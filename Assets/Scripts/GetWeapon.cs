using System;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    private Gun _weapon;
    public Gun Weapon
    {
        get { return _weapon;}
    }

    [SerializeField]

    private Transform _gunPivot;

    private ControllerUI _uiController;

    private void Start()
    {
        _uiController = gameObject.GetComponent<ControllerUI>();
        _uiController.ShowBulletsUI(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && _weapon == null)
        {
            GrabWeapon(other.transform);
        }
    }

    private void GrabWeapon(Transform weapon)
    {
        weapon.GetComponent<Rotate>().IsRotating = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.SetParent(_gunPivot);
        weapon.localPosition = Vector3.zero;
        weapon.localRotation = Quaternion.identity;
        _weapon = weapon.GetComponent<Gun>();
        _weapon.PickUpWeapon(this);
        _uiController.ShowBulletsUI(true);
    }

    public void RemoveWeapon()
    {
        Destroy(_weapon.gameObject);
        _weapon = null;
        _uiController.ShowBulletsUI(false);
    }
}
