using System;
using UnityEngine;

public class SimpleBallController : BallController {
    
    protected GameObject ball;
    protected Rigidbody2D ballRigidbody;
    protected Vector2 startPosition;

    float actualVelocity;
    float xValueOfVelocity;
    float yValueOfVelocity;

    float minimumVelocity;
    float maximumVelocity;

    public GameObject Ball {
        set {
            ball = value;
            ballRigidbody = ball.GetComponent<Rigidbody2D>();
            startPosition = ball.transform.position;
        }
    }

    public void StartGame() {
        ballRigidbody.AddForce(Vector2.down * 3f,ForceMode2D.Impulse);
    }

    public void ResetBall() {
        ball.transform.position = startPosition;
        ballRigidbody.velocity = Vector2.zero;
        ballRigidbody.angularVelocity = 360f;
        ResetMinimumAndMaximumVelocities();
    }

    private void ResetMinimumAndMaximumVelocities() {
        minimumVelocity = 4f;
        maximumVelocity = 40f;
    }

    public void OnCollisionExit2D(Collision2D collision) {
        GetVelocities();
        if(IsBallMovingFasterInXThanInY()) {
            ChangeXValueAndYValueOfVelocity();
        }
       if(IsBallMovingTooSlow()) {
            SpeedUpBall();
        }
        if(IsBallMovingTooFast()) {
            SlowDownBall();
        }
        if(IsPaddleHit(collision)) {
            RaiseMaximumAndMinimumVelocity();
            if(IsBallMovingOnlyInY())
                AddForceInX();

        }
    }

    void GetVelocities() {
        actualVelocity = ballRigidbody.velocity.magnitude;
        xValueOfVelocity = ballRigidbody.velocity.x;
        yValueOfVelocity = ballRigidbody.velocity.y;
    }

    bool IsBallMovingFasterInXThanInY() {
        return Mathf.Abs(xValueOfVelocity) > Mathf.Abs(yValueOfVelocity);
    }

    bool IsBallMovingTooSlow() {
        return actualVelocity < minimumVelocity;
    }

    bool IsBallMovingTooFast() {
        return actualVelocity > maximumVelocity;
    }

    void ChangeXValueAndYValueOfVelocity() {
        float halfOfVelocityValue = actualVelocity / 2f;
        float newXValue = halfOfVelocityValue * Mathf.Sign(xValueOfVelocity);
        float newYValue = halfOfVelocityValue * Mathf.Sign(yValueOfVelocity);
        ballRigidbody.velocity = new Vector2(newXValue, newYValue);
    }

    void SpeedUpBall() {
        ballRigidbody.velocity = ballRigidbody.velocity.normalized * minimumVelocity;
    }

    void SlowDownBall() {
        ballRigidbody.velocity = ballRigidbody.velocity.normalized * maximumVelocity;
    }

    bool IsPaddleHit(Collision2D collision) {
        return collision.gameObject.tag == "Player";
    }

    void RaiseMaximumAndMinimumVelocity() {
        if(minimumVelocity < 20f) {
            minimumVelocity += .1f;
        }
    }

    bool IsBallMovingOnlyInY() {
        return Math.Abs(xValueOfVelocity) < 0.1f;
    }

    private void AddForceInX() {
        ballRigidbody.AddForce(Vector2.right * Mathf.Sign(xValueOfVelocity) * 1.5f, ForceMode2D.Impulse);
    }
}
