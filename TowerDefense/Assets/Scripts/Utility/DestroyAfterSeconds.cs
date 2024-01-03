using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField, Tooltip("The amount of time it takes until the GameObjects gets Destroyed")] private float timeUntilItGetsDestroyed = 1.0f;

    private void Start()
    {
        Destroy(gameObject, timeUntilItGetsDestroyed);
    }
}
