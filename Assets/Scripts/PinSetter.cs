using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    
    public float distanceToRaise = 0.40f;
    public GameObject pinSet;

    private PinCounter pinCounter;
    private Animator animator;

    // Use this for initialization
    void Start () {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
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

    public void PerformAction(ActionMaster.Action action) {
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }

    public void RenewPins() {
        GameObject pins = Instantiate(pinSet, new Vector3(0, distanceToRaise, 18.29f), Quaternion.identity) as GameObject;
        foreach (Rigidbody rib in pins.GetComponentsInChildren<Rigidbody>()) {
            rib.freezeRotation = true;
        }
    }

    private void OnTriggerExit(Collider collider) {
        GameObject thingLeft = collider.gameObject;
        
        if (thingLeft.GetComponent<Pin>()) {
            Destroy(thingLeft);
        }
    }
}
