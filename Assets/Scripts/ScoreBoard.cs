using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    int score;


    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;    //score = score + amountToIncrease

        Debug.Log($"Score is now {score} points");

    }



}
