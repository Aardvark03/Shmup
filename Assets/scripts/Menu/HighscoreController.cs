using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class HighscoreController : MonoBehaviour {
    public Text highscoreText;

    void Start() {
        highscoreText.text = HighscoreManager.Instance.getHighscoreTable();
    }
    
    public void backToMenu() {
        Application.LoadLevel("Menu");
    }
}
