using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallExitTrigger : MonoBehaviour
{

    [Header("Text GUI Counter")]
    //public TextMeshProUGUI pinCounter;
    public ScoreKeeper scoreKeeper;
    
    public float timeBeforeScoring = 3f;
    private bool hasTriggered = false;

    private int numThrows = 0;

    private int totalScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
        {
            return;
        }
        if (other.CompareTag("Ball"))
        {
            hasTriggered = true;
            numThrows += 1;
            StartCoroutine(ScoreAfterDelay(other));
        }
    }

    private IEnumerator ScoreAfterDelay(Collider other)
    {
        yield return new WaitForSeconds(timeBeforeScoring);

        Ball ball = other.GetComponentInParent<Ball>();
        ball.Reset();

        hasTriggered = false;
        int pinsDownCount = PinManager.Instance.GetPinsDown();
        int totalPins = PinManager.Instance.GetTotalPins();

        totalScore += pinsDownCount;

        PinManager.Instance.RemoveDownedPins();

        scoreKeeper.UpdateScore(pinsDownCount);

        if (numThrows == 2 || pinsDownCount == totalPins)
        {
            PinManager.Instance.ResetAllPins();
            numThrows = 0;
        }

        Debug.Log("Pins knocked down: " + pinsDownCount + " out of " + totalPins + ".");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
