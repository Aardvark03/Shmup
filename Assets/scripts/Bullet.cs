using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed;

    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed; 

    float maxY;

    void Start() {
        maxY = GameController.worldBounds.y + GameController.worldBounds.height + renderer.bounds.extents.y;
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

            collider.gameObject.SendMessage("explode", null, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
