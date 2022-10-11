using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float forwardSpeed = 1f;
    public float horizontalSpeed = 1f;
    private float jumpHeight = 1000f;
    private float g = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = Vector3.zero;
        moveVector +=(Vector3.up*g);
        if(Input.GetAxis("Vertical") != 0){
            moveVector +=(Vector3.forward * Input.GetAxis("Vertical") * forwardSpeed);
        }
        if(Input.GetAxis("Horizontal") != 0){
            moveVector +=(Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed);
        }
        if(Input.GetButtonDown("Jump") ){//&& characterController.isGrounded
            moveVector +=(Vector3.up * jumpHeight );
        }
        characterController.Move(moveVector* Time.deltaTime);
    }
    
}
// Vector3 moveVector = Vector3.zero;
//         characterController.Move(Vector3.up*g * Time.deltaTime);
//         if(Input.GetAxis("Vertical") != 0){
//             characterController.Move(Vector3.forward * Input.GetAxis("Vertical") * forwardSpeed * Time.deltaTime);
//         }
//         if(Input.GetAxis("Horizontal") != 0){
//             characterController.Move(Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime);
//         }
//         if(Input.GetButtonDown("Jump") && characterController.isGrounded){
//             characterController.Move(Vector3.up * jumpHeight * Time.deltaTime);
//         }