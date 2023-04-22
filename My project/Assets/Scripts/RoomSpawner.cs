using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int openSide;

    //1 bot //2 tot //3 left //4 right
    private RoomTemp roomTemp;
    private int rand;
    [HideInInspector]public bool spawned=false;
    void Start()
    {
        roomTemp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        Invoke("Spawner", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawner()
    {
        if(!spawned)
        {
            switch (openSide)
            {
                case 1:
                    rand = Random.Range(0, roomTemp.botRooms.Length);
                    Instantiate(roomTemp.botRooms[rand], transform.position, roomTemp.botRooms[rand].transform.rotation);

                    break;
                case 2:
                    rand = Random.Range(0, roomTemp.topRooms.Length);
                    Instantiate(roomTemp.topRooms[rand], transform.position, roomTemp.topRooms[rand].transform.rotation);

                    break;
                case 3:
                    rand = Random.Range(0, roomTemp.leftRooms.Length);
                    Instantiate(roomTemp.leftRooms[rand], transform.position, roomTemp.leftRooms[rand].transform.rotation);

                    break;
                case 4:
                    rand = Random.Range(0, roomTemp.rightRooms.Length);
                    Instantiate(roomTemp.rightRooms[rand], transform.position, roomTemp.rightRooms[rand].transform.rotation);

                    break;
            }
            spawned = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {

            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Debug.Log(roomTemp.closedRoom);
               Instantiate(roomTemp.closedRoom, transform.position, Quaternion.identity);                   
               Destroy(gameObject);

            }
            spawned = true;
        }
    }
}
