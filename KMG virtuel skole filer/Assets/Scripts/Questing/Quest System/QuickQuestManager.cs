using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickQuestManager : MonoBehaviour
{
    List<Transform> targets = new List<Transform>();
    PlayerUI playerUI;
    bool hasQuest = false;
    public bool HasQuest { get { return hasQuest; } }

    public bool isFinalQuest;

    QuickQuest questGiver;

    private void Awake()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    public void QuestComplete()
    {
        Debug.LogError("Hurray");
    }

    public void SetTargets(Transform[] targets, QuickQuest questGiver)
    {
        this.questGiver = questGiver;
        hasQuest = true;
        this.targets.Clear();
        foreach (Transform target in targets)
        {
            this.targets.Add(target);
            target.GetComponent<NavPoint>().SetAsQuestTarget(true);
            target.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void TargetReached(Transform targetReached)
    {
        targets.Remove(targetReached);
        targetReached.GetComponent<MeshRenderer>().enabled = false;
        if (targets.Count == 0)
        {
            if (isFinalQuest)
            {
                QuestComplete();
                isFinalQuest = false;
            }
            hasQuest = false;
            playerUI.ResetQuestUI();
            questGiver.HasBeenCompleted();
            questGiver = null;
        }
    }
}
