using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public Camera camera;

    public Text scoreText;
    public Text levelText;

    public GameObject playerPrefab;

    public static Rect worldBounds;
    public static int currentLevel;
    int kills;

    void Awake() {
        if (camera == null) {
            camera = Camera.main;
        }

        Vector3 upperRight = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 upperRightWorld = camera.ScreenToWorldPoint(upperRight);

        Vector3 lowerLeft = new Vector3(0f, 0f, 0f);
        Vector3 lowerLeftWorld = camera.ScreenToWorldPoint(lowerLeft); 

        worldBounds = new Rect(lowerLeftWorld.x,
                               lowerLeftWorld.y,
                               upperRightWorld.x - lowerLeftWorld.x,
                               upperRightWorld.y - lowerLeftWorld.y);

        kills = 0;
        currentLevel = 1;

        Bullet.OnEnemyDestroyed += OnEnemyDestroyed;
        Player.OnGameOver += OnGameOver;

        StartCoroutine("setLevel");
    }

    void OnDestroy() {
        Bullet.OnEnemyDestroyed -= OnEnemyDestroyed;
        Player.OnGameOver -= OnGameOver;
    }

    IEnumerator setLevel() {
        while (true) {
            yield return new WaitForSeconds(15f);
            currentLevel += 1;
            levelText.text = "Level: " + currentLevel;
        }
    }

    void OnEnemyDestroyed() {
        kills += 1;
        scoreText.text = "Score: " + kills;
    }

    IEnumerator backToMenu() {
        yield return new WaitForSeconds(3f);

        Application.LoadLevel("Menu"); 
    }

    void OnGameOver() {
        Debug.Log("Game Over. Total Score: " + kills);
        
        if (HighscoreManager.Instance.checkHighscore(kills)) {
            Debug.Log("A new Highscore!");
        } else {
            Debug.Log("No Highscore :(");
        }

        StartCoroutine ("backToMenu");

    }

}
