using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCountDown : BaseText
{
    [Header("Text Count Down")]
    [SerializeField] protected int currTime;
    [SerializeField] protected float timer;
    [SerializeField] protected float duration;

    public int CurrTime => currTime;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.currTime = 3;
        this.timer = 0f;
        this.duration = 1f;
    }

    protected virtual void Update()
    {
        this.CountDown();
        this.CheckFinishCountDown();
    }

    protected virtual void CountDown()
    {
        if (this.currTime == 0) return;
        //Debug.Log("ss" + this.timer);
        this.timer +=  Time.fixedDeltaTime;
        if (this.timer < this.duration) return;
        this.timer = 0f;
        this.currTime -= 1;
        this.text.text = currTime.ToString();
    }

    protected virtual void CheckFinishCountDown()
    {
        if (this.currTime > 0) return;

        this.text.enabled = false;
        this.enabled = false;
        
    }
}
