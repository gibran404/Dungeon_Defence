using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static List<PlayerMovement> moveableObjects = new List<PlayerMovement>();
    public float speed = 10f;
    private Vector3 target;

    public bool selected;
    public int count; //count used to distinguish between select, move and deselect taps


    void Start()
    {
        moveableObjects.Add(this);
        target = transform.position;
        count = 0;
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && selected)
        {
            count++;
            if(count == 2)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;

                selected = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                count = 0;
            }
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    private void OnMouseDown()
    {
        
        selected = true;
        
        //add an animation or whatever to show it is selected
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        foreach (PlayerMovement obj in moveableObjects)
        {
            if(obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
    }
}