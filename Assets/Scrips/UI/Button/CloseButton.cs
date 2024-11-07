using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : BaseButton
{
    protected override void OnClick()
    {
        transform.parent.gameObject.SetActive(false);
    }

    
}
