using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialShoot : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private int _fireRate = 9999;
    [SerializeField] private int _firePower = 100;
    [SerializeField] private int _startingAmmo = 9999;
    [SerializeField] private SelectMaterial selectMaterial;

    private int _currentAmmo;
    private float _timeToNextShoot;

    // Use this for initialization
    void Start()
    {
        _currentAmmo = _startingAmmo;
        _timeToNextShoot = 0;
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
    }

    void fireCube()
    {
        _currentAmmo--;
        _timeToNextShoot = Time.time + 1f / _fireRate;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<MeshRenderer>().material.color = selectMaterial.selected.color;
        cube.transform.position = _camera.transform.position + _camera.transform.forward * 2;
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * _firePower);
    }
}
