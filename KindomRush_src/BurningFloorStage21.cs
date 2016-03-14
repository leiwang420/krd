using System;
using System.Collections;
using UnityEngine;

public class BurningFloorStage21 : BurningFloor
{
    public BurningFloorStage21()
    {
        base..ctor();
        return;
    }

    protected override void CreateDamagePoints()
    {
        base.damagePoints = new ArrayList();
        base.damagePoints.Add((Vector3) new Vector3(-159f, -143f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(-312f, -227f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(438f, -250f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(453f, -152f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(-288f, -120f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(-246f, -175f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(294f, -152f, 0f));
        base.damagePoints.Add((Vector3) new Vector3(378f, -198f, 0f));
        base.damageReloadTime = 10;
        base.rangeWidth = 0xd4;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        return;
    }

    protected override void LoadDataCampaign()
    {
        int[] numArray18;
        int[] numArray17;
        int[] numArray16;
        int[] numArray15;
        int[] numArray14;
        int[] numArray13;
        int[] numArray12;
        int[] numArray11;
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
        base.data = new int[0x12][];
        numArray1 = new int[] { 3, 5 };
        base.data[0] = numArray1;
        numArray2 = new int[] { 3, 5 };
        base.data[1] = numArray2;
        numArray3 = new int[] { 3, 5 };
        base.data[2] = numArray3;
        numArray4 = new int[] { 3, 5 };
        base.data[3] = numArray4;
        numArray5 = new int[] { 3, 5 };
        base.data[4] = numArray5;
        numArray6 = new int[] { 3, 5 };
        base.data[5] = numArray6;
        numArray7 = new int[] { 3, 5 };
        base.data[6] = numArray7;
        numArray8 = new int[] { 3, 5 };
        base.data[7] = numArray8;
        numArray9 = new int[] { 3, 5 };
        base.data[8] = numArray9;
        numArray10 = new int[] { 3, 5 };
        base.data[9] = numArray10;
        numArray11 = new int[] { 3, 5 };
        base.data[10] = numArray11;
        numArray12 = new int[] { 3, 5 };
        base.data[11] = numArray12;
        numArray13 = new int[] { 3, 5 };
        base.data[12] = numArray13;
        numArray14 = new int[] { 3, 5 };
        base.data[13] = numArray14;
        numArray15 = new int[] { 3, 5 };
        base.data[14] = numArray15;
        numArray16 = new int[] { 3, 5 };
        base.data[15] = numArray16;
        numArray17 = new int[] { 3, 5 };
        base.data[0x10] = numArray17;
        numArray18 = new int[] { 3, 5 };
        base.data[0x11] = numArray18;
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
        numArray1 = new int[] { 1, 40 };
        base.data[0] = numArray1;
        numArray2 = new int[] { 13, 10 };
        base.data[1] = numArray2;
        numArray3 = new int[] { 2, 10 };
        base.data[2] = numArray3;
        numArray4 = new int[] { 2, 10 };
        base.data[3] = numArray4;
        numArray5 = new int[] { 2, 10 };
        base.data[4] = numArray5;
        numArray6 = new int[] { 3, 10 };
        base.data[5] = numArray6;
        return;
    }

    protected override void LoadDataIron()
    {
        int[] numArray1;
        base.data = new int[1][];
        numArray1 = new int[] { 1, 0x2710 };
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

