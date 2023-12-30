using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{

    private static TextManager instance;

    public static TextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TextManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(TextManager).Name);
                    instance = singletonObject.AddComponent<TextManager>();
                }
            }
            return instance;
        }
    }

    public TMP_Text AvailableText;
    public TMP_Text RemainingText;
    public TMP_Text TotalText;

    public TMP_Text RupeeText;

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

    public void SetTotalText()
    {
        TotalText.text = "Total Checks: " + GameManager.Instance.checkCountTotal;
    }

    public void SetRemainingText()
    {
        RemainingText.text = "Remaining Checks: " + GameManager.Instance.checkCountRemaining;
    }

    public void SetAvailableText()
    {
        AvailableText.text = "Available Checks: " + GameManager.Instance.checkCountAvailable;
    }

    public void SetWalletText()
    {
        RupeeText.text = GameManager.Instance.walletCount.ToString();
    }

}
