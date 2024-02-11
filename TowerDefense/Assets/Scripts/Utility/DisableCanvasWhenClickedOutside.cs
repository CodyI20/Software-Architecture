using UnityEngine;

public class DisableCanvasWhenClickedOutside : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        HideIfClickedOutside();
    }
}
