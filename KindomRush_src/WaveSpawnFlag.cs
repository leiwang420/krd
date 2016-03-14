using System;
using System.Collections;
using UnityEngine;

public class WaveSpawnFlag : MonoBehaviour
{
    private Transform coinPrefab;
    private int counter;
    private bool first;
    private float fraction;
    private bool isPaused;
    private Transform over;
    private Transform pointer;
    private Transform pointerOver;
    public Transform pointerPrefab;
    private circle ring;
    private PackedSprite ringFull;
    private StageBase stage;
    private int timeCounter;
    private WaveTooltip tooltip;
    private Transform tooltipPrefab;
    private int totalLinesTooltip;
    private int totalTime;
    private Wave wave;
    private Transform waveRewardGoldPrefab;

    public WaveSpawnFlag()
    {
        base..ctor();
        return;
    }

    private void CallWave()
    {
        this.stage.SendNextWave(this);
        this.stage.DestroyFlags();
        return;
    }

    private void CleanUp()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void DisableFlag()
    {
        base.collider.enabled = 0;
        if ((this.over != null) == null)
        {
            goto Label_002D;
        }
        UnityEngine.Object.Destroy(this.over.gameObject);
    Label_002D:
        if ((this.pointerOver != null) == null)
        {
            goto Label_004E;
        }
        UnityEngine.Object.Destroy(this.pointerOver.gameObject);
    Label_004E:
        return;
    }

    private void FadeOut()
    {
        ParticleFadeOut @out;
        @out = base.GetComponent<ParticleFadeOut>();
        @out.enabled = 1;
        @out.Fade();
        @out = this.pointer.GetComponent<ParticleFadeOut>();
        @out.enabled = 1;
        @out.Fade();
        @out = base.transform.FindChild("Skull").GetComponent<ParticleFadeOut>();
        @out.enabled = 1;
        @out.Fade();
        this.ring.gameObject.SetActive(0);
        this.ringFull.Hide(1);
        return;
    }

    private void FixedUpdate()
    {
        float num;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.first != null)
        {
            goto Label_0047;
        }
        this.timeCounter += 1;
        num = 1f - (((float) this.timeCounter) / ((float) this.totalTime));
        this.ring.SetCutoff(num);
    Label_0047:
        return;
    }

    private unsafe string GetWaveAsString(ArrayList myWaves)
    {
        string str;
        int num;
        int num2;
        str = string.Empty;
        num = 0;
        goto Label_0079;
    Label_000D:
        str = (str + ((string) ((ArrayList) myWaves[num])[0]) + ((GameData.GetGameMode() == 2) ? "??" : (" x " + &(num2 = (int) ((ArrayList) myWaves[num])[1]).ToString()))) + "\n";
        num += 1;
    Label_0079:
        if (num < myWaves.Count)
        {
            goto Label_000D;
        }
        return str;
    }

    public unsafe void Init(int time, bool myFirst, Vector3 pointerPosition, Wave w)
    {
        ArrayList list;
        Vector3 vector;
        this.LoadTooltip();
        list = w.GetTooltipInformation();
        this.tooltip.SetText(this.GetWaveAsString(list));
        this.tooltip.ResizeForLines(list.Count);
        this.tooltip.AdjustPositionForLines(list.Count, &base.transform.position.y);
        this.wave = w;
        this.totalTime = time;
        this.first = myFirst;
        this.pointer = UnityEngine.Object.Instantiate(this.pointerPrefab, base.transform.position + new Vector3(0f, 28f, -1f), Quaternion.identity) as Transform;
        this.pointer.parent = base.transform;
        this.pointer.RotateAround(base.transform.position, Vector3.back, 90f);
        this.pointer.RotateAround(base.transform.position, Vector3.back, -(Mathf.Atan2(&pointerPosition.y, &pointerPosition.x) * 57.29578f));
        this.pointerOver = this.pointer.FindChild("Over");
        return;
    }

    public unsafe void KillFlag()
    {
        object[] objArray1;
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        if ((this.tooltip != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.tooltip.gameObject);
    Label_0021:
        base.collider.enabled = 0;
        num = &base.transform.localScale.x + 0.25f;
        num2 = &base.transform.localScale.y + 0.25f;
        objArray1 = new object[] { "x", (float) 1.3f, "y", (float) 1.3f, "time", (float) 0.3f, "easetype", (iTween.EaseType) 2, "oncomplete", "CleanUp" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        this.FadeOut();
        return;
    }

    private unsafe void LoadTooltip()
    {
        float num;
        float num2;
        Vector3 vector;
        Transform transform;
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
        this.tooltipPrefab = Resources.Load("Prefabs/GUI/WaveTooltip", typeof(Transform)) as Transform;
        if (&base.transform.position.y > -334f)
        {
            goto Label_005D;
        }
        num = &base.transform.position.y + 120f;
        goto Label_0078;
    Label_005D:
        num = &base.transform.position.y - 45f;
    Label_0078:
        if (&base.transform.position.x > -633f)
        {
            goto Label_00B6;
        }
        num2 = &base.transform.position.x + 150f;
        goto Label_00D1;
    Label_00B6:
        num2 = &base.transform.position.x - 130f;
    Label_00D1:
        &vector = new Vector3(num2, num, -905f);
        transform = UnityEngine.Object.Instantiate(this.tooltipPrefab, vector, Quaternion.identity) as Transform;
        this.tooltip = transform.GetComponent<WaveTooltip>();
        this.tooltip.gameObject.SetActive(0);
        if (&this.tooltip.transform.position.x >= &base.transform.position.x)
        {
            goto Label_0197;
        }
        if (&this.tooltip.transform.position.y >= &base.transform.position.y)
        {
            goto Label_0187;
        }
        this.tooltip.SetArrowTR();
        goto Label_0192;
    Label_0187:
        this.tooltip.SetArrowBR();
    Label_0192:
        goto Label_01E4;
    Label_0197:
        if (&this.tooltip.transform.position.y >= &base.transform.position.y)
        {
            goto Label_01D9;
        }
        this.tooltip.SetArrowTL();
        goto Label_01E4;
    Label_01D9:
        this.tooltip.SetArrowBL();
    Label_01E4:
        return;
    }

    private void OnMouseExit()
    {
        if ((this.over != null) == null)
        {
            goto Label_0022;
        }
        this.over.gameObject.SetActive(0);
    Label_0022:
        if ((this.pointerOver != null) == null)
        {
            goto Label_0044;
        }
        this.pointerOver.gameObject.SetActive(0);
    Label_0044:
        if ((this.tooltip != null) == null)
        {
            goto Label_0066;
        }
        this.tooltip.gameObject.SetActive(0);
    Label_0066:
        return;
    }

    private void OnMouseOver()
    {
        if ((this.over != null) == null)
        {
            goto Label_0022;
        }
        this.over.gameObject.SetActive(1);
    Label_0022:
        if ((this.pointerOver != null) == null)
        {
            goto Label_0044;
        }
        this.pointerOver.gameObject.SetActive(1);
    Label_0044:
        if ((this.tooltip != null) == null)
        {
            goto Label_007B;
        }
        if (this.tooltip.gameObject.activeSelf != null)
        {
            goto Label_007B;
        }
        this.tooltip.gameObject.SetActive(1);
    Label_007B:
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_0092;
        }
        this.DisableFlag();
        this.CallWave();
    Label_0092:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public unsafe void ShowGold(int gold)
    {
        Transform transform;
        Transform transform2;
        Vector3 vector;
        if (&base.transform.position.x < 0f)
        {
            goto Label_00CB;
        }
        UnityEngine.Object.Instantiate(this.coinPrefab, base.transform.position + new Vector3(-40f, 0f, 0f), Quaternion.identity);
        transform = UnityEngine.Object.Instantiate(this.waveRewardGoldPrefab, base.transform.position + new Vector3(-80f, 10f, 0f), Quaternion.identity) as Transform;
        transform.GetComponent<WaveRewardTime>().SetGold(gold);
        if ((gold / 100) == null)
        {
            goto Label_0174;
        }
        transform.position += new Vector3(-20f, 0f, 0f);
        goto Label_0174;
    Label_00CB:
        UnityEngine.Object.Instantiate(this.coinPrefab, base.transform.position + new Vector3(40f, 0f, 0f), Quaternion.identity);
        transform2 = UnityEngine.Object.Instantiate(this.waveRewardGoldPrefab, base.transform.position + new Vector3(80f, 10f, 0f), Quaternion.identity) as Transform;
        transform2.GetComponent<WaveRewardTime>().SetGold(gold);
        if ((gold / 100) == null)
        {
            goto Label_0174;
        }
        transform2.position += new Vector3(20f, 0f, 0f);
    Label_0174:
        return;
    }

    private void Start()
    {
        object[] objArray1;
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.ring = base.transform.FindChild("Ring").GetComponent<circle>();
        this.ringFull = base.transform.FindChild("RingFull").GetComponent<PackedSprite>();
        this.over = base.transform.FindChild("Over");
        this.coinPrefab = Resources.Load("Prefabs/GUI/Coin", typeof(Transform)) as Transform;
        this.waveRewardGoldPrefab = Resources.Load("Prefabs/GUI/WaveRewardGold", typeof(Transform)) as Transform;
        objArray1 = new object[] { "x", (float) 1.04f, "y", (float) 1.04f, "time", (float) 0.45f, "easetype", (iTween.EaseType) 2, "looptype", (iTween.LoopType) 2 };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        if (this.first == null)
        {
            goto Label_0145;
        }
        this.ringFull.Hide(0);
        this.ring.gameObject.SetActive(0);
        goto Label_0161;
    Label_0145:
        this.ringFull.Hide(1);
        this.ring.SetCutoff(1f);
    Label_0161:
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }

    public void UpdateProgress(float t)
    {
        if (this.first != null)
        {
            goto Label_001D;
        }
        this.ring.SetCutoff(1f - t);
    Label_001D:
        return;
    }
}

