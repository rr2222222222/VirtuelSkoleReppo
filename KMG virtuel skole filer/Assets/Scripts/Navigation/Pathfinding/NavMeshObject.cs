using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshObject : MonoBehaviour
{
    NavMeshAgent agent;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(Transform target)
    {
        agent = GetComponent<NavMeshAgent>();
        Vector3 targetPos = target.position;
        agent.SetDestination(targetPos);
        if(agent.enabled == false)
        {
            Debug.LogError("agent is not enabled");
        }
    }
}
