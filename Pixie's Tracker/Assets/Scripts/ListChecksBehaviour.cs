using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.EventSystems;

public class ListChecksBehaviour : MonoBehaviour, IPointerClickHandler
{

    [Header("Fill in")]
    public GameObject DungeonBox; // linked dungeon box on map
    [SerializeField]
    private bool isPoe;
    public int rupeesWorth; // for hint rupee mode

    [Header("Info")]
    public bool checkCompletion;
    public bool checkAvailibility;
    public int checkImportance; // 0 = normal, 1 = junk item, 2 = star item. 0 by default

    [Header("Spoiler Log Info")]
    public string checkContents;
    public string region;

    // self
    private Toggle toggle;
    private Text toggleText;

    public void DCheckInitialize()
    {
        toggle = GetComponent<Toggle>();
        toggleText = GetComponentInChildren<Text>();
        checkImportance = 0;
    }

    public void DCheckRefresh()
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

        if (toggle.isOn == true)
            checkCompletion = false;
        else
            checkCompletion = true;

        // Changes colour
        if (checkCompletion == false) // if unobtained, color
        {
            if (checkImportance == 0)
            {
                if (checkAvailibility == true)
                {
                    if (isPoe == false)
                        toggleText.color = GameManager.Instance.OverworldColor;
                    else
                        toggleText.color = GameManager.Instance.PoeColor;
                }
                else
                {
                    toggleText.color = Color.red;
                }
            }

            else if (checkImportance == 1)
            {
                toggleText.color = GameManager.Instance.JunkColor;
            }

            else if (checkImportance == 2)
            {
                toggleText.color = GameManager.Instance.StarColor;
            }
        }
        else // gray if obtained
        {
            toggleText.color = new Color(0.7f, 0.7f, 0.7f, 1);
        }

    }

    // OnClick, updates counters and wallet
    public void DUpdateCount()
    {
        if (toggle.isOn == true)
        {
            GameManager.Instance.checkCountRemaining += 1;
            GameManager.Instance.checkCountCompleted -= 1;
            TextManager.Instance.SetRemainingText();
            checkCompletion = false;

            if (GameManager.Instance.RupeeMode.isOn == true)
            {
                GameManager.Instance.walletCount -= rupeesWorth;
                if (GameManager.Instance.walletCount < 0)
                    GameManager.Instance.walletCount = 0;
            }

            if (checkAvailibility == true)
            {
                GameManager.Instance.checkCountAvailable += 1;
                TextManager.Instance.SetAvailableText();
            }
        }
        else
        {
            GameManager.Instance.checkCountRemaining -= 1;
            GameManager.Instance.checkCountCompleted += 1;
            TextManager.Instance.SetRemainingText();
            checkCompletion = true;

            GameManager.Instance.walletCount += rupeesWorth;

            if (checkAvailibility == true)
            {
                GameManager.Instance.checkCountAvailable -= 1;
                TextManager.Instance.SetAvailableText();
            }
        }

        TextManager.Instance.SetWalletText();
        GameManager.Instance.HintRefresh();

        DungeonBox.GetComponent<DungeonBehaviour>().UpdateDCheckCount();
    }

    // Right-clicking for star and junk items
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && checkCompletion == false)
        {
            checkImportance += 1;
            if (checkImportance > 2)
                checkImportance = 0;
            DCheckRefresh();
        }
    }
}
