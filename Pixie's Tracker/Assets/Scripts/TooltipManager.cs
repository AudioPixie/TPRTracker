using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public GameObject Tooltip;
    public TMP_Text TooltipText;

    private static TooltipManager instance;

    public static TooltipManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TooltipManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(TooltipManager).Name);
                    instance = singletonObject.AddComponent<TooltipManager>();
                }
            }
            return instance;
        }
    }

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
        Tooltip.SetActive(false);
    }

    public void Show(string rename, Vector3 checkPosition)
    {
        TooltipText.text = rename;
        Tooltip.transform.position = new Vector3(checkPosition.x, checkPosition.y + 20, checkPosition.z);
        Tooltip.SetActive(true);
    }

    public void Hide()
    {
        Tooltip.SetActive(false);
    }

}
