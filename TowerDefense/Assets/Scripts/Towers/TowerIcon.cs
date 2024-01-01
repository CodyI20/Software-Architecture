using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static event Action<TowerType, TowerSettingsSO> onTowerPicked;
    [SerializeField, Min(0)] private int towerCost;

    [SerializeField] private TowerSettingsSO towerSettings;
    [SerializeField, Tooltip("Drag in the background image for the stats (it is found in the children of this object")] private Image statsBackground;
    private TextMeshProUGUI[] UIDisplays;

    [SerializeField] private TowerType _towerType;
    public TowerType TowerType
    {
        get { return _towerType; }
    }

    void Awake()
    {
        InitializeChildren();
    }

    void InitializeChildren()
    {
        if(statsBackground == null)
        {
            throw new Exception("The background for the tower icon stats cannot be found in the children!");
        }
        UIDisplays = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        if(UIDisplays == null)
        {
            throw new Exception("The UI elements for the tower icon stats cannot be found in the children!");
        }
        SetTheTextForChildren();
        ToggleActiveStats();
    }

    //Find a better, MORE RELIABLE way to do this
    void SetTheTextForChildren()
    {
        UIDisplays[0].text = $"Type: {TowerType}";
        UIDisplays[1].text = $"Cost: {towerCost}";
        UIDisplays[2].text = $"Damage: {towerSettings.Damage}";
        UIDisplays[3].text = $"Fire rate: {towerSettings.AttackSpeed}";
        UIDisplays[4].text = $"Range: {towerSettings.Range}";
    }

    void ToggleActiveStats()
    {
        foreach (TextMeshProUGUI text in UIDisplays)
        {
            text.gameObject.SetActive(!text.gameObject.activeSelf);
        }
        statsBackground.gameObject.SetActive(!statsBackground.gameObject.activeSelf);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("CLICKED ON ICON!");
        // Invoke the event that others can listen to
        if (Player.playerInstance.SpendCoins(towerCost))
            onTowerPicked?.Invoke(TowerType, towerSettings);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered icon");
        ToggleActiveStats();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exited icon");
        ToggleActiveStats();
    }
}
