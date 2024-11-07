using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ISummonMeteorSkillObserver 
{
    
    public abstract void OnSummonMeteorSkillStart();
    public abstract void OnSummonMeteorSkillEnd();

}
