using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformController : MonoBehaviour
{
    float timer = 2f;
    float maxTimer = 2f;
    public UnityEvent onPlatformDestroy = new UnityEvent();

    GameController gc; 
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("Logic").GetComponent<GameController>();
        onPlatformDestroy.AddListener(gc.CreatePlatform);
        onPlatformDestroy.AddListener(gc.CreateSplash);
        onPlatformDestroy.AddListener(gc.AddScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
            gc.prevCoordinate = gameObject.transform.position;
            onPlatformDestroy.Invoke();
            Destroy(gameObject);            
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {        
        
    }

    private void  OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.name=="Rocket"){
            timer-=Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        timer = maxTimer;        
    }

    public void Test(){

    }
}
