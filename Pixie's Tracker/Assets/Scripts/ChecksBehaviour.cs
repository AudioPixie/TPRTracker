using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Reflection;

public class ChecksBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Fill in")]
    public string tooltipName; // display name for tooltip hover
    public GameObject room;
    public int checksWorth; // so flight by fowl can be worth 5 checks in the counters
    public int rupeesWorth; // for hint rupee mode

    [Header("Info")]
    public string checkType; // overworld, poe, or bug
    public bool checkAvailibility;
    public bool checkCompletion;
    public int checkImportance; // 0 = normal, 1 = junk item, 2 = star item. 0 by default

    [Header("Spoiler Log Info")]
    public string checkContents;
    public string region;

    private Toggle toggle; // self

    public void CheckInitialize()
    {
        toggle = GetComponent<Toggle>();
        checkImportance = 0;
    }

    public void CheckRefresh()
    {
        if (room.GetComponent<RoomBehaviour>().isAccessible == true)
        {
            MethodInfo methodInfo = typeof(LogicManager).GetMethod(this.gameObject.name); // check gameobject names match logicmanager and spoiler log names perfectly

            // Checks Logic Manager for availibility and sets checkAvailibility
            if (methodInfo != null)
            {
                object returnValue = methodInfo.Invoke(LogicManager.Instance, null);

                if (returnValue is bool)
                {
                    bool result = (bool)returnValue;

                    if (result)
                        checkAvailibility = true;
                    else
                        checkAvailibility = false;
                }
                else
                {
                    // If didn't return bool
                    Debug.LogError("Method did not return a boolean: " + this.gameObject.name);
                }
            }
            else
            {
                // If method name does not exist
                Debug.LogError("Method not found: " + this.gameObject.name);
            }
        }
        else
            checkAvailibility = false;

        // Changes colour
        if (checkImportance == 0)
        {
            if (checkAvailibility == true)
            {
                if (checkType == "Overworld" && gameObject.activeInHierarchy == true)
                {
                    toggle.graphic.color = GameManager.Instance.OverworldColor;
                }

                if (checkType == "Poe" && gameObject.activeInHierarchy == true)
                {
                    toggle.graphic.color = GameManager.Instance.PoeColor;
                }

                if (checkType == "Bug" && gameObject.activeInHierarchy == true)
                {
                    toggle.graphic.color = GameManager.Instance.BugColor;
                }

            }
            else
            {
                if (gameObject.activeInHierarchy == true)
                {
                    toggle.graphic.color = Color.red;
                }

            }
        }

        else if (checkImportance == 1)
        {
            toggle.graphic.color = GameManager.Instance.JunkColor;
        }

        else if (checkImportance == 2)
        {
            toggle.graphic.color = GameManager.Instance.StarColor;
        }

        // changes completion status
        if (toggle.isOn == true)
            checkCompletion = false;
        else
            checkCompletion = true;
    }

    // OnClick, updates counters and wallet
    public void UpdateCount()
    {
        if (toggle.isOn == true)
        {
            GameManager.Instance.checkCountRemaining += checksWorth;
            GameManager.Instance.checkCountCompleted -= checksWorth;
            TextManager.Instance.SetRemainingText();

            if (GameManager.Instance.RupeeMode.isOn == true)
            {
                GameManager.Instance.walletCount -= rupeesWorth;
                if (GameManager.Instance.walletCount < 0)
                    GameManager.Instance.walletCount = 0;
            }

            checkCompletion = false;

            if (checkAvailibility == true)
            {
                GameManager.Instance.checkCountAvailable += checksWorth;
                TextManager.Instance.SetAvailableText();
            }
        }
        else
        {
            GameManager.Instance.checkCountRemaining -= checksWorth;
            GameManager.Instance.checkCountCompleted += checksWorth;
            TextManager.Instance.SetRemainingText();

            GameManager.Instance.walletCount += rupeesWorth;

            checkCompletion = true;

            if (checkAvailibility == true)
            {
                GameManager.Instance.checkCountAvailable -= checksWorth;
                TextManager.Instance.SetAvailableText();
            }
        }

        TextManager.Instance.SetWalletText();
        GameManager.Instance.HintRefresh();
    }

    // Right-clicking for star and junk items
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && checkCompletion == false)
        {
            checkImportance += 1;
            if (checkImportance > 2)
                checkImportance = 0;
            CheckRefresh();
        }
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
