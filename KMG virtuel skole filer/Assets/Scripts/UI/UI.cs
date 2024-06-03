using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //For the dropdown
    [Header("Dropdown menu")]
    [SerializeField] Dropdown roomDropdown;
    [SerializeField] List<NavPoint> navpointsKaelder;
    [SerializeField] List<NavPoint> navpointsEtage0;
    [SerializeField] List<NavPoint> navpointsEtage1;
    [SerializeField] List<NavPoint> navpointsEtage2;
    [SerializeField] List<NavPoint> navpointsEtage3;
    [SerializeField] List<NavPoint> navpointsEtage4;
    List<List<NavPoint>> lists = new List<List<NavPoint>>();
    List<NavPoint> currentList;
    PlayerNavMesh playerNavMesh;
    NavPoint target;


    [SerializeField] Toggle toggle;
    bool autoPathfind = true;


    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        playerNavMesh = FindObjectOfType<PlayerNavMesh>();
        lists.Add(navpointsKaelder);
        lists.Add(navpointsEtage0);
        lists.Add(navpointsEtage1);
        lists.Add(navpointsEtage2);
        lists.Add(navpointsEtage3);
        lists.Add(navpointsEtage4);

        UpdateDropdown(1);
    }

    public void UpdateDropdown(int floorIndex)
    {
        roomDropdown.options.Clear();
        foreach (NavPoint navpoint in lists[floorIndex])
        {
            roomDropdown.options.Add(new Dropdown.OptionData() { text = navpoint.name });
        }
        roomDropdown.RefreshShownValue();
        currentList = lists[floorIndex];
    }

    public void Pathfind()
    {
        int index = roomDropdown.value;
        foreach (NavPoint navpoint in currentList)
        {
            if (navpoint.name == roomDropdown.options[index].text)
            {
                target = navpoint;
                break;
            }
        }
        if (target)
        {
            playerNavMesh.ShowPath(target);
        }
        else
        {

        }
    }

    public void Pathfind(NavPoint target)
    {
        if (autoPathfind)
        {
            playerNavMesh.ShowPath(target);
        }
    }

    public void AutoPathfind()
    {
        autoPathfind = toggle.isOn;

    }

    



    public void Quit()
    {
        Application.Quit();
    }
}
