using System;

public interface ISpriteAnimatable
{
    bool StepAnim(float time);

    ISpriteAnimatable next { get; set; }

    ISpriteAnimatable prev { get; set; }
}

