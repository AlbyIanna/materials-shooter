using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	public void HitTarget() {
		GetComponent<MeshRenderer> ().material.color = Color.green;
		Destroy (gameObject, 1);
	}
}
