using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    // Start is called before the first frame update
   public Text triangleCounter;

    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        triangleCounter.text = "Score: " + score;
    }
}
