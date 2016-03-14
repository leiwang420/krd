using System;
using System.Collections;
using UnityEngine;

public class EncyclopediaScreen : MonoBehaviour
{
    private Transform activeContainer;
    private EncyclopediaContainerCreeps containerCreeps;
    private EncyclopediaContainerTowers containerTowers;
    private Map map;
    private PackedSprite tabCreep;
    private PackedSprite tabTower;

    public EncyclopediaScreen()
    {
        base..ctor();
        return;
    }

    private void CleanUp()
    {
        base.transform.position = new Vector3(0f, 1600f, -910f);
        this.ResetFade(base.transform);
        return;
    }

    private void Fade(Transform t)
    {
        ParticleFadeOut @out;
        TextMesh mesh;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if (t.GetComponent<PackedSprite>() == null)
        {
            goto Label_0058;
        }
        if (t.GetComponent<ParticleFadeOut>() != null)
        {
            goto Label_004D;
        }
        @out = t.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        goto Label_0058;
    Label_004D:
        t.GetComponent<ParticleFadeOut>().Fade();
    Label_0058:
        mesh = t.GetComponent<TextMesh>();
        if ((mesh != null) == null)
        {
            goto Label_0077;
        }
        mesh.gameObject.SetActive(0);
    Label_0077:
        enumerator = t.GetEnumerator();
    Label_007E:
        try
        {
            goto Label_0096;
        Label_0083:
            transform = (Transform) enumerator.Current;
            this.Fade(transform);
        Label_0096:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0083;
            }
            goto Label_00BB;
        }
        finally
        {
        Label_00A6:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B3;
            }
        Label_00B3:
            disposable.Dispose();
        }
    Label_00BB:
        return;
    }

    public void HideScreen()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 60f, -910f), "time", (double) 0.2, "easetype", (iTween.EaseType) 7, "oncomplete", "CleanUp" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        this.Fade(base.transform);
        return;
    }

    public bool IsCreepContainerActive()
    {
        return (this.containerCreeps.gameObject.activeSelf == 1);
    }

    public bool IsTowerContainerActive()
    {
        return (this.containerTowers.gameObject.activeSelf == 1);
    }

    private void Reset()
    {
        this.containerTowers.gameObject.SetActive(1);
        this.containerTowers.Reset();
        this.containerCreeps.gameObject.SetActive(0);
        this.tabTower.PlayAnim("off");
        this.tabCreep.RevertToStatic();
        return;
    }

    private void ResetFade(Transform t)
    {
        ParticleFadeOut @out;
        TextMesh mesh;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        @out = t.GetComponent<ParticleFadeOut>();
        if ((@out != null) == null)
        {
            goto Label_0019;
        }
        @out.Reset();
    Label_0019:
        mesh = t.GetComponent<TextMesh>();
        if ((mesh != null) == null)
        {
            goto Label_0038;
        }
        mesh.gameObject.SetActive(1);
    Label_0038:
        enumerator = t.GetEnumerator();
    Label_003F:
        try
        {
            goto Label_0057;
        Label_0044:
            transform = (Transform) enumerator.Current;
            this.ResetFade(transform);
        Label_0057:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0044;
            }
            goto Label_007C;
        }
        finally
        {
        Label_0067:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0074;
            }
        Label_0074:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    public void ShowContainer(string containerName)
    {
        if (containerName.Equals("towers") == null)
        {
            goto Label_004D;
        }
        this.containerTowers.gameObject.SetActive(1);
        this.containerCreeps.gameObject.SetActive(0);
        this.containerTowers.Reset();
        this.tabCreep.RevertToStatic();
        goto Label_0095;
    Label_004D:
        if (containerName.Equals("creeps") == null)
        {
            goto Label_0095;
        }
        this.containerTowers.gameObject.SetActive(0);
        this.containerCreeps.gameObject.SetActive(1);
        this.containerCreeps.Open();
        this.tabTower.RevertToStatic();
    Label_0095:
        return;
    }

    public void ShowScreen()
    {
        object[] objArray1;
        base.transform.position = new Vector3(0f, 69f, -910f);
        this.Reset();
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 19f, -910f), "time", (double) 0.25, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.containerTowers = base.transform.FindChild("ContainerTowers").GetComponent<EncyclopediaContainerTowers>();
        this.containerCreeps = base.transform.FindChild("ContainerCreeps").GetComponent<EncyclopediaContainerCreeps>();
        this.tabTower = base.transform.FindChild("TabTowers").GetComponent<PackedSprite>();
        this.tabCreep = base.transform.FindChild("TabEnemies").GetComponent<PackedSprite>();
        this.Reset();
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_0045;
        }
        if (&base.transform.position.y != 19f)
        {
            goto Label_0045;
        }
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.HideScreen();
    Label_0045:
        return;
    }
}

