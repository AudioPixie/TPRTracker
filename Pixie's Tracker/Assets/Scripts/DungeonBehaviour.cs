using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DungeonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private GameObject DungeonContainer; // contains corresponding checks in viewport
    [SerializeField]
    private string headerName;
    [SerializeField]
    private string tooltipName;
    [SerializeField]
    private bool isPoe;

    private int totalDCheckCount;
    private int availableDCheckCount;
    private int completedDCheckCount;

    private TMP_Text DungeonCounter; // number on dungeon

    public ScrollRect scrollRect;

    public void DungeonInitialize()
    {
        DungeonCounter = GetComponentInChildren<TMP_Text>();

        scrollRect = GameObject.Find("ScrollBox").GetComponent<ScrollRect>();
        OnDungeonClick();
        LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content); // fixes list spacing issue
    }

    public void UpdateDCheckCount() // updates dungeon check counter and color
    {
        availableDCheckCount = 0;
        completedDCheckCount = 0;
        totalDCheckCount = 0;

        foreach (Transform child in DungeonContainer.transform)
        {
            if (child.gameObject.activeSelf == true)
                totalDCheckCount += 1;
        }

        foreach (Transform child in DungeonContainer.transform)
        {
            if (child.GetComponent<ListChecksBehaviour>().checkAvailibility == true
                && child.GetComponent<ListChecksBehaviour>().checkCompletion == false
                && child.gameObject.activeSelf == true)
            {
                availableDCheckCount += 1;
            }
        }

        if (availableDCheckCount > 0)
        {
            DungeonCounter.text = availableDCheckCount.ToString();
        }
        else // if the dungeon has no available checks, no number is displayed
        {
            DungeonCounter.text = "";
        }

        foreach (Transform child in DungeonContainer.transform)
        {
            if (child.GetComponent<ListChecksBehaviour>().checkCompletion == true
                && child.gameObject.activeSelf == true)
            {
                completedDCheckCount += 1;
            }
        }

        // colour
        
        // gray - completed
        if (completedDCheckCount == totalDCheckCount)
        {
            GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);

            if (DungeonContainer.activeInHierarchy == true)
                ScrollManager.Instance.Header.color = new Color(0.7f, 0.7f, 0.7f, 1);
        }

        // green - all remaining are available
        else if (availableDCheckCount == (totalDCheckCount - completedDCheckCount))
        {
            GetComponent<Image>().color = GameManager.Instance.OverworldColor;

            if (DungeonContainer.activeInHierarchy == true)
                ScrollManager.Instance.Header.color = GameManager.Instance.OverworldColor;
        }

        // red - none remaining available
        else if (availableDCheckCount == 0)
        {
            GetComponent<Image>().color = Color.red;

            if (DungeonContainer.activeInHierarchy == true)
                ScrollManager.Instance.Header.color = Color.red;
        }

        // yellow - some remaining available
        else if ((availableDCheckCount > 0) && !(availableDCheckCount == (totalDCheckCount - completedDCheckCount)))
        {
            GetComponent<Image>().color = new Color(0.89f, 0.84f, 0, 1);

            if (DungeonContainer.activeInHierarchy == true)
                ScrollManager.Instance.Header.color = new Color(0.89f, 0.84f, 0, 1);
        }

        // blue - just in case something escapes previous logic
        else
        {
            GetComponent<Image>().color = Color.blue;

            if (DungeonContainer.activeInHierarchy == true)
                ScrollManager.Instance.Header.color = Color.blue;
        }


    }

    public void OnDungeonClick()
    {
        ScrollManager.Instance.ChangeDungeon(DungeonContainer.GetComponent<RectTransform>(), headerName);
        UpdateDCheckCount();
    }

    // Tooltip hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.Show(tooltipName, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
}
