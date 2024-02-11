using UnityEngine;

public class EarlyWaveCoinsUI : AbstractUIText
{
    private void OnEnable()
    {
        AdvanceWave.onWaveAdvance += AdditionText;
    }

    private void OnDisable()
    {
        AdvanceWave.onWaveAdvance -= AdditionText;
    }
}
