using System;
using UnityEngine;

/// <summary>
/// This class is responsible for the logic behind clicking a tower base and spawning the selected tower type
/// It allows you to click on a base, select a tower from the options
/// And if you have enough coins, you will spawn it.
/// </summary>
public class TowerSpawner : MonoBehaviour
{
    [SerializeField, Tooltip("Drag in the tower spanwer settings scriptable object!")] private TowerSpawnerSettingsSO towerSpawnerSO;
    [SerializeField, Tooltip("Drag in the RangeSphere prefab")] private GameObject rangeSphere;
    private Canvas choiceCanvas;

    private void Awake()
    {
        if (towerSpawnerSO == null)
        {
            throw new System.Exception("The mandatory scriptable object is missing from this prefab! Please drag in the TowerSpawnerSettingsSO file!");
        }
        if (rangeSphere == null)
        {
            throw new Exception("The prefab for the range sphere is not assigned!");
        }
        if (!rangeSphere.CompareTag("RangeSphere"))
        {
            throw new Exception("The prefab dragged in is not a RangeSphere!");
        }
        SetupCanvas();
    }

    private void OnEnable()
    {
        TowerIcon.onTowerPicked += SpawnTower;
        TowerIcon.onIconHoverEnter += SetTheRangeSphere;
    }

    private void OnDisable()
    {
        TowerIcon.onTowerPicked -= SpawnTower;
        TowerIcon.onIconHoverEnter -= SetTheRangeSphere;
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
        foreach (GameObject towerImage in towerSpawnerSO.towers)
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

    void SpawnTower(TowerSettingsSO towerSettings, GameObject towerPrefab)
    {
        //Check if the canvas is active ( for making sure the static event doesn't trigger for all the spawners at once)
        if (choiceCanvas.gameObject.activeSelf)
        {
            Instantiate(towerPrefab, transform.position, transform.rotation);
            towerPrefab.GetComponent<TowerStats>().towerSettings = towerSettings;
            Destroy(gameObject);
        }
    }

    void SetTheRangeSphere(TowerSettingsSO towerSettings)
    {
        if (choiceCanvas.gameObject.activeSelf)
        {
            rangeSphere.transform.localScale = new Vector3(towerSettings.Range, towerSettings.Range, towerSettings.Range) * 2;
            Instantiate(rangeSphere, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        EnableCanvas();
    }
}
