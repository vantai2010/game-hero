using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : CustomBehavior
{
    [SerializeField] protected List<Transform> listWeapons;
    [SerializeField] protected string nameWeaponOrder = "Rifle";
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListWeapons();
    }

    protected virtual void Update()
    {
        this.GetStatusButtonNumberKey();
        this.ChangeWeapon();
    }

    protected virtual void LoadListWeapons()
    {
        if (this.listWeapons.Count > 0) return;
        foreach (Transform weapon in transform)
        {
            this.listWeapons.Add(weapon);
        }
    }
    protected virtual void GetStatusButtonNumberKey()
    {
        if (InputManager.Instance.IsAlpha1)
        {
            this.nameWeaponOrder = "Rifle";
        }
        else if (InputManager.Instance.IsAlpha2)
        {
            this.nameWeaponOrder = "Pistol";
        }
        else if (InputManager.Instance.IsAlpha3)
        {
            this.nameWeaponOrder = "Shotgun";
        }
        
    }
    protected virtual void ChangeWeapon()
    {
        foreach(Transform weapon in this.listWeapons)
        {
            if(weapon.name == this.nameWeaponOrder)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
