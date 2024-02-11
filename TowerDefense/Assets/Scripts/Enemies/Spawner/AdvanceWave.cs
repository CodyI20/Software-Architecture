using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script will be used to send a broadcast message that the advance wave button has been pressed
/// </summary>
public class AdvanceWave : MonoBehaviour, IPointerClickHandler
{
    //PUBLIC VARIABLES:
    public static event Action<int> onWaveAdvance;

    //PRIVATE VARIABLES:
    [SerializeField, Tooltip("Base money gained from starting early")] private int coins;
    [SerializeField, Tooltip("The amount of money substracted per second")] private int coinsLostPerSecond;
    [SerializeField, Tooltip("The UI for the money gained")] private Canvas moneyGainedUI;
    private int actualCoinsGained;
    private float timeSincePopUp;

    void OnEnable()
    {
        timeSincePopUp = 0f;
        actualCoinsGained = coins;
    }
    public void Update()
    {
        timeSincePopUp += Time.deltaTime;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.gameState == GameState.Paused)
        {
            return;
        }
        actualCoinsGained -= (int)timeSincePopUp * coinsLostPerSecond;
        if(actualCoinsGained < 0)
        {
            actualCoinsGained = 0;
        }
        Instantiate(moneyGainedUI, transform.position, Quaternion.identity);
        Debug.Log("PRESSED THE ADVANCE_WAVE ICON!");
        onWaveAdvance?.Invoke(actualCoinsGained);
    }
}
