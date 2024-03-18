using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject rocket;
    RocketController rc; 
    PlatformController pc;
    ScoreController sc;
    private GameObject gameOverCard;
    public GameObject platform;
    public GameObject splashText;
    Vector3 platformCoordinate;
    public Vector3 prevCoordinate;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlatform();
        this.sc = GameObject.Find("Score").GetComponent<ScoreController>();
        this.rocket = GameObject.Find("Rocket");
        if(this.rocket != null){
            this.rc = this.rocket.GetComponent<RocketController>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver){
            Vector3 rightWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
            Vector3 leftWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));

            if(this.rocket.transform.position.x < leftWorldPoint.x){
                this.rocket.transform.position = new Vector3(rightWorldPoint.x, this.rocket.transform.position.y,0);
            }
            if(this.rocket.transform.position.x > rightWorldPoint.x){
                this.rocket.transform.position = new Vector3(leftWorldPoint.x, this.rocket.transform.position.y,0);
            }
        }else{
            if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("InitScene");
            }
        }
    }

    Vector3 GenerateCoordinate(){
        Vector3 randomPt = new (Random.Range(Screen.width*0.25f,Screen.width*0.75f),Random.Range(Screen.height*0.25f,Screen.height*0.75f),0);
        Vector3 screenPt = Camera.main.ScreenToWorldPoint(randomPt);
        return screenPt;
    }

    public void CreatePlatform(){
           
        platformCoordinate = GenerateCoordinate(); 
        Instantiate(this.platform, platformCoordinate, Quaternion.identity);
        
    }

    public void AddScore(){
        this.sc.score += 500;
        this.sc.UpdateScore();
    }

    public void CreateSplash(){        
        GameObject splash = Instantiate(this.splashText,prevCoordinate,Quaternion.identity,GameObject.Find("Canvas").transform);
        
    }

    public void GameOver(){
        this.gameOverCard = GameObject.Find("GameOverCard");
        this.gameOverCard.GetComponent<Text>().text = "Game Over \nYour Final Score: " + sc.score.ToString() + "\n Press R to restart";
        this.isGameOver = true;
    }
}
