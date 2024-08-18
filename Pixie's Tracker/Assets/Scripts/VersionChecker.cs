using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class VersionChecker : MonoBehaviour
{
    // URL to your version file on GitHub
    private string versionUrl = "https://raw.githubusercontent.com/AudioPixie/TPRTracker/tree/logic-fix/version.txt";
    private string currentVersion;

    void Start()
    {
        StartCoroutine(CheckForUpdates());
    }

    IEnumerator CheckForUpdates()
    {
        currentVersion = Application.version; // Get version from Player Settings
        using (UnityWebRequest request = UnityWebRequest.Get(versionUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string latestVersion = request.downloadHandler.text.Trim();
                if (IsNewVersion(latestVersion))
                {
                    NotifyUser(latestVersion);
                }
            }
            else
            {
                Debug.LogError("Failed to check for updates: " + request.error);
            }
        }
    }

    bool IsNewVersion(string latestVersion)
    {
        // Simple version comparison, assuming versions are in "major.minor.patch" format
        var current = new Version(currentVersion);
        var latest = new Version(latestVersion);
        return latest.CompareTo(current) > 0;
    }

    void NotifyUser(string newVersion)
    {
        // Notify the user about the update
        Debug.Log($"A new version ({newVersion}) is available!");
        // You can implement your notification system here
    }
}