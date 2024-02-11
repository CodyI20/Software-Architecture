using UnityEngine;
/// <summary>
/// This is the interface for pathfinding behaviors
/// </summary>
public interface IPathFinding
{
    void MoveTowardsTarget(Vector3 targetPosition, float speed);
    bool HasReachedTarget(Vector3 targetPosition, float distanceToStop);
}
