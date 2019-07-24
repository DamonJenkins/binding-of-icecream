using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> roomPrefabs;
    [SerializeField]
    private GameObject currentRoom;
    private int currRoomNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom() {
        if (currRoomNumber < roomPrefabs.Count)
        {
            Destroy(currentRoom);
            currentRoom = Instantiate(roomPrefabs[++currRoomNumber]);
        }
        else {
            //TODO: Win
        }
    }
}
