using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void LoadComponent()
    {

    }
}
