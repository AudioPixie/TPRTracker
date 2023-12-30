using UnityEngine;
using UnityEngine.UI;

// bit of a misnomer, should be called "TabsBehaviour" or something

public class SettingsBehaviour : MonoBehaviour
{
    public GameObject ScrollBox;
    private Toggle toggle;
    private RectTransform CurrentDungeon;
    private GameObject NewDungeon;

    public void SettingsInitialize()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        ScrollBox = GameObject.Find("ScrollBox");

        if (gameObject.name == "Main")
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    public void OnToggleValueChanged(bool isOn)
    {
        if (isOn && ((gameObject.name == "Main") || (gameObject.name == "Poes"))) // switches between main and poe dungeon check lists
        {
            CurrentDungeon = ScrollBox.GetComponent<ScrollRect>().content;
            if (CurrentDungeon.GetComponent<TwinBehaviour>().Twin != null &&
                ((gameObject.name == "Main" && CurrentDungeon.GetComponent<TwinBehaviour>().isPoe_twin == true)
                ||
                (gameObject.name == "Poes" && CurrentDungeon.GetComponent<TwinBehaviour>().isPoe_twin == false)))
            {
                NewDungeon = CurrentDungeon.GetComponent<TwinBehaviour>().Twin;
                ScrollManager.Instance.ChangeDungeon(NewDungeon.GetComponent<RectTransform>(), NewDungeon.GetComponent<TwinBehaviour>().twinHeaderName);
            }
        }

        GameManager.Instance.Refresh();
    }
}
