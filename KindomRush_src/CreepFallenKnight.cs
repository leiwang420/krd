using System;
using UnityEngine;

public class CreepFallenKnight : CreepBlackburn
{
    protected Transform aura;
    protected PackedSprite auraEffect;
    public Transform auraEffectPrefab;
    public int bonusAuraPercent;
    protected bool shifted;
    public Transform spectralKnightPrefab;
    public bool Unexplodable;

    public CreepFallenKnight()
    {
        base..ctor();
        return;
    }

    protected override void DestroyThis()
    {
        this.Shift();
        base.DestroyThis();
        return;
    }

    public void HideAuraEffect()
    {
        if ((this.aura != null) == null)
        {
            goto Label_0022;
        }
        this.aura.GetComponent<PackedSprite>().Hide(1);
    Label_0022:
        return;
    }

    protected override void InitCustomSettings()
    {
        if (this.Unexplodable == null)
        {
            goto Label_0012;
        }
        base.canGib = 0;
    Label_0012:
        this.aura = base.transform.FindChild("SpectralKnight Effect");
        return;
    }

    protected unsafe void Shift()
    {
        Vector3 vector;
        Transform transform;
        Creep creep;
        Vector3 vector2;
        vector = base.transform.position;
        transform = UnityEngine.Object.Instantiate(this.spectralKnightPrefab, vector, Quaternion.identity) as Transform;
        creep = transform.GetComponent<Creep>();
        creep.name = "Spectral Knight";
        creep.InitSprite();
        creep.SetPathIndex(base.pathIndex);
        creep.SetSubPath(base.subpathIndex);
        creep.SetCurrentNode(base.currentNode);
        creep.SetActive(1);
        creep.roadNodesTillActive = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_00A9;
        }
        creep.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00A9:
        return;
    }

    public void ShowAuraEffect()
    {
        if ((this.aura != null) == null)
        {
            goto Label_0022;
        }
        this.aura.GetComponent<PackedSprite>().Hide(0);
    Label_0022:
        return;
    }
}

