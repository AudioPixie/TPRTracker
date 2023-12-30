using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{

/* ------------------------------

        Item Counters 

------------------------------ */

    public Dictionary<string, int> ItemCounts = new()
    {

        {"FishCount", 0 }, //2
        {"SlingCount", 0 },
        {"LanternCount", 0 },
        {"RangCount", 0 },
        {"BootsCount", 0 },
        {"BowCount", 0 }, //3
        {"BombCount", 0 }, //3
        {"WBombCount", 0 },
        {"BombExCount", 0 },
        {"HawkCount", 0 },
        {"ClawCount", 0 }, //2
        {"SpinCount", 0 },
        {"BCCount", 0 },
        {"RodCount", 0 }, //2
        {"AuruCount", 0 },
        {"AsheiCount", 0 },
        {"BottleCount", 0 }, //4
        {"CrystalCount", 0 },
        {"SkillCount", 0 }, //7
        {"FetchCount", 0 }, //4
        {"HorseCount", 0 },
        {"SkybookCount", 0 }, //7
        {"WalletCount", 0 }, //3
        {"BugCount", 0 }, //24
        {"PoeCount", 0 }, //60
        {"SwordCount", 0 }, //4
        {"ShieldCount", 0 }, //2
        {"TunicCount", 0 },
        {"ZoraCount", 0 },
        {"MagicCount", 0 },
        {"HeartPCount", 0 }, //45
        {"HeartCCount", 0 }, //8
        {"FSCount", 0 }, //3
        {"MSCount", 0 }, //3

        {"YouthSCount", 0 },
        {"IliaSCount", 0 },
        {"PoeSCount", 0 },
        {"ReekSCount", 0 },
        {"MedicineSCount", 0 },

        {"FaronTCount", 0 },
        {"EldinTCount", 0 },
        {"LanayruTCount", 0 },

        {"Boss1Count", 0 },
        {"Boss2Count", 0 },
        {"Boss3Count", 0 },
        {"Boss4Count", 0 },
        {"Boss5Count", 0 },
        {"Boss6Count", 0 },
        {"Boss7Count", 0 },
        {"Boss8Count", 0 },

        {"GateKeyCount", 0 },
        {"FaronKeyCount", 0 },
        {"DesertKeyCount", 0 },

        {"FTKeyCount", 0 }, //4
        {"FTBossKeyCount", 0 },

        {"GMKeyCount", 0 }, //3
        {"GMBossKeyCount", 0 }, //3

        {"LTKeyCount", 0 }, //3
        {"LTBossKeyCount", 0 },

        {"AGKeyCount", 0 }, //5
        {"AGBossKeyCount", 0 },

        {"SRKeyCount", 0 }, //4
        {"SRBossKeyCount", 0 },
        {"PumpkinCount", 0 },
        {"CheeseCount", 0 },

        {"ToTKeyCount", 0 }, //3
        {"ToTBossKeyCount", 0 },

        {"CitSKeyCount", 0 }, //1
        {"CitSBossKeyCount", 0 },

        {"PoTKeyCount", 0 }, //7
        {"PoTBossKeyCount", 0 },

        {"HCKeyCount", 0 }, //3
        {"HCBossKeyCount", 0 }

    };

/* ------------------------------

        Settings Status 

------------------------------ */

    public Dictionary<string, bool> SettingsStatus = new()
    {
        {"FaronEscape", true },
        {"SkipPrologue", false },
        {"SkipMDH", false },
        {"SkipFaronTwilight", false },
        {"SkipEldinTwilight", false },
        {"SkipLanayruTwilight", false },

        {"HCOpen", false },
        {"HCFusedShadows", false },
        {"HCMirrorShards", false },
        {"HCAllDungeons", false },
        {"HCVanilla", true },
        {"PoTOpen", false },
        {"PoTFusedShadows", false },
        {"PoTMirrorShards", false },
        {"PoTVanilla", true },
        {"MinesClosed", true },
        {"MinesNoWrestling", false },
        {"MinesOpen", false },
        {"EarlyLakebed", false },
        {"EarlyArbiters", false },
        {"EarlySnowpeak", false },
        {"ToTClosed", true },
        {"ToTOpenGrove", false },
        {"ToTOpen", false },
        {"EarlyCitS", false },

        {"WalletIncrease", false },
        {"OpenDoorOfTime", false },
        {"UnlockMapRegions", false },

        {"IgnoreKeyLogic", false },
        {"IgnoreWalletLogic", false },
        {"IgnoreLanternLogic", false },
        {"IgnoreWaterBombLogic", false },
        {"IgnoreScentLogic", false }

    };

/* ------------------------------

            Setup

------------------------------ */

    private static LogicManager instance;

    public static LogicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LogicManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(LogicManager).Name);
                    instance = singletonObject.AddComponent<LogicManager>();
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

    public void LogItems(string input)
    {
        if (input == "All")
            foreach (var kvp in ItemCounts)
            {
                Debug.Log("Key: " + kvp.Key + ", Value: " + kvp.Value);
            }
        else
            Debug.Log("Key: " + input + ", Value: " + ItemCounts[input]);
    }

    public void LogSettings(string input)
    {
        if (input == "All")
            foreach (var kvp in SettingsStatus)
            {
                Debug.Log("Key: " + kvp.Key + ", Value: " + kvp.Value);
            }
        else
            Debug.Log("Key: " + input + ", Value: " + SettingsStatus[input]);
    }

/* ------------------------------

            Items

------------------------------ */

    public bool Has(string name, int amount = 1)
    {
        return ItemCounts[name] >= amount;
    }

    public bool CanDamage()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("BombCount")
            || Has("BootsCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanSmash()
    {
        return Has("BCCount") || Has("BombCount");
    }

    public bool CanBurnWebs()
    {
        return Has("LanternCount") || Has("BCCount") || Has("BombCount");
    }

    public bool CanRange()
    {
        return Has("BowCount")
            || Has("SlingCount")
            || Has("RangCount")
            || Has("BCCount")
            || Has("ClawCount");
    }

    public bool CanLaunchBombs()
    {
        return (Has("BowCount") || Has("RangCount")) && Has("BombCount");
    }

    public bool CanBombArrow()
    {
        return Has("BowCount") && Has("BombCount");
    }

    public bool CanCutHangingWeb()
    {
        return Has("ClawCount")
            || Has("RangCount")
            || Has("BCCount")
            || (Has("BowCount") && CanGetArrows());
    }

    public bool CanKnockDownHCPainting()
    {
        return Has("BowCount") || (Has("SwordCount") && Has("SkillCount", 6));
    }

    public bool CanUseWBombs()
    {
        return Has("WBombCount") || SettingsStatus["IgnoreWaterBombLogic"];
    }

    public bool CanGetArrows()
    {
        return CanLeaveForest() || (CanCompletePrologue() && Has("CrystalCount"));
    }

    public bool CanBreakMonkeyCage()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BootsCount")
            || Has("BombCount")
            || Has("ClawCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanFreeAllMonkeys()
    {
        return CanBreakMonkeyCage()
            && (Has("LanternCount") || Has("BombCount") || Has("BootsCount"))
            && CanBurnWebs()
            && Has("RangCount")
            && CanDefeatBokoblin()
            && (Has("FTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool CanPressMinesSwitch()
    {
        return Has("BootsCount");
    }

    public bool CanKnockDownHangingBaba()
    {
        return Has("BowCount") || Has("RangCount") || Has("ClawCount");
    }

    public bool CanBreakWoodenDoor()
    {
        return Has("CrystalCount") || Has("SwordCount") || CanSmash();
    }

/* ------------------------------

        Areas/Settings

------------------------------ */

    public bool CanCompletePrologue()
    {
        return (Has("SwordCount") && Has("SlingCount") && Has("FaronKeyCount"))
            || SettingsStatus["SkipPrologue"];
    }

    public bool HasCompletedPrologue()
    {
        return (Has("SwordCount") && Has("SlingCount"))
            || SettingsStatus["SkipPrologue"];
    }

    public bool CanLeaveForest()
    {
        return (Has("Boss1Count") || SettingsStatus["FaronEscape"]) && CanCompletePrologue();
    }

    public bool CanCompleteMDH()
    {
        return CanCompleteLT() || SettingsStatus["SkipMDH"];
    }

    public bool HasSetMDHFlag()
    {
        return Has("Boss3Count") || SettingsStatus["SkipMDH"];
    }

    public bool FaronTwilightCleared()
    {
        return Has("FaronTCount") || SettingsStatus["SkipFaronTwilight"];
    }

    public bool EldinTwilightCleared()
    {
        return Has("EldinTCount") || SettingsStatus["SkipEldinTwilight"];
    }

    public bool LanayruTwilightCleared()
    {
        return Has("LanayruTCount") || SettingsStatus["SkipLanayruTwilight"];
    }

    public bool CanAccessNorthFaron()
    {
        return FaronTwilightCleared() && (Has("LanternCount") || Has("CrystalCount"));
    }

    public bool CanAccessKakGorge()
    {
        return EldinTwilightCleared() && (CanAccessFaronField() || CanAccessKakVillage());
    }

    public bool CanAccessKakVillage()
    {
        return EldinTwilightCleared() && CanAccessFaronField();
    }

    public bool CanAccessDeathMountain()
    {
        return EldinTwilightCleared()
            && ((CanAccessKakVillage() && Has("BootsCount"))
            || (SettingsStatus["UnlockMapRegions"] && Has("CrystalCount")));
    }

    public bool CanAccessLakeHylia()
    {
        return LanayruTwilightCleared()
            && CanAccessLanayruField()
            && (CanSmash() || Has("GateKeyCount") || (SettingsStatus["UnlockMapRegions"] && Has("CrystalCount")));
    }

    public bool CanAccessDesert()
    {
        return CanAccessLakeHylia() && Has("AuruCount") && Has("CrystalCount");
    }

    public bool CanAccessZorasDomain()
    {
        return LanayruTwilightCleared()
            && (Has("CrystalCount")
                || (CanSmash() && CanAccessLanayruField()));
    }

    public bool CanAccessSnowpeakSummit()
    {
        return (CanAccessZorasDomain()
            && (Has("ReekSCount")
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishCount", 2))
                || SettingsStatus["EarlySnowpeak"])
            && Has("CrystalCount"))
            || (SettingsStatus["UnlockMapRegions"] && Has("CrystalCount"));
    }

    public bool CanAccessGrove()
    {
        return (CanAccessNorthFaron() && HasSetMDHFlag() && Has("CrystalCount"))
            || ((SettingsStatus["ToTOpenGrove"] || SettingsStatus["ToTOpen"]) && Has("CrystalCount"));
    }

    public bool CanAccessMirrorChamber()
    {
        return Has("Boss4Count");
    }

    public bool CanAccessCastleTown()
    {
        return CanAccessLanayruField();
    }

    public bool CanAccessFaronField()
    {
        return FaronTwilightCleared() && (CanLeaveForest() || (Has("CrystalCount") && EldinTwilightCleared()));
    }

    public bool CanAccessEldinField()
    {
        return EldinTwilightCleared() && (CanAccessFaronField() || Has("CrystalCount"));
    }

    public bool CanAccessLanayruField()
    {
        return LanayruTwilightCleared()
            && CanLeaveForest()
            && ((CanSmash() && CanAccessEldinField())
                || Has("GateKeyCount")
                || Has("CrystalCount"));
    }

    public bool CanAccessLanayru()
    {
        return CanLeaveForest()
            && (CanSmash() || Has("GateKeyCount") || (SettingsStatus["UnlockMapRegions"] && Has("CrystalCount")))
            && ((Has("SwordCount") && Has("SlingCount")) || SettingsStatus["SkipPrologue"]);
    }

    public bool GoMode()
    {
        return CanAccessHC()
            && ((Has("HCKeyCount", 2) && Has("HCBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting())
            && CanDefeatGanondorf();
    }

/* ------------------------------

            Dungeons

------------------------------ */

    public bool CanAccessFT()
    {
        return CanAccessNorthFaron() && (SettingsStatus["FaronEscape"] || CanBurnWebs());
    }

    public bool CanCompleteFT()
    {
        return CanBreakMonkeyCage()
            && Has("RangCount")
            && (Has("FTBossKeyCount") || SettingsStatus["IgnoreKeyLogic"])
            && (CanFreeAllMonkeys() || Has("ClawCount"))
            && CanDefeatDiababa();
    }

    public bool CanAccessGM()
    {
        return Has("BootsCount")
            && CanDefeatGoron()
            && CanAccessDeathMountain();
    }

    public bool CanCompleteGM()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && ((Has("GMKeyCount", 3) && Has("GMBossKey", 3)) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatBulblin()
            && CanDefeatFyrus();
    }

    public bool CanAccessLT()
    {
        return CanAccessLakeHylia()
            && Has("ZoraCount")
            && (SettingsStatus["EarlyLakebed"]
                || (Has("BootsCount")
                    && (Has("WBombCount")
                        || (Has("BombCount")
                            && SettingsStatus["IgnoreWaterBombLogic"]))));
    }

    public bool CanCompleteLT()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && ((Has("LTKeyCount", 3) && Has("LTBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatMorpheel();
    }

    public bool CanAccessAG()
    {
        return CanAccessDesert()
            && ((Has("DesertKeyCount") && CanDefeatKingBulblinDesert())
                || SettingsStatus["EarlyArbiters"]);
    }

    public bool CanCompleteAG()
    {
        return Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount")
            && ((Has("AGKeyCount", 5) && Has("AGBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && ((CanAccessLanayru()
                && Has("AuruCount")
                && CanDefeatKingBulblinDesert()
                && Has("DesertKeyCount"))
                    || SettingsStatus["EarlyArbiters"]);

    }

    public bool CanAccessSR()
    {
        return CanAccessSnowpeakSummit();
    }

    public bool CanCompleteSR()
    {
        return CanAccessSR()
            && ((Has("SRKeyCount", 4) && Has("SRBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CheeseCount")
            && Has("BCCount")
            && Has("BombCount")
            && CanDefeatBlizzeta();
    }

    public bool CanAccessToT()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && (CanDefeatShadowBeast() && Has("SwordCount", 3) || SettingsStatus["ToTOpen"]);
    }

    public bool CanCompleteToT()
    {
        return CanAccessToT()
            && Has("RodCount")
            && Has("BowCount")
            && Has("SpinCount")
            && ((Has("ToTKeyCount", 3) && Has("ToTBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatArmogohma();
    }

    public bool CanAccessCitS()
    {
        return CanAccessLanayru()
            && Has("ClawCount")
            && (Has("SkybookCount", 7) || SettingsStatus["EarlyCitS"]);
    }

    public bool CanCompleteCitS()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && Has("CrystalCount")
            && Has("BootsCount")
            && (Has("CitSBossKeyCount") || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatArgorok();
    }

    public bool CanAccessPoT()
    {
        return CanAccessMirrorChamber()
            && ((SettingsStatus["PoTVanilla"] && Has("Boss7Count"))
                || (SettingsStatus["PoTFusedShadows"] && Has("FSCount", 3))
                || (SettingsStatus["PoTMirrorShards"] && Has("MSCount", 3))
                || SettingsStatus["PoTOpen"]);
    }

    public bool CanCompletePoT()
    {
        return CanAccessPoT()
            && Has("SwordCount", 4)
            && Has("CrystalCount")
            && ((Has("PoTKeyCount", 7) && Has("PoTBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatZant();
    }

    public bool CanAccessHC()
    {
        return CanAccessCastleTown()
            && ((SettingsStatus["HCVanilla"] && Has("Boss8Count"))
                || (SettingsStatus["HCFusedShadows"] && Has("FSCount", 3))
                || (SettingsStatus["HCMirrorShards"] && Has("MSCount", 3))
                || (SettingsStatus["HCAllDungeons"] && HasCompletedAllDungeons())
                || SettingsStatus["HCOpen"]);
    }

    public bool CanCompleteAllDungeons()
    {
        return CanCompleteFT()
            && CanCompleteGM()
            && CanCompleteLT()
            && CanCompleteAG()
            && CanCompleteSR()
            && CanCompleteToT()
            && CanCompleteCitS()
            && CanCompletePoT();
    }

    public bool HasCompletedAllDungeons()
    {
        return Has("Boss1Count")
            && Has("Boss2Count")
            && Has("Boss3Count")
            && Has("Boss4Count")
            && Has("Boss5Count")
            && Has("Boss6Count")
            && Has("Boss7Count")
            && Has("Boss8Count");
    }

/* ------------------------------

            Enemies

------------------------------ */

    public bool CanDefeatAeralfos()
    {
        return Has("ClawCount") && (Has("SwordCount") || Has("BCCount") || Has("CrystalCount"));
    }

    public bool CanDefeatArmos()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("ClawCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBabaSerpent()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBabyGohma()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("SlingCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBari()
    {
        return CanUseWBombs() || Has("ClawCount");
    }

    public bool CanDefeatBeamos()
    {
        return Has("BCCount") || Has("BowCount") || Has("BombCount");
    }

    public bool CanDefeatBigBaba()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || (Has("BowCount") && CanGetArrows())
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatChu()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("ClawCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBokoblin()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("CrystalCount")
            || Has("SlingCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBokoblinRed()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || (Has("BowCount") && CanGetArrows())
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatBombfish()
    {
        return Has("BootsCount")
            && (Has("SwordCount") || Has("ClawCount")
                || (Has("ShieldCount") && Has("SkillCount", 2)));
    }

    public bool CanDefeatBombling()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || (Has("BowCount") && CanGetArrows())
            || Has("CrystalCount")
            || Has("ClawCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBomskit()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("CrystalCount")
            || Has("BowCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBubble()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("CrystalCount")
            || Has("BowCount")
            || Has("SpinCount");
    }

    public bool CanDefeatBulblin()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("CrystalCount")
            || Has("BowCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatChilfos()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatChuWorm()
    {
        return (Has("SwordCount")
            || Has("BowCount")
            || Has("SpinCount")
            || Has("CrystalCount")
            || Has("SpinCount"))
                && (Has("BombCount") || Has("ClawCount"));
    }

    public bool CanDefeatDarknut()
    {
        return Has("SwordCount");
    }

    public bool CanDefeatDekuBaba()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("SpinCount")
            || (Has("SkillCount", 2) && Has("ShieldCount"))
            || Has("SlingCount")
            || Has("ClawCount")
            || Has("BombCount");
    }

    public bool CanDefeatDekuLike()
    {
        return Has("BombCount");
    }

    public bool CanDefeatDodongo()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatDinalfos()
    {
        return Has("SwordCount") || Has("BCCount") || Has("CrystalCount");
    }

    public bool CanDefeatFireBubble()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanDefeatFireKeese()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SlingCount")
            || Has("SpinCount");
    }

    public bool CanDefeatFireToadpoli()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || (Has("SkillCount", 2) && Has("ShieldCount"));
    }

    public bool CanDefeatFreezard()
    {
        return Has("BCCount");
    }

    public bool CanDefeatGoron()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || (Has("SkillCount", 2) && Has("ShieldCount"))
            || Has("SlingCount")
            || Has("ClawCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatGhoulRat()
    {
        return Has("CrystalCount");
    }

    public bool CanDefeatGuay()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SlingCount");
    }

    public bool CanDefeatHelmasaur()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatHelmasaurus()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatIceBubble()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanDefeatIceKeese()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SlingCount")
            || Has("SpinCount");
    }

    public bool CanDefeatPoe()
    {
        return Has("CrystalCount");
    }

    public bool CanDefeatKargorok()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanDefeatKeese()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SlingCount")
            || Has("SpinCount");
    }

    public bool CanDefeatLeever()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatLizalfos()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatMiniFreezard()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatMoldorm()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatPoisonMite()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("LanternCount")
            || Has("SpinCount");
    }

    public bool CanDefeatPuppet()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount");
    }

    public bool CanDefeatRat()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount")
            || Has("SpinCount")
            || Has("SlingCount");
    }

    public bool CanDefeatRedeadKnight()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatShadowBeast()
    {
        return Has("SwordCount") || (Has("CrystalCount") && CanCompleteMDH());
    }

    public bool CanDefeatShadowBulblin()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatShadowDekuBaba()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("BombCount")
            || Has("SpinCount")
            || Has("SlingCount")
            || Has("ClawCount")
            || (Has("SkillCount", 2) && Has("ShieldCount"));
    }

    public bool CanDefeatShadowInsect()
    {
        return Has("CrystalCount");
    }

    public bool CanDefeatShadowKargorok()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatShadowKeese()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("SlingCount");
    }

    public bool CanDefeatShadowVermin()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatShellBlade()
    {
        return ((Has("WBombCount") || (Has("BombCount") && SettingsStatus["IgnoreWaterBombLogic"])))
            || (Has("SwordCount") && Has("BootsCount"));
    }

    public bool CanDefeatSkullfish()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanDefeatSkulltula()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatStalfos()
    {
        return CanSmash();
    }

    public bool CanDefeatStalhound()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatStalchild()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatTektite()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatTileWorm()
    {
        return (Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount"))
                && Has("RangCount");
    }

    public bool CanDefeatToado()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount");
    }

    public bool CanDefeatToadpoli()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || (Has("SkillCount", 2) && Has("ShieldCount"));
    }

    public bool CanDefeatTorchSlug()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatWalltula()
    {
        return Has("BCCount")
            || (Has("BowCount") && CanGetArrows())
            || Has("SlingCount")
            || Has("RangCount")
            || Has("ClawCount");
    }

    public bool CanDefeatWhiteWolfos()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatYoungGohma()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("SpinCount")
            || Has("BombCount");
    }

    public bool CanDefeatZantHead()
    {
        return Has("SwordCount") || Has("CrystalCount");
    }

    public bool CanDefeatOok()
    {
        return Has("SwordCount")
            || (Has("BowCount") && CanGetArrows())
            || Has("BCCount")
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatDangoro()
    {
        return Has("BootsCount")
            && (Has("SwordCount") || Has("CrystalCount") || Has("BCCount"));
    }

    public bool CanDefeatCarrierKargorok()
    {
        return Has("CrystalCount");
    }

    public bool CanDefeatTwilitBloat()
    {
        return Has("CrystalCount");
    }

    public bool CanDefeatDekuToad()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatSkullKid()
    {
        return Has("BowCount");
    }

    public bool CanDefeatKingBulblinBridge()
    {
        return Has("BowCount");
    }

    public bool CanDefeatKingBulblinDesert()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount", 3)
            || Has("CrystalCount");
    }

    public bool CanDefeatKingBulblinCastle()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount", 3)
            || Has("CrystalCount");
    }

    public bool CanDefeatDeathSword()
    {
        return Has("CrystalCount")
            && (Has("SwordCount") || Has("BCCount"))
            && (Has("RangCount") || Has("BowCount") || Has("ClawCount"));
    }

    public bool CanDefeatDarkhammer()
    {
        return Has("SwordCount")
            || Has("BCCount")
            || Has("BowCount")
            || Has("CrystalCount")
            || Has("BombCount");
    }

    public bool CanDefeatPhantomZant()
    {
        return Has("SwordCount") || Has("CrystalCount");
    }

    public bool CanDefeatDiababa()
    {
        return CanLaunchBombs()
            || (Has("RangCount")
                && (Has("SwordCount")
                    || Has("BCCount")
                    || Has("CrystalCount")
                    || Has("BombCount")));
    }

    public bool CanDefeatFyrus()
    {
        return Has("BowCount") || Has("BootsCount") || Has("SwordCount");
    }

    public bool CanDefeatMorpheel()
    {
        return Has("ZoraCount") && Has("BootsCount") && Has("SwordCount") && Has("ClawCount");
    }

    public bool CanDefeatStallord()
    {
        return Has("SpinCount") && Has("SwordCount");
    }

    public bool CanDefeatBlizzeta()
    {
        return Has("BCCount");
    }

    public bool CanDefeatArmogohma()
    {
        return Has("BowCount") && Has("RodCount");
    }

    public bool CanDefeatArgorok()
    {
        return Has("ClawCount", 2) && Has("SwordCount", 2) && Has("BootsCount");
    }

    public bool CanDefeatZant()
    {
        return Has("SwordCount", 3)
            && Has("RangCount")
            && Has("ClawCount")
            && Has("BCCount")
            && Has("BootsCount")
            && Has("ZoraCount");
    }

    public bool CanDefeatGanondorf()
    {
        return Has("SwordCount", 3) && Has("CrystalCount") && Has("SkillCount");
    }

/* ------------------------------

        Overworld Checks 

------------------------------ */

    // Ordon Province
   
    public bool OrdonRanchGrottoLanternChest()
    {
        return Has("CrystalCount") && Has("LanternCount");
    }

    public bool HerdingGoatsReward()
    {
        return CanCompletePrologue();
    }

    public bool OrdonSpringGoldenWolf()
    {
        return CanCompletePrologue() && CanLeaveForest() && Has("CrystalCount");
    }

    // Faron Woods

    public bool CoroBottle()
    {
        return HasCompletedPrologue()
            && CanCompletePrologue();
    }

    public bool FaronMistCaveLanternChest()
    {
        return HasCompletedPrologue()
            && Has("LanternCount");
    }

    public bool FaronMistCaveOpenChest()
    {
        return HasCompletedPrologue()
            && Has("LanternCount");
    }

    public bool FaronMistNorthChest()
    {
        return HasCompletedPrologue()
            && Has("LanternCount")
            && CanCompletePrologue();
    }

    public bool FaronMistSouthChest()
    {
        return HasCompletedPrologue()
            && Has("LanternCount")
            && CanCompletePrologue();
    }

    public bool FaronMistStumpChest()
    {
        return HasCompletedPrologue()
            && Has("LanternCount")
            && CanCompletePrologue();
    }

    public bool FaronWoodsGoldenWolf()
    {
        return CanCompletePrologue()
            && (Has("CrystalCount") || Has("LanternCount"));
    }

    public bool FaronWoodsOwlStatueChest()
    {
        return HasCompletedPrologue()
            && CanSmash()
            && Has("RodCount", 2)
            && CanLeaveForest()
            && Has("CrystalCount");
    }

    public bool FaronWoodsOwlStatueSkyCharacter()
    {
        return HasCompletedPrologue()
            && CanSmash()
            && Has("RodCount", 2)
            && CanLeaveForest();
    }

    public bool NorthFaronWoodsDekuBabaChest()
    {
        return CanCompletePrologue()
            && (Has("CrystalCount") || Has("LanternCount"));
    }

    public bool SouthFaronCaveChest()
    {
        return HasCompletedPrologue();
    }

    // Lost Woods/Sacred Grove

    public bool LostWoodsLanternChest()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && Has("LanternCount");
    }

    public bool SacredGroveBabaSerpentGrottoChest()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && CanSmash()
            && CanDefeatBabaSerpent()
            && CanKnockDownHangingBaba()
            && (CanDefeatSkullKid()
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]);
    }

    public bool SacredGrovePastOwlStatueChest()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && Has("RodCount")
            && (Has("SwordCount", 3)
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]);
    }

    public bool SacredGroveSpinnerChest()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && Has("SpinCount")
            && (CanDefeatSkullKid()
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]);
    }

    // Faron Field

    public bool FaronFieldBridgeChest()
    {
        return CanLeaveForest()
            && Has("ClawCount")
            && ((Has("SwordCount") && Has("SlingCount"))
                || SettingsStatus["SkipPrologue"]);
    }

    public bool FaronFieldCornerGrottoLeftChest()
    {
        return CanLeaveForest()
            && Has("CrystalCount")
            && ((Has("SwordCount") && Has("SlingCount"))
                || SettingsStatus["SkipPrologue"]);
    }

    public bool FaronFieldCornerGrottoRearChest()
    {
        return CanLeaveForest()
            && Has("CrystalCount")
            && ((Has("SwordCount") && Has("SlingCount"))
                || SettingsStatus["SkipPrologue"]);
    }

    public bool FaronFieldCornerGrottoRightChest()
    {
        return CanLeaveForest()
            && Has("CrystalCount")
            && ((Has("SwordCount") && Has("SlingCount"))
                || SettingsStatus["SkipPrologue"]);
    }

    public bool FaronFieldTreeHeartPiece()
    {
        return CanLeaveForest()
            && (Has("RangCount") || Has("ClawCount"))
            && ((Has("SwordCount") && Has("SlingCount"))
                || SettingsStatus["SkipPrologue"]);
    }

    // Kakariko Gorge

    public bool KakarikoGorgeDoubleClawshotChest()
    {
        return CanAccessKakGorge() && Has("ClawCount", 2);
    }

    public bool KakarikoGorgeOwlStatueChest()
    {
        return CanAccessKakGorge() && Has("RodCount", 2);
    }

    public bool KakarikoGorgeOwlStatueSkyCharacter()
    {
        return CanAccessKakGorge() && Has("RodCount", 2);
    }

    public bool KakarikoGorgeSpireHeartPiece()
    {
        return CanAccessKakGorge()
            && (Has("RangCount") || Has("ClawCount"));
    }

    // Death Mountain

    public bool DeathMountainAlcoveChest()
    {
        return CanAccessDeathMountain()
            && Has("ClawCount");
    }

    // Eldin Field

    public bool BridgeofEldinOwlStatueChest()
    {
        return CanAccessEldinField() && Has("RodCount", 2);
    }

    public bool BridgeofEldinOwlStatueSkyCharacter()
    {
        return CanAccessEldinField() && Has("RodCount", 2);
    }

    public bool EldinFieldBombRockChest()
    {
        return CanAccessEldinField() && CanSmash();
    }

    public bool EldinFieldBomskitGrottoLanternChest()
    {
        return CanAccessEldinField()
            && Has("CrystalCount")
            && Has("LanternCount");
    }

    public bool EldinFieldBomskitGrottoLeftChest()
    {
        return CanAccessEldinField()
            && Has("CrystalCount");
    }

    public bool EldinFieldStalfosGrottoLeftSmallChest()
    {
        return CanAccessEldinField()
            && Has("SpinCount")
            && Has("CrystalCount")
            && (CanSmash() || Has("GateKeyCount"));
    }

    public bool EldinFieldStalfosGrottoRightSmallChest()
    {
        return CanAccessEldinField()
            && Has("SpinCount")
            && Has("CrystalCount")
            && (CanSmash() || Has("GateKeyCount"));
    }

    public bool EldinFieldStalfosGrottoStalfosChest()
    {
        return CanAccessEldinField()
            && Has("SpinCount")
            && Has("CrystalCount")
            && CanDefeatStalfos()
            && (CanSmash() || Has("GateKeyCount"));
    }

    public bool EldinFieldWaterBombFishGrottoChest()
    {
        return CanAccessEldinField() && Has("CrystalCount");
    }

    public bool GoronSpringwaterRush()
    {
        return CanAccessEldinField()
            && CanAccessKakVillage()
            && (CanSmash() || Has("GateKeyCount"));
    }

    // Lanayru Field

    public bool LanayruFieldBehindGateUnderwaterChest()
    {
        return CanAccessLanayruField()
            && Has("BootsCount");
    }

    public bool LanayruFieldSkulltulaGrottoChest()
    {
        return CanAccessLanayruField()
            && Has("CrystalCount")
            && Has("LanternCount");
    }

    public bool LanayruFieldSpinnerTrackChest()
    {
        return CanAccessLanayruField()
            && CanSmash()
            && Has("SpinCount");
    }

    public bool LanayruIceBlockPuzzleCaveChest()
    {
        return CanAccessLanayruField() && Has("BCCount");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterOwlStatueChest()
    {
        return CanAccessLanayru() && Has("RodCount", 2);
    }

    public bool HyruleFieldAmphitheaterOwlStatueSkyCharacter()
    {
        return CanAccessLanayru() && Has("RodCount", 2);
    }

    public bool WestHyruleFieldGoldenWolf()
    {
        return CanAccessLanayru()
            && Has("CrystalCount");
    }

    public bool WestHyruleFieldHelmasaurGrottoChest()
    {
        return CanAccessLanayru()
            && Has("ClawCount")
            && Has("CrystalCount");
    }

    // North Castle Town

    public bool NorthCastleTownGoldenWolf()
    {
        return CanAccessCastleTown()
            && Has("FetchCount", 3)
            && Has("CrystalCount");
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownDoubleClawshotChasmChest()
    {
        return CanAccessCastleTown() && Has("ClawCount", 2);
    }

    public bool OutsideSouthCastleTownFountainChest()
    {
        return CanAccessCastleTown()
            && Has("ClawCount")
            && Has("SpinCount");
    }

    public bool OutsideSouthCastleTownGoldenWolf()
    {
        return CanAccessCastleTown()
            && CanCompletePrologue()
            && Has("CrystalCount");
    }

    public bool OutsideSouthCastleTownTektiteGrottoChest()
    {
        return CanAccessCastleTown() && Has("CrystalCount");
    }

    public bool OutsideSouthCastleTownTightropeChest()
    {
        return CanAccessCastleTown()
            && Has("CrystalCount")
            && Has("ClawCount");
    }

    public bool WoodenStatue()
    {
        return CanAccessCastleTown()
            && Has("FetchCount", 2)
            && (Has("MedicineSCount") || SettingsStatus["IgnoreScentLogic"]);
    }

    // Lake Hylia

    public bool AuruGiftToFyer()
    {
        return CanAccessLakeHylia();
    }

    public bool LakeHyliaShellBladeGrottoChest()
    {
        return CanAccessLakeHylia()
            && Has("CrystalCount")
            && CanDefeatShellBlade();
    }

    public bool LakeHyliaUnderwaterChest()
    {
        return CanAccessLakeHylia() && Has("BootsCount");
    }

    public bool LakeHyliaWaterToadpoliGrottoChest()
    {
        return CanAccessLakeHylia()
            && Has("CrystalCount")
            && CanDefeatToadpoli();
    }

    public bool OutsideLanayruSpringLeftStatueChest()
    {
        return CanAccessLakeHylia();
    }

    public bool OutsideLanayruSpringRightStatueChest()
    {
        return CanAccessLakeHylia();
    }

    public bool PlummFruitBalloonMinigame()
    {
        return (CanAccessLakeHylia() || CanAccessZorasDomain())
            && Has("CrystalCount");
    }

    public bool FlightByFowl()
    {
        return CanAccessLakeHylia();
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeBubbleGrottoChest()
    {
        return CanAccessLanayru()
            && CanLaunchBombs()
            && Has("ClawCount")
            && Has("CrystalCount");
    }

    public bool LakeHyliaBridgeCliffChest()
    {
        return CanAccessLanayru()
            && CanLaunchBombs()
            && Has("ClawCount");
    }

    public bool LakeHyliaBridgeOwlStatueChest()
    {
        return CanAccessLanayru()
            && Has("ClawCount")
            && Has("RodCount", 2);
    }

    public bool LakeHyliaBridgeOwlStatueSkyCharacter()
    {
        return CanAccessLanayru()
            && Has("ClawCount")
            && Has("RodCount", 2);
    }

    public bool LakeHyliaBridgeVinesChest()
    {
        return CanAccessLanayru() && Has("ClawCount");
    }

    // Upper Zora's River

    public bool FishingHoleBottle()
    {
        return CanAccessZorasDomain() && Has("FishCount");
    }

    public bool FishingHoleHeartPiece()
    {
        return CanAccessZorasDomain();
    }

    public bool IzaHelpingHand()
    {
        return CanAccessZorasDomain()
            && CanSmash()
            && Has("SwordCount")
            && Has("BowCount");
    }

    public bool IzaRagingRapidsMinigame()
    {
        return CanAccessZorasDomain()
            && CanSmash()
            && Has("SwordCount")
            && Has("BowCount");
    }

    // Zora's Domain

    public bool ZorasDomainChestBehindWaterfall()
    {
        return CanAccessZorasDomain() && Has("CrystalCount");
    }

    public bool ZorasDomainChestByMotherandChildIsles()
    {
        return CanAccessZorasDomain();
    }

    public bool ZorasDomainExtinguishAllTorchesChest()
    {
        return CanAccessZorasDomain() && Has("RangCount") && Has("BootsCount");
    }

    public bool ZorasDomainLightAllTorchesChest()
    {
        return CanAccessZorasDomain() && Has("LanternCount") && Has("BootsCount");
    }

    public bool ZorasDomainUnderwaterGoron()
    {
        return CanAccessZorasDomain()
            && Has("BootsCount")
            && Has("ZoraCount")
            && (Has("WBombCount")
            || (Has("BombCount") && SettingsStatus["IgnoreWaterBombLogic"]));
    }

    // Gerudo Desert

    public bool GerudoDesertCampfireEastChest()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertCampfireNorthChest()
    {
        return CanAccessDesert();
    }

    public bool GerudoDesertCampfireWestChest()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertEastCanyonChest()
    {
        return CanAccessDesert();
    }

    public bool GerudoDesertGoldenWolf()
    {
        return CanAccessDesert()
            && CanDefeatBulblin()
            && Has("CrystalCount")
            && CanAccessLanayru();
    }

    public bool GerudoDesertLoneSmallChest()
    {
        return CanAccessDesert();
    }

    public bool GerudoDesertNortheastChestBehindGates()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertNorthwestChestBehindGates()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertNorthSmallChestBeforeBulblinCamp()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertOwlStatueChest()
    {
        return CanAccessDesert() && Has("RodCount", 2);
    }

    public bool GerudoDesertOwlStatueSkyCharacter()
    {
        return CanAccessDesert() && Has("RodCount", 2);
    }

    public bool GerudoDesertPeahatLedgeChest()
    {
        return CanAccessDesert() && Has("ClawCount");
    }

    public bool GerudoDesertRockGrottoLanternChest()
    {
        return CanAccessDesert()
            && Has("CrystalCount")
            && Has("ClawCount")
            && CanSmash()
            && Has("LanternCount");
    }

    public bool GerudoDesertSouthChestBehindWoodenGates()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertSkulltulaGrottoChest()
    {
        return CanAccessDesert() && Has("CrystalCount");
    }

    public bool GerudoDesertWestCanyonChest()
    {
        return CanAccessDesert() && Has("ClawCount");
    }

    // Snowpeak

    public bool AsheiSketch()
    {
        return CanAccessZorasDomain();
    }

    public bool SnowboardRacingPrize()
    {
        return CanAccessSnowpeakSummit()
            && CanDefeatShadowBeast()
            && Has("Boss5Count");
    }

    public bool SnowpeakCaveIceLanternChest()
    {
        return CanAccessSnowpeakSummit() && Has("BCCount") && Has("LanternCount");
    }

    public bool SnowpeakFreezardGrottoChest()
    {
        return CanAccessSnowpeakSummit() && Has("BCCount");
    }

    // Hidden Village

    public bool CatsHideandSeekMinigame()
    {
        return CanAccessLanayruField()
            && Has("FetchCount", 4)
            && Has("BowCount");
    }

    public bool IliaCharm()
    {
        return CanAccessLanayruField()
            && Has("FetchCount", 3)
            && Has("BowCount");
    }

    public bool SkybookFromImpaz()
    {
        return CanAccessLanayruField()
            && Has("FetchCount", 3)
            && Has("BowCount")
            && Has("RodCount");
    }

/* ------------------------------

        Overworld Poes 

------------------------------ */

    // Faron Province

    public bool FaronMistPoe()
    {
        return CanCompletePrologue() && Has("CrystalCount");
    }

    // Lost Woods

    public bool LostWoodsWaterfallPoe()
    {
        return CanCompletePrologue() && Has("CrystalCount");
    }

    public bool LostWoodsBoulderPoe()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && CanSmash()
            && (CanDefeatSkullKid()
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]);
    }

    // Sacred Grove

    public bool SacredGroveMasterSwordPoe()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && (CanDefeatSkullKid()
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]);
    }

    public bool SacredGroveTempleofTimeOwlStatuePoe()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && Has("RodCount")
            && (Has("SwordCount", 3)
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]);
    }

    // Faron Field

    public bool FaronFieldPoe()
    {
        return CanLeaveForest()
            && CanCompleteMDH()
            && Has("CrystalCount");
    }

    // Kakariko Gorge

    public bool KakarikoGorgePoe()
    {
        return CanAccessKakGorge()
            && CanCompleteMDH()
            && Has("CrystalCount");
    }

    // Death Mountain

    public bool DeathMountainTrailPoe()
    {
        return Has("Boss2Count")
            && Has("CrystalCount");
    }

    // Lanayru Field

    public bool LanayruFieldBridgePoe()
    {
        return CanAccessLanayru()
            && CanCompleteMDH()
            && Has("CrystalCount");
    }

    public bool LanayruFieldPoeGrottoLeftPoe()
    {
        return CanAccessLanayru() && Has("CrystalCount");
    }

    public bool LanayruFieldPoeGrottoRightPoe()
    {
        return CanAccessLanayru() && Has("CrystalCount");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterPoe()
    {
        return CanAccessLanayru()
            && Has("CrystalCount");
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownPoe()
    {
        return CanAccessLanayru()
            && Has("CrystalCount");
    }

    // Outside East Castle Town

    public bool EastCastleTownBridgePoe()
    {
        return CanAccessLanayru()
            && Has("CrystalCount");
    }

    // Lake Hylia

    public bool LakeHyliaAlcovePoe()
    {
        return CanAccessLakeHylia() && Has("CrystalCount");
    }

    public bool LakeHyliaTowerPoe()
    {
        return CanAccessLakeHylia() && Has("CrystalCount");
    }

    public bool LakeHyliaDockPoe()
    {
        return CanAccessLakeHylia() && Has("CrystalCount");
    }

    public bool FlightByFowlLedgePoe()
    {
        return CanAccessLakeHylia() && Has("CrystalCount");
    }

    public bool IsleofRichesPoe()
    {
        return CanAccessLakeHylia() && Has("CrystalCount");
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeCliffPoe()
    {
        return CanAccessLanayru()
            && Has("CrystalCount")
            && CanLaunchBombs()
            && Has("ClawCount");
    }

    // Upper Zora's River

    public bool UpperZorasRiverPoe()
    {
        return CanAccessZorasDomain()
            && Has("CrystalCount");
    }

    // Zora's Domain

    public bool ZorasDomainWaterfallPoe()
    {
        return CanAccessZorasDomain()
            && Has("CrystalCount");
    }

    public bool ZorasDomainMotherandChildIslePoe()
    {
        return CanAccessZorasDomain()
            && Has("CrystalCount");
    }

    // Gerudo Desert

    public bool GerudoDesertNorthPeahatPoe()
    {
        return CanAccessDesert()
            && Has("ClawCount")
            && Has("CrystalCount");
    }

    public bool GerudoDesertEastPoe()
    {
        return CanAccessDesert() && Has("CrystalCount");
    }

    public bool GerudoDesertPoeAboveCaveofOrdeals()
    {
        return CanAccessDesert()
            && Has("ClawCount")
            && Has("CrystalCount");
    }

    public bool GerudoDesertRockGrottoFirstPoe()
    {
        return CanAccessDesert()
            && Has("ClawCount")
            && CanSmash()
            && Has("CrystalCount");
    }

    public bool GerudoDesertRockGrottoSecondPoe()
    {
        return CanAccessDesert()
            && Has("ClawCount")
            && CanSmash()
            && Has("CrystalCount");
    }

    public bool OutsideBulblinCampPoe()
    {
        return CanAccessDesert() && Has("CrystalCount");
    }

    // Snowpeak

    public bool SnowpeakAboveFreezardGrottoPoe()
    {
        return CanAccessSnowpeakSummit()
            && Has("CrystalCount");
    }

    public bool SnowpeakBlizzardPoe()
    {
        return CanAccessSnowpeakSummit()
            && Has("CrystalCount");
    }

    public bool SnowpeakPoeAmongTrees()
    {
        return CanAccessSnowpeakSummit()
            && Has("CrystalCount");
    }

    public bool SnowpeakCaveIcePoe()
    {
        return CanAccessSnowpeakSummit()
            && Has("BCCount")
            && Has("CrystalCount");
    }

    public bool SnowpeakIcySummitPoe()
    {
        return CanAccessSnowpeakSummit()
            && Has("CrystalCount");
    }

    // Hidden Village

    public bool HiddenVillagePoe()
    {
        return Has("FetchCount", 4)
            && Has("ClawCount")
            && Has("BowCount")
            && Has("RodCount")
            && Has("CrystalCount");
    }

/* ------------------------------

            Bugs 

------------------------------ */

    public bool FaronFieldFemaleBeetle()
    {
        return CanAccessFaronField() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool FaronFieldMaleBeetle()
    {
        return CanAccessFaronField();
    }

    public bool KakarikoGorgeFemalePillBug()
    {
        return CanAccessKakGorge();
    }

    public bool KakarikoGorgeMalePillBug()
    {
        return CanAccessKakGorge();
    }

    public bool KakarikoVillageFemaleAnt()
    {
        return CanAccessKakVillage();
    }

    public bool KakarikoGraveyardMaleAnt()
    {
        return CanAccessKakVillage();
    }

    public bool EldinFieldFemaleGrasshopper()
    {
        return CanAccessEldinField();
    }

    public bool EldinFieldMaleGrasshopper()
    {
        return CanAccessEldinField();
    }

    public bool BridgeofEldinFemalePhasmid()
    {
        return CanAccessEldinField() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool BridgeofEldinMalePhasmid()
    {
        return CanAccessEldinField() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool LakeHyliaBridgeFemaleMantis()
    {
        return CanAccessLanayru() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool LakeHyliaBridgeMaleMantis()
    {
        return CanAccessLanayru() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool LanayruFieldFemaleStagBeetle()
    {
        return CanAccessLanayru() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool LanayruFieldMaleStagBeetle()
    {
        return CanAccessLanayru() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool WestHyruleFieldFemaleButterfly()
    {
        return CanAccessLanayru() && (Has("RangCount") || Has("ClawCount"));
    }

    public bool WestHyruleFieldMaleButterfly()
    {
        return CanAccessLanayru();
    }

    public bool OutsideSouthCastleTownFemaleLadybug()
    {
        return CanAccessCastleTown();
    }

    public bool OutsideSouthCastleTownMaleLadybug()
    {
        return CanAccessCastleTown();
    }

    public bool SacredGroveMaleSnail()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && (CanDefeatSkullKid() || SettingsStatus["ToTOpen"] || SettingsStatus["ToTOpenGrove"])
            && (Has("RangCount") || Has("ClawCount"));
    }

    public bool SacredGroveFemaleSnail()
    {
        return CanCompletePrologue()
            && Has("CrystalCount")
            && (Has("SwordCount", 3) || SettingsStatus["ToTOpen"] || SettingsStatus["ToTOpenGrove"])
            && (Has("RangCount") || Has("ClawCount"));
    }

    public bool GerudoDesertFemaleDayfly()
    {
        return CanAccessDesert();
    }

    public bool GerudoDesertMaleDayfly()
    {
        return CanAccessDesert();
    }

    public bool UpperZorasRiverFemaleDragonfly()
    {
        return CanAccessZorasDomain();
    }

    public bool ZorasDomainMaleDragonfly()
    {
        return CanAccessZorasDomain();
    }

/* ------------------------------

        Ordon Village 

------------------------------ */

    public bool WoodenSwordChest()
    {
        return Has("FishCount") || SettingsStatus["SkipPrologue"];
    }

    public bool LinksBasementChest()
    {
        return Has("LanternCount");
    }

    public bool UliCradleDelivery()
    {
        return true;
    }

    public bool OrdonCatRescue()
    {
        return Has("FishCount");
    }

    public bool SeraShopSlingshot()
    {
        return true;
    }

    public bool OrdonShield()
    {
        return CanCompletePrologue() && Has("CrystalCount");
    }

    public bool OrdonSword()
    {
        return FaronTwilightCleared();
    }

    public bool WrestlingWithBo()
    {
        return true;
    }

/* ------------------------------

        Kakariko Village

------------------------------ */

    public bool KakarikoInnChest()
    {
        return CanAccessKakVillage();
    }

    public bool BarnesBombBag()
    {
        return CanAccessKakVillage();
    }

    public bool EldinSpringUnderwaterChest()
    {
        return CanAccessKakVillage() && CanSmash() && Has("BootsCount");
    }

    public bool KakarikoVillageBombRockSpireHeartPiece()
    {
        return CanAccessKakVillage()
            && CanLaunchBombs()
            && (Has("RangCount") || Has("ClawCount"));
    }

    public bool KakarikoGraveyardLanternChest()
    {
        return CanAccessKakVillage() && Has("LanternCount");
    }

    public bool KakarikoWatchtowerChest()
    {
        return CanAccessKakVillage();
    }

    public bool KakarikoWatchtowerAlcoveChest()
    {
        return CanAccessKakVillage() && CanSmash();
    }

    public bool TaloSharpshooting()
    {
        return CanAccessKakVillage() && Has("BowCount") && Has("Boss2Count");
    }

    public bool KakarikoVillageMaloMartHylianShield()
    {
        return CanAccessKakVillage();
    }

    public bool KakarikoVillageMaloMartHawkeye()
    {
        return CanAccessKakVillage() && Has("BowCount") && Has("Boss2Count");
    }

    public bool RutelasBlessing()
    {
        return CanAccessKakVillage() && Has("GateKeyCount");
    }

    public bool GiftFromRalis()
    {
        return CanAccessKakVillage() && Has("GateKeyCount") && Has("AsheiCount");
    }

    public bool KakarikoGraveyardGoldenWolf()
    {
        return CanAccessKakVillage() && CanAccessLanayru() && Has("CrystalCount");
    }

    public bool RenadosLetter()
    {
        return CanAccessKakVillage() && Has("Boss6Count");
    }

    public bool IliaMemoryReward()
    {
        return CanAccessKakVillage() && Has("FetchCount", 4);
    }

    // Poes

    public bool KakarikoVillageBombShopPoe()
    {
        return CanAccessKakVillage() && Has("CrystalCount");
    }

    public bool KakarikoVillageWatchtowerPoe()
    {
        return CanAccessKakVillage() && Has("CrystalCount");
    }

    public bool KakarikoGraveyardOpenPoe()
    {
        return CanAccessKakVillage() && Has("CrystalCount");
    }

    public bool KakarikoGraveyardGravePoe()
    {
        return CanAccessKakVillage() && Has("CrystalCount");
    }

/* ------------------------------

        Eldin Lantern Cave

------------------------------ */

    public bool EldinLanternCaveFirstChest()
    {
        return CanAccessKakGorge() && CanSmash() && CanBurnWebs();
    }

    public bool EldinLanternCaveSecondChest()
    {
        return CanAccessKakGorge() && CanSmash() && CanBurnWebs();
    }

    public bool EldinLanternCaveLanternChest()
    {
        return CanAccessKakGorge()
            && CanSmash()
            && CanBurnWebs()
            && Has("LanternCount");
    }

    // Poes

    public bool EldinLanternCavePoe()
    {
        return CanAccessKakGorge() && CanSmash() && Has("CrystalCount");
    }

/* ------------------------------

        Eldin Stockcave

------------------------------ */

    public bool EldinStockcaveUpperChest()
    {
        return CanAccessEldinField() && Has("ClawCount") && Has("BootsCount");
    }

    public bool EldinStockcaveLanternChest()
    {
        return CanAccessEldinField()
            && Has("ClawCount")
            && Has("BootsCount")
            && Has("LanternCount");
    }

    public bool EldinStockcaveLowestChest()
    {
        return CanAccessEldinField() && Has("ClawCount") && Has("BootsCount");
    }

/* ------------------------------

        Lake Lantern Cave

------------------------------ */

    public bool LakeLanternCaveFirstChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveSecondChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveThirdChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveFourthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveFifthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveSixthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveSeventhChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveEighthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveNinthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveTenthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveEleventhChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveTwelfthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveThirteenthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveFourteenthChest()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveEndLanternChest()
    {
        return CanAccessLakeHylia()
            && Has("LanternCount")
            && CanSmash();
    }

    // Poes

    public bool LakeLanternCaveFirstPoe()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("CrystalCount");
    }

    public bool LakeLanternCaveSecondPoe()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("CrystalCount");
    }

    public bool LakeLanternCaveFinalPoe()
    {
        return CanAccessLakeHylia()
            && (Has("LanternCount") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("CrystalCount");
    }

/* ------------------------------

        Lanayru Spring

------------------------------ */

    public bool LanayruSpringUnderwaterLeftChest()
    {
        return CanAccessLakeHylia() && Has("BootsCount");
    }

    public bool LanayruSpringUnderwaterRightChest()
    {
        return CanAccessLakeHylia() && Has("BootsCount");
    }

    public bool LanayruSpringBackRoomLeftChest()
    {
        return CanAccessLakeHylia() && Has("ClawCount");
    }

    public bool LanayruSpringBackRoomRightChest()
    {
        return CanAccessLakeHylia() && Has("ClawCount");
    }

    public bool LanayruSpringBackRoomLanternChest()
    {
        return CanAccessLakeHylia() && Has("ClawCount") && Has("LanternCount");
    }

    public bool LanayruSpringWestDoubleClawshotChest()
    {
        return CanAccessLakeHylia() && Has("ClawCount", 2);
    }

    public bool LanayruSpringEastDoubleClawshotChest()
    {
        return CanAccessLakeHylia() && Has("ClawCount", 2);
    }

/* ------------------------------

        Castle Town

------------------------------ */

    public bool AgithaFemaleAntReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 1);
    }

    public bool AgithaFemaleBeetleReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 2);
    }

    public bool AgithaFemaleButterflyReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 3);
    }

    public bool AgithaFemaleDayflyReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 4);
    }

    public bool AgithaFemaleDragonflyReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 5);
    }

    public bool AgithaFemaleGrasshopperReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 6);
    }

    public bool AgithaFemaleLadybugReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 7);
    }

    public bool AgithaFemaleMantisReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 8);
    }

    public bool AgithaFemalePhasmidReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 9);
    }

    public bool AgithaFemalePillBugReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 10);
    }

    public bool AgithaFemaleSnailReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 11);
    }

    public bool AgithaFemaleStagBeetleReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 12);
    }

    public bool AgithaMaleAntReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 13);
    }

    public bool AgithaMaleBeetleReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 14);
    }

    public bool AgithaMaleButterflyReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 15);
    }

    public bool AgithaMaleDayflyReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 16);
    }

    public bool AgithaMaleDragonflyReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 17);
    }

    public bool AgithaMaleGrasshopperReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 18);
    }

    public bool AgithaMaleLadybugReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 19);
    }

    public bool AgithaMaleMantisReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 20);
    }

    public bool AgithaMalePhasmidReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 21);
    }

    public bool AgithaMalePillBugReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 22);
    }

    public bool AgithaMaleSnailReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 23);
    }

    public bool AgithaMaleStagBeetleReward()
    {
        return CanAccessCastleTown() && Has("BugCount", 24);
    }

    public bool CastleTownMaloMartMagicArmor()
    {
        return CanAccessCastleTown()
            && (Has("WalletCount", 1)
                || SettingsStatus["WalletIncrease"]
                || SettingsStatus["IgnoreWalletLogic"]);
    }

    public bool CharloDonationBlessing()
    {
        return CanAccessCastleTown();
    }

    public bool STARPrize1()
    {
        return CanAccessCastleTown() && Has("ClawCount");
    }

    public bool STARPrize2()
    {
        return CanAccessCastleTown() && Has("ClawCount", 2);
    }

    public bool Jovani20PoeSoulReward()
    {
        return CanAccessCastleTown() && Has("PoeCount", 20);
    }

    public bool Jovani60PoeSoulReward()
    {
        return CanAccessCastleTown() && Has("PoeCount", 60);
    }

    public bool TelmaInvoice()
    {
        return CanAccessCastleTown() && Has("FetchCount", 1);
    }

    public bool DoctorsOfficeBalconyChest()
    {
        return CanAccessCastleTown() && Has("FetchCount", 2);
    }

    // Poes

    public bool JovaniHousePoe()
    {
        return CanAccessCastleTown() && Has("CrystalCount");
    }

/* ------------------------------

        Bulblin Camp

------------------------------ */

    public bool BulblinCampFirstChestUnderTowerAtEntrance()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool BulblinCampSmallChestinBackofCamp()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool BulblinCampRoastedBoar()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool BulblinGuardKey()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool OutsideArbitersGroundsLanternChest()
    {
        return CanAccessDesert()
            && CanDefeatBulblin()
            && Has("LanternCount")
            && ((CanDefeatKingBulblinDesert() && Has("DesertKeyCount"))
                || SettingsStatus["EarlyArbiters"]);
    }

    // Poes

    public bool BulblinCampPoe()
    {
        return CanAccessDesert()
            && Has("CrystalCount")
            && ((CanDefeatKingBulblinDesert() && Has("DesertKeyCount"))
                || SettingsStatus["EarlyArbiters"]);
    }

    public bool OutsideArbitersGroundsPoe()
    {
        return CanAccessDesert()
            && Has("CrystalCount")
            && ((CanDefeatKingBulblinDesert() && Has("DesertKeyCount"))
                || SettingsStatus["EarlyArbiters"]);
    }

/* ------------------------------

        Cave of Ordeals

------------------------------ */

    public bool CaveofOrdealsGreatFairyReward()
    {
        return CanAccessDesert()
            && Has("SpinCount")
            && Has("CrystalCount")
            && Has("RodCount", 2)
            && Has("ClawCount", 2)
            && Has("BCCount")
            && CanDefeatDarknut();
    }

    // Poes

    public bool CaveofOrdealsFloor17Poe()
    {
        return CanAccessDesert() && Has("SpinCount") && Has("CrystalCount");
    }

    public bool CaveofOrdealsFloor33Poe()
    {
        return CanAccessDesert()
            && Has("SpinCount")
            && Has("CrystalCount")
            && Has("RodCount", 2)
            && Has("BCCount");
    }

    public bool CaveofOrdealsFloor44Poe()
    {
        return CanAccessDesert()
            && Has("SpinCount")
            && Has("CrystalCount")
            && Has("RodCount", 2)
            && Has("BCCount")
            && Has("ClawCount", 2);
    }

/* ------------------------------

        Dungeon Checks 

------------------------------ */

/* ------------------------------

        Forest Temple 

------------------------------ */

    public bool ForestTempleEntranceVinesChest()
    {
        return CanAccessFT() && CanDefeatWalltula();
    }

    public bool ForestTempleCentralChestBehindStairs()
    {
        return CanAccessFT()
            && Has("RangCount")
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage();
    }

    public bool ForestTempleCentralNorthChest()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("LanternCount");
    }

    public bool ForestTempleWindlessBridgeChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            &&CanBreakMonkeyCage();
    }

    public bool ForestTempleSecondMonkeyUnderBridgeChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && (Has("FTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool ForestTempleTotemPoleChest()
    {
        return CanAccessFT()
            && CanBurnWebs()
            && (Has("FTKeyCount", 2)
                || SettingsStatus["IgnoreKeyLogic"]
                || Has("ClawCount"))
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage();
    }

    public bool ForestTempleWestTileWormRoomVinesChest()
    {
        return CanAccessFT()
            && CanBurnWebs()
            && (((Has("FTKeyCount", 2)
                        || SettingsStatus["IgnoreKeyLogic"])
                    && CanDefeatBokoblin())
                || Has("ClawCount"));
    }

    public bool ForestTempleWestDekuLikeChest()
    {
        return CanAccessFT()
            && CanBurnWebs()
            && (((Has("FTKeyCount", 2)
                        || SettingsStatus["IgnoreKeyLogic"])
                    && CanDefeatBokoblin())
                || Has("ClawCount"));
    }

    public bool ForestTempleBigBabaKey()
    {
        return CanAccessFT()
            && CanBurnWebs()
            && CanDefeatBigBaba()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && CanDefeatBokoblin()
            && (Has("FTKeyCount", 2)
                || SettingsStatus["IgnoreKeyLogic"]
                || Has("ClawCount"));
    }

    public bool ForestTempleGaleBoomerang()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && CanDefeatOok()
            && ((Has("LanternCount")
                && (Has("FTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"]))
                || (Has("RangCount")
                    && CanBurnWebs()
                    && (Has("FTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"]
                        || Has("ClawCount"))));
    }

    public bool ForestTempleWestTileWormChestBehindStairs()
    {
        return CanAccessFT()
            && CanBurnWebs()
            && Has("RangCount")
            && (((Has("FTKeyCount", 4)
                        || SettingsStatus["IgnoreKeyLogic"])
                    && CanDefeatBokoblin())
                || Has("ClawCount"));
    }

    public bool ForestTempleCentralChestHangingFromWeb()
    {
        return CanAccessFT()
            && CanCutHangingWeb()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage();
    }

    public bool ForestTempleBigKeyChest()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("RangCount");
    }

    public bool ForestTempleEastWaterCaveChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage();
    }

    public bool ForestTempleNorthDekuLikeChest()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("RangCount");
    }

    public bool ForestTempleEastTileWormChest()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("RangCount")
            && (Has("FTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool ForestTempleDiababaHeartContainer()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("RangCount")
            && (Has("FTBossKeyCount") || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDiababa()
            && (CanFreeAllMonkeys() || Has("ClawCount"));
    }

    public bool ForestTempleDungeonReward()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("RangCount")
            && (Has("FTBossKeyCount") || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDiababa()
            && (CanFreeAllMonkeys() || Has("ClawCount"));
    }

/* ------------------------------

            Goron Mines 

------------------------------ */

    public bool GoronMinesEntranceChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor();
    }

    public bool GoronMinesMainMagnetRoomBottomChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor();
    }

    public bool GoronMinesGorAmatoChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesGorAmatoKeyShard()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesGorAmatoSmallChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesMagnetMazeChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesCrystalSwitchRoomUnderwaterChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesCrystalSwitchRoomSmallChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesAfterCrystalSwitchRoomMagnetWallChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesOutsideBeamosChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && (Has("BowCount") || Has("SwordCount"));
    }

    public bool GoronMinesGorEbizoKeyShard()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && (Has("BowCount") || Has("SwordCount"));
    }

    public bool GoronMinesGorEbizoChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && (Has("BowCount") || Has("SwordCount"));
    }

    public bool GoronMinesChestBeforeDangoro()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool GoronMinesDangoroChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDangoro();
    }

    public bool GoronMinesBeamosRoomChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDangoro()
            && Has("BowCount");
    }

    public bool GoronMinesGorLiggsKeyShard()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDangoro()
            && Has("BowCount");
    }

    public bool GoronMinesGorLiggsChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDangoro()
            && Has("BowCount");
    }

    public bool GoronMinesMainMagnetRoomTopChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDangoro()
            && Has("BowCount");
    }

    public bool GoronMinesOutsideClawshotChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && (Has("BowCount") || Has("SwordCount"))
            && Has("ClawCount");
    }

    public bool GoronMinesOutsideUnderwaterChest()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && (Has("GMKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && ((Has("BowCount")
                    && (Has("WBombCount")
                        || (SettingsStatus["IgnoreWaterBombLogic"] && Has("BombCount"))))
                || Has("SwordCount"));
    }

    public bool GoronMinesFyrusHeartContainer()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && ((Has("GMKeyCount", 3) && Has("GMBossKeyCount", 3))
                || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatBulblin()
            && Has("BowCount")
            && CanDefeatFyrus();
    }

    public bool GoronMinesDungeonReward()
    {
        return CanAccessGM()
            && Has("BootsCount")
            && CanBreakWoodenDoor()
            && ((Has("GMKeyCount", 3) && Has("GMBossKeyCount", 3))
                || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatBulblin()
            && Has("BowCount")
            && CanDefeatFyrus();
    }

/* ------------------------------

        Lakebed Temple 

------------------------------ */

    public bool LakebedTempleLobbyLeftChest()
    {
        return CanAccessLT();
    }

    public bool LakebedTempleLobbyRearChest()
    {
        return CanAccessLT();
    }

    public bool LakebedTempleStalactiteRoomChest()
    {
        return CanAccessLT()
            && CanLaunchBombs();
    }

    public bool LakebedTempleCentralRoomSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs();
    }

    public bool LakebedTempleCentralRoomChest()
    {
        return CanAccessLT()
            && CanLaunchBombs();
    }

    public bool LakebedTempleEastLowerWaterwheelStalactiteChest()
    {
        return CanAccessLT()
            && CanLaunchBombs();
    }

    public bool LakebedTempleEastSecondFloorSouthwestChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool LakebedTempleEastSecondFloorSoutheastChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool LakebedTempleEastWaterSupplySmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount");
    }

    public bool LakebedTempleBeforeDekuToadAlcoveChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterLeftChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount");
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterRightChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount");
    }

    public bool LakebedTempleDekuToadChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && CanDefeatDekuToad()
            && (Has("WBombCount")
                || (Has("BombCount") && SettingsStatus["IgnoreWaterBombLogic"]));
    }

    public bool LakebedTempleChandelierChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && Has("ClawCount");
    }

    public bool LakebedTempleCentralRoomSpireChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount");
    }

    public bool LakebedTempleEastWaterSupplyClawshotChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && Has("ClawCount");
    }

    public bool LakebedTempleWestLowerSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount");
    }

    public bool LakebedTempleWestWaterSupplySmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && Has("ClawCount");
    }

    public bool LakebedTempleWestWaterSupplyChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && Has("ClawCount");
    }

    public bool LakebedTempleWestSecondFloorSouthwestUnderwaterChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && Has("ClawCount");
    }

    public bool LakebedTempleWestSecondFloorCentralSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount");
    }

    public bool LakebedTempleWestSecondFloorNortheastChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount");
    }

    public bool LakebedTempleWestSecondFloorSoutheastChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount");
    }

    public bool LakebedTempleBigKeyChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && Has("ClawCount")
            && (Has("WBombCount")
                || (Has("BombCount") && SettingsStatus["IgnoreWaterBombLogic"]));
    }

    public bool LakebedTempleUnderwaterMazeSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount");
    }

    public bool LakebedTempleEastLowerWaterwheelBridgeChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount");
    }

    public bool LakebedTempleMorpheelHeartContainer()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && ((Has("LTKeyCount", 3) && Has("LTBossKeyCount"))
                || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount")
            && CanDefeatMorpheel();
    }

    public bool LakebedTempleDungeonReward()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && ((Has("LTKeyCount", 3) && Has("LTBossKeyCount"))
                || SettingsStatus["IgnoreKeyLogic"])
            && Has("ClawCount")
            && CanDefeatMorpheel();
    }

/* ------------------------------

        Arbiter's Grounds 

------------------------------ */

    public bool ArbitersGroundsEntranceChest()
    {
        return CanAccessAG() && CanBreakWoodenDoor();
    }

    public bool ArbitersGroundsTorchRoomWestChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount");
    }

    public bool ArbitersGroundsTorchRoomEastChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount");
    }

    public bool ArbitersGroundsEastLowerTurnableRedeadChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount");
    }

    public bool ArbitersGroundsEastUpperTurnableChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount");
    }

    public bool ArbitersGroundsEastUpperTurnableRedeadChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount");
    }

    public bool ArbitersGroundsGhoulRatRoomChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatBubble();
    }

    public bool ArbitersGroundsWestSmallChestBehindBlock()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount");
    }

    public bool ArbitersGroundsWestChandelierChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount");
    }

    public bool ArbitersGroundsWestStalfosWestChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount");
    }

    public bool ArbitersGroundsWestStalfosNortheastChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount");
    }

    public bool ArbitersGroundsNorthTurningRoomChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount");
    }

    public bool ArbitersGroundsDeathSwordChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && CanSmash();
    }

    public bool ArbitersGroundsSpinnerRoomFirstSmallChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount");
    }

    public bool ArbitersGroundsSpinnerRoomSecondSmallChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount");
    }

    public bool ArbitersGroundsSpinnerRoomLowerCentralSmallChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount");
    }

    public bool ArbitersGroundsSpinnerRoomStalfosAlcoveChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount");
    }

    public bool ArbitersGroundsSpinnerRoomLowerNorthChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount");
    }

    public bool ArbitersGroundsBigKeyChest()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount")
            && CanSmash();
    }

    public bool ArbitersGroundsStallordHeartContainer()
    {
        return CanAccessAG()
            && ((Has("AGKeyCount", 4) && Has("AGBossKeyCount")) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount")
            && Has("SpinCount")
            && CanDefeatStallord();
    }

    // Poes

    public bool ArbitersGroundsTorchRoomPoe()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount");
    }

    public bool ArbitersGroundsEastTurningRoomPoe()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("LanternCount")
            && Has("CrystalCount")
            && Has("ClawCount");
    }

    public bool ArbitersGroundsHiddenWallPoe()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatRedeadKnight()
            && Has("CrystalCount");
    }

    public bool ArbitersGroundsWestPoe()
    {
        return CanAccessAG()
            && (Has("AGKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && CanSmash()
            && Has("CrystalCount");
    }

/* ------------------------------

        Snowpeak Ruins 

------------------------------ */

    public bool SnowpeakRuinsLobbyEastArmorChest()
    {
        return CanAccessSR() && Has("BCCount");
    }

    public bool SnowpeakRuinsLobbyWestArmorChest()
    {
        return CanAccessSR() && Has("BCCount");
    }

    public bool SnowpeakRuinsMansionMap()
    {
        return CanAccessSR();
    }

    public bool SnowpeakRuinsEastCourtyardBuriedChest()
    {
        return CanAccessSR() && Has("CrystalCount");
    }

    public bool SnowpeakRuinsEastCourtyardChest()
    {
        return CanAccessSR() && Has("CrystalCount") && Has("BCCount");
    }

    public bool SnowpeakRuinsOrdonPumpkinChest()
    {
        return CanAccessSR()
            && (Has("CrystalCount") || Has("BCCount"))
            && (Has("SRKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsWestCourtyardBuriedChest()
    {
        return CanAccessSR()
            && Has("CrystalCount")
            && (Has("BCCount")
                || Has("PumpkinCount")
                || (Has("CheeseCount") && Has("SRKeyCount", 2))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsWoodenBeamCentralChest()
    {
        return CanAccessSR()
            && (Has("BCCount")
                || (Has("BombCount")
                    && (Has("PumpkinCount")
                        || (Has("CheeseCount") && Has("SRKeyCount", 2))
                        || SettingsStatus["IgnoreKeyLogic"])));
    }

    public bool SnowpeakRuinsWoodenBeamNorthwestChest()
    {
        return CanAccessSR()
            && (Has("BCCount")
                || (Has("BombCount")
                    && (Has("PumpkinCount")
                        || (Has("CheeseCount") && Has("SRKeyCount", 2))
                        || SettingsStatus["IgnoreKeyLogic"])));
    }

    public bool SnowpeakRuinsCourtyardCentralChest()
    {
        return CanAccessSR()
            && Has("CrystalCount")
            && ((Has("PumpkinCount") && Has("SRKeyCount", 2))
                || SettingsStatus["IgnoreKeyLogic"]
                || (Has("BCCount") && CanDefeatDarkhammer()));

    }

    public bool SnowpeakRuinsBallandChain()
    {
        return CanAccessSR()
            && CanDefeatDarkhammer()
            && (Has("BCCount")
                || (Has("BombCount")
                    && ((Has("PumpkinCount")
                        && (Has("CheeseCount")
                            || Has("SRKeyCount", 2)))
                        || SettingsStatus["IgnoreKeyLogic"])));
    }

    public bool SnowpeakRuinsChestAfterDarkhammer()
    {
        return CanAccessSR()
            && CanDefeatDarkhammer()
            && Has("BCCount");
    }

    public bool SnowpeakRuinsBrokenFloorChest()
    {
        return CanAccessSR()
            && Has("BCCount")
            && (Has("CheeseCount") || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsWoodenBeamChandelierChest()
    {
        return CanAccessSR()
            && Has("BCCount")
            && (Has("CheeseCount") || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsLobbyChandelierChest()
    {
        return CanAccessSR()
            && Has("BCCount")
            && ((Has("CheeseCount") && Has("SRKeyCount", 3))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsNortheastChandelierChest()
    {
        return CanAccessSR()
            && Has("BCCount")
            && Has("ClawCount")
            && ((Has("CheeseCount") && Has("SRKeyCount", 3))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsWestCannonRoomCentralChest()
    {
        return CanAccessSR()
            && Has("BCCount");
    }

    public bool SnowpeakRuinsWestCannonRoomCornerChest()
    {
        return CanAccessSR()
            && (Has("BCCount")
                || (Has("BombCount")
                    && (Has("PumpkinCount")
                        || (Has("CheeseCount") && Has("SRKeyCount", 2))
                        || SettingsStatus["IgnoreKeyLogic"])));
    }

    public bool SnowpeakRuinsChapelChest()
    {
        return CanAccessSR()
            && Has("BCCount")
            && Has("BombCount")
            && ((Has("CheeseCount") && Has("SRKeyCount", 4))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsBlizzetaHeartContainer()
    {
        return CanAccessSR()
            && Has("BCCount")
            && Has("BombCount")
            && ((Has("CheeseCount") && Has("SRKeyCount", 4) && Has("SRBossKeyCount"))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool SnowpeakRuinsDungeonReward()
    {
        return CanAccessSR()
            && Has("BCCount")
            && Has("BombCount")
            && ((Has("CheeseCount") && Has("SRKeyCount", 4) && Has("SRBossKeyCount"))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    // Poes

    public bool SnowpeakRuinsLobbyPoe()
    {
        return CanAccessSR() && Has("CrystalCount");
    }

    public bool SnowpeakRuinsLobbyArmorPoe()
    {
        return CanAccessSR() && Has("CrystalCount") && Has("BCCount");
    }

    public bool SnowpeakRuinsIceRoomPoe()
    {
        return CanAccessSR()
            && Has("BCCount")
            && Has("CrystalCount")
            && ((Has("CheeseCount") && Has("SRKeyCount", 3))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

/* ------------------------------

        Temple of Time

------------------------------ */

    public bool TempleofTimeLobbyLanternChest()
    {
        return CanAccessToT() && Has("LanternCount");
    }

    public bool TempleofTimeFirstStaircaseGohmaGateChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanRange()
            && CanDefeatLizalfos()
            && CanDefeatArmos();
    }

    public bool TempleofTimeFirstStaircaseWindowChest()
    {
        return CanAccessToT()
            && CanRange()
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool TempleofTimeFirstStaircaseArmosChest()
    {
        return CanAccessToT()
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanRange()
            && CanDefeatLizalfos()
            && CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberEastChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanRange()
            && CanDefeatLizalfos()
            && CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberNorthChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanRange()
            && CanDefeatLizalfos();
    }

    public bool TempleofTimeMovingWallBeamosRoomChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos();
    }

    public bool TempleofTimeScalesGohmaChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos();
    }

    public bool TempleofTimeGilloutineChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos();
    }

    public bool TempleofTimeChestBeforeDarknut()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos();
    }

    public bool TempleofTimeDarknutChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos()
            && CanDefeatDarknut();
    }

    public bool TempleofTimeScalesUpperChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos();
    }

    public bool TempleofTimeFloorSwitchPuzzleRoomUpperChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos()
            && Has("ClawCount");
    }

    public bool TempleofTimeBigKeyChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos()
            && Has("ClawCount");
    }

    public bool TempleofTimeMovingWallDinalfosRoomChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos()
            && Has("RodCount")
            && CanDefeatDinalfos();
    }

    public bool TempleofTimeArmosAntechamberStatueChest()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanRange()
            && CanDefeatLizalfos()
            && CanDefeatArmos()
            && Has("RodCount");
    }

    public bool TempleofTimeArmogohmaHeartContainer()
    {
        return CanAccessToT()
            && ((Has("SpinCount")
                && (Has("ToTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"]))
                    || SettingsStatus["OpenDoorOfTime"])
            && (Has("ToTBossKeyCount") || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatArmogohma();
    }

    public bool TempleofTimeDungeonReward()
    {
        return CanAccessToT()
            && ((Has("SpinCount")
                && (Has("ToTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"]))
                    || SettingsStatus["OpenDoorOfTime"])
            && (Has("ToTBossKeyCount") || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatArmogohma();
    }

    // Poes

    public bool TempleofTimePoeBehindGate()
    {
        return CanAccessToT()
            && Has("CrystalCount")
            && Has("RodCount")
            && (Has("ToTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool TempleofTimePoeAboveScales()
    {
        return CanAccessToT()
            && Has("SpinCount")
            && (Has("ToTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BowCount")
            && CanDefeatLizalfos()
            && Has("CrystalCount")
            && Has("ClawCount");
    }

/* ------------------------------

        City in the Sky 

------------------------------ */

    public bool CityinTheSkyUnderwaterEastChest()
    {
        return CanAccessCitS() && Has("BootsCount");
    }

    public bool CityinTheSkyUnderwaterWestChest()
    {
        return CanAccessCitS() && Has("BootsCount");
    }

    public bool CityinTheSkyWestWingFirstChest()
    {
        return CanAccessCitS() && Has("ClawCount");
    }

    public bool CityinTheSkyEastFirstWingChestAfterFans()
    {
        return CanAccessCitS()
            && Has("ClawCount")
            && Has("SpinCount")
            && (Has("CitSKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool CityinTheSkyEastTileWormSmallChest()
    {
        return CanAccessCitS()
            && Has("ClawCount")
            && Has("SpinCount")
            && (Has("CitSKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool CityinTheSkyEastWingAfterDinalfosLedgeChest()
    {
        return CanAccessCitS()
            && Has("ClawCount")
            && Has("SpinCount")
            && (Has("CitSKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatTileWorm()
            && CanDefeatDinalfos();
    }

    public bool CityinTheSkyEastWingAfterDinalfosAlcoveChest()
    {
        return CanAccessCitS()
            && Has("ClawCount")
            && Has("SpinCount")
            && (Has("CitSKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatTileWorm()
            && CanDefeatDinalfos();
    }

    public bool CityinTheSkyAeralfosChest()
    {
        return CanAccessCitS()
            && Has("ClawCount")
            && Has("SpinCount")
            && (Has("CitSKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && Has("BootsCount")
            && Has("RangCount")
            && CanDefeatAeralfos();
    }

    public bool CityinTheSkyEastWingLowerLevelChest()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && Has("SpinCount")
            && (Has("CitSKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatTileWorm()
            && CanDefeatDinalfos();
    }

    public bool CityinTheSkyWestWingBabaBalconyChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2);
    }

    public bool CityinTheSkyWestWingNarrowLedgeChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2);
    }

    public bool CityinTheSkyWestWingTileWormChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2);
    }

    public bool CityinTheSkyBabaTowerTopSmallChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerNarrowLedgeChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerAlcoveChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenCornerChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenLoneIslandChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenLowerChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenLedgeChest()
    {
        return CanAccessCitS() && Has("ClawCount", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyCentralOutsideLedgeChest()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("BootsCount")
            && Has("CrystalCount");
    }

    public bool CityinTheSkyCentralOutsidePoeIslandChest()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("BootsCount")
            && Has("CrystalCount");
    }

    public bool CityinTheSkyBigKeyChest()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("BootsCount")
            && Has("CrystalCount");
    }

    public bool CityinTheSkyChestBelowBigKeyChest()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("BootsCount");
    }

    public bool CityinTheSkyChestBehindNorthFan()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("BootsCount")
            && Has("CrystalCount");
    }

    public bool CityinTheSkyArgorokHeartContainer()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatArgorok()
            && Has("BootsCount")
            && Has("CrystalCount")
            && (Has("CitSBossKeyCount") || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool CityinTheSkyDungeonReward()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatArgorok()
            && Has("BootsCount")
            && Has("CrystalCount")
            && (Has("CitSBossKeyCount") || SettingsStatus["IgnoreKeyLogic"]);
    }

    // Poes

    public bool CityinTheSkyGardenIslandPoe()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("CrystalCount");
    }

    public bool CityinTheSkyPoeAboveCentralFan()
    {
        return CanAccessCitS()
            && Has("ClawCount", 2)
            && CanDefeatBigBaba()
            && Has("BootsCount")
            && Has("CrystalCount");
    }

/* ------------------------------

        Palace of Twilight

------------------------------ */

    public bool PalaceofTwilightWestWingFirstRoomCentralChest()
    {
        return CanAccessPoT() && CanDefeatZantHead();
    }

    public bool PalaceofTwilightWestWingChestBehindWallofDarkness()
    {
        return CanAccessPoT() && Has("SwordCount", 4) && Has("ClawCount");
    }

    public bool PalaceofTwilightWestWingSecondRoomCentralChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomLowerSouthChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomSoutheastChest()
    {
        return CanAccessPoT()
            && Has("ClawCount", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomZantHeadChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightEastWingFirstRoomNorthSmallChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 2) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightEastWingSecondRoomNortheastChest()
    {
        return CanAccessPoT()
            && Has("ClawCount", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightEastWingSecondRoomNorthwestChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightEastWingSecondRoomSouthwestChest()
    {
        return CanAccessPoT()
            && Has("ClawCount", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightEastWingSecondRoomSoutheastChest()
    {
        return CanAccessPoT()
            && Has("ClawCount", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightEastWingFirstRoomEastAlcove()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && Has("CrystalCount")
            && (Has("PoTKeyCount", 4)
                || (Has("PoTKeyCount", 2) && Has("SwordCount", 4))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomWestAlcove()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && Has("CrystalCount")
            && (Has("PoTKeyCount", 4)
                || (Has("PoTKeyCount", 2) && Has("SwordCount", 4))
                || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool PalaceofTwilightCollectBothSols()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && CanDefeatPhantomZant()
            && (Has("PoTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightCentralFirstRoomChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && Has("SwordCount", 4)
            && (Has("PoTKeyCount", 4) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightBigKeyChest()
    {
        return CanAccessPoT()
            && Has("ClawCount", 2)
            && Has("SwordCount", 4)
            && (Has("PoTKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightCentralOutdoorChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && Has("SwordCount", 4)
            && (Has("PoTKeyCount", 5) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightCentralTowerChest()
    {
        return CanAccessPoT()
            && Has("ClawCount")
            && Has("SwordCount", 4)
            && (Has("PoTKeyCount", 6) || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

    public bool PalaceofTwilightZantHeartContainer()
    {
        return CanAccessPoT()
            && CanDefeatZant()
            && Has("SwordCount", 4)
            && ((Has("PoTKeyCount", 4) && Has("PoTBossKeyCount"))
                || SettingsStatus["IgnoreKeyLogic"])
            && Has("CrystalCount");
    }

/* ------------------------------

        Hyrule Castle 

------------------------------ */

    public bool HyruleCastleGraveyardGraveSwitchRoomRightChest()
    {
        return CanAccessHC() && Has("CrystalCount") && CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomFrontLeftChest()
    {
        return CanAccessHC() && Has("CrystalCount") && CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomBackLeftChest()
    {
        return CanAccessHC() && Has("CrystalCount") && CanSmash();
    }

    public bool HyruleCastleGraveyardOwlStatueChest()
    {
        return CanAccessHC()
            && Has("CrystalCount")
            && CanSmash()
            && Has("LanternCount")
            && Has("RodCount", 2);
    }

    public bool HyruleCastleEastWingBoomerangPuzzleChest()
    {
        return CanAccessHC() && Has("RangCount");
    }

    public bool HyruleCastleEastWingBalconyChest()
    {
        return CanAccessHC() && Has("RangCount");
    }

    public bool HyruleCastleWestCourtyardNorthSmallChest()
    {
        return CanAccessHC() && CanDefeatBokoblin();
    }

    public bool HyruleCastleWestCourtyardCentralSmallChest()
    {
        return CanAccessHC() && CanDefeatBokoblin();
    }

    public bool HyruleCastleKingBulblinKey()
    {
        return CanAccessHC() && CanDefeatKingBulblinCastle();
    }

    public bool HyruleCastleMainHallNortheastChest()
    {
        return CanAccessHC()
            && CanDefeatLizalfos()
            && Has("ClawCount")
            && (Has("HCKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"]);
    }

    public bool HyruleCastleLanternStaircaseChest()
    {
        return CanAccessHC()
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && (Has("HCKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatDarknut()
            && Has("RangCount");
    }

    public bool HyruleCastleMainHallSouthwestChest()
    {
        return CanAccessHC()
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && (Has("HCKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanKnockDownHCPainting()
            && Has("RangCount")
            && Has("LanternCount");
    }

    public bool HyruleCastleMainHallNorthwestChest()
    {
        return CanAccessHC()
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && (Has("HCKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanKnockDownHCPainting()
            && Has("RangCount")
            && Has("LanternCount");
    }

    public bool HyruleCastleSoutheastBalconyTowerChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && CanDefeatAeralfos()
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleBigKeyChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 1) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFirstChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSecondChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomThirdChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFourthChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFifthChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFirstSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSecondSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomThirdSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFourthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFifthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSixthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSeventhSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomEighthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCKeyCount", 3) || SettingsStatus["IgnoreKeyLogic"])
            && CanDefeatLizalfos()
            && Has("ClawCount", 2)
            && CanDefeatDarknut()
            && Has("RangCount")
            && Has("SpinCount")
            && ((Has("LanternCount") && CanDefeatDinalfos()) || CanKnockDownHCPainting());
    }

}
