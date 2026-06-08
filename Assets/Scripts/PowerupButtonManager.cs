using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButtonmanager : MonoBehaviour
{
    [Header("Yes Speed Button")]
    public Button sButton;
    [Header("Yes Pins Button")]
    public Button pButton;
    [Header("YesHeavyButton")]
    public Button bButton;

    public void Start()
    {
        sButton.onClick.AddListener(() =>
        {
            PowerupManager.Instance.AcquirePowerup("speed");
        });
        pButton.onClick.AddListener(() =>
        {
            PowerupManager.Instance.AcquirePowerup("pins");
        });
        bButton.onClick.AddListener(() =>
        {
           PowerupManager.Instance.AcquirePowerup("balls"); 
        });
    }
}
