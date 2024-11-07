using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShootBy : MonoBehaviour
{
    [Header("Check Shoot By")]
    [SerializeField] protected string nameWeapon;
    public string NameWeapon => nameWeapon;

    public virtual void SetNameWeapon(string nameWeapon)
    {
        Debug.Log(nameWeapon);
        this.nameWeapon = nameWeapon;
    }

}
