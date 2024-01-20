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

        {"FishingRod", 0 }, //2
        {"Slingshot", 0 },
        {"Lantern", 0 },
        {"Boomerang", 0 },
        {"IronBoots", 0 },
        {"Bow", 0 }, //3
        {"Bombs", 0 }, //3
        {"WaterBombs", 0 },
        {"GiantBombs", 0 },
        {"Hawkeye", 0 },
        {"Clawshot", 0 }, //2
        {"Spinner", 0 },
        {"B&C", 0 },
        {"DominionRod", 0 }, //2
        {"AurusMemo", 0 },
        {"AsheisSketch", 0 },
        {"Bottle", 0 }, //4
        {"ShadowCrystal", 0 },
        {"HiddenSkill", 0 }, //7
        {"FetchQuest", 0 }, //4
        {"HorseCall", 0 },
        {"Skybook", 0 }, //7
        {"Wallet", 0 }, //3
        {"GoldenBug", 0 }, //24
        {"PoeSoul", 0 }, //60
        {"Sword", 0 }, //4
        {"Shield", 0 }, //2
        {"Tunic", 0 },
        {"ZoraArmor", 0 },
        {"MagicArmor", 0 },
        {"HeartPiece", 0 }, //45
        {"HeartContainer", 0 }, //8
        {"FusedShadow", 0 }, //3
        {"MirrorShard", 0 }, //3

        {"YouthScent", 0 },
        {"IliaScent", 0 },
        {"PoeScent", 0 },
        {"ReekfishScent", 0 },
        {"MedicineScent", 0 },

        {"FaronVessel", 0 },
        {"EldinVessel", 0 },
        {"LanayruVessel", 0 },

        {"Boss1", 0 },
        {"Boss2", 0 },
        {"Boss3", 0 },
        {"Boss4", 0 },
        {"Boss5", 0 },
        {"Boss6", 0 },
        {"Boss7", 0 },
        {"Boss8", 0 },

        {"GateKeys", 0 },
        {"FaronKeys", 0 },
        {"DesertKeys", 0 },

        {"FTSmallKey", 0 }, //4
        {"FTBigKey", 0 },

        {"GMSmallKey", 0 }, //3
        {"GMBigKey", 0 }, //3

        {"LTSmallKey", 0 }, //3
        {"LTBigKey", 0 },

        {"AGSmallKey", 0 }, //5
        {"AGBigKey", 0 },

        {"SRSmallKey", 0 }, //4
        {"SRBigKey", 0 },
        {"Pumpkin", 0 },
        {"Cheese", 0 },

        {"ToTSmallKey", 0 }, //3
        {"ToTBigKey", 0 },

        {"CitSSmallKey", 0 }, //1
        {"CitSBigKey", 0 },

        {"PoTSmallKey", 0 }, //7
        {"PoTBigKey", 0 },

        {"HCSmallKey", 0 }, //3
        {"HCBigKey", 0 }

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
        {"BonksDoDamage", false },
        {"TransformAnywhere", false },

        {"SmallKeysVanilla", true },
        {"SmallKeysOwnDungeon", false },
        {"SmallKeysAnyDungeon", false },
        {"SmallKeysKeysanity", false },
        {"SmallKeysKeysy", false },

        {"BigKeysVanilla", true },
        {"BigKeysOwnDungeon", false },
        {"BigKeysAnyDungeon", false },
        {"BigKeysKeysanity", false },
        {"BigKeysKeysy", false },

        {"DamageVanilla", true },
        {"DamageDouble", false },
        {"DamageTriple", false },
        {"DamageQuadruple", false },
        {"DamageOHKO", false },

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

    public bool HasDamagingItem()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Bombs")
            || Has("IronBoots")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool CanSmash()
    {
        return Has("B&C") || Has("Bombs");
    }

    public bool CanBurnWebs()
    {
        return Has("Lantern") || Has("B&C") || Has("Bombs");
    }

    public bool HasRangedItem()
    {
        return Has("Bow")
            || Has("Slingshot")
            || Has("Boomerang")
            || Has("B&C")
            || Has("Clawshot");
    }

    public bool HasShield()
    {
        return Has("Shield", 2)
            || CanAccessKakariko()
            || CanAccessCastleTown()
            || (CanAccessDeathMountain() && CanDefeatGoron());
    }

    public bool CanUseBottledFairy()
    {
        return Has("Bottle") && CanAccessLakeHylia();
    }

    public bool CanUseBottledFairies()
    {
        return Has("Bottle", 2) && CanAccessLakeHylia();
    }

    public bool CanUseOilBottle()
    {
        return true;
        // should be lantern and coro bottle
        // don't have bottles separated so this can't be used rn
    }

    public bool CanLaunchBombs()
    {
        return (Has("Bow") || Has("Boomerang")) && Has("Bombs");
    }

    public bool CanBombArrow()
    {
        return Has("Bow") && Has("Bombs");
    }

    public bool CanCutHangingWeb()
    {
        return Has("Clawshot")
            || Has("Boomerang")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows());
    }

    public int GetPlayerHealth()
    {
        double playerHealth = 3.0;

        playerHealth += ItemCounts["HeartPiece"];
        playerHealth += ItemCounts["HeartContainer"];

        return (int)playerHealth;
    }

    public bool CanKnockDownHCPainting()
    {
        return Has("Bow");
    }

    public bool CanUseWBombs()
    {
        return Has("WaterBombs") || (Has("Bombs") && SettingsStatus["IgnoreWaterBombLogic"]);
    }

    public bool CanGetArrows()
    {
        return CanClearForest() || CanAccessLostWoods();
    }

    public bool CanBreakMonkeyCage()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("IronBoots")
            || Has("Bombs")
            || Has("Clawshot")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || (Has("Bow") && CanGetArrows());
    }

    public bool CanFreeAllMonkeys()
    {
        return CanBreakMonkeyCage()
            && (Has("Lantern") || Has("Bombs") || Has("IronBoots")) //?
            && CanBurnWebs()
            && Has("Boomerang")
            && CanDefeatBokoblin()
            && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool CanPressMinesSwitch()
    {
        return Has("IronBoots");
    }

    public bool CanKnockDownHangingBaba()
    {
        return Has("Bow") || Has("Boomerang") || Has("Clawshot") || Has("Slingshot");
    }

    public bool CanBreakWoodenDoor()
    {
        return Has("ShadowCrystal") || Has("Sword") || CanSmash();
    }

/* ------------------------------

        Areas/Settings

------------------------------ */

    public bool CanCompletePrologue()
    {
        return (Has("Sword") && Has("Slingshot") && (Has("FaronKeys") || SettingsStatus["SmallKeysKeysy"]))
            || SettingsStatus["SkipPrologue"];
    }

    public bool CanClearForest()
    {
        return (Has("Boss1") || SettingsStatus["FaronEscape"]) && CanCompletePrologue();
    }

    public bool CanCompleteMDH()
    {
        return CanCompleteLT() || SettingsStatus["SkipMDH"];
    }

    public bool HasSetMDHFlag()
    {
        return Has("Boss3") || SettingsStatus["SkipMDH"];
    }

    public bool FaronTwilightCleared()
    {
        return Has("FaronVessel") || SettingsStatus["SkipFaronTwilight"];
    }

    public bool EldinTwilightCleared()
    {
        return Has("EldinVessel") || SettingsStatus["SkipEldinTwilight"];
    }

    public bool LanayruTwilightCleared()
    {
        return Has("LanayruVessel") || SettingsStatus["SkipLanayruTwilight"];
    }

    public bool CanCompleteEldinTwilight()
    {
        return SettingsStatus["SkipEldinTwilight"] || (CanCompletePrologue() && CanClearForest());
    }

    public bool CanAccessNorthFaron()
    {
        return CanCompletePrologue() && (Has("Lantern") || Has("ShadowCrystal"));
    }

    public bool CanAccessLostWoods()
    {
        return CanCompletePrologue() && Has("ShadowCrystal");
    }

    public bool CanAccessSacredGrove()
    {
        return CanAccessLostWoods()
            && (CanDefeatSkullKid() || SettingsStatus["ToTOpen"] || SettingsStatus["ToTOpenGrove"]);
    }

    public bool CanAccessKakariko() // used for gorge and village since requirements are the same
    {
        return CanClearForest() || (EldinTwilightCleared() && SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal"));
    }

    public bool CanAccessDeathMountain()
    {
        return (CanAccessKakariko() && (Has("IronBoots") || Has("ShadowCrystal")))
            || (EldinTwilightCleared() && SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal"));
    }

    public bool CanAccessLakeHylia()
    {
        return CanAccessLanayru();
    }

    public bool CanAccessDesert()
    {
        return CanAccessLakeHylia() && Has("AurusMemo");
    }

    public bool CanAccessZorasDomain()
    {
        return (CanClearForest()
            && (CanSmash() 
                || ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                && Has("ShadowCrystal"))))
            || (LanayruTwilightCleared() && SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal"));
    }

    public bool CanAccessSnowpeakClimb()
    {
        return CanAccessZorasDomain() || (SettingsStatus["EarlySnowpeak"] && SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal"));
    }

    public bool CanAccessSnowpeakSummit()
    {
        return (CanAccessZorasDomain()
            && (Has("ReekfishScent")
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || SettingsStatus["EarlySnowpeak"])
            && Has("ShadowCrystal"))
            || (SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal") && SettingsStatus["EarlySnowpeak"]);
    }

    public bool CanAccessMirrorChamber()
    {
        return Has("Boss4");
    }

    public bool CanAccessCastleTown()
    {
        return CanAccessLanayru();
    }

    public bool CanAccessEldinField()
    {
        return CanAccessKakariko();
    }

    public bool CanAccessLanayru()
    {
        return (CanClearForest()
            && (CanSmash() 
                || ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                && (LanayruTwilightCleared() || Has("ShadowCrystal")))))
            || (LanayruTwilightCleared() && SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal"));
    }

    public bool GoMode()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("HCBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatLizalfos()
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && ((Has("Lantern") && CanDefeatDinalfos()) || CanKnockDownHCPainting())
            && CanDefeatGanondorf();
    }

/* ------------------------------

            Dungeons

------------------------------ */

    public bool CanAccessFT()
    {
        return CanAccessNorthFaron();
    }

    public bool CanCompleteFT()
    {
        return CanBreakMonkeyCage()
            && Has("Boomerang")
            && (Has("FTBigKey") || SettingsStatus["BigKeysKeysy"])
            && (CanFreeAllMonkeys() || Has("Clawshot"))
            && CanDefeatDiababa();
    }

    public bool CanAccessGM()
    {
        return Has("IronBoots")
            && (CanDefeatGoron() || SettingsStatus["MinesOpen"])
            && CanAccessDeathMountain();
    }

    public bool CanCompleteGM()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3)  || SettingsStatus["SmallKeysKeysy"])
            && (Has("GMBigKey", 3) || SettingsStatus["BigKeysKeysy"])
            && Has("Bow")
            && CanDefeatBulblin()
            && CanDefeatFyrus();
    }

    public bool CanAccessLT()
    {
        return CanAccessLakeHylia()
            && Has("ZoraArmor")
            && (SettingsStatus["EarlyLakebed"]
                || (Has("IronBoots")
                    && (Has("WaterBombs")
                        || (Has("Bombs")
                            && SettingsStatus["IgnoreWaterBombLogic"]))));
    }

    public bool CanCompleteLT()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("LTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatMorpheel();
    }

    public bool CanAccessAG()
    {
        return CanAccessDesert()
            && (((Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"]) && CanDefeatKingBulblinDesert())
                || SettingsStatus["EarlyArbiters"]);
    }

    public bool CanCompleteAG()
    {
        return Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && Has("Spinner")
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && (Has("AGBigKey") || SettingsStatus["BigKeysKeysy"])
            && ((CanAccessLanayru()
                && Has("AurusMemo")
                && CanDefeatKingBulblinDesert()
                && (Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"]))
                    || SettingsStatus["EarlyArbiters"]);

    }

    public bool CanAccessSR()
    {
        return CanAccessSnowpeakSummit()
        && (!SettingsStatus["BonksDoDamage"]
            || (SettingsStatus["BonksDoDamage"]
                && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairy())));;
    }

    public bool CanCompleteSR()
    {
        return CanAccessSR()
            && (Has("SRSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"])
            && Has("Cheese")
            && Has("B&C")
            && Has("Bombs")
            && CanDefeatBlizzeta();
    }

    public bool CanAccessToT()
    {
        return CanAccessSacredGrove()
            && (((CanDefeatShadowBeast() || SettingsStatus["ToTOpenGrove"]) && Has("Sword", 3))
                || SettingsStatus["ToTOpen"]);
    }

    public bool CanCompleteToT()
    {
        return CanAccessToT()
            && Has("DominionRod")
            && Has("Bow")
            && Has("Spinner")
            && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("ToTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatArmogohma();
    }

    public bool CanAccessCitS()
    {
        return CanAccessLakeHylia()
            && Has("Clawshot")
            && (Has("Skybook", 7) || SettingsStatus["EarlyCitS"]);
    }

    public bool CanCompleteCitS()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && Has("ShadowCrystal")
            && Has("IronBoots")
            && (Has("CitSBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatArgorok();
    }

    public bool CanAccessPoT()
    {
        return CanAccessMirrorChamber()
            && ((SettingsStatus["PoTVanilla"] && Has("Boss7"))
                || (SettingsStatus["PoTFusedShadows"] && Has("FusedShadow", 3))
                || (SettingsStatus["PoTMirrorShards"] && Has("MirrorShard", 3))
                || SettingsStatus["PoTOpen"]);
    }

    public bool CanCompletePoT()
    {
        return CanAccessPoT()
            && Has("Sword", 4)
            && Has("ShadowCrystal")
            && (Has("PoTSmallKey", 7) || SettingsStatus["SmallKeysKeysy"])
            && (Has("PoTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatZant();
    }

    public bool CanAccessHC()
    {
        return CanAccessCastleTown()
            && CanCompleteMDH()
            && ((SettingsStatus["HCVanilla"] && Has("Boss8"))
                || (SettingsStatus["HCFusedShadows"] && Has("FusedShadow", 3))
                || (SettingsStatus["HCMirrorShards"] && Has("MirrorShard", 3))
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
        return Has("Boss1")
            && Has("Boss2")
            && Has("Boss3")
            && Has("Boss4")
            && Has("Boss5")
            && Has("Boss6")
            && Has("Boss7")
            && Has("Boss8");
    }

/* ------------------------------

            Enemies

------------------------------ */

    public bool CanDefeatAeralfos()
    {
        return Has("Clawshot") && (Has("Sword") || Has("B&C") || Has("ShadowCrystal"));
    }

    public bool CanDefeatArmos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Clawshot")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatBabaSerpent()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatBabyGohma()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Clawshot")
            || Has("Slingshot")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatBari()
    {
        return CanUseWBombs() || Has("Clawshot");
    }

    public bool CanDefeatBeamos()
    {
        return Has("B&C") || Has("Bow") || Has("Bombs");
    }

    public bool CanDefeatBigBaba()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatChu()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Clawshot")
            || Has("Spinner");
    }

    public bool CanDefeatBokoblin()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatBokoblinRed()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatBombfish()
    {
        return Has("IronBoots")
            && (Has("Sword") || Has("Clawshot")
                || (Has("Shield") && Has("HiddenSkill", 2)));
    }

    public bool CanDefeatBombling()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || Has("Clawshot")
            || Has("Spinner");
    }

    public bool CanDefeatBomskit()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow")
            || Has("Spinner");
    }

    public bool CanDefeatBulblin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatChilfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatChuWorm()
    {
        return (Has("Sword")
            || Has("Bow")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Spinner"))
                && (Has("Bombs") || Has("Clawshot"));
    }

    public bool CanDefeatDarknut()
    {
        return Has("Sword");
    }

    public bool CanDefeatDekuBaba()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Spinner")
            || (Has("HiddenSkill", 2)) // no shield??
            || Has("Slingshot")
            || Has("Clawshot")
            || Has("Bombs");
    }

    public bool CanDefeatDekuLike()
    {
        return Has("Bombs");
    }

    public bool CanDefeatDodongo()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatDinalfos()
    {
        return Has("Sword") || Has("B&C") || Has("ShadowCrystal");
    }

    public bool CanDefeatFireBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool CanDefeatFireKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Spinner");
    }

    public bool CanDefeatFireToadpoli()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (Has("HiddenSkill", 2) && Has("Shield"));
    }

    public bool CanDefeatFreezard()
    {
        return Has("B&C");
    }

    public bool CanDefeatGoron()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (Has("HiddenSkill", 2) && Has("Shield"))
            || Has("Slingshot")
            || Has("Clawshot")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatGhoulRat()
    {
        return Has("ShadowCrystal");
    }

    public bool CanDefeatGuay()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot");
    }

    public bool CanDefeatHelmasaur()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatHelmasaurus()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatIceBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool CanDefeatIceKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Spinner");
    }

    public bool CanDefeatPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool CanDefeatKargorok()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool CanDefeatKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Spinner"); // was this supposed to be clawshot?
    }

    public bool CanDefeatLeever()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatLizalfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatMiniFreezard()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatMoldorm()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatPoisonMite()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Lantern")
            || Has("Spinner");
    }

    public bool CanDefeatPuppet()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner");
    }

    public bool CanDefeatRat()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs")
            || Has("Spinner")
            || Has("Slingshot");
    }

    public bool CanDefeatRedeadKnight()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatShadowBeast()
    {
        return Has("Sword") || (Has("ShadowCrystal") && CanCompleteMDH());
    }

    public bool CanDefeatShadowBulblin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatShadowDekuBaba()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Bombs")
            || Has("Spinner")
            || Has("Slingshot")
            || Has("Clawshot")
            || Has("HiddenSkill", 2); // shield??
    }

    public bool CanDefeatShadowInsect()
    {
        return Has("ShadowCrystal");
    }

    public bool CanDefeatShadowKargorok()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatShadowKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Slingshot");
    }

    public bool CanDefeatShadowVermin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatShellBlade()
    {
        return (Has("WaterBombs") || (Has("Bombs") && SettingsStatus["IgnoreWaterBombLogic"]))
            || (Has("Sword") && Has("IronBoots"));
    }

    public bool CanDefeatSkullfish()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool CanDefeatSkulltula()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatStalfos()
    {
        return CanSmash();
    }

    public bool CanDefeatStalhound()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatStalchild()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatTektite()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatTileWorm()
    {
        return (Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs"))
                && Has("Boomerang");
    }

    public bool CanDefeatToado()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool CanDefeatWaterToadpoli()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (Has("HiddenSkill", 2) && Has("Shield"));
    }

    public bool CanDefeatTorchSlug()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatWalltula()
    {
        return Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("Slingshot")
            || Has("Boomerang")
            || Has("Clawshot");
    }

    public bool CanDefeatWhiteWolfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatYoungGohma()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Bombs");
    }

    public bool CanDefeatZantHead()
    {
        return Has("Sword") || Has("ShadowCrystal");
    }

    public bool CanDefeatOok()
    {
        return Has("Sword")
            || (Has("Bow") && CanGetArrows())
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatDangoro()
    {
        return Has("IronBoots")
            && (Has("Sword") || Has("ShadowCrystal") || CanBombArrow());
    }

    public bool CanDefeatCarrierKargorok()
    {
        return Has("ShadowCrystal");
    }

    public bool CanDefeatTwilitBloat()
    {
        return Has("ShadowCrystal");
    }

    public bool CanDefeatDekuToad()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatSkullKid()
    {
        return Has("Bow");
    }

    public bool CanDefeatKingBulblinBridge()
    {
        return Has("Bow");
    }

    public bool CanDefeatKingBulblinDesert()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow", 3)
            || Has("ShadowCrystal");
    }

    public bool CanDefeatKingBulblinCastle()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow", 3)
            || Has("ShadowCrystal");
    }

    public bool CanDefeatDeathSword()
    {
        return Has("ShadowCrystal")
            && Has("Sword")
            && (Has("Boomerang") || Has("Bow") || Has("Clawshot"));
    }

    public bool CanDefeatDarkhammer()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Bombs");
    }

    public bool CanDefeatPhantomZant()
    {
        return Has("Sword") || Has("ShadowCrystal");
    }

    public bool CanDefeatDiababa()
    {
        return CanLaunchBombs()
            || (Has("Boomerang")
                && (Has("Sword")
                    || Has("B&C")
                    || Has("ShadowCrystal")
                    || Has("Bombs")));
    }

    public bool CanDefeatFyrus()
    {
        return Has("Bow") || Has("IronBoots") || Has("Sword");
    }

    public bool CanDefeatMorpheel()
    {
        return Has("ZoraArmor") && Has("IronBoots") && Has("Sword") && Has("Clawshot");
    }

    public bool CanDefeatStallord()
    {
        return Has("Spinner") && Has("Sword");
    }

    public bool CanDefeatBlizzeta()
    {
        return Has("B&C");
    }

    public bool CanDefeatArmogohma()
    {
        return Has("Bow") && Has("DominionRod");
    }

    public bool CanDefeatArgorok()
    {
        return Has("Clawshot", 2) && Has("Sword", 2) && Has("IronBoots");
    }

    public bool CanDefeatZant()
    {
        return Has("Sword", 3)
            && Has("Boomerang")
            && Has("Clawshot")
            && Has("B&C")
            && Has("IronBoots")
            && Has("ZoraArmor");
    }

    public bool CanDefeatGanondorf()
    {
        return Has("Sword", 3) && Has("ShadowCrystal") && Has("HiddenSkill");
    }

/* ------------------------------

        Overworld Checks 

------------------------------ */

    // Ordon Province
   
    public bool OrdonRanchGrottoLanternChest()
    {
        return CanCompletePrologue() && Has("ShadowCrystal") && Has("Lantern");
    }

    public bool HerdingGoatsReward()
    {
        return CanCompletePrologue();
    }

    public bool OrdonSpringGoldenWolf()
    {
        return Has("ShadowCrystal") && CanAccessKakariko();
    }

    // Faron Woods

    public bool CoroBottle()
    {
        return CanCompletePrologue();
    }

    public bool FaronMistCaveLanternChest()
    {
        return ((Has("Sword") && Has("Slingshot")) || SettingsStatus["SkipPrologue"])
            && (CanBurnWebs() || Has("ShadowCrystal") || SettingsStatus["SkipPrologue"])
            && Has("Lantern");
    }

    public bool FaronMistCaveOpenChest()
    {
        return ((Has("Sword") && Has("Slingshot")) || SettingsStatus["SkipPrologue"])
            && (CanBurnWebs() || Has("ShadowCrystal") || SettingsStatus["SkipPrologue"]);
    }

    public bool FaronMistNorthChest()
    {
        return CanCompletePrologue()
            && Has("Lantern");
    }

    public bool FaronMistSouthChest()
    {
        return CanCompletePrologue()
            && Has("Lantern");
    }

    public bool FaronMistStumpChest()
    {
        return CanCompletePrologue()
            && Has("Lantern");
    }

    public bool FaronWoodsGoldenWolf()
    {
        return CanAccessNorthFaron();
    }

    public bool FaronWoodsOwlStatueChest()
    {
        return CanSmash()
            && Has("DominionRod", 2)
            && CanClearForest()
            && Has("ShadowCrystal");
    }

    public bool FaronWoodsOwlStatueSkyCharacter()
    {
        return CanSmash()
            && Has("DominionRod", 2)
            && CanClearForest();
    }

    public bool NorthFaronWoodsDekuBabaChest()
    {
        return CanAccessNorthFaron();
    }

    public bool SouthFaronCaveChest()
    {
        return CanCompletePrologue();
    }

    // Lost Woods/Sacred Grove

    public bool LostWoodsLanternChest()
    {
        return CanAccessLostWoods() && Has("Lantern");
    }

    public bool SacredGroveBabaSerpentGrottoChest()
    {
        return CanAccessSacredGrove()
            && CanSmash()
            && CanDefeatBabaSerpent()
            && CanKnockDownHangingBaba();
    }

    public bool SacredGrovePastOwlStatueChest()
    {
        return CanAccessSacredGrove()
            && ((CanDefeatShadowBeast() && Has("Sword", 3))
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"])
            && Has("DominionRod");
    }

    public bool SacredGroveSpinnerChest()
    {
        return CanAccessSacredGrove() && Has("Spinner");
    }

    // Faron Field

    public bool FaronFieldBridgeChest()
    {
        return CanClearForest()
            && Has("Clawshot");
    }

    public bool FaronFieldCornerGrottoLeftChest()
    {
        return CanClearForest()
            && Has("ShadowCrystal");
    }

    public bool FaronFieldCornerGrottoRearChest()
    {
        return CanClearForest()
            && Has("ShadowCrystal");
    }

    public bool FaronFieldCornerGrottoRightChest()
    {
        return CanClearForest()
            && Has("ShadowCrystal");
    }

    public bool FaronFieldTreeHeartPiece()
    {
        return CanClearForest()
            && (Has("Boomerang") || Has("Clawshot"));
    }

    // Kakariko Gorge

    public bool KakarikoGorgeDoubleClawshotChest()
    {
        return CanAccessKakariko() && Has("Clawshot", 2);
    }

    public bool KakarikoGorgeOwlStatueChest()
    {
        return CanAccessKakariko() && Has("DominionRod", 2);
    }

    public bool KakarikoGorgeOwlStatueSkyCharacter()
    {
        return CanAccessKakariko() && Has("DominionRod", 2);
    }

    public bool KakarikoGorgeSpireHeartPiece()
    {
        return CanAccessKakariko()
            && (Has("Boomerang") || Has("Clawshot"));
    }

    // Death Mountain

    public bool DeathMountainAlcoveChest()
    {
        return CanAccessKakariko()
            && (Has("Boss2") 
                || (Has("Clawshot") 
                    && (Has("IronBoots") || Has("ShadowCrystal"))));
    }

    // Eldin Field

    public bool BridgeofEldinOwlStatueChest()
    {
        return CanAccessEldinField() && Has("DominionRod", 2);
    }

    public bool BridgeofEldinOwlStatueSkyCharacter()
    {
        return CanAccessEldinField() && Has("DominionRod", 2);
    }

    public bool EldinFieldBombRockChest()
    {
        return CanAccessEldinField() && CanSmash();
    }

    public bool EldinFieldBomskitGrottoLanternChest()
    {
        return CanAccessEldinField()
            && Has("ShadowCrystal")
            && Has("Lantern");
    }

    public bool EldinFieldBomskitGrottoLeftChest()
    {
        return CanAccessEldinField()
            && Has("ShadowCrystal");
    }

    public bool EldinFieldStalfosGrottoLeftSmallChest()
    {
        return CanAccessEldinField()
            && Has("Spinner")
            && Has("ShadowCrystal")
            && (CanSmash() 
                || ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                    && (LanayruTwilightCleared() || Has("ShadowCrystal"))));
    }

    public bool EldinFieldStalfosGrottoRightSmallChest()
    {
        return CanAccessEldinField()
            && Has("Spinner")
            && Has("ShadowCrystal")
            && (CanSmash() 
                || ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                    && (LanayruTwilightCleared() || Has("ShadowCrystal"))));
    }

    public bool EldinFieldStalfosGrottoStalfosChest()
    {
        return CanAccessEldinField()
            && Has("Spinner")
            && Has("ShadowCrystal")
            && CanDefeatStalfos()
            && (CanSmash() 
                || ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                    && (LanayruTwilightCleared() || Has("ShadowCrystal"))));
    }

    public bool EldinFieldWaterBombFishGrottoChest()
    {
        return CanAccessEldinField() && Has("ShadowCrystal");
    }

    public bool GoronSpringwaterRush()
    {
        return CanAccessEldinField()
            && (CanSmash() 
                || ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                    && (LanayruTwilightCleared() || Has("ShadowCrystal"))));
    }

    // Lanayru Field

    public bool LanayruFieldBehindGateUnderwaterChest()
    {
        return CanAccessLanayru() && Has("IronBoots");
    }

    public bool LanayruFieldSkulltulaGrottoChest()
    {
        return CanAccessLanayru()
            && Has("ShadowCrystal")
            && Has("Lantern");
    }

    public bool LanayruFieldSpinnerTrackChest()
    {
        return CanAccessLanayru()
            && CanSmash()
            && Has("Spinner");
    }

    public bool LanayruIceBlockPuzzleCaveChest()
    {
        return CanAccessLanayru() && Has("B&C");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterOwlStatueChest()
    {
        return CanAccessLanayru() && Has("DominionRod", 2);
    }

    public bool HyruleFieldAmphitheaterOwlStatueSkyCharacter()
    {
        return CanAccessLanayru() && Has("DominionRod", 2);
    }

    public bool WestHyruleFieldGoldenWolf()
    {
        return CanAccessLanayru()
            && Has("ShadowCrystal");
    }

    public bool WestHyruleFieldHelmasaurGrottoChest()
    {
        return CanAccessLanayru()
            && Has("Clawshot")
            && Has("ShadowCrystal");
    }

    // North Castle Town

    public bool NorthCastleTownGoldenWolf()
    {
        return CanAccessCastleTown()
            && Has("FetchQuest", 3)
            && Has("ShadowCrystal")
            && CanCompleteMDH();
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownDoubleClawshotChasmChest()
    {
        return CanAccessCastleTown() && Has("Clawshot", 2);
    }

    public bool OutsideSouthCastleTownFountainChest()
    {
        return CanAccessCastleTown()
            && Has("Clawshot")
            && Has("Spinner");
    }

    public bool OutsideSouthCastleTownGoldenWolf()
    {
        return CanAccessCastleTown()
            && CanAccessNorthFaron()
            && Has("ShadowCrystal");
    }

    public bool OutsideSouthCastleTownTektiteGrottoChest()
    {
        return CanAccessCastleTown() && Has("ShadowCrystal");
    }

    public bool OutsideSouthCastleTownTightropeChest()
    {
        return CanAccessCastleTown()
            && Has("ShadowCrystal")
            && Has("Clawshot");
    }

    public bool WoodenStatue()
    {
        return CanAccessCastleTown()
            && Has("FetchQuest", 2)
            && (Has("MedicineScent") || SettingsStatus["IgnoreScentLogic"]);
    }

    // Lake Hylia

    public bool AuruGiftToFyer()
    {
        return CanAccessLakeHylia();
    }

    public bool LakeHyliaShellBladeGrottoChest()
    {
        return CanAccessLakeHylia()
            && Has("ShadowCrystal")
            && CanDefeatShellBlade();
    }

    public bool LakeHyliaUnderwaterChest()
    {
        return CanAccessLakeHylia() && Has("IronBoots");
    }

    public bool LakeHyliaWaterToadpoliGrottoChest()
    {
        return CanAccessLakeHylia()
            && Has("ShadowCrystal")
            && CanDefeatWaterToadpoli();
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
        return CanAccessZorasDomain() && Has("ShadowCrystal");
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
            && Has("Clawshot")
            && Has("ShadowCrystal");
    }

    public bool LakeHyliaBridgeCliffChest()
    {
        return CanAccessLanayru()
            && CanLaunchBombs()
            && Has("Clawshot");
    }

    public bool LakeHyliaBridgeOwlStatueChest()
    {
        return CanAccessLanayru()
            && Has("Clawshot")
            && Has("DominionRod", 2);
    }

    public bool LakeHyliaBridgeOwlStatueSkyCharacter()
    {
        return CanAccessLanayru()
            && Has("Clawshot")
            && Has("DominionRod", 2);
    }

    public bool LakeHyliaBridgeVinesChest()
    {
        return CanAccessLanayru() && Has("Clawshot");
    }

    // Upper Zora's River

    public bool FishingHoleBottle()
    {
        return CanAccessZorasDomain() && Has("FishingRod");
    }

    public bool FishingHoleHeartPiece()
    {
        return CanAccessZorasDomain();
    }

    public bool IzaHelpingHand()
    {
        return CanAccessZorasDomain()
            && CanAccessLakeHylia()
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    public bool IzaRagingRapidsMinigame()
    {
        return CanAccessZorasDomain()
            && CanAccessLakeHylia()
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    // Zora's Domain

    public bool ZorasDomainChestBehindWaterfall()
    {
        return CanAccessZorasDomain() && Has("ShadowCrystal");
    }

    public bool ZorasDomainChestByMotherandChildIsles()
    {
        return CanAccessZorasDomain();
    }

    public bool ZorasDomainExtinguishAllTorchesChest()
    {
        return CanAccessZorasDomain() && Has("Boomerang") && Has("IronBoots");
    }

    public bool ZorasDomainLightAllTorchesChest()
    {
        return CanAccessZorasDomain() && Has("Lantern") && Has("IronBoots");
    }

    public bool ZorasDomainUnderwaterGoron()
    {
        return CanAccessZorasDomain()
            && Has("IronBoots")
            && Has("ZoraArmor")
            && CanUseWBombs();
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
            && Has("ShadowCrystal")
            && CanAccessLakeHylia();
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
        return CanAccessDesert() && Has("DominionRod", 2);
    }

    public bool GerudoDesertOwlStatueSkyCharacter()
    {
        return CanAccessDesert() && Has("DominionRod", 2);
    }

    public bool GerudoDesertPeahatLedgeChest()
    {
        return CanAccessDesert() && Has("Clawshot");
    }

    public bool GerudoDesertRockGrottoLanternChest()
    {
        return CanAccessDesert()
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanSmash()
            && Has("Lantern");
    }

    public bool GerudoDesertSouthChestBehindWoodenGates()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool GerudoDesertSkulltulaGrottoChest()
    {
        return CanAccessDesert() && Has("ShadowCrystal");
    }

    public bool GerudoDesertWestCanyonChest()
    {
        return CanAccessDesert() && Has("Clawshot");
    }

    // Snowpeak

    public bool AsheiSketch()
    {
        return CanAccessSnowpeakClimb();
    }

    public bool SnowboardRacingPrize()
    {
        return CanAccessSnowpeakSummit()
            && Has("Boss5");
    }

    public bool SnowpeakCaveIceLanternChest()
    {
        return CanAccessSnowpeakSummit() && Has("B&C") && Has("Lantern");
    }

    public bool SnowpeakFreezardGrottoChest()
    {
        return CanAccessSnowpeakClimb() 
            && Has("B&C")
            && (SettingsStatus["EarlySnowpeak"]
                || (Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))));
    }

    // Hidden Village

    public bool CatsHideandSeekMinigame()
    {
        return CanAccessLanayru()
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && Has("FetchQuest", 4)
            && Has("Bow")
            && Has("DominionRod");
    }

    public bool IliaCharm()
    {
        return CanAccessLanayru()
            && Has("FetchQuest", 3)
            && Has("Bow");
    }

    public bool SkybookFromImpaz()
    {
        return CanAccessLanayru()
            && Has("FetchQuest", 3)
            && Has("Bow")
            && Has("DominionRod");
    }

/* ------------------------------

        Overworld Poes 

------------------------------ */

    // Faron Province

    public bool FaronMistPoe()
    {
        return CanCompletePrologue() && Has("ShadowCrystal");
    }

    // Lost Woods

    public bool LostWoodsWaterfallPoe()
    {
        return CanAccessLostWoods();
    }

    public bool LostWoodsBoulderPoe()
    {
        return CanAccessSacredGrove() && CanSmash();
    }

    // Sacred Grove

    public bool SacredGroveMasterSwordPoe()
    {
        return CanAccessSacredGrove();
    }

    public bool SacredGroveTempleofTimeOwlStatuePoe()
    {
        return CanAccessSacredGrove()
            && ((CanDefeatShadowBeast() && Has("Sword", 3))
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"])
            && Has("DominionRod");
    }

    // Faron Field

    public bool FaronFieldPoe()
    {
        return CanClearForest()
            && CanCompleteMDH()
            && Has("ShadowCrystal");
    }

    // Kakariko Gorge

    public bool KakarikoGorgePoe()
    {
        return CanAccessKakariko()
            && CanCompleteMDH()
            && Has("ShadowCrystal");
    }

    // Death Mountain

    public bool DeathMountainTrailPoe()
    {
        return Has("Boss2")
            && Has("ShadowCrystal");
    }

    // Lanayru Field

    public bool LanayruFieldBridgePoe()
    {
        return CanAccessLanayru()
            && CanCompleteMDH()
            && Has("ShadowCrystal");
    }

    public bool LanayruFieldPoeGrottoLeftPoe()
    {
        return CanAccessLanayru() && Has("ShadowCrystal");
    }

    public bool LanayruFieldPoeGrottoRightPoe()
    {
        return CanAccessLanayru() && Has("ShadowCrystal");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterPoe()
    {
        return CanAccessLanayru()
            && Has("ShadowCrystal");
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownPoe()
    {
        return CanAccessCastleTown()
            && Has("ShadowCrystal");
    }

    // Outside East Castle Town

    public bool EastCastleTownBridgePoe()
    {
        return CanAccessCastleTown()
            && Has("ShadowCrystal");
    }

    // Lake Hylia

    public bool LakeHyliaAlcovePoe()
    {
        return CanAccessLakeHylia() && Has("ShadowCrystal");
    }

    public bool LakeHyliaTowerPoe()
    {
        return CanAccessLakeHylia() && Has("ShadowCrystal");
    }

    public bool LakeHyliaDockPoe()
    {
        return CanAccessLakeHylia() && Has("ShadowCrystal");
    }

    public bool FlightByFowlLedgePoe()
    {
        return CanAccessLakeHylia() && Has("ShadowCrystal");
    }

    public bool IsleofRichesPoe()
    {
        return CanAccessLakeHylia() && Has("ShadowCrystal");
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeCliffPoe()
    {
        return CanAccessLanayru()
            && Has("ShadowCrystal")
            && CanLaunchBombs()
            && Has("Clawshot")
            && CanCompleteMDH();
    }

    // Upper Zora's River

    public bool UpperZorasRiverPoe()
    {
        return CanAccessZorasDomain()
            && Has("ShadowCrystal");
    }

    // Zora's Domain

    public bool ZorasDomainWaterfallPoe()
    {
        return CanAccessZorasDomain()
            && Has("ShadowCrystal");
    }

    public bool ZorasDomainMotherandChildIslePoe()
    {
        return CanAccessZorasDomain()
            && Has("ShadowCrystal");
    }

    // Gerudo Desert

    public bool GerudoDesertNorthPeahatPoe()
    {
        return CanAccessDesert()
            && Has("Clawshot")
            && Has("ShadowCrystal");
    }

    public bool GerudoDesertEastPoe()
    {
        return CanAccessDesert() && Has("ShadowCrystal");
    }

    public bool GerudoDesertPoeAboveCaveofOrdeals()
    {
        return CanAccessDesert()
            && Has("Clawshot")
            && Has("ShadowCrystal");
    }

    public bool GerudoDesertRockGrottoFirstPoe()
    {
        return CanAccessDesert()
            && Has("Clawshot")
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool GerudoDesertRockGrottoSecondPoe()
    {
        return CanAccessDesert()
            && Has("Clawshot")
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool OutsideBulblinCampPoe()
    {
        return CanAccessDesert() && Has("ShadowCrystal");
    }

    // Snowpeak

    public bool SnowpeakAboveFreezardGrottoPoe()
    {
        return CanAccessSnowpeakClimb()
            && Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || (Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))));
    }

    public bool SnowpeakBlizzardPoe()
    {
        return CanAccessSnowpeakClimb()
            && Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || (Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))));
    }

    public bool SnowpeakPoeAmongTrees()
    {
        return CanAccessSnowpeakSummit()
            && Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || (Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))));
    }

    public bool SnowpeakCaveIcePoe()
    {
        return CanAccessSnowpeakSummit()
            && Has("B&C")
            && Has("ShadowCrystal");
    }

    public bool SnowpeakIcySummitPoe()
    {
        return CanAccessSnowpeakSummit()
            && Has("ShadowCrystal")
            && (!SettingsStatus["BonksDoDamage"]
            || (SettingsStatus["BonksDoDamage"]
                && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairy())));;
    }

    // Hidden Village

    public bool HiddenVillagePoe()
    {
        return Has("FetchQuest", 4)
            && Has("Clawshot")
            && Has("Bow")
            && Has("DominionRod")
            && Has("ShadowCrystal");
    }

/* ------------------------------

            Bugs 

------------------------------ */

    public bool FaronFieldFemaleBeetle()
    {
        return CanClearForest() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool FaronFieldMaleBeetle()
    {
        return CanClearForest();
    }

    public bool KakarikoGorgeFemalePillBug()
    {
        return CanAccessKakariko();
    }

    public bool KakarikoGorgeMalePillBug()
    {
        return CanAccessKakariko();
    }

    public bool KakarikoVillageFemaleAnt()
    {
        return CanAccessKakariko();
    }

    public bool KakarikoGraveyardMaleAnt()
    {
        return CanAccessKakariko();
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
        return CanAccessEldinField() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool BridgeofEldinMalePhasmid()
    {
        return CanAccessEldinField() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool LakeHyliaBridgeFemaleMantis()
    {
        return CanAccessLanayru() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool LakeHyliaBridgeMaleMantis()
    {
        return CanAccessLanayru() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool LanayruFieldFemaleStagBeetle()
    {
        return CanAccessLanayru() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool LanayruFieldMaleStagBeetle()
    {
        return CanAccessLanayru() && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool WestHyruleFieldFemaleButterfly()
    {
        return CanAccessLanayru() && (Has("Boomerang") || Has("Clawshot"));
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
        return CanAccessSacredGrove()
            && (Has("Boomerang") || Has("Clawshot"));
    }

    public bool SacredGroveFemaleSnail()
    {
        return CanAccessSacredGrove()
            && ((CanDefeatShadowBeast() && Has("Sword", 3))
                || SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"])
            && (Has("Clawshot") || Has("Boomerang"));
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
        return true;
    }

    public bool LinksBasementChest()
    {
        return Has("Lantern");
    }

    public bool UliCradleDelivery()
    {
        return true;
    }

    public bool OrdonCatRescue()
    {
        return Has("FishingRod");
    }

    public bool SeraShopSlingshot()
    {
        return true;
    }

    public bool OrdonShield()
    {
        return (CanCompletePrologue() && !FaronTwilightCleared())
        || (FaronTwilightCleared() && Has("ShadowCrystal"))
        && (!SettingsStatus["BonksDoDamage"]
            || (SettingsStatus["BonksDoDamage"]
                && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairies())));
    }

    public bool OrdonSword()
    {
        return CanCompletePrologue() || FaronTwilightCleared();
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
        return CanAccessKakariko();
    }

    public bool BarnesBombBag()
    {
        return CanAccessKakariko();
    }

    public bool EldinSpringUnderwaterChest()
    {
        return CanAccessKakariko() && CanSmash() && Has("IronBoots");
    }

    public bool KakarikoVillageBombRockSpireHeartPiece()
    {
        return CanAccessKakariko()
            && CanLaunchBombs()
            && Has("Boomerang");
    }

    public bool KakarikoGraveyardLanternChest()
    {
        return CanAccessKakariko() && Has("Lantern");
    }

    public bool KakarikoWatchtowerChest()
    {
        return CanAccessKakariko();
    }

    public bool KakarikoWatchtowerAlcoveChest()
    {
        return CanAccessKakariko() && CanSmash();
    }

    public bool TaloSharpshooting()
    {
        return CanAccessKakariko() && Has("Bow") && Has("Boss2");
    }

    public bool KakarikoVillageMaloMartHylianShield()
    {
        return CanAccessKakariko();
    }

    public bool KakarikoVillageMaloMartHawkeye()
    {
        return CanAccessKakariko() && Has("Bow") && Has("Boss2");
    }

    public bool RutelasBlessing()
    {
        return CanAccessKakariko() && (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GiftFromRalis()
    {
        return CanAccessKakariko() 
            && (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
            && Has("AsheisSketch");
    }

    public bool KakarikoGraveyardGoldenWolf()
    {
        return CanAccessKakariko() && Has("ShadowCrystal")
            && CanAccessSnowpeakClimb()
            && ((Has("ReekfishScent") || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2)))
                || SettingsStatus["EarlySnowpeak"]);
    }

    public bool RenadosLetter()
    {
        return CanAccessKakariko() && Has("Boss6");
    }

    public bool IliaMemoryReward()
    {
        return CanAccessKakariko() && Has("FetchQuest", 4);
    }

    // Poes

    public bool KakarikoVillageBombShopPoe()
    {
        return CanAccessKakariko() && Has("ShadowCrystal");
    }

    public bool KakarikoVillageWatchtowerPoe()
    {
        return CanAccessKakariko() && Has("ShadowCrystal");
    }

    public bool KakarikoGraveyardOpenPoe()
    {
        return CanAccessKakariko() && Has("ShadowCrystal");
    }

    public bool KakarikoGraveyardGravePoe()
    {
        return CanAccessKakariko() && Has("ShadowCrystal");
    }

/* ------------------------------

        Eldin Lantern Cave

------------------------------ */

    public bool EldinLanternCaveFirstChest()
    {
        return CanAccessKakariko() && CanSmash() && CanBurnWebs();
    }

    public bool EldinLanternCaveSecondChest()
    {
        return CanAccessKakariko() && CanSmash() && CanBurnWebs();
    }

    public bool EldinLanternCaveLanternChest()
    {
        return CanAccessKakariko()
            && CanSmash()
            && Has("Lantern");
    }

    // Poes

    public bool EldinLanternCavePoe()
    {
        return CanAccessKakariko() && CanSmash() && CanBurnWebs() && Has("ShadowCrystal");
    }

/* ------------------------------

        Eldin Stockcave

------------------------------ */

    public bool EldinStockcaveUpperChest()
    {
        return CanAccessEldinField() && Has("Clawshot") && Has("IronBoots");
    }

    public bool EldinStockcaveLanternChest()
    {
        return CanAccessEldinField()
            && Has("Clawshot")
            && Has("IronBoots")
            && Has("Lantern");
    }

    public bool EldinStockcaveLowestChest()
    {
        return CanAccessEldinField() && Has("Clawshot") && Has("IronBoots");
    }

/* ------------------------------

        Lake Lantern Cave

------------------------------ */

    public bool LakeLanternCaveFirstChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveSecondChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveThirdChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveFourthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveFifthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveSixthChest()
    {
        return CanAccessLakeHylia()
            && Has("Lantern")
            && CanSmash();
    }

    public bool LakeLanternCaveSeventhChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveEighthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveNinthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveTenthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveEleventhChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveTwelfthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveThirteenthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveFourteenthChest()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash();
    }

    public bool LakeLanternCaveEndLanternChest()
    {
        return CanAccessLakeHylia()
            && Has("Lantern")
            && CanSmash();
    }

    // Poes

    public bool LakeLanternCaveFirstPoe()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveSecondPoe()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveFinalPoe()
    {
        return CanAccessLakeHylia()
            && (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

/* ------------------------------

        Lanayru Spring

------------------------------ */

    public bool LanayruSpringUnderwaterLeftChest()
    {
        return CanAccessLakeHylia() && Has("IronBoots");
    }

    public bool LanayruSpringUnderwaterRightChest()
    {
        return CanAccessLakeHylia() && Has("IronBoots");
    }

    public bool LanayruSpringBackRoomLeftChest()
    {
        return CanAccessLakeHylia() && Has("Clawshot");
    }

    public bool LanayruSpringBackRoomRightChest()
    {
        return CanAccessLakeHylia() && Has("Clawshot");
    }

    public bool LanayruSpringBackRoomLanternChest()
    {
        return CanAccessLakeHylia() && Has("Clawshot") && Has("Lantern");
    }

    public bool LanayruSpringWestDoubleClawshotChest()
    {
        return CanAccessLakeHylia() && Has("Clawshot", 2);
    }

    public bool LanayruSpringEastDoubleClawshotChest()
    {
        return CanAccessLakeHylia() && Has("Clawshot", 2);
    }

/* ------------------------------

        Castle Town

------------------------------ */

    public bool AgithaFemaleAntReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 1);
    }

    public bool AgithaFemaleBeetleReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 2);
    }

    public bool AgithaFemaleButterflyReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 3);
    }

    public bool AgithaFemaleDayflyReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 4);
    }

    public bool AgithaFemaleDragonflyReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 5);
    }

    public bool AgithaFemaleGrasshopperReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 6);
    }

    public bool AgithaFemaleLadybugReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 7);
    }

    public bool AgithaFemaleMantisReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 8);
    }

    public bool AgithaFemalePhasmidReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 9);
    }

    public bool AgithaFemalePillBugReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 10);
    }

    public bool AgithaFemaleSnailReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 11);
    }

    public bool AgithaFemaleStagBeetleReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 12);
    }

    public bool AgithaMaleAntReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 13);
    }

    public bool AgithaMaleBeetleReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 14);
    }

    public bool AgithaMaleButterflyReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 15);
    }

    public bool AgithaMaleDayflyReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 16);
    }

    public bool AgithaMaleDragonflyReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 17);
    }

    public bool AgithaMaleGrasshopperReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 18);
    }

    public bool AgithaMaleLadybugReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 19);
    }

    public bool AgithaMaleMantisReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 20);
    }

    public bool AgithaMalePhasmidReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 21);
    }

    public bool AgithaMalePillBugReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 22);
    }

    public bool AgithaMaleSnailReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 23);
    }

    public bool AgithaMaleStagBeetleReward()
    {
        return CanAccessCastleTown() && Has("GoldenBug", 24);
    }

    public bool CastleTownMaloMartMagicArmor()
    {
        return CanAccessCastleTown()
            && (Has("Wallet", 1)
                || SettingsStatus["WalletIncrease"]
                || SettingsStatus["IgnoreWalletLogic"]);
    }

    public bool CharloDonationBlessing()
    {
        return CanAccessCastleTown();
    }

    public bool STARPrize1()
    {
        return CanAccessCastleTown() && Has("Clawshot");
    }

    public bool STARPrize2()
    {
        return CanAccessCastleTown() && Has("Clawshot", 2);
    }

    public bool Jovani20PoeSoulReward()
    {
        return CanAccessCastleTown() 
            && Has("PoeSoul", 20)
            && Has("ShadowCrystal")
            && CanCompleteMDH();
    }

    public bool Jovani60PoeSoulReward()
    {
        return CanAccessCastleTown() 
            && Has("PoeSoul", 60)
            && Has("ShadowCrystal")
            && CanCompleteMDH();
    }

    public bool TelmaInvoice()
    {
        return CanAccessCastleTown() && Has("FetchQuest", 1);
    }

    public bool DoctorsOfficeBalconyChest()
    {
        return CanAccessCastleTown() && Has("ShadowCrystal") && Has("FetchQuest", 2);
    }

    // Poes

    public bool JovaniHousePoe()
    {
        return CanAccessCastleTown() && Has("ShadowCrystal");
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
        return CanAccessDesert() && CanDefeatBulblin() && HasDamagingItem();
    }

    public bool BulblinGuardKey()
    {
        return CanAccessDesert() && CanDefeatBulblin();
    }

    public bool OutsideArbitersGroundsLanternChest()
    {
        return CanAccessDesert()
            && CanDefeatBulblin()
            && Has("Lantern")
            && ((CanDefeatKingBulblinDesert() && (Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"]))
                || SettingsStatus["EarlyArbiters"]);
    }

    // Poes

    public bool BulblinCampPoe()
    {
        return CanAccessDesert()
            && Has("ShadowCrystal")
            && (Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"] || SettingsStatus["EarlyArbiters"]);
    }

    public bool OutsideArbitersGroundsPoe()
    {
        return CanAccessDesert()
            && Has("ShadowCrystal")
            && ((CanDefeatKingBulblinDesert() && (Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"]))
                || SettingsStatus["EarlyArbiters"]);
    }

/* ------------------------------

        Cave of Ordeals

------------------------------ */

    public bool CaveofOrdealsGreatFairyReward()
    {
        return CanAccessDesert()
            && Has("Spinner")
            && Has("ShadowCrystal")
            && Has("DominionRod", 2)
            && Has("Clawshot", 2)
            && Has("B&C")
            && CanDefeatDarknut();
    }

    // Poes

    public bool CaveofOrdealsFloor17Poe()
    {
        return CanAccessDesert() 
            && Has("Clawshot")
            && CanDefeatShadowBeast()
            && Has("Spinner") 
            && Has("ShadowCrystal");
    }

    public bool CaveofOrdealsFloor33Poe()
    {
        return CanAccessDesert()
            && Has("Clawshot")
            && CanDefeatShadowBeast()
            && Has("Spinner")
            && Has("ShadowCrystal")
            && Has("DominionRod", 2)
            && Has("B&C");
    }

    public bool CaveofOrdealsFloor44Poe()
    {
        return CanAccessDesert()
            && Has("Spinner")
            && Has("ShadowCrystal")
            && Has("DominionRod", 2)
            && Has("B&C")
            && Has("Clawshot", 2)
            && CanDefeatDarknut();
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
            && Has("Boomerang")
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
            && Has("Lantern");
    }

    public bool ForestTempleWindlessBridgeChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage();
    }

    public bool ForestTempleSecondMonkeyUnderBridgeChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool ForestTempleTotemPoleChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && CanBurnWebs() 
            && (Has("FTSmallKey", 2) 
                || SettingsStatus["SmallKeysKeysy"] 
                || Has("Clawshot"));
    }

    public bool ForestTempleWestTileWormRoomVinesChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && CanBurnWebs() 
            && (Has("FTSmallKey", 2) 
                || SettingsStatus["SmallKeysKeysy"] 
                || Has("Clawshot"));
    }

    public bool ForestTempleWestDekuLikeChest()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && CanBurnWebs() 
            && (Has("FTSmallKey", 2) 
                || SettingsStatus["SmallKeysKeysy"] 
                || Has("Clawshot"));
    }

    public bool ForestTempleBigBabaKey()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && CanBurnWebs() 
            && (Has("FTSmallKey", 2) 
                || SettingsStatus["SmallKeysKeysy"] 
                || Has("Clawshot"))
            && CanDefeatBigBaba();
    }

    public bool ForestTempleGaleBoomerang()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && ((CanBurnWebs() 
                && (Has("FTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"] || Has("Clawshot"))
                    && Has("Boomerang"))
                || (Has("Lantern") && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])))
            && CanDefeatOok();
    }

    public bool ForestTempleWestTileWormChestBehindStairs()
    {
        return CanAccessFT()
            && CanDefeatWalltula()
            && CanDefeatBokoblin()
            && CanBreakMonkeyCage()
            && CanBurnWebs() 
            && (Has("FTSmallKey", 2) 
                || SettingsStatus["SmallKeysKeysy"] 
                || Has("Clawshot"))
            && Has("Boomerang");
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
            && Has("Boomerang");
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
            && Has("Boomerang");
    }

    public bool ForestTempleEastTileWormChest()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && CanDefeatSkulltula()
            && CanDefeatTileWorm()
            && Has("Boomerang")
            && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool ForestTempleDiababaHeartContainer()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("Boomerang")
            && (Has("FTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatDiababa()
            && (CanFreeAllMonkeys() || Has("Clawshot"));
    }

    public bool ForestTempleDungeonReward()
    {
        return CanAccessFT()
            && CanDefeatBokoblin()
            && CanDefeatWalltula()
            && CanBreakMonkeyCage()
            && Has("Boomerang")
            && (Has("FTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatDiababa()
            && (CanFreeAllMonkeys() || Has("Clawshot"));
    }

/* ------------------------------

            Goron Mines 

------------------------------ */

    public bool GoronMinesEntranceChest()
    {
        return CanAccessGM()
            && CanPressMinesSwitch()
            && CanBreakWoodenDoor();
    }

    public bool GoronMinesMainMagnetRoomBottomChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor();
    }

    public bool GoronMinesGorAmatoChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesGorAmatoKeyShard()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesGorAmatoSmallChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesMagnetMazeChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesCrystalSwitchRoomUnderwaterChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesCrystalSwitchRoomSmallChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesAfterCrystalSwitchRoomMagnetWallChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool GoronMinesOutsideBeamosChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Bow") || Has("Sword"));
    }

    public bool GoronMinesGorEbizoKeyShard()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Bow") || Has("Sword"));
    }

    public bool GoronMinesGorEbizoChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Bow") || Has("Sword"));
    }

    public bool GoronMinesChestBeforeDangoro()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Bow") || Has("Sword"));
    }

    public bool GoronMinesDangoroChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Bow") || Has("Sword"))
            && CanDefeatDangoro();
    }

    public bool GoronMinesBeamosRoomChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatDangoro()
            && Has("Bow");
    }

    public bool GoronMinesGorLiggsKeyShard()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatDangoro()
            && Has("Bow");
    }

    public bool GoronMinesGorLiggsChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatDangoro()
            && Has("Bow");
    }

    public bool GoronMinesMainMagnetRoomTopChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatDangoro()
            && Has("Bow");
    }

    public bool GoronMinesOutsideClawshotChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Bow") || Has("Sword"))
            && (Has("Clawshot") && (Has("Bow") || Has("Slingshot")));
    }

    public bool GoronMinesOutsideUnderwaterChest()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && ((Has("Bow")
                    && (Has("WaterBombs")
                        || (SettingsStatus["IgnoreWaterBombLogic"] && Has("Bombs"))))
                || Has("Sword"));
    }

    public bool GoronMinesFyrusHeartContainer()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("GMBigKey", 3) || SettingsStatus["BigKeysKeysy"])
            && CanDefeatBulblin()
            && Has("Bow")
            && CanDefeatFyrus();
    }

    public bool GoronMinesDungeonReward()
    {
        return CanAccessGM()
            && Has("IronBoots")
            && CanBreakWoodenDoor()
            && (Has("GMSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("GMBigKey", 3) || SettingsStatus["BigKeysKeysy"])
            && CanDefeatBulblin()
            && Has("Bow")
            && CanDefeatFyrus();
    }

/* ------------------------------

        Lakebed Temple 

------------------------------ */

    public bool LakebedTempleLobbyLeftChest()
    {
        return CanAccessLT() && Has("ZoraArmor");
    }

    public bool LakebedTempleLobbyRearChest()
    {
        return CanAccessLT() && Has("ZoraArmor");
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
            && (Has("LTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool LakebedTempleEastSecondFloorSoutheastChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool LakebedTempleEastWaterSupplySmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots");
    }

    public bool LakebedTempleBeforeDekuToadAlcoveChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (CanDefeatDekuToad() 
                && (Has("LTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
                && Has("ZoraArmor") 
                && Has("IronBoots") 
                && CanUseWBombs() 
                && Has("Clawshot")) 
            || ((Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]) 
                && (CanLaunchBombs() || (Has("Clawshot") && CanSmash())));
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterLeftChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots");
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterRightChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots");
    }

    public bool LakebedTempleDekuToadChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && CanDefeatDekuToad()
            && CanUseWBombs();
    }

    public bool LakebedTempleChandelierChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && Has("Clawshot");
    }

    public bool LakebedTempleCentralRoomSpireChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots");
    }

    public bool LakebedTempleEastWaterSupplyClawshotChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && Has("Clawshot");
    }

    public bool LakebedTempleWestLowerSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplySmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplyChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorSouthwestUnderwaterChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorCentralSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorNortheastChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorSoutheastChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleBigKeyChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && Has("Clawshot")
            && CanUseWBombs();
    }

    public bool LakebedTempleUnderwaterMazeSmallChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleEastLowerWaterwheelBridgeChest()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleMorpheelHeartContainer()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("LTBigKey") || SettingsStatus["BigKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatMorpheel();
    }

    public bool LakebedTempleDungeonReward()
    {
        return CanAccessLT()
            && CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && (Has("LTBigKey") || SettingsStatus["BigKeysKeysy"])
            && Has("Clawshot")
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
            && (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern");
    }

    public bool ArbitersGroundsTorchRoomEastChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern");
    }

    public bool ArbitersGroundsEastLowerTurnableRedeadChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsEastUpperTurnableChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern");
    }

    public bool ArbitersGroundsEastUpperTurnableRedeadChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && HasDamagingItem();
    }

    public bool ArbitersGroundsGhoulRatRoomChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatBubble()
            && CanDefeatStalchild()
            && CanDefeatRedeadKnight()
            && Has("Lantern");
    }

    public bool ArbitersGroundsWestSmallChestBehindBlock()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern");
    }

    public bool ArbitersGroundsWestChandelierChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsWestStalfosWestChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsWestStalfosNortheastChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsNorthTurningRoomChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos();
    }

    public bool ArbitersGroundsDeathSwordChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && CanDefeatDeathSword();
    }

    public bool ArbitersGroundsSpinnerRoomFirstSmallChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomSecondSmallChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomLowerCentralSmallChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomStalfosAlcoveChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomLowerNorthChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsBigKeyChest()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner")
            && CanSmash();
    }

    public bool ArbitersGroundsStallordHeartContainer()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && (Has("AGBigKey") || SettingsStatus["BigKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner")
            && CanDefeatStallord();
    }

    // Poes

    public bool ArbitersGroundsTorchRoomPoe()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsEastTurningRoomPoe()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Lantern")
            && Has("ShadowCrystal")
            && Has("Clawshot");
    }

    public bool ArbitersGroundsHiddenWallPoe()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatRedeadKnight()
            && Has("ShadowCrystal")
            && Has("Lantern");
    }

    public bool ArbitersGroundsWestPoe()
    {
        return CanAccessAG()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

/* ------------------------------

        Snowpeak Ruins 

------------------------------ */

    public bool SnowpeakRuinsLobbyEastArmorChest()
    {
        return CanAccessSR() && Has("B&C");
    }

    public bool SnowpeakRuinsLobbyWestArmorChest()
    {
        return CanAccessSR() && Has("B&C");
    }

    public bool SnowpeakRuinsMansionMap()
    {
        return CanAccessSR();
    }

    public bool SnowpeakRuinsEastCourtyardBuriedChest()
    {
        return CanAccessSR() && Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsEastCourtyardChest()
    {
        return CanAccessSR() && (Has("ShadowCrystal") || Has("B&C"));
    }

    public bool SnowpeakRuinsOrdonPumpkinChest()
    {
        return CanAccessSR()
            && (Has("ShadowCrystal") || Has("B&C"))
            && CanDefeatMiniFreezard()
            && ((Has("SRSmallKey", 4) || (Has("SRSmallKey", 2) && Has("Clawshot")) || SettingsStatus["SmallKeysKeysy"]));
    }

    public bool SnowpeakRuinsWestCourtyardBuriedChest()
    {
        return CanAccessSR()
            && Has("ShadowCrystal")
            && (Has("B&C")
                || Has("Pumpkin")
                || (Has("Cheese") && Has("SRSmallKey", 2))
                || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsWoodenBeamCentralChest()
    {
        return CanAccessSR()
            && CanDefeatIceKeese()
            && (Has("B&C")
                || (Has("Bombs")
                    && (Has("Pumpkin")
                        || (Has("Cheese") && Has("SRSmallKey", 2))
                        || SettingsStatus["SmallKeysKeysy"])));
    }

    public bool SnowpeakRuinsWoodenBeamNorthwestChest()
    {
        return CanAccessSR()
            && CanDefeatIceKeese()
            && (Has("B&C")
                || (Has("Bombs")
                    && (Has("Pumpkin")
                        || (Has("Cheese") && Has("SRSmallKey", 2))
                        || SettingsStatus["SmallKeysKeysy"])));
    }

    public bool SnowpeakRuinsCourtyardCentralChest()
    {
        return CanAccessSR()
            && (Has("B&C")
                || Has("Pumpkin")
                || (Has("Cheese") && Has("SRSmallKey", 2))
                || SettingsStatus["SmallKeysKeysy"])
            && (Has("B&C")
                || (Has("Bombs")
                    && (Has("SRSmallKey", 2) || Has("Cheese") || SettingsStatus["SmallKeysKeysy"])));
    }

    public bool SnowpeakRuinsBallandChain()
    {
        return CanAccessSR()
            && CanDefeatDarkhammer()
            && (Has("B&C")
                || Has("Pumpkin")
                || (Has("Cheese") && Has("SRSmallKey", 2))
                || SettingsStatus["SmallKeysKeysy"])
            && (Has("B&C")
                || (Has("Bombs")
                    && (Has("Cheese")
                        || Has("SRSmallKey", 2)
                        || SettingsStatus["SmallKeysKeysy"])));
    }

    public bool SnowpeakRuinsChestAfterDarkhammer()
    {
        return CanAccessSR()
            && CanDefeatDarkhammer()
            && Has("B&C");
    }

    public bool SnowpeakRuinsBrokenFloorChest()
    {
        return CanAccessSR()
            && Has("B&C")
            && (Has("Cheese") || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsWoodenBeamChandelierChest()
    {
        return CanAccessSR()
            && Has("B&C")
            && (Has("Cheese") || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsLobbyChandelierChest()
    {
        return CanAccessSR()
            && Has("B&C")
            && ((Has("Cheese") && Has("SRSmallKey", 3))
                || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsNortheastChandelierChest()
    {
        return CanAccessSR()
            && Has("B&C")
            && Has("Clawshot")
            && ((Has("Cheese") && Has("SRSmallKey", 3))
                || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsWestCannonRoomCentralChest()
    {
        return CanAccessSR()
            && Has("B&C");
    }

    public bool SnowpeakRuinsWestCannonRoomCornerChest()
    {
        return CanAccessSR()
            && (Has("B&C")
                || (Has("Bombs")
                    && (Has("Pumpkin")
                        || (Has("Cheese") && Has("SRSmallKey", 2))
                        || SettingsStatus["SmallKeysKeysy"])));
    }

    public bool SnowpeakRuinsChapelChest()
    {
        return CanAccessSR()
            && Has("B&C")
            && Has("Bombs")
            && ((Has("Cheese") && Has("SRSmallKey", 4))
                || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsBlizzetaHeartContainer()
    {
        return CanAccessSR()
            && Has("B&C")
            && Has("Bombs")
            && ((Has("Cheese") && Has("SRSmallKey", 4)) || SettingsStatus["SmallKeysKeysy"])
            && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"]);
    }

    public bool SnowpeakRuinsDungeonReward()
    {
        return CanAccessSR()
            && Has("B&C")
            && Has("Bombs")
            && ((Has("Cheese") && Has("SRSmallKey", 4)) || SettingsStatus["SmallKeysKeysy"])
            && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"]);
    }

    // Poes

    public bool SnowpeakRuinsLobbyPoe()
    {
        return CanAccessSR() && Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsLobbyArmorPoe()
    {
        return CanAccessSR() && Has("ShadowCrystal") && Has("B&C");
    }

    public bool SnowpeakRuinsIceRoomPoe()
    {
        return CanAccessSR()
            && Has("B&C")
            && Has("ShadowCrystal")
            && ((Has("Cheese") && Has("SRSmallKey", 3))
                || SettingsStatus["SmallKeysKeysy"]);
    }

/* ------------------------------

        Temple of Time

------------------------------ */

    public bool TempleofTimeLobbyLanternChest()
    {
        return CanAccessToT() && Has("Lantern");
    }

    public bool TempleofTimeFirstStaircaseGohmaGateChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatYoungGohma();
    }

    public bool TempleofTimeFirstStaircaseWindowChest()
    {
        return CanAccessToT()
            && HasRangedItem()
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool TempleofTimeFirstStaircaseArmosChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && HasRangedItem()
            && CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberEastChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && HasRangedItem()
            && CanDefeatLizalfos()
            && Has("Spinner");
    }

    public bool TempleofTimeArmosAntechamberNorthChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && HasRangedItem()
            && CanDefeatLizalfos()
            && Has("Spinner");
    }

    public bool TempleofTimeMovingWallBeamosRoomChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatLizalfos()
            && Has("Spinner")
            && Has("Bow");
    }

    public bool TempleofTimeScalesGohmaChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos()
            && CanDefeatBabyGohma();
    }

    public bool TempleofTimeGilloutineChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos();
    }

    public bool TempleofTimeChestBeforeDarknut()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos();
    }

    public bool TempleofTimeDarknutChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDarknut();
    }

    public bool TempleofTimeScalesUpperChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos()
            && Has("Clawshot");
    }

    public bool TempleofTimeFloorSwitchPuzzleRoomUpperChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos()
            && Has("Clawshot");
    }

    public bool TempleofTimeBigKeyChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos()
            && Has("Clawshot");
    }

    public bool TempleofTimeMovingWallDinalfosRoomChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && CanDefeatDinalfos()
            && Has("DominionRod")
            && Has("Bow");
    }

    public bool TempleofTimeArmosAntechamberStatueChest()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && HasRangedItem()
            && CanDefeatLizalfos()
            && Has("Spinner")
            && Has("DominionRod");
    }

    public bool TempleofTimeArmogohmaHeartContainer()
    {
        return CanAccessToT()
            && ((Has("Spinner") 
                && Has("Bow") 
                && Has("DominionRod")
                && CanDefeatDarknut()
                    && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]))
                        || SettingsStatus["OpenDoorOfTime"])
            && (Has("ToTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatArmogohma();
    }

    public bool TempleofTimeDungeonReward()
    {
        return CanAccessToT()
            && ((Has("Spinner") 
                && Has("Bow") 
                && Has("DominionRod")
                && CanDefeatDarknut()
                    && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]))
                        || SettingsStatus["OpenDoorOfTime"])
            && (Has("ToTBigKey") || SettingsStatus["BigKeysKeysy"])
            && CanDefeatArmogohma();
    }

    // Poes

    public bool TempleofTimePoeBehindGate()
    {
        return CanAccessToT()
            && Has("ShadowCrystal")
            && Has("DominionRod")
            && (Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && HasRangedItem();
    }

    public bool TempleofTimePoeAboveScales()
    {
        return CanAccessToT()
            && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && Has("Spinner")
            && Has("Bow")
            && CanDefeatDinalfos()
            && Has("Clawshot");
    }

/* ------------------------------

        City in the Sky 

------------------------------ */

    public bool CityinTheSkyUnderwaterEastChest()
    {
        return CanAccessCitS() && Has("IronBoots");
    }

    public bool CityinTheSkyUnderwaterWestChest()
    {
        return CanAccessCitS() && Has("IronBoots");
    }

    public bool CityinTheSkyWestWingFirstChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyEastFirstWingChestAfterFans()
    {
        return CanAccessCitS()
            && Has("Clawshot")
            && Has("Spinner")
            && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool CityinTheSkyEastTileWormSmallChest()
    {
        return CanAccessCitS()
            && Has("Clawshot")
            && Has("Spinner")
            && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool CityinTheSkyEastWingAfterDinalfosLedgeChest()
    {
        return CanAccessCitS()
            && Has("Clawshot")
            && Has("Spinner")
            && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatTileWorm()
            && CanDefeatDinalfos();
    }

    public bool CityinTheSkyEastWingAfterDinalfosAlcoveChest()
    {
        return CanAccessCitS()
            && Has("Clawshot")
            && Has("Spinner")
            && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatTileWorm()
            && CanDefeatDinalfos();
    }

    public bool CityinTheSkyAeralfosChest()
    {
        return CanAccessCitS()
            && Has("Clawshot")
            && Has("Spinner")
            && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && CanDefeatDinalfos()
            && CanDefeatTileWorm()
            && CanDefeatAeralfos();
    }

    public bool CityinTheSkyEastWingLowerLevelChest()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && Has("Spinner")
            && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatTileWorm()
            && CanDefeatDinalfos();
    }

    public bool CityinTheSkyWestWingBabaBalconyChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestWingNarrowLedgeChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestWingTileWormChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyBabaTowerTopSmallChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerNarrowLedgeChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerAlcoveChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenCornerChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLoneIslandChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLowerChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLedgeChest()
    {
        return CanAccessCitS() && Has("Clawshot", 2);
    }

    public bool CityinTheSkyCentralOutsideLedgeChest()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyCentralOutsidePoeIslandChest()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyBigKeyChest()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("IronBoots")
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyChestBelowBigKeyChest()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && CanDefeatHelmasaur();
    }

    public bool CityinTheSkyChestBehindNorthFan()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && CanDefeatBabaSerpent()
            && CanDefeatKargorok()
            && Has("IronBoots")
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyArgorokHeartContainer()
    {
        return CanAccessCitS()
            && CanDefeatArgorok()
            && Has("ShadowCrystal")
            && (Has("CitSBigKey") || SettingsStatus["BigKeysKeysy"]);
    }

    public bool CityinTheSkyDungeonReward()
    {
        return CanAccessCitS()
            && CanDefeatArgorok()
            && Has("ShadowCrystal")
            && (Has("CitSBigKey") || SettingsStatus["BigKeysKeysy"]);
    }

    // Poes

    public bool CityinTheSkyGardenIslandPoe()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyPoeAboveCentralFan()
    {
        return CanAccessCitS()
            && Has("Clawshot", 2)
            && CanDefeatWalltula()
            && Has("ShadowCrystal");
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
        return CanAccessPoT() && Has("Sword", 4) && Has("Clawshot");
    }

    public bool PalaceofTwilightWestWingSecondRoomCentralChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomLowerSouthChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomSoutheastChest()
    {
        return CanAccessPoT()
            && Has("Clawshot", 2)
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomZantHeadChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomNorthSmallChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomNortheastChest()
    {
        return CanAccessPoT()
            && Has("Clawshot", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomNorthwestChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomSouthwestChest()
    {
        return CanAccessPoT()
            && Has("Clawshot", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomSoutheastChest()
    {
        return CanAccessPoT()
            && Has("Clawshot", 2)
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomEastAlcove()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Sword", 4) || Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomWestAlcove()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && (Has("Sword", 4) || Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCollectBothSols()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && CanDefeatPhantomZant()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralFirstRoomChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightBigKeyChest()
    {
        return CanAccessPoT()
            && Has("Clawshot", 2)
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralOutdoorChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralTowerChest()
    {
        return CanAccessPoT()
            && Has("Clawshot")
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 6) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightZantHeartContainer()
    {
        return CanAccessPoT()
            && CanDefeatZant()
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 7) || SettingsStatus["SmallKeysKeysy"])
            && (Has("PoTBigKey") || SettingsStatus["BigKeysKeysy"]);
    }

/* ------------------------------

        Hyrule Castle 

------------------------------ */

    public bool HyruleCastleGraveyardGraveSwitchRoomRightChest()
    {
        return CanAccessHC() && Has("ShadowCrystal") && CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomFrontLeftChest()
    {
        return CanAccessHC() && Has("ShadowCrystal") && CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomBackLeftChest()
    {
        return CanAccessHC() && Has("ShadowCrystal") && CanSmash();
    }

    public bool HyruleCastleGraveyardOwlStatueChest()
    {
        return CanAccessHC()
            && Has("ShadowCrystal")
            && CanSmash()
            && Has("Lantern")
            && Has("DominionRod", 2);
    }

    public bool HyruleCastleEastWingBoomerangPuzzleChest()
    {
        return CanAccessHC() && CanDefeatBokoblinRed() && Has("Boomerang");
    }

    public bool HyruleCastleEastWingBalconyChest()
    {
        return CanAccessHC() && CanDefeatBokoblinRed() && Has("Boomerang");
    }

    public bool HyruleCastleWestCourtyardNorthSmallChest()
    {
        return CanAccessHC() && CanDefeatBokoblinRed();
    }

    public bool HyruleCastleWestCourtyardCentralSmallChest()
    {
        return CanAccessHC() && CanDefeatBokoblinRed();
    }

    public bool HyruleCastleKingBulblinKey()
    {
        return CanAccessHC() && CanDefeatKingBulblinCastle();
    }

    public bool HyruleCastleMainHallNortheastChest()
    {
        return CanAccessHC()
            && CanDefeatLizalfos()
            && Has("Clawshot")
            && (Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool HyruleCastleLanternStaircaseChest()
    {
        return CanAccessHC()
            && Has("Clawshot", 2)
            && (Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatDarknut()
            && Has("Boomerang");
    }

    public bool HyruleCastleMainHallSouthwestChest()
    {
        return CanAccessHC()
            && CanDefeatDarknut()
            && Has("Clawshot", 2)
            && (Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanKnockDownHCPainting()
            && Has("Boomerang")
            && Has("Lantern");
    }

    public bool HyruleCastleMainHallNorthwestChest()
    {
        return CanAccessHC()
            && CanDefeatDarknut()
            && Has("Clawshot", 2)
            && (Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && CanKnockDownHCPainting()
            && Has("Boomerang")
            && Has("Lantern");
    }

    public bool HyruleCastleSoutheastBalconyTowerChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleBigKeyChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFirstChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSecondChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomThirdChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFourthChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFifthChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFirstSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSecondSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomThirdSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFourthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomFifthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSixthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomSeventhSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

    public bool HyruleCastleTreasureRoomEighthSmallChest()
    {
        return CanAccessHC()
            && (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot", 2)
            && CanDefeatDarknut()
            && Has("Boomerang")
            && Has("Spinner")
            && (Has("Lantern") || CanKnockDownHCPainting());
    }

}
