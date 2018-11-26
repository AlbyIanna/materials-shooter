using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShoot : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private int _fireRate = 9999;
    [SerializeField] private int _firePower = 100;
    [SerializeField] private int _startingAmmo = 9999;
    [SerializeField] private SelectMaterial selectMaterial;
    [SerializeField] private Text PowerText;

    private int _currentAmmo;
    private float _timeToNextShoot;

    // Use this for initialization
    void Start()
    {
        _currentAmmo = _startingAmmo;
        _timeToNextShoot = 0;
        PowerText.text = "Power: " + _firePower.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _timeToNextShoot && _currentAmmo > 0)
        {
            fireCube();
        }

        // Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentAmmo = _startingAmmo;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            _firePower += 1000;
        }
    
        if (Input.GetKeyDown(KeyCode.O)) {
            _firePower -= 1000;
        }

        _firePower += (int) Mathf.Floor(Input.mouseScrollDelta.y * 100);

        PowerText.text = "Power: " + _firePower.ToString();
    }

    void fireCube()
    {
        _currentAmmo--;
        _timeToNextShoot = Time.time + 1f / _fireRate;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<MeshRenderer>().material.color = selectMaterial.selected.color;
        cube.transform.position = _camera.transform.position + _camera.transform.forward * 2;
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.mass = selectMaterial.selected.density;
        rb.AddForce(_camera.transform.forward * _firePower);
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

    }
}
