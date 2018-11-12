using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour {

    static int score;
    static bool isChangedScore = false;

    [SerializeField] string scoreTextHeader = "Score: ";
    [SerializeField] Text scoreLabel;

    void Update()
    {

        if (isChangedScore == true)
        {
            scoreLabel.text = scoreTextHeader + score.ToString();

            isChangedScore = false;
        }
    }

    public static void AddScore(int point)
    {
        score += point;

        isChangedScore = true;
    }
}
