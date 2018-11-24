using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaterial : MonoBehaviour {
    public Image crosshair;
    public Material selectedMaterial;

    // Use this for initialization
    void Start () {
        selectedMaterial = Material.Earth;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedMaterial = Material.Earth;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedMaterial = Material.Grass;
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedMaterial = Material.Sticky;
        }

        crosshair.color = Materials.getColorByMaterial(selectedMaterial);
    }
}
