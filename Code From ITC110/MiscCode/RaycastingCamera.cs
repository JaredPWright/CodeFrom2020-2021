//This script was written by Jared Wright on behalf of Colleen Gostomski for her game for DET 220. 
//It *should* allow the player to complete game objectives of taking pictures of particular objects
//throughout the game. It accomplishes this through Raycasting and comparison of tags.
//This script should be paired with a Game Manager of some kind that can track whether or not the 
//correct objects have been hit or not.
//Additionally, this script could be attached to anything, so long as the actual origin point object
//that we pass it is attached to the player and in proper position there. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingCamera : MonoBehaviour
{
    [Header("Set in Inspector")]
    //I would recommend making an array of bools for each kind of object
    //that we can flip once the raycast returns that we have, in fact, hit
    //an object of that type.
    public GameManagerScript gameManager;

    //Load your subjects into this array. Later in the code, we'll take their
    //names and compare them to the subjects of the photos that our rays return.
    public GameObject[] photoSubjects;
    //Make an empty GameObject outside of the colliders of the source of the
    //object that will actually be shooting the ray. 
    public GameObject raycastOrigin;

    //How far should the camera shoot the raycast beam (in meters)?
    public float rangeOfCamera = 5.0f;

    

    [Header("Set during Runtime")]
    //This is the variable where we will store our Raycast info.
    [SerializeField] private RaycastHit hit;

    //This will store the names of the GameObjects that you want the player
    //to take pictures of. 
    public List<string> tagsOfSubjects;

    void Awake()
    {
        //Initialize the List
        tagsOfSubjects = new List<string>();

        //Load the tags of the objects into our tag List so we can prepare them later.
        //We can set the condition to run for as many counts as the array is long.
        for(int i = 0; i < photoSubjects.Length; i++)
        {
            //Initialize a temp variable to load the subject's tag into.
            string tempString = photoSubjects[i].tag;

            //Add it to the List.
            tagsOfSubjects.Add(tempString);
        }
    }


    //Call this cast in whatever function actually takes the screenshot.
    public static void CheckYourCams()
    {
        LayerMask mask = LayerMask.GetMask("CollectedPhotoSubjects");

        //Check for hit
        if(Physics.Raycast(raycastOrigin.transform.position, transform.TransformDirection(Vector3.forward), out hit, rangeOfCamera, mask))
        {
            //Run through the whole list of tags to check if any of them match the tag of the hit.
            for(int i = 0; i < photoSubjects.Length; i++)
            {
                //Check if the tag is the same as any of the objects that we loaded in Awake().
                if(hit.collider.gameObject.CompareTag(tagsOfSubjects[i]))
                {
                    hit.collider.gameObject.layer = LayerMask.NameToLayer("CollectedPhotoSubjects");
                    //If they are, make our corresponding bool true. 
                    //gameManager.boolArray[indexOfTheEquivalentBool] = true;
                    for(int j = 0; j < yourBoolArrayHere.Length; j++)
                    {
                        if(!yourBoolArrayHere[j])
                        {
                            yourBoolArrayHere[j] = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}