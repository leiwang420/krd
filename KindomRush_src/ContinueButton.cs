using System;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    protected LoadingScreen loadingScreen;
    protected Transform restarPrefab;
    protected PackedSprite sprite;

    public ContinueButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected void OnMouseDown()
    {
        Time.timeScale = 1f;
        GameData.LevelToLoad = 1;
        this.loadingScreen.Launch();
        return;
    }

    protected void OnMouseEnter()
    {
        GameSoundManager.PlayGUIButtonCommon();
        this.sprite.PlayAnim("over");
        return;
    }

    protected void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    protected void ShowRestart()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.restarPrefab, new Vector3(0f, -127f, -908f), Quaternion.identity) as Transform;
        transform.parent = base.transform.parent;
        return;
    }

    private void Start()
    {
        object[] objArray1;
        this.restarPrefab = ((GameObject) Resources.Load("Prefabs/Screens/Button Restart")).GetComponent<Transform>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, -93f, -909f), "time", (float) 0.4f, "easetype", (iTween.EaseType) 0x1b, "oncomplete", "ShowRestart" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }
}

