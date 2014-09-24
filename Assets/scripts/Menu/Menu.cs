using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public void startGame() {
        Debug.Log("Starting Game!");
        Application.LoadLevel("main");
    }
}
