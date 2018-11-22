using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	public void HitTarget(Color color) {
		GetComponent<MeshRenderer> ().material.color = color;
		Destroy (gameObject, 1);
	}
}
