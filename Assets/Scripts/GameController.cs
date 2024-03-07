using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject rocket;
    RocketController rc; 
    PlatformController pc;
    public GameObject platform;
    Vector3 platformCoordiate;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlatform();
        this.rocket = GameObject.Find("Rocket");
        if(this.rocket != null){
            this.rc = this.rocket.GetComponent<RocketController>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rightWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        Vector3 leftWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));

        if(this.rocket.transform.position.x < leftWorldPoint.x){
            this.rocket.transform.position = new Vector3(rightWorldPoint.x, this.rocket.transform.position.y,0);
        }
        if(this.rocket.transform.position.x > rightWorldPoint.x){
            this.rocket.transform.position = new Vector3(leftWorldPoint.x, this.rocket.transform.position.y,0);
        }
    }

    Vector3 GenerateCoordinate(){
        Vector3 randomPt = new (Random.Range(0,Screen.width),Random.Range(0,Screen.height),0);
        Vector3 screenPt = Camera.main.ScreenToWorldPoint(randomPt);
        return screenPt;
    }

    public void CreatePlatform(){
        Debug.Log("EventFired");
        platformCoordiate = GenerateCoordinate(); 
        Instantiate(this.platform, platformCoordiate, Quaternion.identity);
        
    }
}
