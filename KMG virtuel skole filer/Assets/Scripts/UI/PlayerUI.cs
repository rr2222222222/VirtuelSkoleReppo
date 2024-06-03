using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(QuickQuestManager))]
public class PlayerUI : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float uIOpaqueLevel = 0.8f;

    //CACHED REFERENCES
    GameObject mainMenu;
    GameObject pathfindingMenu;
    GameObject floorMarkerUI;
    public FloorMarker playerFloorMarker;


    [SerializeField] QuickQuest activeQuickQuest;
    [SerializeField] QuickQuest quickQuestInRange;

    //STATES
    bool pathfindingMenuActive = false;
    bool mainMenuActive = false;
    bool floorMarkerUIActive = false;
    bool questDialogueActive = false;


    [Header("Dialogue")]
    [SerializeField] GameObject dialogueUI;
    [SerializeField] Text questGiverNameText;
    [SerializeField] Text questDialogueText;

    [Header("Quest Description")]
    [SerializeField] GameObject currentQuestUI;
    [SerializeField] Text questObjectiveText;
    [Tooltip("The text that is displayed when there is no active quest")]
    [SerializeField] string noQuestText;
    bool dialogueUIActive = false;

    public string[] dialogue;
    public string questGiverName;

    int dialogueIndex;

    private void Start()
    {
        mainMenu = GameObject.FindWithTag("Main Menu");
        pathfindingMenu = GameObject.FindWithTag("Pathfinding Menu");
        floorMarkerUI = GameObject.FindWithTag("UN Goal");

        SetUIActive();
        ResetQuestUI();
    }

    void SetUIActive()
    {
        if (mainMenu) { mainMenu.SetActive(false); }
        else { Debug.LogError("Main menu is not assigned"); }
        if (pathfindingMenu) { pathfindingMenu.SetActive(false); }
        else { Debug.LogError("Pathfinding menu is not assigned"); }
        if (floorMarkerUI) { floorMarkerUI.SetActive(false); }
        else { Debug.LogError("Floor marker menu is not assigned"); }
        if(dialogueUI) { dialogueUI.SetActive(false); }
        else { Debug.LogError("Dialogue field is not assigned"); }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetPathfindingMenuActive();
            if (mainMenuActive) { SetMainMenuActive(); }
            if (floorMarkerUIActive) { SetfloorMarkerUI(); }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetMainMenuActive();
            if (pathfindingMenuActive) { SetPathfindingMenuActive(); }
            if (floorMarkerUIActive) { SetfloorMarkerUI(); }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetfloorMarkerUI();
            if (pathfindingMenuActive) { SetPathfindingMenuActive(); }
            if (mainMenuActive) { SetMainMenuActive(); }
        }
        if(dialogueUIActive)
        {
            ManageDialogue();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(activeQuickQuest == quickQuestInRange && quickQuestInRange != null)
            {
                dialogueIndex = 0;
                SetDialogueUIActive();
            }
        }
    }

    private void SetfloorMarkerUI()
    {
        if (playerFloorMarker)
        {
            floorMarkerUIActive = !floorMarkerUIActive;
            floorMarkerUI.SetActive(floorMarkerUIActive);
            Text text = floorMarkerUI.GetComponentInChildren<Text>();
            Image background = floorMarkerUI.GetComponentInChildren<Image>();
            text.text = playerFloorMarker.GetInfoText();
            Color color = playerFloorMarker.GetColor();
            color.a = uIOpaqueLevel;
            background.color = color;
        }
       
    }

    void SetPathfindingMenuActive()
    {
        pathfindingMenuActive = !pathfindingMenuActive;
        pathfindingMenu.SetActive(pathfindingMenuActive);
    }

    void SetMainMenuActive()
    {
        mainMenuActive = !mainMenuActive;
        mainMenu.SetActive(mainMenuActive);
    }

    public void SetDialogueUIActive()
    {
        dialogueUIActive = !dialogueUIActive;
        dialogueUI.SetActive(dialogueUIActive);
        if(dialogueUI.activeInHierarchy)
        {
            dialogueIndex = 0;
            questDialogueText.text = dialogue[dialogueIndex];
            questGiverNameText.text = questGiverName;
        }
    }

    public void GetQuickQuestData(string[] dialogue, string questGiverName, string questDescription,  QuickQuest quickQuest)
    {
        this.dialogue = dialogue;
        this.questGiverName = questGiverName;
        this.activeQuickQuest = quickQuest;
        questObjectiveText.text = questDescription;
    }

    void ManageDialogue()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (dialogueIndex >= 1)
            {
                dialogueIndex--;
                questDialogueText.text = dialogue[dialogueIndex];
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (dialogueIndex < dialogue.Length - 1)
            {
                dialogueIndex++;
                questDialogueText.text = dialogue[dialogueIndex];
            }
        }
    }

    public void ResetQuestUI()
    {
        questObjectiveText.text = noQuestText;
        activeQuickQuest = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FloorMarker>())
        {
            playerFloorMarker = other.GetComponent<FloorMarker>();
        }
        /*if (other.GetComponent<QuestGiver>())
        {
            questManager.currentQuestGiver = other.GetComponent<QuestGiver>();
        }*/
        if (other.GetComponent<QuickQuest>())
        {
            quickQuestInRange = other.GetComponent<QuickQuest>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FloorMarker>())
        {
            playerFloorMarker = null;
            floorMarkerUIActive = false;
            floorMarkerUI.SetActive(false);
        }
        if (other.GetComponent<QuestGiver>())
        {
            //questManager.currentQuestGiver = null;
            //dialogueUIActive = false;
            //dialogueUI.SetActive(false);
        }
        if(other.GetComponent<QuickQuest>())
        {
            quickQuestInRange = null;
            dialogueUIActive = false;
            dialogueUI.SetActive(false);
        }
    }
}
