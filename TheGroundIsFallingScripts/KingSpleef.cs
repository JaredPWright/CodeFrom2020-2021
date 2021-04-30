using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets;

public class KingSpleef : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject[] FloorPrefabs;
    public GameObject startButton;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;

    [Header("Set Dynamically")]
    [SerializeField] private List<GameObject> DangerousPlatforms;
    [SerializeField] private List<GameObject> SafePlatforms;

    public static float addDropTime = 0.0f;

    void Start()
    {
        Time.timeScale = 0;
        startButton.SetActive(true);

        DangerousPlatforms = new List<GameObject>();
        SafePlatforms = new List<GameObject>();

        PlatformSpawner();
    }


    public void StartButton()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }

    void PlatformSpawner()
    {
        Vector3 spawnPos = new Vector3(8.6f, 0f, -8.6f);

        int safePlatformsSpawned = 0;

        for(int j = 0; j < 8; j++)
        {
            Debug.Log("I am in interation " + j.ToString() + " of 'J' loop!");

            float tempPosVar = j;

            spawnPos = new Vector3((-2.5f * (tempPosVar - 3.5f)), 0f, -8.6f);

            for(int i = 0; i < 8; i++)
            {
                GameObject tempSafePlatform  = null;
                GameObject tempDeadPlatform = null;

                Debug.Log("I am in iteration " + i.ToString() + " of 'I' loop!");

                int rand = (int)Random.Range(0, 100);
                
                if(rand <= 5 && safePlatformsSpawned < 2)
                {
                    tempSafePlatform = Instantiate<GameObject>(FloorPrefabs[1]);
                    tempSafePlatform.transform.position = spawnPos;

                    SafePlatforms.Add(tempSafePlatform);

                    spawnPos += new Vector3(0, 0, 2.5f);

                    safePlatformsSpawned++;
                }
                else
                {
                    tempDeadPlatform = Instantiate<GameObject>(FloorPrefabs[0]);
                    tempDeadPlatform.transform.position = spawnPos;

                    DangerousPlatforms.Add(tempDeadPlatform);

                    spawnPos += new Vector3(0, 0, 2.5f);
                }

            }
        }
    }
}
