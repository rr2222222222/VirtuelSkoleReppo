using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldQuest : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] string[] dialogue;
    public string[] Dialogue { get { return dialogue; } }

    [SerializeField] string questDescription;
    public string QuestDescription { get { return questDescription; } }

    [Header("Type of quest")]
    [SerializeField] bool isFetchQuest = false;
    public bool IsFetchQuest { get { return isFetchQuest; } }

    [Tooltip("A quest with the goal of reaching the next quest giver")]
    [SerializeField] bool isReachQuest = false;
    public bool IsReachQuest { get { return isReachQuest; } }

    [Header("Goal")]
    [Tooltip("Only necessary if this is a fetch quest")]
    [SerializeField] GameObject fetchQuestGoal;
    public GameObject FetchQuestGoal { get { return fetchQuestGoal; } }

    [Tooltip("Only necessary if this is a reach quest")]
    [SerializeField] NavPoint reachQuestGoal;
    public NavPoint ReachQuestGoal { get { return reachQuestGoal; } }

    [Header("Next quest (if any)")]
    [Tooltip("If this is NOT a reach quest giver quest, this quest will automatically be assigned after the active quest is complete." +
        "If this IS a reach quest giver quest, this quest will be assigned to the quest giver")]
    [SerializeField] OldQuest nextQuestPart;
    public OldQuest NextQuestPart { get { return nextQuestPart; } }

    
}
