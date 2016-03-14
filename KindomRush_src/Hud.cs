using System;
using UnityEngine;

public class Hud : MonoBehaviour
{
    private float horizRatio;
    private StageBase stage;
    private TextMesh textGold;
    private TextMesh textHearts;
    private TextMesh textWaves;
    private string totalWaves;
    private float vertRatio;

    public Hud()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        return;
    }

    private unsafe void FixedUpdate()
    {
        int num;
        int num2;
        int num3;
        int num4;
        if (this.totalWaves != null)
        {
            goto Label_0024;
        }
        this.totalWaves = &this.stage.GetTotalWaveNumber().ToString();
    Label_0024:
        this.textHearts.text = &this.stage.GetLives().ToString();
        this.textGold.text = &this.stage.GetGold().ToString();
        this.textWaves.text = "Wave " + &this.stage.GetCurrentWaveNumber().ToString() + "/" + this.totalWaves;
        return;
    }

    private void Start()
    {
        this.textHearts = base.transform.FindChild("Hearts").GetComponent<TextMesh>();
        this.textGold = base.transform.FindChild("Gold").GetComponent<TextMesh>();
        this.textWaves = base.transform.FindChild("Waves").GetComponent<TextMesh>();
        return;
    }
}

