using UnityEngine;


/// <summary>
/// This class is responsible for switching the overlay UI on and off. It listens to the GameManager's OnGamePaused event.
/// </summary>
public class OverlayUISwitch : MonoBehaviour
{
    void Start()
    {
        GameManager.OnGameStateSwitch += SwitchOverlayUIState;
        gameObject.SetActive(false);
    }
    void OnDestroy()
    {
        GameManager.OnGameStateSwitch -= SwitchOverlayUIState;
    }

    void SwitchOverlayUIState()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
