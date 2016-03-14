using System;
using UnityEngine;

public class DenasCursing : MonoBehaviour
{
    private PackedSprite sprite;

    public DenasCursing()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Pause()
    {
        this.sprite.PauseAnim();
        return;
    }

    public void Play()
    {
        this.sprite.Hide(0);
        this.sprite.PlayAnim(0);
        return;
    }

    private void Start()
    {
    }

    public void Unpause()
    {
        this.sprite.UnpauseAnim();
        return;
    }
}

