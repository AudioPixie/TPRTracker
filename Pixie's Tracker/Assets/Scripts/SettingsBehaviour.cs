using UnityEngine;
using UnityEngine.UI;

// bit of a misnomer, should be called "TabsBehaviour" or something

public class SettingsBehaviour : MonoBehaviour
{
    public GameObject ScrollBox;
    public GameObject Viewport;
    private Toggle toggle;
    private RectTransform CurrentDungeon;
    private GameObject NewDungeon;

    public void SettingsInitialize()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        ScrollBox = GameObject.Find("ScrollBox");
        Viewport = GameObject.Find("Viewport");

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
        if (gameObject.name == "Main")
        {
            foreach (Transform child1 in Viewport.transform)
            {
                foreach (Transform child2 in child1.transform)
                {
                    if (child2.GetComponent<ListChecksBehaviour>().isPoe == false)
                    {
                        child2.gameObject.SetActive(isOn);
                    }
                }
            }
        }

        if (gameObject.name == "Poes")
        {
            foreach (Transform child1 in Viewport.transform)
            {
                foreach (Transform child2 in child1.transform)
                {
                    if (child2.GetComponent<ListChecksBehaviour>().isPoe == true)
                    {
                        child2.gameObject.SetActive(isOn);
                    }
                }
            }
        }
        
        GameManager.Instance.Refresh();
    }
}
