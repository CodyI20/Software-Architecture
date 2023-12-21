using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerIcon : MonoBehaviour, IPointerClickHandler
{
    public static event Action<string> onTowerPicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CLICKED ON ICON!");
        // Invoke the event that others can listen to
        onTowerPicked?.Invoke(gameObject.name);
        //gameObject.SetActive(false);
    }
}
