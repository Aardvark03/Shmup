using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed;
    public Camera camera;

    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed; 

    float maxY;

    void Start() {
        if (camera == null) {
            camera = Camera.main;
        }

        Vector3 upperRight = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 upperRightWorld = camera.ScreenToWorldPoint(upperRight);

        maxY = upperRightWorld.y + renderer.bounds.extents.y;
    }

	
	void Update () {
        float dt = Time.deltaTime;
        float s = dt * speed;

        transform.position = transform.position + new Vector3(0, s, 0);

        if (transform.position.y > maxY) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            if (OnEnemyDestroyed != null) {
                OnEnemyDestroyed();
            } 

            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
