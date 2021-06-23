using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    [SerializeField] PaddleController paddle;
    [SerializeField] float speedX = 2f;
    [SerializeField] float speedY = 10f;
    [SerializeField] AudioClip[] ballsounds;
    Vector2 distancePaddleToBall;
    bool isBallShot = false;


    // Start is called before the first frame update
    void Start()
    {
        

        //abstands vektor zwischen ball und paddle ist vector des balls minus den vektor des paddles
        distancePaddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (!isBallShot)
        {
            LockBallToPaddle();
            ShootBallOnMouseClick();
        }
            


    }

    private void ShootBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX , speedY);
            isBallShot = true;
        }
       
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + distancePaddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
  
    {
        if (isBallShot)
        {
            int randomNumber = UnityEngine.Random.Range(0, ballsounds.Length);
            AudioClip clip = ballsounds[randomNumber];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        
    }
}
