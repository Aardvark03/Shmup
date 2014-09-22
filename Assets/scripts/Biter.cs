using UnityEngine;
using System.Collections;

public class Biter : MonoBehaviour {
    public float speed;
    public Camera camera;

    float minY;

    void Start() {
        if (camera == null) {
            camera = Camera.main;
        }

        float biterHeight = renderer.bounds.extents.y;

        Vector3 lowerLeft = new Vector3(0f, 0f, 0f);
        Vector3 lowerLeftWorld = camera.ScreenToWorldPoint(lowerLeft);
        minY = lowerLeftWorld.y - biterHeight;
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
}
