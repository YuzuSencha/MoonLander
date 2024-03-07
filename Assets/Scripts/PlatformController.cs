using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformController : MonoBehaviour
{
    float timer = 3f;
    public UnityEvent onPlatformDestroy = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        onPlatformDestroy.AddListener(GameObject.Find("Logic").GetComponent<GameController>().CreatePlatform);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
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

    public void Test(){

    }
}
