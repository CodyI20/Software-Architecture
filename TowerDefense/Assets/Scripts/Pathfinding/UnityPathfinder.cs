using TMPro;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// This pathfinder uses Unity's AI, it requires backing a NavMesh in the scene
/// and a NavMeshAgent component to work.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class UnityPathfinder : MonoBehaviour, IPathFinding
{
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveTowardsTarget(Vector3 targetPosition, float speed)
    {
        agent.speed = speed;
        agent.SetDestination(targetPosition);
    }

    public bool HasReachedTarget(Vector3 targetPosition, float distanceToStop)
    {
        return Vector3.Distance(agent.destination, transform.position)<=agent.stoppingDistance;
    }
}
