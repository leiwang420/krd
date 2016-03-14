using System;
using UnityEngine;

public class BolinParticleEmitter : MonoBehaviour
{
    private Vector3 end;
    private bool isEnabled;
    private bool isPaused;
    public PackedSprite particle;
    public float spawnTime;
    private Vector3 start;
    private float timer;

    public BolinParticleEmitter()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.isEnabled = 0;
        return;
    }

    private void FixedUpdate()
    {
        PackedSprite sprite;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isEnabled == null)
        {
            goto Label_006C;
        }
        this.timer += Time.deltaTime;
        if (this.timer < this.spawnTime)
        {
            goto Label_006C;
        }
        sprite = UnityEngine.Object.Instantiate(this.particle, base.transform.position, base.transform.rotation) as PackedSprite;
        this.timer = 0f;
    Label_006C:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public void SetEnabled(bool e)
    {
        this.isEnabled = e;
        return;
    }

    private unsafe void SetupPoints()
    {
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        vector = ((Bullet) base.transform.GetComponent("Bullet")).GetDir();
        this.start = new Vector3(&vector.x + &base.transform.position.x, &vector.y + &base.transform.position.y, 0f);
        &this.start.Normalize();
        this.start *= 20f;
        this.start += new Vector3(0f, 0f, &base.transform.position.z);
        this.end = new Vector3(&base.transform.position.x - &vector.x, &base.transform.position.y - &vector.y, 0f);
        &this.end.Normalize();
        this.end *= -20f;
        this.end += new Vector3(0f, 0f, &base.transform.position.z);
        return;
    }

    private void Start()
    {
        base.Invoke("SetupPoints", 0.1f);
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

