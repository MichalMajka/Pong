using UnityEngine;
using System.Collections;

public class ScoreBoundaryScript: MonoBehaviour {

    public Player playerToScore;

    void OnTriggerEnter2D(Collider2D collider) {
        Scores.PlayerScores(playerToScore);
    }
}
