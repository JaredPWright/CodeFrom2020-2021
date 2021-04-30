using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public Houston houston;
    public GameObject bulletPrefab;
    public float shipSpeed = 10f;
    public float xLimit = 7f;
    public float reloadTime = .05f;

    public bool isShielded = false;
    public float shieldTimer = 0f;

    float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(xInput * shipSpeed * Time.deltaTime, 0f, 0f);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        if(Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0f, 1.2f, 0f);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            elapsedTime = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R) && elapsedTime > reloadTime)
        {
            int numOfBullets = Random.Range(5, 10);
            for(int i = 0; i < numOfBullets; i++)
            {
                Instantiate(bulletPrefab, new Vector3(transform.position.x + (i - (numOfBullets / 2)) * 0.2f, transform.position.y - Mathf.Abs(i - (numOfBullets / 2)) * 0.2f), Quaternion.identity);
            }
        }

        if(Input.GetKeyDown(KeyCode.T) && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(.25f, .5f, 0);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            spawnPos -= new Vector3(.5f, 0f, 0f);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        }

        // if(Input.GetButtonDown("Fire1") && elapsedTime > reloadTime)
        // {
        //     // Debug.Log("Input Received");

        //     // int randLasers = Random.Range(5, 10);

        //     // Debug.Log("I've generated a random number.");

        //     // RSpawn(randLasers);

            
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ShieldBuddy"))
        {
            isShielded = true;
            shieldTimer = 10f;

            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("DeathMeteor") && !isShielded)
        {
            houston.playerHealth--;

            Destroy(other.gameObject);
        }
        
    }

    // void RSpawn(int a)
    // {
    //     for(int i = a; i > 0; i--)
    //     {
    //         Debug.Log("Spawning Bullet: " + i.ToString());
    //         float j = 2;

    //         Vector3 spawnPos = transform.position;
    //         spawnPos -= new Vector3(j, i, 0f);
    //         Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

    //         j -= .25f;
    //     }
    // }
}
