using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{
    [Header("Items")]
    public GameObject RegularItemsContainer;
    public GameObject BossItemsContainer;
    public GameObject LongItemsContainer;
    public GameObject KeyItemsContainer;

    [Header("Checks")]
    public GameObject MapChecksContainer;
    public GameObject DungeonChecksContainer;

    [Header("Settings")]
    public GameObject GeneralBG;
    public GameObject SeedBG;
    public GameObject VisualBG;

    [Header("Tabs")]
    public Toggle MainTab;
    public Toggle PoesTab;
    public Toggle BugsTab;
    public Toggle HintsTab;
    public Toggle NotepadTab;

    [Header("Text")]
    public TMP_InputField InputField;

    [Header("Hint Overlay")]
    public Toggle HintOverlayToggle;

    private static SaveManager instance;

    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveManager).Name);
                    instance = singletonObject.AddComponent<SaveManager>();
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

    public void SaveData(string file)
    {
        // Regular Items
        foreach (Transform child1 in RegularItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            PlayerPrefs.SetInt(child1.name + file, child2.GetComponent<ItemBehaviour>().currentItemCount);
        }

        // Boss Items
        foreach (Transform child1 in BossItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            PlayerPrefs.SetInt(child1.name + "_count" + file, child2.GetComponent<ItemBehaviour>().currentItemCount);
            PlayerPrefs.SetInt(child1.name + "_bossIndex" + file, child2.GetComponent<ItemBehaviour>().currentBossIndex);
        }

        // Long Items
        foreach (Transform child1 in LongItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            foreach (Transform child3 in child2)
            {
                PlayerPrefs.SetInt(child3.name + file, child3.GetComponent<ItemBehaviour>().currentItemCount);
            }
        }

        // Keys
        for (int i = 0; i < KeyItemsContainer.transform.childCount; i++)
        {
            Transform child = KeyItemsContainer.transform.GetChild(i);

            if (i % 3 != 0)
                PlayerPrefs.SetInt(child.name + file, child.GetComponent<ItemBehaviour>().currentItemCount);
        }

        // Overworld Checks
        foreach (Transform child1 in MapChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                PlayerPrefs.SetInt(child2.name + file, child2.GetComponent<Toggle>().isOn ? 1 : 0);
                PlayerPrefs.SetInt(child2.name + "_mark" + file, child2.GetComponent<ChecksBehaviour>().checkImportance);
            }
        }

        // Dungeon Checks
        foreach (Transform child1 in DungeonChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                PlayerPrefs.SetInt(child2.name + file, child2.GetComponent<Toggle>().isOn ? 1 : 0);
                PlayerPrefs.SetInt(child2.name + "_mark" + file, child2.GetComponent<ListChecksBehaviour>().checkImportance);
            }
        }

        // General Settings
        foreach (Transform child in GeneralBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child.name + file, child.GetComponent<Toggle>().isOn ? 1 : 0);
            if (child.GetComponent<TMP_Dropdown>() != null)
                PlayerPrefs.SetInt(child.name + file, child.GetComponent<TMP_Dropdown>().value);
        }

        // Seed Settings
        foreach (Transform child in SeedBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child.name + file, child.GetComponent<Toggle>().isOn ? 1 : 0);
            if (child.GetComponent<TMP_Dropdown>() != null)
                PlayerPrefs.SetInt(child.name + file, child.GetComponent<TMP_Dropdown>().value);
        }

        // Visual Settings
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child1.name + file, child1.GetComponent<Toggle>().isOn ? 1 : 0);
            if (child1.GetComponent<Slider>() != null)
                PlayerPrefs.SetFloat(child1.name + file, child1.GetComponent<Slider>().value);
            if (child1.name == "ShowRegularItems")
            {
                foreach (Transform child2 in child1)
                    PlayerPrefs.SetInt(child2.name + file, child2.GetComponent<Toggle>().isOn ? 1 : 0);
            }
            if (child1.name == "BGColor")
            {
                PlayerPrefs.SetString(child1.name + file, child1.GetComponentInChildren<TMP_InputField>().text);
            }
        }

        // Rupees
        PlayerPrefs.SetInt("Rupees" + file, GameManager.Instance.walletCount);

        // Spoiler Log
        SpoilerManager.Instance.SaveSpoilerLog(file);

        // Tabs
        PlayerPrefs.SetInt("MainTab" + file, MainTab.isOn ? 1 : 0);
        PlayerPrefs.SetInt("PoesTab" + file, PoesTab.isOn ? 1 : 0);
        PlayerPrefs.SetInt("BugsTab" + file, BugsTab.isOn ? 1 : 0);
        PlayerPrefs.SetInt("HintsTab" + file, HintsTab.isOn ? 1 : 0);
        PlayerPrefs.SetInt("NotepadTab" + file, NotepadTab.isOn ? 1 : 0);

        // Notes
        PlayerPrefs.SetString("Notes" + file, InputField.text);

        // Go Mode
        PlayerPrefs.SetInt("GoModeToggle" + file, GameManager.Instance.GoModeToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("GoModeUsed" + file, GameManager.Instance.GoModeUsed ? 1 : 0);

        // Hint Overlay
        PlayerPrefs.SetInt("HintOverlayToggle" + file, HintOverlayToggle.isOn ? 1 : 0);
    }

    public void LoadData(string file)
    {
        // Regular Items
        foreach (Transform child1 in RegularItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);
            child2.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child1.name + file);
            child2.GetComponent<ItemBehaviour>().ItemRefresh();
        }

        // Boss Items
        foreach (Transform child1 in BossItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            child2.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child1.name + "_count" + file);
            child2.GetComponent<ItemBehaviour>().currentBossIndex = PlayerPrefs.GetInt(child1.name + "_bossIndex" + file);
            child2.GetComponent<ItemBehaviour>().BossItemRefresh();
        }

        // Long Items
        foreach (Transform child1 in LongItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            foreach (Transform child3 in child2)
            {
                child3.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child3.name + file);
                child3.GetComponent<ItemBehaviour>().ItemRefresh();
            }
        }

        // Keys
        for (int i = 0; i < KeyItemsContainer.transform.childCount; i++)
        {
            Transform child = KeyItemsContainer.transform.GetChild(i);

            if (i % 3 != 0)
            {
                child.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child.name + file);
                child.GetComponent<ItemBehaviour>().ItemRefresh();
            }
        }

        // Overworld Checks
        foreach (Transform child1 in MapChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name + file) != 0;
                child2.GetComponent<ChecksBehaviour>().checkImportance = PlayerPrefs.GetInt(child2.name + "_mark" + file);
            }
        }

        // Dungeon Checks
        foreach (Transform child1 in DungeonChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name + file) != 0;
                child2.GetComponent<ListChecksBehaviour>().checkImportance = PlayerPrefs.GetInt(child2.name + "_mark" + file);
            }
        }

        // General Settings
        foreach (Transform child in GeneralBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                child.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child.name + file) != 0;
            if (child.GetComponent<TMP_Dropdown>() != null)
                child.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt(child.name + file);
        }

        // Seed Settings
        foreach (Transform child in SeedBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                child.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child.name + file) != 0;
            if (child.GetComponent<TMP_Dropdown>() != null)
                child.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt(child.name + file);
        }

        // Visual Settings
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.GetComponent<Toggle>() != null)
                child1.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child1.name + file) != 0;
            if (child1.GetComponent<Slider>() != null)
                child1.GetComponent<Slider>().value = PlayerPrefs.GetFloat(child1.name + file);
            if (child1.name == "ShowRegularItems")
            {
                foreach (Transform child2 in child1)
                    child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name + file) != 0;
            }
            if (child1.name == "BGColor")
            {
                child1.GetComponentInChildren<TMP_InputField>().text = PlayerPrefs.GetString(child1.name + file);
            }
        }

        // Rupees
        GameManager.Instance.walletCount = PlayerPrefs.GetInt("Rupees" + file);
        TextManager.Instance.SetWalletText();

        // Spoiler Log
        SpoilerManager.Instance.LoadSavedSpoilerLog(PlayerPrefs.GetString("currentSpoilerLog" + file), file);

        // Tabs
        MainTab.isOn = PlayerPrefs.GetInt("MainTab" + file) != 0;
        PoesTab.isOn = PlayerPrefs.GetInt("PoesTab" + file) != 0;
        BugsTab.isOn = PlayerPrefs.GetInt("BugsTab" + file) != 0;
        HintsTab.isOn = PlayerPrefs.GetInt("HintsTab" + file) != 0;
        NotepadTab.isOn = PlayerPrefs.GetInt("NotepadTab" + file) != 0;

        // Notes
        InputField.text = PlayerPrefs.GetString("Notes" + file);

        // Go Mode
        GameManager.Instance.GoModeToggle.isOn = PlayerPrefs.GetInt("GoModeToggle" + file) != 0;
        GameManager.Instance.GoModeUsed = PlayerPrefs.GetInt("GoModeUsed" + file) != 0;

        // Hint Overlay
        HintOverlayToggle.isOn = PlayerPrefs.GetInt("HintOverlayToggle" + file) != 0;

        GameManager.Instance.Refresh();

    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveNoteTemplate()
    {
        PlayerPrefs.SetString("NoteTemplate", InputField.text);
    }

    public void LoadNoteTemplate()
    {
       InputField.text = PlayerPrefs.GetString("NoteTemplate");
    }

    public void SaveUserLayout()
    {
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child1.name + "userLayout", child1.GetComponent<Toggle>().isOn ? 1 : 0);
            if (child1.GetComponent<Slider>() != null)
                PlayerPrefs.SetFloat(child1.name + "userLayout", child1.GetComponent<Slider>().value);
            if (child1.name == "ShowRegularItems")
            {
                foreach (Transform child2 in child1)
                    PlayerPrefs.SetInt(child2.name + "userLayout", child2.GetComponent<Toggle>().isOn ? 1 : 0);
            }
            if (child1.name == "BGColor")
            {
                PlayerPrefs.SetString(child1.name + "userLayout", child1.GetComponentInChildren<TMP_InputField>().text);
            }
        }
    }

    public void LoadUserLayout()
    {
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.GetComponent<Toggle>() != null)
                child1.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child1.name + "userLayout") != 0;
            if (child1.GetComponent<Slider>() != null)
                child1.GetComponent<Slider>().value = PlayerPrefs.GetFloat(child1.name + "userLayout");
            if (child1.name == "ShowRegularItems")
            {
                foreach (Transform child2 in child1)
                    child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name + "userLayout") != 0;
            }
            if (child1.name == "BGColor")
            {
                child1.GetComponentInChildren<TMP_InputField>().text = PlayerPrefs.GetString(child1.name + "userLayout");
            }
        }
    }

    public void SaveUserBGColor()
    {
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.name == "BGColor")
            {
                PlayerPrefs.SetString(child1.name + "userBGColor", child1.GetComponentInChildren<TMP_InputField>().text);
            }
        }
    }

    public void LoadUserBGColor()
    {
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.name == "BGColor")
            {
                child1.GetComponentInChildren<TMP_InputField>().text = PlayerPrefs.GetString(child1.name + "userBGColor");
            }
        }
    }
}
