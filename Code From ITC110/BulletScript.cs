using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GhostEnemy")
        {
            Destroy(other.gameObject);  // destroy bad guy
            Destroy(gameObject);  // destroy SELF so this bullet doesn't fly through the whole level and kill ALL the bad guys (OP)
        }
    }
}
