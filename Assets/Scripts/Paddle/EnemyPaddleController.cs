using UnityEngine;
using System.Collections;

public class EnemyPaddleController : PaddleController {

    GameObject ball;

    int difficultyLevel = 10;

    protected override void Start() {
        base.Start();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    protected override void GetInput() {
        float difficultyMultiplier = 5f * difficultyLevel;
        inputVelocity = (ball.transform.position.x - gameObject.transform.position.x) *Time.deltaTime * difficultyMultiplier;
    }

    public int DifficultyLevel {
        set {
            difficultyLevel = value;
        }
        get {
            return difficultyLevel;
        }
    }
}
