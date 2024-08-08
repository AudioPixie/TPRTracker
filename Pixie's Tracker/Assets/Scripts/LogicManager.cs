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

    public GameObject RoomHyruleCastleEntrance; // for Go mode

    // all for checks, not rooms
    public GameObject RoomLakebedTempleEastWingSecondFloor;
    public GameObject RoomLakebedTempleWestWing;
    public GameObject RoomGoronMinesUpperEastWing;
    public GameObject RoomForestTempleWestWing;

    // i think these are all golden wolves
    public GameObject RoomDeathMountainTrail; // good
    public GameObject RoomZorasDomain;
    public GameObject RoomHiddenVillage;
    public GameObject RoomSnowpeakClimb;
    public GameObject RoomNorthFaronWoods;
    public GameObject RoomLakeHylia;

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
        return Has("Bombs") 
            && (CanAccessEldin() || CanAccessLanayru());
    }

    public bool HasWaterBombs()
    {
        return Has("Bombs") 
            && (Has("WaterBombs") || SettingsStatus["IgnoreWaterBombLogic"])
            && (CanAccessEldin() || CanAccessLanayru());
    }

    public bool CanSmash()
    {
        return Has("B&C") || HasBombs();
    }

    public bool CanBurnWebs()
    {
        return Has("Lantern") || HasBombs() || Has("B&C");
    }

    public bool HasRangedItem()
    {
        return Has("B&C")
            || Has("Slingshot")
            || Has("Bow")
            || Has("Clawshot")
            || Has("Boomerang");
    }

    public bool CanUseBottledFairy()
    {
        return Has("Bottle") && CanAccessLanayru();
    }

    public bool CanUseBottledFairies()
    {
        return Has("Bottle", 2) && CanAccessLanayru();
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
            && (
                Has("Lantern")
                || (
                    SettingsStatus["SmallKeysKeysy"]
                    && (HasBombs() || Has("IronBoots"))
                )
            )
            && CanBurnWebs()
            && Has("Boomerang")
            && CanDefeatBokoblin()
            && (
                Has("FTSmallKey", 4)
                || SettingsStatus["SmallKeysKeysy"]
            );
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
        return Has("ShadowCrystal") && CanAccessEldin();
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
        return CanDoMoonBoots() && Has("HiddenSkill") && Has("Sword", 2);
    }

    public bool CanDoHSMoonBoots()
    {
        return CanDoMoonBoots() && Has("HiddenSkill", 4) && Has("Sword") && Has("Shield");
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
                || Has("Boss1")
                || CanDoLJA()
                || CanDoMapGlitch()
            );
    }

    public bool CanSkipKeyToDekuToad()
    {
        return SettingsStatus["SmallKeysKeysy"]
            || Has("HiddenSkill", 3)
            || CanDoBSMoonBoots()
            || CanDoJSMoonBoots()
            || CanDoLJA()
            || (
                HasBombs() 
                && (HasHeavyMod() || Has("HiddenSkill", 6))
            );
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
        return (Has("Boss1") || SettingsStatus["FaronEscape"]) 
            && CanCompletePrologue()
            && FaronTwilightCleared();
    }

    public bool CanCompleteMDH()
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

    public bool GoMode() // need to make sure this is processed last
    {
        return RoomHyruleCastleEntrance.GetComponent<RoomBehaviour>().isAccessible
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

    public bool CanGetArrows() // used for closed faron woods mainly - CanClearForest or can access lost woods
    {
        return CanClearForest()
            || Has("ShadowCrystal")
            || (
                SettingsStatus["GlitchedLogic"]
                && Has("Lantern")
                && Has("Bombs")
                && CanDoLJA()
            );
    }

    public bool CanAccessEldin() // used for map glitch - if you can warp to any of these places in glitched, you can access kak gorge
    {
        return CanClearForest()
            || (
                Has("ShadowCrystal")
                && SettingsStatus["UnlockMapRegions"]
                && (
                    SettingsStatus["SkipEldinTwilight"]
                    || SettingsStatus["SkipLanayruTwilight"]
                    || SettingsStatus["EarlySnowpeak"]
                )
            );
    }

    public bool CanAccessLanayru() // for fairies - can warp to lanayru/snowpeak, or can warp to eldin and break out
    {
        return (
                Has("ShadowCrystal")
                && SettingsStatus["UnlockMapRegions"]
                && (SettingsStatus["SkipLanayruTwilight"] || SettingsStatus["EarlySnowpeak"])
            )
            || (
                (
                    CanClearForest() 
                    || (Has("ShadowCrystal")
                        && SettingsStatus["UnlockMapRegions"]
                        && SettingsStatus["SkipEldinTwilight"]
                    )
                )
                && (
                    CanSmash()
                    || Has("GateKeys")
                    || SettingsStatus["SmallKeysKeysy"]
                    || SettingsStatus["GlitchedLogic"]
                )
            );
    }

/* ------------------------------

            Enemies

------------------------------ */

    public bool CanDefeatAeralfos()
    {
        return Has("Clawshot") 
            && (
                Has("Sword") 
                || Has("B&C") 
                || Has("ShadowCrystal")
                || (CanDoNicheStuff() && Has("IronBoots"))
            );
    }

    public bool CanDefeatArmos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || Has("Clawshot")
            || HasBombs()
            || Has("Spinner")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBabaSerpent()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBabyGohma()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("Clawshot")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBokoblin()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("ShadowCrystal")
            || HasBombs()
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
        return (
                Has("IronBoots") 
                || (SettingsStatus["GlitchedLogic"] && Has("MagicArmor"))
            )
            && (   
                Has("Sword") 
                || Has("Clawshot")
                || (Has("Shield") && Has("HiddenSkill", 2))
            );
    }

    public bool CanDefeatBombling()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || Has("Clawshot");
    }

    public bool CanDefeatBomskit()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword()
            || (CanDoNicheStuff() && Has("IronBoots"));
    }

    public bool CanDefeatBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatBulblin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatChilfos()
    {
        return Has("Sword")
            || Has("B&C")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || Has("Spinner")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatChu()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || Has("Clawshot")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatChuWorm()
    {
        return (
                Has("Sword")
                || Has("B&C")
                || Has("Bow")
                || (CanDoNicheStuff() && Has("IronBoots"))
                || Has("Spinner")
                || Has("ShadowCrystal")
                || CanUseBacksliceAsSword()
            )
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("HiddenSkill", 2) // no shield??
            || Has("Slingshot")
            || Has("Clawshot")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatFireKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatFireToadpoli()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (Has("HiddenSkill", 2) && Has("Shield", 2));
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || (Has("HiddenSkill", 2) && Has("Shield"))
            || Has("Slingshot")
            || Has("Clawshot")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || Has("Slingshot");
    }

    public bool CanDefeatHelmasaur()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatHelmasaurus()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatIceBubble()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatIceKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("ShadowCrystal")
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword(); // was this supposed to be clawshot?
    }

    public bool CanDefeatLeever()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs();
    }

    public bool CanDefeatLizalfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatMiniFreezard()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatMoldorm()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs();
    }

    public bool CanDefeatPoisonMite()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Lantern")
            || Has("Spinner")
            || Has("ShadowCrystal");
    }

    public bool CanDefeatPuppet()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatRat()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatRedeadKnight()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShadowDekuBaba()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("HiddenSkill", 2)
            || Has("Slingshot")
            || Has("Clawshot")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShadowKeese()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("Slingshot")
            || Has("ShadowCrystal")
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShadowVermin()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatShellBlade()
    {
        return HasWaterBombs() 
            || (
                Has("Sword") 
                && (
                    Has("IronBoots") 
                        || (CanDoNicheStuff() && Has("MagicArmor"))
                )
            );
    }

    public bool CanDefeatSkullfish()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal");
    }

    public bool CanDefeatSkulltula()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatStalchild()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatTektite()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatTileWorm()
    {
        return (
                Has("Sword")
                || Has("B&C")
                || Has("Bow")
                || Has("ShadowCrystal")
                || Has("Spinner")
                || (CanDoNicheStuff() && Has("IronBoots"))
                || HasBombs()
                || CanUseBacksliceAsSword()
            )
            && Has("Boomerang");
    }

    public bool CanDefeatToado()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || Has("Spinner")
            || Has("ShadowCrystal");
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
            || Has("Slingshot")
            || (Has("Bow") && CanGetArrows())
            || Has("Boomerang")
            || Has("Clawshot");
    }

    public bool CanDefeatWhiteWolfos()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs();
    }

    public bool CanDefeatYoungGohma()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("Spinner")
            || Has("ShadowCrystal")
            || HasBombs();
    }

    public bool CanDefeatZantHead()
    {
        return Has("ShadowCrystal") || Has("Sword") || CanUseBacksliceAsSword();
    }

    public bool CanDefeatOok()
    {
        return Has("Sword")
            || Has("B&C")
            || (Has("Bow") && CanGetArrows())
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || HasBombs()
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatDangoro()
    {
        return (
                (
                    Has("Sword")
                    || Has("ShadowCrystal")
                    || (
                        CanDoNicheStuff() && Has("B&C")
                        || (Has("Bow") && HasBombs())
                    )
                ) && Has("IronBoots")
            );
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
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || HasBombs()
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
            || Has("ShadowCrystal")
            || Has("Bow", 3)
            || CanUseBacksliceAsSword();
    }

    public bool CanDefeatKingBulblinCastle()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("ShadowCrystal")
            || Has("Bow", 3);
    }

    public bool CanDefeatDeathSword()
    {
        return (
                Has("Sword")
                && (
                    Has("Boomerang")
                    || Has("Bow")
                    || Has("Clawshot")
                )
                && Has("ShadowCrystal")
            );
    }

    public bool CanDefeatDarkhammer()
    {
        return Has("Sword")
            || Has("B&C")
            || Has("Bow")
            || (CanDoNicheStuff() && Has("IronBoots"))
            || Has("ShadowCrystal")
            || HasBombs();
    }

    public bool CanDefeatPhantomZant()
    {
        return Has("ShadowCrystal") || Has("Sword");
    }

    public bool CanDefeatDiababa()
    {
        return CanLaunchBombs()
            || (
                Has("Boomerang")
                    && (Has("Sword")
                        || Has("B&C")
                        || (CanDoNicheStuff() && Has("IronBoots"))
                        || Has("ShadowCrystal")
                        || HasBombs()
                    )
                );
    }

    public bool CanDefeatFyrus()
    {
        return Has("Bow") && Has("IronBoots") && Has("Sword");
    }

    public bool CanDefeatMorpheel()
    {
        return (
            (
                Has("ZoraArmor")
                && Has("IronBoots")
                && Has("Sword")
                && Has("Clawshot")
            )
            || (
                CanDoNicheStuff()
                && (
                    Has("Clawshot")
                    && CanDoAirRefill()
                    && Has("Sword")
                )
            )
        );
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
                && (
                    Has("IronBoots") 
                    || (CanDoNicheStuff() && Has("MagicArmor"))
                )
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
        return Has("ShadowCrystal") && Has("Sword", 3) && Has("HiddenSkill");
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
        return Has("ShadowCrystal") && RoomDeathMountainTrail.GetComponent<RoomBehaviour>().isAccessible;
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
        return (CanCompletePrologue() && Has("Lantern"))
            || (SettingsStatus["GlitchedLogic"] && (Has("Lantern") || CanDoMapGlitch()));
    }

    public bool FaronMistSouthChest()
    {
        return (CanCompletePrologue() && Has("Lantern"))
            || (SettingsStatus["GlitchedLogic"] && (Has("Lantern") || CanDoMapGlitch()));
    }

    public bool FaronMistStumpChest()
    {
        return (CanCompletePrologue() && Has("Lantern"))
            || (SettingsStatus["GlitchedLogic"] && (Has("Lantern") || Has("ShadowCrystal")));
    }

    public bool FaronWoodsGoldenWolf()
    {
        return true;
    }

    public bool FaronWoodsOwlStatueChest()
    {
        return (
                SettingsStatus["GlitchedLogic"]
                && (
                    (
                        CanSmash()
                        && Has("DominionRod", 2)
                        && CanClearForest()
                        && Has("ShadowCrystal")
                    )
                    || CanDoMapGlitch()
                )
            )
            || !SettingsStatus["GlitchedLogic"];
    }

    public bool FaronWoodsOwlStatueSkyCharacter()
    {
        return Has("DominionRod", 2)
            && (
                CanClearForest()
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch())
            );
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
        return CanDefeatBabaSerpent() 
            && (CanKnockDownHangingBaba()
                || (SettingsStatus["GlitchedLogic"] && 
                    (Has("Sword")
                    || Has("ShadowCrystal")
                    || Has("Slingshot")
                    || Has("B&C")
                    || HasBombs())));
    }

    public bool SacredGrovePastOwlStatueChest()
    {
        return Has("DominionRod")
            || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
    }

    public bool SacredGroveSpinnerChest()
    {
        return Has("Spinner")
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
    }

    public bool SacredGrovePedestalMasterSword()
    {
        return true;
    }

    public bool SacredGrovePedestalShadowCrystal()
    {
        return true;
    }

    // Faron Field

    public bool FaronFieldBridgeChest()
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoStorage());
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
        return Has("Boomerang") || Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && Has("B&C"));
    }

    // Kakariko Gorge

    public bool KakarikoGorgeDoubleClawshotChest()
    {
        return Has("Clawshot", 2)
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("ShadowCrystal")));
    }

    public bool KakarikoGorgeOwlStatueChest()
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && 
                (CanDoLJA() || CanDoStorage() || CanDoEBMoonBoots()));
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
        return (
                Has("Boss2") 
                && !SettingsStatus["UnrequiredDungeonsAreBarren"]
            ) || 
            (
                (
                    Has("Clawshot") 
                    && (Has("IronBoots") || Has("ShadowCrystal"))
                )
                || (
                    SettingsStatus["GlitchedLogic"] 
                    && (Has("Clawshot") || CanDoLJA())
                )
            );
    }

    // Eldin Field

    public bool BridgeofEldinOwlStatueChest()
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("ShadowCrystal")));
    }

    public bool BridgeofEldinOwlStatueSkyCharacter() 
    {
        return Has("DominionRod", 2);
    }

    public bool EldinFieldBombRockChest()
    {
        return CanSmash()
            || (SettingsStatus["GlitchedLogic"] 
                && CanDoMapGlitch() 
                    || (CanDoEBMoonBoots() && CanDoLJA()));
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
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LanayruFieldSkulltulaGrottoChest()
    {
        return (SettingsStatus["GlitchedLogic"] || CanDefeatSkulltula()) 
            && Has("Lantern") 
            && CanBreakWoodenDoor();
    }

    public bool LanayruFieldSpinnerTrackChest()
    {
        return (CanSmash() && Has("Spinner"))
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
    }

    public bool LanayruIceBlockPuzzleCaveChest()
    {
        return Has("B&C");
    }

    // West Hyrule Field - pick up here

    public bool HyruleFieldAmphitheaterOwlStatueChest()
    {
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] 
                && 
                    (CanDoLJA()
                    || CanDoMapGlitch()
                    || CanDoEBMoonBoots()));
    }

    public bool HyruleFieldAmphitheaterOwlStatueSkyCharacter()
    {
        return Has("DominionRod", 2);
    }

    public bool WestHyruleFieldGoldenWolf()
    {
        return Has("ShadowCrystal") && RoomZorasDomain.GetComponent<RoomBehaviour>().isAccessible;
    }

    public bool WestHyruleFieldHelmasaurGrottoChest()
    {
        return CanDefeatHelmasaur();
    }

    // North Castle Town

    public bool NorthCastleTownGoldenWolf()
    {
        return RoomHiddenVillage.GetComponent<RoomBehaviour>().isAccessible 
            && Has("ShadowCrystal") 
            && CanCompleteMDH();
    }

    // Outside South Castle Town

    public bool OutsideSouthCastleTownDoubleClawshotChasmChest()
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

    public bool OutsideSouthCastleTownFountainChest()
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

    public bool OutsideSouthCastleTownGoldenWolf()
    {
        return RoomNorthFaronWoods.GetComponent<RoomBehaviour>().isAccessible && Has("ShadowCrystal");
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
        return Has("IronBoots") || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
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
        return (Has("Clawshot") && Has("DominionRod", 2))
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
    }

    public bool LakeHyliaBridgeOwlStatueSkyCharacter()
    {
        return Has("Clawshot") && Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
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
        return RoomZorasDomain.GetComponent<RoomBehaviour>().isAccessible
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    public bool IzaRagingRapidsMinigame()
    {
        return RoomZorasDomain.GetComponent<RoomBehaviour>().isAccessible
            && (Has("Sword") || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]))
            && Has("Bow");
    }

    // Zora's Domain

    public bool ZorasDomainChestBehindWaterfall()
    {
        return Has("ShadowCrystal")
            || (SettingsStatus["GlitchedLogic"] && 
                (CanDoBSMoonBoots()
                || Has("Spinner")
                || (HasBombs() && Has("Sword"))
                || CanDoLJA()));
    }

    public bool ZorasDomainChestByMotherandChildIsles()
    {
        return true;
    }

    public bool ZorasDomainExtinguishAllTorchesChest()
    {
        return Has("Boomerang") 
            && (Has("IronBoots")
                || (SettingsStatus["GlitchedLogic"] && HasHeavyMod()));
    }

    public bool ZorasDomainLightAllTorchesChest()
    {
        return Has("Lantern") 
            && (Has("IronBoots")
                || (SettingsStatus["GlitchedLogic"] && HasHeavyMod()));
    }

    public bool ZorasDomainUnderwaterGoron()
    {
        return Has("IronBoots") 
            && (Has("ZoraArmor") || SettingsStatus["GlitchedLogic"])
            && HasWaterBombs();
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
        return Has("ShadowCrystal") && RoomLakeHylia.GetComponent<RoomBehaviour>().isAccessible;
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
        return Has("DominionRod", 2)
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
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
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] 
                && (CanDoLJA() || (Has("ShadowCrystal") && HasBombs())));
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
            && (Has("Bow") || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched()))
            && Has("DominionRod");
    }

    public bool IliaCharm()
    {
        return Has("Bow")
            || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched());
    }

    public bool SkybookFromImpaz()
    {
        return (Has("Bow") || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched())) 
            && Has("DominionRod");
    }

/* ------------------------------

        Overworld Poes 

------------------------------ */

    // Faron Province

    public bool FaronMistPoe()
    {
        return (CanCompletePrologue() || SettingsStatus["GlitchedLogic"])
            && Has("ShadowCrystal");
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
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool SnowpeakBlizzardPoe()
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
    }

    public bool SnowpeakPoeAmongTrees()
    {
        return Has("ShadowCrystal")
            && (SettingsStatus["EarlySnowpeak"]
                || Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
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
            && ((Has("Clawshot") && Has("Bow"))
                || (SettingsStatus["GlitchedLogic"] && CanDoHiddenVillageGlitched()))
            && Has("DominionRod")
            && Has("ShadowCrystal");
    }

/* ------------------------------

            Bugs 

------------------------------ */

    public bool FaronFieldFemaleBeetle()
    {
        return Has("Boomerang") 
            || Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && (CanDoMapGlitch() || CanDoEBMoonBoots()));
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
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool LakeHyliaBridgeMaleMantis()
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool LanayruFieldFemaleStagBeetle()
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool LanayruFieldMaleStagBeetle()
    {
        return Has("Boomerang") || Has("Clawshot"); // || CanGetBugWithLantern for glitched
    }

    public bool WestHyruleFieldFemaleButterfly()
    {
        return Has("Boomerang") 
            || Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()); // || CanGetBugWithLantern for glitched
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
        return (CanSmash() && Has("IronBoots"))
            || (SettingsStatus["GlitchedLogic"] 
                && HasHeavyMod() 
                && (CanSmash() || CanDoMapGlitch()));
    }

    public bool KakarikoVillageBombRockSpireHeartPiece()
    {
        return (CanLaunchBombs() && Has("Boomerang"))
            || (SettingsStatus["GlitchedLogic"] 
                && (CanDoMapGlitch()
                    || (CanLaunchBombs() && (Has("Boomerang") || Has("Clawshot")))));
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
        return CanSmash() || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
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

    public bool KakarikoVillageMaloMartRedPotion()
    {
        return true;
    }

    public bool KakarikoVillageMaloMartWoodenShield()
    {
        return true;
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
            && RoomSnowpeakClimb.GetComponent<RoomBehaviour>().isAccessible
            && (Has("ReekfishScent") 
                || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                || SettingsStatus["EarlySnowpeak"]
                || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch()));
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
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && Has("Clawshot"));
    }

    public bool EldinStockcaveLanternChest()
    {
        return (Has("IronBoots") 
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("Clawshot"))))
            && Has("Lantern");
    }

    public bool EldinStockcaveLowestChest()
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && (CanDoLJA() || Has("Clawshot")));
    }

/* ------------------------------

        Lake Lantern Cave

------------------------------ */

    public bool LakeLanternCaveFirstChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveSecondChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveThirdChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveFourthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveFifthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveSixthChest()
    {
        return Has("Lantern") && CanSmash();
    }

    public bool LakeLanternCaveSeventhChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveEighthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveNinthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveTenthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveEleventhChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveTwelfthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveThirteenthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveFourteenthChest()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"] 
            || SettingsStatus["GlitchedLogic"]) 
            && CanSmash();
    }

    public bool LakeLanternCaveEndLanternChest()
    {
        return Has("Lantern") && CanSmash();
    }

    // Poes

    public bool LakeLanternCaveFirstPoe()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"]
            || SettingsStatus["GlitchedLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveSecondPoe()
    {
        return (Has("Lantern") 
            || SettingsStatus["IgnoreLanternLogic"]
            || SettingsStatus["GlitchedLogic"])
            && CanSmash()
            && Has("ShadowCrystal");
    }

    public bool LakeLanternCaveFinalPoe()
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

    public bool LanayruSpringUnderwaterLeftChest()
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LanayruSpringUnderwaterRightChest()
    {
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
    }

    public bool LanayruSpringBackRoomLeftChest()
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots());
    }

    public bool LanayruSpringBackRoomRightChest()
    {
        return Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots());
    }

    public bool LanayruSpringBackRoomLanternChest()
    {
        return (Has("Clawshot")
            || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots())) 
            && Has("Lantern");
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
            && (SettingsStatus["SkipMDH"] || Has("Boss3"));
    }

    public bool Jovani60PoeSoulReward()
    {
        return Has("PoeSoul", 60)
            && Has("ShadowCrystal")
            && (SettingsStatus["SkipMDH"] || Has("Boss3"));
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
        return (Has("Spinner")
            || (SettingsStatus["GlitchedLogic"] && Has("Clawshot") && CanDoLJA()))
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

    public bool ForestTempleEntranceVinesChest()
    {
        return CanDefeatWalltula();
    }

    public bool ForestTempleCentralChestBehindStairs()
    {
        return Has("Boomerang")
            || (SettingsStatus["GlitchedLogic"] 
                && Has("Boomerang") 
                && (CanDefeatBombling() || CanSmash()));
    }

    public bool ForestTempleCentralNorthChest()
    {
        return Has("Lantern")
            || (SettingsStatus["GlitchedLogic"] 
                && CanDoLJA() 
                && RoomForestTempleWestWing.GetComponent<RoomBehaviour>().isAccessible);
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
        return !SettingsStatus["GlitchedLogic"] || CanDefeatBombling() || CanSmash();
    }

    public bool ForestTempleWestTileWormRoomVinesChest()
    {
        return !SettingsStatus["GlitchedLogic"] || CanDefeatBombling() || CanSmash();
    }

    public bool ForestTempleWestDekuLikeChest()
    {
        return CanDefeatWalltula() || SettingsStatus["GlitchedLogic"];
    }

    public bool ForestTempleBigBabaKey()
    {
        return (CanDefeatWalltula() || SettingsStatus["GlitchedLogic"]) && CanDefeatBigBaba();
    }

    public bool ForestTempleGaleBoomerang()
    {
        return CanDefeatOok() || (SettingsStatus["GlitchedLogic"] && HasBombs());
    }

    public bool ForestTempleWestTileWormChestBehindStairs()
    {
        return Has("Boomerang")
            || (SettingsStatus["GlitchedLogic"] 
                && Has("Boomerang") 
                && (CanDefeatBombling() || CanSmash()));
    }

    public bool ForestTempleCentralChestHangingFromWeb()
    {
        return CanCutHangingWeb()
            || (SettingsStatus["GlitchedLogic"] && CanDoJSMoonBoots());
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
        return Has("Boomerang")
            || (SettingsStatus["GlitchedLogic"] 
                && HasBombs() 
                && Has("Sword") 
                && Has("Clawshot"));
    }

    public bool ForestTempleEastTileWormChest()
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
        return (CanPressMinesSwitch() && CanBreakWoodenDoor())
            || (SettingsStatus["GlitchedLogic"] && (CanDoBSMoonBoots() || CanBreakWoodenDoor()));
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
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
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
        return Has("IronBoots")
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
    }

    public bool GoronMinesDangoroChest()
    {
        return Has("IronBoots") && CanDefeatDangoro();
    }

    public bool GoronMinesBeamosRoomChest()
    {
        return Has("IronBoots") 
            && CanDefeatDangoro() 
            && (Has("Bow")
                || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
    }

    public bool GoronMinesGorLiggsKeyShard()
    {
        return Has("IronBoots") 
            && CanDefeatDangoro() 
            && (Has("Bow")
                || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
    }

    public bool GoronMinesGorLiggsChest()
    {
        return Has("IronBoots") 
            && CanDefeatDangoro() 
            && (Has("Bow")
                || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
    }

    public bool GoronMinesMainMagnetRoomTopChest()
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

    public bool GoronMinesOutsideClawshotChest()
    {
        return Has("Clawshot") 
            && (Has("Bow") || Has("Slingshot") || SettingsStatus["GlitchedLogic"]);
    }

    public bool GoronMinesOutsideUnderwaterChest()
    {
        return (Has("IronBoots")
            && (HasWaterBombs() || Has("Sword")))
            || (SettingsStatus["GlitchedLogic"] && HasHeavyMod());
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
        return CanLaunchBombs()
            || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
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
            ) || 
            (
                SettingsStatus["GlitchedLogic"] 
                && (CanDoLJA() 
                    || ((Has("LTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]) 
                        && (CanLaunchBombs() || Has("Clawshot"))))
            );
    }

    public bool LakebedTempleBeforeDekuToadUnderwaterLeftChest()
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

    public bool LakebedTempleBeforeDekuToadUnderwaterRightChest()
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

    public bool LakebedTempleDekuToadChest()
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
            && Has("Clawshot")
            && (
                (Has("IronBoots") && CanSmash())
                || 
                (SettingsStatus["GlitchedLogic"] && CanLaunchBombs())
            );
    }

    public bool LakebedTempleWestLowerSmallChest()
    {
        return Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplySmallChest()
    {
        return CanLaunchBombs() 
            && (Has("IronBoots") || SettingsStatus["GlitchedLogic"])
            && Has("Clawshot");
    }

    public bool LakebedTempleWestWaterSupplyChest()
    {
        return CanLaunchBombs() 
            && (Has("IronBoots") || SettingsStatus["GlitchedLogic"])
            && Has("Clawshot");
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
            && (Has("IronBoots") || SettingsStatus["GlitchedLogic"])
            && Has("Clawshot")
            && HasWaterBombs();
    }

    public bool LakebedTempleUnderwaterMazeSmallChest()
    {
        return Has("ZoraArmor") && CanLaunchBombs() && Has("Clawshot");
    }

    public bool LakebedTempleEastLowerWaterwheelBridgeChest()
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

    public bool ArbitersGroundsDungeonReward()
    {
        return CanDefeatStallord();
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
                    && (Has("SRSmallKey", 2) 
                        || (Has("Cheese") && !SettingsStatus["GlitchedLogic"])
                        || SettingsStatus["SmallKeysKeysy"])
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
            && (CanDefeatTileWorm() || SettingsStatus["GlitchedLogic"])
            && CanDefeatAeralfos();
    }

    public bool CityinTheSkyEastWingLowerLevelChest()
    {
        return Has("Clawshot", 2) 
            && ((CanDefeatTileWorm() && CanDefeatDinalfos()) 
                || SettingsStatus["GlitchedLogic"]);
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
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && !SettingsStatus["GlitchedLogic"]);
    }

    public bool PalaceofTwilightEastWingFirstRoomWestAlcove()
    {
        return Has("Sword", 4) || 
            (Has("Clawshot")
            && CanDefeatPhantomZant()
            && CanDefeatZantHead()
            && CanDefeatShadowBeast()
            && (Has("PoTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"])
            && !SettingsStatus["GlitchedLogic"]);
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
        return CanDefeatBokoblin() || SettingsStatus["GlitchedLogic"];
    }

    public bool HyruleCastleWestCourtyardCentralSmallChest()
    {
        return CanDefeatBokoblin() || SettingsStatus["GlitchedLogic"];
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
        return (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")))
            && CanDefeatDarknut() 
            && Has("Boomerang");
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

    public bool OutsideLinksHouse(string neighbour)
    {
        if (neighbour == "OrdonVillage")
        {
            return true;
        }

        else if (neighbour == "OrdonSpring")
        {
            return true;
        }

        else if (neighbour == "OrdonLinksHouse")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonLinksHouse(string neighbour)
    {
        if (neighbour == "OutsideLinksHouse")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonVillage(string neighbour)
    {
        if (neighbour == "OutsideLinksHouse")
        {
            return true;
        }

        else if (neighbour == "OrdonRanch")
        {
            return true;
        }

        else if (neighbour == "OrdonSerasShop")
        {
            return true;
        }

        else if (neighbour == "OrdonShieldHouse")
        {
            return true;
        }

        else if (neighbour == "OrdonSwordHouse")
        {
            return true;
        }

        else if (neighbour == "OrdonBosHouse")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonSerasShop(string neighbour)
    {
        if (neighbour == "OrdonVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonShieldHouse(string neighbour)
    {
        if (neighbour == "OrdonVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonSwordHouse(string neighbour)
    {
        if (neighbour == "OrdonVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonBosHouse(string neighbour)
    {
        if (neighbour == "OrdonVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonRanch(string neighbour)
    {
        if (neighbour == "OrdonVillage")
        {
            return true;
        }

        else if (neighbour == "OrdonRanchStable")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonRanchStable(string neighbour)
    {
        if (neighbour == "OrdonRanch")
        {
            return true;
        }

        else if (neighbour == "OrdonRanchGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonRanchGrotto(string neighbour)
    {
        if (neighbour == "OrdonRanchStable")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OrdonSpring(string neighbour)
    {
        if (neighbour == "OutsideLinksHouse")
        {
            return true;
        }

        else if (neighbour == "SouthFaronWoods")
        {
            return (Has("Sword") && Has("Slingshot"))
                || SettingsStatus["SkipPrologue"]
                || SettingsStatus["GlitchedLogic"];
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

    public bool SouthFaronWoods(string neighbour)
    {
        if (neighbour == "OrdonSpring")
        {
            return (Has("Sword") && Has("Slingshot"))
                || SettingsStatus["SkipPrologue"];
        }

        else if (neighbour == "FaronWoodsCave")
        {
            return true;
        }

        else if (neighbour == "SouthFaronWoodsOwlStatueArea")
        {
            return CanSmash();
        }

        else if (neighbour == "FaronField")
        {
            return CanClearForest();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SouthFaronWoodsOwlStatueArea(string neighbour)
    {
        if (neighbour == "SouthFaronWoods")
        {
            return CanSmash();
        }

        else if (neighbour == "MistAreaNearOwlStatueChest")
        {
            return CanClearForest() && Has("DominionRod", 2) && Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool FaronWoodsCave(string neighbour)
    {
        if (neighbour == "SouthFaronWoods")
        {
            return Has("ShadowCrystal") 
                || CanClearForest() 
                || (SettingsStatus["GlitchedLogic"] && CanClearForestGlitched());
        }

        else if (neighbour == "MistAreaNearFaronWoodsCave")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaNearFaronWoodsCave(string neighbour)
    {
        if (neighbour == "FaronWoodsCave")
        {
            return true;
        }

        else if (neighbour == "MistAreaUnderOwlStatueChest")
        {
            return Has("Lantern") || Has("ShadowCrystal");
        }

        else if (neighbour == "MistAreaInsideMist")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaInsideMist(string neighbour)
    {
        if (neighbour == "MistAreaNearNorthFaronWoods")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "MistAreaNearFaronWoodsCave")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "MistAreaUnderOwlStatueChest")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "MistAreaFaronMistCave")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaUnderOwlStatueChest(string neighbour)
    {
        if (neighbour == "MistAreaInsideMist")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "MistAreaCenterStump")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaNearOwlStatueChest(string neighbour)
    {
        if (neighbour == "MistAreaUnderOwlStatueChest")
        {
            return true;
        }

        else if (neighbour == "SouthFaronWoodsOwlStatueArea")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaCenterStump(string neighbour)
    {
        if (neighbour == "MistAreaInsideMist")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "MistAreaNearNorthFaronWoods")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaNearNorthFaronWoods(string neighbour)
    {
        if (neighbour == "MistAreaInsideMist")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "MistAreaNearNorthFaronWoodsCave")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "NorthFaronWoods")
        {
            return Has("FaronKeys") 
                || SettingsStatus["SmallKeysKeysy"] 
                || SettingsStatus["SkipPrologue"];;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MistAreaFaronMistCave(string neighbour)
    {
        if (neighbour == "MistAreaInsideMist")
        {
            return Has("Lantern") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool NorthFaronWoods(string neighbour)
    {
        if (neighbour == "MistAreaNearNorthFaronWoods")
        {
            return true;
        }

        else if (neighbour == "LostWoods")
        {
            return Has("ShadowCrystal")
                || (SettingsStatus["GlitchedLogic"] && HasBombs() && CanDoLJA());
        }

        else if (neighbour == "ForestTempleEntrance")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Sacred Grove

    public bool LostWoods(string neighbour)
    {
        if (neighbour == "LostWoodsLowerBattleArena")
        {
            return (CanDefeatSkullKid() && Has("ShadowCrystal")) 
                || SettingsStatus["ToTOpen"] 
                || SettingsStatus["ToTOpenGrove"]
                || (SettingsStatus["GlitchedLogic"] && CanDoJSMoonBoots());
        }

        else if (neighbour == "LostWoodsUpperBattleArena")
        {
            return (CanDefeatSkullKid() && Has("ShadowCrystal")) 
                || SettingsStatus["ToTOpen"] 
                || SettingsStatus["ToTOpenGrove"];
        }

        else if (neighbour == "NorthFaronWoods")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LostWoodsLowerBattleArena(string neighbour)
    {
        if (neighbour == "LostWoods")
        {
            return true;
        }

        else if (neighbour == "SacredGroveLower")
        {
            return CanDefeatSkullKid()
                || SettingsStatus["ToTOpen"] 
                || SettingsStatus["ToTOpenGrove"];
        }

        else if (neighbour == "LostWoodsBabaSerpentGrotto")
        {
            return CanSmash() && Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LostWoodsUpperBattleArena(string neighbour)
    {
        if (neighbour == "SacredGroveBeforeBlock")
        {
            return CanDefeatSkullKid()
                || SettingsStatus["ToTOpen"] 
                || SettingsStatus["ToTOpenGrove"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LostWoodsBabaSerpentGrotto(string neighbour)
    {
        if (neighbour == "LostWoodsLowerBattleArena")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGroveBeforeBlock(string neighbour)
    {
        if (neighbour == "LostWoodsUpperBattleArena")
        {
            return true;
        }

        else if (neighbour == "SacredGroveUpper")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGroveUpper(string neighbour)
    {
        if (neighbour == "SacredGroveLower")
        {
            return true;
        }

        else if (neighbour == "SacredGrovePast")
        {
            return SettingsStatus["ToTOpen"]
                || SettingsStatus["ToTOpenGrove"]
                || (Has("Sword", 3) && CanDefeatShadowBeast());
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGroveLower(string neighbour)
    {
        if (neighbour == "LostWoodsLowerBattleArena")
        {
            return true;
        }

        else if (neighbour == "SacredGroveUpper")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SacredGrovePast(string neighbour)
    {
        if (neighbour == "TempleofTimeEntrance")
        {
            return SettingsStatus["ToTOpen"] || Has("Sword", 3);
        }

        else if (neighbour == "SacredGroveUpper")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Faron Field

    public bool FaronField(string neighbour)
    {
        if (neighbour == "SouthFaronWoods")
        {
            return true;
        }

        else if (neighbour == "KakarikoGorge")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return Has("GateKeys") 
                || SettingsStatus["SmallKeysKeysy"] 
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

    public bool FaronFieldCornerGrotto(string neighbour)
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

/* ------------------------------

        Eldin Province 

------------------------------ */

// Eldin Field

    public bool KakarikoGorge(string neighbour)
    {
        if (neighbour == "EldinLanternCave")
        {
            return CanSmash();
        }

        else if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "FaronField")
        {
            return true;
        }

        else if (neighbour == "EldinField")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinLanternCave(string neighbour)
    {
        if (neighbour == "KakarikoGorge")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinField(string neighbour)
    {
        if (neighbour == "OutsideCastleTownEast")
        {
            return SettingsStatus["GlitchedLogic"];
        }

        else if (neighbour == "EldinFieldLavaCaveUpper")
        {
            return Has("Clawshot") || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "EldinFieldLavaCaveLower")
        {
            return SettingsStatus["GlitchedLogic"] && (Has("ShadowCrystal") || CanDoLJA());
        }

        else if (neighbour == "KakarikoGorge")
        {
            return CanSmash();
        }

        else if (neighbour == "LowerKakarikoVillage")
        {
            return Has("GateKeys") || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "NorthEldinField")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "EldinFieldBombskitGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "EldinFieldWaterBombFishGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool NorthEldinField(string neighbour)
    {
        if (neighbour == "EldinField")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else if (neighbour == "HiddenVillage")
        {
            return Has("FetchQuest", 3);
        }

        else if (neighbour == "EldinFieldGrottoPlatform")
        {
            return Has("Spinner");
        }

        else if (neighbour == "LanayruField")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinFieldGrottoPlatform(string neighbour)
    {
        if (neighbour == "NorthEldinField")
        {
            return Has("Spinner");
        }

        else if (neighbour == "EldinFieldStalfosGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinFieldLavaCaveUpper(string neighbour)
    {
        if (neighbour == "EldinField")
        {
            return true;
        }

        else if (neighbour == "EldinFieldLavaCaveLower")
        {
            return Has("IronBoots") || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinFieldLavaCaveLower(string neighbour)
    {
        if (neighbour == "EldinField")
        {
            return Has("Clawshot");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool EldinFieldBombskitGrotto(string neighbour)
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

    public bool EldinFieldWaterBombFishGrotto(string neighbour)
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

    public bool EldinFieldStalfosGrotto(string neighbour)
    {
        if (neighbour == "EldinFieldGrottoPlatform")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Kakariko Village

    public bool LowerKakarikoVillage(string neighbour)
    {
        if (neighbour == "KakarikoGorge")
        {
            return Has("ShadowCrystal") || Has("GateKeys") || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "EldinField")
        {
            return Has("GateKeys") || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "DeathMountainTrail")
        {
            return Has("IronBoots") || Has("Boss2");
        }

        else if (neighbour == "KakarikoBugHouse")
        {
            return true;
        }

        else if (neighbour == "KakarikoGraveyard")
        {
            return true;
        }

        else if (neighbour == "KakarikoBarnesBombShopLower")
        {
            return true;
        }

        else if (neighbour == "UpperKakarikoVillage")
        {
            return Has("Boss2") || CanSmash();
        }

        else if (neighbour == "KakarikoMaloMart")
        {
            return true;
        }

        else if (neighbour == "KakarikoRenadosSanctuary")
        {
            return true;
        }

        else if (neighbour == "KakarikoEldeInn")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool UpperKakarikoVillage(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "KakarikoTopofWatchtower")
        {
            return Has("Boss2");
        }

        else if (neighbour == "KakarikoBarnesBombShopLower")
        {
            return true;
        }

        else if (neighbour == "KakarikoWatchtower")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoTopofWatchtower(string neighbour)
    {
        if (neighbour == "UpperKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "KakarikoWatchtower")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoRenadosSanctuary(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoMaloMart(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoEldeInn(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoBugHouse(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoBarnesBombShopLower(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "UpperKakarikoVillage")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoWatchtower(string neighbour)
    {
        if (neighbour == "UpperKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "KakarikoTopofWatchtower")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool KakarikoGraveyard(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "LakeHylia")
        {
            return (
                    (Has("GateKeys") || SettingsStatus["SmallKeysKeysy"]) 
                    && (Has("IronBoots") || Has("ZoraArmor") || (SettingsStatus["GlitchedLogic"] && HasHeavyMod())) 
                    && HasWaterBombs()
                ) 
                || (
                    SettingsStatus["GlitchedLogic"] 
                    && (
                        (HasHeavyMod() || Has("ZoraArmor")) 
                        && (
                            (
                                HasBombs() 
                                && (Has("Sword") || Has("Spinner"))
                            ) 
                            || CanDoLJA() 
                            || CanDoMoonBoots()
                        )
                    )  
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Death Mountain

    public bool DeathMountainTrail(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return true;
        }

        else if (neighbour == "DeathMountainVolcano")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool DeathMountainVolcano(string neighbour)
    {
        if (neighbour == "DeathMountainTrail")
        {
            return true;
        }

        else if (neighbour == "DeathMountainSumoHall")
        {
            return Has("IronBoots") && (CanDefeatGoron() || Has("Boss2"));
        }

        else if (neighbour == "DeathMountainElevatorLower")
        {
            return SettingsStatus["MinesOpen"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool DeathMountainElevatorLower(string neighbour)
    {
        if (neighbour == "DeathMountainVolcano")
        {
            return true;
        }

        else if (neighbour == "DeathMountainSumoHallElevator")
        {
            return Has("IronBoots");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool DeathMountainSumoHall(string neighbour)
    {
        if (neighbour == "DeathMountainVolcano")
        {
            return true;
        }

        else if (neighbour == "DeathMountainSumoHallElevator")
        {
            return Has("IronBoots") || SettingsStatus["MinesNoWrestling"] || SettingsStatus["MinesOpen"];
        }

        else if (neighbour == "GoronMinesEntrance")
        {
            return Has("IronBoots") || SettingsStatus["MinesNoWrestling"] || SettingsStatus["MinesOpen"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool DeathMountainSumoHallElevator(string neighbour)
    {
        if (neighbour == "DeathMountainElevatorLower")
        {
            return Has("IronBoots");
        }

        else if (neighbour == "DeathMountainSumoHall")
        {
            return Has("IronBoots") 
                || SettingsStatus["MinesNoWrestling"] 
                || SettingsStatus["MinesOpen"]
                || (Has("Spinner") && SettingsStatus["GlitchedLogic"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Hidden Village

    public bool HiddenVillage(string neighbour)
    {
        if (neighbour == "NorthEldinField")
        {
            return Has("FetchQuest", 3);
        }

        else if (neighbour == "HiddenVillageImpazHouse")
        {
            return Has("Bow") && Has("DominionRod");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool HiddenVillageImpazHouse(string neighbour)
    {
        if (neighbour == "HiddenVillage")
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

        Lanayru Province 

------------------------------ */

// Hyrule Field

    public bool LanayruField(string neighbour)
    {
        if (neighbour == "LanayruIcePuzzleCave")
        {
            return CanSmash();
        }

        else if (neighbour == "ZorasDomainWestLedge")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "HyruleFieldNearSpinnerRails")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "NorthEldinField")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownWest")
        {
            return true;
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

    public bool HyruleFieldNearSpinnerRails(string neighbour)
    {
        if (neighbour == "LanayruField")
        {
            return CanSmash();
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LanayruIcePuzzleCave(string neighbour)
    {
        if (neighbour == "LanayruField")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LanayruFieldSkulltulaGrotto(string neighbour)
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

    public bool LanayruFieldPoeGrotto(string neighbour)
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

    public bool OutsideCastleTownWest(string neighbour)
    {
        if (neighbour == "OutsideCastleTownWestGrottoLedge")
        {
            return Has("Clawshot") || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "LanayruField")
        {
            return true;
        }

        else if (neighbour == "CastleTownWest")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownWestGrottoLedge(string neighbour)
    {
        if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownWestHelmasaurGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownWestHelmasaurGrotto(string neighbour)
    {
        if (neighbour == "OutsideCastleTownWestGrottoLedge")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownEast(string neighbour)
    {
        if (neighbour == "EldinField")
        {
            return true;
        }

        else if (neighbour == "CastleTownEast")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownSouth(string neighbour)
    {
        if (neighbour == "CastleTownSouth")
        {
            return true;
        }

        else if (neighbour == "LakeHylia")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownSouthTektiteGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideCastleTownSouthTektiteGrotto(string neighbour)
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

    public bool LakeHyliaBridge(string neighbour)
    {
        if (neighbour == "LakeHyliaBridgeGrottoLedge")
        {
            return CanLaunchBombs() && Has("Clawshot");
        }

        else if (neighbour == "HyruleFieldNearSpinnerRails")
        {
            return CanSmash() || (SettingsStatus["GlitchedLogic"] && CanDoMapGlitch());
        }

        else if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else if (neighbour == "LakeHylia")
        {
            return true;
        }

        else if (neighbour == "FaronField")
        {
            return Has("GateKeys") 
                || SettingsStatus["SmallKeysKeysy"] 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaBridgeGrottoLedge(string neighbour)
    {
        if (neighbour == "LakeHyliaBridge")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaBridgeBubbleGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaBridgeBubbleGrotto(string neighbour)
    {
        if (neighbour == "LakeHyliaBridgeGrottoLedge")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

// Castle Town

    public bool CastleTownWest(string neighbour)
    {
        if (neighbour == "OutsideCastleTownWest")
        {
            return true;
        }

        else if (neighbour == "CastleTownCenter")
        {
            return true;
        }

        else if (neighbour == "CastleTownSouth")
        {
            return true;
        }

        else if (neighbour == "CastleTownSTARGame")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownSTARGame(string neighbour)
    {
        if (neighbour == "CastleTownWest")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownCenter(string neighbour)
    {
        if (neighbour == "CastleTownWest")
        {
            return true;
        }

        else if (neighbour == "CastleTownNorthBehindFirstDoor")
        {
            return CanCompleteMDH();
        }

        else if (neighbour == "CastleTownEast")
        {
            return true;
        }

        else if (neighbour == "CastleTownSouth")
        {
            return true;
        }

        else if (neighbour == "CastleTownMaloMart")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownMaloMart(string neighbour)
    {
        if (neighbour == "CastleTownCenter")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownNorthBehindFirstDoor(string neighbour)
    {
        if (neighbour == "CastleTownCenter")
        {
            return CanCompleteMDH();
        }

        else if (neighbour == "HyruleCastleEntrance")
        {
            return SettingsStatus["HCOpen"]
                || (SettingsStatus["HCVanilla"] && Has("Boss8"))
                || (SettingsStatus["HCFusedShadows"] && Has("FusedShadow", 3))
                || (SettingsStatus["HCMirrorShards"] && Has("MirrorShard", 4))
                || (SettingsStatus["HCAllDungeons"] && HasCompletedAllDungeons());
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownEast(string neighbour)
    {
        if (neighbour == "CastleTownCenter")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownEast")
        {
            return true;
        }

        else if (neighbour == "CastleTownSouth")
        {
            return true;
        }

        else if (neighbour == "CastleTownDoctorsOfficeLower")
        {
            return Has("FetchQuest", 2);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownDoctorsOfficeBalcony(string neighbour)
    {
        if (neighbour == "CastleTownEast")
        {
            return true;
        }

        else if (neighbour == "CastleTownDoctorsOfficeLower")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownDoctorsOfficeLower(string neighbour)
    {
        if (neighbour == "CastleTownDoctorsOfficeBalcony")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "CastleTownEast")
        {
            return Has("FetchQuest", 2);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownSouth(string neighbour)
    {
        if (neighbour == "CastleTownWest")
        {
            return true;
        }

        else if (neighbour == "CastleTownCenter")
        {
            return true;
        }

        else if (neighbour == "CastleTownEast")
        {
            return true;
        }

        else if (neighbour == "OutsideCastleTownSouth")
        {
            return true;
        }

        else if (neighbour == "CastleTownAgithasHouse")
        {
            return true;
        }

        else if (neighbour == "CastleTownJovanisHouse")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "CastleTownTelmasBar")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownAgithasHouse(string neighbour)
    {
        if (neighbour == "CastleTownSouth")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownJovanisHouse(string neighbour)
    {
        if (neighbour == "CastleTownSouth")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CastleTownTelmasBar(string neighbour)
    {
        if (neighbour == "CastleTownSouth")
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

    public bool LakeHylia(string neighbour)
    {
        if (neighbour == "LakeHyliaLongCave")
        {
            return CanSmash();
        }

        else if (neighbour == "LakebedTempleEntrance")
        {
            return (
                    Has("ZoraArmor")
                    && (
                        SettingsStatus["EarlyLakebed"]
                        || (Has("IronBoots") && HasWaterBombs())
                    )
                )
                || (
                    SettingsStatus["GlitchedLogic"] 
                    && (Has("ZoraArmor") || CanDoAirRefill())
                );
        }

        else if (neighbour == "LakeHyliaBridge")
        {
            return true;
        }

        else if (neighbour == "GerudoDesert")
        {
            return Has("AurusMemo");
        }

        else if (neighbour == "UpperZorasRiver")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "LakeHyliaLanayruSpring")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaShellBladeGrotto")
        {
            return true;
        }

        else if (neighbour == "LakeHyliaWaterToadpoliGrotto")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "CityinTheSkyEntrance")
        {
            return Has("Clawshot") && (Has("Skybook", 7) || SettingsStatus["EarlyCitS"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaLanayruSpring(string neighbour)
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

    public bool LakeHyliaLongCave(string neighbour)
    {
        if (neighbour == "LakeHylia")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakeHyliaShellBladeGrotto(string neighbour)
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

    public bool LakeHyliaWaterToadpoliGrotto(string neighbour)
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

// Zora's Domain

    public bool UpperZorasRiver(string neighbour)
    {
        if (neighbour == "LanayruField")
        {
            return true;
        }

        else if (neighbour == "FishingHole")
        {
            return true;
        }

        else if (neighbour == "ZorasDomain")
        {
            return true;
        }

        else if (neighbour == "UpperZorasRiverIzasHouse")
        {
            return Has("Sword")
                || (CanDefeatShadowBeast() && SettingsStatus["TransformAnywhere"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool UpperZorasRiverIzasHouse(string neighbour)
    {
        if (neighbour == "UpperZorasRiver")
        {
            return true;
        }

        else if (neighbour == "LakeHylia")
        {
            return Has("Bow");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool FishingHole(string neighbour)
    {
        if (neighbour == "UpperZorasRiver")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ZorasDomain(string neighbour)
    {
        if (neighbour == "ZorasDomainWestLedge")
        {
            return Has("Clawshot") || Has("ShadowCrystal") || CanSmash();
        }

        else if (neighbour == "UpperZorasRiver")
        {
            return true;
        }

        else if (neighbour == "ZorasThroneRoom")
        {
            return true;
        }

        else if (neighbour == "SnowpeakClimbLower")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ZorasDomainWestLedge(string neighbour)
    {
        if (neighbour == "ZorasDomain")
        {
            return true;
        }

        else if (neighbour == "LanayruField")
        {
            return CanSmash();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ZorasThroneRoom(string neighbour)
    {
        if (neighbour == "ZorasDomain")
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

    public bool GerudoDesert(string neighbour)
    {
        if (neighbour == "GerudoDesertCaveofOrdealsPlateau")
        {
            return CanDefeatShadowBeast() && Has("Clawshot");
        }

        else if (neighbour == "GerudoDesertBasin")
        {
            return true;
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

    public bool GerudoDesertCaveofOrdealsPlateau(string neighbour)
    {
        if (neighbour == "GerudoDesert")
        {
            return true;
        }

        else if (neighbour == "CaveofOrdealsFloors0111")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesertBasin(string neighbour)
    {
        if (neighbour == "GerudoDesert")
        {
            return CanDefeatBulblin();
        }

        else if (neighbour == "GerudoDesertNorthEastLedge")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "GerudoDesertOutsideBulblinCamp")
        {
            return CanDefeatBulblin();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesertNorthEastLedge(string neighbour)
    {
        if (neighbour == "GerudoDesertBasin")
        {
            return true;
        }

        else if (neighbour == "GerudoDesertRockGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesertOutsideBulblinCamp(string neighbour)
    {
        if (neighbour == "GerudoDesertBasin")
        {
            return CanDefeatBulblin();
        }

        else if (neighbour == "BulblinCamp")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GerudoDesertSkulltulaGrotto(string neighbour)
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

    public bool GerudoDesertRockGrotto(string neighbour)
    {
        if (neighbour == "GerudoDesertNorthEastLedge")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool BulblinCamp(string neighbour)
    {
        if (neighbour == "GerudoDesertOutsideBulblinCamp")
        {
            return true;
        }

        else if (neighbour == "OutsideArbitersGrounds")
        {
            return (
                    (
                        Has("DesertKeys") 
                        || SettingsStatus["SmallKeysKeysy"] 
                        || (
                            SettingsStatus["GlitchedLogic"] 
                            && CanDoMapGlitch() 
                            && Has("Sword")
                        )
                    ) 
                    && CanDefeatKingBulblinDesert()
                )
                || SettingsStatus["EarlyArbiters"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool OutsideArbitersGrounds(string neighbour)
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

    public bool MirrorChamberLower(string neighbour)
    {
        if (neighbour == "ArbitersGroundsBossRoom")
        {
            return true;
        }

        else if (neighbour == "MirrorChamberUpper")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MirrorChamberUpper(string neighbour)
    {
        if (neighbour == "MirrorChamberLower")
        {
            return CanDefeatShadowBeast();
        }

        else if (neighbour == "MirrorChamberPortal")
        {
            return ((SettingsStatus["PoTVanilla"] && Has("Boss7"))
                || (SettingsStatus["PoTFusedShadows"] && Has("FusedShadow", 3))
                || (SettingsStatus["PoTMirrorShards"] && Has("MirrorShard", 4))
                || SettingsStatus["PoTOpen"])
                && CanDefeatShadowBeast();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool MirrorChamberPortal(string neighbour)
    {
        if (neighbour == "MirrorChamberUpper")
        {
            return CanDefeatShadowBeast();
        }

        else if (neighbour == "PalaceofTwilightEntrance")
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

    public bool CaveofOrdealsFloors0111(string neighbour)
    {
        if (neighbour == "GerudoDesertCaveofOrdealsPlateau")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CaveofOrdealsFloors1221")
        {
            return (Has("Spinner") || (SettingsStatus["GlitchedLogic"] && CanDoLJA()))
                && CanDefeatKeese() 
                && CanDefeatTorchSlug();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors1221(string neighbour)
    {
        if (neighbour == "CaveofOrdealsFloors2231")
        {
            return CanDefeatPoe() && Has("B&C");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors2231(string neighbour)
    {
        if (neighbour == "CaveofOrdealsFloors3241")
        {
            return Has("DominionRod", 2) && CanDefeatGhoulRat();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CaveofOrdealsFloors3241(string neighbour)
    {
        if (neighbour == "CaveofOrdealsFloors4250")
        {
            return (Has("Clawshot", 2) || (SettingsStatus["GlitchedLogic"] && CanDoLJA()))
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

    public bool CaveofOrdealsFloors4250(string neighbour)
    {
        if (neighbour == "LakeHyliaLanayruSpring")
        {
            return CanDefeatPoe()
                && CanDefeatFreezard()
                && CanDefeatDarknut()
                && CanDefeatAeralfos();
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

    public bool SnowpeakClimbLower(string neighbour)
    {
        if (neighbour == "SnowpeakClimbUpper")
        {
            return (
                (
                    Has("ReekfishScent")
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                    || SettingsStatus["EarlySnowpeak"]
                )
                && Has("ShadowCrystal")
            )
            || (
                SettingsStatus["GlitchedLogic"]
                && (
                    Has("ReekfishScent")
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                    || SettingsStatus["EarlySnowpeak"]
                )
                || Has("ShadowCrystal")
            );
        }

        else if (neighbour == "ZorasDomain")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakClimbUpper(string neighbour)
    {
        if (neighbour == "SnowpeakClimbLower")
        {
            return (
                (
                    Has("ReekfishScent")
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                    || SettingsStatus["EarlySnowpeak"]
                )
                && Has("ShadowCrystal")
            )
            || (
                SettingsStatus["GlitchedLogic"]
                && (
                    Has("ReekfishScent")
                    || (SettingsStatus["IgnoreScentLogic"] && Has("FishingRod", 2))
                    || SettingsStatus["EarlySnowpeak"]
                )
                || Has("ShadowCrystal")
            );
        }

        else if (neighbour == "SnowpeakSummitUpper")
        {
            return Has("ShadowCrystal");
        }

        else if (neighbour == "SnowpeakFreezardGrotto")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakFreezardGrotto(string neighbour)
    {
        if (neighbour == "SnowpeakClimbUpper")
        {
            return true;
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakSummitUpper(string neighbour)
    {
        if (neighbour == "SnowpeakSummitLower")
        {
            return CanDefeatShadowBeast() 
                && (
                    !SettingsStatus["BonksDoDamage"]
                    || (
                        SettingsStatus["BonksDoDamage"]
                        && (!SettingsStatus["DamageOHKO"] || CanUseBottledFairy())
                    )
                );
        }

        else if (neighbour == "SnowpeakClimbUpper")
        {
            return Has("ShadowCrystal");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakSummitLower(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsEntrance")
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

        Forest Temple

------------------------------ */

    public bool ForestTempleBossRoom(string neighbour)
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

    public bool ForestTempleEastWing(string neighbour)
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

    public bool ForestTempleEntrance(string neighbour)
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

    public bool ForestTempleLobby(string neighbour)
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
                && (
                    (
                        (Has("FTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]) 
                        && CanDefeatBokoblin()
                    ) 
                    || Has("Clawshot")
                    || (SettingsStatus["GlitchedLogic"] && CanDoLJA())
                );
        }

        else if (neighbour == "Ook")
        {
            return Has("Lantern")
                && CanDefeatWalltula()
                && CanDefeatBokoblin()
                && CanBreakMonkeyCage()
                && (Has("FTSmallKey", 4) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ForestTempleNorthWing(string neighbour)
    {
        if (neighbour == "ForestTempleEastWing")
        {
            return true;
        }

        else if (neighbour == "ForestTempleBossRoom")
        {
            return (Has("FTBigKey") || SettingsStatus["BigKeysKeysy"])
                && (
                    (
                        Has("Boomerang")
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

    public bool ForestTempleWestWing(string neighbour)
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

    public bool Ook(string neighbour)
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

    public bool GoronMinesBossRoom(string neighbour)
    {
        if (neighbour == "LowerKakarikoVillage")
        {
            return CanDefeatFyrus();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesCrystalSwitchRoom(string neighbour)
    {
        if (neighbour == "GoronMinesMagnetRoom")
        {
            return true;
        }

        else if (neighbour == "GoronMinesNorthWing")
        {
            return (
                (
                    Has("IronBoots") && Has("Sword")
                ) 
                || Has("Bow")
                || (
                    SettingsStatus["GlitchedLogic"] 
                    && (
                        CanDoLJA() 
                        || (Has("Sword") && HasBombs())
                    ) 
                    && (
                        Has("Clawshot") 
                        || Has("B&C") 
                        || HasBombs()
                    )
                    
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

    public bool GoronMinesEntrance(string neighbour)
    {
        if (neighbour == "DeathMountainSumoHall")
        {
            return Has("IronBoots")
                || SettingsStatus["MinesNoWrestling"]
                || SettingsStatus["MinesOpen"]
                || (SettingsStatus["GlitchedLogic"] && Has("Spinner"));
        }

        else if (neighbour == "GoronMinesMagnetRoom")
        {
            return (
                Has("IronBoots") 
                || (SettingsStatus["GlitchedLogic"] && Has("ShadowCrystal"))
            )
            && (
                CanBreakWoodenDoor() 
                || (SettingsStatus["GlitchedLogic"] && CanDoBSMoonBoots())
            );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesLowerWestWing(string neighbour)
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

    public bool GoronMinesMagnetRoom(string neighbour)
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

    public bool GoronMinesNorthWing(string neighbour)
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
            return (
                    Has("GMBigKey", 3) || SettingsStatus["BigKeysKeysy"]
                )
                && Has("Bow")
                && (
                    (
                        Has("IronBoots") && CanDefeatBulblin()
                    ) 
                    || (
                        SettingsStatus["GlitchedLogic"] 
                        && (Has("Clawshot") || CanDoLJA())
                    )
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool GoronMinesUpperEastWing(string neighbour)
    {
        if (neighbour == "GoronMinesMagnetRoom")
        {
            return Has("IronBoots") 
                && CanDefeatDangoro() 
                && (Has("Bow") || (SettingsStatus["GlitchedLogic"] && CanDefeatBeamos()));
        }

        else if (neighbour == "GoronMinesNorthWing")
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

        Lakebed Temple

------------------------------ */

    public bool LakebedTempleBossRoom(string neighbour)
    {
        if (neighbour == "LakeHyliaLanayruSpring")
        {
            return CanDefeatMorpheel();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleCentralRoom(string neighbour)
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
            return (
                    (Has("LTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                    && CanLaunchBombs()
                    && Has("Clawshot")
                    && (Has("LTBigKey") || SettingsStatus["BigKeysKeysy"])
                )
                || (
                    SettingsStatus["GlitchedLogic"]
                    && (
                        (
                            Has("Clawshot") 
                            && (
                                Has("Sword") 
                                || Has("LTBigKey") 
                                || SettingsStatus["BigKeysKeysy"]
                            )
                        ) 
                        || CanDoLJA()
                    )
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool LakebedTempleEastWingFirstFloor(string neighbour)
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

    public bool LakebedTempleEastWingSecondFloor(string neighbour)
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

    public bool LakebedTempleEntrance(string neighbour)
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

    public bool LakebedTempleWestWing(string neighbour)
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

    public bool ArbitersGroundsAfterPoeGate(string neighbour)
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

    public bool ArbitersGroundsBossRoom(string neighbour)
    {
        if (neighbour == "MirrorChamberLower")
        {
            return CanDefeatStallord();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool ArbitersGroundsEastWing(string neighbour)
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

    public bool ArbitersGroundsEntrance(string neighbour)
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

    public bool ArbitersGroundsLobby(string neighbour)
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

    public bool ArbitersGroundsWestWing(string neighbour)
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

    public bool SnowpeakRuinsBossRoom(string neighbour)
    {
        if (neighbour == "SnowpeakSummitLower")
        {
            return CanDefeatBlizzeta();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsCagedFreezardRoom(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsSecondFloorMiniFreezardRoom")
        {
            return Has("B&C") 
                && (
                    (Has("SRSmallKey", 3) && !SettingsStatus["GlitchedLogic"])
                    || (Has("SRSmallKey", 4) && SettingsStatus["GlitchedLogic"])
                    || SettingsStatus["SmallKeysKeysy"])
                    || (SettingsStatus["GlitchedLogic"] && Has("Clawshot")
                );
        }

        else if (neighbour == "SnowpeakRuinsWoodenBeamRoom")
        {
            return Has("B&C");
        }

        else if (neighbour == "SnowpeakRuinsWestCourtyard")
        {
            return Has("SRSmallKey", 2) 
                || SettingsStatus["SmallKeysKeysy"] 
                || SettingsStatus["GlitchedLogic"];
        }

        else if (neighbour == "SnowpeakRuinsChapel")
        {
            return SettingsStatus["GlitchedLogic"];
        }

        else if (neighbour == "SnowpeakRuinsCagedFreezardRoomLower")
        {
            return !SettingsStatus["GlitchedLogic"] || CanSmash();
        }

        else if (neighbour == "SnowpeakRuinsBossRoom")
        {
            return SettingsStatus["GlitchedLogic"]
                && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsCagedFreezardRoomLower(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsEntrance")
        {
            return SettingsStatus["GlitchedLogic"] && CanDoLJA();
        }

        else if (neighbour == "SnowpeakRuinsCagedFreezardRoom")
        {
            return !SettingsStatus["GlitchedLogic"] || Has("Clawshot");
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsChapel(string neighbour)
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

    public bool SnowpeakRuinsDarkhammerRoom(string neighbour)
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

    public bool SnowpeakRuinsEastCourtyard(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return Has("ShadowCrystal") || Has("B&C");
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
                        && !SettingsStatus["GlitchedLogic"]
                ) ||
                (
                    SettingsStatus["GlitchedLogic"]
                    && (Has("B&C") & Has("Clawshot"))
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsEntrance(string neighbour)
    {
        if (neighbour == "SnowpeakSummitLower")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsCagedFreezardRoomLower")
        {
            return SettingsStatus["GlitchedLogic"] && CanDoLJA();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsNortheastChilfosRoomFirstFloor(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return !SettingsStatus["GlitchedLogic"]
                || Has("SRSmallKey", 4) 
                || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return CanDefeatChilfos();
        }

        else if (neighbour == "SnowpeakRuinsNortheastChilfosRoomSecondFloor")
        {
            return SettingsStatus["GlitchedLogic"] && CanDoLJA();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsNortheastChilfosRoomSecondFloor(string neighbour)
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

    public bool SnowpeakRuinsSecondFloorMiniFreezardRoom(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsEntrance")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return !SettingsStatus["GlitchedLogic"] && (Has("ShadowCrystal") || Has("B&C"));
        }

        else if (neighbour == "SnowpeakRuinsNortheastChilfosRoomSecondFloor")
        {
            return (Has("B&C") && Has("Clawshot") && CanDefeatChilfos())
                || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
        }

        else if (neighbour == "SnowpeakRuinsCagedFreezardRoom")
        {
            return Has("SRSmallKey", 4) 
                || SettingsStatus["SmallKeysKeysy"]
                || (SettingsStatus["GlitchedLogic"] && Has("B&C") && Has("Clawshot"));
        }

        else if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return SettingsStatus["GlitchedLogic"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsWestCannonRoom(string neighbour)
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

    public bool SnowpeakRuinsWestCourtyard(string neighbour)
    {
        if (neighbour == "SnowpeakRuinsYetoandYeta")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsEastCourtyard")
        {
            return Has("B&C")
                || (
                    SettingsStatus["GlitchedLogic"]
                    && (
                        Has("SRSmallKey", 4)
                        || Has("Cheese")
                        || SettingsStatus["SmallKeysKeysy"]
                    )
                );
        }

        else if (neighbour == "SnowpeakRuinsWestCannonRoom")
        {
            return true;
        }

        else if (neighbour == "SnowpeakRuinsChapel")
        {
            return (
                    (
                        (Has("SRSmallKey", 4) && Has("Cheese")) 
                        || SettingsStatus["SmallKeysKeysy"]
                    ) 
                    && Has("B&C") 
                    && HasBombs()
                    && !SettingsStatus["GlitchedLogic"]
                )
                || (
                    SettingsStatus["GlitchedLogic"]
                    && (
                        Has("SRSmallKey", 4) 
                        || Has("Cheese") 
                        || SettingsStatus["SmallKeysKeysy"]
                    )
                );
        }

        else if (neighbour == "SnowpeakRuinsDarkhammerRoom")
        {
            return Has("B&C")
                || (
                    (
                        (Has("SRSmallKey", 2) && !SettingsStatus["GlitchedLogic"])
                        || (Has("SRSmallKey", 4) && SettingsStatus["GlitchedLogic"])
                        || Has("Cheese")
                        || SettingsStatus["SmallKeysKeysy"]
                    ) 
                    && HasBombs()
                )
                || (
                    SettingsStatus["GlitchedLogic"]
                    && (
                        Has("ShadowCrystal") 
                        && !SettingsStatus["DamageOHKO"]
                    )
                );
        }

        else if (neighbour == "SnowpeakRuinsBossRoom")
        {
            return (
                    (
                        !SettingsStatus["GlitchedLogic"] 
                        && (
                            (
                                (Has("SRSmallKey", 4) && Has("Cheese")) 
                                || SettingsStatus["SmallKeysKeysy"]
                            ) 
                            && Has("B&C") 
                            && HasBombs()
                        )
                    ) ||
                    (
                        SettingsStatus["GlitchedLogic"]
                        && (
                            Has("SRSmallKey", 4)
                            || Has("Cheese")
                            || SettingsStatus["SmallKeysKeysy"]
                        )
                    )
                )
                && (Has("SRBigKey") || SettingsStatus["BigKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool SnowpeakRuinsWoodenBeamRoom(string neighbour)
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

    public bool SnowpeakRuinsYetoandYeta(string neighbour)
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

    public bool TempleofTimeArmosAntechamber(string neighbour)
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

    public bool TempleofTimeBossRoom(string neighbour)
    {
        if (neighbour == "SacredGrovePast")
        {
            return CanDefeatArmogohma();
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeCentralMechanicalPlatform(string neighbour)
    {
        if (neighbour == "TempleofTimeConnectingCorridors")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeArmosAntechamber")
        {
            return Has("Spinner")
                || (SettingsStatus["GlitchedLogic"] && CanDoLJA());
        }

        else if (neighbour == "TempleofTimeMovingWallHallways")
        {
            return (Has("Spinner") || (SettingsStatus["GlitchedLogic"] && CanDoLJA()))
                && (Has("ToTSmallKey", 2) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeConnectingCorridors(string neighbour)
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

    public bool TempleofTimeCrumblingCorridor(string neighbour)
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

    public bool TempleofTimeDarknutArena(string neighbour)
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

    public bool TempleofTimeEntrance(string neighbour)
    {
        if (neighbour == "SacredGrovePast")
        {
            return true;
        }

        else if (neighbour == "TempleofTimeConnectingCorridors")
        {
            return Has("ToTSmallKey", 1) || SettingsStatus["SmallKeysKeysy"];
        }

        else if (neighbour == "TempleofTimeCrumblingCorridor")
        {
            return (
                    Has("DominionRod") 
                    && (
                        (
                            Has("Bow") 
                            && Has("Spinner") 
                            && CanDefeatLizalfos() 
                            && CanDefeatDinalfos() 
                            && CanDefeatDarknut() 
                            && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"])
                        ) 
                        || SettingsStatus["GlitchedLogic"]
                    )
                ) 
                || SettingsStatus["OpenDoorOfTime"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool TempleofTimeFloorSwitchPuzzleRoom(string neighbour)
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

    public bool TempleofTimeMovingWallHallways(string neighbour)
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

    public bool TempleofTimeScalesofTime(string neighbour)
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
    
    public bool TempleofTimeUpperSpikeTrapCorridor(string neighbour)
    {
        if (neighbour == "TempleofTimeDarknutArena")
        {
            return CanDefeatLizalfos()
                && CanDefeatBabyGohma()
                && CanDefeatYoungGohma()
                && CanDefeatArmos()
                && (Has("ToTSmallKey", 3) || SettingsStatus["SmallKeysKeysy"]);
        }

        else if (neighbour == "TempleofTimeScalesofTime")
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

        City in The Sky

------------------------------ */

    public bool CityinTheSkyBossRoom(string neighbour)
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

    public bool CityinTheSkyCentralTowerSecondFloor(string neighbour)
    {
        if (neighbour == "CityinTheSkyWestWing")
        {
            return Has("Clawshot", 2);
        }

        else if (neighbour == "CityinTheSkyLobby")
        {
            return Has("Clawshot")
                && Has("IronBoots")
                && !SettingsStatus["DamageOHKO"]
                && (Has("ShadowCrystal") || (SettingsStatus["GlitchedLogic"] && CanDoLJA()));
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyEastWing(string neighbour)
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

    public bool CityinTheSkyEntrance(string neighbour)
    {
        if (neighbour == "LakeHylia")
        {
            return Has("Clawshot");
        }

        else if (neighbour == "CityinTheSkyLobby")
        {
            return Has("Clawshot")
                || (
                    SettingsStatus["GlitchedLogic"]
                    && Has("Bow")
                    && CanDoLJA()
                );
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool CityinTheSkyLobby(string neighbour)
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
                    || SettingsStatus["GlitchedLogic"] 
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

    public bool CityinTheSkyNorthWing(string neighbour)
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

    public bool CityinTheSkyWestWing(string neighbour)
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

    public bool PalaceofTwilightBossRoom(string neighbour)
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

    public bool PalaceofTwilightEastWing(string neighbour)
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

    public bool PalaceofTwilightWestWing(string neighbour)
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

    public bool PalaceofTwilightEntrance(string neighbour)
    {
        if (neighbour == "MirrorChamberUpper")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightWestWing")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightEastWing")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightCentralFirstRoom")
        {
            return Has("Sword", 4);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightCentralFirstRoom(string neighbour)
    {
        if (neighbour == "PalaceofTwilightEntrance")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightOutsideRoom")
        {
            return Has("Sword", 4)
                && (Has("PoTSmallKey", 5) || SettingsStatus["SmallKeysKeysy"]);
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightOutsideRoom(string neighbour)
    {
        if (neighbour == "PalaceofTwilightCentralFirstRoom")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightNorthTower")
        {
            return Has("PoTSmallKey", 6) || SettingsStatus["SmallKeysKeysy"];
        }

        else
        {
            Debug.Log("Could not find neighbor: " + neighbour);
            return false;
        }
    }

    public bool PalaceofTwilightNorthTower(string neighbour)
    {
        if (neighbour == "PalaceofTwilightOutsideRoom")
        {
            return true;
        }

        else if (neighbour == "PalaceofTwilightBossRoom")
        {
            return (Has("PoTSmallKey", 7) || SettingsStatus["SmallKeysKeysy"])
                && CanDefeatZantHead()
                && Has("Sword", 4)
                && (Has("PoTBigKey") || SettingsStatus["BigKeysKeysy"])
                && CanDefeatShadowBeast()
                && Has("Clawshot");
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

    public bool GanondorfCastle(string neighbour)
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

    public bool HyruleCastleEntrance(string neighbour)
    {
        if (neighbour == "CastleTownNorthBehindFirstDoor")
        {
            return CanCompleteMDH();
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

    public bool HyruleCastleGraveyard(string neighbour)
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

    public bool HyruleCastleInsideEastWing(string neighbour)
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

    public bool HyruleCastleInsideWestWing(string neighbour)
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

    public bool HyruleCastleMainHall(string neighbour)
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

    public bool HyruleCastleOutsideEastWing(string neighbour)
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

    public bool HyruleCastleOutsideWestWing(string neighbour)
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

    public bool HyruleCastleThirdFloorBalcony(string neighbour)
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

    public bool HyruleCastleTowerClimb(string neighbour)
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

    public bool HyruleCastleTreasureRoom(string neighbour)
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
