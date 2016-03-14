using System;
using System.Collections;
using UnityEngine;

public class BurningFloorStage20 : BurningFloor
{
    public BurningFloorStage20()
    {
        base..ctor();
        return;
    }

    protected override void CreateDamagePoints()
    {
        base.damagePoints = new ArrayList();
        base.damagePoints.Add((Vector3) new Vector3(31f, 166f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(129f, 203f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(-425f, -116f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(227f, 242f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(-363f, -173f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(198f, -117f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(94f, 270f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(275f, -66f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(101f, -128f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(38f, 324f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(-487f, -65f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(335f, -12f, 0f));
        base.damageReloadTime = 10;
        base.rangeWidth = 0xd4;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        return;
    }

    protected override void LoadDataCampaign()
    {
        int[] numArray10;
        int[] numArray9;
        int[] numArray8;
        int[] numArray7;
        int[] numArray6;
        int[] numArray5;
        int[] numArray4;
        int[] numArray3;
        int[] numArray2;
        int[] numArray1;
        base.data = new int[20][];
        base.data[0] = new int[2];
        base.data[1] = new int[2];
        base.data[2] = new int[2];
        numArray1 = new int[] { 3, 40 };
        base.data[3] = numArray1;
        numArray2 = new int[] { 3, 40 };
        base.data[4] = numArray2;
        base.data[5] = new int[2];
        base.data[6] = new int[2];
        numArray3 = new int[] { 3, 20 };
        base.data[7] = numArray3;
        numArray4 = new int[] { 3, 30 };
        base.data[8] = numArray4;
        numArray5 = new int[] { 3, 40 };
        base.data[9] = numArray5;
        base.data[10] = new int[2];
        base.data[11] = new int[2];
        numArray6 = new int[] { 10, 20 };
        base.data[12] = numArray6;
        base.data[13] = new int[2];
        numArray7 = new int[] { 3, 40 };
        base.data[14] = numArray7;
        numArray8 = new int[] { 3, 5 };
        base.data[15] = numArray8;
        numArray9 = new int[] { 3, 5 };
        base.data[0x10] = numArray9;
        numArray10 = new int[] { 3, 5 };
        base.data[0x11] = numArray10;
        base.data[0x12] = new int[2];
        base.data[0x13] = new int[2];
        return;
    }

    protected override void LoadDataHeroic()
    {
        int[] numArray6;
        int[] numArray5;
        int[] numArray4;
        int[] numArray3;
        int[] numArray2;
        int[] numArray1;
        base.data = new int[6][];
        numArray1 = new int[] { 1, 10 };
        base.data[0] = numArray1;
        numArray2 = new int[] { 15, 0x19 };
        base.data[1] = numArray2;
        numArray3 = new int[] { 15, 50 };
        base.data[2] = numArray3;
        numArray4 = new int[] { 5, 40 };
        base.data[3] = numArray4;
        numArray5 = new int[] { 15, 120 };
        base.data[4] = numArray5;
        numArray6 = new int[] { 20, 240 };
        base.data[5] = numArray6;
        return;
    }

    protected override void LoadDataIron()
    {
        int[] numArray1;
        base.data = new int[1][];
        numArray1 = new int[] { 5, 0x270f };
        base.data[0] = numArray1;
        return;
    }

    public override void SetSettingsOnWave()
    {
        base.reloadTime = base.data[base.stage.GetCurrentWaveNumber() - 1][0] * 30;
        base.durationTime = base.data[base.stage.GetCurrentWaveNumber() - 1][1] * 30;
        base.SetSettingsOnWave();
        return;
    }
}

