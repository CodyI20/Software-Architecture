using UnityEngine;
using TMPro;

/// <summary>
/// This script is used as a base for all UI elements that contain text.
/// It is used so that all of the required code for them is kept in one place;
/// And no code has to be rewritten
/// </summary>
public abstract class AbstractUIText : MonoBehaviour
{
    private TextMeshProUGUI textElement;
    private void Awake()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        if (textElement == null)
        {
            throw new System.Exception("The text element was not found!");
        }
    }
    protected void ChangeText(string newText)
    {
        if(newText == null)
        {
            throw new System.Exception("You cannot imput an empty string as the text!");
        }
        textElement.text = newText;
    }
    protected void ChangeText(int newText)
    {
        textElement.text = newText.ToString();
    }
}
