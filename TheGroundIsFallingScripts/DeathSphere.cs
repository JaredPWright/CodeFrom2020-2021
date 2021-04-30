using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSphere : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject player;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FreezeRay", 2.0f, 2.0f);
    }

    void FreezeRay()
    {
        float randHitChanceX = Random.Range(0, 20);
        float randHitChanceY = Random.Range(0, 20);
        float randHitChanceZ = Random.Range(0, 20);

        Vector3 shotFired = player.transform.position + new Vector3(randHitChanceX, randHitChanceY, randHitChanceZ);

        if(Physics.Raycast(this.transform.position, shotFired, out hit, Mathf.Infinity))
        {
            hit.rigidbody.velocity /= 2;
            Debug.DrawRay(this.transform.position, shotFired, Color.red);

            Invoke("ResumeVelocity", 3.0f);
        }
        else{Debug.DrawRay(this.transform.position, shotFired, Color.red);}
    }

    void ResumeVelocity(Rigidbody r)
    {
        r.velocity *= 2;
    }
}
