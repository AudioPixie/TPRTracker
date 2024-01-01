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

    public void SaveData()
    {
        // Regular Items
        foreach (Transform child1 in RegularItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            PlayerPrefs.SetInt(child1.name, child2.GetComponent<ItemBehaviour>().currentItemCount);
        }

        // Boss Items
        foreach (Transform child1 in BossItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            PlayerPrefs.SetInt(child1.name, child2.GetComponent<ItemBehaviour>().currentItemCount);
        }

        // Long Items
        foreach (Transform child1 in LongItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            foreach (Transform child3 in child2)
            {
                PlayerPrefs.SetInt(child3.name, child3.GetComponent<ItemBehaviour>().currentItemCount);
            }
        }

        // Keys
        for (int i = 0; i < KeyItemsContainer.transform.childCount; i++)
        {
            Transform child = KeyItemsContainer.transform.GetChild(i);

            if (i % 3 != 0)
                PlayerPrefs.SetInt(child.name, child.GetComponent<ItemBehaviour>().currentItemCount);
        }

        // Overworld Checks
        foreach (Transform child1 in MapChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                PlayerPrefs.SetInt(child2.name, child2.GetComponent<Toggle>().isOn ? 1 : 0);
                PlayerPrefs.SetInt(child2.name + "_mark", child2.GetComponent<ChecksBehaviour>().checkImportance);
            }
        }

        // Dungeon Checks
        foreach (Transform child1 in DungeonChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                PlayerPrefs.SetInt(child2.name, child2.GetComponent<Toggle>().isOn ? 1 : 0);
                PlayerPrefs.SetInt(child2.name + "_mark", child2.GetComponent<ListChecksBehaviour>().checkImportance);
            }
        }

        // General Settings
        foreach (Transform child in GeneralBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child.name, child.GetComponent<Toggle>().isOn ? 1 : 0);
        }

        // Seed Settings
        foreach (Transform child in SeedBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child.name, child.GetComponent<Toggle>().isOn ? 1 : 0);
            if (child.GetComponent<TMP_Dropdown>() != null)
                PlayerPrefs.SetInt(child.name, child.GetComponent<TMP_Dropdown>().value);
        }

        // Visual Settings
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.GetComponent<Toggle>() != null)
                PlayerPrefs.SetInt(child1.name, child1.GetComponent<Toggle>().isOn ? 1 : 0);
            if (child1.GetComponent<Slider>() != null)
                PlayerPrefs.SetFloat(child1.name, child1.GetComponent<Slider>().value);
            if (child1.name == "ShowRegularItems" || child1.name == "ShowDungeons")
            {
                foreach (Transform child2 in child1)
                    PlayerPrefs.SetInt(child2.name, child2.GetComponent<Toggle>().isOn ? 1 : 0);
            }
        }

        // Rupees
        PlayerPrefs.SetInt("rupees", GameManager.Instance.walletCount);

        // Spoiler Log
        SpoilerManager.Instance.SaveSpoilerLog();
    }

    public void LoadData()
    {
        // Regular Items
        foreach (Transform child1 in RegularItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            child2.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child1.name);
            child2.GetComponent<ItemBehaviour>().ItemRefresh();
        }

        // Boss Items
        foreach (Transform child1 in BossItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            child2.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child1.name);
            child2.GetComponent<ItemBehaviour>().ItemRefresh();
        }

        // Long Items
        foreach (Transform child1 in LongItemsContainer.transform)
        {
            Transform child2 = child1.GetChild(1);

            foreach (Transform child3 in child2)
            {
                child3.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child3.name);
                child3.GetComponent<ItemBehaviour>().ItemRefresh();
            }
        }

        // Keys
        for (int i = 0; i < KeyItemsContainer.transform.childCount; i++)
        {
            Transform child = KeyItemsContainer.transform.GetChild(i);

            if (i % 3 != 0)
            {
                child.GetComponent<ItemBehaviour>().currentItemCount = PlayerPrefs.GetInt(child.name);
                child.GetComponent<ItemBehaviour>().ItemRefresh();
            }
        }

        // Overworld Checks
        foreach (Transform child1 in MapChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name) != 0;
                child2.GetComponent<ChecksBehaviour>().checkImportance = PlayerPrefs.GetInt(child2.name + "_mark");
            }
        }

        // Dungeon Checks
        foreach (Transform child1 in DungeonChecksContainer.transform)
        {
            foreach (Transform child2 in child1)
            {
                child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name) != 0;
                child2.GetComponent<ListChecksBehaviour>().checkImportance = PlayerPrefs.GetInt(child2.name + "_mark");
            }
        }

        // General Settings
        foreach (Transform child in GeneralBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                child.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child.name) != 0;
        }

        // Seed Settings
        foreach (Transform child in SeedBG.transform)
        {
            if (child.GetComponent<Toggle>() != null)
                child.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child.name) != 0;
            if (child.GetComponent<TMP_Dropdown>() != null)
                child.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt(child.name);
        }

        // Visual Settings
        foreach (Transform child1 in VisualBG.transform)
        {
            if (child1.GetComponent<Toggle>() != null)
                child1.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child1.name) != 0;
            if (child1.GetComponent<Slider>() != null)
                child1.GetComponent<Slider>().value = PlayerPrefs.GetFloat(child1.name);
            if (child1.name == "ShowRegularItems" || child1.name == "ShowDungeons")
            {
                foreach (Transform child2 in child1)
                    child2.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(child2.name) != 0;
            }
        }

        // Rupees
        GameManager.Instance.walletCount = PlayerPrefs.GetInt("rupees");
        TextManager.Instance.SetWalletText();

        // Spoiler Log
        if (PlayerPrefs.HasKey("currentSpoilerLog"))
        {
            SpoilerManager.Instance.LoadSavedSpoilerLog(PlayerPrefs.GetString("currentSpoilerLog"));
        }

        GameManager.Instance.Refresh();

    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
