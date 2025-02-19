using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private Transform _bulletPivot;
        
    [SerializeField]
    private Animator _weaponAnimator;

    [SerializeField]
    private int _maxBulletsNumber = 50;

    [SerializeField]
    private int _cartridgeBulletsNumber = 10;
    private int _totalBulletsNumber = 0;
    private int _currentBulletsNumber = 0;

    private Text _bulletText;

    private GetWeapon _getWeapon;

    public void Shoot()
    {
        if(_currentBulletsNumber == 0)
        {
            if (_totalBulletsNumber == 0)
            {
                RemoveWeapon();
            }
            return;
        }

        SoundManager.instance.Play("Gun-Shot");

        GameObject.Instantiate(_bullet, _bulletPivot.position,  _bulletPivot.rotation);
        _weaponAnimator.Play("Shoot", -1, 0f);
        _currentBulletsNumber --;
        UpdateBulletsText();
    }

    public void PickUpWeapon(GetWeapon getWeapon)
    {
        _getWeapon = getWeapon;
        _totalBulletsNumber = _maxBulletsNumber;
        Reload();
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletsText();
    }

    public void Reload()
    {
        if(_currentBulletsNumber == _cartridgeBulletsNumber || _totalBulletsNumber == 0)
       {
         return;
       }

       int bulletNeeded = _cartridgeBulletsNumber - _currentBulletsNumber;

       if(_totalBulletsNumber >= _cartridgeBulletsNumber)
       {
        _currentBulletsNumber = bulletNeeded;
       }

       else if(_totalBulletsNumber > 0)
       {
        _currentBulletsNumber = _totalBulletsNumber;
       }
 
        _totalBulletsNumber -= _currentBulletsNumber;
        _weaponAnimator.Play("Reload", -1, 0f);
        UpdateBulletsText();

        SoundManager.instance.Play("ReloadGun");
    }

    public void UpdateBulletsText()
    {
        if (_bulletText == null)
        {
            _bulletText = _getWeapon.GetComponent<ControllerUI>().BulletsText;
        }

        _bulletText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;

    }

    private void RemoveWeapon()
    {
        _getWeapon.RemoveWeapon();
        _getWeapon = null;
    }
}
