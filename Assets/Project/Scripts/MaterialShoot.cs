using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShoot : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private int _fireRate = 9999;
    [SerializeField] private int _firePower = 100;
    [SerializeField] private int _startingAmmo = 9999;
    [SerializeField] private float _projectileScale = 1f;
    [SerializeField] private SelectMaterial selectMaterial;

    [SerializeField] private Text PowerText;
    [SerializeField] private Text SizeText;

    private int _currentAmmo;
    private float _timeToNextShoot;

    // Use this for initialization
    void Start()
    {
        _currentAmmo = _startingAmmo;
        _timeToNextShoot = 0;
        PowerText.text = "Power: " + _firePower.ToString();
        SizeText.text = "Size: " + _projectileScale.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Fire
        if (Input.GetButton("Fire1") && Time.time > _timeToNextShoot && _currentAmmo > 0)
        {
            fireCube();
        }

        // Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentAmmo = _startingAmmo;
        }

        // Increase/Decrease fire power
        if (Input.GetKeyDown(KeyCode.P))
        {
            _firePower += 1000;
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            _firePower -= 1000;
        }

        // Increase/Decrease projectile size
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("shift pressed");
            _projectileScale += Input.mouseScrollDelta.y / 20;
        } else
        // Increase/Decrease fire power
        {
            _firePower += (int) Mathf.Floor(Input.mouseScrollDelta.y * 100);
        }

        PowerText.text = "Power: " + _firePower.ToString();
        SizeText.text = "Size: " + _projectileScale.ToString();
    }

    void fireCube()
    {
        _currentAmmo--;
        _timeToNextShoot = Time.time + 1f / _fireRate;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<MeshRenderer>().material.color = selectMaterial.selected.color;
        cube.transform.position = _camera.transform.position + _camera.transform.forward * ( 1 + _projectileScale);
        cube.transform.localScale = new Vector3(_projectileScale, _projectileScale, _projectileScale);
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.mass = selectMaterial.selected.density * Mathf.Pow(_projectileScale, 3); // This formula only applies for cubes. Find a way to calculate for other shapes
        rb.AddForce(_camera.transform.forward * _firePower);
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

    }
}
