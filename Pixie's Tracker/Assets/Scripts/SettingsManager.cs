using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    private static SettingsManager instance;

    public static SettingsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SettingsManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SettingsManager).Name);
                    instance = singletonObject.AddComponent<SettingsManager>();
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

    public void SetHCRequirements(int index)
    {
        LogicManager.Instance.SettingsStatus["HCVanilla"] = false;
        LogicManager.Instance.SettingsStatus["HCAllDungeons"] = false;
        LogicManager.Instance.SettingsStatus["HCMirrorShards"] = false;
        LogicManager.Instance.SettingsStatus["HCFusedShadows"] = false;
        LogicManager.Instance.SettingsStatus["HCOpen"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["HCVanilla"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["HCAllDungeons"] = true;
        else if (index == 2)
            LogicManager.Instance.SettingsStatus["HCMirrorShards"] = true;
        else if (index == 3)
            LogicManager.Instance.SettingsStatus["HCFusedShadows"] = true;
        else
            LogicManager.Instance.SettingsStatus["HCOpen"] = true;
    }

    public void SetPoTRequirements(int index)
    {
        LogicManager.Instance.SettingsStatus["PoTVanilla"] = false;
        LogicManager.Instance.SettingsStatus["PoTMirrorShards"] = false;
        LogicManager.Instance.SettingsStatus["PoTFusedShadows"] = false;
        LogicManager.Instance.SettingsStatus["PoTOpen"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["PoTVanilla"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["PoTMirrorShards"] = true;
        else if (index == 2)
            LogicManager.Instance.SettingsStatus["PoTFusedShadows"] = true;
        else
            LogicManager.Instance.SettingsStatus["PoTOpen"] = true;
    }

    public void SetFaronEscape(int index)
    {
        if (index == 0)
            LogicManager.Instance.SettingsStatus["FaronEscape"] = true;
        else
            LogicManager.Instance.SettingsStatus["FaronEscape"] = false;
    }

    public void SetPrologueSkip(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["SkipPrologue"] = isOn;
    }

    public void SetFaronTwilightSkip(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["SkipFaronTwilight"] = isOn;
    }

    public void SetEldinTwilightSkip(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["SkipEldinTwilight"] = isOn;
    }

    public void SetLanayruTwilightSkip(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["SkipLanayruTwilight"] = isOn;
    }

    public void SetMDHSkip(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["SkipMDH"] = isOn;
    }

    public void SetMinesRequirements(int index)
    {
        LogicManager.Instance.SettingsStatus["MinesClosed"] = false;
        LogicManager.Instance.SettingsStatus["MinesNoWrestling"] = false;
        LogicManager.Instance.SettingsStatus["MinesOpen"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["MinesClosed"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["MinesNoWrestling"] = true;
        else
            LogicManager.Instance.SettingsStatus["MinesOpen"] = true;
    }

    public void SetEarlyLakebed(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["EarlyLakebed"] = isOn;
    }

    public void SetEarlyArbiters(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["EarlyArbiters"] = isOn;
    }

    public void SetEarlySnowpeak(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["EarlySnowpeak"] = isOn;
    }

    public void SetToTRequirements(int index)
    {
        LogicManager.Instance.SettingsStatus["ToTClosed"] = false;
        LogicManager.Instance.SettingsStatus["ToTOpenGrove"] = false;
        LogicManager.Instance.SettingsStatus["ToTsOpen"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["ToTClosed"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["ToTOpenGrove"] = true;
        else
            LogicManager.Instance.SettingsStatus["ToTOpen"] = true;
    }

    public void SetEarlyCitS(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["EarlyCitS"] = isOn;
    }

    public void SetWalletIncrease(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["WalletIncrease"] = isOn;
    }

    public void SetDoorOfTime(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["OpenDoorOfTime"] = isOn;
    }

    public void SetUnlockMapRegions(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["UnlockMapRegions"] = isOn;
    }

    public void SetBonksDoDamage(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["BonksDoDamage"] = isOn;
    }

    public void SetTransformAnywhere(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["TransformAnywhere"] = isOn;
    }

    public void SetSmallKeys(int index)
    {
        LogicManager.Instance.SettingsStatus["SmallKeysVanilla"] = false;
        LogicManager.Instance.SettingsStatus["SmallKeysOwnDungeon"] = false;
        LogicManager.Instance.SettingsStatus["SmallKeysAnyDungeon"] = false;
        LogicManager.Instance.SettingsStatus["SmallKeysKeysanity"] = false;
        LogicManager.Instance.SettingsStatus["SmallKeysKeysy"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["SmallKeysVanilla"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["SmallKeysOwnDungeon"] = true;
        else if (index == 2)
            LogicManager.Instance.SettingsStatus["SmallKeysAnyDungeon"] = true;
        else if (index == 3)
            LogicManager.Instance.SettingsStatus["SmallKeysKeysanity"] = true;
        else
            LogicManager.Instance.SettingsStatus["SmallKeysKeysy"] = true;
    }

    public void SetBigKeys(int index)
    {
        LogicManager.Instance.SettingsStatus["BigKeysVanilla"] = false;
        LogicManager.Instance.SettingsStatus["BigKeysOwnDungeon"] = false;
        LogicManager.Instance.SettingsStatus["BigKeysAnyDungeon"] = false;
        LogicManager.Instance.SettingsStatus["BigKeysKeysanity"] = false;
        LogicManager.Instance.SettingsStatus["BigKeysKeysy"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["BigKeysVanilla"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["BigKeysOwnDungeon"] = true;
        else if (index == 2)
            LogicManager.Instance.SettingsStatus["BigKeysAnyDungeon"] = true;
        else if (index == 3)
            LogicManager.Instance.SettingsStatus["BigKeysKeysanity"] = true;
        else
            LogicManager.Instance.SettingsStatus["BigKeysKeysy"] = true;
    }

    public void SetDamageMultiplier(int index)
    {
        LogicManager.Instance.SettingsStatus["DamageVanilla"] = false;
        LogicManager.Instance.SettingsStatus["DamageDouble"] = false;
        LogicManager.Instance.SettingsStatus["DamageTriple"] = false;
        LogicManager.Instance.SettingsStatus["DamageQuadruple"] = false;
        LogicManager.Instance.SettingsStatus["DamageOHKO"] = false;

        if (index == 0)
            LogicManager.Instance.SettingsStatus["DamageVanilla"] = true;
        else if (index == 1)
            LogicManager.Instance.SettingsStatus["DamageDouble"] = true;
        else if (index == 2)
            LogicManager.Instance.SettingsStatus["DamageTriple"] = true;
        else if (index == 3)
            LogicManager.Instance.SettingsStatus["DamageQuadruple"] = true;
        else
            LogicManager.Instance.SettingsStatus["DamageOHKO"] = true;
    }

    public void SetIgnoreWallet(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["IgnoreWalletLogic"] = isOn;
    }

    public void SetIgnoreLantern(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["IgnoreLanternLogic"] = isOn;
    }

    public void SetIgnoreWaterBomb(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["IgnoreWaterBombLogic"] = isOn;
    }

    public void SetIgnoreScent(bool isOn)
    {
        LogicManager.Instance.SettingsStatus["IgnoreScentLogic"] = isOn;
    }
}
