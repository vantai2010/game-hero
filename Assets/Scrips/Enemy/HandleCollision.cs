using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollision : CustomBehavior
{
    [SerializeField] protected BoxCollider2D boxCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollier();
    }
    protected virtual void LoadBoxCollier()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("da chay");
        if (collision.transform.parent.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("da chay 2");

            transform.position += new Vector3(1, 0, 0); 
        }
    }
    protected virtual void OnCollisionExist2D(Collision2D collision)
    {

    }
}
