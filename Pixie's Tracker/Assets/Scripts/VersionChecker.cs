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
        localVersion = Application.version;
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
        string urlWithCacheBuster = $"{remoteVersionUrl}?cache_buster={System.DateTime.UtcNow.Ticks}";
        // Fetch remote version
        using (UnityWebRequest webRequest = new UnityWebRequest(urlWithCacheBuster, "GET"))
        {
            // Set cache control header to prevent caching
            webRequest.SetRequestHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1
            webRequest.SetRequestHeader("Pragma", "no-cache"); // HTTP 1.0
            webRequest.SetRequestHeader("Expires", "0"); // Proxies

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                UpdateResult.interactable = false;
                UpdateResult.GetComponentInChildren<TMP_Text>().text = "<color=#FF4400>Connection failed, please try again.</color>";
                Debug.LogWarning(webRequest.result);
            }
            else
            {
                Debug.LogWarning(webRequest.result);
                string remoteVersion = webRequest.downloadHandler.text.Trim();
                Debug.LogWarning(remoteVersion);
                CompareVersions(localVersion, remoteVersion);
            }
        }
    }

    private void CompareVersions(string localVersion, string remoteVersion)
    {
        if (localVersion == remoteVersion)
        {
            UpdateResult.interactable = false;
            UpdateResult.GetComponentInChildren<TMP_Text>().text = "<color=#00BF00>Version is up to date: </color>" + localVersion + ", " + remoteVersion;
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