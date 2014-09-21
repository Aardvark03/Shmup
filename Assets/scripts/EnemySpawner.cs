﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyToSpawn;
    public Camera camera;

    float minX;
    float maxX;
    float minY;
    float maxY;

    void Start() {
        if (camera == null) {
            camera = Camera.main;
        }

        Vector3 upperRight = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 upperRightWorld = camera.ScreenToWorldPoint(upperRight);

        Vector3 lowerLeft = new Vector3(0f, 0f, 0f);
        Vector3 lowerLeftWorld = camera.ScreenToWorldPoint(lowerLeft);

        minX = lowerLeftWorld.x;
        minY = lowerLeftWorld.y;
        maxX = upperRightWorld.x;
        maxY = upperRightWorld.y;

        StartCoroutine("spawn");
    }

    IEnumerator spawn() {
        while (true) {
            Debug.Log("Probieren!");
            if (Random.Range(0, 2) == 1) {
                Debug.Log("Yeah!");
                float xPos = Random.Range(minX, maxX);
                Instantiate(enemyToSpawn, new Vector3(xPos, maxY, 0f), Quaternion.Euler(0, 0, 180));
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
