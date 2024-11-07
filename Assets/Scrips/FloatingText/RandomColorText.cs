using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorText : CustomBehavior
{
    [Header("Random Color Text")]
    [SerializeField] protected FloatingTextCtrl floatingTextCtrl;
    [SerializeField] protected bool isHighlighting = false;
    [SerializeField] protected List<Color> colors;

    protected virtual void OnEnable()
    {
        this.RandomColor();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isHighlighting = false;
        this.SetListColor();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFloatingTextCtrl();
    }

    protected virtual void LoadFloatingTextCtrl()
    {
        if (this.floatingTextCtrl != null) return;
        this.floatingTextCtrl = transform.parent.GetComponent<FloatingTextCtrl>();
    }

    protected virtual void SetListColor()
    {
        if (this.colors.Count > 0) return;
        this.colors.Add(Color.red);
        this.colors.Add(Color.green);
        this.colors.Add(Color.blue);
    }

    protected virtual void RandomColor()
    {
        if (this.isHighlighting)
        {
            Color critDamageColor = new Color(242, 255, 0);

            this.floatingTextCtrl.Text.fontSize = 8f;
            this.floatingTextCtrl.Text.color = critDamageColor;
            this.ResetStatusText();
        }
        else
        {
            int randomIndex = Random.Range(0, this.colors.Count);
            Color randomColor = this.colors[randomIndex];   

            this.floatingTextCtrl.Text.color = randomColor;
        }

    }

    public virtual void AllowHighlighting()
    {
        this.isHighlighting = true;
    }

    protected virtual void ResetStatusText()
    {
        this.floatingTextCtrl.Text.fontSize = 5.2f;
        this.isHighlighting = false;
    }
}
