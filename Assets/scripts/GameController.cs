using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    int kills;
    public Camera camera;
    public Text scoreText;
    public GameObject playerPrefab;

    public static Rect worldBounds;

    void Start() {
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
        Bullet.OnEnemyDestroyed += OnEnemyDestroyed;
        Player.OnGameOver += OnGameOver;
    }

    void OnEnemyDestroyed() {
        kills += 1;
        scoreText.text = "Score: " + kills;
    }

    void OnGameOver() {
        Debug.Log("Game Over. Total Score: " + kills);
        Debug.Log("Restarting");

        kills = 0;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
            Instantiate(playerPrefab);
            scoreText.text = "Score: 0";
        }
    }

}
