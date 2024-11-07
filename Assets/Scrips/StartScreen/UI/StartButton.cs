using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
