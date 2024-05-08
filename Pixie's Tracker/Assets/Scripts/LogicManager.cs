using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
        {"GlitchedLogic", false },

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
        {"UnrequiredDungeonsAreBarren", false },
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

        Room References

------------------------------ */

    public GameObject RoomDeathMountainTrail;
    public GameObject RoomLakeHylia;
    public GameObject RoomZorasDomain;
    public GameObject RoomNorthFaronWoods;
    public GameObject RoomSnowpeakClimb;
    public GameObject RoomHiddenVillage;
    public GameObject RoomForestTempleWestWing;
    public GameObject RoomGoronMinesUpperEastWing;
    public GameObject RoomLakebedTempleEastWingSecondFloor;
    public GameObject RoomLakebedTempleWestWing;

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
            || HasBombs()
            || Has("IronBoots")
            || Has("ShadowCrystal")
            || Has("Spinner");
    }

    public bool HasBombs()
    {
        return (
            Has("Bombs")
            && (
                CanAccessKakariko()
                || (
                    CanAccessEldinField() && Has("ShadowCrystal") && Has("FishingRod")
                )
                || CanAccessCitS()
            )
        );
    }

    public bool HasWaterBombs()
    {
        return 
            Has("Bombs") && (Has("WaterBombs") || SettingsStatus["IgnoreWaterBombLogic"])
            && (
                CanAccessKakariko()
                || (
                    CanAccessEldinField() && Has("ShadowCrystal") && Has("FishingRod")
                )
            );
    }

    public bool CanSmash()
    {
        return Has("B&C") || HasBombs();
    }

    public bool CanBurnWebs()
    {
        return Has("Lantern") || Has("B&C") || HasBombs();
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
        return (Has("Bow") || Has("Boomerang")) && HasBombs();
    }

    public bool CanBombArrow()
    {
        return Has("Bow") && HasBombs();
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

        playerHealth += ItemCounts["HeartPiece"] * 0.2;
        playerHealth += ItemCounts["HeartContainer"];

        return (int)playerHealth;
    }

    public bool CanKnockDownHCPainting()
    {
        return (
            Has("Bow")
            || (
                CanDoNicheStuff()
                && (
                    HasBombs()
                    || (Has("Sword") && Has("HiddenSkill", 6))
                )
            )
            || (
                SettingsStatus["GlitchedLogic"]
                && ((Has("Sword") && CanDoMoonBoots()) || CanDoBSMoonBoots())
            )
        );
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
            || HasBombs()
            || Has("Clawshot")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || (Has("Bow") && CanGetArrows())
            || (CanDoNicheStuff() && Has("HiddenSkill", 2));
    }

    public bool CanFreeAllMonkeys()
    {
        return CanBreakMonkeyCage()
            && (Has("Lantern") || HasBombs() || Has("IronBoots")) //?
            && CanBurnWebs()
            && Has("Boomerang")
            && CanDefeatBokoblin()
            && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool CanPressMinesSwitch()
    {
        return Has("IronBoots") || (CanDoNicheStuff() && Has("B&C"));
    }

    public bool CanKnockDownHangingBaba()
    {
        return Has("Bow") || Has("Boomerang") || Has("Clawshot") || Has("Slingshot");
    }

    public bool CanBreakWoodenDoor()
    {
        return Has("ShadowCrystal") || Has("Sword") || CanSmash() || CanUseBacksliceAsSword();
    }

// Glitched Functions

    public bool HasSwordorBS()
    {
        return Has("Sword") || Has("HiddenSkill", 3);
    }

    public bool HasBottle()
    {
        return Has("Bottle") && Has("Lantern");
    }

    public bool HasBottles()
    {
        return Has("Bottle", 2) && Has("Lantern");
    }

    public bool HasHeavyMod()
    {
        return Has("IronBoots") || Has("MagicArmor");
    }

    public bool HasCutsceneItem()
    {
        return Has("Skybook") || HasBottle() || Has("HorseCall");
    }

    public bool CanDoLJA()
    {
        return Has("Sword") && Has("Boomerang");
    }

    public bool CanDoJSLJA()
    {
        return Has("Sword") && Has("Boomerang") && Has("HiddenSkill", 6);
    }

    public bool CanDoMapGlitch()
    {
        return Has("ShadowCrystal") && CanAccessKakariko();
    }

    public bool CanDoStorage()
    {
        return CanDoMapGlitch() && HasOneHandedItem();
    }

    public bool HasOneHandedItem()
    {
        return Has("Sword")
            || HasBottle()
            || Has("Boomerang")
            || Has("Clawshot")
            || Has("Lantern")
            || Has("Bow")
            || Has("Slingshot")
            || Has("DominionRod");
    }

    public bool CanDoNicheStuff()
    {
        return SettingsStatus["GlitchedLogic"];
    }

    public bool CanUseBacksliceAsSword()
    {
        return CanDoNicheStuff() && Has("HiddenSkill", 3);
    }

    public bool CanDoAirRefill()
    {
        return HasWaterBombs()
            && (Has("Sword") || Has("Clawshot"))
            && (
                Has("MagicArmor")
                || (Has("IronBoots") && (GetItemWheelSlotCount() >= 3))
            );
    }

    public int GetItemWheelSlotCount()
    {
        int count = 0;

        if (Has("Clawshot"))
            count++;
        if (Has("DominionRod"))
            count++;
        if (Has("B&C"))
            count++;
        if (Has("Spinner"))
            count++;
        if (Has("Bow"))
            count++;
        if (Has("IronBoots"))
            count++;
        if (Has("Boomerang"))
            count++;
        if (Has("Lantern"))
            count++;
        if (Has("Slingshot"))
            count++;
        if (Has("FishingRod"))
            count++;
        if (Has("Hawkeye"))
            count++;
        if (Has("Bombs"))
            count++;
        if (Has("Bombs", 2))
            count++;
        if (Has("Bombs", 3))
            count++;
        if (Has("Bottle"))
            count++;
        if (Has("Bottle", 2))
            count++;
        if (Has("Bottle", 3))
            count++;
        if (Has("Bottle", 4))
            count++;
        if (Has("AurusMemo"))
            count++;
        if (Has("FetchQuest"))
            count++;
        if (Has("HorseCall"))
            count++;

        return count;
    }

    public bool CanDoMoonBoots()
    {
        return Has("Sword")
            && (
                Has("MagicArmor")
                || (Has("IronBoots") && GetItemWheelSlotCount() >= 3)
            );
    }

    public bool CanDoJSMoonBoots()
    {
        return CanDoMoonBoots() && Has("HiddenSkill", 6);
    }

    public bool CanDoBSMoonBoots()
    {
        return Has("HiddenSkill", 3) && Has("MagicArmor");
    }

    public bool CanDoEBMoonBoots()
    {
        return CanDoMoonBoots() && Has("HiddenSkill") && Has("Sword");
    }

    public bool CanDoFlyGlitch()
    {
        return Has("FishingRod") && HasHeavyMod();
    }

    public bool CanDoHiddenVillageGlitched()
    {
        return Has("Bow")
            || Has("B&C")
            || (
                Has("Slingshot")
                && (
                    Has("ShadowCrystal")
                    || Has("Sword")
                    || HasBombs()
                    || Has("IronBoots")
                    || Has("Spinner")
                )
            );
    }

    public bool CanDoFTWindlessBridgeRoom()
    {
        return HasBombs() || CanDoBSMoonBoots() || CanDoJSMoonBoots();
    }

    public bool CanClearForestGlitched()
    {
        return CanCompletePrologue()
            && (
                SettingsStatus["FaronEscape"]
                || CanCompleteFT()
                || CanDoLJA()
                || CanDoMapGlitch()
            );
    }

    public bool CanCompleteEldinTwilightGlitched()
    {
        return SettingsStatus["SkipEldinTwilight"] || CanClearForestGlitched();
    }

    public bool CanSkipKeyToDekuToad()
    {
        return SettingsStatus["SmallKeysKeysy"]
            || Has("HiddenSkill", 3)
            || CanDoBSMoonBoots()
            || CanDoJSMoonBoots()
            || CanDoLJA()
            || (HasBombs() && (HasHeavyMod() || Has("HiddenSkill", 6)));
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

    public bool CanAccessKakariko() // used for gorge and village since requirements are the same //done
    {
        return CanClearForest() 
            || (SettingsStatus["GlitchedLogic"] && CanClearForestGlitched()) 
            || (EldinTwilightCleared() && SettingsStatus["UnlockMapRegions"] && Has("ShadowCrystal"));
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
                && (Has("ShadowCrystal") || SettingsStatus["SkipLanayruTwilight"]))))
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
                || (Has("IronBoots") && HasWaterBombs()));
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
                && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairy())));
    }

    public bool CanCompleteSR()
    {
        return CanAccessSR()
            && (Has("SRSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"])
            && Has("Cheese")
            && Has("B&C")
            && HasBombs()
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
            && (SettingsStatus["HCOpen"] 
            || (SettingsStatus["HCVanilla"] && Has("Boss8")) 
            || (SettingsStatus["HCFusedShadows"] && Has("FusedShadow", 3)) 
            || (SettingsStatus["HCMirrorShards"] && Has("MirrorShard", 3)) 
            || ((SettingsStatus["HCAllDungeons"] 
                && HasCompletedAllDungeons()) 
                && CanCompleteMDH()));
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
        return Has("Clawshot") 
            && (Has("Sword") 
                || Has("B&C") 
                || Has("ShadowCrystal")
                || (CanDoNicheStuff() && Has("IronBoots")));
    }

    public bool CanDefeatArmos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Clawshot")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBabaSerpent()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBabyGohma()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Clawshot")
            || Has("Slingshot")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBari()
    {
        return HasWaterBombs() || Has("Clawshot");
    }

    public bool CanDefeatBeamos()
    {
        return Has("B&C") || Has("Bow") || HasBombs();
    }

    public bool CanDefeatBigBaba()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBokoblin()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBokoblinRed()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBombfish()
    {
        return (Has("IronBoots") || (SettingsStatus["GlitchedLogic"] && Has("MagicArmor")))
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
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatBomskit()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBulblin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatChilfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatChu()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Clawshot")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatChuWorm()
    {
        return (Has("Sword")
            || Has("Bow")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword())
                && (HasBombs() || Has("Clawshot"));
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
            || Has("HiddenSkill", 2) // no shield??
            || Has("Slingshot")
            || Has("Clawshot")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatDekuLike()
    {
        return HasBombs();
    }

    public bool CanDefeatDodongo()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatFireKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || Has("Slingshot")
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatHelmasaur()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatHelmasaurus()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatIceBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatIceKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Slingshot")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword(); // was this supposed to be clawshot?
    }

    public bool CanDefeatLeever()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatLizalfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatMiniFreezard()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatMoldorm()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"));
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
            || HasBombs()
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatRat()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || Has("Spinner")
            || Has("Slingshot")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatRedeadKnight()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShadowDekuBaba()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || HasBombs()
            || Has("Spinner")
            || Has("Slingshot")
            || Has("Clawshot")
            || Has("HiddenSkill", 2)
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword(); // shield??
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
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShadowKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || Has("Slingshot")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShadowVermin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShellBlade()
    {
        return HasWaterBombs() 
            || (Has("Sword") 
                && (Has("IronBoots") 
                    || (CanDoNicheStuff() && Has("MagicArmor"))));
    }

    public bool CanDefeatSkullfish()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatSkulltula()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatStalchild()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatTektite()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatTileWorm()
    {
        return (Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword())
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
            || HasBombs();
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
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatYoungGohma()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatZantHead()
    {
        return Has("Sword") || Has("ShadowCrystal") || CanUseBacksliceAsSword();
    }

    public bool CanDefeatOok()
    {
        return Has("Sword")
            || (Has("Bow") && CanGetArrows())
            || Has("B&C")
            || Has("ShadowCrystal")
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatDangoro()
    {
        return (Has("Sword")
            || Has("ShadowCrystal")
            || (CanDoNicheStuff() && Has("B&C")
                || (Has("Bow") && HasBombs())))
            && Has("IronBoots");
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
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"))
            || CanUseBacksliceAsSword();
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
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
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
            || HasBombs()
            || (CanDoNicheStuff() && Has("IronBoots"));
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
                    || HasBombs()
                    || (CanDoNicheStuff() && Has("IronBoots"))));
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
        return Has("Clawshot", 2) 
            && Has("Sword", 2) 
            && (Has("IronBoots") || (CanDoNicheStuff() && Has("MagicArmor")));
    }

    public bool CanDefeatZant()
    {
        return Has("Sword", 3)
            && (
                Has("Boomerang")
                && Has("Clawshot")
                && Has("B&C")
                && (Has("IronBoots") || (CanDoNicheStuff() && Has("MagicArmor")))
                && (
                    Has("ZoraArmor")
                    || (
                        SettingsStatus["GlitchedLogic"]
                        && CanDoAirRefill()
                    )
                )
            );
    }

    public bool CanDefeatGanondorf()
    {
        return Has("Sword", 3) && Has("ShadowCrystal") && Has("HiddenSkill");
    }

/* ------------------------------

        Overworld Checks 

------------------------------ */

    // Ordon Province
   
    public bool OrdonRanchGrottoLanternChest() // done
    {
        return Has("Lantern");
    }

    public bool HerdingGoatsReward() // done
    {
        return CanCompletePrologue();
    }

    public bool OrdonSpringGoldenWolf() // done
    {
        return Has("ShadowCrystal") && RoomDeathMountainTrail.GetComponent<RoomBehaviour>().isAccessible;
    }

    // Faron Woods

    public bool CoroBottle() // done
    {
        return CanCompletePrologue();
    }

    public bool FaronMistCaveLanternChest() // done
    {
        return Has("Lantern");
    }

    public bool FaronMistCaveOpenChest() // done
    {
        return true;
    }

    public bool FaronMistNorthChest() // done
    {
        return (CanCompletePrologue() && Has("Lantern"))
            || (SettingsStatus["GlitchedLogic"] && (Has("Lantern") || CanDoMapGlitch()));
    }

    public bool FaronMistSouthChest() // done
    {
        return (CanCompletePrologue() && Has("Lantern"))
            || (SettingsStatus["GlitchedLogic"] && (Has("Lantern") || CanDoMapGlitch()));
    }

    public bool FaronMistStumpChest() // done
    {
        return (CanCompletePrologue() && Has("Lantern"))
            || (SettingsStatus["GlitchedLogic"] && (Has("Lantern") || Has("ShadowCrystal")));
    }

    public bool FaronWoodsGoldenWolf() // done
    {
        return true;
    }

    public bool FaronWoodsOwlStatueChest() // done
    {
        return (CanSmash()
            && Has("DominionRod", 2)
            && CanClearForest()
            && Has("ShadowCrystal"))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
    }

    public bool FaronWoodsOwlStatueSkyCharacter() // done
    {
        return Has("DominionRod", 2)
            && ((CanClearForest() && CanSmash())
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool NorthFaronWoodsDekuBabaChest() // done
    {
        return true;
    }

    public bool SouthFaronCaveChest() // done
    {
        return true;
    }

    // Lost Woods/Sacred Grove

    public bool LostWoodsLanternChest() // done
    {
        return Has("Lantern");
    }

    public bool SacredGroveBabaSerpentGrottoChest() // done
    {
        return CanDefeatBabaSerpent() 
            && (CanKnockDownHangingBaba()
                || (SettingsStatus["GlitchedLogic"] && 
                    (Has("Sword")
                    || Has("ShadowCrystal")
                    || Has("Slingshot")
                    || Has("B&C")
                    || HasBombs())));
    }

    public bool SacredGrovePastOwlStatueChest() // done
    {
        return Has("DominionRod")
            || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
    }

    public bool SacredGroveSpinnerChest() // done
    {
        return Has("Spinner")
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
    }

    // Faron Field

    public bool FaronFieldBridgeChest() // done
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoStorage());
    }

    public bool FaronFieldCornerGrottoLeftChest() // done
    {
        return true;
    }

    public bool FaronFieldCornerGrottoRearChest() // done
    {
        return true;
    }

    public bool FaronFieldCornerGrottoRightChest() // done
    {
        return true;
    }

    public bool FaronFieldTreeHeartPiece() // done
    {
        return Has("Boomerang") || Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && Has("B&C"));
    }

    // Kakariko Gorge

    public bool KakarikoGorgeDoubleClawshotChest() // done
    {
        return Has("Clawshot", 2)
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("ShadowCrystal")));
    }

    public bool KakarikoGorgeOwlStatueChest() // done
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && 
                (CanDoLJA() || CanDoStorage() || CanDoEBMoonBoots()));
    }

    public bool KakarikoGorgeOwlStatueSkyCharacter() // done
    {
        return Has("DominionRod", 2);
    }

    public bool KakarikoGorgeSpireHeartPiece() // done
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    // Death Mountain

    public bool DeathMountainAlcoveChest() // done
    {
        return (Has("Boss2") && SettingsStatus["UnrequiredDungeonsAreBarren"]) || 
            (
                (Has("Clawshot") 
                    && (Has("IronBoots") || Has("ShadowCrystal")))
                || (SettingsStatus["GlitchedLogic"] && (Has("Clawshot") || CanDoLJA()))
            );
    }

    // Eldin Field

    public bool BridgeofEldinOwlStatueChest() // done
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("ShadowCrystal")));
    }

    public bool BridgeofEldinOwlStatueSkyCharacter() // done 
    {
        return Has("DominionRod", 2);
    }

    public bool EldinFieldBombRockChest() // done
    {
        return CanSmash()
            || (SettingsStatus["GlitchedLogic"] 
                && CanDoMapGlitch() 
                    || (CanDoEBMoonBoots() && CanDoLJA()));
    }

    public bool EldinFieldBomskitGrottoLanternChest() // done
    {
        return CanDefeatBomskit() && Has("Lantern");
    }

    public bool EldinFieldBomskitGrottoLeftChest() // done
    {
        return CanDefeatBomskit();
    }

    public bool EldinFieldStalfosGrottoLeftSmallChest() // done
    {
        return true;
    }

    public bool EldinFieldStalfosGrottoRightSmallChest() // done
    {
        return true;
    }

    public bool EldinFieldStalfosGrottoStalfosChest() // done
    {
        return CanDefeatStalfos();
    }

    public bool EldinFieldWaterBombFishGrottoChest() // done
    {
        return true;
    }

    public bool GoronSpringwaterRush() // done
    {
        return CanSmash() ||
            (
                (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                && (LanayruTwilightCleared() || Has("ShadowCrystal"))
            );
    }

    // Lanayru Field

    public bool LanayruFieldBehindGateUnderwaterChest() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LanayruFieldSkulltulaGrottoChest() // done
    {
        return (SettingsStatus["GlitchedLogic"] || CanDefeatSkulltula()) 
            && Has("Lantern") 
            && CanBreakWoodenDoor();
    }

    public bool LanayruFieldSpinnerTrackChest() // done
    {
        return (CanSmash() && Has("Spinner"))
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
    }

    public bool LanayruIceBlockPuzzleCaveChest() // done
    {
        return Has("B&C");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterOwlStatueChest() // done
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] 
                && 
                    (CanDoLJA()
                    || CanDoMapGlitch()
                    || CanDoEBMoonBoots()));
    }

    public bool HyruleFieldAmphitheaterOwlStatueSkyCharacter() // done
    {
        return Has("DominionRod", 2);
    }

    public bool WestHyruleFieldGoldenWolf() // done
    {
        return Has("ShadowCrystal") && RoomZorasDomain.GetComponent<RoomBehaviour>().isAccessible;
    }

    public bool WestHyruleFieldHelmasaurGrottoChest() // done
    {
        return CanDefeatHelmasaur();
    }

    // North Castle Town

    public bool NorthCastleTownGoldenWolf() // done
    {
        return RoomHiddenVillage.GetComponent<RoomBehaviour>().isAccessible 
            && Has("ShadowCrystal") 
            && CanCompleteMDH();
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownDoubleClawshotChasmChest() // done
    {
        return Has("Clawshot", 2)
            || (SettingsStatus["GlitchedLogic"] 
                && (
                    (Has("Sword") && 
                        (SettingsStatus["DamageVanilla"] 
                        || SettingsStatus["DamageDouble"]
                        || CanUseBottledFairy())
                    ) 
                    || HasBombs() 
                    || Has("Spinner") 
                    || Has("ShadowCrystal")
                )
            );
    }

    public bool OutsideSouthCastleTownFountainChest() // done
    {
        return (Has("Clawshot") && Has("Spinner"))
            || (SettingsStatus["GlitchedLogic"]
                &&
                (
                (CanDoMapGlitch() && HasBottle()) 
                || CanDoMoonBoots() 
                || CanDoBSMoonBoots() 
                || CanDoLJA() 
                || (Has("Sword") && (Has("HiddenSkill", 3) || HasBombs()))
                )
            );
    }

    public bool OutsideSouthCastleTownGoldenWolf() // done
    {
        return RoomNorthFaronWoods.GetComponent<RoomBehaviour>().isAccessible && Has("ShadowCrystal");
    }

    public bool OutsideSouthCastleTownTektiteGrottoChest() // done
    {
        return CanDefeatTektite();
    }

    public bool OutsideSouthCastleTownTightropeChest() // done
    {
        return Has("ShadowCrystal") && Has("Clawshot");
    }

    public bool WoodenStatue() // done
    {
        return Has("FetchQuest", 2) && (Has("MedicineScent") || SettingsStatus["IgnoreScentLogic"]);
    }

    // Lake Hylia

    public bool AuruGiftToFyer() // done
    {
        return true;
    }

    public bool LakeHyliaShellBladeGrottoChest() // done
    {
        return CanDefeatShellBlade();
    }

    public bool LakeHyliaUnderwaterChest() // done
    {
        return Has("IronBoots") || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LakeHyliaWaterToadpoliGrottoChest() // done
    {
        return CanDefeatWaterToadpoli();
    }

    public bool OutsideLanayruSpringLeftStatueChest() // done
    {
        return true;
    }

    public bool OutsideLanayruSpringRightStatueChest() // done
    {
        return true;
    }

    public bool PlummFruitBalloonMinigame() // done
    {
        return Has("ShadowCrystal");
    }

    public bool FlightByFowl() // done
    {
        return true;
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeBubbleGrottoChest() // done
    {
        return CanDefeatBubble();
    }

    public bool LakeHyliaBridgeCliffChest() // done
    {
        return CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakeHyliaBridgeOwlStatueChest() // done
    {
        return (Has("Clawshot") && Has("DominionRod", 2))
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
    }

    public bool LakeHyliaBridgeOwlStatueSkyCharacter() // done
    {
        return Has("Clawshot") && Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
    }

    public bool LakeHyliaBridgeVinesChest() // done
    {
        return Has("Clawshot");
    }

    // Upper Zora's River

    public bool FishingHoleBottle() // done
    {
        return Has("FishingRod");
    }

    public bool FishingHoleHeartPiece() // done
    {
        return true;
    }

    public bool IzaHelpingHand() // done
    {
        return RoomZorasDomain.GetComponent<RoomBehaviour>().isAccessible
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    public bool IzaRagingRapidsMinigame() // done
    {
        return RoomZorasDomain.GetComponent<RoomBehaviour>().isAccessible
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    // Zora's Domain

    public bool ZorasDomainChestBehindWaterfall() // done
    {
        return Has("ShadowCrystal")
            || (SettingsStatus["GlitchedLogic"] && 
                (CanDoBSMoonBoots()
                || Has("Spinner")
                || (HasBombs() && Has("Sword"))
                || CanDoLJA()));
    }

    public bool ZorasDomainChestByMotherandChildIsles() // done
    {
        return true;
    }

    public bool ZorasDomainExtinguishAllTorchesChest() // done
    {
        return Has("Boomerang") 
            && (Has("IronBoots")
                || (SettingsStatus["GlitchedLogic"] && HasHeavyMod()));
    }

    public bool ZorasDomainLightAllTorchesChest() // done
    {
        return Has("Lantern") 
            && (Has("IronBoots")
                || (SettingsStatus["GlitchedLogic"] && HasHeavyMod()));
    }

    public bool ZorasDomainUnderwaterGoron() // done
    {
        return Has("IronBoots") 
            && (Has("ZoraArmor") || SettingsStatus["GlitchedLogic"])
            && HasWaterBombs();
    }

    // Gerudo Desert

    public bool GerudoDesertCampfireEastChest() // done
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertCampfireNorthChest() // done
    {
        return true;
    }

    public bool GerudoDesertCampfireWestChest() // done
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertEastCanyonChest() // done
    {
        return true;
    }

    public bool GerudoDesertGoldenWolf() // done
    {
        return Has("ShadowCrystal") && RoomLakeHylia.GetComponent<RoomBehaviour>().isAccessible;
    }

    public bool GerudoDesertLoneSmallChest() // done
    {
        return true;
    }

    public bool GerudoDesertNortheastChestBehindGates() // done
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertNorthwestChestBehindGates() // done
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertNorthSmallChestBeforeBulblinCamp() // done
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertOwlStatueChest() // done
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
    }

    public bool GerudoDesertOwlStatueSkyCharacter() // done
    {
        return Has("DominionRod", 2);
    }

    public bool GerudoDesertPeahatLedgeChest() // done
    {
        return Has("Clawshot");
    }

    public bool GerudoDesertRockGrottoLanternChest() // done
    {
        return CanSmash() && Has("Lantern");
    }

    public bool GerudoDesertSouthChestBehindWoodenGates() // done
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertSkulltulaGrottoChest() // done
    {
        return CanDefeatSkulltula();
    }

    public bool GerudoDesertWestCanyonChest() // done
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] 
                && (CanDoLJA() || (Has("ShadowCrystal") && HasBombs())));
    }

    // Snowpeak

    public bool AsheiSketch() // done
    {
        return true;
    }

    public bool SnowboardRacingPrize() // done
    {
        return Has("Boss5");
    }

    public bool SnowpeakCaveIceLanternChest() // done
    {
        return Has("B&C") && Has("Lantern");
    }

    public bool SnowpeakFreezardGrottoChest() // done
    {
        return Has("B&C");
    }

    // Hidden Village

    public bool CatsHideandSeekMinigame() // done
    {
        return Has("ShadowCrystal")
            && Has("Clawshot")
            && Has("FetchQuest", 4)
            && (Has("Bow") || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched()))
            && Has("DominionRod");
    }

    public bool IliaCharm() // done
    {
        return Has("Bow")
            || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched());
    }

    public bool SkybookFromImpaz() // done
    {
        return (Has("Bow") || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched())) 
            && Has("DominionRod");
    }

/* ------------------------------

        Overworld Poes 

------------------------------ */

    // Faron Province

    public bool FaronMistPoe() // done
    {
        return (CanCompletePrologue() || SettingsStatus["GlitchedLogic"])
            && Has("ShadowCrystal");
    }

    // Lost Woods

    public bool LostWoodsWaterfallPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool LostWoodsBoulderPoe() // done
    {
        return Has("ShadowCrystal")
            && (CanDefeatSkullKid() || !SettingsStatus["ToTClosed"]) 
            && CanSmash();
    }

    // Sacred Grove

    public bool SacredGroveMasterSwordPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool SacredGroveTempleofTimeOwlStatuePoe() // done
    {
        return Has("ShadowCrystal") && Has("DominionRod");
    }

    // Faron Field

    public bool FaronFieldPoe() // done
    {
        return CanCompleteMDH() && Has("ShadowCrystal");
    }

    // Kakariko Gorge

    public bool KakarikoGorgePoe() // done
    {
        return CanCompleteMDH() && Has("ShadowCrystal");
    }

    // Death Mountain

    public bool DeathMountainTrailPoe() // done
    {
        return Has("Boss2") && Has("ShadowCrystal");
    }

    // Lanayru Field

    public bool LanayruFieldBridgePoe() // done
    {
        return CanCompleteMDH() && Has("ShadowCrystal");
    }

    public bool LanayruFieldPoeGrottoLeftPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool LanayruFieldPoeGrottoRightPoe() // done
    {
        return Has("ShadowCrystal");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterPoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownPoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Outside East Castle Town

    public bool EastCastleTownBridgePoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Lake Hylia

    public bool LakeHyliaAlcovePoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool LakeHyliaTowerPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool LakeHyliaDockPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool FlightByFowlLedgePoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool IsleofRichesPoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeCliffPoe() // done
    {
        return Has("ShadowCrystal")
            && CanLaunchBombs()
            && Has("Clawshot")
            && CanCompleteMDH();
    }

    // Upper Zora's River

    public bool UpperZorasRiverPoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Zora's Domain

    public bool ZorasDomainWaterfallPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool ZorasDomainMotherandChildIslePoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Gerudo Desert

    public bool GerudoDesertNorthPeahatPoe() // done
    {
        return Has("Clawshot") && Has("ShadowCrystal");
    }

    public bool GerudoDesertEastPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool GerudoDesertPoeAboveCaveofOrdeals() // done
    {
        return Has("Clawshot") && Has("ShadowCrystal");
    }

    public bool GerudoDesertRockGrottoFirstPoe() // done
    {
        return CanSmash() && Has("ShadowCrystal");
    }

    public bool GerudoDesertRockGrottoSecondPoe() // done
    {
        return CanSmash() && Has("ShadowCrystal");
    }

    public bool OutsideBulblinCampPoe() // done
    {
        return Has("ShadowCrystal");
    }

    // Snowpeak

    public bool SnowpeakAboveFreezardGrottoPoe() // done
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool SnowpeakBlizzardPoe() // done
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool SnowpeakPoeAmongTrees() // done
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool SnowpeakCaveIcePoe() // done
    {
        return Has("B&C") && Has("ShadowCrystal");
    }

    public bool SnowpeakIcySummitPoe() // done
    {
        return Has("ShadowCrystal")
            && (!SettingsStatus["BonksDoDamage"]
            || (SettingsStatus["BonksDoDamage"]
                && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairy())));;
    }

    // Hidden Village

    public bool HiddenVillagePoe() // done
    {
        return Has("FetchQuest", 4)
            && ((Has("Clawshot") && Has("Bow"))
                || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched()))
            && Has("DominionRod")
            && Has("ShadowCrystal");
    }

/* ------------------------------

            Bugs 

------------------------------ */

    public bool FaronFieldFemaleBeetle() // done
    {
        return Has("Boomerang") 
            || Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && (CanDoMapGlitch() || CanDoEBMoonBoots()));
    }

    public bool FaronFieldMaleBeetle() // done
    {
        return true;
    }

    public bool KakarikoGorgeFemalePillBug() // done
    {
        return true;
    }

    public bool KakarikoGorgeMalePillBug() // done
    {
        return true;
    }

    public bool KakarikoVillageFemaleAnt() // done
    {
        return true;
    }

    public bool KakarikoGraveyardMaleAnt() // done
    {
        return true;
    }

    public bool EldinFieldFemaleGrasshopper() // done
    {
        return true;
    }

    public bool EldinFieldMaleGrasshopper() // done
    {
        return true;
    }

    public bool BridgeofEldinFemalePhasmid() // done
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool BridgeofEldinMalePhasmid() // done
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool LakeHyliaBridgeFemaleMantis() // done
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool LakeHyliaBridgeMaleMantis() // done
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool LanayruFieldFemaleStagBeetle() // done
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool LanayruFieldMaleStagBeetle() // done
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool WestHyruleFieldFemaleButterfly() // done
    {
        return Has("Boomerang") 
            || Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()); // || CanGetBugWithLantern for glitched
    }

    public bool WestHyruleFieldMaleButterfly() // done
    {
        return true;
    }

    public bool OutsideSouthCastleTownFemaleLadybug() // done
    {
        return true;
    }

    public bool OutsideSouthCastleTownMaleLadybug() // done
    {
        return true;
    }

    public bool SacredGroveMaleSnail() // done
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool SacredGroveFemaleSnail() // done
    {
        return Has("Clawshot") || Has("Boomerang");
    }

    public bool GerudoDesertFemaleDayfly() // done
    {
        return true;
    }

    public bool GerudoDesertMaleDayfly() // done
    {
        return true;
    }

    public bool UpperZorasRiverFemaleDragonfly() // done
    {
        return true;
    }

    public bool ZorasDomainMaleDragonfly() // done
    {
        return true;
    }

/* ------------------------------

        Ordon Village 

------------------------------ */

    public bool WoodenSwordChest() // done
    {
        return true;
    }

    public bool LinksBasementChest() // done
    {
        return Has("Lantern");
    }

    public bool UliCradleDelivery() // done
    {
        return true;
    }

    public bool OrdonCatRescue() // done
    {
        return Has("FishingRod");
    }

    public bool SeraShopSlingshot() // done
    {
        return true;
    }

    public bool OrdonShield() // done
    {
        return (CanCompletePrologue() && !FaronTwilightCleared())
        || (FaronTwilightCleared() && Has("ShadowCrystal"))
        && (!SettingsStatus["BonksDoDamage"]
            || (SettingsStatus["BonksDoDamage"]
                && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairies())));
    }

    public bool OrdonSword() // done
    {
        return CanCompletePrologue() || FaronTwilightCleared();
    }

    public bool WrestlingWithBo() // done
    {
        return true;
    }

/* ------------------------------

        Kakariko Village

------------------------------ */

    public bool KakarikoInnChest() // done
    {
        return true;
    }

    public bool BarnesBombBag() // done
    {
        return true;
    }

    public bool EldinSpringUnderwaterChest() // done
    {
        return (CanSmash() && Has("IronBoots"))
            || (SettingsStatus["GlitchedLogic"] 
                && HasHeavyMod() 
                && (CanSmash() || CanDoMapGlitch()));
    }

    public bool KakarikoVillageBombRockSpireHeartPiece() // done
    {
        return (CanLaunchBombs() && Has("Boomerang"))
            || (SettingsStatus["GlitchedLogic"] 
                && (CanDoMapGlitch()
                    || (CanLaunchBombs() && (Has("Boomerang") || Has("Clawshot")))));
    }

    public bool KakarikoGraveyardLanternChest() // done
    {
        return Has("Lantern");
    }

    public bool KakarikoWatchtowerChest() // done
    {
        return true;
    }

    public bool KakarikoWatchtowerAlcoveChest() // done
    {
        return CanSmash() || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
    }

    public bool TaloSharpshooting() // done
    {
        return Has("Bow") && Has("Boss2");
    }

    public bool KakarikoVillageMaloMartHylianShield() // done
    {
        return true;
    }

    public bool KakarikoVillageMaloMartHawkeye() // done
    {
        return Has("Bow") && Has("Boss2");
    }

    public bool RutelasBlessing() // done
    {
        return Has("GateKeys") || SettingsStatus["SmallKeysKeysy"];
    }

    public bool GiftFromRalis() // done
    {
        return (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
            && Has("AsheisSketch");
    }

    public bool KakarikoGraveyardGoldenWolf() // done
    {
        return Has("ShadowCrystal")
            && RoomSnowpeakClimb.GetComponent<RoomBehaviour>().isAccessible
            && (Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || SettingsStatus["EarlySnowpeak"]
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool RenadosLetter() // done
    {
        return Has("Boss6");
    }

    public bool IliaMemoryReward() // done
    {
        return Has("FetchQuest", 4);
    }

    // Poes

    public bool KakarikoVillageBombShopPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool KakarikoVillageWatchtowerPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool KakarikoGraveyardOpenPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool KakarikoGraveyardGravePoe() // done
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Eldin Lantern Cave

------------------------------ */

    public bool EldinLanternCaveFirstChest() // done
    {
        return CanBurnWebs();
    }

    public bool EldinLanternCaveSecondChest() // done
    {
        return CanBurnWebs();
    }

    public bool EldinLanternCaveLanternChest() // done
    {
        return Has("Lantern");
    }

    // Poes

    public bool EldinLanternCavePoe() // done
    {
        return CanBurnWebs() && Has("ShadowCrystal");
    }

/* ------------------------------

        Eldin Stockcave

------------------------------ */

    public bool EldinStockcaveUpperChest() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && Has("Clawshot"));
    }

    public bool EldinStockcaveLanternChest() // done
    {
        return (Has("IronBoots") 
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("Clawshot"))))
            && Has("Lantern");
    }

    public bool EldinStockcaveLowestChest() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("Clawshot")));
    }

/* ------------------------------

        Lake Lantern Cave

------------------------------ */

    public bool LakeLanternCaveFirstChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveSecondChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveThirdChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveFourthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveFifthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveSixthChest() // done
    {
        return Has("Lantern") && CanSmash();
    }

    public bool LakeLanternCaveSeventhChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveEighthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveNinthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveTenthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveEleventhChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveTwelfthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveThirteenthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveFourteenthChest() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveEndLanternChest() // done
    {
        return Has("Lantern") && CanSmash();
    }

    // Poes

    public bool LakeLanternCaveFirstPoe() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"]
            || SettingsStatus["GlitchedLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveSecondPoe() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"]
            || SettingsStatus["GlitchedLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveFinalPoe() // done
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"]
            || SettingsStatus["GlitchedLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

/* ------------------------------

        Lanayru Spring

------------------------------ */

    public bool LanayruSpringUnderwaterLeftChest() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LanayruSpringUnderwaterRightChest() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LanayruSpringBackRoomLeftChest() // done
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots());
    }

    public bool LanayruSpringBackRoomRightChest() // done
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots());
    }

    public bool LanayruSpringBackRoomLanternChest() // done
    {
        return (Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots())) 
            && Has("Lantern");
    }

    public bool LanayruSpringWestDoubleClawshotChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool LanayruSpringEastDoubleClawshotChest() // done
    {
        return Has("Clawshot", 2);
    }

/* ------------------------------

        Castle Town

------------------------------ */

    public bool AgithaFemaleAntReward() // done
    {
        return Has("GoldenBug", 1);
    }

    public bool AgithaFemaleBeetleReward() // done
    {
        return Has("GoldenBug", 2);
    }

    public bool AgithaFemaleButterflyReward() // done
    {
        return Has("GoldenBug", 3);
    }

    public bool AgithaFemaleDayflyReward() // done
    {
        return Has("GoldenBug", 4);
    }

    public bool AgithaFemaleDragonflyReward() // done
    {
        return Has("GoldenBug", 5);
    }

    public bool AgithaFemaleGrasshopperReward() // done
    {
        return Has("GoldenBug", 6);
    }

    public bool AgithaFemaleLadybugReward() // done
    {
        return Has("GoldenBug", 7);
    }

    public bool AgithaFemaleMantisReward() // done
    {
        return Has("GoldenBug", 8);
    }

    public bool AgithaFemalePhasmidReward() // done
    {
        return Has("GoldenBug", 9);
    }

    public bool AgithaFemalePillBugReward() // done
    {
        return Has("GoldenBug", 10);
    }

    public bool AgithaFemaleSnailReward() // done
    {
        return Has("GoldenBug", 11);
    }

    public bool AgithaFemaleStagBeetleReward() // done
    {
        return Has("GoldenBug", 12);
    }

    public bool AgithaMaleAntReward() // done
    {
        return Has("GoldenBug", 13);
    }

    public bool AgithaMaleBeetleReward() // done
    {
        return Has("GoldenBug", 14);
    }

    public bool AgithaMaleButterflyReward() // done
    {
        return Has("GoldenBug", 15);
    }

    public bool AgithaMaleDayflyReward() // done
    {
        return Has("GoldenBug", 16);
    }

    public bool AgithaMaleDragonflyReward() // done
    {
        return Has("GoldenBug", 17);
    }

    public bool AgithaMaleGrasshopperReward() // done
    {
        return Has("GoldenBug", 18);
    }

    public bool AgithaMaleLadybugReward() // done
    {
        return Has("GoldenBug", 19);
    }

    public bool AgithaMaleMantisReward() // done
    {
        return Has("GoldenBug", 20);
    }

    public bool AgithaMalePhasmidReward() // done
    {
        return Has("GoldenBug", 21);
    }

    public bool AgithaMalePillBugReward() // done
    {
        return Has("GoldenBug", 22);
    }

    public bool AgithaMaleSnailReward() // done
    {
        return Has("GoldenBug", 23);
    }

    public bool AgithaMaleStagBeetleReward() // done
    {
        return Has("GoldenBug", 24);
    }

    public bool CastleTownMaloMartMagicArmor() // done
    {
        return Has("Wallet", 1)
                || SettingsStatus["WalletIncrease"]
                || SettingsStatus["IgnoreWalletLogic"];
    }

    public bool CharloDonationBlessing() // done
    {
        return true;
    }

    public bool STARPrize1() // done
    {
        return Has("Clawshot");
    }

    public bool STARPrize2() // done
    {
        return Has("Clawshot", 2);
    }

    public bool Jovani20PoeSoulReward() // done
    {
        return Has("PoeSoul", 20)
            && Has("ShadowCrystal")
            && (SettingsStatus["SkipMDH"] || Has("Boss3"));
    }

    public bool Jovani60PoeSoulReward() // done
    {
        return Has("PoeSoul", 60)
            && Has("ShadowCrystal")
            && (SettingsStatus["SkipMDH"] || Has("Boss3"));
    }

    public bool TelmaInvoice() // done
    {
        return Has("FetchQuest", 1);
    }

    public bool DoctorsOfficeBalconyChest() // done
    {
        return Has("ShadowCrystal") && Has("FetchQuest", 2);
    }

    // Poes

    public bool JovaniHousePoe() // done
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Bulblin Camp

------------------------------ */

    public bool BulblinCampFirstChestUnderTowerAtEntrance() // done
    {
        return true;
    }

    public bool BulblinCampSmallChestinBackofCamp() // done
    {
        return true;
    }

    public bool BulblinCampRoastedBoar() // done
    {
        return HasDamagingItem();
    }

    public bool BulblinGuardKey() // done
    {
        return CanDefeatBulblin();
    }

    public bool OutsideArbitersGroundsLanternChest() // done
    {
        return Has("Lantern");
    }

    // Poes

    public bool BulblinCampPoe() // done
    {
        return (
            Has("ShadowCrystal")
            && 
                (Has("DesertKeys") 
                || SettingsStatus["SmallKeysKeysy"] 
                || SettingsStatus["EarlyArbiters"]
                )
            )
            || (SettingsStatus["GlitchedLogic"] 
            && 
            (
                (Has("ShadowCrystal") 
                && (Has("DesertKeys") 
                        || (
                            (CanDoMapGlitch() && Has("Sword")) 
                                || SettingsStatus["SmallKeysKeysy"]
                            )
                    )
                ) || SettingsStatus["EarlyArbiters"]
            )
            );
    }

    public bool OutsideArbitersGroundsPoe() // done
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Cave of Ordeals

------------------------------ */

    public bool CaveofOrdealsGreatFairyReward() // done
    {
        return Has("Clawshot", 2)
            && CanDefeatPoe()
            && CanDefeatFreezard()
            && CanDefeatDarknut();
    }

    // Poes

    public bool CaveofOrdealsFloor17Poe() // done
    {
        return (Has("Spinner")
            || (SettingsStatus["GlitchedLogic"] && Has("Clawshot") && CanDoLJA()))
            && Has("ShadowCrystal");
    }

    public bool CaveofOrdealsFloor33Poe() // done
    {
        return Has("ShadowCrystal")
            && Has("DominionRod", 2)
            && CanDefeatBeamos();
    }

    public bool CaveofOrdealsFloor44Poe() // done
    {
        return Has("ShadowCrystal")
            && (Has("Clawshot", 2)
                || (SettingsStatus["GlitchedLogic"] && Has("Clawshot") && CanDoLJA()))
            && (Has("Bow") || Has("B&C"));
    }

/* ------------------------------

        Dungeon Checks 

------------------------------ */

/* ------------------------------

        Forest Temple 

------------------------------ */

    public bool ForestTempleEntranceVinesChest() // done
    {
        return CanDefeatWalltula();
    }

    public bool ForestTempleCentralChestBehindStairs() // done
    {
        return Has("Boomerang")
            || (SettingsStatus["GlitchedLogic"] 
                && Has("Boomerang") 
                && (CanDefeatBombling() || CanSmash()));
    }

    public bool ForestTempleCentralNorthChest() // done
    {
        return Has("Lantern")
            || (SettingsStatus["GlitchedLogic"] 
                && CanDoLJA() 
                && RoomForestTempleWestWing.GetComponent<RoomBehaviour>().isAccessible);
    }

    public bool ForestTempleWindlessBridgeChest() // done
    {
        return true;
    }

    public bool ForestTempleSecondMonkeyUnderBridgeChest() // done
    {
        return Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"];
    }

    public bool ForestTempleTotemPoleChest() // done
    {
        return !SettingsStatus["GlitchedLogic"] || CanDefeatBombling() || CanSmash();
    }

    public bool ForestTempleWestTileWormRoomVinesChest() // done
    {
        return !SettingsStatus["GlitchedLogic"] || CanDefeatBombling() || CanSmash();
    }

    public bool ForestTempleWestDekuLikeChest() // done
    {
        return CanDefeatWalltula() || SettingsStatus["GlitchedLogic"];
    }

    public bool ForestTempleBigBabaKey() // done
    {
        return (CanDefeatWalltula() || SettingsStatus["GlitchedLogic"]) && CanDefeatBigBaba();
    }

    public bool ForestTempleGaleBoomerang() // done
    {
        return CanDefeatOok() || (SettingsStatus["GlitchedLogic"] && HasBombs());
    }

    public bool ForestTempleWestTileWormChestBehindStairs() // done
    {
        return Has("Boomerang")
            || (SettingsStatus["GlitchedLogic"] 
                && Has("Boomerang") 
                && (CanDefeatBombling() || CanSmash()));
    }

    public bool ForestTempleCentralChestHangingFromWeb() // done
    {
        return CanCutHangingWeb()
            || (SettingsStatus["GlitchedLogic"] && CanDoJSMoonBoots());
    }

    public bool ForestTempleBigKeyChest() // done
    {
        return Has("Boomerang");
    }

    public bool ForestTempleEastWaterCaveChest() // done
    {
        return true;
    }

    public bool ForestTempleNorthDekuLikeChest() // done
    {
        return Has("Boomerang")
            || (SettingsStatus["GlitchedLogic"] 
                && HasBombs() 
                && Has("Sword") 
                && Has("Clawshot"));
    }

    public bool ForestTempleEastTileWormChest() // done
    {
        return (
                (
                    CanDefeatWalltula()
                    && CanDefeatSkulltula()
                    && CanDefeatTileWorm()
                    && Has("Boomerang")
                )
                || 
                (
                    SettingsStatus["GlitchedLogic"] 
                    && 
                    (
                        HasBombs()
                        || CanDoBSMoonBoots()
                        || CanDoJSMoonBoots()
                        || Has("Boomerang")
                    )
                )
            )
            && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool ForestTempleDiababaHeartContainer() // done
    {
        return CanDefeatDiababa();
    }

    public bool ForestTempleDungeonReward() // done
    {
        return CanDefeatDiababa();
    }

/* ------------------------------

            Goron Mines 

------------------------------ */

    public bool GoronMinesEntranceChest() // done
    {
        return (CanPressMinesSwitch() && CanBreakWoodenDoor())
            || (SettingsStatus["GlitchedLogic"] && (CanDoBSMoonBoots() || CanBreakWoodenDoor()));
    }

    public bool GoronMinesMainMagnetRoomBottomChest() // done
    {
        return true;
    }

    public bool GoronMinesGorAmatoChest() // done
    {
        return Has("IronBoots");
    }

    public bool GoronMinesGorAmatoKeyShard() // done
    {
        return Has("IronBoots");
    }

    public bool GoronMinesGorAmatoSmallChest() // done
    {
        return Has("IronBoots");
    }

    public bool GoronMinesMagnetMazeChest() // done
    {
        return Has("IronBoots");
    }

    public bool GoronMinesCrystalSwitchRoomUnderwaterChest() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool GoronMinesCrystalSwitchRoomSmallChest() // done
    {
        return Has("IronBoots");
    }

    public bool GoronMinesAfterCrystalSwitchRoomMagnetWallChest() // done
    {
        return Has("IronBoots");
    }

    public bool GoronMinesOutsideBeamosChest() // done
    {
        return true;
    }

    public bool GoronMinesGorEbizoKeyShard() // done
    {
        return true;
    }

    public bool GoronMinesGorEbizoChest() // done
    {
        return true;
    }

    public bool GoronMinesChestBeforeDangoro() // done
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
    }

    public bool GoronMinesDangoroChest() // done
    {
        return Has("IronBoots") && CanDefeatDangoro();
    }

    public bool GoronMinesBeamosRoomChest() // done
    {
        return Has("IronBoots") 
            && CanDefeatDangoro() 
            && (Has("Bow")
                || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
    }

    public bool GoronMinesGorLiggsKeyShard() // done
    {
        return Has("IronBoots") 
            && CanDefeatDangoro() 
            && (Has("Bow")
                || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
    }

    public bool GoronMinesGorLiggsChest() // done
    {
        return Has("IronBoots") 
            && CanDefeatDangoro() 
            && (Has("Bow")
                || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
    }

    public bool GoronMinesMainMagnetRoomTopChest() // done
    {
        return CanDefeatDangoro()
            && (
                (
                    Has("IronBoots")
                    && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                    && Has("Bow")
                )
                || 
                (
                    SettingsStatus["GlitchedLogic"] 
                    && CanDefeatBeamos() 
                    && RoomGoronMinesUpperEastWing.GetComponent<RoomBehaviour>().isAccessible
                )
            );
    }

    public bool GoronMinesOutsideClawshotChest() // done
    {
        return Has("Clawshot") 
            && (Has("Bow") || Has("Slingshot") || SettingsStatus["GlitchedLogic"]);
    }

    public bool GoronMinesOutsideUnderwaterChest() // done
    {
        return (Has("IronBoots")
            && (HasWaterBombs() || Has("Sword")))
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool GoronMinesFyrusHeartContainer() // done
    {
        return CanDefeatFyrus();
    }

    public bool GoronMinesDungeonReward() // done
    {
        return CanDefeatFyrus();
    }

/* ------------------------------

        Lakebed Temple 

------------------------------ */

    public bool LakebedTempleLobbyLeftChest() // done
    {
        return Has("ZoraArmor");
    }

    public bool LakebedTempleLobbyRearChest() // done
    {
        return Has("ZoraArmor");
    }

    public bool LakebedTempleStalactiteRoomChest() // done
    {
        return CanLaunchBombs();
    }

    public bool LakebedTempleCentralRoomSmallChest() // done
    {
        return true;
    }

    public bool LakebedTempleCentralRoomChest() // done
    {
        return true;
    }

    public bool LakebedTempleEastLowerWaterwheelStalactiteChest() // done
    {
        return CanLaunchBombs()
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
    }

    public bool LakebedTempleEastSecondFloorSouthwestChest() // done
    {
        return true;
    }

    public bool LakebedTempleEastSecondFloorSoutheastChest() // done
    {
        return CanLaunchBombs()
            || (Has("Clawshot") && CanSmash());
    }

    public bool LakebedTempleEastWaterSupplySmallChest() // done
    {
        return (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && 
            (
                (
                    (CanLaunchBombs() || Has("Clawshot"))
                    && Has("IronBoots")
                    && CanSmash()
                )
            || SettingsStatus["GlitchedLogic"]
            );
    }

    public bool LakebedTempleBeforeDekuToadAlcoveChest() // done
    {
        return (
                CanDefeatDekuToad() 
                && (Has("LTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
                && Has("ZoraArmor") 
                && Has("IronBoots") 
                && HasWaterBombs() 
                && Has("Clawshot")
            ) || 
            (
                (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]) 
                && (CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
            ) || 
            (
                SettingsStatus["GlitchedLogic"] 
                && (CanDoLJA() 
                    || ((Has("LTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]) 
                        && (CanLaunchBombs() || Has("Clawshot"))))
            );
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterLeftChest() // done
    {
        return ((CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("ZoraArmor")
            && Has("IronBoots"))
            || (
                SettingsStatus["GlitchedLogic"] 
                && 
                (
                    (
                        CanDoLJA() && (CanSkipKeyToDekuToad() || Has("LTSmallKey", 1))
                    ) 
                    || 
                    (
                        (CanSkipKeyToDekuToad() || Has("LTSmallKey", 3)) 
                        && Has("Clawshot") 
                        && CanLaunchBombs()
                    ) 
                    && HasHeavyMod() 
                    && (HasWaterBombs() || Has("ZoraArmor"))
                )
            );
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterRightChest() //done
    {
        return ((CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("ZoraArmor")
            && Has("IronBoots"))
            || (
                SettingsStatus["GlitchedLogic"] 
                && 
                (
                    (
                        CanDoLJA() && (CanSkipKeyToDekuToad() || Has("LTSmallKey", 1))
                    ) 
                    || 
                    (
                        (CanSkipKeyToDekuToad() || Has("LTSmallKey", 3)) 
                        && Has("Clawshot") 
                        && CanLaunchBombs()
                    ) 
                    && HasHeavyMod() 
                    && (HasWaterBombs() || Has("ZoraArmor"))
                )
            );
    }

    public bool LakebedTempleDekuToadChest() // done
    {
        return CanDefeatDekuToad()
            && 
            (
                (CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
                && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                && Has("ZoraArmor")
                && Has("IronBoots")
                && HasWaterBombs())
            || (
                SettingsStatus["GlitchedLogic"] 
                && 
                (
                    (
                        CanDoLJA() && (CanSkipKeyToDekuToad() || Has("LTSmallKey", 1))
                    ) 
                    || 
                    (
                        (CanSkipKeyToDekuToad() || Has("LTSmallKey", 3)) 
                        && Has("Clawshot") 
                        && CanLaunchBombs()
                    ) 
                    && HasHeavyMod() 
                    && (HasWaterBombs() || Has("ZoraArmor"))
                )
            );
    }

    public bool LakebedTempleChandelierChest() // done
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleCentralRoomSpireChest() // done
    {
        return CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots");
    }

    public bool LakebedTempleEastWaterSupplyClawshotChest() // done
    {
        return (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && (
                (Has("IronBoots") && CanSmash())
                || 
                (SettingsStatus["GlitchedLogic"] && CanLaunchBombs())
            );
    }

    public bool LakebedTempleWestLowerSmallChest() // done
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplySmallChest() // done
    {
        return CanLaunchBombs() 
            && (Has("IronBoots") || SettingsStatus["GlitchedLogic"])
            && Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplyChest() // done
    {
        return CanLaunchBombs() 
            && (Has("IronBoots") || SettingsStatus["GlitchedLogic"])
            && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorSouthwestUnderwaterChest() // done
    {
        return CanLaunchBombs() && Has("IronBoots") && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorCentralSmallChest() // done
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorNortheastChest() // done
    {
        return CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorSoutheastChest() // done
    {
        return CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleBigKeyChest() // done
    {
        return Has("ZoraArmor")
            && CanLaunchBombs()
            && (Has("IronBoots") || SettingsStatus["GlitchedLogic"])
            && Has("Clawshot")
            && HasWaterBombs();
    }

    public bool LakebedTempleUnderwaterMazeSmallChest() // done
    {
        return Has("ZoraArmor") && CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleEastLowerWaterwheelBridgeChest() // done
    {
        return 
        (
            CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
        )
        || 
        (SettingsStatus["GlitchedLogic"] 
            && 
            (
                CanDoLJA() 
                || (Has("Clawshot") && HasBombs()) 
                || (RoomLakebedTempleEastWingSecondFloor.GetComponent<RoomBehaviour>().isAccessible 
                    && (Has("Clawshot") || CanLaunchBombs()) 
                    && (Has("ShadowCrystal") || (HasBombs() && Has("Sword")))
                    ) 
                || (RoomLakebedTempleWestWing.GetComponent<RoomBehaviour>().isAccessible 
                    && CanLaunchBombs())
            )
        );
    }

    public bool LakebedTempleMorpheelHeartContainer() // done
    {
        return CanDefeatMorpheel();
    }

    public bool LakebedTempleDungeonReward() // done
    {
        return CanDefeatMorpheel();
    }

/* ------------------------------

        Arbiter's Grounds 

------------------------------ */

    public bool ArbitersGroundsEntranceChest() // done
    {
        return CanBreakWoodenDoor();
    }

    public bool ArbitersGroundsTorchRoomWestChest() // done
    {
        return true;
    }

    public bool ArbitersGroundsTorchRoomEastChest() // done
    {
        return true;
    }

    public bool ArbitersGroundsEastLowerTurnableRedeadChest() // done
    {
        return Has("ShadowCrystal");
    }

    public bool ArbitersGroundsEastUpperTurnableChest() // done
    {
        return Has("AGSmallKey", 2) || SettingsStatus["SmallKeysKeysy"];
    }

    public bool ArbitersGroundsEastUpperTurnableRedeadChest() // done
    {
        return (Has("AGSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && HasDamagingItem();
    }

    public bool ArbitersGroundsGhoulRatRoomChest() // done
    {
        return (Has("AGSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatBubble()
            && CanDefeatStalchild()
            && CanDefeatRedeadKnight();
    }

    public bool ArbitersGroundsWestSmallChestBehindBlock() // done
    {
        return true;
    }

    public bool ArbitersGroundsWestChandelierChest() // done
    {
        return (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsWestStalfosWestChest() // done
    {
        return CanBreakWoodenDoor()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatGhoulRat();
    }

    public bool ArbitersGroundsWestStalfosNortheastChest() // done
    {
        return CanBreakWoodenDoor()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatGhoulRat();
    }

    public bool ArbitersGroundsNorthTurningRoomChest() // done
    {
        return Has("Clawshot");
    }

    public bool ArbitersGroundsDeathSwordChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && CanDefeatDeathSword();
    }

    public bool ArbitersGroundsSpinnerRoomFirstSmallChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomSecondSmallChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomLowerCentralSmallChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomStalfosAlcoveChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomLowerNorthChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsBigKeyChest() // done
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && Has("Spinner")
            && CanSmash();
    }

    public bool ArbitersGroundsStallordHeartContainer() // done
    {
        return CanDefeatStallord();
    }

    // Poes

    public bool ArbitersGroundsTorchRoomPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool ArbitersGroundsEastTurningRoomPoe() // done
    {
        return Has("ShadowCrystal") && Has("Clawshot");
    }

    public bool ArbitersGroundsHiddenWallPoe() // done
    {
        return (Has("AGSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatRedeadKnight()
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsWestPoe() // done
    {
        return (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

/* ------------------------------

        Snowpeak Ruins 

------------------------------ */

    public bool SnowpeakRuinsLobbyEastArmorChest() // done
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsLobbyWestArmorChest() // done
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsMansionMap() // done
    {
        return true;
    }

    public bool SnowpeakRuinsEastCourtyardBuriedChest() // done
    {
        return Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsEastCourtyardChest() // done
    {
        return true;
    }

    public bool SnowpeakRuinsOrdonPumpkinChest() // done
    {
        return CanDefeatChilfos();
    }

    public bool SnowpeakRuinsWestCourtyardBuriedChest() // done
    {
        return Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsWoodenBeamCentralChest() // done
    {
        return CanDefeatIceKeese();
    }

    public bool SnowpeakRuinsWoodenBeamNorthwestChest() // done
    {
        return CanDefeatIceKeese();
    }

    public bool SnowpeakRuinsCourtyardCentralChest() // done
    {
        return Has("B&C") || 
            (
                HasBombs()
                    && (Has("SRSmallKey", 2) 
                        || (Has("Cheese") && !SettingsStatus["GlitchedLogic"])
                        || SettingsStatus["SmallKeysKeysy"])
            );
    }

    public bool SnowpeakRuinsBallandChain() // done
    {
        return CanDefeatDarkhammer();
    }

    public bool SnowpeakRuinsChestAfterDarkhammer() // done
    {
        return CanDefeatDarkhammer() && Has("B&C");
    }

    public bool SnowpeakRuinsBrokenFloorChest() // done
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsWoodenBeamChandelierChest() // done
    {
        return Has("B&C")
            && (Has("Cheese") || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsLobbyChandelierChest() // done
    {
        return Has("B&C")
            && ((Has("Cheese") && Has("SRSmallKey", 3))
                || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsNortheastChandelierChest() // done
    {
        return CanDefeatChilfos() && Has("B&C");
    }

    public bool SnowpeakRuinsWestCannonRoomCentralChest() // done
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsWestCannonRoomCornerChest() // done
    {
        return CanSmash();
    }

    public bool SnowpeakRuinsChapelChest() // done
    {
        return CanDefeatChilfos();
    }

    public bool SnowpeakRuinsBlizzetaHeartContainer() // done
    {
        return CanDefeatBlizzeta();
    }

    public bool SnowpeakRuinsDungeonReward() // done
    {
        return CanDefeatBlizzeta();
    }

    // Poes

    public bool SnowpeakRuinsLobbyPoe() // done
    {
        return Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsLobbyArmorPoe() // done
    {
        return Has("ShadowCrystal") && Has("B&C");
    }

    public bool SnowpeakRuinsIceRoomPoe() // done
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Temple of Time

------------------------------ */

    public bool TempleofTimeLobbyLanternChest() // done
    {
        return Has("Lantern");
    }

    public bool TempleofTimeFirstStaircaseGohmaGateChest() // done
    {
        return CanDefeatYoungGohma();
    }

    public bool TempleofTimeFirstStaircaseWindowChest() // done
    {
        return HasRangedItem();
    }

    public bool TempleofTimeFirstStaircaseArmosChest() // done
    {
        return HasRangedItem() && CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberEastChest() // done
    {
        return CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberNorthChest() // done
    {
        return true;
    }

    public bool TempleofTimeMovingWallBeamosRoomChest() // done
    {
        return Has("Bow");
    }

    public bool TempleofTimeScalesGohmaChest() // done
    {
        return CanDefeatYoungGohma() && CanDefeatBabyGohma();
    }

    public bool TempleofTimeGilloutineChest() // done
    {
        return true;
    }

    public bool TempleofTimeChestBeforeDarknut() // done
    {
        return CanDefeatArmos() && CanDefeatBabyGohma() && CanDefeatYoungGohma();
    }

    public bool TempleofTimeDarknutChest() // done
    {
        return CanDefeatDarknut();
    }

    public bool TempleofTimeScalesUpperChest() // done
    {
        return Has("Spinner") && Has("Clawshot");
    }

    public bool TempleofTimeFloorSwitchPuzzleRoomUpperChest() // done
    {
        return Has("Clawshot");
    }

    public bool TempleofTimeBigKeyChest() // done
    {
        return CanDefeatHelmasaur() && Has("Clawshot");
    }

    public bool TempleofTimeMovingWallDinalfosRoomChest() // done
    {
        return CanDefeatDinalfos() && Has("DominionRod") && Has("Bow");
    }

    public bool TempleofTimeArmosAntechamberStatueChest() // done
    {
        return Has("DominionRod");
    }

    public bool TempleofTimeArmogohmaHeartContainer() // done
    {
        return CanDefeatArmogohma();
    }

    public bool TempleofTimeDungeonReward() // done
    {
        return CanDefeatArmogohma();
    }

    // Poes

    public bool TempleofTimePoeBehindGate() // done
    {
        return Has("ShadowCrystal") && Has("DominionRod");
    }

    public bool TempleofTimePoeAboveScales() // done
    {
        return Has("ShadowCrystal") && Has("Spinner") && Has("Clawshot");
    }

/* ------------------------------

        City in the Sky 

------------------------------ */

    public bool CityinTheSkyUnderwaterEastChest() // done
    {
        return Has("IronBoots");
    }

    public bool CityinTheSkyUnderwaterWestChest() // done
    {
        return Has("IronBoots");
    }

    public bool CityinTheSkyWestWingFirstChest() // done
    {
        return true;
    }

    public bool CityinTheSkyEastFirstWingChestAfterFans() // done
    {
        return Has("Clawshot");
    }

    public bool CityinTheSkyEastTileWormSmallChest() // done
    {
        return Has("Clawshot");
    }

    public bool CityinTheSkyEastWingAfterDinalfosLedgeChest() // done
    {
        return Has("Clawshot") && CanDefeatTileWorm() && CanDefeatDinalfos();
    }

    public bool CityinTheSkyEastWingAfterDinalfosAlcoveChest() // done
    {
        return Has("Clawshot") && CanDefeatTileWorm() && CanDefeatDinalfos();
    }

    public bool CityinTheSkyAeralfosChest() // done
    {
        return Has("Clawshot")
            && Has("IronBoots")
            && CanDefeatDinalfos()
            && (CanDefeatTileWorm() || SettingsStatus["GlitchedLogic"])
            && CanDefeatAeralfos();
    }

    public bool CityinTheSkyEastWingLowerLevelChest() // done
    {
        return Has("Clawshot", 2) 
            && ((CanDefeatTileWorm() && CanDefeatDinalfos()) 
                || SettingsStatus["GlitchedLogic"]);
    }

    public bool CityinTheSkyWestWingBabaBalconyChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestWingNarrowLedgeChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestWingTileWormChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyBabaTowerTopSmallChest() // done
    {
        return CanDefeatBabaSerpent() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerNarrowLedgeChest() // done
    {
        return CanDefeatBabaSerpent() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerAlcoveChest() // done
    {
        return CanDefeatBabaSerpent() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenCornerChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLoneIslandChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLowerChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLedgeChest() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyCentralOutsideLedgeChest() // done
    {
        return CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyCentralOutsidePoeIslandChest() // done
    {
        return CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyBigKeyChest() // done
    {
        return Has("Clawshot")
            && CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("IronBoots")
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyChestBelowBigKeyChest() // done
    {
        return CanDefeatHelmasaur();
    }

    public bool CityinTheSkyChestBehindNorthFan() // done
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyArgorokHeartContainer() // done
    {
        return CanDefeatArgorok();
    }

    public bool CityinTheSkyDungeonReward() // done
    {
        return CanDefeatArgorok();
    }

    // Poes

    public bool CityinTheSkyGardenIslandPoe() // done
    {
        return Has("Clawshot", 2) && Has("ShadowCrystal");
    }

    public bool CityinTheSkyPoeAboveCentralFan() // done
    {
        return CanDefeatWalltula() && Has("ShadowCrystal");
    }

/* ------------------------------

        Palace of Twilight

------------------------------ */

    public bool PalaceofTwilightWestWingFirstRoomCentralChest() // done
    {
        return CanDefeatZantHead();
    }

    public bool PalaceofTwilightWestWingChestBehindWallofDarkness() // done
    {
        return Has("Sword", 4) && Has("Clawshot");
    }

    public bool PalaceofTwilightWestWingSecondRoomCentralChest() // done
    {
        return Has("Clawshot")
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomLowerSouthChest() // done
    {
        return Has("Clawshot")
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomSoutheastChest() // done
    {
        return Has("Clawshot", 2)
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomZantHeadChest() // done
    {
        return Has("Clawshot") && CanDefeatZantHead();
    }

    public bool PalaceofTwilightEastWingFirstRoomNorthSmallChest() // done
    {
        return Has("Clawshot");
    }

    public bool PalaceofTwilightEastWingSecondRoomNortheastChest() // done
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot", 2)
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomNorthwestChest() // done
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot")
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomSouthwestChest() // done
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot", 2)
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomSoutheastChest() // done
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot", 2)
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomEastAlcove() // done
    {
        return Has("Sword", 4) || 
            (Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && !SettingsStatus["GlitchedLogic"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomWestAlcove() // done
    {
        return Has("Sword", 4) || 
            (Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && !SettingsStatus["GlitchedLogic"]);
    }

    public bool PalaceofTwilightCollectBothSols() // done
    {
        return Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralFirstRoomChest() // done
    {
        return CanDefeatZantHead() && Has("Sword", 4);
    }

    public bool PalaceofTwilightBigKeyChest() // done
    {
        return CanDefeatZantHead()
            && Has("Clawshot", 2)
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralOutdoorChest() // done
    {
        return CanDefeatZantHead()
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralTowerChest() // done
    {
        return CanDefeatZantHead()
            && Has("Clawshot")
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 6) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightZantHeartContainer() // done
    {
        return CanDefeatZant();
    }

/* ------------------------------

        Hyrule Castle 

------------------------------ */

    public bool HyruleCastleGraveyardGraveSwitchRoomRightChest() // done
    {
        return CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomFrontLeftChest() // done
    {
        return CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomBackLeftChest() // done
    {
        return CanSmash();
    }

    public bool HyruleCastleGraveyardOwlStatueChest() // done
    {
        return CanSmash() && Has("Lantern") && Has("DominionRod", 2);
    }

    public bool HyruleCastleEastWingBoomerangPuzzleChest() // done
    {
        return Has("Boomerang");
    }

    public bool HyruleCastleEastWingBalconyChest() // done
    {
        return Has("Boomerang");
    }

    public bool HyruleCastleWestCourtyardNorthSmallChest() // done
    {
        return CanDefeatBokoblin() || SettingsStatus["GlitchedLogic"];
    }

    public bool HyruleCastleWestCourtyardCentralSmallChest() // done
    {
        return CanDefeatBokoblin() || SettingsStatus["GlitchedLogic"];
    }

    public bool HyruleCastleKingBulblinKey() // done
    {
        return CanDefeatKingBulblinCastle();
    }

    public bool HyruleCastleMainHallNortheastChest() // done
    {
        return CanDefeatBokoblin() && CanDefeatLizalfos() && Has("Clawshot");
    }

    public bool HyruleCastleLanternStaircaseChest() // done
    {
        return (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")))
            && CanDefeatDarknut() 
            && Has("Boomerang");
    }

    public bool HyruleCastleMainHallSouthwestChest() // done
    {
        return CanDefeatDarknut()
            && Has("Clawshot", 2)
            && CanKnockDownHCPainting()
            && Has("Boomerang")
            && Has("Lantern");
    }

    public bool HyruleCastleMainHallNorthwestChest() // done
    {
        return CanDefeatDarknut()
            && Has("Clawshot", 2)
            && CanKnockDownHCPainting()
            && Has("Boomerang")
            && Has("Lantern");
    }

    public bool HyruleCastleSoutheastBalconyTowerChest() // done
    {
        return CanDefeatAeralfos();
    }

    public bool HyruleCastleBigKeyChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFirstChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSecondChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomThirdChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFourthChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFifthChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFirstSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSecondSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomThirdSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFourthSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFifthSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSixthSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSeventhSmallChest() // done
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomEighthSmallChest() // done
    {
        return true;
    }

/* ------------------------------

            Rooms 

------------------------------ */

/* ------------------------------

        Ordona Province 

------------------------------ */

    public bool OrdonProvince(string neighbour) // done
    {
        if (neighbour == "OrdonRanchGrotto")
        {
            return CanCompletePrologue() && Has("ShadowCrystal");
        }

        else if (neighbour == "SouthFaronWoods")
        {
            return (Has("Sword") && Has("Slingshot")) || SettingsStatus["SkipPrologue"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonRanchGrotto(string neighbour) // done
    {
        if (neighbour == "OrdonProvince")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Faron Province 

------------------------------ */

// Faron Woods

    public bool FaronMistArea(string neighbour) // done
    {
        if (neighbour == "SouthFaronWoodsCave")
        {
            return true;
        }

        else if (neighbour == "FaronMistCave")
        {
            return Has("Lantern")
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "NorthFaronWoods")
        {
            return CanCompletePrologue() && (Has("ShadowCrystal") || Has("Lantern"))
                || (SettingsStatus["GlitchedLogic"] &&
                    ((CanDoMapGlitch()
                    || (Has("FaronKeys") || SettingsStatus["SmallKeysKeysy"])
                    || (Has("ShadowCrystal") && SettingsStatus["SkipFaronTwilight"])
                    || SettingsStatus["SkipPrologue"])
                        && (Has("ShadowCrystal") || Has("Lantern"))));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool FaronMistCave(string neighbour) // done
    {
        if (neighbour == "FaronMistArea")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool NorthFaronWoods(string neighbour) // done
    {
        if (neighbour == "FaronMistArea")
        {
            return true;
        }

        else if (neighbour == "ForestTempleEntrance")
        {
            return true;
        }

        else if (neighbour == "LostWoods")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SouthFaronWoodsCave(string neighbour) // done
    {
        if (neighbour == "SouthFaronWoods")
        {
            return CanBurnWebs() || Has("ShadowCrystal") || SettingsStatus["SkipPrologue"];
        }

        else if (neighbour == "FaronMistArea")
        {
            return CanBurnWebs() || Has("ShadowCrystal") || SettingsStatus["SkipPrologue"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SouthFaronWoods(string neighbour) // done
    {
        if (neighbour == "OrdonProvince")
        {
            return true;
        }

        else if (neighbour == "FaronField")
        {
            return CanClearForest()
                || (SettingsStatus["GlitchedLogic"] && CanClearForestGlitched());
        }

        else if (neighbour == "SouthFaronWoodsCave")
        {
            return true;
        }

        else if (neighbour == "FaronMistArea")
        {
            return CanSmash() && Has("DominionRod", 2) && Has("ShadowCrystal") && CanClearForest()
                || (SettingsStatus["GlitchedLogic"] &&
                    ((CanSmash() && Has("DominionRod", 2) && Has("ShadowCrystal"))
                    || (CanDoBSMoonBoots() && HasBombs() && CanDoLJA())
                    || CanDoMapGlitch()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Hyrule Field

    public bool FaronFieldCornerGrotto(string neighbour) // done
    {
        if (neighbour == "FaronField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool FaronField(string neighbour) // done
    {
        if (neighbour == "SouthFaronWoods")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownSouth")
        {
            return ((
                    (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"]) 
                    && (Has("ShadowCrystal") || SettingsStatus["SkipLanayruTwilight"]) 
                    || CanSmash()
                ) 
                && Has("Bottle"))
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "KakarikoGorge")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return ((Has("GateKeys") || SettingsStatus["SmallKeysKeysy"]) 
                    && (Has("ShadowCrystal") || SettingsStatus["SkipLanayruTwilight"]) 
                    || CanSmash())
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "FaronFieldCornerGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Sacred Grove

    public bool LostWoods(string neighbour) // done
    {
        if (neighbour == "NorthFaronWoods")
        {
            return true;
        }

        else if (neighbour == "SacredGroveMasterSword")
        {
            return (CanDefeatSkullKid() && Has("ShadowCrystal")) 
                || SettingsStatus["ToTOpen"] 
                || SettingsStatus["ToTOpenGrove"]
                || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGroveBabaSerpentGrotto(string neighbour) // done
    {
        if (neighbour == "SacredGroveMasterSword")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGroveMasterSword(string neighbour) // done
    {
        if (neighbour == "LostWoods")
        {
            return true;
        }

        else if (neighbour == "SacredGroveTempleofTime")
        {
            return (CanDefeatShadowBeast() && Has("Sword", 3)) 
                || SettingsStatus["ToTOpen"] 
                || SettingsStatus["ToTOpenGrove"];
        }

        else if (neighbour == "SacredGroveBabaSerpentGrotto")
        {
            return CanSmash() && Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGroveTempleofTime(string neighbour) // done
    {
        if (neighbour == "SacredGroveMasterSword")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeEntrance")
        {
            return Has("Sword", 3) || SettingsStatus["ToTOpen"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Eldin Province 

------------------------------ */

    public bool DeathMountainInteriors(string neighbour) // done
    {
        if (neighbour == "DeathMountainVolcano")
        {
            return true;
        }

        else if (neighbour == "GoronMinesEntrance")
        {
            return Has("IronBoots") 
                || !SettingsStatus["MinesClosed"]
                || (SettingsStatus["GlitchedLogic"] && Has("Spinner"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool DeathMountainTrail(string neighbour) // done
    {
        if (neighbour == "KakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "DeathMountainVolcano")
        {
            return Has("IronBoots") || Has("ShadowCrystal") || SettingsStatus["GlitchedLogic"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool DeathMountainVolcano(string neighbour) // done
    {
        if (neighbour == "DeathMountainTrail")
        {
            return true;
        }

        else if (neighbour == "DeathMountainInteriors")
        {
            return (Has("IronBoots") && (CanDefeatGoron() || SettingsStatus["MinesOpen"]))
                || SettingsStatus["GlitchedLogic"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoVillage(string neighbour) // done
    {
        if (neighbour == "KakarikoGorge")
        {
            return true;
        }

        else if (neighbour == "EldinField")
        {
            return true;
        }

        else if (neighbour == "DeathMountainTrail")
        {
            return true;
        }

        else if (neighbour == "LakeHylia")
        {
            return (Has("GateKeys") && Has("IronBoots") && HasWaterBombs())
                || (SettingsStatus["GlitchedLogic"] && 
                    (
                        (HasHeavyMod() && HasWaterBombs() && Has("GateKeys"))
                        || 
                        (
                            (HasHeavyMod() || Has("ZoraArmor"))
                            && 
                            (
                                (HasBombs() && (Has("Sword") || Has("Spinner")))
                                || CanDoLJA()
                                || CanDoMoonBoots()
                            )
                        )
                    ));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Hidden Village

    public bool HiddenVillage(string neighbour) // done
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Hyrule Field

    public bool EldinFieldBombskitGrotto(string neighbour) // done
    {
        if (neighbour == "EldinField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinFieldStalfosGrotto(string neighbour) // done
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinFieldWaterBombFishGrotto(string neighbour) // done
    {
        if (neighbour == "EldinField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinField(string neighbour) // done
    {
        if (neighbour == "KakarikoGorge")
        {
            return CanSmash();
        }

        else if (neighbour == "KakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "GoronStockcave")
        {
            return Has("Clawshot")
                || (SettingsStatus["GlitchedLogic"] && (CanDoMapGlitch() || CanDoLJA()));
        }

        else if (neighbour == "CastleTown")
        {
            return CanSmash() || 
                (
                    (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"]) 
                    && (Has("ShadowCrystal") || SettingsStatus["SkipLanayruTwilight"])
                );
        }

        else if (neighbour == "LanayruField")
        {
            return CanSmash();
        }

        else if (neighbour == "EldinFieldWaterBombFishGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "EldinFieldBombskitGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "EldinFieldStalfosGrotto")
        {
            return (
                    (Has("ShadowCrystal") && Has("Spinner")) 
                    || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch())
                ) 
                && 
                (
                    CanSmash() || 
                        (
                            (SettingsStatus["SkipLanayruTwilight"] || Has("ShadowCrystal")) 
                            && 
                            (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                        )
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinLongCave(string neighbour) // done
    {
        if (neighbour == "KakarikoGorge")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronStockcave(string neighbour) // done
    {
        if (neighbour == "EldinField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoGorge(string neighbour) // done
    {
        if (neighbour == "EldinField")
        {
            return CanSmash();
        }

        else if (neighbour == "FaronField")
        {
            return true;
        }

        else if (neighbour == "KakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "EldinLongCave")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Lanayru Province 

------------------------------ */

// Castle Town

    public bool CastleTown(string neighbour) // done
    {
        if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else if (neighbour == "EldinField")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownSouth")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleEntrance")
        {
            return (SettingsStatus["HCOpen"] 
            || (SettingsStatus["HCVanilla"] && Has("FusedShadow", 3)) 
            || (SettingsStatus["HCFusedShadows"] && Has("FusedShadow", 3)) 
            || (SettingsStatus["HCMirrorShards"] && Has("MirrorShard", 3)) 
            || (SettingsStatus["HCAllDungeons"] && HasCompletedAllDungeons()) && CanCompleteMDH());
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Hyrule Field

    public bool LakeHyliaBridgeBubbleGrotto(string neighbour) // done
    {
        if (neighbour == "LakeHyliaBridge")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaBridge(string neighbour) // done
    {
        if (neighbour == "FaronField")
        {
            return Has("GateKeys") 
                || SettingsStatus["SmallKeysKeysy"]
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "LakeHylia")
        {
            return true;
        }

        else if (neighbour == "LanayruField")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaBridgeBubbleGrotto")
        {
            return Has("ShadowCrystal") && CanLaunchBombs() && Has("Clawshot");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LanayruFieldPoeGrotto(string neighbour) // done
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LanayruFieldSkulltulaGrotto(string neighbour) // done
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LanayruField(string neighbour) // done
    {
        if (neighbour == "EldinField")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "ZorasDomain")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else if (neighbour == "LanayruIcePuzzleCave")
        {
            return CanSmash();
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return CanSmash()|| (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "HiddenVillage")
        {
            return Has("FetchQuest", 3); // wooden statue
        }

        else if (neighbour == "LanayruFieldSkulltulaGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "LanayruFieldPoeGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LanayruIcePuzzleCave(string neighbour) // done
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownSouth(string neighbour) // done
    {
        if (neighbour == "CastleTown")
        {
            return true;
        }

        else if (neighbour == "FaronField")
        {
            return true;
        }

        else if (neighbour == "OutsideSouthCastleTownTektiteGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "LakeHylia")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownWest(string neighbour) // done
    {
        if (neighbour == "LakeHyliaBridge")
        {
            return true;
        }

        else if (neighbour == "LanayruField")
        {
            return true;
        }

        else if (neighbour == "CastleTown")
        {
            return true;
        }

        else if (neighbour == "WestHyruleFieldHelmasaurGrotto")
        {
            return Has("ShadowCrystal") 
                && (Has("Clawshot") 
                    || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideSouthCastleTownTektiteGrotto(string neighbour) // done
    {
        if (neighbour == "OutsideCastleTownSouth")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool WestHyruleFieldHelmasaurGrotto(string neighbour) // done
    {
        if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Lake Hylia

    public bool LakeHyliaLongCave(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaShellBladeGrotto(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaWaterToadpoliGrotto(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHylia(string neighbour) // done
    {
        if (neighbour == "GerudoDesert")
        {
            return Has("AurusMemo");
        }

        else if (neighbour == "LakeHyliaLongCave")
        {
            return CanSmash();
        }

        else if (neighbour == "LakeHyliaWaterToadpoliGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "LakeHyliaShellBladeGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "LakebedTempleEntrance")
        {
            return (Has("ZoraArmor")
                && (SettingsStatus["EarlyLakebed"]
                    || (Has("IronBoots") && HasWaterBombs())))
                || (SettingsStatus["GlitchedLogic"] 
                    && (Has("ZoraArmor") || CanDoAirRefill()));
        }

        else if (neighbour == "CityinTheSkyEntrance")
        {
            return Has("Clawshot")
            && (Has("Skybook", 7) || SettingsStatus["EarlyCitS"]);
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return true;
        }

        else if (neighbour == "ZorasDomain")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Zora's Domain

    public bool ZorasDomain(string neighbour) // done
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else if (neighbour == "SnowpeakClimb")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Gerudo Desert

------------------------------ */

    public bool BulblinCamp(string neighbour) // done
    {
        if (neighbour == "GerudoDesert")
        {
            return true;
        }

        else if (neighbour == "OutsideArbitersGrounds")
        {
            return ((Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"]) && CanDefeatKingBulblinDesert())
                || SettingsStatus["EarlyArbiters"]
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch() && Has("Sword"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesertRockGrotto(string neighbour) // done
    {
        if (neighbour == "GerudoDesert")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesertSkulltulaGrotto(string neighbour) // done
    {
        if (neighbour == "GerudoDesert")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesert(string neighbour) // done
    {
        if (neighbour == "CaveofOrdealsFloors111")
        {
            return CanDefeatShadowBeast() && Has("Clawshot");
        }

        else if (neighbour == "BulblinCamp")
        {
            return CanDefeatBulblin();
        }

        else if (neighbour == "GerudoDesertRockGrotto")
        {
            return Has("ShadowCrystal") && Has("Clawshot");
        }

        else if (neighbour == "GerudoDesertSkulltulaGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MirrorChamber(string neighbour) // done
    {
        if (neighbour == "ArbitersGroundsBossRoom")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightEntrance")
        {
            return ((SettingsStatus["PoTVanilla"] && Has("Boss7"))
                || (SettingsStatus["PoTFusedShadows"] && Has("FusedShadow", 3))
                || (SettingsStatus["PoTMirrorShards"] && Has("MirrorShard", 3))
                || SettingsStatus["PoTOpen"])
                && CanDefeatShadowBeast();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideArbitersGrounds(string neighbour) // done
    {
        if (neighbour == "BulblinCamp")
        {
            return true;
        }

        else if (neighbour == "ArbitersGroundsEntrance")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Cave of Ordeals

    public bool CaveofOrdealsFloors111(string neighbour) // done
    {
        if (neighbour == "GerudoDesert")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CaveofOrdealsFloors1221")
        {
            return CanDefeatKeese() && CanDefeatTorchSlug();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors1221(string neighbour) // done
    {
        if (neighbour == "OrdonProvince")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CaveofOrdealsFloors2231")
        {
            return Has("Spinner") && CanDefeatPoe();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors2231(string neighbour) // done
    {
        if (neighbour == "SouthFaronWoods")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CaveofOrdealsFloors3241")
        {
            return Has("B&C") && CanDefeatGhoulRat();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors3241(string neighbour) // done
    {
        if (neighbour == "KakarikoVillage")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CaveofOrdealsFloors4250")
        {
            return Has("DominionRod", 2)
                && CanDefeatPoe()
                && CanDefeatFreezard()
                && CanDefeatDarknut();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors4250(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return Has("Clawshot", 2)
                && CanDefeatPoe()
                && CanDefeatFreezard()
                && CanDefeatDarknut();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Snowpeak Province

------------------------------ */

    public bool SnowpeakClimb(string neighbour) // done
    {
        if (neighbour == "ZorasDomain")
        {
            return true;
        }

        else if (neighbour == "SnowpeakSummit")
        {
            return (Has("ReekfishScent")
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || SettingsStatus["EarlySnowpeak"]
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()))
            && Has("ShadowCrystal");
        }

        else if (neighbour == "SnowpeakFreezardGrotto")
        {
            return (Has("ReekfishScent")
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || SettingsStatus["EarlySnowpeak"]
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()))
            && Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakFreezardGrotto(string neighbour) // done
    {
        if (neighbour == "SnowpeakClimb")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakSummit(string neighbour) // done
    {
        if (neighbour == "SnowpeakClimb")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "SnowpeakRuinsEntrance")
        {
            return CanDefeatShadowBeast() 
                && (!SettingsStatus["BonksDoDamage"]
                    || (SettingsStatus["BonksDoDamage"]
                    && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairy())));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Forest Temple

------------------------------ */

    public bool ForestTempleBossRoom(string neighbour) // done
    {
        if (neighbour == "SouthFaronWoods")
        {
            return CanDefeatDiababa();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ForestTempleEastWing(string neighbour) // done
    {
        if (neighbour == "ForestTempleLobby")
        {
            return true;
        }

        else if (neighbour == "ForestTempleNorthWing")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ForestTempleEntrance(string neighbour) // done
    {
        if (neighbour == "NorthFaronWoods")
        {
            return true;
        }

        else if (neighbour == "ForestTempleLobby")
        {
            return CanDefeatWalltula() && CanDefeatBokoblin() && CanBreakMonkeyCage();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ForestTempleLobby(string neighbour) // done
    {
        if (neighbour == "ForestTempleEntrance")
        {
            return true;
        }

        else if (neighbour == "ForestTempleEastWing")
        {
            return true;
        }

        else if (neighbour == "ForestTempleWestWing")
        {
            return CanBurnWebs() 
                && (((Has("FTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]) 
                    && CanDefeatBokoblin()) 
                        || Has("Clawshot")
                        || (SettingsStatus["GlitchedLogic"] && CanDoLJA()));
        }

        else if (neighbour == "Ook")
        {
            return (Has("Lantern")
                && CanDefeatWalltula()
                && CanDefeatBokoblin()
                && CanBreakMonkeyCage()
                && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]))
                    || (SettingsStatus["GlitchedLogic"] && CanDoLJA() && CanBurnWebs());
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ForestTempleNorthWing(string neighbour) // done
    {
        if (neighbour == "ForestTempleEastWing")
        {
            return true;
        }

        else if (neighbour == "ForestTempleBossRoom")
        {
            return (Has("FTBigKey") || SettingsStatus["BigKeysKeysy"])
                && (
                        (Has("Boomerang")
                            && (CanFreeAllMonkeys() || Has("Clawshot"))
                        )
                        || (SettingsStatus["GlitchedLogic"] && CanDoLJA())
                    );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ForestTempleWestWing(string neighbour) // done
    {
        if (neighbour == "ForestTempleLobby")
        {
            return true;
        }

        else if (neighbour == "Ook")
        {
            return Has("Boomerang")
                || (SettingsStatus["GlitchedLogic"] && 
                    (Has("ShadowCrystal") || Has("Sword") || HasBombs()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool Ook(string neighbour) // done
    {
        if (neighbour == "ForestTempleWestWing")
        {
            return CanDefeatOok() && Has("Boomerang");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Goron Mines

------------------------------ */

    public bool GoronMinesBossRoom(string neighbour) // done
    {
        if (neighbour == "KakarikoVillage")
        {
            return CanDefeatFyrus();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesCrystalSwitchRoom(string neighbour) // done
    {
        if (neighbour == "GoronMinesMagnetRoom")
        {
            return true;
        }

        else if (neighbour == "GoronMinesNorthWing")
        {
            return (
                (Has("IronBoots") && Has("Sword")) 
                || Has("Bow")
                || (SettingsStatus["GlitchedLogic"] 
                    && (CanDoLJA() || (Has("Sword") && HasBombs()))
                    && (Has("Clawshot") || Has("B&C") || HasBombs())
                    )
                ) 
                && (Has("GMSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesEntrance(string neighbour) // done
    {
        if (neighbour == "DeathMountainInteriors")
        {
            return true;
        }

        else if (neighbour == "GoronMinesMagnetRoom")
        {
            return Has("IronBoots") 
                && (CanBreakWoodenDoor() 
                    || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesLowerWestWing(string neighbour) // done
    {
        if (neighbour == "GoronMinesMagnetRoom")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesMagnetRoom(string neighbour) // done
    {
        if (neighbour == "GoronMinesEntrance")
        {
            return true;
        }

        else if (neighbour == "GoronMinesLowerWestWing")
        {
            return Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "GoronMinesCrystalSwitchRoom")
        {
            return (Has("GMSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]) && Has("IronBoots");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesNorthWing(string neighbour) // done
    {
        if (neighbour == "GoronMinesCrystalSwitchRoom")
        {
            return true;
        }

        else if (neighbour == "GoronMinesUpperEastWing")
        {
            return Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "GoronMinesBossRoom")
        {
            return (Has("GMBigKey", 3) || SettingsStatus["BigKeysKeysy"])
                && Has("Bow")
                && ((Has("IronBoots") && CanDefeatBulblin()) 
                    || (SettingsStatus["GlitchedLogic"] && (Has("Clawshot") || CanDoLJA())));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesUpperEastWing(string neighbour) // done
    {
        if (neighbour == "GoronMinesMagnetRoom")
        {
            return Has("IronBoots") 
                && CanDefeatDangoro() 
                && (Has("Bow") || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Lakebed Temple

------------------------------ */

    public bool LakebedTempleBossRoom(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return CanDefeatMorpheel();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleCentralRoom(string neighbour) // done
    {
        if (neighbour == "LakebedTempleEntrance")
        {
            return true;
        }

        else if (neighbour == "LakebedTempleEastWingSecondFloor")
        {
            return Has("LTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "LakebedTempleEastWingFirstFloor")
        {
            return true;
        }

        else if (neighbour == "LakebedTempleWestWing")
        {
            return (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                && CanSmash()
                && Has("Clawshot");
        }

        else if (neighbour == "LakebedTempleBossRoom")
        {
            return (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                && CanLaunchBombs()
                && Has("Clawshot")
                && (Has("LTBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleEastWingFirstFloor(string neighbour) // done
    {
        if (neighbour == "LakebedTempleCentralRoom")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleEastWingSecondFloor(string neighbour) // done
    {
        if (neighbour == "LakebedTempleCentralRoom")
        {
            return true;
        }

        else if (neighbour == "LakebedTempleEastWingFirstFloor")
        {
            return CanLaunchBombs() || Has("Clawshot");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleEntrance(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return true;
        }

        else if (neighbour == "LakebedTempleCentralRoom")
        {
            return CanLaunchBombs()
                || (SettingsStatus["GlitchedLogic"] 
                    && (CanDoLJA() || CanDoJSMoonBoots()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleWestWing(string neighbour) // done
    {
        if (neighbour == "LakebedTempleCentralRoom")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Arbiter's Grounds

------------------------------ */

    public bool ArbitersGroundsAfterPoeGate(string neighbour) // done
    {
        if (neighbour == "ArbitersGroundsLobby")
        {
            return true;
        }

        else if (neighbour == "ArbitersGroundsBossRoom")
        {
            return Has("Spinner") && (Has("AGBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ArbitersGroundsBossRoom(string neighbour) // done
    {
        if (neighbour == "MirrorChamber")
        {
            return CanDefeatStallord();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ArbitersGroundsEastWing(string neighbour) // done
    {
        if (neighbour == "ArbitersGroundsLobby")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ArbitersGroundsEntrance(string neighbour) // done
    {
        if (neighbour == "OutsideArbitersGrounds")
        {
            return true;
        }

        else if (neighbour == "ArbitersGroundsLobby")
        {
            return (Has("AGSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]) && Has("Lantern");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ArbitersGroundsLobby(string neighbour) // done
    {
        if (neighbour == "ArbitersGroundsEntrance")
        {
            return true;
        }

        else if (neighbour == "ArbitersGroundsEastWing")
        {
            return true;
        }

        else if (neighbour == "ArbitersGroundsWestWing")
        {
            return true;
        }

        else if (neighbour == "ArbitersGroundsAfterPoeGate")
        {
            return Has("ShadowCrystal")
                && Has("Clawshot")
                && CanDefeatStalfos()
                && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ArbitersGroundsWestWing(string neighbour) // done
    {
        if (neighbour == "ArbitersGroundsLobby")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Snowpeak Ruins

------------------------------ */

    public bool SnowpeakRuinsBossRoom(string neighbour) // done
    {
        if (neighbour == "SnowpeakSummit")
        {
            return CanDefeatBlizzeta();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsCagedFreezardRoom(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsSecondFloorMiniFreezardRoom")
        {
            return Has("B&C") && (Has("SRSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
        }

        else if (neighbour == "SnowpeakRuinsWoodenBeamRoom")
        {
            return Has("B&C");
        }

        else if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return Has("SRSmallKey", 2) || SettingsStatus["SmallKeysKeysy"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsChapel(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return CanDefeatChilfos();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsDarkhammerRoom(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return CanDefeatDarkhammer();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsEastCourtyard(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return Has("ShadowCrystal") && Has("B&C");
        }

        else if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return Has("B&C");
        }

        else if (neighbour == "SnowpeakRuinsNortheastChilfosRoomFirstFloor")
        {
            return (
                (Has("SRSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]) 
                        && CanDefeatMiniFreezard()
                ) || 
                (
                    (Has("SRSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]) 
                        && Has("Clawshot") 
                        && CanDefeatMiniFreezard()
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsEntrance(string neighbour) // done
    {
        if (neighbour == "SnowpeakSummit")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsNortheastChilfosRoomFirstFloor(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return CanDefeatChilfos();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsNortheastChilfosRoomSecondFloor(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsNortheastChilfosRoomFirstFloor")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return Has("B&C");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsSecondFloorMiniFreezardRoom(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsEntrance")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return Has("ShadowCrystal") || Has("B&C");
        }

        else if (neighbour == "SnowpeakRuinsNortheastChilfosRoomSecondFloor")
        {
            return Has("B&C") && Has("Clawshot") && CanDefeatChilfos();
        }

        else if (neighbour == "SnowpeakRuinsCagedFreezardRoom")
        {
            return Has("SRSmallKey", 4) || SettingsStatus["SmallKeysKeysy"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsWestCannonRoom(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsWoodenBeamRoom")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsWestCourtyard(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return Has("B&C");
        }

        else if (neighbour == "SnowpeakRuinsWestCannonRoom")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsChapel")
        {
            return (
                (Has("SRSmallKey", 4) && Has("Cheese")) 
                    || SettingsStatus["SmallKeysKeysy"]
                ) 
                && Has("B&C") 
                && HasBombs();
        }

        else if (neighbour == "SnowpeakRuinsDarkhammerRoom")
        {
            return Has("B&C") || 
                (
                    (Has("SRSmallKey", 2) 
                        || (Has("Cheese") && !SettingsStatus["GlitchedLogic"])
                        || SettingsStatus["SmallKeysKeysy"]) 
                    && HasBombs()
                );
        }

        else if (neighbour == "SnowpeakRuinsBossRoom")
        {
            return ((Has("SRSmallKey", 4) && Has("Cheese")) || SettingsStatus["SmallKeysKeysy"]) 
                && Has("B&C") 
                && HasBombs() 
                && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsWoodenBeamRoom(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsWestCannonRoom")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsYetoandYeta(string neighbour) // done
    {
        if (neighbour == "SnowpeakRuinsEntrance")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsCagedFreezardRoom")
        {
            return Has("Cheese") || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return Has("Pumpkin") || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return Has("ShadowCrystal") || Has("B&C");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Temple of Time

------------------------------ */

    public bool TempleofTimeArmosAntechamber(string neighbour) // done
    {
        if (neighbour == "TempleofTimeCentralMechanicalPlatform")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeBossRoom(string neighbour) // done
    {
        if (neighbour == "SacredGroveTempleofTime")
        {
            return CanDefeatArmogohma();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeCentralMechanicalPlatform(string neighbour) // done
    {
        if (neighbour == "TempleofTimeConnectingCorridors")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeArmosAntechamber")
        {
            return Has("Spinner");
        }

        else if (neighbour == "TempleofTimeMovingWallHallways")
        {
            return Has("Spinner") && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeConnectingCorridors(string neighbour) // done
    {
        if (neighbour == "TempleofTimeEntrance")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeCentralMechanicalPlatform")
        {
            return HasRangedItem() && CanDefeatYoungGohma() && CanDefeatLizalfos();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeCrumblingCorridor(string neighbour) // done
    {
        if (neighbour == "TempleofTimeEntrance")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeBossRoom")
        {
            return Has("DominionRod") && (Has("ToTBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeDarknutArena(string neighbour) // done
    {
        if (neighbour == "TempleofTimeUpperSpikeTrapCorridor")
        {
            return CanDefeatDarknut() && Has("DominionRod");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeEntrance(string neighbour) // done
    {
        if (neighbour == "SacredGroveTempleofTime")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeConnectingCorridors")
        {
            return Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "TempleofTimeCrumblingCorridor")
        {
            return (Has("DominionRod") 
                    && Has("Bow") 
                    && Has("Spinner") 
                    && CanDefeatLizalfos() 
                    && CanDefeatDinalfos() 
                    && CanDefeatDarknut() 
                    && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                ) 
                || SettingsStatus["OpenDoorOfTime"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeFloorSwitchPuzzleRoom(string neighbour) // done
    {
        if (neighbour == "TempleofTimeScalesofTime")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeMovingWallHallways(string neighbour) // done
    {
        if (neighbour == "TempleofTimeCentralMechanicalPlatform")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeScalesofTime")
        {
            return Has("Bow") && CanDefeatLizalfos() && CanDefeatDinalfos();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeScalesofTime(string neighbour) // done
    {
        if (neighbour == "TempleofTimeMovingWallHallways")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeFloorSwitchPuzzleRoom")
        {
            return Has("Clawshot") && Has("Spinner");
        }

        else if (neighbour == "TempleofTimeUpperSpikeTrapCorridor")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }
    
    public bool TempleofTimeUpperSpikeTrapCorridor(string neighbour) // done
    {
        if (neighbour == "TempleofTimeDarknutArena")
        {
            return CanDefeatLizalfos()
                && CanDefeatBabyGohma()
                && CanDefeatYoungGohma()
                && CanDefeatArmos()
                && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        City in The Sky

------------------------------ */

    public bool CityinTheSkyBossRoom(string neighbour) // done
    {
        if (neighbour == "CityinTheSkyEntrance")
        {
            return CanDefeatArgorok();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyCentralTowerSecondFloor(string neighbour) // done
    {
        if (neighbour == "CityinTheSkyWestWing")
        {
            return Has("Clawshot", 2);
        }

        else if (neighbour == "CityinTheSkyLobby")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyEastWing(string neighbour) // done
    {
        if (neighbour == "CityinTheSkyLobby")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyEntrance(string neighbour) // done
    {
        if (neighbour == "LakeHylia")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CityinTheSkyLobby")
        {
            return Has("Clawshot");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyLobby(string neighbour) // done
    {
        if (neighbour == "CityinTheSkyEntrance")
        {
            return true;
        }

        else if (neighbour == "CityinTheSkyEastWing")
        {
            return Has("Spinner") && (Has("CitSSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
        }

        else if (neighbour == "CityinTheSkyWestWing")
        {
            return Has("Clawshot", 2);
        }

        else if (neighbour == "CityinTheSkyNorthWing")
        {
            return Has("Clawshot", 2)
                && (
                        (
                            CanDefeatBabaSerpent()
                            && CanDefeatKargorok()
                            && Has("ShadowCrystal")
                            && Has("IronBoots")
                        )
                    || (
                        SettingsStatus["GlitchedLogic"] 
                        && ((Has("ShadowCrystal") && Has("IronBoots")) || CanDoLJA())
                        )
                    );
        }

        else if (neighbour == "CityinTheSkyCentralTowerSecondFloor")
        {
            return SettingsStatus["GlitchedLogic"] && Has("Clawshot") && Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyNorthWing(string neighbour) // done
    {
        if (neighbour == "CityinTheSkyLobby")
        {
            return true;
        }

        else if (neighbour == "CityinTheSkyBossRoom")
        {
            return Has("Clawshot", 2) 
                && CanDefeatAeralfos()
                && (Has("CitSBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyWestWing(string neighbour) // done
    {
        if (neighbour == "CityinTheSkyLobby")
        {
            return Has("Clawshot", 2);
        }

        else if (neighbour == "CityinTheSkyCentralTowerSecondFloor")
        {
            return Has("Clawshot", 2);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Palace of Twilight

------------------------------ */

    public bool PalaceofTwilightBossRoom(string neighbour) // done
    {
        if (neighbour == "PalaceofTwilightEntrance")
        {
            return CanDefeatZant();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightEastWing(string neighbour) // done
    {
        if (neighbour == "PalaceofTwilightEntrance")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightEntrance(string neighbour) // done
    {
        if (neighbour == "MirrorChamber")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightWestWing")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightEastWing")
        {
            return CanDefeatPhantomZant()
                && Has("Clawshot")
                && CanDefeatZantHead()
                && (Has("PoTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]);
        }

        else if (neighbour == "PalaceofTwilightNorthTower")
        {
            return Has("Sword", 4)
                && CanDefeatPhantomZant()
                && Has("Clawshot")
                && CanDefeatZantHead()
                && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
                && CanDefeatShadowBeast();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightNorthTower(string neighbour) // done
    {
        if (neighbour == "PalaceofTwilightEntrance")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightBossRoom")
        {
            return (Has("PoTSmallKey", 7) || SettingsStatus["SmallKeysKeysy"])
                && CanDefeatZantHead()
                && Has("Sword", 4)
                && (Has("PoTBigKey") || SettingsStatus["BigKeysKeysy"])
                && CanDefeatShadowBeast();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightWestWing(string neighbour) // done
    {
        if (neighbour == "PalaceofTwilightEntrance")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

/* ------------------------------

        Hyrule Castle

------------------------------ */

    public bool GanondorfCastle(string neighbour) // done
    {
        if (neighbour == "HyruleCastleTowerClimb")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleEntrance(string neighbour) // done
    {
        if (neighbour == "CastleTown")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleMainHall")
        {
            return Has("HCSmallKey", 1) || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "HyruleCastleOutsideWestWing")
        {
            return CanDefeatBokoblinRed();
        }

        else if (neighbour == "HyruleCastleOutsideEastWing")
        {
            return CanDefeatBokoblinRed();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleGraveyard(string neighbour) // done
    {
        if (neighbour == "HyruleCastleOutsideEastWing")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleInsideEastWing(string neighbour) // done
    {
        if (neighbour == "HyruleCastleMainHall")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleThirdFloorBalcony")
        {
            return Has("Lantern") && CanDefeatDinalfos();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleInsideWestWing(string neighbour) // done
    {
        if (neighbour == "HyruleCastleMainHall")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleThirdFloorBalcony")
        {
            return CanKnockDownHCPainting() && CanDefeatLizalfos() && CanDefeatDarknut();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleMainHall(string neighbour) // done
    {
        if (neighbour == "HyruleCastleEntrance")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleInsideEastWing")
        {
            return CanDefeatBokoblin()
                && CanDefeatLizalfos()
                && (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")))
                && CanDefeatDarknut()
                && Has("Boomerang");
        }

        else if (neighbour == "HyruleCastleInsideWestWing")
        {
            return CanDefeatBokoblin()
                && CanDefeatLizalfos()
                && (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")))
                && CanDefeatDarknut()
                && Has("Boomerang");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleOutsideEastWing(string neighbour) // done
    {
        if (neighbour == "HyruleCastleEntrance")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleGraveyard")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleOutsideWestWing(string neighbour) // done
    {
        if (neighbour == "HyruleCastleEntrance")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleThirdFloorBalcony(string neighbour) // done
    {
        if (neighbour == "HyruleCastleInsideWestWing")
        {
            return CanKnockDownHCPainting() && CanDefeatLizalfos() && CanDefeatDarknut();
        }

        else if (neighbour == "HyruleCastleInsideEastWing")
        {
            return Has("Lantern") && CanDefeatDinalfos();
        }

        else if (neighbour == "HyruleCastleTowerClimb")
        {
            return Has("HCSmallKey", 2) || SettingsStatus["SmallKeysKeysy"];
        }
        
        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleTowerClimb(string neighbour) // done
    {
        if (neighbour == "HyruleCastleThirdFloorBalcony")
        {
            return true;
        }

        else if (neighbour == "HyruleCastleTreasureRoom")
        {
            return (Has("HCSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                && (Has("Spinner") || (SettingsStatus["GlitchedLogic"] && CanDoJSLJA()))
                && (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")))
                && CanDefeatDarknut()
                && CanDefeatLizalfos();
        }

        else if (neighbour == "GanondorfCastle")
        {
            return (Has("Spinner") || (SettingsStatus["GlitchedLogic"] && CanDoJSLJA()))
                && (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")))
                && CanDefeatDarknut()
                && CanDefeatLizalfos()
                && (Has("HCBigKey") || SettingsStatus["BigKeysKeysy"])
                && CanDefeatGanondorf();
        }
        
        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HyruleCastleTreasureRoom(string neighbour) // done
    {
        if (neighbour == "HyruleCastleTowerClimb")
        {
            return true;
        }
        
        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }
}
