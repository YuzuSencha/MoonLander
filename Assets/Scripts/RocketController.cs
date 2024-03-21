using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketController : MonoBehaviour
{
    Renderer[] renderers;
    Rigidbody2D rocket;
    GameController gc;
    public Vector3 com;
    public bool isFlying = false;
    public GameObject expPrefab;    
    private float groundLevel = -4.4f;    
    public float verticalAccel = 5f;
    private float rotationSpeed = 0.5f;
    private AudioSource[] asArray;
    public UnityEvent onRocketDestroyed = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        this.rocket = GetComponent<Rigidbody2D>();
        this.rocket.centerOfMass = this.com;
        this.asArray = GetComponents<AudioSource>();
        this.gc = GameObject.Find("Logic").GetComponent<GameController>();
        onRocketDestroyed.AddListener(gc.GameOver);
        //this.renderers = GetComponentsInChildren();
    }

    bool CheckRenderers(){
        foreach (Renderer r in renderers){
            if(r.isVisible){
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Collided with "+other.gameObject.name+" with force of "+other.relativeVelocity.magnitude);
        if(other.relativeVelocity.magnitude >14 ){
            //explode and destroy rocket
            GameObject expInstance = Instantiate(expPrefab);
            expInstance.transform.position = this.rocket.position;
            
            asArray[0].Play();
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, asArray[0].clip.length); // this combo will destroy object after the audio is played... not great but works for now.


            onRocketDestroyed.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        bool isGrounded = (transform.position.y > this.groundLevel)? false : true;
        this.isFlying = !isGrounded;
        if (Input.GetKey(KeyCode.UpArrow)){
            this.rocket.AddForce(transform.up * this.verticalAccel * Time.deltaTime, ForceMode2D.Force);
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            this.rocket.transform.Rotate(new Vector3(0,0,-this.rotationSpeed));
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            this.rocket.transform.Rotate(new Vector3(0,0,this.rotationSpeed));
        }



        //Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0)); //top right
        //0,0,0 left bottom
        
    }
}
