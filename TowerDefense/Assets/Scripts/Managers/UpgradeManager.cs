using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    private AbstractTower tower;
    private Canvas choiceCanvas;

    [SerializeField] private CommandSO damageUpgradeCommand;
    [SerializeField] private CommandSO attackSpeedUpgradeCommand;
    [SerializeField] private CommandSO rangeUpgradeCommand;

    private void Awake()
    {
        tower = GetComponent<AbstractTower>();
        choiceCanvas = GetComponentInChildren<Canvas>();
        if(choiceCanvas == null)
        {
            throw new System.Exception("No canvas found in children");
        }else
            choiceCanvas.gameObject.SetActive(false);
    }
    public void UpgradeDamage()
    {
        damageUpgradeCommand.Execute(tower);
    }

    public void UpgradeAttackSpeed()
    {
        attackSpeedUpgradeCommand.Execute(tower);
    }

    public void UpgradeRange()
    {
        rangeUpgradeCommand.Execute(tower);
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
