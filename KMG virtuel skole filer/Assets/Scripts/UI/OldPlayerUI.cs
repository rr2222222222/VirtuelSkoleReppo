using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OldQuestManager))]
public class OldPlayerUI : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float uIOpaqueLevel = 0.8f;

    //CACHED REFERENCES
    GameObject mainMenu;
    GameObject pathfindingMenu;
    GameObject uNGoalMenu;
    public FloorMarker playerFloorMarker;
    OldQuestManager questManager;

    //STATES
    bool pathfindingMenuActive = false;
    bool mainMenuActive = false;
    bool uNGoalMenuActive = false;
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
    string[] dialogue;
    int dialogueIndex;

    private void Awake()
    {
        questManager = GetComponent<OldQuestManager>();
        if(!questManager)
        {
            Debug.LogError("No Quest Manager script found on player");
        }
    }

    private void Start()
    {
        mainMenu = GameObject.FindWithTag("Main Menu");
        pathfindingMenu = GameObject.FindWithTag("Pathfinding Menu");
        uNGoalMenu = GameObject.FindWithTag("UN Goal");

        if(mainMenu && pathfindingMenu && uNGoalMenu)
        {
            Debug.Log("Main menu, pathfinding menu & UN Goal menu found");
        }
        else
        {
            Debug.Log("Menus not found");
        }
        SetUIActive();
        ResetQuestUI();
    }

    void SetUIActive()
    {
        if (mainMenu) { mainMenu.SetActive(false); }
        else { Debug.LogError("Main menu is not assigned"); }
        if (pathfindingMenu) { pathfindingMenu.SetActive(false); }
        else { Debug.LogError("Pathfinding menu is not assigned"); }
        if (uNGoalMenu) { uNGoalMenu.SetActive(false); }
        else { Debug.LogError("UN goal menu is not assigned"); }
        if(dialogueUI) { dialogueUI.SetActive(false); }
        else { Debug.LogError("Dialogue field is not assigned"); }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SetPathfindingMenuActive();
            if (mainMenuActive) { SetMainMenuActive(); }
            if (uNGoalMenuActive) { SetUNGoalMenu(); }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetMainMenuActive();
            if (pathfindingMenuActive) { SetPathfindingMenuActive(); }
            if (uNGoalMenuActive) { SetUNGoalMenu(); }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetUNGoalMenu();
            if (pathfindingMenuActive) { SetPathfindingMenuActive(); }
            if (mainMenuActive) { SetMainMenuActive(); }
        }
        if(dialogueUIActive)
        {
            ManageDialogue();
        }
    }

    private void SetUNGoalMenu()
    {
        if (playerFloorMarker)
        {
            uNGoalMenuActive = !uNGoalMenuActive;
            uNGoalMenu.SetActive(uNGoalMenuActive);
            Text text = uNGoalMenu.GetComponentInChildren<Text>();
            Image background = uNGoalMenu.GetComponentInChildren<Image>();
            text.text = playerFloorMarker.GetInfoText();
            Color color = playerFloorMarker.GetColor();
            color.a = uIOpaqueLevel;
            background.color = color;
        }
        else
        {
            Debug.Log("The player does not appear to be in contact with a floor marker");
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
    }

    public void LoadQuestDialogueData(string questGiverName, string questDescription, string[] dialogue)
    {
        questGiverNameText.text = questGiverName;
        questObjectiveText.text = questDescription;
        this.dialogue = dialogue;
        dialogueIndex = 0;
        questDialogueText.text = dialogue[dialogueIndex];
    }

    public void LoadNextObjectiveText(string objectiveText)
    {
        questObjectiveText.text = objectiveText;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        playerFloorMarker = other.GetComponent<FloorMarker>();

        if (other.GetComponent<OldQuestGiver>())
        {
            questManager.currentQuestGiver = other.GetComponent<OldQuestGiver>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FloorMarker>())
        {
            playerFloorMarker = null;
            uNGoalMenuActive = false;
            uNGoalMenu.SetActive(false);
        }
        if (other.GetComponent<OldQuestGiver>())
        {
            questManager.currentQuestGiver = null;
            dialogueUIActive = false;
            dialogueUI.SetActive(false);
        }
    }
}
