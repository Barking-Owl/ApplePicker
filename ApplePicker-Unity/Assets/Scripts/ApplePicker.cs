/****
 * Created by: Andrew Nguyen
 * Date Created: Feb 1 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Feb 1 2022
 * 
 * Description: The game manager. Attached to main camera.
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("SET IN INSPECTOR")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab); //Instantiate three baskets at the bottom of screen.
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
        } //end for loop
    } //end Start()

    // Update is called once per frame
    void Update()
    {
        
    }
}
