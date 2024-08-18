using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class VersionChecker : MonoBehaviour
{
    public string remoteVersionUrl = "https://raw.githubusercontent.com/AudioPixie/TPRTracker/main/version.txt";
    public string localVersion;
    public string docsURL = "https://github.com/AudioPixie/TPRTracker?tab=readme-ov-file#tprtracker";
    public string latestReleaseURL = "https://github.com/AudioPixie/TPRTracker/releases";

    public Button UpdateResult;

    void Start()
    {
        UpdateResult.interactable = false;
        CheckForUpdate();
    }

    public void CheckForUpdate()
    {
        UpdateResult.interactable = false;
        UpdateResult.GetComponentInChildren<TMP_Text>().text = "<color=#C900CA>Loading...</color>";
        StartCoroutine(CheckVersionCoroutine());
    }

    private IEnumerator CheckVersionCoroutine()
    {
        localVersion = Application.version;

        // Fetch remote version
        using (UnityWebRequest www = UnityWebRequest.Get(remoteVersionUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string remoteVersion = www.downloadHandler.text.Trim();
                CompareVersions(localVersion, remoteVersion);
            }
            else
            {
                UpdateResult.interactable = false;
                UpdateResult.GetComponentInChildren<TMP_Text>().text = "<color=#FF4400>Connection failed, please try again.</color>";
            }
        }
    }

    private void CompareVersions(string localVersion, string remoteVersion)
    {
        if (localVersion == remoteVersion)
        {
            UpdateResult.interactable = false;
            UpdateResult.GetComponentInChildren<TMP_Text>().text = "<color=#00BF00>Version is up to date</color>";
        }
        else
        {
            UpdateResult.interactable = true;
            UpdateResult.GetComponentInChildren<TMP_Text>().text = "<color=#CFA700>Version " + remoteVersion + " available <u>here</u></color>";
        }
    }

    public void OpenDocs()
    {
        Application.OpenURL(docsURL);
    }

    public void OpenLatestVersion()
    {
        Application.OpenURL(latestReleaseURL);
    }
}