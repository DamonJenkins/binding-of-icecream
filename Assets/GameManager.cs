﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> roomPrefabs;
    private GameObject currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom() {
        Destroy(currentRoom);
        currentRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
    }
}
