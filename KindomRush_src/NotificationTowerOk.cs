﻿using System;
using UnityEngine;

public class NotificationTowerOk : MonoBehaviour
{
    private NotificationTower notificationCard;
    private PackedSprite sprite;

    public NotificationTowerOk()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void OnMouseUp()
    {
        this.notificationCard.Hide();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.notificationCard = base.transform.parent.GetComponent<NotificationTower>();
        return;
    }
}

