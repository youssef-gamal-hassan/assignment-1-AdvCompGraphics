using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] Camera tpsCam;
    [SerializeField] Camera tdCam;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] Light light;

    float cameraPitch = 0.0f;
    int currentCam = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleActiveCam();
        handleZoomLevel();
        UpdateMouseLook();

        if(Input.GetKey(KeyCode.F)) {
            if (light.enabled) {
                light.enabled = false;
            }
            else {
                light.enabled = true;
            }
        }

    }

    void UpdateMouseLook() {
        if (currentCam != 3) {
            Vector2 currentMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            cameraPitch -= currentMouseDelta.y * mouseSensitivity;
            cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

            fpsCam.transform.localEulerAngles = Vector3.right * cameraPitch;
            tpsCam.transform.localEulerAngles = Vector3.right * cameraPitch;

        }
    }

    void handleActiveCam() {
        if (Input.GetKey(KeyCode.Keypad1)) {
            currentCam = 1;
            fpsCam.enabled = true;
            tpsCam.enabled = false;
            tdCam.enabled = false;
        }
        if (Input.GetKey(KeyCode.Keypad2)) { 
            currentCam = 2;
            tpsCam.enabled = true;
            fpsCam.enabled = false;
            tdCam.enabled = false;

        }
        if(Input.GetKey(KeyCode.Keypad3)) {
            currentCam = 3;
            tdCam.enabled = true;
            fpsCam.enabled = false;
            tpsCam.enabled = false;
        }
    }

    void handleZoomLevel() {
        if (Input.GetKey(KeyCode.Keypad8)) {
            tdCam.fieldOfView = 30;
        }
        if (Input.GetKey(KeyCode.Keypad9)) {
            tdCam.fieldOfView = 60;
        }
        if (Input.GetKey(KeyCode.Keypad0)) {
            tdCam.fieldOfView = 90;
        }
    }


}
