using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public float speed;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    Vector3 getDistanceToMove() {
        Vector3 distanceToMove = new Vector3(0f, 0f, 0f);
    
        float dt = Time.deltaTime;
        float s = dt * speed;

        if (Application.platform == RuntimePlatform.Android) {
            float acceleration = Input.acceleration.x;

            if (acceleration > -0.1f && acceleration < 0.1f) {
                return distanceToMove;
            }

            if (acceleration > 0) {
                distanceToMove.x += s;
            } else {
                distanceToMove.x -= s;
            }
        } else {
            if (Input.GetKey("a")) {
                distanceToMove.x -= s;
            }
        
            if (Input.GetKey("d")) {
                distanceToMove.x += s; 
            }
        }

        return distanceToMove;
    }

	
	void Update () {
        Rect worldBounds = GameController.worldBounds;
        float width = renderer.bounds.extents.x;

        Vector3 currentPosition = rigidbody2D.position;
        Vector3 targetPosition = currentPosition;

        targetPosition += getDistanceToMove();
        
        if (targetPosition.x - width < worldBounds.x || targetPosition.x + width > worldBounds.x + worldBounds.width) {
            targetPosition = currentPosition;
        }


        rigidbody2D.MovePosition(targetPosition);


        if (Input.GetKeyDown("space")) {
            Instantiate(bulletPrefab, transform.position + new Vector3(-0.05f, 0, 0), Quaternion.identity);
            Instantiate(bulletPrefab, transform.position + new Vector3(0.05f, 0, 0), Quaternion.identity);
            audio.Play();
        }

         foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Ended) {
                Instantiate(bulletPrefab, transform.position + new Vector3(-0.05f, 0, 0), Quaternion.identity);
                Instantiate(bulletPrefab, transform.position + new Vector3(0.05f, 0, 0), Quaternion.identity);
                audio.Play(); 
            }
        }
	}

    void explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D enteringCollider) {
        if (enteringCollider.gameObject.tag == "Enemy") {
            
            enteringCollider.gameObject.SendMessage("explode", null, SendMessageOptions.DontRequireReceiver);
            explode();

            if (OnGameOver != null) {
                OnGameOver();
            }
        }
    }
}
