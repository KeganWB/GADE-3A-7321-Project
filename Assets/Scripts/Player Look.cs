using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public Camera _camera;

    private float xRotation = 0f;

    public float xSensitivity = 15f;
    public float ySensitivity = 15f;
    // Start is called before the first frame update
    public void LookManagement(Vector2 input)
    {
        float _mouseX = input.x;
        float _mouseY = input.y;

        xRotation -= (_mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80f);
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate((Vector3.up * (_mouseX*Time.deltaTime * xSensitivity)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
