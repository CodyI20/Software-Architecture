using UnityEngine;

/// <summary>
/// This class is responsible for handling the animations of the enemy.
/// </summary>
[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        AbstractEnemy.onEnemyDeath += DeathAnimation;
    }
    private void OnDisable()
    {
        AbstractEnemy.onEnemyDeath -= DeathAnimation;
    }

    private void DeathAnimation(int moneyDropped)
    {
        animator.SetBool("Death",true);
    }
}
