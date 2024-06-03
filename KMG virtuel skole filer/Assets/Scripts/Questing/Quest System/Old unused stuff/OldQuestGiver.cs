using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldQuestGiver : MonoBehaviour
{
    [SerializeField] string questGiverName;
    OldQuestManager oldQuestManager;
    OldPlayerUI playerUI;
    public OldQuest oldQuestData;
    bool isQuestGiverGoal = false;

    public void GetQuestData()
    {
        if (!FoundError())
        {
            oldQuestManager.LoadQuestData(oldQuestData, questGiverName);
        }
    }

    public void SetIsQuestGiverGoal(bool state)
    {
        isQuestGiverGoal = state;
    }

    bool FoundError()
    {
        oldQuestManager = FindObjectOfType<OldQuestManager>();
        playerUI = FindObjectOfType<OldPlayerUI>();
        if (!oldQuestManager)
        {
            Debug.LogError("No Quest Manager found");
            return true;
        }
        if (!playerUI)
        {
            Debug.LogError("No PlayerUI script found in scene");
            return true;
        }
        if (!oldQuestData)
        {
            Debug.LogError("This quest giver has not been assigned a quest to give");
            return true;
        }
        else { return false; }
    }
}
