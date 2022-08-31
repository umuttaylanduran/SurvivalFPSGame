using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float sensivity = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayerBody();
    }

    private float rotateY = 0;
    private float rotateX = 0;

    private void RotatePlayerBody()
    {
        rotateX += sensivity * Input.GetAxis("Mouse X");
        rotateY -= sensivity * Input.GetAxis("Mouse Y");
        rotateY = Mathf.Clamp(rotateY, -90, 90);
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
    }
}
