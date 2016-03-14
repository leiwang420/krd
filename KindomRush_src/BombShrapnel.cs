using System;

public class BombShrapnel : Bomb
{
    private bool hasSound;

    public BombShrapnel()
    {
        base..ctor();
        return;
    }

    protected override void PlayExplosionSound()
    {
        if (this.hasSound == null)
        {
            goto Label_0010;
        }
        GameSoundManager.PlayBombExplosionSound();
    Label_0010:
        return;
    }

    public void SetSound(bool s)
    {
        this.hasSound = s;
        return;
    }

    private void Start()
    {
        base.Init();
        return;
    }
}

