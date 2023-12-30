using UnityEditor.U2D;
using UnityEngine;

/// <summary>
/// This class is going to control the way the enemy traverses the path.
/// It takes a pathfinding interface and applies the method from the script attached to the object.
/// This allows for easy swapping between pathfinding algorithms.
/// </summary>

public class EnemyController : MonoBehaviour
{
    public delegate void TargetReachedAction();
    public event TargetReachedAction onTargetReached;

    private IPathFinding pathFinder;

    private float maximumSpeed = 1.7f;
    private float initialSpeed = 1.7f;
    private float speed = 1.7f;
    private Transform target;
    private bool hasReachedFinalTarget = false;

    void Awake()
    {
        pathFinder = GetComponent<IPathFinding>();
        if (pathFinder == null)
        {
            throw new System.Exception("No PathFinder found.");
        }
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Base").transform;
        if (target == null)
        {
            throw new System.Exception("Base not found!");
        }
    }

    /// <summary>
    /// Sets the speed at which each enemy advances
    /// </summary>
    /// <param name="speed"></param>
    public void SetEnemySpeed(float eSpeed)
    {
        speed = eSpeed;
        initialSpeed = eSpeed;
        maximumSpeed = eSpeed;
    }

    public void ReduceEnemySpeed(float amount)
    {
        speed -= amount;
    }

    public void ResetEnemySpeed()
    {
        speed = initialSpeed;
    }

    public void ModifyMaximumSpeed(float amount, bool addition = true, bool alsoSetCurrentSpeed = false)
    {
        if (addition)
            maximumSpeed += amount;
        else
            maximumSpeed -= amount;
        if (alsoSetCurrentSpeed)
            speed = maximumSpeed;
    }

    void CheckTargetReached()
    {
        if (pathFinder.HasReachedTarget(target.position, 1f))
        {
            onTargetReached?.Invoke();
            hasReachedFinalTarget = true;
        }
    }


    void Update()
    {
        pathFinder.MoveTowardsTarget(target.position, speed);
        if (!hasReachedFinalTarget)
            CheckTargetReached();
    }
}
