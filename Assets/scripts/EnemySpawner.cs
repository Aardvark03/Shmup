using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyToSpawn;

    float minX;
    float maxX;
    float minY;
    float maxY;

    float enemyWidth;

    void Start() {
        
        minX = GameController.worldBounds.x;
        maxX = minX + GameController.worldBounds.width;
        minY = GameController.worldBounds.y;
        maxY = minY + GameController.worldBounds.height;

        Debug.Log(GameController.worldBounds);

        enemyWidth = enemyToSpawn.renderer.bounds.extents.x;

        StartCoroutine("spawn");
    }

    IEnumerator spawn() {
        while (true) {
            for (int i = 0; i<GameController.currentLevel; i++) {
                if (Random.Range(0, 2) == 1) {
                    float xPos = Random.Range(minX + enemyWidth, maxX - enemyWidth);
                    Instantiate(enemyToSpawn, new Vector3(xPos, maxY, 0f), Quaternion.Euler(0, 0, 180));
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    }
