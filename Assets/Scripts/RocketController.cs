using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    Rigidbody2D rocket;
    
    private float groundLevel = -4.4f;
    private float maxVSpeed = 15f;
    private float verticalAccel = 1f;
    private float maxHSpeed = 10f;
    private float horizontalAccel = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.rocket = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = (transform.position.y > this.groundLevel)? false : true;
        
        if (Input.GetKey(KeyCode.UpArrow)){
            this.rocket.AddForce(transform.up * this.verticalAccel, ForceMode2D.Force);
        }
        
    }
}
