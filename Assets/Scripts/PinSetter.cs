using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 40f;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();    	
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            UpdateStandingCountAndSettle();
        }

    }

    public void PinsIdleState() {
        // Reset to default value when all pins settled on floor
        Pin pin = GameObject.FindObjectOfType<Pin>();
        pin.ResetPin();
    }

    public void RaisePins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins () {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void RenewPins () {
        GameObject pins = Instantiate(pinSet, new Vector3(0, distanceToRaise, 1829), Quaternion.identity) as GameObject;
        foreach (Rigidbody rib in pins.GetComponentsInChildren<Rigidbody>()) {
            rib.freezeRotation = true;
        }
    }

    int CountStanding() {
        int standing = 0;

        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standing++;
            }
        }

        return standing;
    }

    private void UpdateStandingCountAndSettle() {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; //How long to wait to consider pins settled

        if ((Time.time - lastChangeTime) > settleTime) { //If last change > 3s ago
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled() {
        ball.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }


    private void OnTriggerExit(Collider collider) {
        GameObject thingLeft = collider.gameObject;
        
        if (thingLeft.GetComponent<Pin>()) {
            Destroy(thingLeft);
        }
    }

    void OnTriggerEnter(Collider collider) {
        GameObject thingHit = collider.gameObject;
        
        //Ball enters play box
        if (thingHit.GetComponent<Ball>()) {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
}
