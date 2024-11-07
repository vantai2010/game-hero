using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistButton : BaseButton
{

    protected override void OnClick()
    {
        Application.Quit();
    }

}
