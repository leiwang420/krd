using System;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    private int clickCounter;
    private RaycastHit hit;
    private PackedSprite sprite;
    private PackedSprite spriteFeedback;
    private int totalClicks;
    private TowerBase tower;

    public IceBlock()
    {
        this.totalClicks = 3;
        base..ctor();
        return;
    }

    protected void KillMe(SpriteBase sprt)
    {
        this.sprite.PlayAnim("unfreezeEnd");
        return;
    }

    private void OnMouseUp()
    {
    }

    public void SetTower(TowerBase t)
    {
        this.tower = t;
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.spriteFeedback = base.transform.FindChild("Feedback").GetComponent<PackedSprite>();
        return;
    }

    private unsafe void Update()
    {
        UnityEngine.Ray ray;
        int num;
        if (Input.GetMouseButtonUp(0) == null)
        {
            goto Label_00BE;
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (base.collider.Raycast(ray, &this.hit, 1000f) == null)
        {
            goto Label_00BE;
        }
        GameSoundManager.PlayJTHitIce();
        this.spriteFeedback.Hide(0);
        this.spriteFeedback.PlayAnim(0);
        if ((this.clickCounter += 1) != this.totalClicks)
        {
            goto Label_00BE;
        }
        this.tower.SetActive(1, 1);
        this.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.KillMe));
        this.sprite.PlayAnim("unfreeze");
        UnityEngine.Object.Destroy(base.transform.FindChild("ClickMe").gameObject);
    Label_00BE:
        return;
    }
}

