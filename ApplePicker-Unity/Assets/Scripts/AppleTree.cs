/****
 * Created by: Andrew Nguyen
 * Date Created: Jan 31 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Jan 31 2022
 * 
 * Description: Controls movement of apple tree AppleTree.
*
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    /**** VARIABLES ****/
    [Header("SET IN INSPECTOR")]
    public float speed = 1f; //speed of tree
    public float leftAndRightEdge = 10f; // distance where tree turns around
    public GameObject applePrefab; //the apple prefabs for instantation
    public float appleDropInterval = 1f; //time between apple drops
    public float directionChangeChance = 0.1f; //Chance the tree changes directions


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position; //Record the current position
        //Time.deltaTime measures the number of seconds since the last frame, it is consistent every time. Time.Time counts by frame.
        pos.x += speed * Time.deltaTime; //Add speed to x position
        transform.position = pos; //Set position of the tree to pos' value to move it

        //Change direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //positive speed
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //negative speed
        } //end change directions


    } //end Update(). This fires every frame.

    //Fixed update, called on fixed intervals (50 times per second)
    private void FixedUpdate()
    {
        //Test chance of direction change
        if(Random.value < directionChangeChance)
        {
            speed *= -1; //Change the direction of tree
        }
    } //End FixedUpdate()
}
