using System.Transactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensetivityHor = 9;
    public float sensetivityVert = 9;
    public float minimumVert = -45;
    public float maximumVert = 45;
    public float axisXVal = 0;
    public float axisYVal = 0;
    private float rotationX;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body)
        {
            // Switch off physix impact to rotation 
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        axisXVal = Input.GetAxis("Mouse X");
        axisYVal = Input.GetAxis("Mouse Y");

        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, sensetivityHor * axisXVal, 0);
        } else if (axes == RotationAxes.MouseY) {
            rotationX += sensetivityVert * -axisYVal;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        } else {
            rotationX += sensetivityVert * -axisYVal;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            rotationY = transform.localEulerAngles.y + sensetivityHor * axisXVal;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
