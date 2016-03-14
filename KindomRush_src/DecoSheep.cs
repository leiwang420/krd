using System;
using UnityEngine;

public class DecoSheep : MonoBehaviour
{
    public Transform bloodDecal;
    public float bloodOffset;
    private int clickCount;
    private int clickTotal;
    public float gibOffset;
    public Transform gibPrefab;

    public DecoSheep()
    {
        this.gibOffset = 5f;
        this.bloodOffset = 11f;
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private unsafe void OnMouseDown()
    {
        Vector3 vector;
        this.clickCount += 1;
        GameSoundManager.PlaySheep();
        base.transform.localScale = new Vector3(&base.transform.localScale.x * 1.2f, 1.2f, 1f);
        if (this.clickCount != this.clickTotal)
        {
            goto Label_00D8;
        }
        GameAchievements.KillSheep();
        GameSoundManager.PlayDeathExplosion();
        UnityEngine.Object.Instantiate(this.gibPrefab, base.transform.position - new Vector3(0f, this.gibOffset, 0f), Quaternion.identity);
        UnityEngine.Object.Instantiate(this.bloodDecal, base.transform.position - new Vector3(0f, this.bloodOffset, 0f), Quaternion.identity);
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00D8:
        return;
    }

    private unsafe void OnMouseUp()
    {
        Vector3 vector;
        base.transform.localScale = new Vector3(&base.transform.localScale.x / 1.2f, 1f, 1f);
        return;
    }

    private void Start()
    {
        this.clickTotal = UnityEngine.Random.Range(4, 8);
        return;
    }
}

