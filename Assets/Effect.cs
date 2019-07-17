using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    float TimeLeft;

    public void Update(EnemyScript Enemy) {
        TimeLeft -= Time.deltaTime;
    }

    public Effect(float Duration)
    {
        TimeLeft = Duration;
    }

    public float GetDuration()
    {
        return TimeLeft;
    }

}
