using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    private AnimationController animationController;

    [SerializeField] private List<GameObject> _weapons;

    private int _weaponNum;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();

        CurrentWeapon();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            animationController.MeleeAttack();

        var mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        //var mouseWheel = Input.mouseScrollDelta.y;

        if(mouseWheel < 0)
        {
            _weaponNum += 1;

            CurrentWeapon();
        }
        if(mouseWheel > 0)
        {
            _weaponNum -= 1;

            CurrentWeapon();
        }
    }

    private void CurrentWeapon()
    {
        _weaponNum = _weaponNum > _weapons.Count - 1 ? 0 : _weaponNum;
        _weaponNum = _weaponNum < 0 ? _weapons.Count - 1 : _weaponNum;

        foreach (GameObject w in _weapons)
        {
            if (_weapons.IndexOf(w) == _weaponNum)
                w.SetActive(true);
            else
                w.SetActive(false);
        }
    }
}
