using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script holds the logic for the enemy healthbar
/// </summary>
public class HealthBar : MonoBehaviour
{
    private AbstractEnemy parent;
    private Slider healthSlider;
    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        parent = GetComponentInParent<AbstractEnemy>();
        if(healthSlider == null)
        {
            throw new System.Exception("The slider component was not found!");
        }
        if(parent == null)
        {
            throw new System.Exception("No parent element found!");
        }
    }
    private void OnEnable()
    {
        parent.onEnemyHealthChange += UpdateHealthBar;
    }
    private void OnDisable()
    {
        parent.onEnemyHealthChange -= UpdateHealthBar;
    }
    void UpdateHealthBar(float maxHealth, float health)
    {
        healthSlider.value = health / maxHealth;
    }
}
