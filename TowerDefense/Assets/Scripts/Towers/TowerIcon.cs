using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerIcon : MonoBehaviour, IPointerClickHandler
{
    public static event Action<TowerType> onTowerPicked;

    [SerializeField] private TowerType _towerType;
    public TowerType TowerType
    {
        get { return _towerType; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CLICKED ON ICON!");
        // Invoke the event that others can listen to
        onTowerPicked?.Invoke(TowerType);
    }
}
