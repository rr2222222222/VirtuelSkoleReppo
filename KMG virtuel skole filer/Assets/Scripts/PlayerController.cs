using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    bool inCoRoutine;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update () {
        if (!inCoRoutine)
            StartCoroutine(doSomething());
    }

    Vector3 getNewRandomPosition ()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 2, z);
        return pos;
    }

    IEnumerator doSomething ()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath ()
    {
        navMeshAgent.SetDestination(getNewRandomPosition()); 
    }
}
