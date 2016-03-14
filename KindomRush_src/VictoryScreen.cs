using System;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    protected Transform buttonContinuePrefab;
    protected StageBase stage;
    protected Transform starsPrefab;

    public VictoryScreen()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected int GetStars()
    {
        int num;
        num = this.stage.GetLives();
        if (num < 0x12)
        {
            goto Label_0016;
        }
        return 3;
    Label_0016:
        if (num < 6)
        {
            goto Label_001F;
        }
        return 2;
    Label_001F:
        return 1;
    }

    protected void PlayStarSounds()
    {
        GameSoundManager.PlayGUIWinStars();
        return;
    }

    protected void ShowButtons(SpriteBase sprt)
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.buttonContinuePrefab, Vector3.zero, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.localPosition = new Vector3(0f, 0f, 1f);
        return;
    }

    public void ShowStars()
    {
        Transform transform;
        PackedSprite sprite;
        int num;
        transform = UnityEngine.Object.Instantiate(this.starsPrefab, Vector3.zero, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.localPosition = new Vector3(-2f, -110f, -1f);
        sprite = transform.GetComponent<PackedSprite>();
        sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.ShowButtons));
        num = this.GetStars();
        if (num != 3)
        {
            goto Label_009E;
        }
        sprite.PlayAnim("threeStars");
        this.PlayStarSounds();
        base.Invoke("PlayStarSounds", 0.7f);
        base.Invoke("PlayStarSounds", 1.4f);
        goto Label_00DC;
    Label_009E:
        if (num != 2)
        {
            goto Label_00CB;
        }
        sprite.PlayAnim("twoStars");
        this.PlayStarSounds();
        base.Invoke("PlayStarSounds", 0.7f);
        goto Label_00DC;
    Label_00CB:
        sprite.PlayAnim("oneStar");
        this.PlayStarSounds();
    Label_00DC:
        return;
    }

    private void Start()
    {
        object[] objArray1;
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.starsPrefab = ((GameObject) Resources.Load("Prefabs/Screens/Stars")).GetComponent<Transform>();
        this.buttonContinuePrefab = ((GameObject) Resources.Load("Prefabs/Screens/Button Continue")).GetComponent<Transform>();
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1b, "oncomplete", "ShowStars" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        if (GameData.GetGameMode() != null)
        {
            goto Label_00E1;
        }
        GameData.GetCurrentStageData().Win(this.GetStars());
        goto Label_0130;
    Label_00E1:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_010B;
        }
        base.GetComponent<PackedSprite>().PlayAnim("heroic");
        GameData.GetCurrentStageData().WinHeroic();
        goto Label_0130;
    Label_010B:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_0130;
        }
        base.GetComponent<PackedSprite>().PlayAnim("iron");
        GameData.GetCurrentStageData().WinIron();
    Label_0130:
        this.stage.PauseMusic();
        GameSoundManager.PlayGUIQuestCompleted();
        return;
    }
}

