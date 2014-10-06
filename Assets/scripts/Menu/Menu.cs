using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public void startGame() {
        Application.LoadLevel("main");
    }

    public void showHighscores() {
        Application.LoadLevel("highscore"); 
    }
}
