using UnityEngine;

/// <summary>
/// This class is used purely just to disable the tower spawner canvas if 
/// A tower is chosen (listens to the event from TowerIcon)
/// </summary>
public class TowerCanvasDisabler : MonoBehaviour
{
    private void OnEnable()
    {
        TowerIcon.onTowerPicked += DisableCanvas;
    }

    private void OnDisable()
    {
        TowerIcon.onTowerPicked -= DisableCanvas;
    }

    void DisableCanvas(TowerSettingsSO ss, GameObject gO)
    {
        gameObject.SetActive(false);
    }
}
