using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameManager gManager;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        open = (GameObject.FindWithTag("Enemy") == null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ass");
        if (open) {
            gManager.ChangeRoom();
        }
    }
}
