using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script will be used to send a broadcast message that the advance wave button has been pressed
/// </summary>
public class AdvanceWave : MonoBehaviour, IPointerClickHandler
{
    public event Action onWaveAdvance;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("PRESSED THE ADVANCE_WAVE ICON!");
        onWaveAdvance?.Invoke();
    }
}
