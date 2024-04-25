using TMPro;
using UnityEngine;

public class ScoreingSystem : PickupManager
{
    public int totalScore;
    public int totalCash;
    int scoreMult;
    public int cash;
    private float startTime;
    public TMP_Text text;

    
    void Start()
    {
        totalScore = 0;
        startTime = Time.time;
    }

    
    void Update()
    {
        scoreMult = activeScoreX ? 2 : 1;

        // add time survived onto score
        float timeSurvived = Time.time;
        int timeScore = Mathf.RoundToInt(timeSurvived / 50000); // Convert time float to int
        totalScore += timeScore * scoreMult;

        // ui update score
        text.text = "Score: " + totalScore;
        
    }

 
    public void AddScore(int score)
    {
        totalScore += score * scoreMult;
    }

   
    public void TakeScore(int score)
    {
        totalScore -= score;
        if (totalScore < 0)
        {
            totalScore = 0;
        }
    }
    public void AddCash(int cash)
    {
        totalCash += cash;
    }

    public void secret()
    {
        totalCash *= 2;
    }



}
