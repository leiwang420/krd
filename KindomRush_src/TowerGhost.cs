using System;
using System.Collections;
using UnityEngine;

public class TowerGhost : MonoBehaviour
{
    private PackedSprite sprite;
    private StageBase stage;
    private PackedSprite terrainGrass;
    private PackedSprite terrainIce;
    private PackedSprite terrainWasteland;

    public TowerGhost()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private unsafe void SetOpacity()
    {
        Color color;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        &color = new Color(1f, 1f, 1f, 0.7f);
        this.sprite.SetColor(color);
        this.terrainGrass.SetColor(color);
        this.terrainIce.SetColor(color);
        this.terrainWasteland.SetColor(color);
        enumerator = base.transform.GetEnumerator();
    Label_0057:
        try
        {
            goto Label_0089;
        Label_005C:
            transform = (Transform) enumerator.Current;
            if ((transform.name == "Shooter") == null)
            {
                goto Label_0089;
            }
            transform.GetComponent<PackedSprite>().SetColor(color);
        Label_0089:
            if (enumerator.MoveNext() != null)
            {
                goto Label_005C;
            }
            goto Label_00AB;
        }
        finally
        {
        Label_0099:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A4;
            }
        Label_00A4:
            disposable.Dispose();
        }
    Label_00AB:
        return;
    }

    public void SetRange(float r)
    {
        Transform transform;
        base.transform.FindChild("Range circle").localScale = new Vector3(((float) r) / 385f, (((float) r) * 0.7f) / 385f, 1f);
        return;
    }

    private void SetTerrain()
    {
        StageBase.terrainType type;
        type = this.stage.GetTerrainType();
        if (type != null)
        {
            goto Label_0023;
        }
        this.terrainGrass.Hide(0);
        goto Label_004E;
    Label_0023:
        if (type != 1)
        {
            goto Label_003B;
        }
        this.terrainIce.Hide(0);
        goto Label_004E;
    Label_003B:
        if (type != 2)
        {
            goto Label_004E;
        }
        this.terrainWasteland.Hide(0);
    Label_004E:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.terrainIce = base.transform.FindChild("Ice").GetComponent<PackedSprite>();
        this.terrainGrass = base.transform.FindChild("Grass").GetComponent<PackedSprite>();
        this.terrainWasteland = base.transform.FindChild("Wasteland").GetComponent<PackedSprite>();
        this.SetTerrain();
        this.SetOpacity();
        return;
    }
}

