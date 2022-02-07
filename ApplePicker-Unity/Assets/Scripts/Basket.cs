/****
 * Created by: Andrew Nguyen
 * Date Created: Feb 1 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Feb 7 2022
 * 
 * Description: Manages basket behavior and movement.
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Using the Unity UI

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")] //Level designer should not play with this (or hide it)
    public Text scoreGT;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); //get score game object
        scoreGT = scoreGO.GetComponent<Text>(); //text component of the game score
        scoreGT.text = "0"; //String so use quotation marks; sets the text property by default/start to 0. Generally score is in a Game Manager script, which is in its own Game Object.
    } //end Start()

    // Update is called once per frame
    void Update()
    {
        //Get position of mouse
        Vector3 mousePos2D = Input.mousePosition;

        //Camera's z position adjusts the 3rd dimension of the mouse's movement. While using Unity 3D, it functions as a 2D game, and by doing this the mouse's 3D positon in Z-axis is 0.
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert point from the 2D screen to the 3D world
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move X position of Basket to that of the mouse pointer's
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    } //end Update()

    private void OnCollisionEnter(Collision col)
    {
        //Hit registration
        GameObject collidedWith = col.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100; //You could assign the value of an apple to the apple themselves, having it read the apple's property then destroy it.
            scoreGT.text = score.ToString(); //Get the new score and convert it to string

            //High score tracking
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        } //end if
    } //end onCollisionEnter
} //end Basket
