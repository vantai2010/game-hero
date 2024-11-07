using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextCtrl : CustomBehavior
{
    [Header("Floating Text Ctrl")]
    [SerializeField] protected TextMeshPro text;
    [SerializeField] protected RandomColorText randomColorText;
    public TextMeshPro Text => text;
    public RandomColorText RandomColorText => randomColorText;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
        this.LoadRandomColorText();
    }

    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponentInChildren<TextMeshPro>();
    }

    protected virtual void LoadRandomColorText()
    {
        if (this.randomColorText != null) return;
        this.randomColorText = GetComponentInChildren<RandomColorText>();
    }
}
