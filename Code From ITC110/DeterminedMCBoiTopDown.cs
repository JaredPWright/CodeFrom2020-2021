using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminedMCBoiTopDown : MonoBehaviour
{
  public float moveSpeed = 10.0f;

  //public float jumpForce = 300.0f;

  Rigidbody2D rigidbody;

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
      float verticalInput = Input.GetAxis("Vertical");

      //These determine the force and the axis upon which the sprite will move.
      transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
      transform.Translate(new Vector3(0, verticalInput, 0) * moveSpeed * Time.deltaTime);

  }

  void OnCollisionEnter2D(Collision2D other){
    if(other.gameObject.CompareTag("cannonBall")){
      Destroy(rigidbody.gameObject);
    }
  }

}
