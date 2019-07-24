using System.Collections;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Cherry : Effect
{
    
    Vector2 position;
    float radius = 2.2f;
    bool boomed = false;
    public Cherry(Vector3 CherryPos,float duration) : base (duration)
    {
        position.x = CherryPos.x;
        position.y = CherryPos.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //void Boom()
    //(
        
    //}
}
