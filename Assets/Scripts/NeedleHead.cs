using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Needle Head"))
        {
            Time.timeScale = 0;
            if (ScoreManagerScript.instance != null)
            {
                ScoreManagerScript.instance.GameOverFunction();
            }
        }
    }
}