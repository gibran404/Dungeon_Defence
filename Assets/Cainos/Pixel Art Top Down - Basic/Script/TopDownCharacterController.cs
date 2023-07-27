﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed = 10f;
        Vector2 lastClickedPos;

        bool moving;

        private void Update(){
            if(Input.GetMouseButtonDown(0)){
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }

            if (moving && (Vector2)transform.position !=  lastClickedPos){
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            }
            else{
                moving = false;

            }
        }
    }
}





        // private Animator animator;

        // private void Start()
        // {
        //     animator = GetComponent<Animator>();
        // }


        // private void Update()
        // {
        //     Vector2 dir = Vector2.zero;
        //     if (Input.GetKey(KeyCode.A))
        //     {
        //         dir.x = -1;
        //         animator.SetInteger("Direction", 3);
        //     }
        //     else if (Input.GetKey(KeyCode.D))
        //     {
        //         dir.x = 1;
        //         animator.SetInteger("Direction", 2);
        //     }

        //     if (Input.GetKey(KeyCode.W))
        //     {
        //         dir.y = 1;
        //         animator.SetInteger("Direction", 1);
        //     }
        //     else if (Input.GetKey(KeyCode.S))
        //     {
        //         dir.y = -1;
        //         animator.SetInteger("Direction", 0);
        //     }

        //     dir.Normalize();
        //     animator.SetBool("IsMoving", dir.magnitude > 0);

        //     GetComponent<Rigidbody2D>().velocity = speed * dir;
        // }
//     }
// }
