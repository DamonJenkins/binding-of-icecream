using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class InputData
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;

    public KeyCode Jump;
    public KeyCode ShootR;
    public KeyCode ShootL;
    public KeyCode ShootUp;
    public KeyCode ShootDown;


}

[System.Serializable]
public struct BulletParams
{
    public float MoveSpeed;
    public float Range;
    public int Damage;
    public List<Effect> Effects;
}

[System.Serializable]
public class CharaData
{

    //public int charaset;
    public float hp = 500;
    public float dmg;
    public float spd;
    public int guntype = 1;

}

public class PlayerCtrl : MonoBehaviour
{
    public CharaData playerdata;
    public InputData m_Input;
    //Shoot
    public BulletTest BulletPrefab;
    private int bulletType = 0;

    private Vector2 direction = Vector2.right;

    private float[] timers = { 0.0f, 0.0f, 0.0f };
    [SerializeField]
    private float[] timerStarts = { 1.0f, 1.0f, 1.0f };
    [SerializeField]
    private BulletParams[] Bullets;
    [SerializeField]
    private float[] ammoMax;
    private float[] ammoCurrent;
    [SerializeField]
    private float[] ammoRegenRate;
    [SerializeField]
    private float[] ammoConsumption;


    
    // Start is called before the first frame update
    void Start()
    {
        ammoCurrent = new float[ammoMax.Length];
        for(int i = 0; i < ammoMax.Length; i++)
        {
            ammoCurrent[i] = ammoMax[i];
        }

    }
    //void switchGun(int gun);
   
    void FireBullet(KeyCode dir)
    {
        if (ammoCurrent[bulletType] <= ammoConsumption[bulletType] || timers[bulletType] >= 0) return;

        ammoCurrent[bulletType] -= ammoConsumption[bulletType];
        timers[bulletType] = timerStarts[bulletType];

        // DIRECTION
        if (dir == m_Input.ShootR)
        {
            direction = Vector2.right;
        }
        else if (dir == m_Input.ShootL)
        {
            direction = Vector2.left;
        }
        else if (dir == m_Input.ShootUp)
        {
            direction = Vector2.up;
        }
        else if (dir == m_Input.ShootDown)
        {
            direction = Vector2.down;
        }

        // CREATE
        var bullet = Instantiate(BulletPrefab, transform.position, transform.rotation, transform);

    }
    // Update is called once per frame
    void Update()
    {
        //switch gun
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletType = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulletType = 2;
        }
      
        // SHOOT
        if (Input.GetKeyDown(m_Input.ShootR))
        {
            FireBullet(m_Input.ShootR);
        }

        if (Input.GetKeyDown(m_Input.ShootL))
        {
            FireBullet(m_Input.ShootL);
        }
        if (Input.GetKeyDown(m_Input.ShootUp))
        {
            FireBullet(m_Input.ShootUp);
        }
        if (Input.GetKeyDown(m_Input.ShootDown))
        {

            FireBullet(m_Input.ShootDown);
        }

        for (int i = 0; i < 3; i++) {
            timers[i] -= Time.deltaTime;
        }

    }

    public BulletParams GetCurrentBulletType()
    {
        return Bullets[bulletType];
    }

    public Vector2 GetShotDirection()
    {
        return direction;
    }

}
