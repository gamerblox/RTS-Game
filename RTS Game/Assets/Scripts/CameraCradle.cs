using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCradle : MonoBehaviour {

    public float ScrollSpeed = 20;
    public float ScrollZone = 30;

    public float x_max = 72;
    public float x_min = 0;
    public float y_max = 125;
    public float y_min = 50;
    public float z_max = 128;
    public float z_min = 0;

    private Vector3 desired_pos;
	
    private void Start()
    {
        desired_pos = transform.position;

    }

	private void Update ()
    {
        //if hold tab then don't move camera
        if (Input.GetKey(KeyCode.Tab))
            return;

        //figure out better way to zoom in

        float x = 0, y = 0, z = 0;
        float speed = ScrollSpeed * Time.deltaTime;

        if (Input.mousePosition.x < ScrollZone)
            x -= speed;
        else if (Input.mousePosition.x > Screen.width - ScrollZone)
            x += speed;

        if (Input.mousePosition.y < ScrollZone)
            z -= speed;
        else if (Input.mousePosition.y > Screen.height - ScrollZone)
            z += speed;

        y -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;

        desired_pos = new Vector3(x, y, z) + transform.position;
        desired_pos.x = Mathf.Clamp(desired_pos.x, x_min, x_max);
        desired_pos.y = Mathf.Clamp(desired_pos.y, y_min, y_max);
        desired_pos.z = Mathf.Clamp(desired_pos.z, z_min, z_max);
        transform.position = Vector3.Lerp(transform.position, desired_pos, 0.2f);

    }
}
