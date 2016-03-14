using System;
using UnityEngine;

public class ConstructingTower : MonoBehaviour
{
    private PackedSprite bar;
    private float constructionTime;
    private float constructionTimeCounter;
    public Transform grassTerrain;
    public Transform iceTerrain;
    private bool paused;
    public Transform smokeConstructionPrefab;
    private TowerBase tower;
    private float xScale;
    public float yOffset;

    public ConstructingTower()
    {
        this.constructionTime = 0.8f;
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        Vector3 vector;
        Vector3 vector2;
        this.constructionTimeCounter += Time.deltaTime;
        this.bar.transform.localScale = new Vector3(this.constructionTimeCounter / 0.8f, 1f, 1f);
        if (this.constructionTimeCounter < this.constructionTime)
        {
            goto Label_00AB;
        }
        this.tower.Activate();
        UnityEngine.Object.Instantiate(this.smokeConstructionPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 32f, -900f), Quaternion.identity);
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00AB:
        return;
    }

    public void SetTower(TowerBase t)
    {
        this.tower = t;
        return;
    }

    private void Start()
    {
        this.bar = base.transform.FindChild("Construction bar").FindChild("Bar").GetComponent<PackedSprite>();
        GameSoundManager.PlayTowerBuilding();
        return;
    }
}

