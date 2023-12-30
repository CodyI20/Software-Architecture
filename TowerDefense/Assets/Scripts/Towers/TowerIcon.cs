using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerIcon : MonoBehaviour, IPointerClickHandler
{
    public static event Action<TowerType> onTowerPicked;
    [SerializeField, Min(0)] private int towerCost;

    private TextMeshProUGUI costText;

    [SerializeField] private TowerType _towerType;
    public TowerType TowerType
    {
        get { return _towerType; }
    }

    void Awake()
    {
        costText = GetComponentInChildren<TextMeshProUGUI>();
        if (costText == null)
        {
            throw new Exception($"The text component from the TowerIcon object: {gameObject.name} was not found!");
        }
        costText.text = towerCost.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CLICKED ON ICON!");
        // Invoke the event that others can listen to
        if (Player.playerInstance.SpendCoins(towerCost))
            onTowerPicked?.Invoke(TowerType);
    }
}
