using UnityEngine;
using System.Collections;

public class Biter : MonoBehaviour {
    public float speed;
    public GameObject explosionPrefab;

    float minY;

    void Start() {
        float biterHeight = renderer.bounds.extents.y;

        minY = GameController.worldBounds.y - biterHeight;
    }
    
    void Update () {
        float dt = Time.deltaTime;
        float s = dt * speed;

        Vector3 currentPos = rigidbody2D.position;
        Vector3 targetPos = currentPos + new Vector3(0, -s, 0);

        rigidbody2D.MovePosition(targetPos);

        if (targetPos.y < minY) {
            Destroy(gameObject);
        }
	}
    
    void explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
