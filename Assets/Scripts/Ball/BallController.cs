using UnityEngine;
using System.Collections;

public interface BallController {
    void StartGame();

    void OnCollisionExit2D(Collision2D collision);

    void ResetBall();

    GameObject Ball {
        set;
    }
}
