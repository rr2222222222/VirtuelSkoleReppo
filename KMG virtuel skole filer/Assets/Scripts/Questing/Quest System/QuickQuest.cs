using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickQuest : MonoBehaviour
{
    public string[] dialogue;
    public string questGoal;
    public string characterName;
    public Transform[] targets;
    bool hasBeenCompleted = false;
    [SerializeField] bool isFirstQuest = false;
    [SerializeField] bool isFinalQuest = false;
    [SerializeField] QuickQuest nextQuickQuest;

    private void Start()
    {
        if(!isFirstQuest)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasBeenCompleted)
        {
            PlayerUI playerUI = other.GetComponent<PlayerUI>();
            QuickQuestManager quickQuestManager = other.GetComponent<QuickQuestManager>();
            if (!quickQuestManager.HasQuest)
            {
                playerUI.GetQuickQuestData(dialogue, characterName, questGoal, this);
                playerUI.SetDialogueUIActive();
                quickQuestManager.SetTargets(targets, this);
                quickQuestManager.isFinalQuest = isFinalQuest;
                if (nextQuickQuest)
                {
                    nextQuickQuest.gameObject.SetActive(true);
                }
            }
        }
    }

    public void HasBeenCompleted()
    {
        hasBeenCompleted = true;
    }


}
