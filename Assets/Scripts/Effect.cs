using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    float TimeLeft;

    public void Update(EnemyScript Enemy) {
        TimeLeft -= Time.deltaTime;
    }

    public Effect(float Duration){
        TimeLeft = Duration;
    }

    public float GetDuration(){
        return TimeLeft;
    }

    public virtual void OnDestroy()
    {
        
    }

}
