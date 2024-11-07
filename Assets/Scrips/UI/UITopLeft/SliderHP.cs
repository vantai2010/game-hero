using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : CustomBehavior
{
    private static SliderHP instance;
    [SerializeField] protected Slider slider;
    public static SliderHP Instance => instance;
    
    protected override void Awake()
    {
        base.Awake();
        if (SliderHP.instance != null) Debug.LogError("Only One SliderHP allow to exists");
        SliderHP.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSliderHP();
    }

    protected virtual void LoadSliderHP()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
    }


    public void UpdateSliderHp(int currHp, int maxHp)
    {
        float hpPercent = (float)currHp / maxHp;
        this.slider.value = hpPercent;
    }
   
}
