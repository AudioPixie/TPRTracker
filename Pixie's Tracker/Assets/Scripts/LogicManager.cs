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
   
    public bool OrdonRanchGrottoLanternChest()
    {
        return Has("Lantern");
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
        return Has("Lantern");
    }

    public bool FaronMistCaveOpenChest()
    {
        return true;
    }

    public bool FaronMistNorthChest()
    {
        return CanCompletePrologue() && Has("Lantern");
    }

    public bool FaronMistSouthChest()
    {
        return CanCompletePrologue() && Has("Lantern");
    }

    public bool FaronMistStumpChest()
    {
        return CanCompletePrologue() && Has("Lantern");
    }

    public bool FaronWoodsGoldenWolf()
    {
        return true;
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
        return true;
    }

    public bool SouthFaronCaveChest()
    {
        return true;
    }

    // Lost Woods/Sacred Grove

    public bool LostWoodsLanternChest()
    {
        return Has("Lantern");
    }

    public bool SacredGroveBabaSerpentGrottoChest()
    {
        return CanDefeatBabaSerpent() && CanKnockDownHangingBaba();
    }

    public bool SacredGrovePastOwlStatueChest()
    {
        return Has("DominionRod");
    }

    public bool SacredGroveSpinnerChest()
    {
        return Has("Spinner");
    }

    // Faron Field

    public bool FaronFieldBridgeChest()
    {
        return Has("Clawshot");
    }

    public bool FaronFieldCornerGrottoLeftChest()
    {
        return true;
    }

    public bool FaronFieldCornerGrottoRearChest()
    {
        return true;
    }

    public bool FaronFieldCornerGrottoRightChest()
    {
        return true;
    }

    public bool FaronFieldTreeHeartPiece()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    // Kakariko Gorge

    public bool KakarikoGorgeDoubleClawshotChest()
    {
        return Has("Clawshot", 2);
    }

    public bool KakarikoGorgeOwlStatueChest()
    {
        return Has("DominionRod", 2);
    }

    public bool KakarikoGorgeOwlStatueSkyCharacter()
    {
        return Has("DominionRod", 2);
    }

    public bool KakarikoGorgeSpireHeartPiece()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    // Death Mountain

    public bool DeathMountainAlcoveChest()
    {
        return (Has("Boss2") && SettingsStatus["UnrequiredDungeonsAreBarren"]) || 
            (
                Has("Clawshot") 
                    && (Has("IronBoots") || Has("ShadowCrystal"))
            );
    }

    // Eldin Field

    public bool BridgeofEldinOwlStatueChest()
    {
        return Has("DominionRod", 2);
    }

    public bool BridgeofEldinOwlStatueSkyCharacter()
    {
        return Has("DominionRod", 2);
    }

    public bool EldinFieldBombRockChest()
    {
        return CanSmash();
    }

    public bool EldinFieldBomskitGrottoLanternChest()
    {
        return CanDefeatBomskit() && Has("Lantern");
    }

    public bool EldinFieldBomskitGrottoLeftChest()
    {
        return CanDefeatBomskit();
    }

    public bool EldinFieldStalfosGrottoLeftSmallChest()
    {
        return true;
    }

    public bool EldinFieldStalfosGrottoRightSmallChest()
    {
        return true;
    }

    public bool EldinFieldStalfosGrottoStalfosChest()
    {
        return CanDefeatStalfos();
    }

    public bool EldinFieldWaterBombFishGrottoChest()
    {
        return true;
    }

    public bool GoronSpringwaterRush()
    {
        return CanSmash() ||
            (
                (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
                && (LanayruTwilightCleared() || Has("ShadowCrystal"))
            );
    }

    // Lanayru Field

    public bool LanayruFieldBehindGateUnderwaterChest()
    {
        return Has("IronBoots");
    }

    public bool LanayruFieldSkulltulaGrottoChest()
    {
        return CanDefeatSkulltula() && Has("Lantern") && CanBreakWoodenDoor();
    }

    public bool LanayruFieldSpinnerTrackChest()
    {
        return CanSmash() && Has("Spinner");
    }

    public bool LanayruIceBlockPuzzleCaveChest()
    {
        return Has("B&C");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterOwlStatueChest()
    {
        return Has("DominionRod", 2);
    }

    public bool HyruleFieldAmphitheaterOwlStatueSkyCharacter()
    {
        return Has("DominionRod", 2);
    }

    public bool WestHyruleFieldGoldenWolf()
    {
        return CanAccessZorasDomain() && Has("ShadowCrystal");
    }

    public bool WestHyruleFieldHelmasaurGrottoChest()
    {
        return CanDefeatHelmasaur();
    }

    // North Castle Town

    public bool NorthCastleTownGoldenWolf()
    {
        return Has("FetchQuest", 3) && Has("ShadowCrystal") && CanCompleteMDH();
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownDoubleClawshotChasmChest()
    {
        return Has("Clawshot", 2);
    }

    public bool OutsideSouthCastleTownFountainChest()
    {
        return Has("Clawshot") && Has("Spinner");
    }

    public bool OutsideSouthCastleTownGoldenWolf()
    {
        return CanAccessNorthFaron() && Has("ShadowCrystal");
    }

    public bool OutsideSouthCastleTownTektiteGrottoChest()
    {
        return CanDefeatTektite();
    }

    public bool OutsideSouthCastleTownTightropeChest()
    {
        return Has("ShadowCrystal") && Has("Clawshot");
    }

    public bool WoodenStatue()
    {
        return Has("FetchQuest", 2) && (Has("MedicineScent") || SettingsStatus["IgnoreScentLogic"]);
    }

    // Lake Hylia

    public bool AuruGiftToFyer()
    {
        return true;
    }

    public bool LakeHyliaShellBladeGrottoChest()
    {
        return CanDefeatShellBlade();
    }

    public bool LakeHyliaUnderwaterChest()
    {
        return Has("IronBoots");
    }

    public bool LakeHyliaWaterToadpoliGrottoChest()
    {
        return CanDefeatWaterToadpoli();
    }

    public bool OutsideLanayruSpringLeftStatueChest()
    {
        return true;
    }

    public bool OutsideLanayruSpringRightStatueChest()
    {
        return true;
    }

    public bool PlummFruitBalloonMinigame()
    {
        return Has("ShadowCrystal");
    }

    public bool FlightByFowl()
    {
        return true;
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeBubbleGrottoChest()
    {
        return CanDefeatBubble();
    }

    public bool LakeHyliaBridgeCliffChest()
    {
        return CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakeHyliaBridgeOwlStatueChest()
    {
        return Has("Clawshot") && Has("DominionRod", 2);
    }

    public bool LakeHyliaBridgeOwlStatueSkyCharacter()
    {
        return Has("Clawshot") && Has("DominionRod", 2);
    }

    public bool LakeHyliaBridgeVinesChest()
    {
        return Has("Clawshot");
    }

    // Upper Zora's River

    public bool FishingHoleBottle()
    {
        return Has("FishingRod");
    }

    public bool FishingHoleHeartPiece()
    {
        return true;
    }

    public bool IzaHelpingHand()
    {
        return CanAccessZorasDomain()
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    public bool IzaRagingRapidsMinigame()
    {
        return CanAccessZorasDomain()
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    // Zora's Domain

    public bool ZorasDomainChestBehindWaterfall()
    {
        return Has("ShadowCrystal");
    }

    public bool ZorasDomainChestByMotherandChildIsles()
    {
        return true;
    }

    public bool ZorasDomainExtinguishAllTorchesChest()
    {
        return Has("Boomerang") && Has("IronBoots");
    }

    public bool ZorasDomainLightAllTorchesChest()
    {
        return Has("Lantern") && Has("IronBoots");
    }

    public bool ZorasDomainUnderwaterGoron()
    {
        return Has("IronBoots") && Has("ZoraArmor") && HasWaterBombs();
    }

    // Gerudo Desert

    public bool GerudoDesertCampfireEastChest()
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertCampfireNorthChest()
    {
        return true;
    }

    public bool GerudoDesertCampfireWestChest()
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertEastCanyonChest()
    {
        return true;
    }

    public bool GerudoDesertGoldenWolf()
    {
        return Has("ShadowCrystal") && CanAccessLakeHylia();
    }

    public bool GerudoDesertLoneSmallChest()
    {
        return true;
    }

    public bool GerudoDesertNortheastChestBehindGates()
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertNorthwestChestBehindGates()
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertNorthSmallChestBeforeBulblinCamp()
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertOwlStatueChest()
    {
        return Has("DominionRod", 2);
    }

    public bool GerudoDesertOwlStatueSkyCharacter()
    {
        return Has("DominionRod", 2);
    }

    public bool GerudoDesertPeahatLedgeChest()
    {
        return Has("Clawshot");
    }

    public bool GerudoDesertRockGrottoLanternChest()
    {
        return CanSmash() && Has("Lantern");
    }

    public bool GerudoDesertSouthChestBehindWoodenGates()
    {
        return CanDefeatBulblin();
    }

    public bool GerudoDesertSkulltulaGrottoChest()
    {
        return CanDefeatSkulltula();
    }

    public bool GerudoDesertWestCanyonChest()
    {
        return Has("Clawshot");
    }

    // Snowpeak

    public bool AsheiSketch()
    {
        return true;
    }

    public bool SnowboardRacingPrize()
    {
        return Has("Boss5");
    }

    public bool SnowpeakCaveIceLanternChest()
    {
        return Has("B&C") && Has("Lantern");
    }

    public bool SnowpeakFreezardGrottoChest()
    {
        return Has("B&C");
    }

    // Hidden Village

    public bool CatsHideandSeekMinigame()
    {
        return Has("ShadowCrystal")
            && Has("Clawshot")
            && Has("FetchQuest", 4)
            && Has("Bow")
            && Has("DominionRod");
    }

    public bool IliaCharm()
    {
        return Has("Bow");
    }

    public bool SkybookFromImpaz()
    {
        return Has("Bow") && Has("DominionRod");
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
        return Has("ShadowCrystal");
    }

    public bool LostWoodsBoulderPoe()
    {
        return Has("ShadowCrystal")
            && (CanDefeatSkullKid() || !SettingsStatus["ToTClosed"]) 
            && CanSmash();
    }

    // Sacred Grove

    public bool SacredGroveMasterSwordPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool SacredGroveTempleofTimeOwlStatuePoe()
    {
        return Has("ShadowCrystal") && Has("DominionRod");
    }

    // Faron Field

    public bool FaronFieldPoe()
    {
        return CanCompleteMDH() && Has("ShadowCrystal");
    }

    // Kakariko Gorge

    public bool KakarikoGorgePoe()
    {
        return CanCompleteMDH() && Has("ShadowCrystal");
    }

    // Death Mountain

    public bool DeathMountainTrailPoe()
    {
        return Has("Boss2") && Has("ShadowCrystal");
    }

    // Lanayru Field

    public bool LanayruFieldBridgePoe()
    {
        return CanCompleteMDH() && Has("ShadowCrystal");
    }

    public bool LanayruFieldPoeGrottoLeftPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool LanayruFieldPoeGrottoRightPoe()
    {
        return Has("ShadowCrystal");
    }

    // West Hyrule Field

    public bool HyruleFieldAmphitheaterPoe()
    {
        return Has("ShadowCrystal");
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownPoe()
    {
        return Has("ShadowCrystal");
    }

    // Outside East Castle Town

    public bool EastCastleTownBridgePoe()
    {
        return Has("ShadowCrystal");
    }

    // Lake Hylia

    public bool LakeHyliaAlcovePoe()
    {
        return Has("ShadowCrystal");
    }

    public bool LakeHyliaTowerPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool LakeHyliaDockPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool FlightByFowlLedgePoe()
    {
        return Has("ShadowCrystal");
    }

    public bool IsleofRichesPoe()
    {
        return Has("ShadowCrystal");
    }

    // Lake Hylia Bridge

    public bool LakeHyliaBridgeCliffPoe()
    {
        return Has("ShadowCrystal")
            && CanLaunchBombs()
            && Has("Clawshot")
            && CanCompleteMDH();
    }

    // Upper Zora's River

    public bool UpperZorasRiverPoe()
    {
        return Has("ShadowCrystal");
    }

    // Zora's Domain

    public bool ZorasDomainWaterfallPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool ZorasDomainMotherandChildIslePoe()
    {
        return Has("ShadowCrystal");
    }

    // Gerudo Desert

    public bool GerudoDesertNorthPeahatPoe()
    {
        return Has("Clawshot") && Has("ShadowCrystal");
    }

    public bool GerudoDesertEastPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool GerudoDesertPoeAboveCaveofOrdeals()
    {
        return Has("Clawshot") && Has("ShadowCrystal");
    }

    public bool GerudoDesertRockGrottoFirstPoe()
    {
        return CanSmash() && Has("ShadowCrystal");
    }

    public bool GerudoDesertRockGrottoSecondPoe()
    {
        return CanSmash() && Has("ShadowCrystal");
    }

    public bool OutsideBulblinCampPoe()
    {
        return Has("ShadowCrystal");
    }

    // Snowpeak

    public bool SnowpeakAboveFreezardGrottoPoe()
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2)));
    }

    public bool SnowpeakBlizzardPoe()
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2)));
    }

    public bool SnowpeakPoeAmongTrees()
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2)));
    }

    public bool SnowpeakCaveIcePoe()
    {
        return Has("B&C") && Has("ShadowCrystal");
    }

    public bool SnowpeakIcySummitPoe()
    {
        return Has("ShadowCrystal")
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
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool FaronFieldMaleBeetle()
    {
        return true;
    }

    public bool KakarikoGorgeFemalePillBug()
    {
        return true;
    }

    public bool KakarikoGorgeMalePillBug()
    {
        return true;
    }

    public bool KakarikoVillageFemaleAnt()
    {
        return true;
    }

    public bool KakarikoGraveyardMaleAnt()
    {
        return true;
    }

    public bool EldinFieldFemaleGrasshopper()
    {
        return true;
    }

    public bool EldinFieldMaleGrasshopper()
    {
        return true;
    }

    public bool BridgeofEldinFemalePhasmid()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool BridgeofEldinMalePhasmid()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool LakeHyliaBridgeFemaleMantis()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool LakeHyliaBridgeMaleMantis()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool LanayruFieldFemaleStagBeetle()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool LanayruFieldMaleStagBeetle()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool WestHyruleFieldFemaleButterfly()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool WestHyruleFieldMaleButterfly()
    {
        return true;
    }

    public bool OutsideSouthCastleTownFemaleLadybug()
    {
        return true;
    }

    public bool OutsideSouthCastleTownMaleLadybug()
    {
        return true;
    }

    public bool SacredGroveMaleSnail()
    {
        return Has("Boomerang") || Has("Clawshot");
    }

    public bool SacredGroveFemaleSnail()
    {
        return Has("Clawshot") || Has("Boomerang");
    }

    public bool GerudoDesertFemaleDayfly()
    {
        return true;
    }

    public bool GerudoDesertMaleDayfly()
    {
        return true;
    }

    public bool UpperZorasRiverFemaleDragonfly()
    {
        return true;
    }

    public bool ZorasDomainMaleDragonfly()
    {
        return true;
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
        return true;
    }

    public bool BarnesBombBag()
    {
        return true;
    }

    public bool EldinSpringUnderwaterChest()
    {
        return CanSmash() && Has("IronBoots");
    }

    public bool KakarikoVillageBombRockSpireHeartPiece()
    {
        return CanLaunchBombs() && Has("Boomerang");
    }

    public bool KakarikoGraveyardLanternChest()
    {
        return Has("Lantern");
    }

    public bool KakarikoWatchtowerChest()
    {
        return true;
    }

    public bool KakarikoWatchtowerAlcoveChest()
    {
        return CanSmash();
    }

    public bool TaloSharpshooting()
    {
        return Has("Bow") && Has("Boss2");
    }

    public bool KakarikoVillageMaloMartHylianShield()
    {
        return true;
    }

    public bool KakarikoVillageMaloMartHawkeye()
    {
        return Has("Bow") && Has("Boss2");
    }

    public bool RutelasBlessing()
    {
        return Has("GateKeys") || SettingsStatus["SmallKeysKeysy"];
    }

    public bool GiftFromRalis()
    {
        return (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"])
            && Has("AsheisSketch");
    }

    public bool KakarikoGraveyardGoldenWolf()
    {
        return Has("ShadowCrystal")
            && CanAccessSnowpeakClimb()
            && ((Has("ReekfishScent") || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2)))
                || SettingsStatus["EarlySnowpeak"]);
    }

    public bool RenadosLetter()
    {
        return Has("Boss6");
    }

    public bool IliaMemoryReward()
    {
        return Has("FetchQuest", 4);
    }

    // Poes

    public bool KakarikoVillageBombShopPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool KakarikoVillageWatchtowerPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool KakarikoGraveyardOpenPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool KakarikoGraveyardGravePoe()
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Eldin Lantern Cave

------------------------------ */

    public bool EldinLanternCaveFirstChest()
    {
        return CanBurnWebs();
    }

    public bool EldinLanternCaveSecondChest()
    {
        return CanBurnWebs();
    }

    public bool EldinLanternCaveLanternChest()
    {
        return Has("Lantern");
    }

    // Poes

    public bool EldinLanternCavePoe()
    {
        return CanBurnWebs() && Has("ShadowCrystal");
    }

/* ------------------------------

        Eldin Stockcave

------------------------------ */

    public bool EldinStockcaveUpperChest()
    {
        return Has("IronBoots");
    }

    public bool EldinStockcaveLanternChest()
    {
        return Has("IronBoots") && Has("Lantern");
    }

    public bool EldinStockcaveLowestChest()
    {
        return Has("IronBoots");
    }

/* ------------------------------

        Lake Lantern Cave

------------------------------ */

    public bool LakeLanternCaveFirstChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveSecondChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveThirdChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveFourthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveFifthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveSixthChest()
    {
        return Has("Lantern") && CanSmash();
    }

    public bool LakeLanternCaveSeventhChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveEighthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveNinthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveTenthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveEleventhChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveTwelfthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveThirteenthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveFourteenthChest()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"]) && CanSmash();
    }

    public bool LakeLanternCaveEndLanternChest()
    {
        return Has("Lantern") && CanSmash();
    }

    // Poes

    public bool LakeLanternCaveFirstPoe()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveSecondPoe()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveFinalPoe()
    {
        return (Has("Lantern") || SettingsStatus["IgnoreLanternLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

/* ------------------------------

        Lanayru Spring

------------------------------ */

    public bool LanayruSpringUnderwaterLeftChest()
    {
        return Has("IronBoots");
    }

    public bool LanayruSpringUnderwaterRightChest()
    {
        return Has("IronBoots");
    }

    public bool LanayruSpringBackRoomLeftChest()
    {
        return Has("Clawshot");
    }

    public bool LanayruSpringBackRoomRightChest()
    {
        return Has("Clawshot");
    }

    public bool LanayruSpringBackRoomLanternChest()
    {
        return Has("Clawshot") && Has("Lantern");
    }

    public bool LanayruSpringWestDoubleClawshotChest()
    {
        return Has("Clawshot", 2);
    }

    public bool LanayruSpringEastDoubleClawshotChest()
    {
        return Has("Clawshot", 2);
    }

/* ------------------------------

        Castle Town

------------------------------ */

    public bool AgithaFemaleAntReward()
    {
        return Has("GoldenBug", 1);
    }

    public bool AgithaFemaleBeetleReward()
    {
        return Has("GoldenBug", 2);
    }

    public bool AgithaFemaleButterflyReward()
    {
        return Has("GoldenBug", 3);
    }

    public bool AgithaFemaleDayflyReward()
    {
        return Has("GoldenBug", 4);
    }

    public bool AgithaFemaleDragonflyReward()
    {
        return Has("GoldenBug", 5);
    }

    public bool AgithaFemaleGrasshopperReward()
    {
        return Has("GoldenBug", 6);
    }

    public bool AgithaFemaleLadybugReward()
    {
        return Has("GoldenBug", 7);
    }

    public bool AgithaFemaleMantisReward()
    {
        return Has("GoldenBug", 8);
    }

    public bool AgithaFemalePhasmidReward()
    {
        return Has("GoldenBug", 9);
    }

    public bool AgithaFemalePillBugReward()
    {
        return Has("GoldenBug", 10);
    }

    public bool AgithaFemaleSnailReward()
    {
        return Has("GoldenBug", 11);
    }

    public bool AgithaFemaleStagBeetleReward()
    {
        return Has("GoldenBug", 12);
    }

    public bool AgithaMaleAntReward()
    {
        return Has("GoldenBug", 13);
    }

    public bool AgithaMaleBeetleReward()
    {
        return Has("GoldenBug", 14);
    }

    public bool AgithaMaleButterflyReward()
    {
        return Has("GoldenBug", 15);
    }

    public bool AgithaMaleDayflyReward()
    {
        return Has("GoldenBug", 16);
    }

    public bool AgithaMaleDragonflyReward()
    {
        return Has("GoldenBug", 17);
    }

    public bool AgithaMaleGrasshopperReward()
    {
        return Has("GoldenBug", 18);
    }

    public bool AgithaMaleLadybugReward()
    {
        return Has("GoldenBug", 19);
    }

    public bool AgithaMaleMantisReward()
    {
        return Has("GoldenBug", 20);
    }

    public bool AgithaMalePhasmidReward()
    {
        return Has("GoldenBug", 21);
    }

    public bool AgithaMalePillBugReward()
    {
        return Has("GoldenBug", 22);
    }

    public bool AgithaMaleSnailReward()
    {
        return Has("GoldenBug", 23);
    }

    public bool AgithaMaleStagBeetleReward()
    {
        return Has("GoldenBug", 24);
    }

    public bool CastleTownMaloMartMagicArmor()
    {
        return Has("Wallet", 1)
                || SettingsStatus["WalletIncrease"]
                || SettingsStatus["IgnoreWalletLogic"];
    }

    public bool CharloDonationBlessing()
    {
        return true;
    }

    public bool STARPrize1()
    {
        return Has("Clawshot");
    }

    public bool STARPrize2()
    {
        return Has("Clawshot", 2);
    }

    public bool Jovani20PoeSoulReward()
    {
        return Has("PoeSoul", 20)
            && Has("ShadowCrystal")
            && CanCompleteMDH();
    }

    public bool Jovani60PoeSoulReward()
    {
        return Has("PoeSoul", 60)
            && Has("ShadowCrystal")
            && CanCompleteMDH();
    }

    public bool TelmaInvoice()
    {
        return Has("FetchQuest", 1);
    }

    public bool DoctorsOfficeBalconyChest()
    {
        return Has("ShadowCrystal") && Has("FetchQuest", 2);
    }

    // Poes

    public bool JovaniHousePoe()
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Bulblin Camp

------------------------------ */

    public bool BulblinCampFirstChestUnderTowerAtEntrance()
    {
        return true;
    }

    public bool BulblinCampSmallChestinBackofCamp()
    {
        return true;
    }

    public bool BulblinCampRoastedBoar()
    {
        return HasDamagingItem();
    }

    public bool BulblinGuardKey()
    {
        return CanDefeatBulblin();
    }

    public bool OutsideArbitersGroundsLanternChest()
    {
        return Has("Lantern");
    }

    // Poes

    public bool BulblinCampPoe()
    {
        return Has("ShadowCrystal")
            && (Has("DesertKeys") || SettingsStatus["SmallKeysKeysy"] || SettingsStatus["EarlyArbiters"]);
    }

    public bool OutsideArbitersGroundsPoe()
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Cave of Ordeals

------------------------------ */

    public bool CaveofOrdealsGreatFairyReward()
    {
        return Has("Clawshot", 2)
            && CanDefeatPoe()
            && CanDefeatFreezard()
            && CanDefeatDarknut();
    }

    // Poes

    public bool CaveofOrdealsFloor17Poe()
    {
        return Has("Spinner")
            && Has("ShadowCrystal");
    }

    public bool CaveofOrdealsFloor33Poe()
    {
        return Has("ShadowCrystal")
            && Has("DominionRod", 2)
            && CanDefeatBeamos();
    }

    public bool CaveofOrdealsFloor44Poe()
    {
        return Has("ShadowCrystal")
            && Has("Clawshot", 2)
            && (Has("Bow") || Has("B&C"));
    }

/* ------------------------------

        Dungeon Checks 

------------------------------ */

/* ------------------------------

        Forest Temple 

------------------------------ */

    public bool ForestTempleEntranceVinesChest()
    {
        return CanDefeatWalltula();
    }

    public bool ForestTempleCentralChestBehindStairs()
    {
        return Has("Boomerang");
    }

    public bool ForestTempleCentralNorthChest()
    {
        return Has("Lantern");
    }

    public bool ForestTempleWindlessBridgeChest()
    {
        return true;
    }

    public bool ForestTempleSecondMonkeyUnderBridgeChest()
    {
        return Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"];
    }

    public bool ForestTempleTotemPoleChest()
    {
        return true;
    }

    public bool ForestTempleWestTileWormRoomVinesChest()
    {
        return true;
    }

    public bool ForestTempleWestDekuLikeChest()
    {
        return CanDefeatWalltula();
    }

    public bool ForestTempleBigBabaKey()
    {
        return CanDefeatWalltula() && CanDefeatBigBaba();
    }

    public bool ForestTempleGaleBoomerang()
    {
        return CanDefeatOok();
    }

    public bool ForestTempleWestTileWormChestBehindStairs()
    {
        return Has("Boomerang");
    }

    public bool ForestTempleCentralChestHangingFromWeb()
    {
        return CanCutHangingWeb();
    }

    public bool ForestTempleBigKeyChest()
    {
        return Has("Boomerang");
    }

    public bool ForestTempleEastWaterCaveChest()
    {
        return true;
    }

    public bool ForestTempleNorthDekuLikeChest()
    {
        return Has("Boomerang");
    }

    public bool ForestTempleEastTileWormChest()
    {
        return CanDefeatWalltula()
            && CanDefeatSkulltula()
            && CanDefeatTileWorm()
            && Has("Boomerang")
            && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool ForestTempleDiababaHeartContainer()
    {
        return CanDefeatDiababa();
    }

    public bool ForestTempleDungeonReward()
    {
        return CanDefeatDiababa();
    }

/* ------------------------------

            Goron Mines 

------------------------------ */

    public bool GoronMinesEntranceChest()
    {
        return CanPressMinesSwitch() && CanBreakWoodenDoor();
    }

    public bool GoronMinesMainMagnetRoomBottomChest()
    {
        return true;
    }

    public bool GoronMinesGorAmatoChest()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesGorAmatoKeyShard()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesGorAmatoSmallChest()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesMagnetMazeChest()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesCrystalSwitchRoomUnderwaterChest()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesCrystalSwitchRoomSmallChest()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesAfterCrystalSwitchRoomMagnetWallChest()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesOutsideBeamosChest()
    {
        return true;
    }

    public bool GoronMinesGorEbizoKeyShard()
    {
        return true;
    }

    public bool GoronMinesGorEbizoChest()
    {
        return true;
    }

    public bool GoronMinesChestBeforeDangoro()
    {
        return Has("IronBoots");
    }

    public bool GoronMinesDangoroChest()
    {
        return Has("IronBoots") && CanDefeatDangoro();
    }

    public bool GoronMinesBeamosRoomChest()
    {
        return Has("IronBoots") && CanDefeatDangoro() && Has("Bow");
    }

    public bool GoronMinesGorLiggsKeyShard()
    {
        return Has("IronBoots") && CanDefeatDangoro() && Has("Bow");
    }

    public bool GoronMinesGorLiggsChest()
    {
        return Has("IronBoots") && CanDefeatDangoro() && Has("Bow");
    }

    public bool GoronMinesMainMagnetRoomTopChest()
    {
        return Has("IronBoots")
            && (Has("GMSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatDangoro()
            && Has("Bow");
    }

    public bool GoronMinesOutsideClawshotChest()
    {
        return Has("Clawshot") && (Has("Bow") || Has("Slingshot"));
    }

    public bool GoronMinesOutsideUnderwaterChest()
    {
        return Has("IronBoots")
            && (HasWaterBombs() || Has("Sword"));
    }

    public bool GoronMinesFyrusHeartContainer()
    {
        return CanDefeatFyrus();
    }

    public bool GoronMinesDungeonReward()
    {
        return CanDefeatFyrus();
    }

/* ------------------------------

        Lakebed Temple 

------------------------------ */

    public bool LakebedTempleLobbyLeftChest()
    {
        return Has("ZoraArmor");
    }

    public bool LakebedTempleLobbyRearChest()
    {
        return Has("ZoraArmor");
    }

    public bool LakebedTempleStalactiteRoomChest()
    {
        return CanLaunchBombs();
    }

    public bool LakebedTempleCentralRoomSmallChest()
    {
        return true;
    }

    public bool LakebedTempleCentralRoomChest()
    {
        return true;
    }

    public bool LakebedTempleEastLowerWaterwheelStalactiteChest()
    {
        return CanLaunchBombs();
    }

    public bool LakebedTempleEastSecondFloorSouthwestChest()
    {
        return true;
    }

    public bool LakebedTempleEastSecondFloorSoutheastChest()
    {
        return CanLaunchBombs()
            || (Has("Clawshot") && CanSmash());
    }

    public bool LakebedTempleEastWaterSupplySmallChest()
    {
        return (CanLaunchBombs() || Has("Clawshot"))
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && CanSmash();
    }

    public bool LakebedTempleBeforeDekuToadAlcoveChest()
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
            );
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterLeftChest()
    {
        return (CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("ZoraArmor")
            && Has("IronBoots");
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterRightChest()
    {
        return (CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("ZoraArmor")
            && Has("IronBoots");
    }

    public bool LakebedTempleDekuToadChest()
    {
        return (CanLaunchBombs() || (Has("Clawshot") && CanSmash()))
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("ZoraArmor")
            && Has("IronBoots")
            && CanDefeatDekuToad()
            && HasWaterBombs();
    }

    public bool LakebedTempleChandelierChest()
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleCentralRoomSpireChest()
    {
        return CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots");
    }

    public bool LakebedTempleEastWaterSupplyClawshotChest()
    {
        return (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("IronBoots")
            && Has("Clawshot")
            && CanSmash();
    }

    public bool LakebedTempleWestLowerSmallChest()
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplySmallChest()
    {
        return CanLaunchBombs() && Has("IronBoots") && Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplyChest()
    {
        return CanLaunchBombs() && Has("IronBoots") && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorSouthwestUnderwaterChest()
    {
        return CanLaunchBombs() && Has("IronBoots") && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorCentralSmallChest()
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorNortheastChest()
    {
        return CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleWestSecondFloorSoutheastChest()
    {
        return CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleBigKeyChest()
    {
        return Has("ZoraArmor")
            && CanLaunchBombs()
            && Has("IronBoots")
            && Has("Clawshot")
            && HasWaterBombs();
    }

    public bool LakebedTempleUnderwaterMazeSmallChest()
    {
        return Has("ZoraArmor") && CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleEastLowerWaterwheelBridgeChest()
    {
        return CanLaunchBombs()
            && (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot");
    }

    public bool LakebedTempleMorpheelHeartContainer()
    {
        return CanDefeatMorpheel();
    }

    public bool LakebedTempleDungeonReward()
    {
        return CanDefeatMorpheel();
    }

/* ------------------------------

        Arbiter's Grounds 

------------------------------ */

    public bool ArbitersGroundsEntranceChest()
    {
        return CanBreakWoodenDoor();
    }

    public bool ArbitersGroundsTorchRoomWestChest()
    {
        return true;
    }

    public bool ArbitersGroundsTorchRoomEastChest()
    {
        return true;
    }

    public bool ArbitersGroundsEastLowerTurnableRedeadChest()
    {
        return Has("ShadowCrystal");
    }

    public bool ArbitersGroundsEastUpperTurnableChest()
    {
        return Has("AGSmallKey", 2) || SettingsStatus["SmallKeysKeysy"];
    }

    public bool ArbitersGroundsEastUpperTurnableRedeadChest()
    {
        return (Has("AGSmallKey", 2) || SettingsStatus["SmallKeysKeysy"])
            && HasDamagingItem();
    }

    public bool ArbitersGroundsGhoulRatRoomChest()
    {
        return (Has("AGSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatBubble()
            && CanDefeatStalchild()
            && CanDefeatRedeadKnight();
    }

    public bool ArbitersGroundsWestSmallChestBehindBlock()
    {
        return true;
    }

    public bool ArbitersGroundsWestChandelierChest()
    {
        return (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsWestStalfosWestChest()
    {
        return CanBreakWoodenDoor()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatGhoulRat();
    }

    public bool ArbitersGroundsWestStalfosNortheastChest()
    {
        return CanBreakWoodenDoor()
            && (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatGhoulRat();
    }

    public bool ArbitersGroundsNorthTurningRoomChest()
    {
        return Has("Clawshot");
    }

    public bool ArbitersGroundsDeathSwordChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && CanDefeatDeathSword();
    }

    public bool ArbitersGroundsSpinnerRoomFirstSmallChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomSecondSmallChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomLowerCentralSmallChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomStalfosAlcoveChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsSpinnerRoomLowerNorthChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && CanDefeatStalfos()
            && Has("Spinner");
    }

    public bool ArbitersGroundsBigKeyChest()
    {
        return (Has("AGSmallKey", 5) || SettingsStatus["SmallKeysKeysy"])
            && Has("Clawshot")
            && Has("Spinner")
            && CanSmash();
    }

    public bool ArbitersGroundsStallordHeartContainer()
    {
        return CanDefeatStallord();
    }

    // Poes

    public bool ArbitersGroundsTorchRoomPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool ArbitersGroundsEastTurningRoomPoe()
    {
        return Has("ShadowCrystal") && Has("Clawshot");
    }

    public bool ArbitersGroundsHiddenWallPoe()
    {
        return (Has("AGSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
            && CanDefeatRedeadKnight()
            && Has("ShadowCrystal");
    }

    public bool ArbitersGroundsWestPoe()
    {
        return (Has("AGSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

/* ------------------------------

        Snowpeak Ruins 

------------------------------ */

    public bool SnowpeakRuinsLobbyEastArmorChest()
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsLobbyWestArmorChest()
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsMansionMap()
    {
        return true;
    }

    public bool SnowpeakRuinsEastCourtyardBuriedChest()
    {
        return Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsEastCourtyardChest()
    {
        return true;
    }

    public bool SnowpeakRuinsOrdonPumpkinChest()
    {
        return CanDefeatChilfos();
    }

    public bool SnowpeakRuinsWestCourtyardBuriedChest()
    {
        return Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsWoodenBeamCentralChest()
    {
        return CanDefeatIceKeese();
    }

    public bool SnowpeakRuinsWoodenBeamNorthwestChest()
    {
        return CanDefeatIceKeese();
    }

    public bool SnowpeakRuinsCourtyardCentralChest()
    {
        return Has("B&C") || 
            (
                HasBombs()
                    && (Has("SRSmallKey", 2) || Has("Cheese") || SettingsStatus["SmallKeysKeysy"])
            );
    }

    public bool SnowpeakRuinsBallandChain()
    {
        return CanDefeatDarkhammer();
    }

    public bool SnowpeakRuinsChestAfterDarkhammer()
    {
        return CanDefeatDarkhammer() && Has("B&C");
    }

    public bool SnowpeakRuinsBrokenFloorChest()
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsWoodenBeamChandelierChest()
    {
        return Has("B&C")
            && (Has("Cheese") || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsLobbyChandelierChest()
    {
        return Has("B&C")
            && ((Has("Cheese") && Has("SRSmallKey", 3))
                || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool SnowpeakRuinsNortheastChandelierChest()
    {
        return CanDefeatChilfos() && Has("B&C");
    }

    public bool SnowpeakRuinsWestCannonRoomCentralChest()
    {
        return Has("B&C");
    }

    public bool SnowpeakRuinsWestCannonRoomCornerChest()
    {
        return CanSmash();
    }

    public bool SnowpeakRuinsChapelChest()
    {
        return CanDefeatChilfos();
    }

    public bool SnowpeakRuinsBlizzetaHeartContainer()
    {
        return CanDefeatBlizzeta();
    }

    public bool SnowpeakRuinsDungeonReward()
    {
        return CanDefeatBlizzeta();
    }

    // Poes

    public bool SnowpeakRuinsLobbyPoe()
    {
        return Has("ShadowCrystal");
    }

    public bool SnowpeakRuinsLobbyArmorPoe()
    {
        return Has("ShadowCrystal") && Has("B&C");
    }

    public bool SnowpeakRuinsIceRoomPoe()
    {
        return Has("ShadowCrystal");
    }

/* ------------------------------

        Temple of Time

------------------------------ */

    public bool TempleofTimeLobbyLanternChest()
    {
        return Has("Lantern");
    }

    public bool TempleofTimeFirstStaircaseGohmaGateChest()
    {
        return CanDefeatYoungGohma();
    }

    public bool TempleofTimeFirstStaircaseWindowChest()
    {
        return HasRangedItem();
    }

    public bool TempleofTimeFirstStaircaseArmosChest()
    {
        return HasRangedItem() && CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberEastChest()
    {
        return CanDefeatArmos();
    }

    public bool TempleofTimeArmosAntechamberNorthChest()
    {
        return true;
    }

    public bool TempleofTimeMovingWallBeamosRoomChest()
    {
        return Has("Bow");
    }

    public bool TempleofTimeScalesGohmaChest()
    {
        return CanDefeatYoungGohma() && CanDefeatBabyGohma();
    }

    public bool TempleofTimeGilloutineChest()
    {
        return true;
    }

    public bool TempleofTimeChestBeforeDarknut()
    {
        return CanDefeatArmos() && CanDefeatBabyGohma() && CanDefeatYoungGohma();
    }

    public bool TempleofTimeDarknutChest()
    {
        return CanDefeatDarknut();
    }

    public bool TempleofTimeScalesUpperChest()
    {
        return Has("Spinner") && Has("Clawshot");
    }

    public bool TempleofTimeFloorSwitchPuzzleRoomUpperChest()
    {
        return Has("Clawshot");
    }

    public bool TempleofTimeBigKeyChest()
    {
        return CanDefeatHelmasaur() && Has("Clawshot");
    }

    public bool TempleofTimeMovingWallDinalfosRoomChest()
    {
        return CanDefeatDinalfos() && Has("DominionRod") && Has("Bow");
    }

    public bool TempleofTimeArmosAntechamberStatueChest()
    {
        return Has("DominionRod");
    }

    public bool TempleofTimeArmogohmaHeartContainer()
    {
        return CanDefeatArmogohma();
    }

    public bool TempleofTimeDungeonReward()
    {
        return CanDefeatArmogohma();
    }

    // Poes

    public bool TempleofTimePoeBehindGate()
    {
        return Has("ShadowCrystal") && Has("DominionRod");
    }

    public bool TempleofTimePoeAboveScales()
    {
        return Has("ShadowCrystal") && Has("Spinner") && Has("Clawshot");
    }

/* ------------------------------

        City in the Sky 

------------------------------ */

    public bool CityinTheSkyUnderwaterEastChest()
    {
        return Has("IronBoots");
    }

    public bool CityinTheSkyUnderwaterWestChest()
    {
        return Has("IronBoots");
    }

    public bool CityinTheSkyWestWingFirstChest()
    {
        return true;
    }

    public bool CityinTheSkyEastFirstWingChestAfterFans()
    {
        return Has("Clawshot");
    }

    public bool CityinTheSkyEastTileWormSmallChest()
    {
        return Has("Clawshot");
    }

    public bool CityinTheSkyEastWingAfterDinalfosLedgeChest()
    {
        return Has("Clawshot") && CanDefeatTileWorm() && CanDefeatDinalfos();
    }

    public bool CityinTheSkyEastWingAfterDinalfosAlcoveChest()
    {
        return Has("Clawshot") && CanDefeatTileWorm() && CanDefeatDinalfos();
    }

    public bool CityinTheSkyAeralfosChest()
    {
        return Has("Clawshot")
            && Has("IronBoots")
            && CanDefeatDinalfos()
            && CanDefeatTileWorm()
            && CanDefeatAeralfos();
    }

    public bool CityinTheSkyEastWingLowerLevelChest()
    {
        return Has("Clawshot", 2) && CanDefeatTileWorm() && CanDefeatDinalfos();
    }

    public bool CityinTheSkyWestWingBabaBalconyChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestWingNarrowLedgeChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestWingTileWormChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyBabaTowerTopSmallChest()
    {
        return CanDefeatBabaSerpent() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerNarrowLedgeChest()
    {
        return CanDefeatBabaSerpent() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyBabaTowerAlcoveChest()
    {
        return CanDefeatBabaSerpent() && Has("Clawshot", 2) && CanDefeatBigBaba();
    }

    public bool CityinTheSkyWestGardenCornerChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLoneIslandChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLowerChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyWestGardenLedgeChest()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyCentralOutsideLedgeChest()
    {
        return CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyCentralOutsidePoeIslandChest()
    {
        return CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyBigKeyChest()
    {
        return Has("Clawshot")
            && CanDefeatDinalfos()
            && CanDefeatWalltula()
            && CanDefeatKargorok()
            && Has("IronBoots")
            && Has("ShadowCrystal");
    }

    public bool CityinTheSkyChestBelowBigKeyChest()
    {
        return CanDefeatHelmasaur();
    }

    public bool CityinTheSkyChestBehindNorthFan()
    {
        return Has("Clawshot", 2);
    }

    public bool CityinTheSkyArgorokHeartContainer()
    {
        return CanDefeatArgorok();
    }

    public bool CityinTheSkyDungeonReward()
    {
        return CanDefeatArgorok();
    }

    // Poes

    public bool CityinTheSkyGardenIslandPoe()
    {
        return Has("Clawshot", 2) && Has("ShadowCrystal");
    }

    public bool CityinTheSkyPoeAboveCentralFan()
    {
        return CanDefeatWalltula() && Has("ShadowCrystal");
    }

/* ------------------------------

        Palace of Twilight

------------------------------ */

    public bool PalaceofTwilightWestWingFirstRoomCentralChest()
    {
        return CanDefeatZantHead();
    }

    public bool PalaceofTwilightWestWingChestBehindWallofDarkness()
    {
        return Has("Sword", 4) && Has("Clawshot");
    }

    public bool PalaceofTwilightWestWingSecondRoomCentralChest()
    {
        return Has("Clawshot")
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomLowerSouthChest()
    {
        return Has("Clawshot")
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightWestWingSecondRoomSoutheastChest()
    {
        return Has("Clawshot", 2)
            && CanDefeatZantHead()
            && (Has("PoTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomZantHeadChest()
    {
        return Has("Clawshot") && CanDefeatZantHead();
    }

    public bool PalaceofTwilightEastWingFirstRoomNorthSmallChest()
    {
        return Has("Clawshot");
    }

    public bool PalaceofTwilightEastWingSecondRoomNortheastChest()
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot", 2)
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomNorthwestChest()
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot")
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomSouthwestChest()
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot", 2)
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingSecondRoomSoutheastChest()
    {
        return CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && Has("Clawshot", 2)
            && (Has("PoTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomEastAlcove()
    {
        return Has("Sword", 4) || 
            (Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]));
    }

    public bool PalaceofTwilightEastWingFirstRoomWestAlcove()
    {
        return Has("Sword", 4) || 
            (Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]));
    }

    public bool PalaceofTwilightCollectBothSols()
    {
        return Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralFirstRoomChest()
    {
        return CanDefeatZantHead() && Has("Sword", 4);
    }

    public bool PalaceofTwilightBigKeyChest()
    {
        return CanDefeatZantHead()
            && Has("Clawshot", 2)
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralOutdoorChest()
    {
        return CanDefeatZantHead()
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightCentralTowerChest()
    {
        return CanDefeatZantHead()
            && Has("Clawshot")
            && Has("Sword", 4)
            && (Has("PoTSmallKey", 6) || SettingsStatus["SmallKeysKeysy"]);
    }

    public bool PalaceofTwilightZantHeartContainer()
    {
        return CanDefeatZant();
    }

/* ------------------------------

        Hyrule Castle 

------------------------------ */

    public bool HyruleCastleGraveyardGraveSwitchRoomRightChest()
    {
        return CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomFrontLeftChest()
    {
        return CanSmash();
    }

    public bool HyruleCastleGraveyardGraveSwitchRoomBackLeftChest()
    {
        return CanSmash();
    }

    public bool HyruleCastleGraveyardOwlStatueChest()
    {
        return CanSmash() && Has("Lantern") && Has("DominionRod", 2);
    }

    public bool HyruleCastleEastWingBoomerangPuzzleChest()
    {
        return Has("Boomerang");
    }

    public bool HyruleCastleEastWingBalconyChest()
    {
        return Has("Boomerang");
    }

    public bool HyruleCastleWestCourtyardNorthSmallChest()
    {
        return CanDefeatBokoblin();
    }

    public bool HyruleCastleWestCourtyardCentralSmallChest()
    {
        return CanDefeatBokoblin();
    }

    public bool HyruleCastleKingBulblinKey()
    {
        return CanDefeatKingBulblinCastle();
    }

    public bool HyruleCastleMainHallNortheastChest()
    {
        return CanDefeatBokoblin() && CanDefeatLizalfos() && Has("Clawshot");
    }

    public bool HyruleCastleLanternStaircaseChest()
    {
        return Has("Clawshot", 2) && CanDefeatDarknut() && Has("Boomerang");
    }

    public bool HyruleCastleMainHallSouthwestChest()
    {
        return CanDefeatDarknut()
            && Has("Clawshot", 2)
            && CanKnockDownHCPainting()
            && Has("Boomerang")
            && Has("Lantern");
    }

    public bool HyruleCastleMainHallNorthwestChest()
    {
        return CanDefeatDarknut()
            && Has("Clawshot", 2)
            && CanKnockDownHCPainting()
            && Has("Boomerang")
            && Has("Lantern");
    }

    public bool HyruleCastleSoutheastBalconyTowerChest()
    {
        return CanDefeatAeralfos();
    }

    public bool HyruleCastleBigKeyChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFirstChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSecondChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomThirdChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFourthChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFifthChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFirstSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSecondSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomThirdSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFourthSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomFifthSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSixthSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomSeventhSmallChest()
    {
        return true;
    }

    public bool HyruleCastleTreasureRoomEighthSmallChest()
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
