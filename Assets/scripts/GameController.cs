using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    int kills;

    void Start() {
        kills = 0;
        Bullet.OnEnemyDestroyed += OnEnemyDestroyed;
        Player.OnGameOver += OnGameOver;
    }

    void OnEnemyDestroyed() {
        kills += 1;
        Debug.Log("New Score: " + kills);
    }

    void OnGameOver() {
        Debug.Log("Game Over. Total Score: " + kills);
    }

}
