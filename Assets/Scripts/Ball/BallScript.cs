using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    BallController controller;

    public void SetController(BallController controller) {
        this.controller = controller;
    }

    void OnCollisionExit2D(Collision2D collision) {
        controller.OnCollisionExit2D(collision);
    }
}
