using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configiration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;

    // Start is called before the first frame update
    void Start()
    { 
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float xPushRandom = UnityEngine.Random.Range(-xPush, xPush);
            //float yPushRandom = UnityEngine.Random.Range(0.2f, 15.0f);
            hasStarted = true;
            myRigidBody2d.velocity = new Vector2(xPushRandom, yPush);
        }
    }



    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomMakerTweak = UnityEngine.Random.Range(0f, randomFactor);
        Vector2 velocityTweak = new Vector2(randomMakerTweak, randomMakerTweak);
        
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2d.velocity += velocityTweak;
        }
        
    }
}
