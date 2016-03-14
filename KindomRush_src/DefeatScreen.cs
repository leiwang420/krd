using System;
using System.Collections;
using UnityEngine;

public class DefeatScreen : MonoBehaviour
{
    private TextMesh tip;
    private ArrayList tipAdjustList;
    private ArrayList tipList;

    public DefeatScreen()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.tip = base.transform.FindChild("Text").FindChild("Tip").GetComponent<TextMesh>();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void LoadTips()
    {
        this.tipList = new ArrayList();
        this.tipList.Add("Enemies and Soldiers with armor receive\nless physical damage.");
        this.tipList.Add("Support barracks with ranged towers to\nmaximize enemy exposure.");
        this.tipList.Add("Reinforcements are a great way to split\nenemy forces.");
        this.tipList.Add("Artillery works best against high\nconcentration of enemies.");
        this.tipList.Add("Artillery damage is higher in the center\nof the explosion.");
        this.tipList.Add("Use reinforcements constantly to slow\nand damage the enemy.");
        this.tipList.Add("Always aim rain of fire a little ahead\nof your target.");
        this.tipList.Add("With the Salvage upgrade you can sell\narcher towers with only a 10% loss.");
        this.tipList.Add("Magic damage is the best way to deal\nwith armored enemies.");
        this.tipList.Add("Flying enemies cannot be blocked by\nbarracks, and won't be targeted by most\nartillery.");
        this.tipList.Add("Enemies with magic resistance receive\nless damage from magic attacks.");
        this.tipList.Add("Adjust the rally point of soldiers to\ncreate better strategies.");
        this.tipList.Add("Sometimes it is better to build more\ntowers instead of upgrading a few.");
        this.tipList.Add("Poison damage ignores armor.");
        this.tipList.Add("Upgrading a barrack, instantly trains\nnew soldiers.");
        this.tipList.Add("Calling an early wave gives bonus cash\nand reduces spell cooldowns a bit.");
        this.tipList.Add("Artillery explosions can damage flying\nenemies although they cannot target\nthem directly.");
        this.tipList.Add("Use barracks or reinforcement to\nisolate troublesome enemies.");
        this.tipList.Add("Barbarians with the right upgrades are\ncapable of dealing with flying enemies.");
        this.tipList.Add("Earth elementals are very tough and deal\narea damage every time they strike.");
        this.tipList.Add("You can check the incoming wave\nenemies by hovering over the wave icon.");
        this.tipAdjustList = new ArrayList();
        this.tipAdjustList.Add((float) -2f);
        this.tipAdjustList.Add((float) -2f);
        this.tipAdjustList.Add((float) -3f);
        this.tipAdjustList.Add((float) 25f);
        this.tipAdjustList.Add((float) 5f);
        this.tipAdjustList.Add((float) 5f);
        this.tipAdjustList.Add((float) 7f);
        this.tipAdjustList.Add((float) 7f);
        this.tipAdjustList.Add((float) 15f);
        this.tipAdjustList.Add((float) 5f);
        this.tipAdjustList.Add((float) 5f);
        this.tipAdjustList.Add((float) 18f);
        this.tipAdjustList.Add((float) 16f);
        this.tipAdjustList.Add((float) 33f);
        this.tipAdjustList.Add((float) 12f);
        this.tipAdjustList.Add((float) 5f);
        this.tipAdjustList.Add((float) 4f);
        this.tipAdjustList.Add((float) 20f);
        this.tipAdjustList.Add((float) 5f);
        this.tipAdjustList.Add((float) -3f);
        this.tipAdjustList.Add((float) 7f);
        return;
    }

    private void SelectTip()
    {
        Transform transform1;
        int num;
        num = 20;
        this.tip.text = (string) this.tipList[num];
        transform1 = this.tip.transform;
        transform1.position += new Vector3((float) this.tipAdjustList[num], 0f, 0f);
        return;
    }

    private void Start()
    {
        object[] objArray1;
        this.LoadTips();
        this.SelectTip();
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 97f, -907f), "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1b };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        GameSoundManager.PlayGUIQuestFailed();
        return;
    }
}

