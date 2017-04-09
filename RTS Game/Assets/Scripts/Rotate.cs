using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float RotateVal = 0;
    private float changeRotateVal = 0;

    private Quaternion startRotation;

	void Start ()
    {
        startRotation = transform.rotation;

	}
	
	void Update ()
    {
        //Update changeRotateVal
        changeRotateVal += RotateVal * Time.deltaTime;
        if (changeRotateVal >= 360)
            changeRotateVal = 0;

        //Fix rotation
        transform.rotation = startRotation;

        //Then rotate
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + changeRotateVal);
        transform.rotation = Quaternion.Euler(rot);

    }
}
