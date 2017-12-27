using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;
    public float distanceToRaise = 40f;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void Awake() {
        rigidBody = this.GetComponent<Rigidbody>();
        //this.GetComponent<Rigidbody>().solverVelocityIterations = 100;
        rigidBody.solverIterations = 50;
    }

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
            return true;
        } else {
            return false;
        }
    }

    public void RaiseIfStanding () {
        if (IsStanding()) {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    }

    public void Lower () {
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigidBody.useGravity = true;
        rigidBody.freezeRotation = true;
    }

    public void ResetPin() {
        if (gameObject) {
            rigidBody.freezeRotation = true;
            rigidBody.useGravity = true;
        }
    }
}
