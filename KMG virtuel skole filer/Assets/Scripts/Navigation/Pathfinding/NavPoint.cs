using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class NavPoint : MonoBehaviour
{
    MeshRenderer meshRenderer;
    GameObject objectPool;
    bool isPathfindingTarget = false;
    bool isQuestTarget = false;

    private void Awake()
    {
        objectPool = GameObject.FindGameObjectWithTag("Object Pool");
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    public void SetAsPathfindingTarget(bool state)
    {
        isPathfindingTarget = state;
        meshRenderer.enabled = state;
    }

    public void SetAsQuestTarget(bool state)
    {
        isQuestTarget = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPathfindingTarget && other.gameObject.GetComponent<NavMeshObject>())
        {
            other.transform.position = objectPool.transform.position;
            other.gameObject.SetActive(false);
        }
        if (isPathfindingTarget && other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerNavMesh>().StopPathfinding();
        }
        if(isQuestTarget && other.gameObject.tag == "Player")
        {
            //other.GetComponent<QuestManager>().QuestComplete();
            isQuestTarget = false;
            other.GetComponent<QuickQuestManager>().TargetReached(this.transform);
        }
    }
}
