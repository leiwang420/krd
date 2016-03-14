using System;
using UnityEngine;

public class ParticleStatic : MonoBehaviour
{
    private int currentDesviation;
    private int currentDesviationFacing;
    private Vector2 destinationPoint;
    public int fadeOutTime;
    private int fadeOutTimeCounter;
    private bool isActive;
    private bool isPaused;
    private bool isVisible;
    private int maxDesviation;
    private float opacity;
    private float scaleX;
    private float scaleY;
    public int speed;
    private PackedSprite sprite;
    private int waitFramesTime;
    private int waitFramesTimeCounter;
    private float xSpeed;
    private float ySpeed;

    public ParticleStatic()
    {
        this.isActive = 1;
        this.maxDesviation = 5;
        this.opacity = 1f;
        this.scaleX = 1f;
        this.scaleY = 1f;
        base..ctor();
        return;
    }

    private void FadeOut()
    {
        ParticleFade fade;
        base.gameObject.AddComponent<ParticleFade>().fadeSpeed = 0.25f;
        return;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform1;
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isActive != null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        if (this.waitFramesTimeCounter >= this.waitFramesTime)
        {
            goto Label_0038;
        }
        this.waitFramesTimeCounter += 1;
        return;
    Label_0038:
        if (this.isVisible != null)
        {
            goto Label_007C;
        }
        this.scaleX = this.scaleY = UnityEngine.Random.Range(0f, 1f) + 0.5f;
        this.isVisible = 1;
        this.sprite.Hide(0);
    Label_007C:
        num = 0f;
        num2 = 0f;
        num3 = 0f;
        num4 = 0f;
        num = &this.destinationPoint.x - &base.transform.position.x;
        num2 = &this.destinationPoint.y - &base.transform.position.y;
        num4 = (Mathf.Atan2(num2, num) / 3.141593f) * 180f;
        num4 += (float) this.currentDesviation;
        num3 = (num4 / 180f) * 3.141593f;
        this.ySpeed = Mathf.Sin(num3) * ((float) this.speed);
        this.xSpeed = Mathf.Cos(num3) * ((float) this.speed);
        this.currentDesviation += 4;
        if (this.currentDesviation < 0x2d)
        {
            goto Label_0155;
        }
        this.currentDesviation = 2 * this.currentDesviationFacing;
    Label_0155:
        transform1 = base.transform;
        transform1.position += new Vector3(this.xSpeed, this.ySpeed);
        this.scaleX *= 0.97f;
        this.scaleY *= 0.97f;
        base.transform.localScale = new Vector3(this.scaleX, this.scaleY, 1f);
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        float introduced10 = Mathf.Pow(&this.destinationPoint.y - &base.transform.position.y, 2f);
        if (Mathf.Sqrt(introduced10 + Mathf.Pow(&this.destinationPoint.x - &base.transform.position.x, 2f)) >= ((float) (this.speed * 2)))
        {
            goto Label_025B;
        }
        this.isActive = 0;
        this.FadeOut();
    Label_025B:
        return;
    }

    public void Init(Vector2 dest)
    {
        this.currentDesviationFacing = this.SetRandomFacing();
        this.currentDesviation = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f) * 3f) * this.currentDesviationFacing;
        this.destinationPoint = dest;
        this.SetInitPoint();
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.sprite.PauseAnim();
        return;
    }

    public unsafe void SetInitPoint()
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        num = 0f;
        num2 = 0f;
        num3 = (UnityEngine.Random.Range(0f, 1f) * 2f) + 1.5f;
        num = (&this.destinationPoint.x - &base.transform.position.x) / num3;
        num2 = (&this.destinationPoint.y - &base.transform.position.y) / num3;
        num4 = &base.transform.position.x + (Mathf.Sqrt((num * num) + (num2 * num2)) * Mathf.Cos(Mathf.Atan2(num2, num)));
        num5 = &base.transform.position.y + (Mathf.Sqrt((num * num) + (num2 * num2)) * Mathf.Sin(Mathf.Atan2(num2, num)));
        base.transform.position = new Vector3(num4, num5, &base.transform.position.z);
        return;
    }

    private int SetRandomFacing()
    {
        if ((Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * 2f) - 1) != null)
        {
            goto Label_0023;
        }
        return 1;
    Label_0023:
        return -1;
    }

    private void Start()
    {
        this.waitFramesTime = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f) * 15f);
        this.sprite = base.GetComponent<PackedSprite>();
        this.fadeOutTime = 5;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.sprite.UnpauseAnim();
        return;
    }
}

