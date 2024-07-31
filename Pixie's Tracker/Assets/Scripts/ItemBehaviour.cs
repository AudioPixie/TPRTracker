using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class ItemBehaviour : MonoBehaviour, IPointerClickHandler
{

    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;

    [Header("Sprites")]
    public Image buttonImage; // link
    public Sprite[] images; // used if sprite swap, first sprite is the "off sprite"
    public bool isSpriteSwap; // false = counter type

    [Header("Counters")]
    public int maxItemCount; // e.g. bow 3
    public int currentItemCount = 0; // 0 = not obtained yet
    public TMP_Text buttonText;

    [SerializeField]
    private string nameCount; // Link to LogicManager ItemCounts dictionary
    [SerializeField]
    private bool isBoss;

    private Color opaque = Color.white;
    private Color faded = new Vector4(1, 1, 1, 0.45f);
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
        if (currentItemCount == 0 && (nameCount != "WalletCount") && isBoss == false) // && not wallet - to do
        {
            buttonImage.color = faded;
            buttonText.text = "";
        }

        else if (currentItemCount == 0 && isBoss == true) // && not wallet - to do
        {
            buttonImage.color = bossFaded;
            buttonText.text = "";
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
            buttonText.text = currentItemCount.ToString();
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
            buttonText.text = currentItemCount.ToString();
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

}
