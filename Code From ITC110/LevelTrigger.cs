using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //This is because the object is set as a trigger. When the Player collides, it should move to the next level. -Jared
    void OnTriggerEnter2D(Collider2D other){

      if(other.gameObject.CompareTag("Player")){

        //This actually loads the next scene. We might have to make modifications for cutscenes later, but this should suffice for the moment. -Jared
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

      }

    }
}
