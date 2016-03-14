using System;
using UnityEngine;

public class GUICenter : MonoBehaviour
{
    private PackedSprite armorIcon;
    public Transform armorIconPrefab;
    private PackedSprite costIcon;
    public Transform costIconPrefab;
    private Creep creep;
    private PackedSprite damageIcon;
    public Transform damageIconPrefab;
    private Vector2 endPos2d;
    private Vector3 endPosition;
    private PackedSprite healthIcon;
    public Transform healthIconPrefab;
    private bool hidden;
    private float horizRatio;
    public GUIStyle infoStyle;
    private PackedSprite mageDamageIcon;
    public Transform mageDamageIconPrefab;
    private bool moving;
    private float nameLabelY;
    public GUIStyle nameStyle;
    private Vector3 originalPosition;
    private Transform portrait;
    private PackedSprite rangeIcon;
    public Transform rangeIconPrefab;
    private PackedSprite reloadIcon;
    public Transform reloadIconPrefab;
    private PackedSprite respawnIcon;
    public Transform respawnIconPrefab;
    private UnitClickable selection;
    private Soldier soldier;
    private PackedSprite sprite;
    private float starttime;
    private TowerBase tower;
    private Vector3 tweenDir;
    private float tweenDistance;
    private float tweenSpeed;
    private float tweenTime;
    private float vertRatio;

    public GUICenter()
    {
        this.nameLabelY = 1025f;
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform1;
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.moving == null)
        {
            goto Label_00F0;
        }
        &vector = new Vector2(&base.transform.position.x, &base.transform.position.y);
        if (Vector2.Distance(vector, this.endPos2d) <= (this.tweenSpeed * Time.deltaTime))
        {
            goto Label_0087;
        }
        transform1 = base.transform;
        transform1.position += this.tweenDir * (this.tweenSpeed * Time.deltaTime);
        goto Label_00F0;
    Label_0087:
        this.moving = 0;
        this.hidden = 1;
        this.selection = null;
        base.transform.position = new Vector3(&this.endPosition.x, &this.endPosition.y, &base.transform.position.z);
        this.HideIcons();
        this.soldier = null;
        this.creep = null;
        this.tower = null;
    Label_00F0:
        return;
    }

    private void HideIcons()
    {
        this.healthIcon.Hide(1);
        this.damageIcon.Hide(1);
        this.armorIcon.Hide(1);
        this.respawnIcon.Hide(1);
        this.costIcon.Hide(1);
        this.rangeIcon.Hide(1);
        this.reloadIcon.Hide(1);
        this.mageDamageIcon.Hide(1);
        return;
    }

    public bool IsHidden()
    {
        return this.hidden;
    }

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(new Vector3(0f, 0f, 1f), Quaternion.identity, new Vector3(this.horizRatio, this.vertRatio, 1f));
        if (this.moving == null)
        {
            goto Label_00A3;
        }
        this.nameLabelY += this.tweenSpeed * Time.deltaTime;
        if ((this.selection != null) == null)
        {
            goto Label_00F4;
        }
        GUI.Label(new Rect(550f, this.nameLabelY, 140f, 30f), this.selection.name, this.nameStyle);
        goto Label_00F4;
    Label_00A3:
        if (this.hidden != null)
        {
            goto Label_00F4;
        }
        if ((this.selection != null) == null)
        {
            goto Label_00F4;
        }
        GUI.Label(new Rect(550f, 1025f, 150f, 30f), this.selection.name, this.nameStyle);
        this.UpdateInfo();
    Label_00F4:
        return;
    }

    public unsafe void Show(UnitClickable s)
    {
        Vector3 vector;
        this.sprite.Hide(0);
        this.hidden = 0;
        this.moving = 0;
        this.selection = s;
        base.transform.position = this.originalPosition;
        if ((this.portrait != null) == null)
        {
            goto Label_0053;
        }
        UnityEngine.Object.Destroy(this.portrait.gameObject);
    Label_0053:
        this.portrait = UnityEngine.Object.Instantiate(this.selection.portrait, new Vector3(-91f, -484f, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        this.portrait.parent = base.transform;
        this.soldier = this.selection.GetComponent<Soldier>();
        this.creep = this.selection.GetComponent<Creep>();
        this.tower = this.selection.GetComponent<TowerBase>();
        this.HideIcons();
        if ((this.soldier != null) == null)
        {
            goto Label_012B;
        }
        this.healthIcon.Hide(0);
        this.damageIcon.Hide(0);
        this.armorIcon.Hide(0);
        this.respawnIcon.Hide(0);
        goto Label_0238;
    Label_012B:
        if ((this.creep != null) == null)
        {
            goto Label_0171;
        }
        this.healthIcon.Hide(0);
        this.damageIcon.Hide(0);
        this.armorIcon.Hide(0);
        this.costIcon.Hide(0);
        goto Label_0238;
    Label_0171:
        if ((this.tower != null) == null)
        {
            goto Label_0238;
        }
        if ((this.selection.name == "Mages") == null)
        {
            goto Label_01C5;
        }
        this.mageDamageIcon.Hide(0);
        this.rangeIcon.Hide(0);
        this.reloadIcon.Hide(0);
        goto Label_0238;
    Label_01C5:
        if ((this.selection.name == "Barracks") == null)
        {
            goto Label_0214;
        }
        this.damageIcon.Hide(0);
        this.armorIcon.Hide(0);
        this.healthIcon.Hide(0);
        this.respawnIcon.Hide(0);
        goto Label_0238;
    Label_0214:
        this.damageIcon.Hide(0);
        this.rangeIcon.Hide(0);
        this.reloadIcon.Hide(0);
    Label_0238:
        return;
    }

    private unsafe void Start()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        Vector3 vector11;
        Vector3 vector12;
        Vector3 vector13;
        Vector3 vector14;
        Vector3 vector15;
        Vector3 vector16;
        this.moving = 0;
        this.hidden = 1;
        this.sprite = base.GetComponent<PackedSprite>();
        this.originalPosition = base.transform.position;
        this.horizRatio = ((float) Screen.width) / 1920f;
        this.vertRatio = ((float) Screen.height) / 1080f;
        transform = null;
        transform = UnityEngine.Object.Instantiate(this.healthIconPrefab, new Vector3(-20f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.healthIcon = transform.GetComponent<PackedSprite>();
        this.healthIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.damageIconPrefab, new Vector3(150f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.damageIcon = transform.GetComponent<PackedSprite>();
        this.damageIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.armorIconPrefab, new Vector3(300f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.armorIcon = transform.GetComponent<PackedSprite>();
        this.armorIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.respawnIconPrefab, new Vector3(450f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.respawnIcon = transform.GetComponent<PackedSprite>();
        this.respawnIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.costIconPrefab, new Vector3(450f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.costIcon = transform.GetComponent<PackedSprite>();
        this.costIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.rangeIconPrefab, new Vector3(450f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.rangeIcon = transform.GetComponent<PackedSprite>();
        this.rangeIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.reloadIconPrefab, new Vector3(270f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.reloadIcon = transform.GetComponent<PackedSprite>();
        this.reloadIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.mageDamageIconPrefab, new Vector3(150f, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.mageDamageIcon = transform.GetComponent<PackedSprite>();
        this.mageDamageIcon.Hide(1);
        return;
    }

    public unsafe void TranslateTween(float xEnd, float yEnd, float time)
    {
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        this.tweenTime = time;
        this.moving = 1;
        this.hidden = 0;
        this.endPosition = new Vector3(xEnd, yEnd, &base.transform.position.z);
        this.endPos2d = new Vector2(xEnd, yEnd);
        &vector = new Vector2(&base.transform.position.x, &base.transform.position.y);
        this.tweenDistance = Vector2.Distance(vector, this.endPos2d);
        this.tweenSpeed = this.tweenDistance / time;
        this.tweenDir = new Vector3(xEnd - &base.transform.position.x, yEnd - &base.transform.position.y, 0f);
        &this.tweenDir.Normalize();
        return;
    }

    private unsafe void UpdateInfo()
    {
        if ((this.soldier != null) == null)
        {
            goto Label_00FD;
        }
        GUI.Label(new Rect(960f, 1022f, 120f, 35f), ((int) this.soldier.GetHealth()) + "/" + ((int) this.soldier.GetInitHealth()));
        GUI.Label(new Rect(1125f, 1022f, 120f, 35f), ((int) this.soldier.minDamage) + "-" + ((int) this.soldier.maxDamage));
        GUI.Label(new Rect(1280f, 1022f, 120f, 35f), this.soldier.GetArmor());
        GUI.Label(new Rect(1430f, 1022f, 120f, 35f), &this.soldier.respawnTime.ToString());
        goto Label_03A5;
    Label_00FD:
        if ((this.creep != null) == null)
        {
            goto Label_01FA;
        }
        GUI.Label(new Rect(960f, 1022f, 120f, 35f), ((int) this.creep.GetHealth()) + "/" + ((int) this.creep.GetTotalLife()));
        GUI.Label(new Rect(1125f, 1022f, 120f, 35f), ((int) this.creep.minDamage) + "-" + ((int) this.creep.maxDamage));
        GUI.Label(new Rect(1280f, 1022f, 120f, 35f), this.creep.GetArmor());
        GUI.Label(new Rect(1430f, 1022f, 120f, 35f), &this.creep.cost.ToString());
        goto Label_03A5;
    Label_01FA:
        if ((this.tower != null) == null)
        {
            goto Label_03A5;
        }
        if ((this.selection.name == "Barracks") == null)
        {
            goto Label_030B;
        }
        GUI.Label(new Rect(960f, 1022f, 120f, 35f), &((BarrackTower) this.tower).health.ToString());
        GUI.Label(new Rect(1125f, 1022f, 120f, 35f), ((int) this.tower.minDamange) + "-" + ((int) this.tower.maxDamage));
        GUI.Label(new Rect(1280f, 1022f, 120f, 35f), IronUtils.GetArmor(((BarrackTower) this.tower).armor));
        GUI.Label(new Rect(1430f, 1022f, 120f, 35f), &((BarrackTower) this.tower).respawn.ToString());
        goto Label_03A5;
    Label_030B:
        GUI.Label(new Rect(1125f, 1022f, 120f, 35f), ((int) this.tower.minDamange) + "-" + ((int) this.tower.maxDamage));
        GUI.Label(new Rect(1430f, 1022f, 120f, 35f), this.tower.GetRange());
        GUI.Label(new Rect(1250f, 1022f, 120f, 35f), this.tower.GetReload());
    Label_03A5:
        return;
    }
}

