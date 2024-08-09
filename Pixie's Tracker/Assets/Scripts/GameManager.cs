using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    [Header("Map Checks")]
    public GameObject OVChecks;
    public GameObject PoeChecks; 
    public GameObject BugChecks;

    [Header("Parent Objects")]
    public GameObject Map;
    public GameObject Viewport; // contains all dungeon checks
    public GameObject Dungeons;

    public GameObject LayerTabs;
    public GameObject OverlayInfo;

    [Header("Rooms")]
    public GameObject Rooms;
    public List<GameObject> RoomsToCheck = new List<GameObject>();
    public List<GameObject> RoomsDiscovered = new List<GameObject>();

    [Header("Warp/Starting Locations")]
    public GameObject OutsideLinksHouse;
    public GameObject SouthFaronWoods;
    public GameObject NorthFaronWoods;
    public GameObject SacredGroveLower;
    public GameObject KakarikoGorge;
    public GameObject LowerKakarikoVillage;
    public GameObject DeathMountainVolcano;
    public GameObject OutsideCastleTownWest;
    public GameObject LakeHylia;
    public GameObject ZorasThroneRoom;
    public GameObject SnowpeakSummitUpper;

    [Header("Check Colors")]
    public Color OverworldColor;
    public Color PoeColor;
    public Color BugColor;

    public Color StarColor;
    public Color JunkColor;

    [Header("Counters")]
    public int checkCountTotal;
    public int checkCountCompleted;
    public int checkCountRemaining;
    public int checkCountAvailable;

    [Header("Hints")]
    public Button SmallHint;
    public Button MediumHint;
    public Button LargeHint;
    public int walletCount;
    public Toggle RupeeMode;

    [Header("Go Mode")]
    public GameObject GoMode;
    public bool GoModeUsed;

    [Header("VSync")]
    public int vSync;

    [Header("Default List Box")]
    public GameObject OrdonVillageBox;

    private void Awake()
    {
        // Ensure only one instance exists, even if multiple scripts try to create it.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 2;
        Application.runInBackground = false;

        // number of checks and text initialization
        checkCountTotal = 0;

        foreach (Transform child1 in Map.transform)
            foreach (Transform child2 in child1.transform)
                checkCountTotal += child2.GetComponent<ChecksBehaviour>().checksWorth;

        foreach (Transform child1 in Viewport.transform)
            foreach (Transform child2 in child1.transform)
                checkCountTotal += 1;

        TextManager.Instance.SetTotalText();

        checkCountCompleted = 0;
        checkCountRemaining = checkCountTotal;

        TextManager.Instance.SetRemainingText();

        walletCount = 0;

        TextManager.Instance.SetWalletText();

        Initialize();
        Refresh();
    }

    public void Initialize()
    {
        // Iterate through all child objects and initialize
        foreach (Transform child in OVChecks.transform)
        {
            child.GetComponent<ChecksBehaviour>().CheckInitialize();
        }
        foreach (Transform child in PoeChecks.transform)
        {
            child.GetComponent<ChecksBehaviour>().CheckInitialize();
        }
        foreach (Transform child in BugChecks.transform)
        {
            child.GetComponent<ChecksBehaviour>().CheckInitialize();
        }

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                child2.GetComponent<ListChecksBehaviour>().DCheckInitialize();
            }
        }

        foreach (Transform child1 in Dungeons.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                child2.GetComponent<DungeonBehaviour>().DungeonInitialize();
            }
        }

        foreach (Transform child in LayerTabs.transform)
        {
            if (child.GetComponent<SettingsBehaviour>() != null)
                child.GetComponent<SettingsBehaviour>().SettingsInitialize();
        }

        ScrollManager.Instance.ScrollInitialize();

        // Sets Ordon as default dungeon
        OrdonVillageBox.GetComponent<DungeonBehaviour>().OnDungeonClick();

        OverlayInfo.SetActive(true); // boot up page

        GoModeUsed = false;
    }

    // Iterate through all child objects and refresh
    public void Refresh()
    {
        int tempAvailCount = 0;

        FloodRooms();

        foreach (Transform child1 in Map.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                child2.GetComponent<ChecksBehaviour>().CheckRefresh();
                if (child2.GetComponent<ChecksBehaviour>().checkAvailibility == true &&
                    child2.GetComponent<ChecksBehaviour>().checkCompletion == false)
                    tempAvailCount += child2.GetComponent<ChecksBehaviour>().checksWorth;
            }
        }

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                child2.GetComponent<ListChecksBehaviour>().DCheckRefresh();
                if (child2.GetComponent<ListChecksBehaviour>().checkAvailibility == true &&
                    child2.GetComponent<ListChecksBehaviour>().checkCompletion == false)
                    tempAvailCount += 1;
            }
        }

        foreach (Transform child1 in Dungeons.transform)
        {

            foreach (Transform child2 in child1.transform)
            {
                child2.GetComponent<DungeonBehaviour>().UpdateDCheckCount();
            }
        }

        checkCountAvailable = tempAvailCount;
        TextManager.Instance.SetAvailableText();
        if (LogicManager.Instance.GoMode() && GoModeUsed == false)
        {
            GoMode.SetActive(true);
            GoModeUsed = true;
        }
    }

    public void RefreshSelective(GameObject Parent) // can selectively refresh just overworld, poes, or bugs
    {
        foreach (Transform child in Parent.transform)
        {
            child.GetComponent<ChecksBehaviour>().CheckRefresh();
        }
    }

    public void ReactivateGoMode()
    {
        GoModeUsed = false;
        Refresh();
    }

    public void HintRefresh()
    {
        if (RupeeMode.isOn) // toggles hint tier interactivity based on rupee count
        {
            if (walletCount >= 5)
                SmallHint.interactable = true;
            else
                SmallHint.interactable = false;

            if (walletCount >= 20)
                MediumHint.interactable = true;
            else
                MediumHint.interactable = false;

            if (walletCount >= 50)
                LargeHint.interactable = true;
            else
                LargeHint.interactable = false;
        }
        else // all are on if rupee mode is disabled
        {
            SmallHint.interactable = true;
            MediumHint.interactable = true;
            LargeHint.interactable = true;
        }

        TextManager.Instance.SetWalletText();
    }

    public void FloodRooms()
    {
        Debug.Log("<size=25><color=cyan>GRAPH START</color></size>");
        RoomsToCheck.Clear();
        foreach (Transform child1 in Rooms.transform)
        {
            foreach(Transform child2 in child1.transform)
            {
                child2.GetComponent<RoomBehaviour>().isAccessible = false;
                //Debug.Log("<color=red>FALSE</color> Initialize: " + child2.name);
            }
        }

        OutsideLinksHouse.GetComponent<RoomBehaviour>().isAccessible = true;
        RoomsToCheck.Add(OutsideLinksHouse);
        Debug.Log("<color=lime>ORDON</color>: True");

        if (LogicManager.Instance.SettingsStatus["UnlockMapRegions"] && LogicManager.Instance.Has("ShadowCrystal"))
        {
            if (LogicManager.Instance.SettingsStatus["SkipFaronTwilight"])
            {
                SouthFaronWoods.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(SouthFaronWoods);
                Debug.Log("<color=magenta>WARP</color> TRUE: SouthFaronWoods");
                NorthFaronWoods.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(NorthFaronWoods);
                Debug.Log("<color=magenta>WARP</color> TRUE: NorthFaronWoods");
            }

            if (LogicManager.Instance.SettingsStatus["SkipEldinTwilight"])
            {
                KakarikoGorge.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(KakarikoGorge);
                Debug.Log("<color=magenta>WARP</color> TRUE: KakarikoGorge");
                LowerKakarikoVillage.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(LowerKakarikoVillage);
                Debug.Log("<color=magenta>WARP</color> TRUE: LowerKakarikoVillage");
                DeathMountainVolcano.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(DeathMountainVolcano);
                Debug.Log("<color=magenta>WARP</color> TRUE: DeathMountainVolcano");
            }

            if (LogicManager.Instance.SettingsStatus["SkipLanayruTwilight"])
            {
                LakeHylia.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(LakeHylia);
                Debug.Log("<color=magenta>WARP</color> TRUE: LakeHylia");
                OutsideCastleTownWest.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(OutsideCastleTownWest);
                Debug.Log("<color=magenta>WARP</color> TRUE: OutsideCastleTownWest");
                ZorasThroneRoom.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(ZorasThroneRoom);
                Debug.Log("<color=magenta>WARP</color> TRUE: ZorasDomain");
            }

            if (LogicManager.Instance.SettingsStatus["EarlySnowpeak"])
            {
                SnowpeakSummitUpper.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(SnowpeakSummitUpper);
                Debug.Log("<color=magenta>WARP</color> TRUE: SnowpeakSummitUpper");
            }

            if (!LogicManager.Instance.SettingsStatus["ToTClosed"])
            {
                SacredGroveLower.GetComponent<RoomBehaviour>().isAccessible = true;
                RoomsToCheck.Add(SacredGroveLower);
                Debug.Log("<color=magenta>WARP</color> TRUE: SacredGroveLower");
            }
        }

        while (RoomsToCheck.Count > 0)
        {
        Debug.Log("<size=25><color=orange>START OF BATCH</color></size>");
            RoomsDiscovered.Clear();
 
            foreach (GameObject room in RoomsToCheck)
            {
                Debug.Log("<color=yellow>CHECKING ROOM</color>: " + room.name);
                foreach (GameObject neighbour in room.GetComponent<RoomBehaviour>().neighboursList)
                {
                    if (neighbour.GetComponent<RoomBehaviour>().isAccessible == false)
                    {
                        bool pathReturn = room.GetComponent<RoomBehaviour>().checkNeighbour(neighbour.name);
                        neighbour.GetComponent<RoomBehaviour>().isAccessible = pathReturn;
                        if (pathReturn == true)
                            RoomsDiscovered.Add(neighbour);
                        Debug.Log("Path: " + neighbour.name + " = " + pathReturn);
                    }
                }
            }

            RoomsToCheck.Clear();
            foreach (GameObject discoveredRoom in RoomsDiscovered)
            {
                RoomsToCheck.Add(discoveredRoom);
                Debug.Log("<color=lightblue>ADDING</color> to next batch: " + discoveredRoom.name);
            }

        }

        Debug.Log("<size=25><color=green>GRAPH SUCCESS</color></size>");

    }

}
