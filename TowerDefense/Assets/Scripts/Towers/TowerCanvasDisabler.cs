using UnityEngine;

/// <summary>
/// This class is used purely just to disable the tower spawner canvas if 
/// - A tower is chosen
/// or
/// - A click is detected outside of it
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

    //Disable the canvas if you click outside of it
    private void HideIfClickedOutside()
    {
        if (Input.GetMouseButton(0) && gameObject.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            gameObject.SetActive(false);
        }
    }

    void DisableCanvas(TowerType tt)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        HideIfClickedOutside();
    }
}
