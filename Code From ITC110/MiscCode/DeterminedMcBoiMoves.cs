/*Author: Jared Wright; For ITC 110; This program is a basic player script. It should move the player
and allow for a basic damage/death system.*/
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class DeterminedMcBoiMoves : MonoBehaviour
{

    public float moveSpeed = 10.0f;

    public float jumpForce = 300.0f;

    Rigidbody2D rigidbody;

    bool isGrounded = false;

    private float damageCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //These tell the engine to look for inputs that are aliased with "horizontal" or "vertical".
        float horizontalInput = Input.GetAxis("Horizontal");

        //These determine the force and the axis upon which the sprite will move.
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump") && isGrounded){
          rigidbody.AddForce(transform.up * jumpForce);
        }

        if(damageCounter == 2.0f){
          Destroy(rigidbody.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){

      Debug.Log("Hey, I'm standing on something!");

      if(other.gameObject.CompareTag("jumpy")){
        isGrounded = true;
      }

    }

    void OnTriggerExit2D(Collider2D other){
      isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D other){
      if(other.gameObject.CompareTag("cannonBall")){
        damageCounter += 1;
      }
    }


}
