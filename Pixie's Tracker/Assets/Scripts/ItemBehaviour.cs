using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class ItemBehaviour : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;

    [Header("Sprites")]
    public Image buttonImage; // link
    public Sprite[] images; // used if sprite swap, first sprite is the "off sprite"
    public bool isSpriteSwap; // false = counter type

    [Header("Bosses")]
    public string[] bossNames;
    public TMP_Text bossTitle;
    public int currentBossIndex;
    public GameObject bossesParent;

    [Header("Counters")]
    public int maxItemCount; // e.g. bow 3
    public int currentItemCount = 0; // 0 = not obtained yet
    public TMP_Text buttonText;

    [SerializeField]
    private string nameCount; // Link to LogicManager ItemCounts dictionary
    [SerializeField]
    private string[] bossNameCount;
    [SerializeField]
    private bool isBoss;
    [SerializeField]
    private bool isDungeonKey;

    [Header("Tooltips")]
    [SerializeField]
    private string tooltipName;
    [SerializeField]
    private string[] bossTooltipNames;
    [SerializeField]
    private Toggle ItemTooltipToggle;

    private Color opaque = Color.white;
    private Color fadedAlpha = new Vector4(1, 1, 1, 0.40f);
    private Color fadedBlack = new Vector4(0.40f, 0.40f, 0.40f, 1);
    private Color bossFaded = new Vector4(1, 1, 1, 0.25f);

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        ItemOpacity();
    }

    public void ItemIncrement()
    {
        if (currentItemCount < maxItemCount)
        {
            currentItemCount += 1;

            ItemRefresh();
        }
    }

    public void ItemIncrementNoRefresh()
    {
        if (currentItemCount < maxItemCount)
        {
            currentItemCount += 1;

            ItemRefreshNoGameManager();
        }
    }

    public void ItemDecrement()
    {
        if (currentItemCount > 0)
        {
            currentItemCount -= 1;

            ItemRefresh();
        }
    }

    public void ItemOpacity()
    {
        if (currentItemCount == 0 && (nameCount != "Wallet"))
        {
            if (((GameManager.Instance.ItemTransparency == true && isDungeonKey == false) || (GameManager.Instance.KeyTransparency == true && isDungeonKey == true)) && isBoss == false)
            {
                buttonImage.color = fadedAlpha;
                buttonText.text = "";
            }
            else if (((GameManager.Instance.ItemTransparency == false && isDungeonKey == false) || (GameManager.Instance.KeyTransparency == false && isDungeonKey == true)) && isBoss == false)
            {
                buttonImage.color = fadedBlack;
                buttonText.text = "";
            }
            else if (isBoss == true)
            {
                buttonImage.color = bossFaded;
                buttonText.text = "";
            }
        }
        else
        {
            buttonImage.color = opaque;
        }

        if (currentItemCount < maxItemCount)
        {
            buttonText.color = Color.white;
        }
        else
        {
            buttonText.color = Color.green;
        }
    }

    public void ItemRefresh()
    {
        LogicManager.Instance.ItemCounts[nameCount] = currentItemCount;

        GameManager.Instance.Refresh();

        if (isSpriteSwap == true)
        {
            buttonImage.sprite = images[currentItemCount];
        }
        else
        {
            if (nameCount != "Skybook")
                buttonText.text = currentItemCount.ToString();
            else
            {
                if (currentItemCount == 1)
                    buttonText.text = "B";
                else
                    buttonText.text = (currentItemCount - 1).ToString();
            }
        }

        ItemOpacity();
    }

    public void ItemRefreshNoGameManager()
    {
        LogicManager.Instance.ItemCounts[nameCount] = currentItemCount;

        if (isSpriteSwap == true)
        {
            buttonImage.sprite = images[currentItemCount];
        }
        else
        {
            if (nameCount != "Skybook")
                buttonText.text = currentItemCount.ToString();
            else
            {
                if (currentItemCount == 1)
                    buttonText.text = "B";
                else
                    buttonText.text = (currentItemCount - 1).ToString();
            }
        }

        ItemOpacity();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onLeftClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick.Invoke();
        }
    }

    public void BossIncrementDecrement()
    {
        if (currentItemCount == 0)
        {
            currentItemCount = 1;

            BossItemRefresh();
        }
        else if (currentItemCount == 1)
        {
            currentItemCount = 0;

            BossItemRefresh();
        }

        foreach (Transform child1 in bossesParent.transform)
        {
            Transform child2 = child1.GetChild(1);
            
            if (child2.GetComponent<ItemBehaviour>() != this 
            && (this.currentBossIndex == child2.GetComponent<ItemBehaviour>().currentBossIndex))
            {
                child2.GetComponent<ItemBehaviour>().currentItemCount = this.currentItemCount;
                child2.GetComponent<ItemBehaviour>().ItemOpacity();
            }
        }

    }

    public void BossItemRefresh()
    {
        buttonImage.sprite = images[currentBossIndex];
        bossTitle.text = bossNames[currentBossIndex];
        nameCount = bossNameCount[currentBossIndex];

        LogicManager.Instance.ItemCounts[nameCount] = currentItemCount;

        GameManager.Instance.Refresh();

        ItemOpacity();
    }

    public void BossCycle()
    {
        if (currentBossIndex < 7)
            currentBossIndex++;
        else
            currentBossIndex = 0;

        ShowTooltip();

        int noMatchCount = 0;

        foreach (Transform child1 in bossesParent.transform)
        {
            Transform child2 = child1.GetChild(1);
            
            if (child2.GetComponent<ItemBehaviour>() != this 
            && (this.currentBossIndex == child2.GetComponent<ItemBehaviour>().currentBossIndex)) // if 2 instances of same boss
            {
                this.currentItemCount = child2.GetComponent<ItemBehaviour>().currentItemCount; // match state of other boss instance 
                this.BossItemRefresh();
            }
            else if (child2.GetComponent<ItemBehaviour>() != this)
            {
                noMatchCount++;
            }
        }

        if (noMatchCount == 7) // if no instances of same boss
        {
            this.currentItemCount = 0; // default to off
            this.BossItemRefresh();
        }

        CleanUpGhostDungeons();

        this.BossItemRefresh();
    }

    public void CleanUpGhostDungeons() // if a dungeon is not represented by any of the 8 boss medallions, set it to uncompleted
    {
        for (int i = 0; i < 8; i++)
        {
            int dungeonMatch = 0;
            foreach (Transform child1 in bossesParent.transform)
            {
                Transform child2 = child1.GetChild(1);

                if (child2.GetComponent<ItemBehaviour>().currentBossIndex == i)
                {
                    dungeonMatch++;
                    break;
                }
            }

            if (dungeonMatch == 0)
            {
                string tempNameCount = bossNameCount[i];
                LogicManager.Instance.ItemCounts[tempNameCount] = 0;
            }
        }
    }

    // Tooltip hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }

    public void ShowTooltip()
    {
        if (ItemTooltipToggle.isOn)
        {
            if (isBoss == false)
                TooltipManager.Instance.Show(tooltipName, transform.position);
            else
                TooltipManager.Instance.Show(bossTooltipNames[currentBossIndex], transform.position);
        }
    }

}
