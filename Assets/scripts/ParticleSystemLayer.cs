using UnityEngine;
using System.Collections;

public class ParticleSystemLayer : MonoBehaviour {
    public string layerName = "Foreground";
	void Start () {
        particleSystem.renderer.sortingLayerName = layerName;	
	}
}
