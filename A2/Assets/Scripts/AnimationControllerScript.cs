using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    public float xVel, yVel;
    public bool sprint;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprint = false;
    }

    // Update is called once per frame
    void Update()
    {
        xVel =0f;
        yVel = 0f;
        bool wPress = Input.GetKey("w");
        bool aPress = Input.GetKey("a");
        bool dPress = Input.GetKey("d");
        bool sPress = Input.GetKey("s");

if (Input.GetKeyDown(KeyCode.LeftShift)) sprint = !sprint;
        //xVel is forward/back
        if (wPress){
            xVel +=1;
        }
        if (sPress){
            xVel -=1;
        }
        if (aPress){
            yVel +=1;
        }
        if (dPress){
            yVel -=1;
        }

        //looks weird
        if(xVel>0){
            if(yVel>0){
                yVel = -1;
            }else if (yVel<0){
                yVel = 1;
            }else{
                yVel = 0;
            }
        }

        animator.SetFloat("xVelocity", xVel);
        animator.SetFloat("yVelocity", yVel);
        if (sprint){
            animator.speed = 1.4f; 
        }else{
            animator.speed = 1f; 
        }
        
    }
}
