using UnityEngine;

public class EarlyWaveCoinsUI : AbstractUIText
{
    private void OnEnable()
    {
        AdvanceWave.onWaveAdvance += ChangeText;
    }

    private void OnDisable()
    {
        AdvanceWave.onWaveAdvance -= ChangeText;
    }
}
