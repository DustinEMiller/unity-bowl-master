using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    public Text standingDisplay;

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();	
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider) {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "Ball") {
            ballOutOfPlay = true;
        }
    }

    public void Reset() {
        lastSettledCount = 10;
    }

    int CountStanding() {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
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

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }
}
