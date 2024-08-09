using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RaceManager : MonoBehaviour
{
    private static RaceManager instance;

    public static RaceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RaceManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SpoilerManager).Name);
                    instance = singletonObject.AddComponent<RaceManager>();
                }
            }
            return instance;
        }
    }

    [Header("Setup")]
    public string raceFolderName = "RaceSettingsLog"; // folder to create
    public string raceFolderPath; // location of new folder

    public List<string> raceJsonFiles = new List<string>();

    public Button PresetRace;

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

    void Start()
    {
        // Get the path for spoiler log folder
        raceFolderPath = Path.Combine(Application.dataPath, raceFolderName);

        // Check if the folder already exists
        if (!Directory.Exists(raceFolderPath))
        {
            // If it doesn't exist, create the folder
            Directory.CreateDirectory(raceFolderPath);
        }
    }

    public void ImportRaceSettings()
    {
        ScanRaceFolder();
    }

    public void ScanRaceFolder()
    {
        raceJsonFiles.Clear();

        // Get all json files in directory 
        string[] arrayJsonFiles = Directory.GetFiles(raceFolderPath, "*.json");

        // convert to list
        for (int i = 0; i < arrayJsonFiles.Length; i++)
        {
            raceJsonFiles.Add(arrayJsonFiles[i]);
        }

        // only continue if there is exactly 1 file
        if (raceJsonFiles.Count == 1)
        {
            ApplyRaceLog();
        }
        else if (raceJsonFiles.Count > 1)
        {
            Debug.LogWarning("Multiple files in RaceSettingsLog");
        }
        else // no files present
        {
            Debug.LogWarning("No files in RaceSettingsLog");
        }
    }

    public void ApplyRaceLog()
    {
        // get string out of list
        string raceLogJson = raceJsonFiles[0];
        // json to string
        string raceLogString = File.ReadAllText(raceLogJson);
        // remove spaces
        string raceModifiedString = raceLogString.Replace(" ", "");
        // Parse the JSON data
        SpoilerManager.Instance.spoilerLog = JsonUtility.FromJson<SpoilerLog>(raceModifiedString);

        SpoilerManager.Instance.ApplyAutoReset();
        SpoilerManager.Instance.ApplyAutoSettings();
        SpoilerManager.Instance.BugsTab.isOn = false;
        PresetRace.onClick.Invoke();
        SpoilerManager.Instance.ExcludeManual();
        SpoilerManager.Instance.ApplyAutoStartingItems();

        GameManager.Instance.Refresh();
    }
}