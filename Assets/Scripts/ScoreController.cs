using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    private string scoreString;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(){
        scoreString = "Score: " + score.ToString("D6");
        GetComponent<Text>().text= scoreString;
    }
}
