using System;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    private int currentAngle;
    private int currentProjectil;
    private bool fading;
    private bool isActive;
    private bool isPaused;
    private int level;
    private int maxProjectiles;
    private float opacity;
    private CreepSpawner spawner;
    private int spawnTime;
    private int spawnTimeCounter;
    private PackedSprite sprite;
    private StageBase stage;
    public Transform thunderPrefab;

    public ThunderController()
    {
        base..ctor();
        return;
    }

    private void FadeOut()
    {
        this.fading = 1;
        this.opacity = 1f;
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isActive != null)
        {
            goto Label_007C;
        }
        if (this.fading == null)
        {
            goto Label_007B;
        }
        this.opacity -= ((float) Time.deltaTime) * 5f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity > 0f)
        {
            goto Label_007B;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_007B:
        return;
    Label_007C:
        if (this.fading == null)
        {
            goto Label_010C;
        }
        this.opacity += ((float) Time.deltaTime) * 5f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity < 1f)
        {
            goto Label_010C;
        }
        this.fading = 0;
        this.opacity = 1f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
    Label_010C:
        if (this.spawnTimeCounter >= this.spawnTime)
        {
            goto Label_012C;
        }
        this.spawnTimeCounter += 1;
        return;
    Label_012C:
        this.SpawnProjectile();
        if (this.currentProjectil != this.maxProjectiles)
        {
            goto Label_015A;
        }
        this.isActive = 0;
        base.Invoke("FadeOut", 0.5f);
    Label_015A:
        return;
    }

    private Vector2 GetThunderDestination(int angle, int tmpW, int tmpH)
    {
        return IronUtils.ellipseGetPointOfDegree((float) angle, (float) tmpH, (float) tmpW, base.transform.position);
    }

    public unsafe void Init(Vector2 pos, int myLevel)
    {
        this.level = myLevel;
        base.transform.position = new Vector3(&pos.x, &pos.y, -1f);
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public void SetStage(StageBase s)
    {
        this.stage = s;
        return;
    }

    private void SpawnProjectile()
    {
        int num;
        int num2;
        Transform transform;
        ThunderProjectile projectile;
        this.spawnTimeCounter = 0;
        this.currentProjectil += 1;
        num = Mathf.RoundToInt((UnityEngine.Random.Range(0f, 1f) * 56f) + 21f);
        num2 = Mathf.RoundToInt(((float) num) * 0.7f);
        transform = UnityEngine.Object.Instantiate(this.thunderPrefab, base.transform.position, Quaternion.identity) as Transform;
        projectile = transform.GetComponent<ThunderProjectile>();
        projectile.Init(this.level, this.spawner, this.GetThunderDestination(this.currentAngle, num, num2));
        projectile.SetStage(this.stage);
        this.stage.AddEffect(projectile.transform);
        this.currentAngle += 70;
        if (this.currentAngle < 360)
        {
            goto Label_00DA;
        }
        this.currentAngle -= 360;
    Label_00DA:
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.opacity = 0f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        this.isActive = 1;
        this.fading = 1;
        this.maxProjectiles = this.level * ((int) GameSettings.GetHeroSetting("hero_mage", "thunderProjectilesPerLevel", 1));
        this.spawnTime = 6;
        this.currentAngle = 0;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

