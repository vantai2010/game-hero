using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : ObjectHasAnimatorAbstract
{
    [Header("Animator Manager")]
    [SerializeField] protected CharacterStatusId currentStatusId;
    [SerializeField] protected CharacterStatusId pressingStatusId = CharacterStatusId.None;


    public virtual void SetCurrentStatusId(CharacterStatusId currentStatusId)
    {
        this.currentStatusId = currentStatusId;
        this.SetCurrentAnimation();
    }
    
    public virtual void SetPressingStatusId(CharacterStatusId pressingStatusId)
    {
        this.pressingStatusId = pressingStatusId;
        this.SetCurrentAnimation();
    }
    public virtual void ResetPressingStatusId()
    {
        this.pressingStatusId = CharacterStatusId.None;
    }

    protected virtual void SetCurrentAnimation()
    {
        if(this.pressingStatusId == CharacterStatusId.None)
        {
            this.objCtrl.Animator.SetInteger("statusId", (int)this.currentStatusId);
        }
        else
        {
            this.objCtrl.Animator.SetInteger("statusId", (int)this.pressingStatusId);
        }

    }
    public virtual float GetTimeFinishCurrentAnimation()
    {
        AnimatorStateInfo inforCurrentAnimation = this.objCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        /*Debug.Log(inforCurrentAnimation.length);
        Debug.Log(inforCurrentAnimation.ToString());*/
        return inforCurrentAnimation.length;
    }
}
