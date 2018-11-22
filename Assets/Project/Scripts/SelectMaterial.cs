using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaterial : MonoBehaviour {
    public Image crosshair;
    public Dictionary<Material, Color> materialsColor = new Dictionary<Material, Color>();
    public Material selectedMaterial;


    // Use this for initialization
    void Start () {
        materialsColor.Add(Material.Earth, new Color(.55f, .3f, .1f));
        materialsColor.Add(Material.Grass, new Color(0, .5f, 0));
        materialsColor.Add(Material.Sticky, new Color(.8f, .8f, 0));
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

        crosshair.color = materialsColor[selectedMaterial];
    }
}
