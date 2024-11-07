using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IShootProjectileSkillObserver
{
    
    public abstract void OnShootProjectileSkillStart();
    public abstract void OnShootProjectileSkillEnd();

}
