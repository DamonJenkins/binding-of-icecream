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
    public BulletScript BulletPrefab;
    public GameObject Cherry;
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
    [SerializeField]
    private float[] ammoRegenDelay;

    [SerializeField]
    private Sprite[] dirSprites;

    //ammo bar
    [SerializeField]
    public Image beambar, machinegunbar, riflebar; 
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
        if (ammoCurrent[bulletType] < ammoConsumption[bulletType] || timers[bulletType] >= 0) return;

        ammoCurrent[bulletType] -= ammoConsumption[bulletType];
        timers[bulletType] = timerStarts[bulletType];

        // CREATE
        if (bulletType != 1)
        {
            var bullet = Instantiate(BulletPrefab, GetComponentInChildren<SpriteRenderer>().transform.position, transform.rotation, transform);
        }
        
         else
        {
            Vector3 firespread = GetComponentInChildren<SpriteRenderer>().transform.position;
            firespread.x += Random.Range(-0.3f, 0.3f);
            firespread.y += Random.Range(-0.3f, 0.3f);
            Vector3 fireangle = GetComponentInChildren<SpriteRenderer>().transform.rotation.eulerAngles;
            fireangle.x += Random.Range(-0.4f, 0.4f);
            fireangle.y += Random.Range(-0.4f, 0.4f);

            var bullet = Instantiate(BulletPrefab, firespread,Quaternion.Euler(firespread), transform);
        }
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

        GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        ) * velThisFrame * 50.0f);

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
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            bulletType = 3;
        }

        // DIRECTION
        if (Input.GetButton("FireX"))
        {
            direction = (Vector2.right * Input.GetAxis("FireX")).normalized;

            //if(bulletType == 1)
            //{
            //   direction.y += Random.Range(-0.4f,0.4f);
            //    //direction = direction.normalized;
            //}
            if (bulletType == 1)
            {
                Quaternion spreadangle = Quaternion.Euler(0.0f, 0.0f, Random.Range(-10.0f, 10.0f));
                direction = spreadangle * direction;
                //direction.x += Random.Range(-0.4f, 0.4f);
                //direction = direction.normalized;
            }
            if (bulletType != 3)
            {
                FireBullet();
            }
            else
            {
                spawnCherry();
            }
        }
        if (Input.GetButton("FireY"))
        {
            direction = (Vector2.up * Input.GetAxis("FireY")).normalized;
            if (bulletType == 1)
            {
                Quaternion spreadangle = Quaternion.Euler(0.0f, 0.0f, Random.Range(-10.0f, 10.0f));
                direction = spreadangle * direction;
                //direction.x += Random.Range(-0.4f, 0.4f);
                //direction = direction.normalized;
            }
            if (bulletType != 3)
            {
                FireBullet();
            }
            else
            {
                spawnCherry();
            }
        }

        if (Input.GetButton("Horizontal"))
        {
            GetComponentInChildren<SpriteRenderer>().sprite = dirSprites[1];
            GetComponentInChildren<SpriteRenderer>().flipX = Input.GetAxis("Horizontal") < 0.0f;
        }
        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0.0f)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = dirSprites[0];
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().sprite = dirSprites[2];
            }
        }

        for (int i = 0; i < 3; i++) {
            timers[i] -= Time.deltaTime;
            if( timers[i] < -ammoRegenDelay[i])
            {
                ammoCurrent[i] += (ammoRegenRate[i] * Time.deltaTime * 0.5f);
                ammoCurrent[i] = Mathf.Min(ammoMax[i], ammoCurrent[i]);
            }
        }
        //ammo hud test
        beambar.fillAmount = ammoCurrent[0] / ammoMax[0];
        machinegunbar.fillAmount = ammoCurrent[1] / ammoMax[1];
        riflebar.fillAmount = ammoCurrent[2] / ammoMax[2];
        

    }

    public BulletParams GetCurrentBulletType()
    {
        return Bullets[bulletType];
    }

    public Vector2 GetShotDirection()
    {
        return direction;
    }

    public void gotBoomed()
    {
        playerdata.hp -= 100;
    }

    public void spawnCherry()
    {
        Cherry = Instantiate(Cherry, transform.position, transform.rotation, transform);
        Destroy(Cherry, 2.1f);
        Cherry oofcherry = new Cherry(transform.position, 2.0f);
    }
}
