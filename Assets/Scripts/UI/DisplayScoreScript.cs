using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreScript : MonoBehaviour {

    public Player observedPlayer;

    Text display;

    void Start() {
        display = gameObject.GetComponent<Text>();
    }

	void Update() {
        display.text = Scores.GetPlayerScore(observedPlayer).ToString();
    }
}
