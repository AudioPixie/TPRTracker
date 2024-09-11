using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// located on verification yes button, should really be 

public class ResetBehaviour : MonoBehaviour
{
    public string query;

    [Header("Items")]
    public GameObject RegularItemsContainer;
    public GameObject BossItemsContainer;
    public GameObject LongItemsContainer;
    public GameObject KeyItemsContainer;

    [Header("Checks")]
    public GameObject MapChecksContainer;
    public GameObject DungeonChecksContainer;

    [Header("Settings Panels")]
    public GameObject GeneralBG;
    public GameObject SeedBG;

    [Header("Dialogs")]
    public GameObject Prompt;
    public GameObject Loading;
    public GameObject NoSave; // dialog if no save is found

    [Header("Hints subpanels")]
    public GameObject LoadPage;
    public GameObject HintPage;

    [Header("Go Mode")]
    public GameObject GoModeIcon;

    // determines "yes" behaviour
    public void SetInput(string input)
    {
        query = input;
    }

    public void OnClick()
    {
        Prompt.SetActive(false);
        Loading.SetActive(true);

        if (query == "Tracker")
        {

            // Resets Regular Items
            foreach (Transform child1 in RegularItemsContainer.transform)
            {
                Transform child2 = child1.GetChild(1);

                while (child2.GetComponent<ItemBehaviour>().currentItemCount > 0)
                {
                    child2.GetComponent<ItemBehaviour>().ItemDecrement();
                }

                if (child1.name == "Tunic")
                    child2.GetComponent<ItemBehaviour>().ItemIncrement();
            }

            // Resets Boss Items
            foreach (Transform child1 in BossItemsContainer.transform)
            {
                Transform child2 = child1.GetChild(1);

                child2.GetComponent<ItemBehaviour>().currentItemCount = 0;
                child2.GetComponent<ItemBehaviour>().BossItemRefresh();
            }

            // Resets Long Items
            foreach (Transform child1 in LongItemsContainer.transform)
            {
                Transform child2 = child1.GetChild(1);

                foreach (Transform child3 in child2)
                {
                    while (child3.GetComponent<ItemBehaviour>().currentItemCount > 0)
                    {
                        child3.GetComponent<ItemBehaviour>().ItemDecrement();
                    }
                }
            }

            // Resets Keys
            for (int i = 0; i < KeyItemsContainer.transform.childCount; i++)
            {
                Transform child = KeyItemsContainer.transform.GetChild(i);

                if (i % 3 != 0)
                {
                    while (child.GetComponent<ItemBehaviour>().currentItemCount > 0)
                    {
                        child.GetComponent<ItemBehaviour>().ItemDecrement();
                    }
                }
            }

            // Resets Overworld Checks
            foreach (Transform child1 in MapChecksContainer.transform)
            {
                foreach (Transform child2 in child1)
                {
                    if (child2.GetComponent<Toggle>().isOn == false)
                        child2.GetComponent<Toggle>().isOn = true;

                    child2.GetComponent<ChecksBehaviour>().checkImportance = 0;
                }
            }

            // Resets Dungeon Checks
            foreach (Transform child1 in DungeonChecksContainer.transform)
            {
                foreach (Transform child2 in child1)
                {
                    if (child2.GetComponent<Toggle>().isOn == false)
                        child2.GetComponent<Toggle>().isOn = true;

                    child2.GetComponent<ListChecksBehaviour>().checkImportance = 0;
                }
            }

            if (GameManager.Instance.GoModeToggle.isOn == true)
                GameManager.Instance.GoModeToggle.isOn = false;
            GameManager.Instance.ReactivateGoMode();
            GameManager.Instance.walletCount = 0;
        }

        else if (query == "Settings")
        {
            // Resets General Settings
            foreach (Transform child in GeneralBG.transform)
            {
                if (child.GetComponent<Toggle>() != null)
                    child.GetComponent<Toggle>().isOn = false;

                if (child.name == "RupeeMode" || child.name == "TrackHowlingStones")
                    child.GetComponent<Toggle>().isOn = true;
            }

            // Resets Seed Settings
            foreach (Transform child in SeedBG.transform)
            {
                if (child.GetComponent<Toggle>() != null)
                    child.GetComponent<Toggle>().isOn = false;
                if (child.GetComponent<TMP_Dropdown>() != null)
                    child.GetComponent<TMP_Dropdown>().value = 0;
            }
        }

        else if (query == "Save1")
        {
            SaveManager.Instance.SaveData("_1");
        }

        else if (query == "Load1")
        {
            if (PlayerPrefs.HasKey("AGBigKey_1"))
            {
                SaveManager.Instance.LoadData("_1");
            }
            else
                NoSave.SetActive(true);
        }

        else if (query == "Save2")
        {
            SaveManager.Instance.SaveData("_2");
        }

        else if (query == "Load2")
        {
            if (PlayerPrefs.HasKey("AGBigKey_2"))
            {
                SaveManager.Instance.LoadData("_2");
            }
            else
                NoSave.SetActive(true);
        }

        else if (query == "Save3")
        {
            SaveManager.Instance.SaveData("_3");
        }

        else if (query == "Load3")
        {
            if (PlayerPrefs.HasKey("AGBigKey_3"))
            {
                SaveManager.Instance.LoadData("_3");
            }
            else
                NoSave.SetActive(true);
        }

        else if (query == "Delete")
        {
            SaveManager.Instance.DeleteData();
        }

        else if (query == "Dump")
        {
            LoadPage.SetActive(true);
            HintPage.SetActive(false);
        }

        else if (query == "Race")
        {
            RaceManager.Instance.ImportRaceSettings();
        }

        else if (query == "SaveNoteTemplate")
        {
            SaveManager.Instance.SaveNoteTemplate();
        }

        else if (query == "LoadNoteTemplate")
        {
            SaveManager.Instance.LoadNoteTemplate();
        }

        else if (query == "UserLayoutSave")
        {
            SaveManager.Instance.SaveUserLayout();
        }

        else
        {
            Debug.LogWarning("Fallthrough");
        }

        Prompt.SetActive(true);
        Loading.SetActive(false);

        GameManager.Instance.Refresh();
    }
}
