using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] string questGiverName;
    QuestManager questManager;
    PlayerUI playerUI;
    public Quest questData;
    bool isQuestGiverGoal = false;

    /*
    public void GetQuestData()
    {
        if (!FoundError())
        {
            questManager.LoadQuestData(questData, questGiverName);
        }
    }

    public void SetIsQuestGiverGoal(bool state)
    {
        isQuestGiverGoal = state;
    }

    bool FoundError()
    {
        questManager = FindObjectOfType<QuestManager>();
        playerUI = FindObjectOfType<PlayerUI>();
        if (!questManager)
        {
            Debug.LogError("No Quest Manager found");
            return true;
        }
        if (!playerUI)
        {
            Debug.LogError("No PlayerUI script found in scene");
            return true;
        }
        if (!questData)
        {
            Debug.LogError("This quest giver has not been assigned a quest to give");
            return true;
        }
        else { return false; }
    }
    */
}
