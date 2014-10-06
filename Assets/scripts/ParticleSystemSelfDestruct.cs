using UnityEngine;
using System.Collections;

public class ParticleSystemSelfDestruct : MonoBehaviour {
    void Update() {
        if (!particleSystem.IsAlive()) {
            Destroy(gameObject);
        }
    }
}
