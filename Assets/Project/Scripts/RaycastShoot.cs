using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {
	[SerializeField] private Camera _camera;
	[SerializeField] private int _fireRate = 1;
	[SerializeField] private int _startingAmmo = 5;
    [SerializeField] private SelectMaterial selectMaterial;

	private int _currentAmmo;
	private float _timeToNextShoot;

	// Use this for initialization
	void Start () {
		_currentAmmo = _startingAmmo;
		_timeToNextShoot = 0;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButton ("Fire1") && Time.time > _timeToNextShoot && _currentAmmo > 0) {
			_currentAmmo--;
			Debug.Log ("_currentAmmo: " + _currentAmmo);
			_timeToNextShoot = Time.time + 1f / _fireRate;
			RaycastHit hitInfo;
			if (Physics.Raycast (_camera.transform.position, _camera.transform.forward, out hitInfo)) {
				Target t = hitInfo.transform.gameObject.GetComponent<Target>();
				if (t != null) {
					t.HitTarget (selectMaterial.selected);
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			_currentAmmo = _startingAmmo;
		}
	}
}
