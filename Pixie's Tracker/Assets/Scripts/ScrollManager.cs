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


}