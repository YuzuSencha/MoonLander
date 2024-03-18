using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSplashController : MonoBehaviour
{
    string scoreText = "500Pts";
    float offset = 3.0f;
    Text t;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        this.t = GetComponent<Text>();
        t.text = scoreText;     
        c = t.color;
        
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(t.color.a);
        if(t.color.a > 0f){
            
            c.a -= 0.01f;
            Debug.Log(c.a);
            gameObject.transform.position += Vector3.up * offset * Time.deltaTime;
            t.color = c;
        }else{
            Debug.Log("Destroyed text");
            Destroy(gameObject);
        }
        
               

    }

    

    


}
