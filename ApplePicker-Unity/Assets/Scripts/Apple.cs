/****
 * Created by: Andrew Nguyen
 * Date Created: Feb 1 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Feb 1 2022
 * 
 * Description: Manages apple behavior and deletion
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    } //end Start()

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    } //end Update()
} //end Apple class
