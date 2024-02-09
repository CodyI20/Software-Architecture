using UnityEngine;
using TMPro;


/// <summary>
/// This class is used to display the current speed of the game on the UI
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class SpeedDisplay : MonoBehaviour
{
    TextMeshProUGUI speedText;
    private void Awake()
    {
        speedText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed: " + Time.timeScale.ToString("0.0") + "x";
    }
}
