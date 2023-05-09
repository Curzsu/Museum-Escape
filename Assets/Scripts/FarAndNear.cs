using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Camera = UnityEngine.Camera;
using Input = UnityEngine.Input;

public class FarAndNear : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float rotationSpeed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            virtualCamera.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            virtualCamera.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
