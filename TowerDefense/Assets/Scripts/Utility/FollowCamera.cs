using UnityEngine;

/// <summary>
/// This class is sort of a utility class
/// Whose sole purpose is to make GameObjects ( usually UI elements ) follow the camera.
/// Which means, the rotation of the object will match the rotation of the camera.
/// </summary>
public class FollowCamera : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
