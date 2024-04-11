using UnityEngine;
using UnityEngine.UI;

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

    [Header("Parents Objects")]
    public GameObject Map;
    public GameObject Viewport; // contains all dungeon checks
    public GameObject Dungeons;

    public GameObject LayerTabs;
    public GameObject OverlayInfo;

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
        GameObject.Find("OrdonVillage").GetComponent<DungeonBehaviour>().OnDungeonClick();

        OverlayInfo.SetActive(true); // boot up page

        GoModeUsed = false;
    }

    // Iterate through all child objects and refresh
    public void Refresh()
    {
        int tempAvailCount = 0;

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

        Debug.Log(QualitySettings.vSyncCount);
        Debug.Log(Application.runInBackground);
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

}
