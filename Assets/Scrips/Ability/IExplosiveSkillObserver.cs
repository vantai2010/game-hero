using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IExplosiveSkillObserver 
{
    
    public abstract void OnExplosiveActive();
    public abstract void OnExplosiveExist();

}
