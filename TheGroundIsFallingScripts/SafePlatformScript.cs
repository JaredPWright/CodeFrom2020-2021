using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SafePlatformScript : MonoBehaviour
{
    private MenuManager menuManager;

    void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }
   void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.CompareTag("Player"))
       {
           menuManager.winButton.SetActive(true);
           menuManager.winText.SetActive(true);
           Time.timeScale = 0;
       }
   }

   void PlayerHasWon()
   {
       SceneManager.LoadScene("WinScreen");
   }
}
