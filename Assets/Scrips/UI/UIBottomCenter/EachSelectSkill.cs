using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class EachSelectSkill : CustomBehavior
{
    [SerializeField] protected Image imageBackground;
    [SerializeField] protected bool isSelected;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImageBackground();
    }

    protected virtual void LoadImageBackground()
    {
        if (this.imageBackground != null) return;
        this.imageBackground = GetComponent<Image>();
    }

    

    protected virtual void FixedUpdate()
    {
        this.UpdateStatusOptionSelect();
    }

    public virtual void SetIsSelected(bool isSelected)
    {
        this.isSelected = isSelected;
    }

    protected void UpdateStatusOptionSelect()
    {
        string colorHex = this.isSelected ? "#0FE218" : "#B6F7B9";
        Color newColor;

        // Convert form hex to Color
        if (UnityEngine.ColorUtility.TryParseHtmlString(colorHex, out newColor))
        {
            this.imageBackground.color = newColor;
        }
        else
        {
            Debug.LogError("Invalid hex color code!");
        }
    }

}
