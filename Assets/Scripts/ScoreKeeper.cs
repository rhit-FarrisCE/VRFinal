using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance;
    public ProgressionManager progressionManager;
    private int totalScore = 0;
    public int roundScore = 0;
    public int currentRound = 1;
    public int currentThrow = 1;
    public TextMeshProUGUI r11;
    public TextMeshProUGUI r12;
    public TextMeshProUGUI r13;
    public TextMeshProUGUI r21;
    public TextMeshProUGUI r22;
    public TextMeshProUGUI r23;
    public TextMeshProUGUI r31;
    public TextMeshProUGUI r32;
    public TextMeshProUGUI r33;
    private TextMeshProUGUI[] round1Scores;
    private TextMeshProUGUI[] round2Scores;
    private TextMeshProUGUI[] round3Scores;
    private TextMeshProUGUI[][] allScores;
    
    // Store actual pin counts for scoring calculation
    private int[][] roundPins = new int[3][]; // 3 rounds, 2 throws each
    private int[] roundTotalScores = new int[3]; // Final score for each round
    private bool[] roundWasStrike = new bool[3]; // Track strikes by round
    private bool[] roundWasSpare = new bool[3]; // Track spares by round
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        round1Scores = new TextMeshProUGUI[] { r11, r12, r13 };
        round2Scores = new TextMeshProUGUI[] { r21, r22, r23 };
        round3Scores = new TextMeshProUGUI[] { r31, r32, r33 };
        allScores = new TextMeshProUGUI[][] { round1Scores, round2Scores, round3Scores };
        
        // Initialize pin storage
        for (int i = 0; i < 3; i++)
        {
            roundPins[i] = new int[2]; // 2 throws per round
        }
        
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        // Progresses the game when the score keeper resets
        // Progression doesn't happen unless the total is greater than the minimal score needed
        progressionManager.Progress(totalScore);

        totalScore = 0;
        roundScore = 0;
        currentRound = 1;
        currentThrow = 1;
        for (int i = 0; i < 3; i++)
        {
            roundTotalScores[i] = 0;
            roundWasStrike[i] = false;
            roundWasSpare[i] = false;
            for (int j = 0; j < 2; j++)
            {
                roundPins[i][j] = 0;
            }
            allScores[i][0].text = "";
            allScores[i][1].text = "";
            allScores[i][2].text = "";
        }
    }

    public void UpdateScore(int pinsDownCount)
    {
        // Store the pin count
        roundPins[currentRound - 1][currentThrow - 1] = pinsDownCount;

        if (pinsDownCount >= 10)
        {
            // Strike on first throw
            allScores[currentRound - 1][currentThrow - 1].text = "X";
            roundWasStrike[currentRound - 1] = true;
            roundWasSpare[currentRound - 1] = false;
            currentRound += 1;
            currentThrow = 1;
            roundScore = 0;
            return;
        }

        if (currentThrow == 1)
        {
            // First throw (non-strike)
            allScores[currentRound - 1][0].text = pinsDownCount.ToString();
            roundScore = pinsDownCount;
            roundWasSpare[currentRound - 1] = false;
            roundWasStrike[currentRound - 1] = false;
            currentThrow = 2;
        }
        else if (currentThrow == 2)
        {
            // Second throw
            allScores[currentRound - 1][1].text = pinsDownCount.ToString();
            roundScore += pinsDownCount;

            // Check for spare
            if (roundScore >= 10)
            {
                allScores[currentRound - 1][1].text = "/";
                roundWasSpare[currentRound - 1] = true;
                roundWasStrike[currentRound - 1] = false;
            }
            else
            {
                roundWasSpare[currentRound - 1] = false;
                roundWasStrike[currentRound - 1] = false;
            }

            // Calculate score for current round
            CalculateRoundScore(currentRound - 1);

            currentRound += 1;
            currentThrow = 1;
            roundScore = 0;
        }
    }

    private void CalculateRoundScore(int roundIndex)
    {
        int score = 0;

        // Current round pins
        int throw1 = roundPins[roundIndex][0];
        int throw2 = roundPins[roundIndex][1];

        // Check if previous round and the round before was a strike or spare
        if (roundIndex > 1)
        {
            if (roundWasStrike[roundIndex - 1])
            {
                if (roundWasStrike[roundIndex])
                {
                    score = 50;
                }
                if (roundWasStrike[roundIndex - 2])
                {
                    score = (throw1 + throw2) * 2 + 30;
                } 
                else if (roundWasSpare[roundIndex - 2])
                {
                    score = (throw1 + throw2) * 2 + 20;
                }
            } 
            else
            {
                if (roundWasStrike[roundIndex - 1])
                {
                    // If last round was a strike, double this round's score
                    score = (throw1 + throw2) * 2 + 10;
                }
                else if (roundWasSpare[roundIndex - 1])
                {
                    // If last round was a spare, double first throw
                    score = (throw1 * 2) + throw2;
                }
                else if (roundWasStrike[roundIndex])
                {
                    score = 10;
                }
                else
                {
                    score = throw1 + throw2;
                }
            }
            // Check if previous round was a strike or spare
        } 
        else if (roundIndex > 0)
        {
            if (roundWasStrike[roundIndex - 1])
            {
                // If last round was a strike, double this round's score
                score = (throw1 + throw2) * 2 + 10;
            }
            else if (roundWasSpare[roundIndex - 1])
            {
                // If last round was a spare, double first throw
                score = (throw1 * 2) + throw2;
            }
            else if (roundWasStrike[roundIndex])
            {
                score = 10;
            }
            else
            {
                score = throw1 + throw2;
            }
        }
        else
        {
            score = throw1 + throw2;
        }

        roundTotalScores[roundIndex] = score;

        // Update cumulative score display
        if (roundIndex == 0)
        {
            totalScore = score;
        }
        else
        {
            totalScore += score;
        }

        allScores[roundIndex][2].text = totalScore.ToString();
    }

}
