using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : CustomBehavior
{
    [SerializeField] protected Texture2D sprite;
    [SerializeField] protected Vector2 hotspot = Vector2.zero;
    [SerializeField] protected CursorMode cursorMode = CursorMode.Auto;
    
    protected void Start()
    {
        base.Awake();
        Cursor.SetCursor(this.sprite, hotspot, cursorMode);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSprite();
    }

    protected virtual void LoadSprite()
    {
        if (this.sprite != null) return;
        this.sprite = GetComponentInChildren<SpriteRenderer>().sprite.texture;
    }

}
