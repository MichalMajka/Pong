using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

    public float boundary;

    protected GameObject paddle;
    protected Rigidbody2D paddleRigidbody;
    protected float inputVelocity;
    protected float positionOfPaddleInXAxis;

    protected virtual void Start() {
        paddle = gameObject;
        paddleRigidbody = paddle.GetComponent<Rigidbody2D>();
	}

    protected void Update() {
        GetInput();
        GetPosition();
        MovePaddle();
    }

    protected virtual void GetInput() {
        inputVelocity = Input.GetAxis("Mouse X");
    }

    protected void GetPosition() {
        positionOfPaddleInXAxis = paddle.transform.position.x;
    }

    protected void MovePaddle() {
        SetPaddleVelocity();
        if(!CanPaddleStillMove()) {
            StopPaddle();
            SetPaddleInBoundaries();
        }
    }

    protected void SetPaddleVelocity() {
        paddleRigidbody.velocity = new Vector2(inputVelocity * 10f, 0f);
    }

    protected void StopPaddle() {
        paddleRigidbody.velocity = Vector2.zero;
    }

    protected void SetPaddleInBoundaries() {
        if(!IsPaddleInLeftBound())
            paddle.transform.position = new Vector2(-boundary, paddle.transform.position.y);
        else if(!IsPaddleInRightBound())
            paddle.transform.position = new Vector2(boundary, paddle.transform.position.y);
    }

    protected bool CanPaddleStillMove() {
        if(!IsPaddleInRightBound() && IsPlayerMovingRight())
            return false;
        if(!IsPaddleInLeftBound() && IsPlayerMovingLeft())
            return false;
        return true;
    }

    protected bool IsPaddleInLeftBound() {
        if(positionOfPaddleInXAxis > -boundary)
            return true;
        else
            return false;
    }

    protected bool IsPaddleInRightBound() {
        if(positionOfPaddleInXAxis < boundary)
            return true;
        else
            return false;
    }

    protected bool IsPlayerMovingRight() {
        if(paddleRigidbody.velocity.x > 0f)
            return true;
        else
            return false;
    }

    protected bool IsPlayerMovingLeft() {
        if(paddleRigidbody.velocity.x < 0f)
            return true;
        else
            return false;
    }
}
