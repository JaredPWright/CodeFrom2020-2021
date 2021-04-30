using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float moveSpeed = 0.25f;

    public float baddyPosition = 1.0f;

    public float playerKickback = 100.0f;

    public bool isRight;

    Rigidbody2D badGuy;

    public float scaleChange = -1.0f;

    GameObject wholeEnemy;

    // Start is called before the first frame update
    void Start()
    {
      badGuy = GetComponent<Rigidbody2D>();
      wholeEnemy = GetComponent<GameObject>();

      isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(new Vector3(-baddyPosition, 0, 0) * moveSpeed * Time.deltaTime);

      if (baddyPosition < 0)
      {
        isRight = false;
      }
      else if (baddyPosition > 0)
      {
        isRight = true;
      }
    }

    void OnTriggerEnter2D(Collider2D other){

      if(other.gameObject.CompareTag("walls")){

        baddyPosition = -baddyPosition;

      }

    }

    void OnCollisionEnter2D(Collision2D other){

      if(other.gameObject.CompareTag("cannonBall")){

        baddyPosition = -baddyPosition;

      }

      if(other.gameObject.CompareTag("Player")){

        other.transform.Translate(new Vector3((baddyPosition * playerKickback), 0, 0) * 1 * Time.deltaTime);

      }

    }

}
