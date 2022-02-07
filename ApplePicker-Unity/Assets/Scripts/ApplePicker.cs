/****
 * Created by: Andrew Nguyen
 * Date Created: Feb 1 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Feb 7 2022
 * 
 * Description: The game manager. Attached to main camera (or its own game manager script)
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("SET IN INSPECTOR")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>(); //List that manages the baskets
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab); //Instantiate three baskets at the bottom of screen.
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        } //end for loop
    } //end Start()

    // Update is called once per frame
    void Update()
    {
        
    } //end Start()

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGo in tAppleArray)
        {
            Destroy(tGo); //We lose a basket, but also destroy all apples to give the player a moment of respite
        } //end foreach

        //Destroy a basket. First we get the index of a basket in the list:
        int basketIndex = basketList.Count - 1;
        //Get the reference to the Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        //Remove it and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //What if no baskets left? The game reloads
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene-01");
        }
    } //end AppleDestroyed()
}
