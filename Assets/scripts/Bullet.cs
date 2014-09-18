using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed;

    void Start() {
    }

	
	void Update () {
        float dt = Time.deltaTime;
        float s = dt * speed;

        transform.position = transform.position + new Vector3(0, s, 0);

        if (transform.position.y > 2) {
            Destroy(gameObject);
        }
	}
}
