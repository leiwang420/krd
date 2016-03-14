using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpriteAnimationPump : MonoBehaviour
{
    private static float _timeScale;
    public static float animationPumpInterval;
    protected static ISpriteAnimatable cur;
    private static float elapsed;
    protected static ISpriteAnimatable head;
    private static SpriteAnimationPump instance;
    private static bool isPaused;
    private static ISpriteAnimatable next;
    protected static bool pumpIsDone;
    protected static bool pumpIsRunning;
    private static float startTime;
    private static float time;
    private static float timePaused;

    static SpriteAnimationPump()
    {
        _timeScale = 1f;
        pumpIsDone = 1;
        animationPumpInterval = 0.03333f;
        return;
    }

    public SpriteAnimationPump()
    {
        base..ctor();
        return;
    }

    public static void Add(ISpriteAnimatable s)
    {
        if (head == null)
        {
            goto Label_002B;
        }
        s.next = head;
        head.prev = s;
        head = s;
        goto Label_003B;
    Label_002B:
        head = s;
        Instance.StartAnimationPump();
    Label_003B:
        return;
    }

    [DebuggerHidden]
    protected static IEnumerator AnimationPump()
    {
        <AnimationPump>c__Iterator1 iterator;
        iterator = new <AnimationPump>c__Iterator1();
        return iterator;
    }

    private void Awake()
    {
        _timeScale = 1f;
        isPaused = 0;
        pumpIsRunning = 0;
        pumpIsDone = 1;
        instance = this;
        return;
    }

    private void OnApplicationPause(bool paused)
    {
        float num;
        if (paused == null)
        {
            goto Label_001F;
        }
        if (isPaused != null)
        {
            goto Label_001F;
        }
        timePaused = Time.realtimeSinceStartup;
        goto Label_0047;
    Label_001F:
        if (paused != null)
        {
            goto Label_0047;
        }
        if (isPaused == null)
        {
            goto Label_0047;
        }
        num = Time.realtimeSinceStartup - timePaused;
        startTime += num;
    Label_0047:
        isPaused = paused;
        return;
    }

    public void OnDestroy()
    {
        head = null;
        cur = null;
        next = null;
        instance = null;
        return;
    }

    [DebuggerHidden]
    protected IEnumerator PumpStarter()
    {
        <PumpStarter>c__Iterator0 iterator;
        iterator = new <PumpStarter>c__Iterator0();
        iterator.<>f__this = this;
        return iterator;
    }

    public static void Remove(ISpriteAnimatable s)
    {
        if (head != s)
        {
            goto Label_002A;
        }
        head = s.next;
        if (head != null)
        {
            goto Label_007E;
        }
        StopAnimationPump();
        goto Label_007E;
    Label_002A:
        if (s.next == null)
        {
            goto Label_0067;
        }
        if (s.prev == null)
        {
            goto Label_0051;
        }
        s.prev.next = s.next;
    Label_0051:
        s.next.prev = s.prev;
        goto Label_007E;
    Label_0067:
        if (s.prev == null)
        {
            goto Label_007E;
        }
        s.prev.next = null;
    Label_007E:
        s.next = null;
        s.prev = null;
        return;
    }

    public void StartAnimationPump()
    {
        if (pumpIsRunning != null)
        {
            goto Label_001D;
        }
        pumpIsRunning = 1;
        base.StartCoroutine(this.PumpStarter());
    Label_001D:
        return;
    }

    public static void StopAnimationPump()
    {
    }

    public static SpriteAnimationPump Instance
    {
        get
        {
            GameObject obj2;
            if ((instance == null) == null)
            {
                goto Label_0035;
            }
            obj2 = new GameObject("SpriteAnimationPump");
            instance = (SpriteAnimationPump) obj2.AddComponent(typeof(SpriteAnimationPump));
        Label_0035:
            return instance;
        }
    }

    public bool IsRunning
    {
        get
        {
            return pumpIsRunning;
        }
    }

    public static float timeScale
    {
        get
        {
            return _timeScale;
        }
        set
        {
            _timeScale = Mathf.Max(0f, value);
            return;
        }
    }

    [CompilerGenerated]
    private sealed class <AnimationPump>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;

        public <AnimationPump>c__Iterator1()
        {
            base..ctor();
            return;
        }

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
            return;
        }

        public bool MoveNext()
        {
            uint num;
            bool flag;
            num = this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    goto Label_0021;

                case 1:
                    goto Label_0091;
            }
            goto Label_0114;
        Label_0021:
            SpriteAnimationPump.startTime = Time.realtimeSinceStartup;
            SpriteAnimationPump.pumpIsDone = 0;
            goto Label_00FD;
        Label_0036:
            if (SpriteAnimationPump.isPaused != null)
            {
                goto Label_004F;
            }
            if (Time.timeScale == 0f)
            {
                goto Label_0068;
            }
        Label_004F:
            if (SpriteAnimationPump.isPaused == null)
            {
                goto Label_007E;
            }
            if (Time.timeScale == 0f)
            {
                goto Label_007E;
            }
        Label_0068:
            SpriteAnimationPump.instance.OnApplicationPause(Time.timeScale == 0f);
        Label_007E:
            this.$current = null;
            this.$PC = 1;
            goto Label_0116;
        Label_0091:
            SpriteAnimationPump.time = Time.realtimeSinceStartup;
            SpriteAnimationPump.elapsed = (SpriteAnimationPump.time - SpriteAnimationPump.startTime) * SpriteAnimationPump._timeScale;
            SpriteAnimationPump.startTime = SpriteAnimationPump.time;
            SpriteAnimationPump.cur = SpriteAnimationPump.head;
            goto Label_00F3;
        Label_00CA:
            SpriteAnimationPump.next = SpriteAnimationPump.cur.next;
            SpriteAnimationPump.cur.StepAnim(SpriteAnimationPump.elapsed);
            SpriteAnimationPump.cur = SpriteAnimationPump.next;
        Label_00F3:
            if (SpriteAnimationPump.cur != null)
            {
                goto Label_00CA;
            }
        Label_00FD:
            if (SpriteAnimationPump.pumpIsRunning != null)
            {
                goto Label_0036;
            }
            SpriteAnimationPump.pumpIsDone = 1;
            this.$PC = -1;
        Label_0114:
            return 0;
        Label_0116:
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
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PumpStarter>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpriteAnimationPump <>f__this;

        public <PumpStarter>c__Iterator0()
        {
            base..ctor();
            return;
        }

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
            return;
        }

        public bool MoveNext()
        {
            uint num;
            bool flag;
            num = this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    goto Label_0021;

                case 1:
                    goto Label_0039;
            }
            goto Label_005B;
        Label_0021:
            goto Label_0039;
        Label_0026:
            this.$current = null;
            this.$PC = 1;
            goto Label_005D;
        Label_0039:
            if (SpriteAnimationPump.pumpIsDone == null)
            {
                goto Label_0026;
            }
            this.<>f__this.StartCoroutine(SpriteAnimationPump.AnimationPump());
            this.$PC = -1;
        Label_005B:
            return 0;
        Label_005D:
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
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}

