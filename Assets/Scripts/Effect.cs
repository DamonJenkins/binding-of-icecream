using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    protected float TimeLeft;
    protected GameObject owner;

    public void Update() {
        TimeLeft -= Time.deltaTime;
        Debug.Log(TimeLeft);
    }

    public Effect(float Duration, GameObject _owner){
        TimeLeft = Duration;
        SetOwner(_owner);
    }

    public float GetDuration(){
        return TimeLeft;
    }

    public void SetOwner(GameObject _owner)
    {
        owner = _owner;
    }

    public GameObject GetOwner()
    {
        return owner;
    }

    public virtual void OnDestroy()
    {
        
    }

}
