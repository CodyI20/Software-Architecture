using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class UpgradeManager : MonoBehaviour
{
    public static event Action<int> onTowerSold;
    private AbstractTower tower;
    private Canvas choiceCanvas;

    private int coinsSpent;

    [SerializeField, Tooltip("Drag in the tower models for the upgraded versions of this tower")] private List<GameObject> towerModels = new List<GameObject>();
    private static int _towerModelIndex = 0;

    [SerializeField] private CommandSO damageUpgradeCommand;
    [SerializeField] private CommandSO attackSpeedUpgradeCommand;
    [SerializeField] private CommandSO rangeUpgradeCommand;

    [SerializeField] private TextMeshProUGUI damageUpgradeCostText;
    [SerializeField] private TextMeshProUGUI attackSpeedUpgradeCostText;
    [SerializeField] private TextMeshProUGUI rangeUpgradeCostText;

    [SerializeField] private TextMeshProUGUI sellTowerCostText;


    private void Awake()
    {
        tower = GetComponent<AbstractTower>();
        choiceCanvas = GetComponentInChildren<Canvas>();
        if (choiceCanvas == null)
        {
            throw new System.Exception("No canvas found in children");
        }
        else
            choiceCanvas.gameObject.SetActive(false);
        _towerModelIndex = 0;
        coinsSpent += tower.towerCost;
        SetupUpgradeCosts();
        UpdateSellTowerText();
    }
    public void UpgradeDamage()
    {
        if (Player.Instance.SpendCoins(damageUpgradeCommand.cost))
        {
            UpgradeTowerModel();
            SaveCoinsSpent(damageUpgradeCommand.cost);
            damageUpgradeCommand.Execute(tower);
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (Player.Instance.SpendCoins(attackSpeedUpgradeCommand.cost))
        {
            SaveCoinsSpent(attackSpeedUpgradeCommand.cost);
            attackSpeedUpgradeCommand.Execute(tower);
        }
    }

    public void UpgradeRange()
    {
        if (Player.Instance.SpendCoins(rangeUpgradeCommand.cost))
        {
            SaveCoinsSpent(rangeUpgradeCommand.cost);
            rangeUpgradeCommand.Execute(tower);
        }
    }

    public void SellTower()
    {
        onTowerSold?.Invoke(coinsSpent);
        Destroy(gameObject);
    }

    //Refactor this method and everything that has to do with it. It's a mess ( Has a long path - TowerIcon -> TowerSpawner -> AbstractTower -> UpgradeManager)
    private void SaveCoinsSpent(int amount)
    {
        coinsSpent += amount;
        UpdateSellTowerText();
    }

    //Drag this logic into a scriptable object
    private void SetupUpgradeCosts()
    {
        damageUpgradeCostText.text = damageUpgradeCommand.cost.ToString();
        attackSpeedUpgradeCostText.text = attackSpeedUpgradeCommand.cost.ToString();
        rangeUpgradeCostText.text = rangeUpgradeCommand.cost.ToString();
    }

    private void UpdateSellTowerText()
    {
        sellTowerCostText.text = coinsSpent.ToString();
    }

    private void UpgradeTowerModel()
    {
        // Check if the towerModels list is not empty
        if (towerModels.Count > 0)
        {
            // Ensure the index is within the bounds of the towerModels list
            _towerModelIndex = Mathf.Clamp(_towerModelIndex, 0, towerModels.Count - 1);

            // Get the mesh filter of the tower
            MeshFilter meshFilter = GetComponent<MeshFilter>();

            // Get the mesh renderer of the tower
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

            // Check if the mesh filter is not null
            if (meshFilter != null && meshRenderer != null)
            {
                // Get the mesh from the towerModels list based on the current index
                Mesh newMesh = towerModels[_towerModelIndex].GetComponent<MeshFilter>().sharedMesh;

                // Set the new mesh to the tower's mesh filter
                meshFilter.mesh = newMesh;
                meshRenderer.SetMaterials(new List<Material>(towerModels[_towerModelIndex].GetComponent<MeshRenderer>().sharedMaterials));
            }
            else
            {
                Debug.LogError("MeshFilter component not found on the tower.");
            }
            _towerModelIndex += 1;
        }
        else
        {
            Debug.LogError("Tower models list is empty. Add tower models to the list in the inspector.");
        }
    }


    private void Update()
    {
        EnableCanvas();
    }

    void EnableCanvas()
    {
        // Check for mouse clicks
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            // Get the ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the one this script is attached to
                if (hit.collider.gameObject == gameObject)
                {
                    // Clicked on the tower base, enable the canvas
                    choiceCanvas.gameObject.SetActive(true);
                }
            }
        }
    }
}
