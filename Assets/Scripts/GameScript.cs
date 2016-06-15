using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    public GameObject ball;

    bool gamePending;
    BallController ballConroller;

    public void EndGame() {
        gamePending = false;
        ballConroller.ResetBall();
    }

	void Start () {
        Cursor.visible = false;
        PrepareMainBall();
        PrepareScoreTable();
        StartCoroutine(StartGame());
	}

    void Update() {
        if(!gamePending)
            StartCoroutine(StartGame());
    }

    IEnumerator StartGame() {
        gamePending = true;
        ballConroller.ResetBall();
        yield return new WaitForSeconds(2f);
        ballConroller.StartGame();
    }

    void PrepareMainBall() {
        ballConroller = new SimpleBallController();
        ball.GetComponent<BallScript>().SetController(ballConroller);
        ballConroller.Ball = ball;
    }

    void PrepareScoreTable() {
        Scores.PreparePlayers();
        Scores.SetGameScript(this);
    }
}
