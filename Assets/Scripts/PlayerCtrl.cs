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
    public Effect[] Effects;
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
    private float[] timerStarts = { 1.0f, 1.0f, 1.0f }; // fire rate
    [SerializeField]
    private BulletParams[] Bullets; // set of different guns
    // ammo data
    [SerializeField]
    private float[] ammoMax;
    [SerializeField]
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
   
    void FireBullet()
    {
        if (ammoCurrent[bulletType] <= ammoConsumption[bulletType] || timers[bulletType] >= 0) return;

        ammoCurrent[bulletType] -= ammoConsumption[bulletType];
        timers[bulletType] = timerStarts[bulletType];

        // CREATE
        var bullet = Instantiate(BulletPrefab, GetComponentInChildren<SpriteRenderer>().transform.position, transform.rotation, transform);

    }
    // Update is called once per frame
    void Update()
    {
        //Movement

        float velThisFrame = playerdata.spd;

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            velThisFrame *= 0.707f;
        }

        GetComponentInChildren<Rigidbody2D>().velocity = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        ) * velThisFrame;

        //switch gun
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //dot(beam)
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

        // DIRECTION
        if (Input.GetButton("FireX"))
        {
            direction = (Vector2.right * Input.GetAxis("FireX")).normalized;
            FireBullet();
        }
        if (Input.GetButton("FireY"))
        {
            direction = (Vector2.up * Input.GetAxis("FireY")).normalized;
            FireBullet();
        }

        for (int i = 0; i < 3; i++) {
            timers[i] -= Time.deltaTime;
            if (i != bulletType){
                ammoCurrent[i] += ammoRegenRate[i] * Time.deltaTime;
                ammoCurrent[i] = Mathf.Min(ammoMax[i], ammoCurrent[i]);
            }
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
