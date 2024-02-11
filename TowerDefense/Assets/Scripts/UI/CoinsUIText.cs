using UnityEngine;

public class CoinsUIText : AbstractUIText
{
    private void OnEnable()
    {
        Player.onCoinsChanged += ChangeText;
    }
    private void OnDisable()
    {
        Player.onCoinsChanged -= ChangeText;
    }
}
