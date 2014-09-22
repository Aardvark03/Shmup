using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject bullet;
    public float speed;
    public Camera camera;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

	
	void Update () {
        float dt = Time.deltaTime;
        float s = dt * speed;

        Vector3 currentPosition = rigidbody2D.position;
        Vector3 targetPosition = currentPosition;

        if (Input.GetKey("a")) {
            targetPosition += new Vector3(-s, 0, 0);
        }
        if (Input.GetKey("d")) {
            targetPosition += new Vector3(s, 0, 0);
        }
        
        rigidbody2D.MovePosition(targetPosition);

        if (Input.GetKeyDown("space")) {
            Instantiate(bullet, transform.position + new Vector3(-0.05f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(0.05f, 0, 0), Quaternion.identity);
        }
	}

    void OnTriggerEnter2D(Collider2D enteringCollider) {
        if (enteringCollider.gameObject.tag == "Enemy") {
            if (OnGameOver != null) {
                OnGameOver();
            }

            Destroy(enteringCollider.gameObject);
            Destroy(gameObject);
        }
    }
}
