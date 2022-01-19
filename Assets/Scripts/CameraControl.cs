using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Camera's position should be the same as the car's position
    [SerializeField] GameObject car;
    private Vector3 cameraOffset = new Vector3(0, 0, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = car.transform.position + cameraOffset;
    }
}
