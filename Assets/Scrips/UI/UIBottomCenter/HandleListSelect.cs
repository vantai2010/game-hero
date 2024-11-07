using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleListSelect : CustomBehavior
{
    [SerializeField] protected List<EachSelectSkill> listOptionsSelect;
    [SerializeField] protected int numberSelected = 1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListOptionsSelect();
    }

    protected virtual void LoadListOptionsSelect()
    {
        if (this.listOptionsSelect.Count > 0) return;
        foreach(Transform option in transform)
        {
            this.listOptionsSelect.Add(option.GetComponent<EachSelectSkill>());
        }
    }

    protected virtual void Update()
    {
        this.GetKeyNumberDown();
        this.UpdateOptionSelected();
    }

    protected virtual void GetKeyNumberDown()
    {
        if (InputManager.Instance.IsAlpha1)
        {
            this.numberSelected = 1;
        }else if (InputManager.Instance.IsAlpha2)
        {
            this.numberSelected = 2;
        }else if (InputManager.Instance.IsAlpha3)
        {
            this.numberSelected = 3;
        }
        /*else if (InputManager.Instance.IsAlpha4)
        {
            this.numberSelected = 4;
        }*/
        
    }

    protected virtual void UpdateOptionSelected()
    {
        for(int i = 0;  i < this.listOptionsSelect.Count; i++)
        {
            if(i == this.numberSelected - 1)
            {
                this.listOptionsSelect[i].SetIsSelected(true);
            }
            else
            {
                this.listOptionsSelect[i].SetIsSelected(false);
            }
        }
    }
}
