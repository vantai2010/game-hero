using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterAbstract
{
    [SerializeField] protected float speed;
    [SerializeField] protected float minX;
    [SerializeField] protected float maxX;
    [SerializeField] protected float minY;
    [SerializeField] protected float maxY;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 3f;
        this.minX = -20.9f;
        this.maxX = 18.7f;
        this.minY = -18.2f;
        this.maxY = 17.55f;
    }
    protected virtual void Update()
    {
        this.Moving();
        //this.ChangeDirectionLookAt();

    }
    protected virtual bool IsMoving(float moveHorizontal, float moveVertical)
    {
        return moveHorizontal != 0 || moveVertical != 0;
    }
    protected virtual void Moving()
    {
        float moveHorizontal = InputManager.Instance.MoveHorizontal;
        float moveVertical = InputManager.Instance.MoveVertical;

        if (!this.IsMoving(moveHorizontal, moveVertical))
        {
            this.characterCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Idle);
            return;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        Vector3 newPosition = transform.parent.position + movement * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(newPosition.x, this.minX, this.maxX); 
        float clampedY = Mathf.Clamp(newPosition.y, this.minY, this.maxY); 

        transform.parent.position = new Vector3(clampedX, clampedY, newPosition.z);


        this.characterCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Walk);
    }
    protected virtual void ChangeDirectionLookAt()
    {
        if (InputManager.Instance.MoveHorizontal == 0) return;

        if(InputManager.Instance.MoveHorizontal > 0)
            transform.parent.localScale = new Vector3(1, 1, 1);
        else 
            transform.parent.localScale = new Vector3(-1, 1, 1);
    }
  
}
