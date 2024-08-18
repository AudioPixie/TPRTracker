using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollManager : MonoBehaviour
{
    private static ScrollManager instance;

    public static ScrollManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScrollManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(ScrollManager).Name);
                    instance = singletonObject.AddComponent<ScrollManager>();
                }
            }
            return instance;
        }
    }

    public RectTransform CurrentDungeon;
    public GameObject ScrollBox;
    public GameObject PoeChecks;
    public GameObject Viewport;
    public TMP_Text Header;

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

    public void ScrollInitialize()
    {
        CurrentDungeon = ScrollBox.GetComponent<ScrollRect>().content;
    }

    public void ChangeDungeon(RectTransform newDungeon, string newDungeonName)
    {
        CurrentDungeon = ScrollBox.GetComponent<ScrollRect>().content;
        ScrollBox.GetComponent<ScrollRect>().content = newDungeon;
        CurrentDungeon.gameObject.SetActive(false);
        newDungeon.gameObject.SetActive(true);
        Header.text = newDungeonName;
    }

    public void ClearDungeon()
    {
        int tempRupees = 0;

        foreach (Transform child in ScrollBox.GetComponent<ScrollRect>().content)
        {
            if (child.GetComponent<Toggle>().isOn == true)
            {
                child.GetComponent<Toggle>().isOn = false;
                tempRupees += child.GetComponent<ListChecksBehaviour>().rupeesWorth;
            }
        }

        GameManager.Instance.walletCount -= tempRupees;
        GameManager.Instance.HintRefresh();
    }

    public void ClearOverworldPoes()
    {
        int tempRupees = 0;

        foreach (Transform child in PoeChecks.transform)
        {
            if (child.GetComponent<Toggle>().isOn == true)
            {
                child.GetComponent<Toggle>().isOn = false;
                tempRupees += child.GetComponent<ChecksBehaviour>().rupeesWorth;
            }
        }

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                if (child2.GetComponent<Toggle>().isOn == true
                    && child2.GetComponent<ListChecksBehaviour>().checkType == "Poe"
                    && child2.GetComponent<ListChecksBehaviour>().isDungeon == false)
                {
                    child2.GetComponent<Toggle>().isOn = false;
                    tempRupees += child2.GetComponent<ListChecksBehaviour>().rupeesWorth;
                }
            }
        }

        GameManager.Instance.walletCount -= tempRupees;
        GameManager.Instance.HintRefresh();
    }

        public void ClearDungeonPoes()
    {
        int tempRupees = 0;

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                if (child2.GetComponent<Toggle>().isOn == true
                    && child2.GetComponent<ListChecksBehaviour>().checkType == "Poe"
                    && child2.GetComponent<ListChecksBehaviour>().isDungeon == true)
                {
                    child2.GetComponent<Toggle>().isOn = false;
                    tempRupees += child2.GetComponent<ListChecksBehaviour>().rupeesWorth;
                }
            }
        }

        GameManager.Instance.walletCount -= tempRupees;
        GameManager.Instance.HintRefresh();
    }

}
