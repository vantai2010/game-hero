using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : CustomBehavior
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeTextValue(string newText)
    {
        this.text.text = newText;
    }

    
}
