using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] GameObject navObjectPrefab;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] int maxNumberOfObjects = 5;
    NavPoint target;
    GameObject objectPool;
    GameObject[] pool;
    Queue<GameObject> queue = new Queue<GameObject>();

    private void Awake()
    {
        objectPool = GameObject.FindGameObjectWithTag("Object Pool");
        pool = new GameObject[maxNumberOfObjects];

        for(int i = 0; i < maxNumberOfObjects; i++)
        {
            pool[i] = Instantiate(navObjectPrefab) as GameObject;
            queue.Enqueue(pool[i]);
            pool[i].transform.parent = objectPool.transform;
            pool[i].gameObject.SetActive(false);
        }
    }

    public void ShowPath(NavPoint endPoint)
    {
        if(target) 
        {
            StopAllCoroutines();
            target.SetAsPathfindingTarget(false); 
        }
        target = endPoint;
        target.SetAsPathfindingTarget(true);
        DeleteNavPointObjects();
        StartCoroutine(WaitAndSpawn(endPoint.transform));
    }

    void DeleteNavPointObjects()
    {
        NavMeshObject[] navMeshObjects = FindObjectsOfType<NavMeshObject>();
        foreach(NavMeshObject navMeshObject in navMeshObjects)
        {
            navMeshObject.transform.position = objectPool.transform.position;
            navMeshObject.gameObject.SetActive(false);
        }
    }

    public void StopPathfinding()
    {
        if (target !=null)
        {
            StopAllCoroutines();
            target.SetAsPathfindingTarget(false);
            target = null;
            DeleteNavPointObjects();
        }
        
    }

     IEnumerator WaitAndSpawn(Transform endPoint)
     {
        while (true)
        {
            GameObject objectToEnable = GetNavMeshObject();
            objectToEnable.gameObject.SetActive(false);
            objectToEnable.gameObject.transform.position = transform.position;
            objectToEnable.gameObject.SetActive(true);
            objectToEnable.GetComponent<NavMeshAgent>().SetDestination(endPoint.position);

            yield return new WaitForSeconds(spawnDelay);
        } 
     }

    GameObject GetNavMeshObject()
    {
        foreach(GameObject objectInPool in pool)
        {
            if(!objectInPool.gameObject.activeInHierarchy)
            {
                objectInPool.gameObject.SetActive(true);
                return objectInPool;
            }
        }
        GameObject navMeshObject = queue.Dequeue();
        navMeshObject.gameObject.SetActive(true);
        queue.Enqueue(navMeshObject);
        return navMeshObject;
    }
}
