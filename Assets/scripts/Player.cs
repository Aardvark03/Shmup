using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject bullet;
    public float speed;	
	
    void Start () {
	}
	
	void Update () {
        float dt = Time.deltaTime;
        float s = dt * speed;

        if (Input.GetKey("a")) {
            transform.position = transform.position + new Vector3(-s, 0, 0);
        }
        if (Input.GetKey("d")) {
            transform.position = transform.position + new Vector3(s, 0, 0);
        }

        if (Input.GetKeyDown("space")) {
            Instantiate(bullet, transform.position + new Vector3(-0.05f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(0.05f, 0, 0), Quaternion.identity);
        }
	}
}
