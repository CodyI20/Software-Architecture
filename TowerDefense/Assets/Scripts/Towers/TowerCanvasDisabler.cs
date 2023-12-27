using UnityEngine;

/// <summary>
/// This class is used purely just to disable the tower spawner canvas if 
/// - A tower is chosen
/// or
/// - A click is detected outside of it
/// </summary>
public class TowerCanvasDisabler : DisableCanvasWhenClickedOutside
{
    private void OnEnable()
    {
        TowerIcon.onTowerPicked += DisableCanvas;
    }

    private void OnDisable()
    {
        TowerIcon.onTowerPicked -= DisableCanvas;
    }

    void DisableCanvas(TowerType tt)
    {
        gameObject.SetActive(false);
    }
}
