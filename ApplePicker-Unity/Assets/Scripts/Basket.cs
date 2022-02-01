/****
 * Created by: Andrew Nguyen
 * Date Created: Feb 1 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Feb 1 2022
 * 
 * Description: Manages basket behavior and movement.
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        } //end if
    } //end onCollisionEnter
} //end Basket
