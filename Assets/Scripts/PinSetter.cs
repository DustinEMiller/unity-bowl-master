using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 0.40f;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private bool ballEnteredBox = false;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            UpdateStandingCountAndSettle();
        }

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
        GameObject pins = Instantiate(pinSet, new Vector3(0, distanceToRaise, 18.29f), Quaternion.identity) as GameObject;
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
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game yet");
        }

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
