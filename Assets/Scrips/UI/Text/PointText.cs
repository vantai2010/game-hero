using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointText : BaseText
{
    public void ChangePointText(string newText)
    {
        this.ChangeTextValue("Point: " + newText);
    }
}
