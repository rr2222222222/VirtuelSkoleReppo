using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldQuestManager : MonoBehaviour
{
    //PARAMETERS

    //CACHED REFERENCES
    [SerializeField] OldQuest activeQuest;
    public OldQuestGiver currentQuestGiver;
    GameObject fetchQuestGoal;
    NavPoint reachQuestGoal;
    OldQuest nextQuest;
    OldPlayerUI playerUI;

    //STATES
    bool isFetchQuest;
    bool isReachQuest;
    bool isReachQuestGiverQuest;

    private void Awake()
    {
        playerUI = GetComponent<OldPlayerUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentQuestGiver)
            {
                playerUI.SetDialogueUIActive();
                currentQuestGiver.GetQuestData();
            }
            else
            {
                Debug.LogError("No quest giver found");
            }
        }
    }

    public void LoadQuestData(OldQuest quest, string questGiverName)
    {
        activeQuest = quest;

        if (quest.Dialogue.Length != 0)
        {
            playerUI.LoadQuestDialogueData(questGiverName, quest.QuestDescription, quest.Dialogue);
        }

        this.isFetchQuest = quest.IsFetchQuest;
        this.fetchQuestGoal = quest.FetchQuestGoal;

        this.isReachQuest = quest.IsReachQuest;
        this.reachQuestGoal = quest.ReachQuestGoal;

        this.nextQuest = quest.NextQuestPart;

        CheckQuestSettings();
    }

    public void QuestComplete()
    {
        if (!nextQuest)
        {
            Debug.LogError("Quest Complete");
            ResetQuestManager();
            playerUI.ResetQuestUI();
        }
        else
        {
            Debug.LogError("Quest partially complete");
            LoadQuestData(nextQuest, null);
            playerUI.LoadNextObjectiveText(activeQuest.QuestDescription);
        }
    }

    void CheckQuestSettings()
    {
        if (!ErrorsFound())
        {
            if(isFetchQuest && fetchQuestGoal)
            {
                //Yet to be completed
            }
            if (isReachQuest && reachQuestGoal)
            {
                reachQuestGoal.SetAsQuestTarget(true);
            }
        }
    }

    bool ErrorsFound()
    {
        if (isFetchQuest && isReachQuest)
        {
            Debug.LogError("The active quest is both a fetch quest and a reach quest. This is not supported");
            return true;
        }
        if (!isFetchQuest && !isReachQuest && !isReachQuestGiverQuest)
        {
            Debug.LogError("Is fetch quest: " + isFetchQuest + ", is reach quest: " + isReachQuest + ", is reach quest giver quest: " + isReachQuestGiverQuest);
            return true;
        }
        if (isFetchQuest && !fetchQuestGoal)
        {
            Debug.LogError("This quest is marked as a reach quest but no item is assigned");
            return true;
        }
        if (isReachQuest && !reachQuestGoal)
        {
            Debug.LogError("This quest is marked as a reach quest but no goal is assigned");
            return true;
        }
        else { return false; }
    }

    void ResetQuestManager()
    {
        activeQuest = null;
        this.isFetchQuest = false;
        this.isReachQuest = false;
        this.fetchQuestGoal = null;
        this.reachQuestGoal = null;
        this.nextQuest = null;
    }
}
