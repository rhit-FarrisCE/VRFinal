using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExitTrigger : MonoBehaviour
{
    
    public float timeBeforeScoring = 3f;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            hasTriggered = true;
            StartCoroutine(ScoreAfterDelay());
        }
    }

    private IEnumerator ScoreAfterDelay()
    {
        yield return new WaitForSeconds(timeBeforeScoring);

        int pinsDownCount = PinManager.Instance.GetPinsDown();
        int total = PinManager.Instance.GetTotalPins();

        Debug.Log("Pins knocked down: " + pinsDownCount + " out of " + total + ".");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
