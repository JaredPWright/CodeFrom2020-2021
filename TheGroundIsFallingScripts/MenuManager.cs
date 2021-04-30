using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject winText;
    public GameObject winButton;


    void Awake()
    {
        winButton.SetActive(false);
        winText.SetActive(false);
    }
   public void OnClickContinue()
   {
       SceneManager.LoadScene("GameScene");
   }

   public static void PlayAgain()
   {
       SceneManager.LoadScene("InfoScreen");
   }
}
