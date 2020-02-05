using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config Parameters 

    Vector2 paddleToBallVector;
    private bool hasStarted = false;

    AudioSource myAudiosource;
    Rigidbody2D myRigidBody2D;
    [SerializeField] Paddle paddle1;
    [SerializeField] float xSpeed = 2f;
    [SerializeField] float ySpeed = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudiosource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
       
    }

    private void LockBallToPaddle(){
        Vector2 paddlePos = new Vector2 (paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchBallOnMouseClick(){
        if(Input.GetMouseButtonDown(0)){
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xSpeed,ySpeed);
        }
    }

     private void OnCollisionEnter2D(Collision2D other) {

        //Vector2 velocityTweak = new Vector2 (Random.Range(0f,randomFactor), Random.Range(0f,randomFactor));

         if(hasStarted){
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudiosource.PlayOneShot(clip);
            float randomAngle = Random.Range(-randomFactor, randomFactor);
            myRigidBody2D.velocity = Quaternion.Euler(0, 0, randomAngle) * myRigidBody2D.velocity;
            //myRigidBody2D.velocity += velocityTweak;
         }
    }
}
