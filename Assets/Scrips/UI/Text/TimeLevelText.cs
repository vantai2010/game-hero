using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLevelText : BaseText
{
    protected virtual void Update()
    {
        this.ChangeTextValue(GameLevel.Instance.CurrTime.ToString() + " s");
    }
}
