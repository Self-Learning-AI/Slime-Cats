using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothMultiplier = 0.2f;
    public float rotationSpeed = 1.0f;
    public Vector3 cameraOffset = new Vector3(0.0f, 1.0f, -2.0f);
    // public float rotationOffset = 3.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        Vector3 smoothedVector = Vector3.Lerp(transform.position, newPosition, smoothMultiplier);
        transform.position = smoothedVector;

        Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
        Quaternion camTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, Vector3.forward);
        cameraOffset = camTurnAngleX * cameraOffset;
        //cameraOffset = camTurnAngleY * cameraOffset;

        transform.LookAt(player.transform);
        //transform.rotation = Quaternion.Euler(0, rotationOffset, 0);

        /*
        float h = rotationSpeed * Input.GetAxis("Mouse X");
        float v = rotationSpeed * Input.GetAxis("Mouse Y");

        if (player.transform.eulerAngles.z + v <= 0.1f || player.transform.eulerAngles.z + v >= 179.9f)
            v = 0;

        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y + h, player.transform.eulerAngles.z + v);

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        transform.LookAt(player.transform.position);
        */
    }
}
