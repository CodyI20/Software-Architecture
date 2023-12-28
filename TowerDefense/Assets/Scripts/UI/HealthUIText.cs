using UnityEngine;

public class HealthUIText : AbstractUIText
{
    private void OnEnable()
    {
        Player.onHealthChanged += ChangeText;
    }
    private void OnDisable()
    {
        Player.onHealthChanged -= ChangeText;
    }
}
