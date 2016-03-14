using System;
using UnityEngine;

public class NextWaveButton : MonoBehaviour
{
    private Transform coinPrefab;
    private bool enabled;
    public bool showCoin;
    private PackedSprite sprite;
    private StageBase stage;

    public NextWaveButton()
    {
        this.showCoin = 1;
        base..ctor();
        return;
    }

    public void Disable()
    {
        this.enabled = 0;
        this.sprite.PlayAnim("click", 0x1c);
        this.sprite.PauseAnim();
        return;
    }

    public void Enable()
    {
        this.enabled = 1;
        this.sprite.RevertToStatic();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseExit()
    {
        if (this.enabled == null)
        {
            goto Label_0016;
        }
        this.sprite.RevertToStatic();
    Label_0016:
        return;
    }

    private void OnMouseOver()
    {
        if (this.enabled == null)
        {
            goto Label_001B;
        }
        this.sprite.PlayAnim("over");
    Label_001B:
        return;
    }

    private void OnMouseUp()
    {
        if (this.enabled == null)
        {
            goto Label_003F;
        }
        this.enabled = 0;
        this.sprite.PlayAnim("click");
        this.stage.SendNextWave(null);
        this.stage.DestroyFlags();
        this.ShowCoin();
    Label_003F:
        return;
    }

    private void ShowCoin()
    {
        if (this.showCoin == null)
        {
            goto Label_0027;
        }
        UnityEngine.Object.Instantiate(this.coinPrefab, base.transform.position, Quaternion.identity);
    Label_0027:
        return;
    }

    private void Start()
    {
        this.coinPrefab = Resources.Load("Prefabs/GUI/Coin", typeof(Transform)) as Transform;
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.enabled = 1;
        return;
    }

    private void Update()
    {
        if (this.stage.GetStatus() != 4)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        if (this.enabled == null)
        {
            goto Label_005D;
        }
        if (Input.GetKeyDown(0x77) == null)
        {
            goto Label_005D;
        }
        this.enabled = 0;
        this.sprite.PlayAnim("click");
        this.stage.SendNextWave(null);
        this.stage.DestroyFlags();
        this.ShowCoin();
    Label_005D:
        return;
    }
}

