using System;
using UnityEngine;

public class UpgradeBuyButton : MonoBehaviour
{
    private UpgradeScreen upgradeScreen;

    public UpgradeBuyButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        object[] objArray1;
        base.collider.enabled = 0;
        objArray1 = new object[] { "position", (Vector3) new Vector3(434f, -35f, -912f), "time", (double) 0.25, "easetype", (iTween.EaseType) 1 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void OnMouseDown()
    {
        this.upgradeScreen.Buy();
        GameSoundManager.PlayGUIBuyUpgrade();
        return;
    }

    public void Show()
    {
        object[] objArray1;
        base.collider.enabled = 1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(434f, -145f, -912f), "time", (double) 0.25, "easetype", (iTween.EaseType) 1 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.upgradeScreen = GameObject.Find("Upgrade Screen").GetComponent<UpgradeScreen>();
        return;
    }
}

