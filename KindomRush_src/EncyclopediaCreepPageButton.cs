using System;
using UnityEngine;

public class EncyclopediaCreepPageButton : MonoBehaviour
{
    private EncyclopediaContainerCreeps encyclopedia;
    public int pageNumber;
    private PackedSprite sprite;

    public EncyclopediaCreepPageButton()
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

    private void OnMouseDown()
    {
        this.encyclopedia.SetPage(this.pageNumber);
        this.sprite.PlayAnim("selected");
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    private void OnMouseEnter()
    {
        if (this.encyclopedia.GetSelectedPage() == this.pageNumber)
        {
            goto Label_0026;
        }
        this.sprite.PlayAnim("over");
    Label_0026:
        return;
    }

    private void OnMouseExit()
    {
        if (this.encyclopedia.GetSelectedPage() == this.pageNumber)
        {
            goto Label_0021;
        }
        this.sprite.RevertToStatic();
    Label_0021:
        return;
    }

    public void Reset()
    {
        this.sprite.RevertToStatic();
        return;
    }

    public void SetSelected()
    {
        this.sprite.PlayAnim("selected");
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.encyclopedia = base.transform.parent.GetComponent<EncyclopediaContainerCreeps>();
        return;
    }
}

