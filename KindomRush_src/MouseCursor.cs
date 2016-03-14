using System;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Camera cam;
    public Texture2D image;
    public Texture2D imageClick;
    public Texture2D imageReinforce;
    private int offsetX;
    private int offsetY;
    private PackedSprite sprite;

    public MouseCursor()
    {
        base..ctor();
        return;
    }

    public void Reset()
    {
        Cursor.SetCursor(this.image, Vector2.zero, 0);
        return;
    }

    public void SetReinforceCursor()
    {
        Cursor.SetCursor(this.imageReinforce, Vector2.zero, 0);
        return;
    }

    private void Start()
    {
        Screen.showCursor = 1;
        Cursor.SetCursor(this.image, Vector2.zero, 0);
        return;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_001C;
        }
        Cursor.SetCursor(this.imageClick, Vector2.zero, 0);
    Label_001C:
        if (Input.GetMouseButtonUp(0) == null)
        {
            goto Label_0038;
        }
        Cursor.SetCursor(this.image, Vector2.zero, 0);
    Label_0038:
        return;
    }
}

