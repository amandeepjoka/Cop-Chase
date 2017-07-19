using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWheels : MonoBehaviour {

    public WheelCollider myWheelCollider;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(myWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0); //making the wheels spin.
        Vector3 temp = transform.localEulerAngles;
        temp.y = myWheelCollider.steerAngle - transform.localEulerAngles.z;
        transform.localEulerAngles = temp; //turning the wheels left or right.
        RaycastHit hit;
        Vector3 wheelPos;
        if (Physics.Raycast(myWheelCollider.transform.position, -myWheelCollider.transform.up, out hit, myWheelCollider.radius + myWheelCollider.suspensionDistance))
        {
            wheelPos = hit.point + myWheelCollider.transform.up * myWheelCollider.radius;
        }
        else
        {
            wheelPos = myWheelCollider.transform.position - myWheelCollider.transform.up * myWheelCollider.suspensionDistance;
        }
        transform.position = wheelPos;
    }
}