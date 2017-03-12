using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoor : MonoBehaviour {

    bool open = false;
    public GameObject door;

    void OnCollisionEnter(Collision collision)
    {
        print(door);
        if(collision.gameObject.CompareTag("arrow"))
        {
            if(!open)
            {
                open = true;
                door.GetComponent<OpenDoor>().OpenTheDoor();
            }
        }
    }

}
