using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for the logic behind clicking a tower base and spawning the selected tower type
/// It allows you to click on a base, select a tower from the options
/// And if you have enough coins, you will spawn it.
/// </summary>
public class TowerSpawner : MonoBehaviour
{
    [SerializeField, Tooltip("Drag in the tower settings scriptable object!")] private TowerSpawnerSettingsSO towerSpawnerSO;
    private Canvas choiceCanvas;

    private void Awake()
    {
        if (towerSpawnerSO == null)
        {
            throw new System.Exception("The mandatory scriptable object is missing from this prefab! Please drag in the TowerSpawnerSettingsSO file!");
        }
        SetupCanvas();
    }

    private void OnEnable()
    {
        TowerIcon.onTowerPicked += SpawnTower;
    }

    private void OnDisable()
    {
        TowerIcon.onTowerPicked -= SpawnTower;
    }

    void SetupCanvas()
    {
        //Get the canvas component
        choiceCanvas = GetComponentInChildren<Canvas>();

        //Make sure to check it!
        if (choiceCanvas == null)
        {
            throw new System.Exception("No canvas found in the children of TowerSpawner!");
        }

        //Set the worldCamera to the main camera for the canvas
        choiceCanvas.worldCamera = Camera.main;

        //Make the canvas look at the camera (Doing it only once since for this game the camera won't be moving)
        choiceCanvas.transform.rotation = Camera.main.transform.rotation;

        //Disable the canvas so that it's not visible right away
        choiceCanvas.gameObject.SetActive(false);

        //Add the buttons for the towers
        foreach (Image towerImage in towerSpawnerSO.towerIcons)
        {
            Instantiate(towerImage, choiceCanvas.transform);
        }

    }

    //This was used for positioning the canvas (Result FL=17)
    //private void Update()
    //{
    //    float distanceToCamera = Vector3.Distance(choiceCanvas.transform.position, Camera.main.transform.position);
    //    float movementSpeed = 0.1f;

    //    if (distanceToCamera > FL)
    //    {
    //        // Move the canvas towards the camera
    //        choiceCanvas.transform.position = Vector3.Lerp(choiceCanvas.transform.position, Camera.main.transform.position, movementSpeed * Time.deltaTime);
    //    }
    //    else if (distanceToCamera <= FL)
    //    {
    //        // Move the canvas away from the camera
    //        Vector3 directionToCamera = (choiceCanvas.transform.position - Camera.main.transform.position).normalized;
    //        choiceCanvas.transform.position += directionToCamera * movementSpeed * 2;
    //    }
    //}

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

    void SpawnTower(TowerType towerType)
    {
        if (choiceCanvas.gameObject.activeSelf)
        {
            foreach(GameObject tower in towerSpawnerSO.towerPrefabs)
            {
                AbstractTower aT = tower.GetComponent<AbstractTower>();
                if(aT.towerType == towerType && Player.playerInstance.SpendCoins(aT.TowerSettings.Cost))
                {
                    Instantiate(tower, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }

    void Update()
    {
        EnableCanvas();
    }
}
