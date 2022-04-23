using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorM : MonoBehaviour

    
{
    public GameObject door;
    public bool doorA=false;
    void Start()
    {
        
    }

    void Update()
    {
        if (doorA)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, door.transform.position.y +10, door.transform.position.z), Time.deltaTime / 5);

        }
    }
   public void openDoor()
    {
        doorA = true;
    }
}
