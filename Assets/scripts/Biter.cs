using UnityEngine;
using System.Collections;

public class Biter : MonoBehaviour {
    public float speed;

	void Update () {
        float dt = Time.deltaTime;
        float s = dt * speed;

        transform.position = transform.position + new Vector3(0, -s, 0);
	}
}
