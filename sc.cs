using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sc : MonoBehaviour
{
    public float speed = 5f;
    RaycastHit hit;
    private bool isMoving = false;
    private Vector3 target;
    private Vector3 check;

    public int count=0;
    void Update()
    {

    //checking it pressed on the player
        if (Input.GetMouseButtonDown(0)&&count==0)
        {
            Vector3 mousePosition = Input.mousePosition;
            float distanceToPlane = 10f;

            // Convert the mouse position to world space using Camera.ScreenToWorldPoint
            check = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanceToPlane));

            // Since the player will be moved to the 2D plane, set its target position's z-coordinate to its current z-coordinate
            check.z = transform.position.z;
            float threshold = 5f;
            if (Vector3.Distance(transform.position, check) < threshold)
            {
                count=1;
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            } 
              
        }
        //setting target
        else if(Input.GetMouseButtonDown(0))
        {
          Vector3 mousePosition = Input.mousePosition;

        // Set a distance from the camera to the desired plane (e.g., the ground plane)
            float distanceToPlane = 10f;

        // Convert the mouse position to world space using Camera.ScreenToWorldPoint
            target = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanceToPlane));

        // Since the player will be moved to the 2D plane, set its target position's z-coordinate to its current z-coordinate
            target.z = transform.position.z;

            isMoving = true;
        }
         if (isMoving==true)
         {
            float step = speed * Time.deltaTime;
         
        // Move the player towards the targetPosition
            transform.position = Vector3.MoveTowards(transform.position, target, step);

        // If you want to stop when the player reaches very close to the target, you can use a threshold distance.
            float threshold = 0.1f;
            if (Vector3.Distance(transform.position, target) < threshold)
            {
                isMoving = false;
                count=0;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            }

         }
        
    }

}
