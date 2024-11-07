using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : CustomBehavior
{
    [SerializeField] protected Transform uiMenu;
    [SerializeField] protected TextCountDown textCountDown;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIMenu();
        this.LoadTextCountDown();
    }

    protected virtual void LoadUIMenu()
    {
        if (this.uiMenu != null) return;
        this.uiMenu = GameObject.Find("UICenter").transform;
    }
    protected virtual void LoadTextCountDown()
    {
        if (this.textCountDown != null) return;
        this.textCountDown = GameObject.Find("UICountDown").GetComponentInChildren<TextCountDown>();
    }

    protected void Update()
    {
        this.HandlePauseGame();
    }

    protected virtual void HandlePauseGame()
    {
        if (!this.CanPauseGame()) 
        {
            Time.timeScale = 1f;
            return;
        }
        Time.timeScale = 0f;
    }

    protected virtual bool CanPauseGame()
    {
        if (this.uiMenu.gameObject.activeSelf == true)
        {
            return true;
        } 
        else if (this.textCountDown.CurrTime > 0)
        {
            return true;
        }
        else if (UIloggerCtrl.Instance.gameObject.activeSelf == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
