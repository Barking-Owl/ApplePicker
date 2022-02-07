/****
 * Created by: Andrew Nguyen
 * Date Created: Feb 7 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edit: Feb 7 2022
 * 
 * Description: Manages and preserves high score. Also references PlayerPrefs to make sure high score is preserved
*
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Since the script interacts with UI elements

public class HighScore : MonoBehaviour
{

    static public int score = 1000; //Score; making it static makes accessing it from other scripts easy

    //Awake() is always called before start

    private void Awake()
    {
        //If high score is already there on PlayerPrefs then get that
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //Set high score to HighScore
        PlayerPrefs.SetInt("HighScore", score);
    } //end Awake()

    // Start is called before the first frame update
    void Start()
    {
        
    } //end Start()

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>(); //Display the score value in text
        gt.text = "High Score : " + score;

        //Update playerprefs HighScore
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        } //end if
    } //end Update()
}
