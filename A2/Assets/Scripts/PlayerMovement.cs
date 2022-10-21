using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    //camera controll
    public Camera mainCam;
    private float mxspeed = 120f, myspeed = 120f;
    //player movement
    private float forwardSpeed = 3f, horizontalSpeed = 2f;
    private float jumpHeight = 3.75f, yVelocity;
    private bool run;
    //private float oriStepOffset = 0.3f;
    //other
    public float testFloat;
    //private float mAngleX=0, mAngleY=0;
    public float g = -9.81f;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {

        // mAngleY += Input.GetAxis("Mouse X")* Time.deltaTime * mxspeed;
        // mAngleX += Input.GetAxis("Mouse Y")* Time.deltaTime * myspeed;
        // mAngleX = Mathf.Clamp(mAngleX, -70, 35);

        // transform.rotation = Quaternion.AngleAxis(mAngleY, Vector3.up);

        // camera.transform.rotation = Quaternion.AngleAxis(-mAngleX, Vector3.right);

        //camera x
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mxspeed;
        transform.Rotate(Vector3.up * mouseX);

        //would like to put limits

        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime * myspeed;

        float camXAngle = mainCam.transform.rotation.eulerAngles.x;

        if (camXAngle > 180)
        {
            camXAngle -= 360;
        }

        //Debug.Log("Before: " + camera.transform.rotation.x + " " + mouseY);
        //neg my is up
        if ((camXAngle) >= -70)
        {
            if (mouseY <= 0)
            {
                mainCam.transform.Rotate(Vector3.right * mouseY);
            }
        }
        if (camXAngle <= 35)
        {
            if (mouseY >= 0)
            {
                mainCam.transform.Rotate(Vector3.right * mouseY);
            }
        }
        //Debug.Log("After: " + camXAngle + " " + mouseY);
        // camera.transform.Rotate(Vector3.right * mouseY);


        //movement
        Vector3 moveVector = Vector3.zero;
        //forward/horisontal
        if (Input.GetKeyDown(KeyCode.LeftShift)) run = !run;
        float moveSpeedMultiplier = (run) ? moveSpeedMultiplier = 2f : moveSpeedMultiplier = 1.2f;
        if (Input.GetAxis("Vertical") != 0)
        {
            moveVector += (transform.forward * Input.GetAxis("Vertical") * forwardSpeed * moveSpeedMultiplier);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            moveVector += (transform.right * Input.GetAxis("Horizontal") * horizontalSpeed * moveSpeedMultiplier);
        }
        if (moveVector.magnitude > forwardSpeed)
        {
            moveVector = moveVector.normalized * forwardSpeed * moveSpeedMultiplier;
        }
        // if(moveVector != Vector3.zero){
        //     characterController.Move(moveVector* Time.deltaTime);
        // }
        //jump
        // cant get isGrounded to work properly
        yVelocity += g * Time.deltaTime;
        isGrounded = CheckIsGrounded();
        if (isGrounded)
        {
            yVelocity = -0.5f;
            if (Input.GetButtonDown("Jump")) {
                yVelocity = jumpHeight;
            }
        }

        moveVector.y = yVelocity;
        testFloat = yVelocity;
        characterController.Move((moveVector) * Time.deltaTime);
    }

    bool CheckIsGrounded()
    {//ray max dist was 0.2, stopped the player from jumping
    //smaller the jump the smaller the ray must be   ratio seems to work >=  250 : 1
        if (Physics.Raycast(this.transform.position, -Vector3.up, 0.01f)){
            return true;
        }
        return false;
    }


}
