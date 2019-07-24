using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BulletParams
{
    public float MoveSpeed;
    public float Range;
    public int Damage;
    public List<Effect> Effects;
}

public class BulletScript : MonoBehaviour
{

    public BulletParams bulletInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
