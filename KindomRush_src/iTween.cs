using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class iTween : MonoBehaviour
{
    public string _name;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap10;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap11;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap12;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap13;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap14;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap15;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap16;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap17;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap18;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap19;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap1A;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap1B;
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap1C;
    private ApplyTween apply;
    private AudioSource audioSource;
    private static GameObject cameraFade;
    private Color[,] colors;
    public float delay;
    private float delayStarted;
    private EasingFunction ease;
    public EaseType easeType;
    private float[] floats;
    public string id;
    private bool isLocal;
    public bool isPaused;
    public bool isRunning;
    private bool kinematic;
    private float lastRealTime;
    private bool loop;
    public LoopType loopType;
    public string method;
    private NamedValueColor namedcolorvalue;
    private CRSpline path;
    private float percentage;
    private bool physics;
    private Vector3 postUpdate;
    private Vector3 preUpdate;
    private Rect[] rects;
    private bool reverse;
    private float runningTime;
    private Space space;
    public float time;
    private Hashtable tweenArguments;
    public static ArrayList tweens;
    public string type;
    private bool useRealTime;
    private Vector2[] vector2s;
    private Vector3[] vector3s;
    private bool wasPaused;

    static iTween()
    {
        tweens = new ArrayList();
        return;
    }

    public iTween()
    {
        base..ctor();
        return;
    }

    private unsafe void ApplyAudioToTargets()
    {
        &(this.vector2s[2]).x = this.ease(&(this.vector2s[0]).x, &(this.vector2s[1]).x, this.percentage);
        &(this.vector2s[2]).y = this.ease(&(this.vector2s[0]).y, &(this.vector2s[1]).y, this.percentage);
        this.audioSource.volume = &(this.vector2s[2]).x;
        this.audioSource.pitch = &(this.vector2s[2]).y;
        if (this.percentage != 1f)
        {
            goto Label_0108;
        }
        this.audioSource.volume = &(this.vector2s[1]).x;
        this.audioSource.pitch = &(this.vector2s[1]).y;
    Label_0108:
        return;
    }

    private void ApplyColorTargets()
    {
        this.colors[0, 2].r = this.ease(this.colors[0, 0].r, this.colors[0, 1].r, this.percentage);
        this.colors[0, 2].g = this.ease(this.colors[0, 0].g, this.colors[0, 1].g, this.percentage);
        this.colors[0, 2].b = this.ease(this.colors[0, 0].b, this.colors[0, 1].b, this.percentage);
        this.colors[0, 2].a = this.ease(this.colors[0, 0].a, this.colors[0, 1].a, this.percentage);
        this.tweenArguments["onupdateparams"] = (Color) this.colors[0, 2];
        if (this.percentage != 1f)
        {
            goto Label_0170;
        }
        this.tweenArguments["onupdateparams"] = (Color) this.colors[0, 1];
    Label_0170:
        return;
    }

    private void ApplyColorToTargets()
    {
        int num;
        int num2;
        int num3;
        num = 0;
        goto Label_0127;
    Label_0007:
        this.colors[num, 2].r = this.ease(this.colors[num, 0].r, this.colors[num, 1].r, this.percentage);
        this.colors[num, 2].g = this.ease(this.colors[num, 0].g, this.colors[num, 1].g, this.percentage);
        this.colors[num, 2].b = this.ease(this.colors[num, 0].b, this.colors[num, 1].b, this.percentage);
        this.colors[num, 2].a = this.ease(this.colors[num, 0].a, this.colors[num, 1].a, this.percentage);
        num += 1;
    Label_0127:
        if (num < this.colors.GetLength(0))
        {
            goto Label_0007;
        }
        if (base.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_0170;
        }
        base.guiTexture.color = this.colors[0, 2];
        goto Label_0235;
    Label_0170:
        if (base.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_01AC;
        }
        base.guiText.material.color = this.colors[0, 2];
        goto Label_0235;
    Label_01AC:
        if (base.renderer == null)
        {
            goto Label_020D;
        }
        num2 = 0;
        goto Label_01F6;
    Label_01C3:
        base.renderer.materials[num2].SetColor(((NamedValueColor) this.namedcolorvalue).ToString(), this.colors[num2, 2]);
        num2 += 1;
    Label_01F6:
        if (num2 < this.colors.GetLength(0))
        {
            goto Label_01C3;
        }
        goto Label_0235;
    Label_020D:
        if (base.light == null)
        {
            goto Label_0235;
        }
        base.light.color = this.colors[0, 2];
    Label_0235:
        if (this.percentage != 1f)
        {
            goto Label_0341;
        }
        if (base.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_027C;
        }
        base.guiTexture.color = this.colors[0, 1];
        goto Label_0341;
    Label_027C:
        if (base.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_02B8;
        }
        base.guiText.material.color = this.colors[0, 1];
        goto Label_0341;
    Label_02B8:
        if (base.renderer == null)
        {
            goto Label_0319;
        }
        num3 = 0;
        goto Label_0302;
    Label_02CF:
        base.renderer.materials[num3].SetColor(((NamedValueColor) this.namedcolorvalue).ToString(), this.colors[num3, 1]);
        num3 += 1;
    Label_0302:
        if (num3 < this.colors.GetLength(0))
        {
            goto Label_02CF;
        }
        goto Label_0341;
    Label_0319:
        if (base.light == null)
        {
            goto Label_0341;
        }
        base.light.color = this.colors[0, 1];
    Label_0341:
        return;
    }

    private void ApplyFloatTargets()
    {
        this.floats[2] = this.ease(this.floats[0], this.floats[1], this.percentage);
        this.tweenArguments["onupdateparams"] = (float) this.floats[2];
        if (this.percentage != 1f)
        {
            goto Label_0073;
        }
        this.tweenArguments["onupdateparams"] = (float) this.floats[1];
    Label_0073:
        return;
    }

    private unsafe void ApplyLookToTargets()
    {
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        if (this.isLocal == null)
        {
            goto Label_00FD;
        }
        base.transform.localRotation = Quaternion.Euler(*(&(this.vector3s[2])));
        goto Label_011E;
    Label_00FD:
        base.transform.rotation = Quaternion.Euler(*(&(this.vector3s[2])));
    Label_011E:
        return;
    }

    private unsafe void ApplyMoveByTargets()
    {
        Vector3 vector;
        this.preUpdate = base.transform.position;
        vector = new Vector3();
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_0056;
        }
        vector = base.transform.eulerAngles;
        base.transform.eulerAngles = *(&(this.vector3s[4]));
    Label_0056:
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        base.transform.Translate(*(&(this.vector3s[2])) - *(&(this.vector3s[3])), this.space);
        *(&(this.vector3s[3])) = *(&(this.vector3s[2]));
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_019D;
        }
        base.transform.eulerAngles = vector;
    Label_019D:
        this.postUpdate = base.transform.position;
        if (this.physics == null)
        {
            goto Label_01DB;
        }
        base.transform.position = this.preUpdate;
        base.rigidbody.MovePosition(this.postUpdate);
    Label_01DB:
        return;
    }

    private void ApplyMoveToPathTargets()
    {
        float num;
        float num2;
        float num3;
        this.preUpdate = base.transform.position;
        num = this.ease(0f, 1f, this.percentage);
        if (this.isLocal == null)
        {
            goto Label_0063;
        }
        base.transform.localPosition = this.path.Interp(Mathf.Clamp(num, 0f, 1f));
        goto Label_0089;
    Label_0063:
        base.transform.position = this.path.Interp(Mathf.Clamp(num, 0f, 1f));
    Label_0089:
        if (this.tweenArguments.Contains("orienttopath") == null)
        {
            goto Label_0146;
        }
        if (((bool) this.tweenArguments["orienttopath"]) == null)
        {
            goto Label_0146;
        }
        if (this.tweenArguments.Contains("lookahead") == null)
        {
            goto Label_00E8;
        }
        num2 = (float) this.tweenArguments["lookahead"];
        goto Label_00EE;
    Label_00E8:
        num2 = Defaults.lookAhead;
    Label_00EE:
        num3 = this.ease(0f, 1f, Mathf.Min(1f, this.percentage + num2));
        this.tweenArguments["looktarget"] = (Vector3) this.path.Interp(Mathf.Clamp(num3, 0f, 1f));
    Label_0146:
        this.postUpdate = base.transform.position;
        if (this.physics == null)
        {
            goto Label_0184;
        }
        base.transform.position = this.preUpdate;
        base.rigidbody.MovePosition(this.postUpdate);
    Label_0184:
        return;
    }

    private unsafe void ApplyMoveToTargets()
    {
        this.preUpdate = base.transform.position;
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        if (this.isLocal == null)
        {
            goto Label_0109;
        }
        base.transform.localPosition = *(&(this.vector3s[2]));
        goto Label_0125;
    Label_0109:
        base.transform.position = *(&(this.vector3s[2]));
    Label_0125:
        if (this.percentage != 1f)
        {
            goto Label_017D;
        }
        if (this.isLocal == null)
        {
            goto Label_0161;
        }
        base.transform.localPosition = *(&(this.vector3s[1]));
        goto Label_017D;
    Label_0161:
        base.transform.position = *(&(this.vector3s[1]));
    Label_017D:
        this.postUpdate = base.transform.position;
        if (this.physics == null)
        {
            goto Label_01BB;
        }
        base.transform.position = this.preUpdate;
        base.rigidbody.MovePosition(this.postUpdate);
    Label_01BB:
        return;
    }

    private unsafe void ApplyPunchPositionTargets()
    {
        Vector3 vector;
        this.preUpdate = base.transform.position;
        vector = new Vector3();
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_0056;
        }
        vector = base.transform.eulerAngles;
        base.transform.eulerAngles = *(&(this.vector3s[4]));
    Label_0056:
        if (&(this.vector3s[1]).x <= 0f)
        {
            goto Label_00A4;
        }
        &(this.vector3s[2]).x = this.punch(&(this.vector3s[1]).x, this.percentage);
        goto Label_00F3;
    Label_00A4:
        if (&(this.vector3s[1]).x >= 0f)
        {
            goto Label_00F3;
        }
        &(this.vector3s[2]).x = -this.punch(Mathf.Abs(&(this.vector3s[1]).x), this.percentage);
    Label_00F3:
        if (&(this.vector3s[1]).y <= 0f)
        {
            goto Label_0141;
        }
        &(this.vector3s[2]).y = this.punch(&(this.vector3s[1]).y, this.percentage);
        goto Label_0190;
    Label_0141:
        if (&(this.vector3s[1]).y >= 0f)
        {
            goto Label_0190;
        }
        &(this.vector3s[2]).y = -this.punch(Mathf.Abs(&(this.vector3s[1]).y), this.percentage);
    Label_0190:
        if (&(this.vector3s[1]).z <= 0f)
        {
            goto Label_01DE;
        }
        &(this.vector3s[2]).z = this.punch(&(this.vector3s[1]).z, this.percentage);
        goto Label_022D;
    Label_01DE:
        if (&(this.vector3s[1]).z >= 0f)
        {
            goto Label_022D;
        }
        &(this.vector3s[2]).z = -this.punch(Mathf.Abs(&(this.vector3s[1]).z), this.percentage);
    Label_022D:
        base.transform.Translate(*(&(this.vector3s[2])) - *(&(this.vector3s[3])), this.space);
        *(&(this.vector3s[3])) = *(&(this.vector3s[2]));
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_02A8;
        }
        base.transform.eulerAngles = vector;
    Label_02A8:
        this.postUpdate = base.transform.position;
        if (this.physics == null)
        {
            goto Label_02E6;
        }
        base.transform.position = this.preUpdate;
        base.rigidbody.MovePosition(this.postUpdate);
    Label_02E6:
        return;
    }

    private unsafe void ApplyPunchRotationTargets()
    {
        this.preUpdate = base.transform.eulerAngles;
        if (&(this.vector3s[1]).x <= 0f)
        {
            goto Label_005F;
        }
        &(this.vector3s[2]).x = this.punch(&(this.vector3s[1]).x, this.percentage);
        goto Label_00AE;
    Label_005F:
        if (&(this.vector3s[1]).x >= 0f)
        {
            goto Label_00AE;
        }
        &(this.vector3s[2]).x = -this.punch(Mathf.Abs(&(this.vector3s[1]).x), this.percentage);
    Label_00AE:
        if (&(this.vector3s[1]).y <= 0f)
        {
            goto Label_00FC;
        }
        &(this.vector3s[2]).y = this.punch(&(this.vector3s[1]).y, this.percentage);
        goto Label_014B;
    Label_00FC:
        if (&(this.vector3s[1]).y >= 0f)
        {
            goto Label_014B;
        }
        &(this.vector3s[2]).y = -this.punch(Mathf.Abs(&(this.vector3s[1]).y), this.percentage);
    Label_014B:
        if (&(this.vector3s[1]).z <= 0f)
        {
            goto Label_0199;
        }
        &(this.vector3s[2]).z = this.punch(&(this.vector3s[1]).z, this.percentage);
        goto Label_01E8;
    Label_0199:
        if (&(this.vector3s[1]).z >= 0f)
        {
            goto Label_01E8;
        }
        &(this.vector3s[2]).z = -this.punch(Mathf.Abs(&(this.vector3s[1]).z), this.percentage);
    Label_01E8:
        base.transform.Rotate(*(&(this.vector3s[2])) - *(&(this.vector3s[3])), this.space);
        *(&(this.vector3s[3])) = *(&(this.vector3s[2]));
        this.postUpdate = base.transform.eulerAngles;
        if (this.physics == null)
        {
            goto Label_0285;
        }
        base.transform.eulerAngles = this.preUpdate;
        base.rigidbody.MoveRotation(Quaternion.Euler(this.postUpdate));
    Label_0285:
        return;
    }

    private unsafe void ApplyPunchScaleTargets()
    {
        if (&(this.vector3s[1]).x <= 0f)
        {
            goto Label_004E;
        }
        &(this.vector3s[2]).x = this.punch(&(this.vector3s[1]).x, this.percentage);
        goto Label_009D;
    Label_004E:
        if (&(this.vector3s[1]).x >= 0f)
        {
            goto Label_009D;
        }
        &(this.vector3s[2]).x = -this.punch(Mathf.Abs(&(this.vector3s[1]).x), this.percentage);
    Label_009D:
        if (&(this.vector3s[1]).y <= 0f)
        {
            goto Label_00EB;
        }
        &(this.vector3s[2]).y = this.punch(&(this.vector3s[1]).y, this.percentage);
        goto Label_013A;
    Label_00EB:
        if (&(this.vector3s[1]).y >= 0f)
        {
            goto Label_013A;
        }
        &(this.vector3s[2]).y = -this.punch(Mathf.Abs(&(this.vector3s[1]).y), this.percentage);
    Label_013A:
        if (&(this.vector3s[1]).z <= 0f)
        {
            goto Label_0188;
        }
        &(this.vector3s[2]).z = this.punch(&(this.vector3s[1]).z, this.percentage);
        goto Label_01D7;
    Label_0188:
        if (&(this.vector3s[1]).z >= 0f)
        {
            goto Label_01D7;
        }
        &(this.vector3s[2]).z = -this.punch(Mathf.Abs(&(this.vector3s[1]).z), this.percentage);
    Label_01D7:
        base.transform.localScale = *(&(this.vector3s[0])) + *(&(this.vector3s[2]));
        return;
    }

    private unsafe void ApplyRectTargets()
    {
        &(this.rects[2]).x = this.ease(&(this.rects[0]).x, &(this.rects[1]).x, this.percentage);
        &(this.rects[2]).y = this.ease(&(this.rects[0]).y, &(this.rects[1]).y, this.percentage);
        &(this.rects[2]).width = this.ease(&(this.rects[0]).width, &(this.rects[1]).width, this.percentage);
        &(this.rects[2]).height = this.ease(&(this.rects[0]).height, &(this.rects[1]).height, this.percentage);
        this.tweenArguments["onupdateparams"] = (Rect) *(&(this.rects[2]));
        if (this.percentage != 1f)
        {
            goto Label_016C;
        }
        this.tweenArguments["onupdateparams"] = (Rect) *(&(this.rects[1]));
    Label_016C:
        return;
    }

    private unsafe void ApplyRotateAddTargets()
    {
        this.preUpdate = base.transform.eulerAngles;
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        base.transform.Rotate(*(&(this.vector3s[2])) - *(&(this.vector3s[3])), this.space);
        *(&(this.vector3s[3])) = *(&(this.vector3s[2]));
        this.postUpdate = base.transform.eulerAngles;
        if (this.physics == null)
        {
            goto Label_017A;
        }
        base.transform.eulerAngles = this.preUpdate;
        base.rigidbody.MoveRotation(Quaternion.Euler(this.postUpdate));
    Label_017A:
        return;
    }

    private unsafe void ApplyRotateToTargets()
    {
        this.preUpdate = base.transform.eulerAngles;
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        if (this.isLocal == null)
        {
            goto Label_010E;
        }
        base.transform.localRotation = Quaternion.Euler(*(&(this.vector3s[2])));
        goto Label_012F;
    Label_010E:
        base.transform.rotation = Quaternion.Euler(*(&(this.vector3s[2])));
    Label_012F:
        if (this.percentage != 1f)
        {
            goto Label_0191;
        }
        if (this.isLocal == null)
        {
            goto Label_0170;
        }
        base.transform.localRotation = Quaternion.Euler(*(&(this.vector3s[1])));
        goto Label_0191;
    Label_0170:
        base.transform.rotation = Quaternion.Euler(*(&(this.vector3s[1])));
    Label_0191:
        this.postUpdate = base.transform.eulerAngles;
        if (this.physics == null)
        {
            goto Label_01D4;
        }
        base.transform.eulerAngles = this.preUpdate;
        base.rigidbody.MoveRotation(Quaternion.Euler(this.postUpdate));
    Label_01D4:
        return;
    }

    private unsafe void ApplyScaleToTargets()
    {
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        base.transform.localScale = *(&(this.vector3s[2]));
        if (this.percentage != 1f)
        {
            goto Label_0114;
        }
        base.transform.localScale = *(&(this.vector3s[1]));
    Label_0114:
        return;
    }

    private unsafe void ApplyShakePositionTargets()
    {
        Transform transform2;
        Transform transform1;
        Vector3 vector;
        float num;
        if (this.isLocal == null)
        {
            goto Label_0021;
        }
        this.preUpdate = base.transform.localPosition;
        goto Label_0032;
    Label_0021:
        this.preUpdate = base.transform.position;
    Label_0032:
        vector = new Vector3();
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_0077;
        }
        vector = base.transform.eulerAngles;
        base.transform.eulerAngles = *(&(this.vector3s[3]));
    Label_0077:
        if (this.percentage != 0f)
        {
            goto Label_00A9;
        }
        base.transform.Translate(*(&(this.vector3s[1])), this.space);
    Label_00A9:
        if (this.isLocal == null)
        {
            goto Label_00D5;
        }
        base.transform.localPosition = *(&(this.vector3s[0]));
        goto Label_00F1;
    Label_00D5:
        base.transform.position = *(&(this.vector3s[0]));
    Label_00F1:
        num = 1f - this.percentage;
        &(this.vector3s[2]).x = UnityEngine.Random.Range(-&(this.vector3s[1]).x * num, &(this.vector3s[1]).x * num);
        &(this.vector3s[2]).y = UnityEngine.Random.Range(-&(this.vector3s[1]).y * num, &(this.vector3s[1]).y * num);
        &(this.vector3s[2]).z = UnityEngine.Random.Range(-&(this.vector3s[1]).z * num, &(this.vector3s[1]).z * num);
        if (this.isLocal == null)
        {
            goto Label_01EC;
        }
        transform1 = base.transform;
        transform1.localPosition += *(&(this.vector3s[2]));
        goto Label_0213;
    Label_01EC:
        transform2 = base.transform;
        transform2.position += *(&(this.vector3s[2]));
    Label_0213:
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_0234;
        }
        base.transform.eulerAngles = vector;
    Label_0234:
        this.postUpdate = base.transform.position;
        if (this.physics == null)
        {
            goto Label_0272;
        }
        base.transform.position = this.preUpdate;
        base.rigidbody.MovePosition(this.postUpdate);
    Label_0272:
        return;
    }

    private unsafe void ApplyShakeRotationTargets()
    {
        float num;
        this.preUpdate = base.transform.eulerAngles;
        if (this.percentage != 0f)
        {
            goto Label_0043;
        }
        base.transform.Rotate(*(&(this.vector3s[1])), this.space);
    Label_0043:
        base.transform.eulerAngles = *(&(this.vector3s[0]));
        num = 1f - this.percentage;
        &(this.vector3s[2]).x = UnityEngine.Random.Range(-&(this.vector3s[1]).x * num, &(this.vector3s[1]).x * num);
        &(this.vector3s[2]).y = UnityEngine.Random.Range(-&(this.vector3s[1]).y * num, &(this.vector3s[1]).y * num);
        &(this.vector3s[2]).z = UnityEngine.Random.Range(-&(this.vector3s[1]).z * num, &(this.vector3s[1]).z * num);
        base.transform.Rotate(*(&(this.vector3s[2])), this.space);
        this.postUpdate = base.transform.eulerAngles;
        if (this.physics == null)
        {
            goto Label_0188;
        }
        base.transform.eulerAngles = this.preUpdate;
        base.rigidbody.MoveRotation(Quaternion.Euler(this.postUpdate));
    Label_0188:
        return;
    }

    private unsafe void ApplyShakeScaleTargets()
    {
        Transform transform1;
        float num;
        if (this.percentage != 0f)
        {
            goto Label_002C;
        }
        base.transform.localScale = *(&(this.vector3s[1]));
    Label_002C:
        base.transform.localScale = *(&(this.vector3s[0]));
        num = 1f - this.percentage;
        &(this.vector3s[2]).x = UnityEngine.Random.Range(-&(this.vector3s[1]).x * num, &(this.vector3s[1]).x * num);
        &(this.vector3s[2]).y = UnityEngine.Random.Range(-&(this.vector3s[1]).y * num, &(this.vector3s[1]).y * num);
        &(this.vector3s[2]).z = UnityEngine.Random.Range(-&(this.vector3s[1]).z * num, &(this.vector3s[1]).z * num);
        transform1 = base.transform;
        transform1.localScale += *(&(this.vector3s[2]));
        return;
    }

    private void ApplyStabTargets()
    {
    }

    private unsafe void ApplyVector2Targets()
    {
        &(this.vector2s[2]).x = this.ease(&(this.vector2s[0]).x, &(this.vector2s[1]).x, this.percentage);
        &(this.vector2s[2]).y = this.ease(&(this.vector2s[0]).y, &(this.vector2s[1]).y, this.percentage);
        this.tweenArguments["onupdateparams"] = (Vector2) *(&(this.vector2s[2]));
        if (this.percentage != 1f)
        {
            goto Label_00E4;
        }
        this.tweenArguments["onupdateparams"] = (Vector2) *(&(this.vector2s[1]));
    Label_00E4:
        return;
    }

    private unsafe void ApplyVector3Targets()
    {
        &(this.vector3s[2]).x = this.ease(&(this.vector3s[0]).x, &(this.vector3s[1]).x, this.percentage);
        &(this.vector3s[2]).y = this.ease(&(this.vector3s[0]).y, &(this.vector3s[1]).y, this.percentage);
        &(this.vector3s[2]).z = this.ease(&(this.vector3s[0]).z, &(this.vector3s[1]).z, this.percentage);
        this.tweenArguments["onupdateparams"] = (Vector3) *(&(this.vector3s[2]));
        if (this.percentage != 1f)
        {
            goto Label_0128;
        }
        this.tweenArguments["onupdateparams"] = (Vector3) *(&(this.vector3s[1]));
    Label_0128:
        return;
    }

    public static unsafe void AudioFrom(GameObject target, Hashtable args)
    {
        Vector2 vector;
        Vector2 vector2;
        AudioSource source;
        float num;
        args = CleanArgs(args);
        if (args.Contains("audiosource") == null)
        {
            goto Label_002E;
        }
        source = (AudioSource) args["audiosource"];
        goto Label_005F;
    Label_002E:
        if (target.GetComponent(typeof(AudioSource)) == null)
        {
            goto Label_0054;
        }
        source = target.audio;
        goto Label_005F;
    Label_0054:
        Debug.LogError("iTween Error: AudioFrom requires an AudioSource.");
        return;
    Label_005F:
        &vector.x = &vector2.x = source.volume;
        &vector.y = &vector2.y = source.pitch;
        if (args.Contains("volume") == null)
        {
            goto Label_00B4;
        }
        &vector2.x = (float) args["volume"];
    Label_00B4:
        if (args.Contains("pitch") == null)
        {
            goto Label_00DB;
        }
        &vector2.y = (float) args["pitch"];
    Label_00DB:
        source.volume = &vector2.x;
        source.pitch = &vector2.y;
        args["volume"] = (float) &vector.x;
        args["pitch"] = (float) &vector.y;
        if (args.Contains("easetype") != null)
        {
            goto Label_0145;
        }
        args.Add("easetype", (EaseType) 0x15);
    Label_0145:
        args["type"] = "audio";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void AudioFrom(GameObject target, float volume, float pitch, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "volume", (float) volume, "pitch", (float) pitch, "time", (float) time };
        AudioFrom(target, Hash(objArray1));
        return;
    }

    public static void AudioTo(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        if (args.Contains("easetype") != null)
        {
            goto Label_002A;
        }
        args.Add("easetype", (EaseType) 0x15);
    Label_002A:
        args["type"] = "audio";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void AudioTo(GameObject target, float volume, float pitch, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "volume", (float) volume, "pitch", (float) pitch, "time", (float) time };
        AudioTo(target, Hash(objArray1));
        return;
    }

    public static unsafe void AudioUpdate(GameObject target, Hashtable args)
    {
        AudioSource source;
        float num;
        Vector2[] vectorArray;
        Vector2 vector;
        CleanArgs(args);
        vectorArray = new Vector2[4];
        if (args.Contains("time") == null)
        {
            goto Label_003C;
        }
        num = (float) args["time"];
        num *= Defaults.updateTimePercentage;
        goto Label_0042;
    Label_003C:
        num = Defaults.updateTime;
    Label_0042:
        if (args.Contains("audiosource") == null)
        {
            goto Label_0068;
        }
        source = (AudioSource) args["audiosource"];
        goto Label_0099;
    Label_0068:
        if (target.GetComponent(typeof(AudioSource)) == null)
        {
            goto Label_008E;
        }
        source = target.audio;
        goto Label_0099;
    Label_008E:
        Debug.LogError("iTween Error: AudioUpdate requires an AudioSource.");
        return;
    Label_0099:
        *(&(vectorArray[1])) = vector = new Vector2(source.volume, source.pitch);
        *(&(vectorArray[0])) = vector;
        if (args.Contains("volume") == null)
        {
            goto Label_00F1;
        }
        &(vectorArray[1]).x = (float) args["volume"];
    Label_00F1:
        if (args.Contains("pitch") == null)
        {
            goto Label_011D;
        }
        &(vectorArray[1]).y = (float) args["pitch"];
    Label_011D:
        &(vectorArray[3]).x = Mathf.SmoothDampAngle(&(vectorArray[0]).x, &(vectorArray[1]).x, &&(vectorArray[2]).x, num);
        &(vectorArray[3]).y = Mathf.SmoothDampAngle(&(vectorArray[0]).y, &(vectorArray[1]).y, &&(vectorArray[2]).y, num);
        source.volume = &(vectorArray[3]).x;
        source.pitch = &(vectorArray[3]).y;
        return;
    }

    public static void AudioUpdate(GameObject target, float volume, float pitch, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "volume", (float) volume, "pitch", (float) pitch, "time", (float) time };
        AudioUpdate(target, Hash(objArray1));
        return;
    }

    private void Awake()
    {
        this.RetrieveArgs();
        this.lastRealTime = Time.realtimeSinceStartup;
        return;
    }

    private void CallBack(string callbackType)
    {
        GameObject obj2;
        if (this.tweenArguments.Contains(callbackType) == null)
        {
            goto Label_00CC;
        }
        if (this.tweenArguments.Contains("ischild") != null)
        {
            goto Label_00CC;
        }
        if (this.tweenArguments.Contains(callbackType + "target") == null)
        {
            goto Label_0062;
        }
        obj2 = (GameObject) this.tweenArguments[callbackType + "target"];
        goto Label_0069;
    Label_0062:
        obj2 = base.gameObject;
    Label_0069:
        if (this.tweenArguments[callbackType].GetType() != typeof(string))
        {
            goto Label_00BC;
        }
        obj2.SendMessage((string) this.tweenArguments[callbackType], this.tweenArguments[callbackType + "params"], 1);
        goto Label_00CC;
    Label_00BC:
        Debug.LogError("iTween Error: Callback method references must be passed as a String!");
        UnityEngine.Object.Destroy(this);
    Label_00CC:
        return;
    }

    public static GameObject CameraFadeAdd()
    {
        if (cameraFade == null)
        {
            goto Label_0011;
        }
        return null;
    Label_0011:
        cameraFade = new GameObject("iTween Camera Fade");
        cameraFade.transform.position = new Vector3(0.5f, 0.5f, (float) Defaults.cameraFadeDepth);
        cameraFade.AddComponent("GUITexture");
        cameraFade.guiTexture.texture = CameraTexture(Color.black);
        cameraFade.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0f);
        return cameraFade;
    }

    public static GameObject CameraFadeAdd(Texture2D texture)
    {
        if (cameraFade == null)
        {
            goto Label_0011;
        }
        return null;
    Label_0011:
        cameraFade = new GameObject("iTween Camera Fade");
        cameraFade.transform.position = new Vector3(0.5f, 0.5f, (float) Defaults.cameraFadeDepth);
        cameraFade.AddComponent("GUITexture");
        cameraFade.guiTexture.texture = texture;
        cameraFade.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0f);
        return cameraFade;
    }

    public static GameObject CameraFadeAdd(Texture2D texture, int depth)
    {
        if (cameraFade == null)
        {
            goto Label_0011;
        }
        return null;
    Label_0011:
        cameraFade = new GameObject("iTween Camera Fade");
        cameraFade.transform.position = new Vector3(0.5f, 0.5f, (float) depth);
        cameraFade.AddComponent("GUITexture");
        cameraFade.guiTexture.texture = texture;
        cameraFade.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0f);
        return cameraFade;
    }

    public static unsafe void CameraFadeDepth(int depth)
    {
        Vector3 vector;
        Vector3 vector2;
        if (cameraFade == null)
        {
            goto Label_0053;
        }
        cameraFade.transform.position = new Vector3(&cameraFade.transform.position.x, &cameraFade.transform.position.y, (float) depth);
    Label_0053:
        return;
    }

    public static void CameraFadeDestroy()
    {
        if (cameraFade == null)
        {
            goto Label_0019;
        }
        UnityEngine.Object.Destroy(cameraFade);
    Label_0019:
        return;
    }

    public static void CameraFadeFrom(Hashtable args)
    {
        if (cameraFade == null)
        {
            goto Label_001F;
        }
        ColorFrom(cameraFade, args);
        goto Label_0029;
    Label_001F:
        Debug.LogError("iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
    Label_0029:
        return;
    }

    public static void CameraFadeFrom(float amount, float time)
    {
        object[] objArray1;
        if (cameraFade == null)
        {
            goto Label_0046;
        }
        objArray1 = new object[] { "amount", (float) amount, "time", (float) time };
        CameraFadeFrom(Hash(objArray1));
        goto Label_0050;
    Label_0046:
        Debug.LogError("iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
    Label_0050:
        return;
    }

    public static void CameraFadeSwap(Texture2D texture)
    {
        if (cameraFade == null)
        {
            goto Label_001F;
        }
        cameraFade.guiTexture.texture = texture;
    Label_001F:
        return;
    }

    public static void CameraFadeTo(Hashtable args)
    {
        if (cameraFade == null)
        {
            goto Label_001F;
        }
        ColorTo(cameraFade, args);
        goto Label_0029;
    Label_001F:
        Debug.LogError("iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
    Label_0029:
        return;
    }

    public static void CameraFadeTo(float amount, float time)
    {
        object[] objArray1;
        if (cameraFade == null)
        {
            goto Label_0046;
        }
        objArray1 = new object[] { "amount", (float) amount, "time", (float) time };
        CameraFadeTo(Hash(objArray1));
        goto Label_0050;
    Label_0046:
        Debug.LogError("iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
    Label_0050:
        return;
    }

    public static unsafe Texture2D CameraTexture(Color color)
    {
        Texture2D textured;
        Color[] colorArray;
        int num;
        textured = new Texture2D(Screen.width, Screen.height, 5, 0);
        colorArray = new Color[Screen.width * Screen.height];
        num = 0;
        goto Label_003B;
    Label_002A:
        *(&(colorArray[num])) = color;
        num += 1;
    Label_003B:
        if (num < ((int) colorArray.Length))
        {
            goto Label_002A;
        }
        textured.SetPixels(colorArray);
        textured.Apply();
        return textured;
    }

    private static unsafe Hashtable CleanArgs(Hashtable args)
    {
        Hashtable hashtable;
        Hashtable hashtable2;
        DictionaryEntry entry;
        IDictionaryEnumerator enumerator;
        DictionaryEntry entry2;
        IDictionaryEnumerator enumerator2;
        int num;
        float num2;
        double num3;
        float num4;
        DictionaryEntry entry3;
        IDictionaryEnumerator enumerator3;
        IDisposable disposable;
        IDisposable disposable2;
        IDisposable disposable3;
        hashtable = new Hashtable(args.Count);
        hashtable2 = new Hashtable(args.Count);
        enumerator = args.GetEnumerator();
    Label_001F:
        try
        {
            goto Label_0044;
        Label_0024:
            entry = (DictionaryEntry) enumerator.Current;
            hashtable.Add(&entry.Key, &entry.Value);
        Label_0044:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
            }
            goto Label_0069;
        }
        finally
        {
        Label_0054:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0061;
            }
        Label_0061:
            disposable.Dispose();
        }
    Label_0069:
        enumerator2 = hashtable.GetEnumerator();
    Label_0071:
        try
        {
            goto Label_0108;
        Label_0076:
            entry2 = (DictionaryEntry) enumerator2.Current;
            if (&entry2.Value.GetType() != typeof(int))
            {
                goto Label_00C6;
            }
            num = (int) &entry2.Value;
            num2 = (float) num;
            args[&entry2.Key] = (float) num2;
        Label_00C6:
            if (&entry2.Value.GetType() != typeof(double))
            {
                goto Label_0108;
            }
            num3 = (double) &entry2.Value;
            num4 = (float) num3;
            args[&entry2.Key] = (float) num4;
        Label_0108:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_0076;
            }
            goto Label_012F;
        }
        finally
        {
        Label_0119:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_0127;
            }
        Label_0127:
            disposable2.Dispose();
        }
    Label_012F:
        enumerator3 = args.GetEnumerator();
    Label_0137:
        try
        {
            goto Label_0168;
        Label_013C:
            entry3 = (DictionaryEntry) enumerator3.Current;
            string introduced15 = &entry3.Key.ToString().ToLower();
            hashtable2.Add(introduced15, &entry3.Value);
        Label_0168:
            if (enumerator3.MoveNext() != null)
            {
                goto Label_013C;
            }
            goto Label_018F;
        }
        finally
        {
        Label_0179:
            disposable3 = enumerator3 as IDisposable;
            if (disposable3 != null)
            {
                goto Label_0187;
            }
        Label_0187:
            disposable3.Dispose();
        }
    Label_018F:
        args = hashtable2;
        return args;
    }

    private float clerp(float start, float end, float value)
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        num = 0f;
        num2 = 360f;
        num3 = Mathf.Abs((num2 - num) / 2f);
        num4 = 0f;
        num5 = 0f;
        if ((end - start) >= -num3)
        {
            goto Label_0045;
        }
        num5 = ((num2 - start) + end) * value;
        num4 = start + num5;
        goto Label_006A;
    Label_0045:
        if ((end - start) <= num3)
        {
            goto Label_0062;
        }
        num5 = -((num2 - end) + start) * value;
        num4 = start + num5;
        goto Label_006A;
    Label_0062:
        num4 = start + ((end - start) * value);
    Label_006A:
        return num4;
    }

    public static unsafe void ColorFrom(GameObject target, Hashtable args)
    {
        Color color;
        Color color2;
        Transform transform;
        IEnumerator enumerator;
        Hashtable hashtable;
        IDisposable disposable;
        color = new Color();
        color2 = new Color();
        args = CleanArgs(args);
        if (args.Contains("includechildren") == null)
        {
            goto Label_003D;
        }
        if (((bool) args["includechildren"]) == null)
        {
            goto Label_00AB;
        }
    Label_003D:
        enumerator = target.transform.GetEnumerator();
    Label_0049:
        try
        {
            goto Label_0086;
        Label_004E:
            transform = (Transform) enumerator.Current;
            hashtable = (Hashtable) args.Clone();
            hashtable["ischild"] = (bool) 1;
            ColorFrom(transform.gameObject, hashtable);
        Label_0086:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004E;
            }
            goto Label_00AB;
        }
        finally
        {
        Label_0096:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A3;
            }
        Label_00A3:
            disposable.Dispose();
        }
    Label_00AB:
        if (args.Contains("easetype") != null)
        {
            goto Label_00CD;
        }
        args.Add("easetype", (EaseType) 0x15);
    Label_00CD:
        if (target.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_00FA;
        }
        color2 = color = target.guiTexture.color;
        goto Label_0172;
    Label_00FA:
        if (target.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_012C;
        }
        color2 = color = target.guiText.material.color;
        goto Label_0172;
    Label_012C:
        if (target.renderer == null)
        {
            goto Label_0154;
        }
        color2 = color = target.renderer.material.color;
        goto Label_0172;
    Label_0154:
        if (target.light == null)
        {
            goto Label_0172;
        }
        color2 = color = target.light.color;
    Label_0172:
        if (args.Contains("color") == null)
        {
            goto Label_0198;
        }
        color = (Color) args["color"];
        goto Label_0234;
    Label_0198:
        if (args.Contains("r") == null)
        {
            goto Label_01BF;
        }
        &color.r = (float) args["r"];
    Label_01BF:
        if (args.Contains("g") == null)
        {
            goto Label_01E6;
        }
        &color.g = (float) args["g"];
    Label_01E6:
        if (args.Contains("b") == null)
        {
            goto Label_020D;
        }
        &color.b = (float) args["b"];
    Label_020D:
        if (args.Contains("a") == null)
        {
            goto Label_0234;
        }
        &color.a = (float) args["a"];
    Label_0234:
        if (args.Contains("amount") == null)
        {
            goto Label_026B;
        }
        &color.a = (float) args["amount"];
        args.Remove("amount");
        goto Label_029D;
    Label_026B:
        if (args.Contains("alpha") == null)
        {
            goto Label_029D;
        }
        &color.a = (float) args["alpha"];
        args.Remove("alpha");
    Label_029D:
        if (target.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_02C8;
        }
        target.guiTexture.color = color;
        goto Label_033A;
    Label_02C8:
        if (target.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_02F8;
        }
        target.guiText.material.color = color;
        goto Label_033A;
    Label_02F8:
        if (target.renderer == null)
        {
            goto Label_031E;
        }
        target.renderer.material.color = color;
        goto Label_033A;
    Label_031E:
        if (target.light == null)
        {
            goto Label_033A;
        }
        target.light.color = color;
    Label_033A:
        args["color"] = (Color) color2;
        args["type"] = "color";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void ColorFrom(GameObject target, Color color, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "color", (Color) color, "time", (float) time };
        ColorFrom(target, Hash(objArray1));
        return;
    }

    public static void ColorTo(GameObject target, Hashtable args)
    {
        Transform transform;
        IEnumerator enumerator;
        Hashtable hashtable;
        IDisposable disposable;
        args = CleanArgs(args);
        if (args.Contains("includechildren") == null)
        {
            goto Label_002D;
        }
        if (((bool) args["includechildren"]) == null)
        {
            goto Label_0095;
        }
    Label_002D:
        enumerator = target.transform.GetEnumerator();
    Label_0039:
        try
        {
            goto Label_0073;
        Label_003E:
            transform = (Transform) enumerator.Current;
            hashtable = (Hashtable) args.Clone();
            hashtable["ischild"] = (bool) 1;
            ColorTo(transform.gameObject, hashtable);
        Label_0073:
            if (enumerator.MoveNext() != null)
            {
                goto Label_003E;
            }
            goto Label_0095;
        }
        finally
        {
        Label_0083:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_008E;
            }
        Label_008E:
            disposable.Dispose();
        }
    Label_0095:
        if (args.Contains("easetype") != null)
        {
            goto Label_00B7;
        }
        args.Add("easetype", (EaseType) 0x15);
    Label_00B7:
        args["type"] = "color";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void ColorTo(GameObject target, Color color, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "color", (Color) color, "time", (float) time };
        ColorTo(target, Hash(objArray1));
        return;
    }

    public static unsafe void ColorUpdate(GameObject target, Hashtable args)
    {
        float num;
        Color[] colorArray;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        Color color;
        CleanArgs(args);
        colorArray = new Color[4];
        if (args.Contains("includechildren") == null)
        {
            goto Label_0033;
        }
        if (((bool) args["includechildren"]) == null)
        {
            goto Label_0081;
        }
    Label_0033:
        enumerator = target.transform.GetEnumerator();
    Label_003F:
        try
        {
            goto Label_005C;
        Label_0044:
            transform = (Transform) enumerator.Current;
            ColorUpdate(transform.gameObject, args);
        Label_005C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0044;
            }
            goto Label_0081;
        }
        finally
        {
        Label_006C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0079;
            }
        Label_0079:
            disposable.Dispose();
        }
    Label_0081:
        if (args.Contains("time") == null)
        {
            goto Label_00AF;
        }
        num = (float) args["time"];
        num *= Defaults.updateTimePercentage;
        goto Label_00B5;
    Label_00AF:
        num = Defaults.updateTime;
    Label_00B5:
        if (target.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_00FC;
        }
        *(&(colorArray[1])) = color = target.guiTexture.color;
        *(&(colorArray[0])) = color;
        goto Label_01C2;
    Label_00FC:
        if (target.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_0148;
        }
        *(&(colorArray[1])) = color = target.guiText.material.color;
        *(&(colorArray[0])) = color;
        goto Label_01C2;
    Label_0148:
        if (target.renderer == null)
        {
            goto Label_018A;
        }
        *(&(colorArray[1])) = color = target.renderer.material.color;
        *(&(colorArray[0])) = color;
        goto Label_01C2;
    Label_018A:
        if (target.light == null)
        {
            goto Label_01C2;
        }
        *(&(colorArray[1])) = color = target.light.color;
        *(&(colorArray[0])) = color;
    Label_01C2:
        if (args.Contains("color") == null)
        {
            goto Label_01F3;
        }
        *(&(colorArray[1])) = (Color) args["color"];
        goto Label_02A3;
    Label_01F3:
        if (args.Contains("r") == null)
        {
            goto Label_021F;
        }
        &(colorArray[1]).r = (float) args["r"];
    Label_021F:
        if (args.Contains("g") == null)
        {
            goto Label_024B;
        }
        &(colorArray[1]).g = (float) args["g"];
    Label_024B:
        if (args.Contains("b") == null)
        {
            goto Label_0277;
        }
        &(colorArray[1]).b = (float) args["b"];
    Label_0277:
        if (args.Contains("a") == null)
        {
            goto Label_02A3;
        }
        &(colorArray[1]).a = (float) args["a"];
    Label_02A3:
        &(colorArray[3]).r = Mathf.SmoothDamp(&(colorArray[0]).r, &(colorArray[1]).r, &&(colorArray[2]).r, num);
        &(colorArray[3]).g = Mathf.SmoothDamp(&(colorArray[0]).g, &(colorArray[1]).g, &&(colorArray[2]).g, num);
        &(colorArray[3]).b = Mathf.SmoothDamp(&(colorArray[0]).b, &(colorArray[1]).b, &&(colorArray[2]).b, num);
        &(colorArray[3]).a = Mathf.SmoothDamp(&(colorArray[0]).a, &(colorArray[1]).a, &&(colorArray[2]).a, num);
        if (target.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_03B1;
        }
        target.guiTexture.color = *(&(colorArray[3]));
        goto Label_0444;
    Label_03B1:
        if (target.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_03EC;
        }
        target.guiText.material.color = *(&(colorArray[3]));
        goto Label_0444;
    Label_03EC:
        if (target.renderer == null)
        {
            goto Label_041D;
        }
        target.renderer.material.color = *(&(colorArray[3]));
        goto Label_0444;
    Label_041D:
        if (target.light == null)
        {
            goto Label_0444;
        }
        target.light.color = *(&(colorArray[3]));
    Label_0444:
        return;
    }

    public static void ColorUpdate(GameObject target, Color color, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "color", (Color) color, "time", (float) time };
        ColorUpdate(target, Hash(objArray1));
        return;
    }

    private unsafe void ConflictCheck()
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        DictionaryEntry entry;
        IDictionaryEnumerator enumerator;
        IDisposable disposable;
        componentArray2 = base.GetComponents(typeof(iTween));
        num = 0;
        goto Label_015A;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if ((tween.type == "value") == null)
        {
            goto Label_0039;
        }
        return;
    Label_0039:
        if (tween.isRunning == null)
        {
            goto Label_0156;
        }
        if ((tween.type == this.type) == null)
        {
            goto Label_0156;
        }
        if ((tween.method != this.method) == null)
        {
            goto Label_0071;
        }
        return;
    Label_0071:
        if (tween.tweenArguments.Count == this.tweenArguments.Count)
        {
            goto Label_0093;
        }
        tween.Dispose();
        return;
    Label_0093:
        enumerator = this.tweenArguments.GetEnumerator();
    Label_00A0:
        try
        {
            goto Label_0129;
        Label_00A5:
            entry = (DictionaryEntry) enumerator.Current;
            if (tween.tweenArguments.Contains(&entry.Key) != null)
            {
                goto Label_00D5;
            }
            tween.Dispose();
            goto Label_0163;
        Label_00D5:
            if (tween.tweenArguments[&entry.Key].Equals(this.tweenArguments[&entry.Key]) != null)
            {
                goto Label_0129;
            }
            if ((((string) &entry.Key) != "id") == null)
            {
                goto Label_0129;
            }
            tween.Dispose();
            goto Label_0163;
        Label_0129:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00A5;
            }
            goto Label_0150;
        }
        finally
        {
        Label_013A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0148;
            }
        Label_0148:
            disposable.Dispose();
        }
    Label_0150:
        this.Dispose();
    Label_0156:
        num += 1;
    Label_015A:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
    Label_0163:
        return;
    }

    public static int Count()
    {
        return tweens.Count;
    }

    public static int Count(string type)
    {
        int num;
        int num2;
        Hashtable hashtable;
        string str;
        num = 0;
        num2 = 0;
        goto Label_006C;
    Label_0009:
        hashtable = (Hashtable) tweens[num2];
        if (((((string) hashtable["type"]) + ((string) hashtable["method"])).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_0068;
        }
        num += 1;
    Label_0068:
        num2 += 1;
    Label_006C:
        if (num2 < tweens.Count)
        {
            goto Label_0009;
        }
        return num;
    }

    public static int Count(GameObject target)
    {
        Component[] componentArray;
        return (int) target.GetComponents(typeof(iTween)).Length;
    }

    public static int Count(GameObject target, string type)
    {
        int num;
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num2;
        string str;
        num = 0;
        componentArray2 = target.GetComponents(typeof(iTween));
        num2 = 0;
        goto Label_006B;
    Label_001D:
        tween = (iTween) componentArray2[num2];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_0065;
        }
        num += 1;
    Label_0065:
        num2 += 1;
    Label_006B:
        if (num2 < ((int) componentArray2.Length))
        {
            goto Label_001D;
        }
        return num;
    }

    private void DisableKinematic()
    {
    }

    private void Dispose()
    {
        int num;
        Hashtable hashtable;
        num = 0;
        goto Label_004C;
    Label_0007:
        hashtable = (Hashtable) tweens[num];
        if ((((string) hashtable["id"]) == this.id) == null)
        {
            goto Label_0048;
        }
        tweens.RemoveAt(num);
        goto Label_005C;
    Label_0048:
        num += 1;
    Label_004C:
        if (num < tweens.Count)
        {
            goto Label_0007;
        }
    Label_005C:
        UnityEngine.Object.Destroy(this);
        return;
    }

    public static unsafe void DrawLine(Transform[] line)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) line.Length) <= 0)
        {
            goto Label_004A;
        }
        vectorArray = new Vector3[(int) line.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = line[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) line.Length))
        {
            goto Label_0019;
        }
        DrawLineHelper(vectorArray, Defaults.color, "gizmos");
    Label_004A:
        return;
    }

    public static void DrawLine(Vector3[] line)
    {
        if (((int) line.Length) <= 0)
        {
            goto Label_0019;
        }
        DrawLineHelper(line, Defaults.color, "gizmos");
    Label_0019:
        return;
    }

    public static unsafe void DrawLine(Transform[] line, Color color)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) line.Length) <= 0)
        {
            goto Label_0046;
        }
        vectorArray = new Vector3[(int) line.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = line[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) line.Length))
        {
            goto Label_0019;
        }
        DrawLineHelper(vectorArray, color, "gizmos");
    Label_0046:
        return;
    }

    public static void DrawLine(Vector3[] line, Color color)
    {
        if (((int) line.Length) <= 0)
        {
            goto Label_0015;
        }
        DrawLineHelper(line, color, "gizmos");
    Label_0015:
        return;
    }

    public static unsafe void DrawLineGizmos(Transform[] line)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) line.Length) <= 0)
        {
            goto Label_004A;
        }
        vectorArray = new Vector3[(int) line.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = line[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) line.Length))
        {
            goto Label_0019;
        }
        DrawLineHelper(vectorArray, Defaults.color, "gizmos");
    Label_004A:
        return;
    }

    public static void DrawLineGizmos(Vector3[] line)
    {
        if (((int) line.Length) <= 0)
        {
            goto Label_0019;
        }
        DrawLineHelper(line, Defaults.color, "gizmos");
    Label_0019:
        return;
    }

    public static unsafe void DrawLineGizmos(Transform[] line, Color color)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) line.Length) <= 0)
        {
            goto Label_0046;
        }
        vectorArray = new Vector3[(int) line.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = line[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) line.Length))
        {
            goto Label_0019;
        }
        DrawLineHelper(vectorArray, color, "gizmos");
    Label_0046:
        return;
    }

    public static void DrawLineGizmos(Vector3[] line, Color color)
    {
        if (((int) line.Length) <= 0)
        {
            goto Label_0015;
        }
        DrawLineHelper(line, color, "gizmos");
    Label_0015:
        return;
    }

    public static unsafe void DrawLineHandles(Transform[] line)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) line.Length) <= 0)
        {
            goto Label_004A;
        }
        vectorArray = new Vector3[(int) line.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = line[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) line.Length))
        {
            goto Label_0019;
        }
        DrawLineHelper(vectorArray, Defaults.color, "handles");
    Label_004A:
        return;
    }

    public static void DrawLineHandles(Vector3[] line)
    {
        if (((int) line.Length) <= 0)
        {
            goto Label_0019;
        }
        DrawLineHelper(line, Defaults.color, "handles");
    Label_0019:
        return;
    }

    public static unsafe void DrawLineHandles(Transform[] line, Color color)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) line.Length) <= 0)
        {
            goto Label_0046;
        }
        vectorArray = new Vector3[(int) line.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = line[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) line.Length))
        {
            goto Label_0019;
        }
        DrawLineHelper(vectorArray, color, "handles");
    Label_0046:
        return;
    }

    public static void DrawLineHandles(Vector3[] line, Color color)
    {
        if (((int) line.Length) <= 0)
        {
            goto Label_0015;
        }
        DrawLineHelper(line, color, "handles");
    Label_0015:
        return;
    }

    private static unsafe void DrawLineHelper(Vector3[] line, Color color, string method)
    {
        int num;
        Gizmos.color = color;
        num = 0;
        goto Label_005F;
    Label_000D:
        if ((method == "gizmos") == null)
        {
            goto Label_0041;
        }
        Gizmos.DrawLine(*(&(line[num])), *(&(line[num + 1])));
        goto Label_005B;
    Label_0041:
        if ((method == "handles") == null)
        {
            goto Label_005B;
        }
        Debug.LogError("iTween Error: Drawing a line with Handles is temporarily disabled because of compatability issues with Unity 2.6!");
    Label_005B:
        num += 1;
    Label_005F:
        if (num < (((int) line.Length) - 1))
        {
            goto Label_000D;
        }
        return;
    }

    public static unsafe void DrawPath(Transform[] path)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) path.Length) <= 0)
        {
            goto Label_004A;
        }
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) path.Length))
        {
            goto Label_0019;
        }
        DrawPathHelper(vectorArray, Defaults.color, "gizmos");
    Label_004A:
        return;
    }

    public static void DrawPath(Vector3[] path)
    {
        if (((int) path.Length) <= 0)
        {
            goto Label_0019;
        }
        DrawPathHelper(path, Defaults.color, "gizmos");
    Label_0019:
        return;
    }

    public static unsafe void DrawPath(Transform[] path, Color color)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) path.Length) <= 0)
        {
            goto Label_0046;
        }
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) path.Length))
        {
            goto Label_0019;
        }
        DrawPathHelper(vectorArray, color, "gizmos");
    Label_0046:
        return;
    }

    public static void DrawPath(Vector3[] path, Color color)
    {
        if (((int) path.Length) <= 0)
        {
            goto Label_0015;
        }
        DrawPathHelper(path, color, "gizmos");
    Label_0015:
        return;
    }

    public static unsafe void DrawPathGizmos(Transform[] path)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) path.Length) <= 0)
        {
            goto Label_004A;
        }
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) path.Length))
        {
            goto Label_0019;
        }
        DrawPathHelper(vectorArray, Defaults.color, "gizmos");
    Label_004A:
        return;
    }

    public static void DrawPathGizmos(Vector3[] path)
    {
        if (((int) path.Length) <= 0)
        {
            goto Label_0019;
        }
        DrawPathHelper(path, Defaults.color, "gizmos");
    Label_0019:
        return;
    }

    public static unsafe void DrawPathGizmos(Transform[] path, Color color)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) path.Length) <= 0)
        {
            goto Label_0046;
        }
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) path.Length))
        {
            goto Label_0019;
        }
        DrawPathHelper(vectorArray, color, "gizmos");
    Label_0046:
        return;
    }

    public static void DrawPathGizmos(Vector3[] path, Color color)
    {
        if (((int) path.Length) <= 0)
        {
            goto Label_0015;
        }
        DrawPathHelper(path, color, "gizmos");
    Label_0015:
        return;
    }

    public static unsafe void DrawPathHandles(Transform[] path)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) path.Length) <= 0)
        {
            goto Label_004A;
        }
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) path.Length))
        {
            goto Label_0019;
        }
        DrawPathHelper(vectorArray, Defaults.color, "handles");
    Label_004A:
        return;
    }

    public static void DrawPathHandles(Vector3[] path)
    {
        if (((int) path.Length) <= 0)
        {
            goto Label_0019;
        }
        DrawPathHelper(path, Defaults.color, "handles");
    Label_0019:
        return;
    }

    public static unsafe void DrawPathHandles(Transform[] path, Color color)
    {
        Vector3[] vectorArray;
        int num;
        if (((int) path.Length) <= 0)
        {
            goto Label_0046;
        }
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0031;
    Label_0019:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0031:
        if (num < ((int) path.Length))
        {
            goto Label_0019;
        }
        DrawPathHelper(vectorArray, color, "handles");
    Label_0046:
        return;
    }

    public static void DrawPathHandles(Vector3[] path, Color color)
    {
        if (((int) path.Length) <= 0)
        {
            goto Label_0015;
        }
        DrawPathHelper(path, color, "handles");
    Label_0015:
        return;
    }

    private static void DrawPathHelper(Vector3[] path, Color color, string method)
    {
        Vector3[] vectorArray;
        Vector3 vector;
        int num;
        int num2;
        float num3;
        Vector3 vector2;
        vectorArray = PathControlPointGenerator(path);
        vector = Interp(vectorArray, 0f);
        Gizmos.color = color;
        num = ((int) path.Length) * 20;
        num2 = 1;
        goto Label_0076;
    Label_0027:
        num3 = ((float) num2) / ((float) num);
        vector2 = Interp(vectorArray, num3);
        if ((method == "gizmos") == null)
        {
            goto Label_0055;
        }
        Gizmos.DrawLine(vector2, vector);
        goto Label_006F;
    Label_0055:
        if ((method == "handles") == null)
        {
            goto Label_006F;
        }
        Debug.LogError("iTween Error: Drawing a path with Handles is temporarily disabled because of compatability issues with Unity 2.6!");
    Label_006F:
        vector = vector2;
        num2 += 1;
    Label_0076:
        if (num2 <= num)
        {
            goto Label_0027;
        }
        return;
    }

    private float easeInBack(float start, float end, float value)
    {
        float num;
        end -= start;
        value /= 1f;
        num = 1.70158f;
        return ((((end * value) * value) * (((num + 1f) * value) - num)) + start);
    }

    private float easeInBounce(float start, float end, float value)
    {
        float num;
        end -= start;
        num = 1f;
        return ((end - this.easeOutBounce(0f, end, num - value)) + start);
    }

    private float easeInCirc(float start, float end, float value)
    {
        end -= start;
        return ((-end * (Mathf.Sqrt(1f - (value * value)) - 1f)) + start);
    }

    private float easeInCubic(float start, float end, float value)
    {
        end -= start;
        return ((((end * value) * value) * value) + start);
    }

    private float easeInElastic(float start, float end, float value)
    {
        float num;
        float num2;
        float num3;
        float num4;
        end -= start;
        num = 1f;
        num2 = num * 0.3f;
        num3 = 0f;
        num4 = 0f;
        if (value != 0f)
        {
            goto Label_002C;
        }
        return start;
    Label_002C:
        if ((value /= num) != 1f)
        {
            goto Label_0040;
        }
        return (start + end);
    Label_0040:
        if (num4 == 0f)
        {
            goto Label_0057;
        }
        if (num4 >= Mathf.Abs(end))
        {
            goto Label_0066;
        }
    Label_0057:
        num4 = end;
        num3 = num2 / 4f;
        goto Label_0077;
    Label_0066:
        num3 = (num2 / 6.283185f) * Mathf.Asin(end / num4);
    Label_0077:
        return (-((num4 * Mathf.Pow(2f, 10f * (value -= 1f))) * Mathf.Sin((((value * num) - num3) * 6.283185f) / num2)) + start);
    }

    private float easeInExpo(float start, float end, float value)
    {
        end -= start;
        return ((end * Mathf.Pow(2f, 10f * ((value / 1f) - 1f))) + start);
    }

    private float easeInOutBack(float start, float end, float value)
    {
        float num;
        num = 1.70158f;
        end -= start;
        value /= 0.5f;
        if (value >= 1f)
        {
            goto Label_0041;
        }
        num *= 1.525f;
        return (((end / 2f) * ((value * value) * (((num + 1f) * value) - num))) + start);
    Label_0041:
        value -= 2f;
        num *= 1.525f;
        return (((end / 2f) * (((value * value) * (((num + 1f) * value) + num)) + 2f)) + start);
    }

    private float easeInOutBounce(float start, float end, float value)
    {
        float num;
        end -= start;
        num = 1f;
        if (value >= (num / 2f))
        {
            goto Label_0034;
        }
        return ((this.easeInBounce(0f, end, value * 2f) * 0.5f) + start);
    Label_0034:
        return (((this.easeOutBounce(0f, end, (value * 2f) - num) * 0.5f) + (end * 0.5f)) + start);
    }

    private float easeInOutCirc(float start, float end, float value)
    {
        value /= 0.5f;
        end -= start;
        if (value >= 1f)
        {
            goto Label_0039;
        }
        return (((-end / 2f) * (Mathf.Sqrt(1f - (value * value)) - 1f)) + start);
    Label_0039:
        value -= 2f;
        return (((end / 2f) * (Mathf.Sqrt(1f - (value * value)) + 1f)) + start);
    }

    private float easeInOutCubic(float start, float end, float value)
    {
        value /= 0.5f;
        end -= start;
        if (value >= 1f)
        {
            goto Label_0029;
        }
        return (((((end / 2f) * value) * value) * value) + start);
    Label_0029:
        value -= 2f;
        return (((end / 2f) * (((value * value) * value) + 2f)) + start);
    }

    private float easeInOutElastic(float start, float end, float value)
    {
        float num;
        float num2;
        float num3;
        float num4;
        end -= start;
        num = 1f;
        num2 = num * 0.3f;
        num3 = 0f;
        num4 = 0f;
        if (value != 0f)
        {
            goto Label_002C;
        }
        return start;
    Label_002C:
        if ((value /= (num / 2f)) != 2f)
        {
            goto Label_0046;
        }
        return (start + end);
    Label_0046:
        if (num4 == 0f)
        {
            goto Label_005D;
        }
        if (num4 >= Mathf.Abs(end))
        {
            goto Label_006C;
        }
    Label_005D:
        num4 = end;
        num3 = num2 / 4f;
        goto Label_007D;
    Label_006C:
        num3 = (num2 / 6.283185f) * Mathf.Asin(end / num4);
    Label_007D:
        if (value >= 1f)
        {
            goto Label_00C0;
        }
        return ((-0.5f * ((num4 * Mathf.Pow(2f, 10f * (value -= 1f))) * Mathf.Sin((((value * num) - num3) * 6.283185f) / num2))) + start);
    Label_00C0:
        return (((((num4 * Mathf.Pow(2f, -10f * (value -= 1f))) * Mathf.Sin((((value * num) - num3) * 6.283185f) / num2)) * 0.5f) + end) + start);
    }

    private float easeInOutExpo(float start, float end, float value)
    {
        value /= 0.5f;
        end -= start;
        if (value >= 1f)
        {
            goto Label_003B;
        }
        return (((end / 2f) * Mathf.Pow(2f, 10f * (value - 1f))) + start);
    Label_003B:
        value -= 1f;
        return (((end / 2f) * (-Mathf.Pow(2f, -10f * value) + 2f)) + start);
    }

    private float easeInOutQuad(float start, float end, float value)
    {
        value /= 0.5f;
        end -= start;
        if (value >= 1f)
        {
            goto Label_0027;
        }
        return ((((end / 2f) * value) * value) + start);
    Label_0027:
        value -= 1f;
        return (((-end / 2f) * ((value * (value - 2f)) - 1f)) + start);
    }

    private float easeInOutQuart(float start, float end, float value)
    {
        value /= 0.5f;
        end -= start;
        if (value >= 1f)
        {
            goto Label_002B;
        }
        return ((((((end / 2f) * value) * value) * value) * value) + start);
    Label_002B:
        value -= 2f;
        return (((-end / 2f) * ((((value * value) * value) * value) - 2f)) + start);
    }

    private float easeInOutQuint(float start, float end, float value)
    {
        value /= 0.5f;
        end -= start;
        if (value >= 1f)
        {
            goto Label_002D;
        }
        return (((((((end / 2f) * value) * value) * value) * value) * value) + start);
    Label_002D:
        value -= 2f;
        return (((end / 2f) * (((((value * value) * value) * value) * value) + 2f)) + start);
    }

    private float easeInOutSine(float start, float end, float value)
    {
        end -= start;
        return (((-end / 2f) * (Mathf.Cos((3.141593f * value) / 1f) - 1f)) + start);
    }

    private float easeInQuad(float start, float end, float value)
    {
        end -= start;
        return (((end * value) * value) + start);
    }

    private float easeInQuart(float start, float end, float value)
    {
        end -= start;
        return (((((end * value) * value) * value) * value) + start);
    }

    private float easeInQuint(float start, float end, float value)
    {
        end -= start;
        return ((((((end * value) * value) * value) * value) * value) + start);
    }

    private float easeInSine(float start, float end, float value)
    {
        end -= start;
        return (((-end * Mathf.Cos((value / 1f) * 1.570796f)) + end) + start);
    }

    private float easeOutBack(float start, float end, float value)
    {
        float num;
        num = 1.70158f;
        end -= start;
        value = (value / 1f) - 1f;
        return ((end * (((value * value) * (((num + 1f) * value) + num)) + 1f)) + start);
    }

    private float easeOutBounce(float start, float end, float value)
    {
        value /= 1f;
        end -= start;
        if (value >= 0.3636364f)
        {
            goto Label_0027;
        }
        return ((end * ((7.5625f * value) * value)) + start);
    Label_0027:
        if (value >= 0.7272727f)
        {
            goto Label_004F;
        }
        value -= 0.5454546f;
        return ((end * (((7.5625f * value) * value) + 0.75f)) + start);
    Label_004F:
        if (((double) value) >= 0.90909090909090906)
        {
            goto Label_007C;
        }
        value -= 0.8181818f;
        return ((end * (((7.5625f * value) * value) + 0.9375f)) + start);
    Label_007C:
        value -= 0.9545454f;
        return ((end * (((7.5625f * value) * value) + 0.984375f)) + start);
    }

    private float easeOutCirc(float start, float end, float value)
    {
        value -= 1f;
        end -= start;
        return ((end * Mathf.Sqrt(1f - (value * value))) + start);
    }

    private float easeOutCubic(float start, float end, float value)
    {
        value -= 1f;
        end -= start;
        return ((end * (((value * value) * value) + 1f)) + start);
    }

    private float easeOutElastic(float start, float end, float value)
    {
        float num;
        float num2;
        float num3;
        float num4;
        end -= start;
        num = 1f;
        num2 = num * 0.3f;
        num3 = 0f;
        num4 = 0f;
        if (value != 0f)
        {
            goto Label_002C;
        }
        return start;
    Label_002C:
        if ((value /= num) != 1f)
        {
            goto Label_0040;
        }
        return (start + end);
    Label_0040:
        if (num4 == 0f)
        {
            goto Label_0057;
        }
        if (num4 >= Mathf.Abs(end))
        {
            goto Label_0066;
        }
    Label_0057:
        num4 = end;
        num3 = num2 / 4f;
        goto Label_0077;
    Label_0066:
        num3 = (num2 / 6.283185f) * Mathf.Asin(end / num4);
    Label_0077:
        return ((((num4 * Mathf.Pow(2f, -10f * value)) * Mathf.Sin((((value * num) - num3) * 6.283185f) / num2)) + end) + start);
    }

    private float easeOutExpo(float start, float end, float value)
    {
        end -= start;
        return ((end * (-Mathf.Pow(2f, (-10f * value) / 1f) + 1f)) + start);
    }

    private float easeOutQuad(float start, float end, float value)
    {
        end -= start;
        return (((-end * value) * (value - 2f)) + start);
    }

    private float easeOutQuart(float start, float end, float value)
    {
        value -= 1f;
        end -= start;
        return ((-end * ((((value * value) * value) * value) - 1f)) + start);
    }

    private float easeOutQuint(float start, float end, float value)
    {
        value -= 1f;
        end -= start;
        return ((end * (((((value * value) * value) * value) * value) + 1f)) + start);
    }

    private float easeOutSine(float start, float end, float value)
    {
        end -= start;
        return ((end * Mathf.Sin((value / 1f) * 1.570796f)) + start);
    }

    private void EnableKinematic()
    {
    }

    public static void FadeFrom(GameObject target, Hashtable args)
    {
        ColorFrom(target, args);
        return;
    }

    public static void FadeFrom(GameObject target, float alpha, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "alpha", (float) alpha, "time", (float) time };
        FadeFrom(target, Hash(objArray1));
        return;
    }

    public static void FadeTo(GameObject target, Hashtable args)
    {
        ColorTo(target, args);
        return;
    }

    public static void FadeTo(GameObject target, float alpha, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "alpha", (float) alpha, "time", (float) time };
        FadeTo(target, Hash(objArray1));
        return;
    }

    public static void FadeUpdate(GameObject target, Hashtable args)
    {
        args["a"] = args["alpha"];
        ColorUpdate(target, args);
        return;
    }

    public static void FadeUpdate(GameObject target, float alpha, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "alpha", (float) alpha, "time", (float) time };
        FadeUpdate(target, Hash(objArray1));
        return;
    }

    private void FixedUpdate()
    {
        if (this.isRunning == null)
        {
            goto Label_0068;
        }
        if (this.physics == null)
        {
            goto Label_0068;
        }
        if (this.reverse != null)
        {
            goto Label_0047;
        }
        if (this.percentage >= 1f)
        {
            goto Label_003C;
        }
        this.TweenUpdate();
        goto Label_0042;
    Label_003C:
        this.TweenComplete();
    Label_0042:
        goto Label_0068;
    Label_0047:
        if (this.percentage <= 0f)
        {
            goto Label_0062;
        }
        this.TweenUpdate();
        goto Label_0068;
    Label_0062:
        this.TweenComplete();
    Label_0068:
        return;
    }

    public static float FloatUpdate(float currentValue, float targetValue, float speed)
    {
        float num;
        num = targetValue - currentValue;
        currentValue += (num * speed) * Time.deltaTime;
        return currentValue;
    }

    private unsafe void GenerateAudioToTargets()
    {
        Vector2 vector;
        this.vector2s = new Vector2[3];
        if (this.tweenArguments.Contains("audiosource") == null)
        {
            goto Label_0041;
        }
        this.audioSource = (AudioSource) this.tweenArguments["audiosource"];
        goto Label_007C;
    Label_0041:
        if (base.GetComponent(typeof(AudioSource)) == null)
        {
            goto Label_006C;
        }
        this.audioSource = base.audio;
        goto Label_007C;
    Label_006C:
        Debug.LogError("iTween Error: AudioTo requires an AudioSource.");
        this.Dispose();
    Label_007C:
        *(&(this.vector2s[1])) = vector = new Vector2(this.audioSource.volume, this.audioSource.pitch);
        *(&(this.vector2s[0])) = vector;
        if (this.tweenArguments.Contains("volume") == null)
        {
            goto Label_00F7;
        }
        &(this.vector2s[1]).x = (float) this.tweenArguments["volume"];
    Label_00F7:
        if (this.tweenArguments.Contains("pitch") == null)
        {
            goto Label_0132;
        }
        &(this.vector2s[1]).y = (float) this.tweenArguments["pitch"];
    Label_0132:
        return;
    }

    private void GenerateColorTargets()
    {
        this.colors = new Color[1, 3];
        this.colors[0, 0] = (Color) this.tweenArguments["from"];
        this.colors[0, 1] = (Color) this.tweenArguments["to"];
        return;
    }

    private void GenerateColorToTargets()
    {
        int num;
        int num2;
        int num3;
        int num4;
        int num5;
        int num6;
        int num7;
        int num8;
        Color color;
        if (base.GetComponent(typeof(GUITexture)) == null)
        {
            goto Label_0056;
        }
        this.colors = new Color[1, 3];
        this.colors[0, 1] = color = base.guiTexture.color;
        this.colors[0, 0] = color;
        goto Label_01B4;
    Label_0056:
        if (base.GetComponent(typeof(GUIText)) == null)
        {
            goto Label_00B1;
        }
        this.colors = new Color[1, 3];
        this.colors[0, 1] = color = base.guiText.material.color;
        this.colors[0, 0] = color;
        goto Label_01B4;
    Label_00B1:
        if (base.renderer == null)
        {
            goto Label_015B;
        }
        this.colors = new Color[(int) base.renderer.materials.Length, 3];
        num = 0;
        goto Label_0143;
    Label_00E1:
        this.colors[num, 0] = base.renderer.materials[num].GetColor(((NamedValueColor) this.namedcolorvalue).ToString());
        this.colors[num, 1] = base.renderer.materials[num].GetColor(((NamedValueColor) this.namedcolorvalue).ToString());
        num += 1;
    Label_0143:
        if (num < ((int) base.renderer.materials.Length))
        {
            goto Label_00E1;
        }
        goto Label_01B4;
    Label_015B:
        if (base.light == null)
        {
            goto Label_01A7;
        }
        this.colors = new Color[1, 3];
        this.colors[0, 1] = color = base.light.color;
        this.colors[0, 0] = color;
        goto Label_01B4;
    Label_01A7:
        this.colors = new Color[1, 3];
    Label_01B4:
        if (this.tweenArguments.Contains("color") == null)
        {
            goto Label_020D;
        }
        num2 = 0;
        goto Label_01F6;
    Label_01D0:
        this.colors[num2, 1] = (Color) this.tweenArguments["color"];
        num2 += 1;
    Label_01F6:
        if (num2 < this.colors.GetLength(0))
        {
            goto Label_01D0;
        }
        goto Label_037B;
    Label_020D:
        if (this.tweenArguments.Contains("r") == null)
        {
            goto Label_0266;
        }
        num3 = 0;
        goto Label_0254;
    Label_0229:
        this.colors[num3, 1].r = (float) this.tweenArguments["r"];
        num3 += 1;
    Label_0254:
        if (num3 < this.colors.GetLength(0))
        {
            goto Label_0229;
        }
    Label_0266:
        if (this.tweenArguments.Contains("g") == null)
        {
            goto Label_02BF;
        }
        num4 = 0;
        goto Label_02AD;
    Label_0282:
        this.colors[num4, 1].g = (float) this.tweenArguments["g"];
        num4 += 1;
    Label_02AD:
        if (num4 < this.colors.GetLength(0))
        {
            goto Label_0282;
        }
    Label_02BF:
        if (this.tweenArguments.Contains("b") == null)
        {
            goto Label_031D;
        }
        num5 = 0;
        goto Label_030A;
    Label_02DC:
        this.colors[num5, 1].b = (float) this.tweenArguments["b"];
        num5 += 1;
    Label_030A:
        if (num5 < this.colors.GetLength(0))
        {
            goto Label_02DC;
        }
    Label_031D:
        if (this.tweenArguments.Contains("a") == null)
        {
            goto Label_037B;
        }
        num6 = 0;
        goto Label_0368;
    Label_033A:
        this.colors[num6, 1].a = (float) this.tweenArguments["a"];
        num6 += 1;
    Label_0368:
        if (num6 < this.colors.GetLength(0))
        {
            goto Label_033A;
        }
    Label_037B:
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_03DE;
        }
        num7 = 0;
        goto Label_03C6;
    Label_0398:
        this.colors[num7, 1].a = (float) this.tweenArguments["amount"];
        num7 += 1;
    Label_03C6:
        if (num7 < this.colors.GetLength(0))
        {
            goto Label_0398;
        }
        goto Label_043C;
    Label_03DE:
        if (this.tweenArguments.Contains("alpha") == null)
        {
            goto Label_043C;
        }
        num8 = 0;
        goto Label_0429;
    Label_03FB:
        this.colors[num8, 1].a = (float) this.tweenArguments["alpha"];
        num8 += 1;
    Label_0429:
        if (num8 < this.colors.GetLength(0))
        {
            goto Label_03FB;
        }
    Label_043C:
        return;
    }

    private void GenerateFloatTargets()
    {
        float num;
        this.floats = new float[3];
        this.floats[0] = (float) this.tweenArguments["from"];
        this.floats[1] = (float) this.tweenArguments["to"];
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_008F;
        }
        num = Math.Abs(this.floats[0] - this.floats[1]);
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_008F:
        return;
    }

    private static string GenerateID()
    {
        int num;
        char[] chArray;
        int num2;
        string str;
        int num3;
        num = 15;
        chArray = new char[] { 
            0x61, 0x62, 0x63, 100, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 110, 0x6f, 0x70, 
            0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 120, 0x79, 0x7a, 0x41, 0x42, 0x43, 0x44, 0x45, 70, 
            0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 80, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 
            0x57, 0x58, 0x59, 90, 0x30, 0x31, 50, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0
         };
        num2 = ((int) chArray.Length) - 1;
        str = string.Empty;
        num3 = 0;
        goto Label_004C;
    Label_002A:
        str = str + ((char) chArray[(int) Mathf.Floor((float) UnityEngine.Random.Range(0, num2))]);
        num3 += 1;
    Label_004C:
        if (num3 < num)
        {
            goto Label_002A;
        }
        return str;
    }

    private unsafe void GenerateLookToTargets()
    {
        float num;
        Vector3? nullable;
        Vector3? nullable2;
        string str;
        Dictionary<string, int> dictionary;
        int num2;
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[0])) = base.transform.eulerAngles;
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_0135;
        }
        if (this.tweenArguments["looktarget"].GetType() != typeof(Transform))
        {
            goto Label_00B9;
        }
        nullable = (Vector3?) this.tweenArguments["up"];
        base.transform.LookAt((Transform) this.tweenArguments["looktarget"], (&nullable.HasValue == null) ? Defaults.up : &nullable.Value);
        goto Label_0130;
    Label_00B9:
        if (this.tweenArguments["looktarget"].GetType() != typeof(Vector3))
        {
            goto Label_0145;
        }
        nullable2 = (Vector3?) this.tweenArguments["up"];
        base.transform.LookAt((Vector3) this.tweenArguments["looktarget"], (&nullable2.HasValue == null) ? Defaults.up : &nullable2.Value);
    Label_0130:
        goto Label_0145;
    Label_0135:
        Debug.LogError("iTween Error: LookTo needs a 'looktarget' property!");
        this.Dispose();
    Label_0145:
        *(&(this.vector3s[1])) = base.transform.eulerAngles;
        base.transform.eulerAngles = *(&(this.vector3s[0]));
        if (this.tweenArguments.Contains("axis") == null)
        {
            goto Label_02F3;
        }
        str = (string) this.tweenArguments["axis"];
        if (str == null)
        {
            goto Label_02F3;
        }
        if (switchmap1B != null)
        {
            goto Label_01EE;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("x", 0);
        dictionary.Add("y", 1);
        dictionary.Add("z", 2);
        switchmap1B = dictionary;
    Label_01EE:
        if (switchmap1B.TryGetValue(str, &num2) == null)
        {
            goto Label_02F3;
        }
        switch (num2)
        {
            case 0:
                goto Label_0218;

            case 1:
                goto Label_0261;

            case 2:
                goto Label_02AA;
        }
        goto Label_02F3;
    Label_0218:
        &(this.vector3s[1]).y = &(this.vector3s[0]).y;
        &(this.vector3s[1]).z = &(this.vector3s[0]).z;
        goto Label_02F3;
    Label_0261:
        &(this.vector3s[1]).x = &(this.vector3s[0]).x;
        &(this.vector3s[1]).z = &(this.vector3s[0]).z;
        goto Label_02F3;
    Label_02AA:
        &(this.vector3s[1]).x = &(this.vector3s[0]).x;
        &(this.vector3s[1]).y = &(this.vector3s[0]).y;
    Label_02F3:
        *(&(this.vector3s[1])) = new Vector3(this.clerp(&(this.vector3s[0]).x, &(this.vector3s[1]).x, 1f), this.clerp(&(this.vector3s[0]).y, &(this.vector3s[1]).y, 1f), this.clerp(&(this.vector3s[0]).z, &(this.vector3s[1]).z, 1f));
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_03EF;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_03EF:
        return;
    }

    private unsafe void GenerateMoveByTargets()
    {
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[6];
        *(&(this.vector3s[4])) = base.transform.eulerAngles;
        *(&(this.vector3s[3])) = vector = base.transform.position;
        *(&(this.vector3s[1])) = vector = vector;
        *(&(this.vector3s[0])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_00C2;
        }
        *(&(this.vector3s[1])) = *(&(this.vector3s[0])) + ((Vector3) this.tweenArguments["amount"]);
        goto Label_01A9;
    Label_00C2:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_010F;
        }
        &(this.vector3s[1]).x = &(this.vector3s[0]).x + ((float) this.tweenArguments["x"]);
    Label_010F:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_015C;
        }
        &(this.vector3s[1]).y = &(this.vector3s[0]).y + ((float) this.tweenArguments["y"]);
    Label_015C:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_01A9;
        }
        &(this.vector3s[1]).z = &(this.vector3s[0]).z + ((float) this.tweenArguments["z"]);
    Label_01A9:
        base.transform.Translate(*(&(this.vector3s[1])), this.space);
        *(&(this.vector3s[5])) = base.transform.position;
        base.transform.position = *(&(this.vector3s[0]));
        if (this.tweenArguments.Contains("orienttopath") == null)
        {
            goto Label_0258;
        }
        if (((bool) this.tweenArguments["orienttopath"]) == null)
        {
            goto Label_0258;
        }
        this.tweenArguments["looktarget"] = (Vector3) *(&(this.vector3s[1]));
    Label_0258:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_02B7;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_02B7:
        return;
    }

    private unsafe void GenerateMoveToPathTargets()
    {
        Vector3[] vectorArray;
        Vector3[] vectorArray2;
        Transform[] transformArray;
        int num;
        bool flag;
        int num2;
        Vector3[] vectorArray3;
        float num3;
        if (this.tweenArguments["path"].GetType() != typeof(Vector3[]))
        {
            goto Label_006B;
        }
        vectorArray2 = (Vector3[]) this.tweenArguments["path"];
        if (((int) vectorArray2.Length) != 1)
        {
            goto Label_0053;
        }
        Debug.LogError("iTween Error: Attempting a path movement with MoveTo requires an array of more than 1 entry!");
        this.Dispose();
    Label_0053:
        vectorArray = new Vector3[(int) vectorArray2.Length];
        Array.Copy(vectorArray2, vectorArray, (int) vectorArray2.Length);
        goto Label_00CB;
    Label_006B:
        transformArray = (Transform[]) this.tweenArguments["path"];
        if (((int) transformArray.Length) != 1)
        {
            goto Label_009A;
        }
        Debug.LogError("iTween Error: Attempting a path movement with MoveTo requires an array of more than 1 entry!");
        this.Dispose();
    Label_009A:
        vectorArray = new Vector3[(int) transformArray.Length];
        num = 0;
        goto Label_00C2;
    Label_00AA:
        *(&(vectorArray[num])) = transformArray[num].position;
        num += 1;
    Label_00C2:
        if (num < ((int) transformArray.Length))
        {
            goto Label_00AA;
        }
    Label_00CB:
        if ((base.transform.position != *(&(vectorArray[0]))) == null)
        {
            goto Label_0131;
        }
        if (this.tweenArguments.Contains("movetopath") == null)
        {
            goto Label_011B;
        }
        if (((bool) this.tweenArguments["movetopath"]) == null)
        {
            goto Label_0126;
        }
    Label_011B:
        flag = 1;
        num2 = 3;
        goto Label_012C;
    Label_0126:
        flag = 0;
        num2 = 2;
    Label_012C:
        goto Label_0137;
    Label_0131:
        flag = 0;
        num2 = 2;
    Label_0137:
        this.vector3s = new Vector3[((int) vectorArray.Length) + num2];
        if (flag == null)
        {
            goto Label_0173;
        }
        *(&(this.vector3s[1])) = base.transform.position;
        num2 = 2;
        goto Label_0176;
    Label_0173:
        num2 = 1;
    Label_0176:
        Array.Copy(vectorArray, 0, this.vector3s, num2, (int) vectorArray.Length);
        *(&(this.vector3s[0])) = *(&(this.vector3s[1])) + (*(&(this.vector3s[1])) - *(&(this.vector3s[2])));
        *(&(this.vector3s[((int) this.vector3s.Length) - 1])) = *(&(this.vector3s[((int) this.vector3s.Length) - 2])) + (*(&(this.vector3s[((int) this.vector3s.Length) - 2])) - *(&(this.vector3s[((int) this.vector3s.Length) - 3])));
        if ((*(&(this.vector3s[1])) == *(&(this.vector3s[((int) this.vector3s.Length) - 2]))) == null)
        {
            goto Label_02FF;
        }
        vectorArray3 = new Vector3[(int) this.vector3s.Length];
        Array.Copy(this.vector3s, vectorArray3, (int) this.vector3s.Length);
        *(&(vectorArray3[0])) = *(&(vectorArray3[((int) vectorArray3.Length) - 3]));
        *(&(vectorArray3[((int) vectorArray3.Length) - 1])) = *(&(vectorArray3[2]));
        this.vector3s = new Vector3[(int) vectorArray3.Length];
        Array.Copy(vectorArray3, this.vector3s, (int) vectorArray3.Length);
    Label_02FF:
        this.path = new CRSpline(this.vector3s);
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_0350;
        }
        num3 = PathLength(this.vector3s);
        this.time = num3 / ((float) this.tweenArguments["speed"]);
    Label_0350:
        return;
    }

    private unsafe void GenerateMoveToTargets()
    {
        Transform transform;
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[3];
        if (this.isLocal == null)
        {
            goto Label_004C;
        }
        *(&(this.vector3s[1])) = vector = base.transform.localPosition;
        *(&(this.vector3s[0])) = vector;
        goto Label_007C;
    Label_004C:
        *(&(this.vector3s[1])) = vector = base.transform.position;
        *(&(this.vector3s[0])) = vector;
    Label_007C:
        if (this.tweenArguments.Contains("position") == null)
        {
            goto Label_0136;
        }
        if (this.tweenArguments["position"].GetType() != typeof(Transform))
        {
            goto Label_00E7;
        }
        transform = (Transform) this.tweenArguments["position"];
        *(&(this.vector3s[1])) = transform.position;
        goto Label_0131;
    Label_00E7:
        if (this.tweenArguments["position"].GetType() != typeof(Vector3))
        {
            goto Label_01E7;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["position"];
    Label_0131:
        goto Label_01E7;
    Label_0136:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_0171;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_0171:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_01AC;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_01AC:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_01E7;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_01E7:
        if (this.tweenArguments.Contains("orienttopath") == null)
        {
            goto Label_023C;
        }
        if (((bool) this.tweenArguments["orienttopath"]) == null)
        {
            goto Label_023C;
        }
        this.tweenArguments["looktarget"] = (Vector3) *(&(this.vector3s[1]));
    Label_023C:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_029B;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_029B:
        return;
    }

    private unsafe void GeneratePunchPositionTargets()
    {
        Vector3 vector;
        this.vector3s = new Vector3[5];
        *(&(this.vector3s[4])) = base.transform.eulerAngles;
        *(&(this.vector3s[0])) = base.transform.position;
        *(&(this.vector3s[3])) = vector = Vector3.zero;
        *(&(this.vector3s[1])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_00AE;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["amount"];
        goto Label_015F;
    Label_00AE:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00E9;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_00E9:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_0124;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_0124:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_015F;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_015F:
        return;
    }

    private unsafe void GeneratePunchRotationTargets()
    {
        Vector3 vector;
        this.vector3s = new Vector3[4];
        *(&(this.vector3s[0])) = base.transform.eulerAngles;
        *(&(this.vector3s[3])) = vector = Vector3.zero;
        *(&(this.vector3s[1])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_0092;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["amount"];
        goto Label_0143;
    Label_0092:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00CD;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_00CD:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_0108;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_0108:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_0143;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_0143:
        return;
    }

    private unsafe void GeneratePunchScaleTargets()
    {
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[0])) = base.transform.localScale;
        *(&(this.vector3s[1])) = Vector3.zero;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_007E;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["amount"];
        goto Label_012F;
    Label_007E:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00B9;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_00B9:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_00F4;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_00F4:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_012F;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_012F:
        return;
    }

    private unsafe void GenerateRectTargets()
    {
        this.rects = new Rect[3];
        *(&(this.rects[0])) = (Rect) this.tweenArguments["from"];
        *(&(this.rects[1])) = (Rect) this.tweenArguments["to"];
        return;
    }

    private unsafe void GenerateRotateAddTargets()
    {
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[5];
        *(&(this.vector3s[3])) = vector = base.transform.eulerAngles;
        *(&(this.vector3s[1])) = vector = vector;
        *(&(this.vector3s[0])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_009B;
        }
        *(&(this.vector3s[1])) += (Vector3) this.tweenArguments["amount"];
        goto Label_0161;
    Label_009B:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00DD;
        }
        &(this.vector3s[1]).x += (float) this.tweenArguments["x"];
    Label_00DD:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_011F;
        }
        &(this.vector3s[1]).y += (float) this.tweenArguments["y"];
    Label_011F:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_0161;
        }
        &(this.vector3s[1]).z += (float) this.tweenArguments["z"];
    Label_0161:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_01C0;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_01C0:
        return;
    }

    private unsafe void GenerateRotateByTargets()
    {
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[4];
        *(&(this.vector3s[3])) = vector = base.transform.eulerAngles;
        *(&(this.vector3s[1])) = vector = vector;
        *(&(this.vector3s[0])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_00B4;
        }
        *(&(this.vector3s[1])) += Vector3.Scale((Vector3) this.tweenArguments["amount"], new Vector3(360f, 360f, 360f));
        goto Label_018C;
    Label_00B4:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00FC;
        }
        &(this.vector3s[1]).x += 360f * ((float) this.tweenArguments["x"]);
    Label_00FC:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_0144;
        }
        &(this.vector3s[1]).y += 360f * ((float) this.tweenArguments["y"]);
    Label_0144:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_018C;
        }
        &(this.vector3s[1]).z += 360f * ((float) this.tweenArguments["z"]);
    Label_018C:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_01EB;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_01EB:
        return;
    }

    private unsafe void GenerateRotateToTargets()
    {
        Transform transform;
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[3];
        if (this.isLocal == null)
        {
            goto Label_004C;
        }
        *(&(this.vector3s[1])) = vector = base.transform.localEulerAngles;
        *(&(this.vector3s[0])) = vector;
        goto Label_007C;
    Label_004C:
        *(&(this.vector3s[1])) = vector = base.transform.eulerAngles;
        *(&(this.vector3s[0])) = vector;
    Label_007C:
        if (this.tweenArguments.Contains("rotation") == null)
        {
            goto Label_0136;
        }
        if (this.tweenArguments["rotation"].GetType() != typeof(Transform))
        {
            goto Label_00E7;
        }
        transform = (Transform) this.tweenArguments["rotation"];
        *(&(this.vector3s[1])) = transform.eulerAngles;
        goto Label_0131;
    Label_00E7:
        if (this.tweenArguments["rotation"].GetType() != typeof(Vector3))
        {
            goto Label_01E7;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["rotation"];
    Label_0131:
        goto Label_01E7;
    Label_0136:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_0171;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_0171:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_01AC;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_01AC:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_01E7;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_01E7:
        *(&(this.vector3s[1])) = new Vector3(this.clerp(&(this.vector3s[0]).x, &(this.vector3s[1]).x, 1f), this.clerp(&(this.vector3s[0]).y, &(this.vector3s[1]).y, 1f), this.clerp(&(this.vector3s[0]).z, &(this.vector3s[1]).z, 1f));
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_02E3;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_02E3:
        return;
    }

    private unsafe void GenerateScaleAddTargets()
    {
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[1])) = vector = base.transform.localScale;
        *(&(this.vector3s[0])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_0087;
        }
        *(&(this.vector3s[1])) += (Vector3) this.tweenArguments["amount"];
        goto Label_014D;
    Label_0087:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00C9;
        }
        &(this.vector3s[1]).x += (float) this.tweenArguments["x"];
    Label_00C9:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_010B;
        }
        &(this.vector3s[1]).y += (float) this.tweenArguments["y"];
    Label_010B:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_014D;
        }
        &(this.vector3s[1]).z += (float) this.tweenArguments["z"];
    Label_014D:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_01AC;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_01AC:
        return;
    }

    private unsafe void GenerateScaleByTargets()
    {
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[1])) = vector = base.transform.localScale;
        *(&(this.vector3s[0])) = vector;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_0092;
        }
        *(&(this.vector3s[1])) = Vector3.Scale(*(&(this.vector3s[1])), (Vector3) this.tweenArguments["amount"]);
        goto Label_0158;
    Label_0092:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00D4;
        }
        &(this.vector3s[1]).x *= (float) this.tweenArguments["x"];
    Label_00D4:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_0116;
        }
        &(this.vector3s[1]).y *= (float) this.tweenArguments["y"];
    Label_0116:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_0158;
        }
        &(this.vector3s[1]).z *= (float) this.tweenArguments["z"];
    Label_0158:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_01B7;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_01B7:
        return;
    }

    private unsafe void GenerateScaleToTargets()
    {
        Transform transform;
        float num;
        Vector3 vector;
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[1])) = vector = base.transform.localScale;
        *(&(this.vector3s[0])) = vector;
        if (this.tweenArguments.Contains("scale") == null)
        {
            goto Label_00F6;
        }
        if (this.tweenArguments["scale"].GetType() != typeof(Transform))
        {
            goto Label_00A7;
        }
        transform = (Transform) this.tweenArguments["scale"];
        *(&(this.vector3s[1])) = transform.localScale;
        goto Label_00F1;
    Label_00A7:
        if (this.tweenArguments["scale"].GetType() != typeof(Vector3))
        {
            goto Label_01A7;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["scale"];
    Label_00F1:
        goto Label_01A7;
    Label_00F6:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_0131;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_0131:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_016C;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_016C:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_01A7;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_01A7:
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_0206;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_0206:
        return;
    }

    private unsafe void GenerateShakePositionTargets()
    {
        this.vector3s = new Vector3[4];
        *(&(this.vector3s[3])) = base.transform.eulerAngles;
        *(&(this.vector3s[0])) = base.transform.position;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_0084;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["amount"];
        goto Label_0135;
    Label_0084:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00BF;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_00BF:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_00FA;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_00FA:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_0135;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_0135:
        return;
    }

    private unsafe void GenerateShakeRotationTargets()
    {
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[0])) = base.transform.eulerAngles;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_0068;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["amount"];
        goto Label_0119;
    Label_0068:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00A3;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_00A3:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_00DE;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_00DE:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_0119;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_0119:
        return;
    }

    private unsafe void GenerateShakeScaleTargets()
    {
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[0])) = base.transform.localScale;
        if (this.tweenArguments.Contains("amount") == null)
        {
            goto Label_0068;
        }
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["amount"];
        goto Label_0119;
    Label_0068:
        if (this.tweenArguments.Contains("x") == null)
        {
            goto Label_00A3;
        }
        &(this.vector3s[1]).x = (float) this.tweenArguments["x"];
    Label_00A3:
        if (this.tweenArguments.Contains("y") == null)
        {
            goto Label_00DE;
        }
        &(this.vector3s[1]).y = (float) this.tweenArguments["y"];
    Label_00DE:
        if (this.tweenArguments.Contains("z") == null)
        {
            goto Label_0119;
        }
        &(this.vector3s[1]).z = (float) this.tweenArguments["z"];
    Label_0119:
        return;
    }

    private void GenerateStabTargets()
    {
        if (this.tweenArguments.Contains("audiosource") == null)
        {
            goto Label_0035;
        }
        this.audioSource = (AudioSource) this.tweenArguments["audiosource"];
        goto Label_008E;
    Label_0035:
        if (base.GetComponent(typeof(AudioSource)) == null)
        {
            goto Label_0060;
        }
        this.audioSource = base.audio;
        goto Label_008E;
    Label_0060:
        base.gameObject.AddComponent(typeof(AudioSource));
        this.audioSource = base.audio;
        this.audioSource.playOnAwake = 0;
    Label_008E:
        this.audioSource.clip = (AudioClip) this.tweenArguments["audioclip"];
        if (this.tweenArguments.Contains("pitch") == null)
        {
            goto Label_00E3;
        }
        this.audioSource.pitch = (float) this.tweenArguments["pitch"];
    Label_00E3:
        if (this.tweenArguments.Contains("volume") == null)
        {
            goto Label_0118;
        }
        this.audioSource.volume = (float) this.tweenArguments["volume"];
    Label_0118:
        this.time = this.audioSource.clip.length / this.audioSource.pitch;
        return;
    }

    private unsafe void GenerateTargets()
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        string str2;
        int num2;
        str = this.type;
        if (str == null)
        {
            goto Label_078F;
        }
        if (switchmap1A != null)
        {
            goto Label_009E;
        }
        dictionary = new Dictionary<string, int>(10);
        dictionary.Add("value", 0);
        dictionary.Add("color", 1);
        dictionary.Add("audio", 2);
        dictionary.Add("move", 3);
        dictionary.Add("scale", 4);
        dictionary.Add("rotate", 5);
        dictionary.Add("shake", 6);
        dictionary.Add("punch", 7);
        dictionary.Add("look", 8);
        dictionary.Add("stab", 9);
        switchmap1A = dictionary;
    Label_009E:
        if (switchmap1A.TryGetValue(str, &num) == null)
        {
            goto Label_078F;
        }
        switch (num)
        {
            case 0:
                goto Label_00E3;

            case 1:
                goto Label_020B;

            case 2:
                goto Label_027B;

            case 3:
                goto Label_02EB;

            case 4:
                goto Label_03CA;

            case 5:
                goto Label_0498;

            case 6:
                goto Label_0566;

            case 7:
                goto Label_0634;

            case 8:
                goto Label_0702;

            case 9:
                goto Label_0772;
        }
        goto Label_078F;
    Label_00E3:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap11 != null)
        {
            goto Label_0143;
        }
        dictionary = new Dictionary<string, int>(5);
        dictionary.Add("float", 0);
        dictionary.Add("vector2", 1);
        dictionary.Add("vector3", 2);
        dictionary.Add("color", 3);
        dictionary.Add("rect", 4);
        switchmap11 = dictionary;
    Label_0143:
        if (switchmap11.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        switch (num2)
        {
            case 0:
                goto Label_0175;

            case 1:
                goto Label_0192;

            case 2:
                goto Label_01AF;

            case 3:
                goto Label_01CC;

            case 4:
                goto Label_01E9;
        }
        goto Label_0206;
    Label_0175:
        this.GenerateFloatTargets();
        this.apply = new ApplyTween(this.ApplyFloatTargets);
        goto Label_0206;
    Label_0192:
        this.GenerateVector2Targets();
        this.apply = new ApplyTween(this.ApplyVector2Targets);
        goto Label_0206;
    Label_01AF:
        this.GenerateVector3Targets();
        this.apply = new ApplyTween(this.ApplyVector3Targets);
        goto Label_0206;
    Label_01CC:
        this.GenerateColorTargets();
        this.apply = new ApplyTween(this.ApplyColorTargets);
        goto Label_0206;
    Label_01E9:
        this.GenerateRectTargets();
        this.apply = new ApplyTween(this.ApplyRectTargets);
    Label_0206:
        goto Label_078F;
    Label_020B:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap12 != null)
        {
            goto Label_023B;
        }
        dictionary = new Dictionary<string, int>(1);
        dictionary.Add("to", 0);
        switchmap12 = dictionary;
    Label_023B:
        if (switchmap12.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        if (num2 == null)
        {
            goto Label_0259;
        }
        goto Label_0276;
    Label_0259:
        this.GenerateColorToTargets();
        this.apply = new ApplyTween(this.ApplyColorToTargets);
    Label_0276:
        goto Label_078F;
    Label_027B:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap13 != null)
        {
            goto Label_02AB;
        }
        dictionary = new Dictionary<string, int>(1);
        dictionary.Add("to", 0);
        switchmap13 = dictionary;
    Label_02AB:
        if (switchmap13.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        if (num2 == null)
        {
            goto Label_02C9;
        }
        goto Label_02E6;
    Label_02C9:
        this.GenerateAudioToTargets();
        this.apply = new ApplyTween(this.ApplyAudioToTargets);
    Label_02E6:
        goto Label_078F;
    Label_02EB:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap14 != null)
        {
            goto Label_0333;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("to", 0);
        dictionary.Add("by", 1);
        dictionary.Add("add", 1);
        switchmap14 = dictionary;
    Label_0333:
        if (switchmap14.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        if (num2 == null)
        {
            goto Label_0359;
        }
        if (num2 == 1)
        {
            goto Label_03A8;
        }
        goto Label_03C5;
    Label_0359:
        if (this.tweenArguments.Contains("path") == null)
        {
            goto Label_038B;
        }
        this.GenerateMoveToPathTargets();
        this.apply = new ApplyTween(this.ApplyMoveToPathTargets);
        goto Label_03A3;
    Label_038B:
        this.GenerateMoveToTargets();
        this.apply = new ApplyTween(this.ApplyMoveToTargets);
    Label_03A3:
        goto Label_03C5;
    Label_03A8:
        this.GenerateMoveByTargets();
        this.apply = new ApplyTween(this.ApplyMoveByTargets);
    Label_03C5:
        goto Label_078F;
    Label_03CA:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap15 != null)
        {
            goto Label_0412;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("to", 0);
        dictionary.Add("by", 1);
        dictionary.Add("add", 2);
        switchmap15 = dictionary;
    Label_0412:
        if (switchmap15.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        switch (num2)
        {
            case 0:
                goto Label_043C;

            case 1:
                goto Label_0459;

            case 2:
                goto Label_0476;
        }
        goto Label_0493;
    Label_043C:
        this.GenerateScaleToTargets();
        this.apply = new ApplyTween(this.ApplyScaleToTargets);
        goto Label_0493;
    Label_0459:
        this.GenerateScaleByTargets();
        this.apply = new ApplyTween(this.ApplyScaleToTargets);
        goto Label_0493;
    Label_0476:
        this.GenerateScaleAddTargets();
        this.apply = new ApplyTween(this.ApplyScaleToTargets);
    Label_0493:
        goto Label_078F;
    Label_0498:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap16 != null)
        {
            goto Label_04E0;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("to", 0);
        dictionary.Add("add", 1);
        dictionary.Add("by", 2);
        switchmap16 = dictionary;
    Label_04E0:
        if (switchmap16.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        switch (num2)
        {
            case 0:
                goto Label_050A;

            case 1:
                goto Label_0527;

            case 2:
                goto Label_0544;
        }
        goto Label_0561;
    Label_050A:
        this.GenerateRotateToTargets();
        this.apply = new ApplyTween(this.ApplyRotateToTargets);
        goto Label_0561;
    Label_0527:
        this.GenerateRotateAddTargets();
        this.apply = new ApplyTween(this.ApplyRotateAddTargets);
        goto Label_0561;
    Label_0544:
        this.GenerateRotateByTargets();
        this.apply = new ApplyTween(this.ApplyRotateAddTargets);
    Label_0561:
        goto Label_078F;
    Label_0566:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap17 != null)
        {
            goto Label_05AE;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("position", 0);
        dictionary.Add("scale", 1);
        dictionary.Add("rotation", 2);
        switchmap17 = dictionary;
    Label_05AE:
        if (switchmap17.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        switch (num2)
        {
            case 0:
                goto Label_05D8;

            case 1:
                goto Label_05F5;

            case 2:
                goto Label_0612;
        }
        goto Label_062F;
    Label_05D8:
        this.GenerateShakePositionTargets();
        this.apply = new ApplyTween(this.ApplyShakePositionTargets);
        goto Label_062F;
    Label_05F5:
        this.GenerateShakeScaleTargets();
        this.apply = new ApplyTween(this.ApplyShakeScaleTargets);
        goto Label_062F;
    Label_0612:
        this.GenerateShakeRotationTargets();
        this.apply = new ApplyTween(this.ApplyShakeRotationTargets);
    Label_062F:
        goto Label_078F;
    Label_0634:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap18 != null)
        {
            goto Label_067C;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("position", 0);
        dictionary.Add("rotation", 1);
        dictionary.Add("scale", 2);
        switchmap18 = dictionary;
    Label_067C:
        if (switchmap18.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        switch (num2)
        {
            case 0:
                goto Label_06A6;

            case 1:
                goto Label_06C3;

            case 2:
                goto Label_06E0;
        }
        goto Label_06FD;
    Label_06A6:
        this.GeneratePunchPositionTargets();
        this.apply = new ApplyTween(this.ApplyPunchPositionTargets);
        goto Label_06FD;
    Label_06C3:
        this.GeneratePunchRotationTargets();
        this.apply = new ApplyTween(this.ApplyPunchRotationTargets);
        goto Label_06FD;
    Label_06E0:
        this.GeneratePunchScaleTargets();
        this.apply = new ApplyTween(this.ApplyPunchScaleTargets);
    Label_06FD:
        goto Label_078F;
    Label_0702:
        str2 = this.method;
        if (str2 == null)
        {
            goto Label_078F;
        }
        if (switchmap19 != null)
        {
            goto Label_0732;
        }
        dictionary = new Dictionary<string, int>(1);
        dictionary.Add("to", 0);
        switchmap19 = dictionary;
    Label_0732:
        if (switchmap19.TryGetValue(str2, &num2) == null)
        {
            goto Label_078F;
        }
        if (num2 == null)
        {
            goto Label_0750;
        }
        goto Label_076D;
    Label_0750:
        this.GenerateLookToTargets();
        this.apply = new ApplyTween(this.ApplyLookToTargets);
    Label_076D:
        goto Label_078F;
    Label_0772:
        this.GenerateStabTargets();
        this.apply = new ApplyTween(this.ApplyStabTargets);
    Label_078F:
        return;
    }

    private unsafe void GenerateVector2Targets()
    {
        Vector3 vector;
        Vector3 vector2;
        float num;
        this.vector2s = new Vector2[3];
        *(&(this.vector2s[0])) = (Vector2) this.tweenArguments["from"];
        *(&(this.vector2s[1])) = (Vector2) this.tweenArguments["to"];
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_00F3;
        }
        &vector = new Vector3(&(this.vector2s[0]).x, &(this.vector2s[0]).y, 0f);
        &vector2 = new Vector3(&(this.vector2s[1]).x, &(this.vector2s[1]).y, 0f);
        num = Math.Abs(Vector3.Distance(vector, vector2));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_00F3:
        return;
    }

    private unsafe void GenerateVector3Targets()
    {
        float num;
        this.vector3s = new Vector3[3];
        *(&(this.vector3s[0])) = (Vector3) this.tweenArguments["from"];
        *(&(this.vector3s[1])) = (Vector3) this.tweenArguments["to"];
        if (this.tweenArguments.Contains("speed") == null)
        {
            goto Label_00B7;
        }
        num = Math.Abs(Vector3.Distance(*(&(this.vector3s[0])), *(&(this.vector3s[1]))));
        this.time = num / ((float) this.tweenArguments["speed"]);
    Label_00B7:
        return;
    }

    private void GetEasingFunction()
    {
        EaseType type;
        switch (this.easeType)
        {
            case 0:
                goto Label_0092;

            case 1:
                goto Label_00A9;

            case 2:
                goto Label_00C0;

            case 3:
                goto Label_00D7;

            case 4:
                goto Label_00EE;

            case 5:
                goto Label_0105;

            case 6:
                goto Label_011C;

            case 7:
                goto Label_0133;

            case 8:
                goto Label_014A;

            case 9:
                goto Label_0161;

            case 10:
                goto Label_0178;

            case 11:
                goto Label_018F;

            case 12:
                goto Label_01A6;

            case 13:
                goto Label_01BD;

            case 14:
                goto Label_01D4;

            case 15:
                goto Label_01EB;

            case 0x10:
                goto Label_0202;

            case 0x11:
                goto Label_0219;

            case 0x12:
                goto Label_0230;

            case 0x13:
                goto Label_0247;

            case 20:
                goto Label_025E;

            case 0x15:
                goto Label_0275;

            case 0x16:
                goto Label_028C;

            case 0x17:
                goto Label_02A3;

            case 0x18:
                goto Label_02BA;

            case 0x19:
                goto Label_02D1;

            case 0x1a:
                goto Label_02E8;

            case 0x1b:
                goto Label_02FF;

            case 0x1c:
                goto Label_0316;

            case 0x1d:
                goto Label_032D;

            case 30:
                goto Label_0344;

            case 0x1f:
                goto Label_035B;
        }
        goto Label_0372;
    Label_0092:
        this.ease = new EasingFunction(this.easeInQuad);
        goto Label_0372;
    Label_00A9:
        this.ease = new EasingFunction(this.easeOutQuad);
        goto Label_0372;
    Label_00C0:
        this.ease = new EasingFunction(this.easeInOutQuad);
        goto Label_0372;
    Label_00D7:
        this.ease = new EasingFunction(this.easeInCubic);
        goto Label_0372;
    Label_00EE:
        this.ease = new EasingFunction(this.easeOutCubic);
        goto Label_0372;
    Label_0105:
        this.ease = new EasingFunction(this.easeInOutCubic);
        goto Label_0372;
    Label_011C:
        this.ease = new EasingFunction(this.easeInQuart);
        goto Label_0372;
    Label_0133:
        this.ease = new EasingFunction(this.easeOutQuart);
        goto Label_0372;
    Label_014A:
        this.ease = new EasingFunction(this.easeInOutQuart);
        goto Label_0372;
    Label_0161:
        this.ease = new EasingFunction(this.easeInQuint);
        goto Label_0372;
    Label_0178:
        this.ease = new EasingFunction(this.easeOutQuint);
        goto Label_0372;
    Label_018F:
        this.ease = new EasingFunction(this.easeInOutQuint);
        goto Label_0372;
    Label_01A6:
        this.ease = new EasingFunction(this.easeInSine);
        goto Label_0372;
    Label_01BD:
        this.ease = new EasingFunction(this.easeOutSine);
        goto Label_0372;
    Label_01D4:
        this.ease = new EasingFunction(this.easeInOutSine);
        goto Label_0372;
    Label_01EB:
        this.ease = new EasingFunction(this.easeInExpo);
        goto Label_0372;
    Label_0202:
        this.ease = new EasingFunction(this.easeOutExpo);
        goto Label_0372;
    Label_0219:
        this.ease = new EasingFunction(this.easeInOutExpo);
        goto Label_0372;
    Label_0230:
        this.ease = new EasingFunction(this.easeInCirc);
        goto Label_0372;
    Label_0247:
        this.ease = new EasingFunction(this.easeOutCirc);
        goto Label_0372;
    Label_025E:
        this.ease = new EasingFunction(this.easeInOutCirc);
        goto Label_0372;
    Label_0275:
        this.ease = new EasingFunction(this.linear);
        goto Label_0372;
    Label_028C:
        this.ease = new EasingFunction(this.spring);
        goto Label_0372;
    Label_02A3:
        this.ease = new EasingFunction(this.easeInBounce);
        goto Label_0372;
    Label_02BA:
        this.ease = new EasingFunction(this.easeOutBounce);
        goto Label_0372;
    Label_02D1:
        this.ease = new EasingFunction(this.easeInOutBounce);
        goto Label_0372;
    Label_02E8:
        this.ease = new EasingFunction(this.easeInBack);
        goto Label_0372;
    Label_02FF:
        this.ease = new EasingFunction(this.easeOutBack);
        goto Label_0372;
    Label_0316:
        this.ease = new EasingFunction(this.easeInOutBack);
        goto Label_0372;
    Label_032D:
        this.ease = new EasingFunction(this.easeInElastic);
        goto Label_0372;
    Label_0344:
        this.ease = new EasingFunction(this.easeOutElastic);
        goto Label_0372;
    Label_035B:
        this.ease = new EasingFunction(this.easeInOutElastic);
    Label_0372:
        return;
    }

    public static Hashtable Hash(params object[] args)
    {
        Hashtable hashtable;
        int num;
        hashtable = new Hashtable(((int) args.Length) / 2);
        if ((((int) args.Length) % 2) == null)
        {
            goto Label_0021;
        }
        Debug.LogError("Tween Error: Hash requires an even number of arguments!");
        return null;
    Label_0021:
        num = 0;
        goto Label_003A;
    Label_0028:
        hashtable.Add(args[num], args[num + 1]);
        num += 2;
    Label_003A:
        if (num < (((int) args.Length) - 1))
        {
            goto Label_0028;
        }
        return hashtable;
    }

    public static void Init(GameObject target)
    {
        MoveBy(target, Vector3.zero, 0f);
        return;
    }

    private static unsafe Vector3 Interp(Vector3[] pts, float t)
    {
        int num;
        int num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num = ((int) pts.Length) - 3;
        num2 = Mathf.Min(Mathf.FloorToInt(t * ((float) num)), num - 1);
        num3 = (t * ((float) num)) - ((float) num2);
        vector = *(&(pts[num2]));
        vector2 = *(&(pts[num2 + 1]));
        vector3 = *(&(pts[num2 + 2]));
        vector4 = *(&(pts[num2 + 3]));
        return (0.5f * (((((((-vector + (3f * vector2)) - (3f * vector3)) + vector4) * ((num3 * num3) * num3)) + (((((2f * vector) - (5f * vector2)) + (4f * vector3)) - vector4) * (num3 * num3))) + ((-vector + vector3) * num3)) + (2f * vector2)));
    }

    private void LateUpdate()
    {
        if (this.tweenArguments.Contains("looktarget") == null)
        {
            goto Label_0070;
        }
        if (this.isRunning == null)
        {
            goto Label_0070;
        }
        if ((this.type == "move") != null)
        {
            goto Label_005F;
        }
        if ((this.type == "shake") != null)
        {
            goto Label_005F;
        }
        if ((this.type == "punch") == null)
        {
            goto Label_0070;
        }
    Label_005F:
        LookUpdate(base.gameObject, this.tweenArguments);
    Label_0070:
        return;
    }

    private static void Launch(GameObject target, Hashtable args)
    {
        if (args.Contains("id") != null)
        {
            goto Label_0020;
        }
        args["id"] = GenerateID();
    Label_0020:
        if (args.Contains("target") != null)
        {
            goto Label_003C;
        }
        args["target"] = target;
    Label_003C:
        tweens.Insert(0, args);
        target.AddComponent("iTween");
        return;
    }

    private float linear(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value);
    }

    public static unsafe void LookFrom(GameObject target, Hashtable args)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3? nullable;
        Vector3? nullable2;
        string str;
        Dictionary<string, int> dictionary;
        int num;
        args = CleanArgs(args);
        vector = target.transform.eulerAngles;
        if (args["looktarget"].GetType() != typeof(Transform))
        {
            goto Label_0081;
        }
        nullable = (Vector3?) args["up"];
        target.transform.LookAt((Transform) args["looktarget"], (&nullable.HasValue == null) ? Defaults.up : &nullable.Value);
        goto Label_00E9;
    Label_0081:
        if (args["looktarget"].GetType() != typeof(Vector3))
        {
            goto Label_00E9;
        }
        nullable2 = (Vector3?) args["up"];
        target.transform.LookAt((Vector3) args["looktarget"], (&nullable2.HasValue == null) ? Defaults.up : &nullable2.Value);
    Label_00E9:
        if (args.Contains("axis") == null)
        {
            goto Label_01F8;
        }
        vector2 = target.transform.eulerAngles;
        str = (string) args["axis"];
        if (str == null)
        {
            goto Label_01EC;
        }
        if (switchmap10 != null)
        {
            goto Label_015E;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("x", 0);
        dictionary.Add("y", 1);
        dictionary.Add("z", 2);
        switchmap10 = dictionary;
    Label_015E:
        if (switchmap10.TryGetValue(str, &num) == null)
        {
            goto Label_01EC;
        }
        switch (num)
        {
            case 0:
                goto Label_0189;

            case 1:
                goto Label_01AA;

            case 2:
                goto Label_01CB;
        }
        goto Label_01EC;
    Label_0189:
        &vector2.y = &vector.y;
        &vector2.z = &vector.z;
        goto Label_01EC;
    Label_01AA:
        &vector2.x = &vector.x;
        &vector2.z = &vector.z;
        goto Label_01EC;
    Label_01CB:
        &vector2.x = &vector.x;
        &vector2.y = &vector.y;
    Label_01EC:
        target.transform.eulerAngles = vector2;
    Label_01F8:
        args["rotation"] = (Vector3) vector;
        args["type"] = "rotate";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void LookFrom(GameObject target, Vector3 looktarget, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "looktarget", (Vector3) looktarget, "time", (float) time };
        LookFrom(target, Hash(objArray1));
        return;
    }

    public static unsafe void LookTo(GameObject target, Hashtable args)
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        args = CleanArgs(args);
        if (args.Contains("looktarget") == null)
        {
            goto Label_00C9;
        }
        if (args["looktarget"].GetType() != typeof(Transform))
        {
            goto Label_00C9;
        }
        transform = (Transform) args["looktarget"];
        args["position"] = (Vector3) new Vector3(&transform.position.x, &transform.position.y, &transform.position.z);
        args["rotation"] = (Vector3) new Vector3(&transform.eulerAngles.x, &transform.eulerAngles.y, &transform.eulerAngles.z);
    Label_00C9:
        args["type"] = "look";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void LookTo(GameObject target, Vector3 looktarget, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "looktarget", (Vector3) looktarget, "time", (float) time };
        LookTo(target, Hash(objArray1));
        return;
    }

    public static unsafe void LookUpdate(GameObject target, Hashtable args)
    {
        float num;
        Vector3[] vectorArray;
        Vector3? nullable;
        Vector3? nullable2;
        string str;
        Dictionary<string, int> dictionary;
        int num2;
        CleanArgs(args);
        vectorArray = new Vector3[5];
        if (args.Contains("looktime") == null)
        {
            goto Label_003C;
        }
        num = (float) args["looktime"];
        num *= Defaults.updateTimePercentage;
        goto Label_0076;
    Label_003C:
        if (args.Contains("time") == null)
        {
            goto Label_0070;
        }
        num = ((float) args["time"]) * 0.15f;
        num *= Defaults.updateTimePercentage;
        goto Label_0076;
    Label_0070:
        num = Defaults.updateTime;
    Label_0076:
        *(&(vectorArray[0])) = target.transform.eulerAngles;
        if (args.Contains("looktarget") == null)
        {
            goto Label_0177;
        }
        if (args["looktarget"].GetType() != typeof(Transform))
        {
            goto Label_010A;
        }
        nullable = (Vector3?) args["up"];
        target.transform.LookAt((Transform) args["looktarget"], (&nullable.HasValue == null) ? Defaults.up : &nullable.Value);
        goto Label_0172;
    Label_010A:
        if (args["looktarget"].GetType() != typeof(Vector3))
        {
            goto Label_0182;
        }
        nullable2 = (Vector3?) args["up"];
        target.transform.LookAt((Vector3) args["looktarget"], (&nullable2.HasValue == null) ? Defaults.up : &nullable2.Value);
    Label_0172:
        goto Label_0182;
    Label_0177:
        Debug.LogError("iTween Error: LookUpdate needs a 'looktarget' property!");
        return;
    Label_0182:
        *(&(vectorArray[1])) = target.transform.eulerAngles;
        target.transform.eulerAngles = *(&(vectorArray[0]));
        &(vectorArray[3]).x = Mathf.SmoothDampAngle(&(vectorArray[0]).x, &(vectorArray[1]).x, &&(vectorArray[2]).x, num);
        &(vectorArray[3]).y = Mathf.SmoothDampAngle(&(vectorArray[0]).y, &(vectorArray[1]).y, &&(vectorArray[2]).y, num);
        &(vectorArray[3]).z = Mathf.SmoothDampAngle(&(vectorArray[0]).z, &(vectorArray[1]).z, &&(vectorArray[2]).z, num);
        target.transform.eulerAngles = *(&(vectorArray[3]));
        if (args.Contains("axis") == null)
        {
            goto Label_03CA;
        }
        *(&(vectorArray[4])) = target.transform.eulerAngles;
        str = (string) args["axis"];
        if (str == null)
        {
            goto Label_03B3;
        }
        if (switchmap1C != null)
        {
            goto Label_02E9;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("x", 0);
        dictionary.Add("y", 1);
        dictionary.Add("z", 2);
        switchmap1C = dictionary;
    Label_02E9:
        if (switchmap1C.TryGetValue(str, &num2) == null)
        {
            goto Label_03B3;
        }
        switch (num2)
        {
            case 0:
                goto Label_0314;

            case 1:
                goto Label_0349;

            case 2:
                goto Label_037E;
        }
        goto Label_03B3;
    Label_0314:
        &(vectorArray[4]).y = &(vectorArray[0]).y;
        &(vectorArray[4]).z = &(vectorArray[0]).z;
        goto Label_03B3;
    Label_0349:
        &(vectorArray[4]).x = &(vectorArray[0]).x;
        &(vectorArray[4]).z = &(vectorArray[0]).z;
        goto Label_03B3;
    Label_037E:
        &(vectorArray[4]).x = &(vectorArray[0]).x;
        &(vectorArray[4]).y = &(vectorArray[0]).y;
    Label_03B3:
        target.transform.eulerAngles = *(&(vectorArray[4]));
    Label_03CA:
        return;
    }

    public static void LookUpdate(GameObject target, Vector3 looktarget, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "looktarget", (Vector3) looktarget, "time", (float) time };
        LookUpdate(target, Hash(objArray1));
        return;
    }

    public static void MoveAdd(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "move";
        args["method"] = "add";
        Launch(target, args);
        return;
    }

    public static void MoveAdd(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        MoveAdd(target, Hash(objArray1));
        return;
    }

    public static void MoveBy(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "move";
        args["method"] = "by";
        Launch(target, args);
        return;
    }

    public static void MoveBy(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        MoveBy(target, Hash(objArray1));
        return;
    }

    public static unsafe void MoveFrom(GameObject target, Hashtable args)
    {
        bool flag;
        Vector3[] vectorArray;
        Vector3[] vectorArray2;
        Vector3[] vectorArray3;
        Transform[] transformArray;
        int num;
        Vector3 vector;
        Vector3 vector2;
        Transform transform;
        args = CleanArgs(args);
        if (args.Contains("islocal") == null)
        {
            goto Label_002E;
        }
        flag = (bool) args["islocal"];
        goto Label_0034;
    Label_002E:
        flag = Defaults.isLocal;
    Label_0034:
        if (args.Contains("path") == null)
        {
            goto Label_01DC;
        }
        if (args["path"].GetType() != typeof(Vector3[]))
        {
            goto Label_008C;
        }
        vectorArray3 = (Vector3[]) args["path"];
        vectorArray2 = new Vector3[(int) vectorArray3.Length];
        Array.Copy(vectorArray3, vectorArray2, (int) vectorArray3.Length);
        goto Label_00D8;
    Label_008C:
        transformArray = (Transform[]) args["path"];
        vectorArray2 = new Vector3[(int) transformArray.Length];
        num = 0;
        goto Label_00CD;
    Label_00B0:
        *(&(vectorArray2[num])) = transformArray[num].position;
        num += 1;
    Label_00CD:
        if (num < ((int) transformArray.Length))
        {
            goto Label_00B0;
        }
    Label_00D8:
        if ((*(&(vectorArray2[((int) vectorArray2.Length) - 1])) != target.transform.position) == null)
        {
            goto Label_0192;
        }
        vectorArray = new Vector3[((int) vectorArray2.Length) + 1];
        Array.Copy(vectorArray2, vectorArray, (int) vectorArray2.Length);
        if (flag == null)
        {
            goto Label_014F;
        }
        *(&(vectorArray[((int) vectorArray.Length) - 1])) = target.transform.localPosition;
        target.transform.localPosition = *(&(vectorArray[0]));
        goto Label_0181;
    Label_014F:
        *(&(vectorArray[((int) vectorArray.Length) - 1])) = target.transform.position;
        target.transform.position = *(&(vectorArray[0]));
    Label_0181:
        args["path"] = vectorArray;
        goto Label_01D7;
    Label_0192:
        if (flag == null)
        {
            goto Label_01B4;
        }
        target.transform.localPosition = *(&(vectorArray2[0]));
        goto Label_01CB;
    Label_01B4:
        target.transform.position = *(&(vectorArray2[0]));
    Label_01CB:
        args["path"] = vectorArray2;
    Label_01D7:
        goto Label_0338;
    Label_01DC:
        if (flag == null)
        {
            goto Label_01F7;
        }
        vector = vector2 = target.transform.localPosition;
        goto Label_0207;
    Label_01F7:
        vector = vector2 = target.transform.position;
    Label_0207:
        if (args.Contains("position") == null)
        {
            goto Label_028C;
        }
        if (args["position"].GetType() != typeof(Transform))
        {
            goto Label_0256;
        }
        transform = (Transform) args["position"];
        vector2 = transform.position;
        goto Label_0287;
    Label_0256:
        if (args["position"].GetType() != typeof(Vector3))
        {
            goto Label_0301;
        }
        vector2 = (Vector3) args["position"];
    Label_0287:
        goto Label_0301;
    Label_028C:
        if (args.Contains("x") == null)
        {
            goto Label_02B3;
        }
        &vector2.x = (float) args["x"];
    Label_02B3:
        if (args.Contains("y") == null)
        {
            goto Label_02DA;
        }
        &vector2.y = (float) args["y"];
    Label_02DA:
        if (args.Contains("z") == null)
        {
            goto Label_0301;
        }
        &vector2.z = (float) args["z"];
    Label_0301:
        if (flag == null)
        {
            goto Label_0319;
        }
        target.transform.localPosition = vector2;
        goto Label_0326;
    Label_0319:
        target.transform.position = vector2;
    Label_0326:
        args["position"] = (Vector3) vector;
    Label_0338:
        args["type"] = "move";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void MoveFrom(GameObject target, Vector3 position, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) position, "time", (float) time };
        MoveFrom(target, Hash(objArray1));
        return;
    }

    public static unsafe void MoveTo(GameObject target, Hashtable args)
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        args = CleanArgs(args);
        if (args.Contains("position") == null)
        {
            goto Label_010B;
        }
        if (args["position"].GetType() != typeof(Transform))
        {
            goto Label_010B;
        }
        transform = (Transform) args["position"];
        args["position"] = (Vector3) new Vector3(&transform.position.x, &transform.position.y, &transform.position.z);
        args["rotation"] = (Vector3) new Vector3(&transform.eulerAngles.x, &transform.eulerAngles.y, &transform.eulerAngles.z);
        args["scale"] = (Vector3) new Vector3(&transform.localScale.x, &transform.localScale.y, &transform.localScale.z);
    Label_010B:
        args["type"] = "move";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void MoveTo(GameObject target, Vector3 position, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) position, "time", (float) time };
        MoveTo(target, Hash(objArray1));
        return;
    }

    public static unsafe void MoveUpdate(GameObject target, Hashtable args)
    {
        float num;
        Vector3[] vectorArray;
        bool flag;
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        CleanArgs(args);
        vectorArray = new Vector3[4];
        vector = target.transform.position;
        if (args.Contains("time") == null)
        {
            goto Label_0048;
        }
        num = (float) args["time"];
        num *= Defaults.updateTimePercentage;
        goto Label_004E;
    Label_0048:
        num = Defaults.updateTime;
    Label_004E:
        if (args.Contains("islocal") == null)
        {
            goto Label_0074;
        }
        flag = (bool) args["islocal"];
        goto Label_007A;
    Label_0074:
        flag = Defaults.isLocal;
    Label_007A:
        if (flag == null)
        {
            goto Label_00AD;
        }
        *(&(vectorArray[1])) = vector3 = target.transform.localPosition;
        *(&(vectorArray[0])) = vector3;
        goto Label_00D5;
    Label_00AD:
        *(&(vectorArray[1])) = vector3 = target.transform.position;
        *(&(vectorArray[0])) = vector3;
    Label_00D5:
        if (args.Contains("position") == null)
        {
            goto Label_016E;
        }
        if (args["position"].GetType() != typeof(Transform))
        {
            goto Label_012E;
        }
        transform = (Transform) args["position"];
        *(&(vectorArray[1])) = transform.position;
        goto Label_0169;
    Label_012E:
        if (args["position"].GetType() != typeof(Vector3))
        {
            goto Label_01F2;
        }
        *(&(vectorArray[1])) = (Vector3) args["position"];
    Label_0169:
        goto Label_01F2;
    Label_016E:
        if (args.Contains("x") == null)
        {
            goto Label_019A;
        }
        &(vectorArray[1]).x = (float) args["x"];
    Label_019A:
        if (args.Contains("y") == null)
        {
            goto Label_01C6;
        }
        &(vectorArray[1]).y = (float) args["y"];
    Label_01C6:
        if (args.Contains("z") == null)
        {
            goto Label_01F2;
        }
        &(vectorArray[1]).z = (float) args["z"];
    Label_01F2:
        &(vectorArray[3]).x = Mathf.SmoothDamp(&(vectorArray[0]).x, &(vectorArray[1]).x, &&(vectorArray[2]).x, num);
        &(vectorArray[3]).y = Mathf.SmoothDamp(&(vectorArray[0]).y, &(vectorArray[1]).y, &&(vectorArray[2]).y, num);
        &(vectorArray[3]).z = Mathf.SmoothDamp(&(vectorArray[0]).z, &(vectorArray[1]).z, &&(vectorArray[2]).z, num);
        if (args.Contains("orienttopath") == null)
        {
            goto Label_02D5;
        }
        if (((bool) args["orienttopath"]) == null)
        {
            goto Label_02D5;
        }
        args["looktarget"] = (Vector3) *(&(vectorArray[3]));
    Label_02D5:
        if (args.Contains("looktarget") == null)
        {
            goto Label_02EC;
        }
        LookUpdate(target, args);
    Label_02EC:
        if (flag == null)
        {
            goto Label_030E;
        }
        target.transform.localPosition = *(&(vectorArray[3]));
        goto Label_0325;
    Label_030E:
        target.transform.position = *(&(vectorArray[3]));
    Label_0325:
        if ((target.rigidbody != null) == null)
        {
            goto Label_035C;
        }
        vector2 = target.transform.position;
        target.transform.position = vector;
        target.rigidbody.MovePosition(vector2);
    Label_035C:
        return;
    }

    public static void MoveUpdate(GameObject target, Vector3 position, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) position, "time", (float) time };
        MoveUpdate(target, Hash(objArray1));
        return;
    }

    private void OnDisable()
    {
        this.DisableKinematic();
        return;
    }

    private void OnEnable()
    {
        if (this.isRunning == null)
        {
            goto Label_0011;
        }
        this.EnableKinematic();
    Label_0011:
        if (this.isPaused == null)
        {
            goto Label_0040;
        }
        this.isPaused = 0;
        if (this.delay <= 0f)
        {
            goto Label_0040;
        }
        this.wasPaused = 1;
        this.ResumeDelay();
    Label_0040:
        return;
    }

    private static unsafe Vector3[] PathControlPointGenerator(Vector3[] path)
    {
        Vector3[] vectorArray;
        Vector3[] vectorArray2;
        int num;
        Vector3[] vectorArray3;
        vectorArray = path;
        num = 2;
        vectorArray2 = new Vector3[((int) vectorArray.Length) + num];
        Array.Copy(vectorArray, 0, vectorArray2, 1, (int) vectorArray.Length);
        *(&(vectorArray2[0])) = *(&(vectorArray2[1])) + (*(&(vectorArray2[1])) - *(&(vectorArray2[2])));
        *(&(vectorArray2[((int) vectorArray2.Length) - 1])) = *(&(vectorArray2[((int) vectorArray2.Length) - 2])) + (*(&(vectorArray2[((int) vectorArray2.Length) - 2])) - *(&(vectorArray2[((int) vectorArray2.Length) - 3])));
        if ((*(&(vectorArray2[1])) == *(&(vectorArray2[((int) vectorArray2.Length) - 2]))) == null)
        {
            goto Label_0123;
        }
        vectorArray3 = new Vector3[(int) vectorArray2.Length];
        Array.Copy(vectorArray2, vectorArray3, (int) vectorArray2.Length);
        *(&(vectorArray3[0])) = *(&(vectorArray3[((int) vectorArray3.Length) - 3]));
        *(&(vectorArray3[((int) vectorArray3.Length) - 1])) = *(&(vectorArray3[2]));
        vectorArray2 = new Vector3[(int) vectorArray3.Length];
        Array.Copy(vectorArray3, vectorArray2, (int) vectorArray3.Length);
    Label_0123:
        return vectorArray2;
    }

    public static unsafe float PathLength(Transform[] path)
    {
        Vector3[] vectorArray;
        float num;
        int num2;
        Vector3[] vectorArray2;
        Vector3 vector;
        int num3;
        int num4;
        float num5;
        Vector3 vector2;
        vectorArray = new Vector3[(int) path.Length];
        num = 0f;
        num2 = 0;
        goto Label_002E;
    Label_0016:
        *(&(vectorArray[num2])) = path[num2].position;
        num2 += 1;
    Label_002E:
        if (num2 < ((int) path.Length))
        {
            goto Label_0016;
        }
        vectorArray2 = PathControlPointGenerator(vectorArray);
        vector = Interp(vectorArray2, 0f);
        num3 = ((int) path.Length) * 20;
        num4 = 1;
        goto Label_0084;
    Label_005B:
        num5 = ((float) num4) / ((float) num3);
        vector2 = Interp(vectorArray2, num5);
        num += Vector3.Distance(vector, vector2);
        vector = vector2;
        num4 += 1;
    Label_0084:
        if (num4 <= num3)
        {
            goto Label_005B;
        }
        return num;
    }

    public static float PathLength(Vector3[] path)
    {
        float num;
        Vector3[] vectorArray;
        Vector3 vector;
        int num2;
        int num3;
        float num4;
        Vector3 vector2;
        num = 0f;
        vectorArray = PathControlPointGenerator(path);
        vector = Interp(vectorArray, 0f);
        num2 = ((int) path.Length) * 20;
        num3 = 1;
        goto Label_004E;
    Label_0028:
        num4 = ((float) num3) / ((float) num2);
        vector2 = Interp(vectorArray, num4);
        num += Vector3.Distance(vector, vector2);
        vector = vector2;
        num3 += 1;
    Label_004E:
        if (num3 <= num2)
        {
            goto Label_0028;
        }
        return num;
    }

    public static void Pause()
    {
        int num;
        Hashtable hashtable;
        GameObject obj2;
        num = 0;
        goto Label_0033;
    Label_0007:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        Pause(obj2);
        num += 1;
    Label_0033:
        if (num < tweens.Count)
        {
            goto Label_0007;
        }
        return;
    }

    public static void Pause(string type)
    {
        ArrayList list;
        int num;
        Hashtable hashtable;
        GameObject obj2;
        int num2;
        list = new ArrayList();
        num = 0;
        goto Label_0040;
    Label_000D:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        list.Insert(list.Count, obj2);
        num += 1;
    Label_0040:
        if (num < tweens.Count)
        {
            goto Label_000D;
        }
        num2 = 0;
        goto Label_0071;
    Label_0058:
        Pause((GameObject) list[num2], type);
        num2 += 1;
    Label_0071:
        if (num2 < list.Count)
        {
            goto Label_0058;
        }
        return;
    }

    public static void Pause(GameObject target)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_0069;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (tween.delay <= 0f)
        {
            goto Label_0057;
        }
        tween.delay -= Time.time - tween.delayStarted;
        tween.StopCoroutine("TweenDelay");
    Label_0057:
        tween.isPaused = 1;
        tween.enabled = 0;
        num += 1;
    Label_0069:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void Pause(GameObject target, bool includechildren)
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        Pause(target);
        if (includechildren == null)
        {
            goto Label_0057;
        }
        enumerator = target.transform.GetEnumerator();
    Label_0018:
        try
        {
            goto Label_0035;
        Label_001D:
            transform = (Transform) enumerator.Current;
            Pause(transform.gameObject, 1);
        Label_0035:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001D;
            }
            goto Label_0057;
        }
        finally
        {
        Label_0045:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0050;
            }
        Label_0050:
            disposable.Dispose();
        }
    Label_0057:
        return;
    }

    public static void Pause(GameObject target, string type)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        string str;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_00A3;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_009F;
        }
        if (tween.delay <= 0f)
        {
            goto Label_0091;
        }
        tween.delay -= Time.time - tween.delayStarted;
        tween.StopCoroutine("TweenDelay");
    Label_0091:
        tween.isPaused = 1;
        tween.enabled = 0;
    Label_009F:
        num += 1;
    Label_00A3:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void Pause(GameObject target, string type, bool includechildren)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        string str;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_00A3;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_009F;
        }
        if (tween.delay <= 0f)
        {
            goto Label_0091;
        }
        tween.delay -= Time.time - tween.delayStarted;
        tween.StopCoroutine("TweenDelay");
    Label_0091:
        tween.isPaused = 1;
        tween.enabled = 0;
    Label_009F:
        num += 1;
    Label_00A3:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        if (includechildren == null)
        {
            goto Label_0107;
        }
        enumerator = target.transform.GetEnumerator();
    Label_00BF:
        try
        {
            goto Label_00E0;
        Label_00C4:
            transform = (Transform) enumerator.Current;
            Pause(transform.gameObject, type, 1);
        Label_00E0:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00C4;
            }
            goto Label_0107;
        }
        finally
        {
        Label_00F1:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00FF;
            }
        Label_00FF:
            disposable.Dispose();
        }
    Label_0107:
        return;
    }

    public static unsafe Vector3 PointOnPath(Transform[] path, float percent)
    {
        Vector3[] vectorArray;
        int num;
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0028;
    Label_0010:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0028:
        if (num < ((int) path.Length))
        {
            goto Label_0010;
        }
        return Interp(PathControlPointGenerator(vectorArray), percent);
    }

    public static Vector3 PointOnPath(Vector3[] path, float percent)
    {
        return Interp(PathControlPointGenerator(path), percent);
    }

    private float punch(float amplitude, float value)
    {
        float num;
        float num2;
        num = 9f;
        if (value != 0f)
        {
            goto Label_0017;
        }
        return 0f;
    Label_0017:
        if (value != 1f)
        {
            goto Label_0028;
        }
        return 0f;
    Label_0028:
        num2 = 0.3f;
        num = (num2 / 6.283185f) * Mathf.Asin(0f);
        return ((amplitude * Mathf.Pow(2f, -10f * value)) * Mathf.Sin((((value * 1f) - num) * 6.283185f) / num2));
    }

    public static void PunchPosition(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "punch";
        args["method"] = "position";
        args["easetype"] = (EaseType) 0x20;
        Launch(target, args);
        return;
    }

    public static void PunchPosition(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        PunchPosition(target, Hash(objArray1));
        return;
    }

    public static void PunchRotation(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "punch";
        args["method"] = "rotation";
        args["easetype"] = (EaseType) 0x20;
        Launch(target, args);
        return;
    }

    public static void PunchRotation(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        PunchRotation(target, Hash(objArray1));
        return;
    }

    public static void PunchScale(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "punch";
        args["method"] = "scale";
        args["easetype"] = (EaseType) 0x20;
        Launch(target, args);
        return;
    }

    public static void PunchScale(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        PunchScale(target, Hash(objArray1));
        return;
    }

    public static unsafe void PutOnPath(GameObject target, Transform[] path, float percent)
    {
        Vector3[] vectorArray;
        int num;
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0028;
    Label_0010:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0028:
        if (num < ((int) path.Length))
        {
            goto Label_0010;
        }
        target.transform.position = Interp(PathControlPointGenerator(vectorArray), percent);
        return;
    }

    public static void PutOnPath(GameObject target, Vector3[] path, float percent)
    {
        target.transform.position = Interp(PathControlPointGenerator(path), percent);
        return;
    }

    public static unsafe void PutOnPath(Transform target, Transform[] path, float percent)
    {
        Vector3[] vectorArray;
        int num;
        vectorArray = new Vector3[(int) path.Length];
        num = 0;
        goto Label_0028;
    Label_0010:
        *(&(vectorArray[num])) = path[num].position;
        num += 1;
    Label_0028:
        if (num < ((int) path.Length))
        {
            goto Label_0010;
        }
        target.position = Interp(PathControlPointGenerator(vectorArray), percent);
        return;
    }

    public static void PutOnPath(Transform target, Vector3[] path, float percent)
    {
        target.position = Interp(PathControlPointGenerator(path), percent);
        return;
    }

    public static unsafe Rect RectUpdate(Rect currentValue, Rect targetValue, float speed)
    {
        Rect rect;
        &rect = new Rect(FloatUpdate(&currentValue.x, &targetValue.x, speed), FloatUpdate(&currentValue.y, &targetValue.y, speed), FloatUpdate(&currentValue.width, &targetValue.width, speed), FloatUpdate(&currentValue.height, &targetValue.height, speed));
        return rect;
    }

    public static void Resume()
    {
        int num;
        Hashtable hashtable;
        GameObject obj2;
        num = 0;
        goto Label_0033;
    Label_0007:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        Resume(obj2);
        num += 1;
    Label_0033:
        if (num < tweens.Count)
        {
            goto Label_0007;
        }
        return;
    }

    public static void Resume(string type)
    {
        ArrayList list;
        int num;
        Hashtable hashtable;
        GameObject obj2;
        int num2;
        list = new ArrayList();
        num = 0;
        goto Label_0040;
    Label_000D:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        list.Insert(list.Count, obj2);
        num += 1;
    Label_0040:
        if (num < tweens.Count)
        {
            goto Label_000D;
        }
        num2 = 0;
        goto Label_0071;
    Label_0058:
        Resume((GameObject) list[num2], type);
        num2 += 1;
    Label_0071:
        if (num2 < list.Count)
        {
            goto Label_0058;
        }
        return;
    }

    public static void Resume(GameObject target)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_002E;
    Label_001A:
        tween = (iTween) componentArray2[num];
        tween.enabled = 1;
        num += 1;
    Label_002E:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void Resume(GameObject target, bool includechildren)
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        Resume(target);
        if (includechildren == null)
        {
            goto Label_0057;
        }
        enumerator = target.transform.GetEnumerator();
    Label_0018:
        try
        {
            goto Label_0035;
        Label_001D:
            transform = (Transform) enumerator.Current;
            Resume(transform.gameObject, 1);
        Label_0035:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001D;
            }
            goto Label_0057;
        }
        finally
        {
        Label_0045:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0050;
            }
        Label_0050:
            disposable.Dispose();
        }
    Label_0057:
        return;
    }

    public static void Resume(GameObject target, string type)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        string str;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_0068;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_0064;
        }
        tween.enabled = 1;
    Label_0064:
        num += 1;
    Label_0068:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void Resume(GameObject target, string type, bool includechildren)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        string str;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_0068;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_0064;
        }
        tween.enabled = 1;
    Label_0064:
        num += 1;
    Label_0068:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        if (includechildren == null)
        {
            goto Label_00CC;
        }
        enumerator = target.transform.GetEnumerator();
    Label_0084:
        try
        {
            goto Label_00A5;
        Label_0089:
            transform = (Transform) enumerator.Current;
            Resume(transform.gameObject, type, 1);
        Label_00A5:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0089;
            }
            goto Label_00CC;
        }
        finally
        {
        Label_00B6:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C4;
            }
        Label_00C4:
            disposable.Dispose();
        }
    Label_00CC:
        return;
    }

    private void ResumeDelay()
    {
        base.StartCoroutine("TweenDelay");
        return;
    }

    private void RetrieveArgs()
    {
        Hashtable hashtable;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = tweens.GetEnumerator();
    Label_000B:
        try
        {
            goto Label_0048;
        Label_0010:
            hashtable = (Hashtable) enumerator.Current;
            if ((((GameObject) hashtable["target"]) == base.gameObject) == null)
            {
                goto Label_0048;
            }
            this.tweenArguments = hashtable;
            goto Label_0053;
        Label_0048:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0010;
            }
        Label_0053:
            goto Label_006A;
        }
        finally
        {
        Label_0058:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0063;
            }
        Label_0063:
            disposable.Dispose();
        }
    Label_006A:
        this.id = (string) this.tweenArguments["id"];
        this.type = (string) this.tweenArguments["type"];
        this._name = (string) this.tweenArguments["name"];
        this.method = (string) this.tweenArguments["method"];
        if (this.tweenArguments.Contains("time") == null)
        {
            goto Label_010B;
        }
        this.time = (float) this.tweenArguments["time"];
        goto Label_0116;
    Label_010B:
        this.time = Defaults.time;
    Label_0116:
        if ((base.rigidbody != null) == null)
        {
            goto Label_012E;
        }
        this.physics = 1;
    Label_012E:
        if (this.tweenArguments.Contains("delay") == null)
        {
            goto Label_0163;
        }
        this.delay = (float) this.tweenArguments["delay"];
        goto Label_016E;
    Label_0163:
        this.delay = Defaults.delay;
    Label_016E:
        if (this.tweenArguments.Contains("namedcolorvalue") == null)
        {
            goto Label_0218;
        }
        if (this.tweenArguments["namedcolorvalue"].GetType() != typeof(NamedValueColor))
        {
            goto Label_01C7;
        }
        this.namedcolorvalue = (int) this.tweenArguments["namedcolorvalue"];
        goto Label_0213;
    Label_01C7:
        try
        {
            this.namedcolorvalue = (int) Enum.Parse(typeof(NamedValueColor), (string) this.tweenArguments["namedcolorvalue"], 1);
            goto Label_0213;
        }
        catch
        {
        Label_01FC:
            Debug.LogWarning("iTween: Unsupported namedcolorvalue supplied! Default will be used.");
            this.namedcolorvalue = 0;
            goto Label_0213;
        }
    Label_0213:
        goto Label_0223;
    Label_0218:
        this.namedcolorvalue = Defaults.namedColorValue;
    Label_0223:
        if (this.tweenArguments.Contains("looptype") == null)
        {
            goto Label_02CD;
        }
        if (this.tweenArguments["looptype"].GetType() != typeof(LoopType))
        {
            goto Label_027C;
        }
        this.loopType = (int) this.tweenArguments["looptype"];
        goto Label_02C8;
    Label_027C:
        try
        {
            this.loopType = (int) Enum.Parse(typeof(LoopType), (string) this.tweenArguments["looptype"], 1);
            goto Label_02C8;
        }
        catch
        {
        Label_02B1:
            Debug.LogWarning("iTween: Unsupported loopType supplied! Default will be used.");
            this.loopType = 0;
            goto Label_02C8;
        }
    Label_02C8:
        goto Label_02D4;
    Label_02CD:
        this.loopType = 0;
    Label_02D4:
        if (this.tweenArguments.Contains("easetype") == null)
        {
            goto Label_0382;
        }
        if (this.tweenArguments["easetype"].GetType() != typeof(EaseType))
        {
            goto Label_032D;
        }
        this.easeType = (int) this.tweenArguments["easetype"];
        goto Label_037D;
    Label_032D:
        try
        {
            this.easeType = (int) Enum.Parse(typeof(EaseType), (string) this.tweenArguments["easetype"], 1);
            goto Label_037D;
        }
        catch
        {
        Label_0362:
            Debug.LogWarning("iTween: Unsupported easeType supplied! Default will be used.");
            this.easeType = Defaults.easeType;
            goto Label_037D;
        }
    Label_037D:
        goto Label_038D;
    Label_0382:
        this.easeType = Defaults.easeType;
    Label_038D:
        if (this.tweenArguments.Contains("space") == null)
        {
            goto Label_043B;
        }
        if (this.tweenArguments["space"].GetType() != typeof(Space))
        {
            goto Label_03E6;
        }
        this.space = (int) this.tweenArguments["space"];
        goto Label_0436;
    Label_03E6:
        try
        {
            this.space = (int) Enum.Parse(typeof(Space), (string) this.tweenArguments["space"], 1);
            goto Label_0436;
        }
        catch
        {
        Label_041B:
            Debug.LogWarning("iTween: Unsupported space supplied! Default will be used.");
            this.space = Defaults.space;
            goto Label_0436;
        }
    Label_0436:
        goto Label_0446;
    Label_043B:
        this.space = Defaults.space;
    Label_0446:
        if (this.tweenArguments.Contains("islocal") == null)
        {
            goto Label_047B;
        }
        this.isLocal = (bool) this.tweenArguments["islocal"];
        goto Label_0486;
    Label_047B:
        this.isLocal = Defaults.isLocal;
    Label_0486:
        if (this.tweenArguments.Contains("ignoretimescale") == null)
        {
            goto Label_04BB;
        }
        this.useRealTime = (bool) this.tweenArguments["ignoretimescale"];
        goto Label_04C6;
    Label_04BB:
        this.useRealTime = Defaults.useRealTime;
    Label_04C6:
        this.GetEasingFunction();
        return;
    }

    public static void RotateAdd(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "rotate";
        args["method"] = "add";
        Launch(target, args);
        return;
    }

    public static void RotateAdd(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        RotateAdd(target, Hash(objArray1));
        return;
    }

    public static void RotateBy(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "rotate";
        args["method"] = "by";
        Launch(target, args);
        return;
    }

    public static void RotateBy(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        RotateBy(target, Hash(objArray1));
        return;
    }

    public static unsafe void RotateFrom(GameObject target, Hashtable args)
    {
        Vector3 vector;
        Vector3 vector2;
        bool flag;
        Transform transform;
        args = CleanArgs(args);
        if (args.Contains("islocal") == null)
        {
            goto Label_002E;
        }
        flag = (bool) args["islocal"];
        goto Label_0034;
    Label_002E:
        flag = Defaults.isLocal;
    Label_0034:
        if (flag == null)
        {
            goto Label_004D;
        }
        vector = vector2 = target.transform.localEulerAngles;
        goto Label_005B;
    Label_004D:
        vector = vector2 = target.transform.eulerAngles;
    Label_005B:
        if (args.Contains("rotation") == null)
        {
            goto Label_00DC;
        }
        if (args["rotation"].GetType() != typeof(Transform))
        {
            goto Label_00A7;
        }
        transform = (Transform) args["rotation"];
        vector2 = transform.eulerAngles;
        goto Label_00D7;
    Label_00A7:
        if (args["rotation"].GetType() != typeof(Vector3))
        {
            goto Label_0151;
        }
        vector2 = (Vector3) args["rotation"];
    Label_00D7:
        goto Label_0151;
    Label_00DC:
        if (args.Contains("x") == null)
        {
            goto Label_0103;
        }
        &vector2.x = (float) args["x"];
    Label_0103:
        if (args.Contains("y") == null)
        {
            goto Label_012A;
        }
        &vector2.y = (float) args["y"];
    Label_012A:
        if (args.Contains("z") == null)
        {
            goto Label_0151;
        }
        &vector2.z = (float) args["z"];
    Label_0151:
        if (flag == null)
        {
            goto Label_0168;
        }
        target.transform.localEulerAngles = vector2;
        goto Label_0174;
    Label_0168:
        target.transform.eulerAngles = vector2;
    Label_0174:
        args["rotation"] = (Vector3) vector;
        args["type"] = "rotate";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void RotateFrom(GameObject target, Vector3 rotation, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "rotation", (Vector3) rotation, "time", (float) time };
        RotateFrom(target, Hash(objArray1));
        return;
    }

    public static unsafe void RotateTo(GameObject target, Hashtable args)
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        args = CleanArgs(args);
        if (args.Contains("rotation") == null)
        {
            goto Label_010B;
        }
        if (args["rotation"].GetType() != typeof(Transform))
        {
            goto Label_010B;
        }
        transform = (Transform) args["rotation"];
        args["position"] = (Vector3) new Vector3(&transform.position.x, &transform.position.y, &transform.position.z);
        args["rotation"] = (Vector3) new Vector3(&transform.eulerAngles.x, &transform.eulerAngles.y, &transform.eulerAngles.z);
        args["scale"] = (Vector3) new Vector3(&transform.localScale.x, &transform.localScale.y, &transform.localScale.z);
    Label_010B:
        args["type"] = "rotate";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void RotateTo(GameObject target, Vector3 rotation, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "rotation", (Vector3) rotation, "time", (float) time };
        RotateTo(target, Hash(objArray1));
        return;
    }

    public static unsafe void RotateUpdate(GameObject target, Hashtable args)
    {
        bool flag;
        float num;
        Vector3[] vectorArray;
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        CleanArgs(args);
        vectorArray = new Vector3[4];
        vector = target.transform.eulerAngles;
        if (args.Contains("time") == null)
        {
            goto Label_0048;
        }
        num = (float) args["time"];
        num *= Defaults.updateTimePercentage;
        goto Label_004E;
    Label_0048:
        num = Defaults.updateTime;
    Label_004E:
        if (args.Contains("islocal") == null)
        {
            goto Label_0074;
        }
        flag = (bool) args["islocal"];
        goto Label_007A;
    Label_0074:
        flag = Defaults.isLocal;
    Label_007A:
        if (flag == null)
        {
            goto Label_009C;
        }
        *(&(vectorArray[0])) = target.transform.localEulerAngles;
        goto Label_00B3;
    Label_009C:
        *(&(vectorArray[0])) = target.transform.eulerAngles;
    Label_00B3:
        if (args.Contains("rotation") == null)
        {
            goto Label_0147;
        }
        if (args["rotation"].GetType() != typeof(Transform))
        {
            goto Label_010C;
        }
        transform = (Transform) args["rotation"];
        *(&(vectorArray[1])) = transform.eulerAngles;
        goto Label_0147;
    Label_010C:
        if (args["rotation"].GetType() != typeof(Vector3))
        {
            goto Label_0147;
        }
        *(&(vectorArray[1])) = (Vector3) args["rotation"];
    Label_0147:
        &(vectorArray[3]).x = Mathf.SmoothDampAngle(&(vectorArray[0]).x, &(vectorArray[1]).x, &&(vectorArray[2]).x, num);
        &(vectorArray[3]).y = Mathf.SmoothDampAngle(&(vectorArray[0]).y, &(vectorArray[1]).y, &&(vectorArray[2]).y, num);
        &(vectorArray[3]).z = Mathf.SmoothDampAngle(&(vectorArray[0]).z, &(vectorArray[1]).z, &&(vectorArray[2]).z, num);
        if (flag == null)
        {
            goto Label_020B;
        }
        target.transform.localEulerAngles = *(&(vectorArray[3]));
        goto Label_0222;
    Label_020B:
        target.transform.eulerAngles = *(&(vectorArray[3]));
    Label_0222:
        if ((target.rigidbody != null) == null)
        {
            goto Label_025E;
        }
        vector2 = target.transform.eulerAngles;
        target.transform.eulerAngles = vector;
        target.rigidbody.MoveRotation(Quaternion.Euler(vector2));
    Label_025E:
        return;
    }

    public static void RotateUpdate(GameObject target, Vector3 rotation, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "rotation", (Vector3) rotation, "time", (float) time };
        RotateUpdate(target, Hash(objArray1));
        return;
    }

    public static void ScaleAdd(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "scale";
        args["method"] = "add";
        Launch(target, args);
        return;
    }

    public static void ScaleAdd(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        ScaleAdd(target, Hash(objArray1));
        return;
    }

    public static void ScaleBy(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "scale";
        args["method"] = "by";
        Launch(target, args);
        return;
    }

    public static void ScaleBy(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        ScaleBy(target, Hash(objArray1));
        return;
    }

    public static unsafe void ScaleFrom(GameObject target, Hashtable args)
    {
        Vector3 vector;
        Vector3 vector2;
        Transform transform;
        args = CleanArgs(args);
        vector = vector2 = target.transform.localScale;
        if (args.Contains("scale") == null)
        {
            goto Label_0097;
        }
        if (args["scale"].GetType() != typeof(Transform))
        {
            goto Label_0062;
        }
        transform = (Transform) args["scale"];
        vector2 = transform.localScale;
        goto Label_0092;
    Label_0062:
        if (args["scale"].GetType() != typeof(Vector3))
        {
            goto Label_010C;
        }
        vector2 = (Vector3) args["scale"];
    Label_0092:
        goto Label_010C;
    Label_0097:
        if (args.Contains("x") == null)
        {
            goto Label_00BE;
        }
        &vector2.x = (float) args["x"];
    Label_00BE:
        if (args.Contains("y") == null)
        {
            goto Label_00E5;
        }
        &vector2.y = (float) args["y"];
    Label_00E5:
        if (args.Contains("z") == null)
        {
            goto Label_010C;
        }
        &vector2.z = (float) args["z"];
    Label_010C:
        target.transform.localScale = vector2;
        args["scale"] = (Vector3) vector;
        args["type"] = "scale";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void ScaleFrom(GameObject target, Vector3 scale, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "scale", (Vector3) scale, "time", (float) time };
        ScaleFrom(target, Hash(objArray1));
        return;
    }

    public static unsafe void ScaleTo(GameObject target, Hashtable args)
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        args = CleanArgs(args);
        if (args.Contains("scale") == null)
        {
            goto Label_010B;
        }
        if (args["scale"].GetType() != typeof(Transform))
        {
            goto Label_010B;
        }
        transform = (Transform) args["scale"];
        args["position"] = (Vector3) new Vector3(&transform.position.x, &transform.position.y, &transform.position.z);
        args["rotation"] = (Vector3) new Vector3(&transform.eulerAngles.x, &transform.eulerAngles.y, &transform.eulerAngles.z);
        args["scale"] = (Vector3) new Vector3(&transform.localScale.x, &transform.localScale.y, &transform.localScale.z);
    Label_010B:
        args["type"] = "scale";
        args["method"] = "to";
        Launch(target, args);
        return;
    }

    public static void ScaleTo(GameObject target, Vector3 scale, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "scale", (Vector3) scale, "time", (float) time };
        ScaleTo(target, Hash(objArray1));
        return;
    }

    public static unsafe void ScaleUpdate(GameObject target, Hashtable args)
    {
        float num;
        Vector3[] vectorArray;
        Transform transform;
        Vector3 vector;
        CleanArgs(args);
        vectorArray = new Vector3[4];
        if (args.Contains("time") == null)
        {
            goto Label_003C;
        }
        num = (float) args["time"];
        num *= Defaults.updateTimePercentage;
        goto Label_0042;
    Label_003C:
        num = Defaults.updateTime;
    Label_0042:
        *(&(vectorArray[1])) = vector = target.transform.localScale;
        *(&(vectorArray[0])) = vector;
        if (args.Contains("scale") == null)
        {
            goto Label_00FF;
        }
        if (args["scale"].GetType() != typeof(Transform))
        {
            goto Label_00BF;
        }
        transform = (Transform) args["scale"];
        *(&(vectorArray[1])) = transform.localScale;
        goto Label_00FA;
    Label_00BF:
        if (args["scale"].GetType() != typeof(Vector3))
        {
            goto Label_0183;
        }
        *(&(vectorArray[1])) = (Vector3) args["scale"];
    Label_00FA:
        goto Label_0183;
    Label_00FF:
        if (args.Contains("x") == null)
        {
            goto Label_012B;
        }
        &(vectorArray[1]).x = (float) args["x"];
    Label_012B:
        if (args.Contains("y") == null)
        {
            goto Label_0157;
        }
        &(vectorArray[1]).y = (float) args["y"];
    Label_0157:
        if (args.Contains("z") == null)
        {
            goto Label_0183;
        }
        &(vectorArray[1]).z = (float) args["z"];
    Label_0183:
        &(vectorArray[3]).x = Mathf.SmoothDamp(&(vectorArray[0]).x, &(vectorArray[1]).x, &&(vectorArray[2]).x, num);
        &(vectorArray[3]).y = Mathf.SmoothDamp(&(vectorArray[0]).y, &(vectorArray[1]).y, &&(vectorArray[2]).y, num);
        &(vectorArray[3]).z = Mathf.SmoothDamp(&(vectorArray[0]).z, &(vectorArray[1]).z, &&(vectorArray[2]).z, num);
        target.transform.localScale = *(&(vectorArray[3]));
        return;
    }

    public static void ScaleUpdate(GameObject target, Vector3 scale, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "scale", (Vector3) scale, "time", (float) time };
        ScaleUpdate(target, Hash(objArray1));
        return;
    }

    public static void ShakePosition(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "shake";
        args["method"] = "position";
        Launch(target, args);
        return;
    }

    public static void ShakePosition(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        ShakePosition(target, Hash(objArray1));
        return;
    }

    public static void ShakeRotation(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "shake";
        args["method"] = "rotation";
        Launch(target, args);
        return;
    }

    public static void ShakeRotation(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        ShakeRotation(target, Hash(objArray1));
        return;
    }

    public static void ShakeScale(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "shake";
        args["method"] = "scale";
        Launch(target, args);
        return;
    }

    public static void ShakeScale(GameObject target, Vector3 amount, float time)
    {
        object[] objArray1;
        objArray1 = new object[] { "amount", (Vector3) amount, "time", (float) time };
        ShakeScale(target, Hash(objArray1));
        return;
    }

    private float spring(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = ((Mathf.Sin((value * 3.141593f) * (0.2f + (((2.5f * value) * value) * value))) * Mathf.Pow(1f - value, 2.2f)) + value) * (1f + (1.2f * (1f - value)));
        return (start + ((end - start) * value));
    }

    public static void Stab(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        args["type"] = "stab";
        Launch(target, args);
        return;
    }

    public static void Stab(GameObject target, AudioClip audioclip, float delay)
    {
        object[] objArray1;
        objArray1 = new object[] { "audioclip", audioclip, "delay", (float) delay };
        Stab(target, Hash(objArray1));
        return;
    }

    [DebuggerHidden]
    private IEnumerator Start()
    {
        _Start_c__Iterator4 iterator;
        iterator = new _Start_c__Iterator4();
        iterator.f__this = this;
        return iterator;
    }

    public static void Stop()
    {
        int num;
        Hashtable hashtable;
        GameObject obj2;
        num = 0;
        goto Label_0033;
    Label_0007:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        Stop(obj2);
        num += 1;
    Label_0033:
        if (num < tweens.Count)
        {
            goto Label_0007;
        }
        tweens.Clear();
        return;
    }

    public static void Stop(string type)
    {
        ArrayList list;
        int num;
        Hashtable hashtable;
        GameObject obj2;
        int num2;
        list = new ArrayList();
        num = 0;
        goto Label_0040;
    Label_000D:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        list.Insert(list.Count, obj2);
        num += 1;
    Label_0040:
        if (num < tweens.Count)
        {
            goto Label_000D;
        }
        num2 = 0;
        goto Label_0071;
    Label_0058:
        Stop((GameObject) list[num2], type);
        num2 += 1;
    Label_0071:
        if (num2 < list.Count)
        {
            goto Label_0058;
        }
        return;
    }

    public static void Stop(GameObject target)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_002D;
    Label_001A:
        tween = (iTween) componentArray2[num];
        tween.Dispose();
        num += 1;
    Label_002D:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void Stop(GameObject target, bool includechildren)
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        Stop(target);
        if (includechildren == null)
        {
            goto Label_0057;
        }
        enumerator = target.transform.GetEnumerator();
    Label_0018:
        try
        {
            goto Label_0035;
        Label_001D:
            transform = (Transform) enumerator.Current;
            Stop(transform.gameObject, 1);
        Label_0035:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001D;
            }
            goto Label_0057;
        }
        finally
        {
        Label_0045:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0050;
            }
        Label_0050:
            disposable.Dispose();
        }
    Label_0057:
        return;
    }

    public static void Stop(GameObject target, string type)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        string str;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_0067;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_0063;
        }
        tween.Dispose();
    Label_0063:
        num += 1;
    Label_0067:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void Stop(GameObject target, string type, bool includechildren)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        string str;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_0067;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if (((tween.type + tween.method).Substring(0, type.Length).ToLower() == type.ToLower()) == null)
        {
            goto Label_0063;
        }
        tween.Dispose();
    Label_0063:
        num += 1;
    Label_0067:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        if (includechildren == null)
        {
            goto Label_00CB;
        }
        enumerator = target.transform.GetEnumerator();
    Label_0083:
        try
        {
            goto Label_00A4;
        Label_0088:
            transform = (Transform) enumerator.Current;
            Stop(transform.gameObject, type, 1);
        Label_00A4:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0088;
            }
            goto Label_00CB;
        }
        finally
        {
        Label_00B5:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C3;
            }
        Label_00C3:
            disposable.Dispose();
        }
    Label_00CB:
        return;
    }

    public static void StopByName(string name)
    {
        ArrayList list;
        int num;
        Hashtable hashtable;
        GameObject obj2;
        int num2;
        list = new ArrayList();
        num = 0;
        goto Label_0040;
    Label_000D:
        hashtable = (Hashtable) tweens[num];
        obj2 = (GameObject) hashtable["target"];
        list.Insert(list.Count, obj2);
        num += 1;
    Label_0040:
        if (num < tweens.Count)
        {
            goto Label_000D;
        }
        num2 = 0;
        goto Label_0071;
    Label_0058:
        StopByName((GameObject) list[num2], name);
        num2 += 1;
    Label_0071:
        if (num2 < list.Count)
        {
            goto Label_0058;
        }
        return;
    }

    public static void StopByName(GameObject target, string name)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_003E;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if ((tween._name == name) == null)
        {
            goto Label_003A;
        }
        tween.Dispose();
    Label_003A:
        num += 1;
    Label_003E:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        return;
    }

    public static void StopByName(GameObject target, string name, bool includechildren)
    {
        Component[] componentArray;
        iTween tween;
        Component[] componentArray2;
        int num;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        componentArray2 = target.GetComponents(typeof(iTween));
        num = 0;
        goto Label_003E;
    Label_001A:
        tween = (iTween) componentArray2[num];
        if ((tween._name == name) == null)
        {
            goto Label_003A;
        }
        tween.Dispose();
    Label_003A:
        num += 1;
    Label_003E:
        if (num < ((int) componentArray2.Length))
        {
            goto Label_001A;
        }
        if (includechildren == null)
        {
            goto Label_00A2;
        }
        enumerator = target.transform.GetEnumerator();
    Label_005A:
        try
        {
            goto Label_007B;
        Label_005F:
            transform = (Transform) enumerator.Current;
            StopByName(transform.gameObject, name, 1);
        Label_007B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_005F;
            }
            goto Label_00A2;
        }
        finally
        {
        Label_008C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_009A;
            }
        Label_009A:
            disposable.Dispose();
        }
    Label_00A2:
        return;
    }

    private void TweenComplete()
    {
        this.isRunning = 0;
        if (this.percentage <= 0.5f)
        {
            goto Label_0027;
        }
        this.percentage = 1f;
        goto Label_0032;
    Label_0027:
        this.percentage = 0f;
    Label_0032:
        this.apply();
        if ((this.type == "value") == null)
        {
            goto Label_005D;
        }
        this.CallBack("onupdate");
    Label_005D:
        if (this.loopType != null)
        {
            goto Label_0073;
        }
        this.Dispose();
        goto Label_0079;
    Label_0073:
        this.TweenLoop();
    Label_0079:
        this.CallBack("oncomplete");
        return;
    }

    [DebuggerHidden]
    private IEnumerator TweenDelay()
    {
        _TweenDelay_c__Iterator2 iterator;
        iterator = new _TweenDelay_c__Iterator2();
        iterator.f__this = this;
        return iterator;
    }

    private void TweenLoop()
    {
        LoopType type;
        this.DisableKinematic();
        type = this.loopType;
        if (type == 1)
        {
            goto Label_0020;
        }
        if (type == 2)
        {
            goto Label_0052;
        }
        goto Label_007D;
    Label_0020:
        this.percentage = 0f;
        this.runningTime = 0f;
        this.apply();
        base.StartCoroutine("TweenRestart");
        goto Label_007D;
    Label_0052:
        this.reverse = this.reverse == 0;
        this.runningTime = 0f;
        base.StartCoroutine("TweenRestart");
    Label_007D:
        return;
    }

    [DebuggerHidden]
    private IEnumerator TweenRestart()
    {
        _TweenRestart_c__Iterator3 iterator;
        iterator = new _TweenRestart_c__Iterator3();
        iterator.f__this = this;
        return iterator;
    }

    private void TweenStart()
    {
        this.CallBack("onstart");
        if (this.loop != null)
        {
            goto Label_0022;
        }
        this.ConflictCheck();
        this.GenerateTargets();
    Label_0022:
        if ((this.type == "stab") == null)
        {
            goto Label_004D;
        }
        this.audioSource.PlayOneShot(this.audioSource.clip);
    Label_004D:
        if ((this.type == "move") != null)
        {
            goto Label_00E0;
        }
        if ((this.type == "scale") != null)
        {
            goto Label_00E0;
        }
        if ((this.type == "rotate") != null)
        {
            goto Label_00E0;
        }
        if ((this.type == "punch") != null)
        {
            goto Label_00E0;
        }
        if ((this.type == "shake") != null)
        {
            goto Label_00E0;
        }
        if ((this.type == "curve") != null)
        {
            goto Label_00E0;
        }
        if ((this.type == "look") == null)
        {
            goto Label_00E6;
        }
    Label_00E0:
        this.EnableKinematic();
    Label_00E6:
        this.isRunning = 1;
        return;
    }

    private void TweenUpdate()
    {
        this.apply();
        this.CallBack("onupdate");
        this.UpdatePercentage();
        return;
    }

    private void Update()
    {
        if (this.isRunning == null)
        {
            goto Label_0068;
        }
        if (this.physics != null)
        {
            goto Label_0068;
        }
        if (this.reverse != null)
        {
            goto Label_0047;
        }
        if (this.percentage >= 1f)
        {
            goto Label_003C;
        }
        this.TweenUpdate();
        goto Label_0042;
    Label_003C:
        this.TweenComplete();
    Label_0042:
        goto Label_0068;
    Label_0047:
        if (this.percentage <= 0f)
        {
            goto Label_0062;
        }
        this.TweenUpdate();
        goto Label_0068;
    Label_0062:
        this.TweenComplete();
    Label_0068:
        return;
    }

    private void UpdatePercentage()
    {
        if (this.useRealTime == null)
        {
            goto Label_0029;
        }
        this.runningTime += Time.realtimeSinceStartup - this.lastRealTime;
        goto Label_003B;
    Label_0029:
        this.runningTime += Time.deltaTime;
    Label_003B:
        if (this.reverse == null)
        {
            goto Label_0064;
        }
        this.percentage = 1f - (this.runningTime / this.time);
        goto Label_0077;
    Label_0064:
        this.percentage = this.runningTime / this.time;
    Label_0077:
        this.lastRealTime = Time.realtimeSinceStartup;
        return;
    }

    public static void ValueTo(GameObject target, Hashtable args)
    {
        args = CleanArgs(args);
        if (args.Contains("onupdate") == null)
        {
            goto Label_0038;
        }
        if (args.Contains("from") == null)
        {
            goto Label_0038;
        }
        if (args.Contains("to") != null)
        {
            goto Label_0043;
        }
    Label_0038:
        Debug.LogError("iTween Error: ValueTo() requires an 'onupdate' callback function and a 'from' and 'to' property.  The supplied 'onupdate' callback must accept a single argument that is the same type as the supplied 'from' and 'to' properties!");
        return;
    Label_0043:
        args["type"] = "value";
        if (args["from"].GetType() != typeof(Vector2))
        {
            goto Label_0087;
        }
        args["method"] = "vector2";
        goto Label_0162;
    Label_0087:
        if (args["from"].GetType() != typeof(Vector3))
        {
            goto Label_00BB;
        }
        args["method"] = "vector3";
        goto Label_0162;
    Label_00BB:
        if (args["from"].GetType() != typeof(Rect))
        {
            goto Label_00EF;
        }
        args["method"] = "rect";
        goto Label_0162;
    Label_00EF:
        if (args["from"].GetType() != typeof(float))
        {
            goto Label_0123;
        }
        args["method"] = "float";
        goto Label_0162;
    Label_0123:
        if (args["from"].GetType() != typeof(Color))
        {
            goto Label_0157;
        }
        args["method"] = "color";
        goto Label_0162;
    Label_0157:
        Debug.LogError("iTween Error: ValueTo() only works with interpolating Vector3s, Vector2s, floats, ints, Rects and Colors!");
        return;
    Label_0162:
        if (args.Contains("easetype") != null)
        {
            goto Label_0184;
        }
        args.Add("easetype", (EaseType) 0x15);
    Label_0184:
        Launch(target, args);
        return;
    }

    public static Vector2 Vector2Update(Vector2 currentValue, Vector2 targetValue, float speed)
    {
        Vector2 vector;
        vector = targetValue - currentValue;
        currentValue += (vector * speed) * Time.deltaTime;
        return currentValue;
    }

    public static Vector3 Vector3Update(Vector3 currentValue, Vector3 targetValue, float speed)
    {
        Vector3 vector;
        vector = targetValue - currentValue;
        currentValue += (vector * speed) * Time.deltaTime;
        return currentValue;
    }

    [CompilerGenerated]
    private sealed class _Start_c__Iterator4 : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal object _current;
        internal int _PC;
        internal iTween f__this;

        public _Start_c__Iterator4()
        {
            base..ctor();
            return;
        }

        [DebuggerHidden]
        public void Dispose()
        {
            this._PC = -1;
            return;
        }

        public bool MoveNext()
        {
            uint num;
            bool flag;
            num = this._PC;
            this._PC = -1;
            switch (num)
            {
                case 0:
                    goto Label_0021;

                case 1:
                    goto Label_0058;
            }
            goto Label_006A;
        Label_0021:
            if (this.f__this.delay <= 0f)
            {
                goto Label_0058;
            }
            this._current = this.f__this.StartCoroutine("TweenDelay");
            this._PC = 1;
            goto Label_006C;
        Label_0058:
            this.f__this.TweenStart();
            this._PC = -1;
        Label_006A:
            return 0;
        Label_006C:
            return 1;
            return flag;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this._current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this._current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class _TweenDelay_c__Iterator2 : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal object _current;
        internal int _PC;
        internal iTween f__this;

        public _TweenDelay_c__Iterator2()
        {
            base..ctor();
            return;
        }

        [DebuggerHidden]
        public void Dispose()
        {
            this._PC = -1;
            return;
        }

        public bool MoveNext()
        {
            uint num;
            bool flag;
            num = this._PC;
            this._PC = -1;
            switch (num)
            {
                case 0:
                    goto Label_0021;

                case 1:
                    goto Label_0053;
            }
            goto Label_0081;
        Label_0021:
            this.f__this.delayStarted = Time.time;
            this._current = new WaitForSeconds(this.f__this.delay);
            this._PC = 1;
            goto Label_0083;
        Label_0053:
            if (this.f__this.wasPaused == null)
            {
                goto Label_007A;
            }
            this.f__this.wasPaused = 0;
            this.f__this.TweenStart();
        Label_007A:
            this._PC = -1;
        Label_0081:
            return 0;
        Label_0083:
            return 1;
            return flag;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this._current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this._current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class _TweenRestart_c__Iterator3 : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal object _current;
        internal int _PC;
        internal iTween f__this;

        public _TweenRestart_c__Iterator3()
        {
            base..ctor();
            return;
        }

        [DebuggerHidden]
        public void Dispose()
        {
            this._PC = -1;
            return;
        }

        public bool MoveNext()
        {
            uint num;
            bool flag;
            num = this._PC;
            this._PC = -1;
            switch (num)
            {
                case 0:
                    goto Label_0021;

                case 1:
                    goto Label_0068;
            }
            goto Label_0086;
        Label_0021:
            if (this.f__this.delay <= 0f)
            {
                goto Label_0068;
            }
            this.f__this.delayStarted = Time.time;
            this._current = new WaitForSeconds(this.f__this.delay);
            this._PC = 1;
            goto Label_0088;
        Label_0068:
            this.f__this.loop = 1;
            this.f__this.TweenStart();
            this._PC = -1;
        Label_0086:
            return 0;
        Label_0088:
            return 1;
            return flag;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this._current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this._current;
            }
        }
    }

    private delegate void ApplyTween();

    private class CRSpline
    {
        public Vector3[] pts;

        public CRSpline(params Vector3[] pts)
        {
            base..ctor();
            this.pts = new Vector3[(int) pts.Length];
            Array.Copy(pts, this.pts, (int) pts.Length);
            return;
        }

        public unsafe Vector3 Interp(float t)
        {
            int num;
            int num2;
            float num3;
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            Vector3 vector4;
            num = ((int) this.pts.Length) - 3;
            num2 = Mathf.Min(Mathf.FloorToInt(t * ((float) num)), num - 1);
            num3 = (t * ((float) num)) - ((float) num2);
            vector = *(&(this.pts[num2]));
            vector2 = *(&(this.pts[num2 + 1]));
            vector3 = *(&(this.pts[num2 + 2]));
            vector4 = *(&(this.pts[num2 + 3]));
            return (0.5f * (((((((-vector + (3f * vector2)) - (3f * vector3)) + vector4) * ((num3 * num3) * num3)) + (((((2f * vector) - (5f * vector2)) + (4f * vector3)) - vector4) * (num3 * num3))) + ((-vector + vector3) * num3)) + (2f * vector2)));
        }
    }

    public static class Defaults
    {
        public static int cameraFadeDepth;
        public static Color color;
        public static float delay;
        public static iTween.EaseType easeType;
        public static bool isLocal;
        public static float lookAhead;
        public static float lookSpeed;
        public static iTween.LoopType loopType;
        public static iTween.NamedValueColor namedColorValue;
        public static bool orientToPath;
        public static Space space;
        public static float time;
        public static Vector3 up;
        public static float updateTime;
        public static float updateTimePercentage;
        public static bool useRealTime;

        static Defaults()
        {
            time = 1f;
            delay = 0f;
            namedColorValue = 0;
            loopType = 0;
            easeType = 0x10;
            lookSpeed = 3f;
            isLocal = 0;
            space = 1;
            orientToPath = 0;
            color = Color.white;
            updateTimePercentage = 0.05f;
            updateTime = 1f * updateTimePercentage;
            cameraFadeDepth = 0xf423f;
            lookAhead = 0.05f;
            useRealTime = 0;
            up = Vector3.up;
            return;
        }
    }

    public enum EaseType
    {
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic,
        easeInQuart,
        easeOutQuart,
        easeInOutQuart,
        easeInQuint,
        easeOutQuint,
        easeInOutQuint,
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInExpo,
        easeOutExpo,
        easeInOutExpo,
        easeInCirc,
        easeOutCirc,
        easeInOutCirc,
        linear,
        spring,
        easeInBounce,
        easeOutBounce,
        easeInOutBounce,
        easeInBack,
        easeOutBack,
        easeInOutBack,
        easeInElastic,
        easeOutElastic,
        easeInOutElastic,
        punch
    }

    private delegate float EasingFunction(float start, float end, float value);

    public enum LoopType
    {
        none,
        loop,
        pingPong
    }

    public enum NamedValueColor
    {
        _Color,
        _SpecColor,
        _Emission,
        _ReflectColor
    }
}

