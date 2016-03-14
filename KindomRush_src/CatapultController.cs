using System;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    private int adjustX;
    private int adjustY;
    public CatapultRock catapultRockPrefab;
    private int currentAngle;
    private int currentProjectil;
    private bool fadeIn;
    private int goingOutTime;
    private int goingOutTimeCounter;
    private bool isActive;
    private bool isPaused;
    private int level;
    private int maxProjectiles;
    private float opacity;
    private const float ratio43 = 1.33333f;
    private int spawnTime;
    private int spawnTimeCounter;
    private PackedSprite sprite;
    private StageBase stage;

    public CatapultController()
    {
        base..ctor();
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
        if (this.fadeIn == null)
        {
            goto Label_0071;
        }
        this.opacity += Time.deltaTime * 5f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity < 1f)
        {
            goto Label_0070;
        }
        this.fadeIn = 0;
        goto Label_0071;
    Label_0070:
        return;
    Label_0071:
        if (this.isActive != null)
        {
            goto Label_00A7;
        }
        this.goingOutTimeCounter += 1;
        if (this.goingOutTimeCounter != this.goingOutTime)
        {
            goto Label_00A6;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00A6:
        return;
    Label_00A7:
        if (this.spawnTimeCounter >= this.spawnTime)
        {
            goto Label_00C7;
        }
        this.spawnTimeCounter += 1;
        return;
    Label_00C7:
        this.SpawnProjectile();
        if (this.currentProjectil != this.maxProjectiles)
        {
            goto Label_00E5;
        }
        this.isActive = 0;
    Label_00E5:
        return;
    }

    private Vector2 GetRockDestination(int angle, int tmpW, int tmpH)
    {
        return IronUtils.ellipseGetPointOfDegree((float) angle, (float) tmpH, (float) tmpW, base.transform.position);
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public void SetLevel(int l)
    {
        this.level = l;
        return;
    }

    public void SetStage(StageBase s)
    {
        this.stage = s;
        return;
    }

    private unsafe void SpawnProjectile()
    {
        int num;
        int num2;
        Vector2 vector;
        CatapultRock rock;
        Vector3 vector2;
        Vector3 vector3;
        this.spawnTimeCounter = 0;
        this.currentProjectil += 1;
        num = Mathf.RoundToInt((UnityEngine.Random.Range(0f, 1f) * 66f) + 31f);
        num2 = Mathf.RoundToInt(((float) num) * 0.7f);
        this.currentAngle += 60;
        vector = this.GetRockDestination(this.currentAngle, num, num2);
        rock = UnityEngine.Object.Instantiate(this.catapultRockPrefab, new Vector3(&base.transform.position.x + ((float) this.adjustX), &base.transform.position.y + ((float) this.adjustY), -890f), Quaternion.identity) as CatapultRock;
        rock.SetDest(&vector.x, &vector.y);
        rock.SetLevel(this.level);
        rock.SetG(-0.55f);
        rock.SetT1(45f);
        rock.SetStage(this.stage);
        this.stage.AddProjectile(rock.transform);
        return;
    }

    private unsafe void Start()
    {
        float num;
        Vector3 vector;
        Vector3 vector2;
        this.sprite = base.GetComponent<PackedSprite>();
        this.opacity = 0f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        this.fadeIn = 1;
        this.isActive = 1;
        this.maxProjectiles = ((int) GameSettings.GetHeroSetting("hero_denas", "catapultRocks", 1)) + (((int) GameSettings.GetHeroSetting("hero_denas", "catapultRocksIncrement", 1)) * this.level);
        this.spawnTime = 6;
        this.currentAngle = 0;
        this.adjustY = 0xd3;
        this.goingOutTime = 0x2d;
        this.goingOutTimeCounter = 0;
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_0103;
        }
        if (&base.transform.position.x < 0f)
        {
            goto Label_00F3;
        }
        this.adjustX = 500;
        goto Label_00FE;
    Label_00F3:
        this.adjustX = -550;
    Label_00FE:
        goto Label_013B;
    Label_0103:
        if (&base.transform.position.x < 0f)
        {
            goto Label_0130;
        }
        this.adjustX = 0x37d;
        goto Label_013B;
    Label_0130:
        this.adjustX = -893;
    Label_013B:
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

