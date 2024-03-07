using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float walkSpeed = 12.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] bool lockCursor = true;

    
    CharacterController controller = null;


    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();   
    }



    void UpdateMovement() {
        Vector2 currentMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up * currentMouseDelta.x * 3.5f);


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (controller.isGrounded) {
            velocity.y = 0.0f;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = (transform.right * x) + (transform.forward * z) + (Vector3.up * velocity.y);

        controller.Move(move * Time.deltaTime * walkSpeed);


    }

}
