using UnityEngine;

public class DestroyRangeSphere : MonoBehaviour
{
    private void OnEnable()
    {
        TowerIcon.onIconExit += DestroySphere;
    }
    private void OnDisable()
    {
        TowerIcon.onIconExit -= DestroySphere;
    }

    void DestroySphere()
    {
        Destroy(gameObject);
    }
}
