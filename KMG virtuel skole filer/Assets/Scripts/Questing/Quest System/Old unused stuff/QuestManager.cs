using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    /*
    //PARAMETERS

    //CACHED REFERENCES
    [SerializeField] Quest activeQuest;
    public QuestGiver currentQuestGiver;
    GameObject fetchQuestGoal;
    NavPoint reachQuestGoal;
    QuestGiver questGiverGoal;
    Quest nextQuest;
    PlayerUI playerUI;

    //STATES
    bool questActive = false;
    bool isFetchQuest;
    bool isReachQuest;
    bool isReachQuestGiverQuest;

    private void Awake()
    {
        playerUI = GetComponent<PlayerUI>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(currentQuestGiver)
            {
                if (currentQuestGiver == questGiverGoal)
                {
                    QuestComplete();
                }
                else
                {
                    playerUI.SetDialogueUIActive();
                    currentQuestGiver.GetQuestData();
                }
            }
            else
            {
                Debug.LogError("No quest giver found");
            }
        }
    }
    
    
    public void LoadQuestData(Quest quest, string questGiverName)
    {
        activeQuest = quest;

        if (quest.IsReachQuestGiverQuest)
        {
            playerUI.LoadQuestDialogueData(questGiverName, quest.QuestDescription, quest.Dialogue);
        }

        this.isFetchQuest = quest.IsFetchQuest;
        this.fetchQuestGoal = quest.FetchQuestGoal;

        this.isReachQuest = quest.IsReachQuest;
        this.reachQuestGoal = quest.ReachQuestGoal;

        this.isReachQuestGiverQuest = quest.IsReachQuestGiverQuest;
        this.questGiverGoal = quest.QuestGiverGoal;

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
            if (isReachQuestGiverQuest && questGiverGoal)
            {
                questGiverGoal.SetIsQuestGiverGoal(true);
                if (nextQuest)
                {
                    questGiverGoal.questData = nextQuest;
                }
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
        if (isReachQuestGiverQuest)
        {
            Debug.Log("meme");
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
    */
}
