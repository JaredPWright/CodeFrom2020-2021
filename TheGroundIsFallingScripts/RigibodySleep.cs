using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodySleep : MonoBehaviour
{
    Rigidbody rb;

    [Header("Set in Inspector")]
    public float fallVelocity = -1.0f;
    public float playerContactDropTime = 2.5f;
    public float platformContactDropTime = 5.0f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.Sleep();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("I've been hit!!!");

        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit me");
            Invoke("BeginMayhem", playerContactDropTime);
        }
        else if(other.gameObject.CompareTag("DangerPlatform"))
        {
            Debug.Log("Platform hit me");
            Invoke("BeginMayhem", platformContactDropTime + KingSpleef.addDropTime);

            KingSpleef.addDropTime += 1.0f;
        }
    }

    void BeginMayhem()
    {
        Debug.Log("In Begin Mayhem");
        rb.velocity = new Vector3(0, fallVelocity, 0);
        rb.useGravity = true;
        Debug.Log("Velocity added");
    }
}
