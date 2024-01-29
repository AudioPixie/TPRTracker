using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System;
using System.Reflection;

/*---------------------------------
  
        Spoiler log fields

---------------------------------*/

[System.Serializable]
public class SpoilerLog
{
    public string playthroughName;
    public bool isRaceSeed;
    public string seedString;
    public string settingsString;
    public Settings settings;
    public string[] requiredDungeons;
    public ItemPlacements itemPlacements;
    public string version;
}

[System.Serializable]
public class Settings
{
    public string logicRules;
    public string castleRequirements;
    public string palaceRequirements;
    public string faronWoodsLogic;
    public bool shuffleGoldenBugs;
    public bool shuffleSkyCharacters;
    public bool shuffleNpcItems;
    public string shufflePoes;
    public bool shuffleShopItems;
    public bool shuffleHiddenSkills;
    public string itemScarcity;
    public string damageMagnification;
    public string bonksDoDamage;
    public string shuffleRewards;
    public string smallKeySettings;
    public string bigKeySettings;
    public string mapAndCompassSettings;
    public bool skipPrologue;
    public bool faronTwilightCleared;
    public bool eldinTwilightCleared;
    public bool lanayruTwilightCleared;
    public bool skipMdh;
    public bool skipMinorCutscenes;
    public bool fastIronBoots;
    public bool quickTransform;
    public bool transformAnywhere;
    public bool increaseWallet;
    public bool modifyShopModels;
    public string trapFrequency;
    public bool barrenDungeons;
    public string goronMinesEntrance;
    public bool skipLakebedEntrance;
    public bool skipArbitersEntrance;
    public bool skipSnowpeakEntrance;
    public string totEntrance;
    public bool skipCityEntrance;
    public bool instantText;
    public bool openMap;
    public bool increaseSpinnerSpeed;
    public bool openDot;

    public string[] startingItems;
    public string[] excludedChecks;
}

[System.Serializable]
public class ItemPlacements
{
    public string AgithaFemaleAntReward;
    public string AgithaFemaleBeetleReward;
    public string AgithaFemaleButterflyReward;
    public string AgithaFemaleDayflyReward;
    public string AgithaFemaleDragonflyReward;
    public string AgithaFemaleGrasshopperReward;
    public string AgithaFemaleLadybugReward;
    public string AgithaFemaleMantisReward;
    public string AgithaFemalePhasmidReward;
    public string AgithaFemalePillBugReward;
    public string AgithaFemaleSnailReward;
    public string AgithaFemaleStagBeetleReward;
    public string AgithaMaleAntReward;
    public string AgithaMaleBeetleReward;
    public string AgithaMaleButterflyReward;
    public string AgithaMaleDayflyReward;
    public string AgithaMaleDragonflyReward;
    public string AgithaMaleGrasshopperReward;
    public string AgithaMaleLadybugReward;
    public string AgithaMaleMantisReward;
    public string AgithaMalePhasmidReward;
    public string AgithaMalePillBugReward;
    public string AgithaMaleSnailReward;
    public string AgithaMaleStagBeetleReward;
    public string ArbitersGroundsBigKeyChest;
    public string ArbitersGroundsDeathSwordChest;
    public string ArbitersGroundsEastLowerTurnableRedeadChest;
    public string ArbitersGroundsEastTurningRoomPoe;
    public string ArbitersGroundsEastUpperTurnableChest;
    public string ArbitersGroundsEastUpperTurnableRedeadChest;
    public string ArbitersGroundsEntranceChest;
    public string ArbitersGroundsGhoulRatRoomChest;
    public string ArbitersGroundsHiddenWallPoe;
    public string ArbitersGroundsNorthTurningRoomChest;
    public string ArbitersGroundsSpinnerRoomFirstSmallChest;
    public string ArbitersGroundsSpinnerRoomLowerCentralSmallChest;
    public string ArbitersGroundsSpinnerRoomLowerNorthChest;
    public string ArbitersGroundsSpinnerRoomSecondSmallChest;
    public string ArbitersGroundsSpinnerRoomStalfosAlcoveChest;
    public string ArbitersGroundsStallordHeartContainer;
    public string ArbitersGroundsTorchRoomEastChest;
    public string ArbitersGroundsTorchRoomPoe;
    public string ArbitersGroundsTorchRoomWestChest;
    public string ArbitersGroundsWestChandelierChest;
    public string ArbitersGroundsWestPoe;
    public string ArbitersGroundsWestSmallChestBehindBlock;
    public string ArbitersGroundsWestStalfosNortheastChest;
    public string ArbitersGroundsWestStalfosWestChest;
    public string AsheiSketch;
    public string AuruGiftToFyer;
    public string BarnesBombBag;
    public string BridgeofEldinFemalePhasmid;
    public string BridgeofEldinMalePhasmid;
    public string BridgeofEldinOwlStatueChest;
    public string BridgeofEldinOwlStatueSkyCharacter;
    public string BulblinCampFirstChestUnderTowerAtEntrance;
    public string BulblinCampPoe;
    public string BulblinCampRoastedBoar;
    public string BulblinCampSmallChestinBackofCamp;
    public string BulblinGuardKey;
    public string CastleTownMaloMartMagicArmor;
    public string CatsHideandSeekMinigame;
    public string CaveofOrdealsFloor17Poe;
    public string CaveofOrdealsFloor33Poe;
    public string CaveofOrdealsFloor44Poe;
    public string CaveofOrdealsGreatFairyReward;
    public string CharloDonationBlessing;
    public string CityinTheSkyAeralfosChest;
    public string CityinTheSkyArgorokHeartContainer;
    public string CityinTheSkyBabaTowerAlcoveChest;
    public string CityinTheSkyBabaTowerNarrowLedgeChest;
    public string CityinTheSkyBabaTowerTopSmallChest;
    public string CityinTheSkyBigKeyChest;
    public string CityinTheSkyCentralOutsideLedgeChest;
    public string CityinTheSkyCentralOutsidePoeIslandChest;
    public string CityinTheSkyChestBehindNorthFan;
    public string CityinTheSkyChestBelowBigKeyChest;
    public string CityinTheSkyDungeonReward;
    public string CityinTheSkyEastFirstWingChestAfterFans;
    public string CityinTheSkyEastTileWormSmallChest;
    public string CityinTheSkyEastWingAfterDinalfosAlcoveChest;
    public string CityinTheSkyEastWingAfterDinalfosLedgeChest;
    public string CityinTheSkyEastWingLowerLevelChest;
    public string CityinTheSkyGardenIslandPoe;
    public string CityinTheSkyPoeAboveCentralFan;
    public string CityinTheSkyUnderwaterEastChest;
    public string CityinTheSkyUnderwaterWestChest;
    public string CityinTheSkyWestGardenCornerChest;
    public string CityinTheSkyWestGardenLedgeChest;
    public string CityinTheSkyWestGardenLoneIslandChest;
    public string CityinTheSkyWestGardenLowerChest;
    public string CityinTheSkyWestWingBabaBalconyChest;
    public string CityinTheSkyWestWingFirstChest;
    public string CityinTheSkyWestWingNarrowLedgeChest;
    public string CityinTheSkyWestWingTileWormChest;
    public string CoroBottle;
    public string DeathMountainAlcoveChest;
    public string DeathMountainTrailPoe;
    public string DoctorsOfficeBalconyChest;
    public string EastCastleTownBridgePoe;
    public string EldinFieldBombRockChest;
    public string EldinFieldBomskitGrottoLanternChest;
    public string EldinFieldBomskitGrottoLeftChest;
    public string EldinFieldFemaleGrasshopper;
    public string EldinFieldMaleGrasshopper;
    public string EldinFieldStalfosGrottoLeftSmallChest;
    public string EldinFieldStalfosGrottoRightSmallChest;
    public string EldinFieldStalfosGrottoStalfosChest;
    public string EldinFieldWaterBombFishGrottoChest;
    public string EldinLanternCaveFirstChest;
    public string EldinLanternCaveLanternChest;
    public string EldinLanternCavePoe;
    public string EldinLanternCaveSecondChest;
    public string EldinSpringUnderwaterChest;
    public string EldinStockcaveLanternChest;
    public string EldinStockcaveLowestChest;
    public string EldinStockcaveUpperChest;
    public string FaronFieldBridgeChest;
    public string FaronFieldCornerGrottoLeftChest;
    public string FaronFieldCornerGrottoRearChest;
    public string FaronFieldCornerGrottoRightChest;
    public string FaronFieldFemaleBeetle;
    public string FaronFieldMaleBeetle;
    public string FaronFieldPoe;
    public string FaronFieldTreeHeartPiece;
    public string FaronMistCaveLanternChest;
    public string FaronMistCaveOpenChest;
    public string FaronMistNorthChest;
    public string FaronMistPoe;
    public string FaronMistSouthChest;
    public string FaronMistStumpChest;
    public string FaronWoodsGoldenWolf;
    public string FaronWoodsOwlStatueChest;
    public string FaronWoodsOwlStatueSkyCharacter;
    public string FishingHoleBottle;
    public string FishingHoleHeartPiece;
    public string FlightByFowlFifthPlatformChest;
    public string FlightByFowlFourthPlatformChest;
    public string FlightByFowlLedgePoe;
    public string FlightByFowlSecondPlatformChest;
    public string FlightByFowlThirdPlatformChest;
    public string FlightByFowlTopPlatformReward;
    public string ForestTempleBigBabaKey;
    public string ForestTempleBigKeyChest;
    public string ForestTempleCentralChestBehindStairs;
    public string ForestTempleCentralChestHangingFromWeb;
    public string ForestTempleCentralNorthChest;
    public string ForestTempleDiababaHeartContainer;
    public string ForestTempleDungeonReward;
    public string ForestTempleEastTileWormChest;
    public string ForestTempleEastWaterCaveChest;
    public string ForestTempleEntranceVinesChest;
    public string ForestTempleGaleBoomerang;
    public string ForestTempleNorthDekuLikeChest;
    public string ForestTempleSecondMonkeyUnderBridgeChest;
    public string ForestTempleTotemPoleChest;
    public string ForestTempleWestDekuLikeChest;
    public string ForestTempleWestTileWormChestBehindStairs;
    public string ForestTempleWestTileWormRoomVinesChest;
    public string ForestTempleWindlessBridgeChest;
    public string GerudoDesertCampfireEastChest;
    public string GerudoDesertCampfireNorthChest;
    public string GerudoDesertCampfireWestChest;
    public string GerudoDesertEastCanyonChest;
    public string GerudoDesertEastPoe;
    public string GerudoDesertFemaleDayfly;
    public string GerudoDesertGoldenWolf;
    public string GerudoDesertLoneSmallChest;
    public string GerudoDesertMaleDayfly;
    public string GerudoDesertNorthPeahatPoe;
    public string GerudoDesertNorthSmallChestBeforeBulblinCamp;
    public string GerudoDesertNortheastChestBehindGates;
    public string GerudoDesertNorthwestChestBehindGates;
    public string GerudoDesertOwlStatueChest;
    public string GerudoDesertOwlStatueSkyCharacter;
    public string GerudoDesertPeahatLedgeChest;
    public string GerudoDesertPoeAboveCaveofOrdeals;
    public string GerudoDesertRockGrottoFirstPoe;
    public string GerudoDesertRockGrottoLanternChest;
    public string GerudoDesertRockGrottoSecondPoe;
    public string GerudoDesertSkulltulaGrottoChest;
    public string GerudoDesertSouthChestBehindWoodenGates;
    public string GerudoDesertWestCanyonChest;
    public string GiftFromRalis;
    public string GoronMinesAfterCrystalSwitchRoomMagnetWallChest;
    public string GoronMinesBeamosRoomChest;
    public string GoronMinesChestBeforeDangoro;
    public string GoronMinesCrystalSwitchRoomSmallChest;
    public string GoronMinesCrystalSwitchRoomUnderwaterChest;
    public string GoronMinesDangoroChest;
    public string GoronMinesDungeonReward;
    public string GoronMinesEntranceChest;
    public string GoronMinesFyrusHeartContainer;
    public string GoronMinesGorAmatoChest;
    public string GoronMinesGorAmatoKeyShard;
    public string GoronMinesGorAmatoSmallChest;
    public string GoronMinesGorEbizoChest;
    public string GoronMinesGorEbizoKeyShard;
    public string GoronMinesGorLiggsChest;
    public string GoronMinesGorLiggsKeyShard;
    public string GoronMinesMagnetMazeChest;
    public string GoronMinesMainMagnetRoomBottomChest;
    public string GoronMinesMainMagnetRoomTopChest;
    public string GoronMinesOutsideBeamosChest;
    public string GoronMinesOutsideClawshotChest;
    public string GoronMinesOutsideUnderwaterChest;
    public string GoronSpringwaterRush;
    public string HerdingGoatsReward;
    public string HiddenVillagePoe;
    public string HyruleCastleBigKeyChest;
    public string HyruleCastleEastWingBalconyChest;
    public string HyruleCastleEastWingBoomerangPuzzleChest;
    public string HyruleCastleGraveyardGraveSwitchRoomBackLeftChest;
    public string HyruleCastleGraveyardGraveSwitchRoomFrontLeftChest;
    public string HyruleCastleGraveyardGraveSwitchRoomRightChest;
    public string HyruleCastleGraveyardOwlStatueChest;
    public string HyruleCastleKingBulblinKey;
    public string HyruleCastleLanternStaircaseChest;
    public string HyruleCastleMainHallNortheastChest;
    public string HyruleCastleMainHallNorthwestChest;
    public string HyruleCastleMainHallSouthwestChest;
    public string HyruleCastleSoutheastBalconyTowerChest;
    public string HyruleCastleTreasureRoomEighthSmallChest;
    public string HyruleCastleTreasureRoomFifthChest;
    public string HyruleCastleTreasureRoomFifthSmallChest;
    public string HyruleCastleTreasureRoomFirstChest;
    public string HyruleCastleTreasureRoomFirstSmallChest;
    public string HyruleCastleTreasureRoomFourthChest;
    public string HyruleCastleTreasureRoomFourthSmallChest;
    public string HyruleCastleTreasureRoomSecondChest;
    public string HyruleCastleTreasureRoomSecondSmallChest;
    public string HyruleCastleTreasureRoomSeventhSmallChest;
    public string HyruleCastleTreasureRoomSixthSmallChest;
    public string HyruleCastleTreasureRoomThirdChest;
    public string HyruleCastleTreasureRoomThirdSmallChest;
    public string HyruleCastleWestCourtyardCentralSmallChest;
    public string HyruleCastleWestCourtyardNorthSmallChest;
    public string HyruleFieldAmphitheaterOwlStatueChest;
    public string HyruleFieldAmphitheaterOwlStatueSkyCharacter;
    public string HyruleFieldAmphitheaterPoe;
    public string IliaCharm;
    public string IliaMemoryReward;
    public string IsleofRichesPoe;
    public string IzaHelpingHand;
    public string IzaRagingRapidsMinigame;
    public string Jovani20PoeSoulReward;
    public string Jovani60PoeSoulReward;
    public string JovaniHousePoe;
    public string KakarikoGorgeDoubleClawshotChest;
    public string KakarikoGorgeFemalePillBug;
    public string KakarikoGorgeMalePillBug;
    public string KakarikoGorgeOwlStatueChest;
    public string KakarikoGorgeOwlStatueSkyCharacter;
    public string KakarikoGorgePoe;
    public string KakarikoGorgeSpireHeartPiece;
    public string KakarikoGraveyardGoldenWolf;
    public string KakarikoGraveyardGravePoe;
    public string KakarikoGraveyardLanternChest;
    public string KakarikoGraveyardMaleAnt;
    public string KakarikoGraveyardOpenPoe;
    public string KakarikoInnChest;
    public string KakarikoVillageBombRockSpireHeartPiece;
    public string KakarikoVillageBombShopPoe;
    public string KakarikoVillageFemaleAnt;
    public string KakarikoVillageMaloMartHawkeye;
    public string KakarikoVillageMaloMartHylianShield;
    public string KakarikoVillageWatchtowerPoe;
    public string KakarikoWatchtowerAlcoveChest;
    public string KakarikoWatchtowerChest;
    public string LakeHyliaAlcovePoe;
    public string LakeHyliaBridgeBubbleGrottoChest;
    public string LakeHyliaBridgeCliffChest;
    public string LakeHyliaBridgeCliffPoe;
    public string LakeHyliaBridgeFemaleMantis;
    public string LakeHyliaBridgeMaleMantis;
    public string LakeHyliaBridgeOwlStatueChest;
    public string LakeHyliaBridgeOwlStatueSkyCharacter;
    public string LakeHyliaBridgeVinesChest;
    public string LakeHyliaDockPoe;
    public string LakeHyliaShellBladeGrottoChest;
    public string LakeHyliaTowerPoe;
    public string LakeHyliaUnderwaterChest;
    public string LakeHyliaWaterToadpoliGrottoChest;
    public string LakeLanternCaveEighthChest;
    public string LakeLanternCaveEleventhChest;
    public string LakeLanternCaveEndLanternChest;
    public string LakeLanternCaveFifthChest;
    public string LakeLanternCaveFinalPoe;
    public string LakeLanternCaveFirstChest;
    public string LakeLanternCaveFirstPoe;
    public string LakeLanternCaveFourteenthChest;
    public string LakeLanternCaveFourthChest;
    public string LakeLanternCaveNinthChest;
    public string LakeLanternCaveSecondChest;
    public string LakeLanternCaveSecondPoe;
    public string LakeLanternCaveSeventhChest;
    public string LakeLanternCaveSixthChest;
    public string LakeLanternCaveTenthChest;
    public string LakeLanternCaveThirdChest;
    public string LakeLanternCaveThirteenthChest;
    public string LakeLanternCaveTwelfthChest;
    public string LakebedTempleBeforeDekuToadAlcoveChest;
    public string LakebedTempleBeforeDekuToadUnderwaterLeftChest;
    public string LakebedTempleBeforeDekuToadUnderwaterRightChest;
    public string LakebedTempleBigKeyChest;
    public string LakebedTempleCentralRoomChest;
    public string LakebedTempleCentralRoomSmallChest;
    public string LakebedTempleCentralRoomSpireChest;
    public string LakebedTempleChandelierChest;
    public string LakebedTempleDekuToadChest;
    public string LakebedTempleDungeonReward;
    public string LakebedTempleEastLowerWaterwheelBridgeChest;
    public string LakebedTempleEastLowerWaterwheelStalactiteChest;
    public string LakebedTempleEastSecondFloorSoutheastChest;
    public string LakebedTempleEastSecondFloorSouthwestChest;
    public string LakebedTempleEastWaterSupplyClawshotChest;
    public string LakebedTempleEastWaterSupplySmallChest;
    public string LakebedTempleLobbyLeftChest;
    public string LakebedTempleLobbyRearChest;
    public string LakebedTempleMorpheelHeartContainer;
    public string LakebedTempleStalactiteRoomChest;
    public string LakebedTempleUnderwaterMazeSmallChest;
    public string LakebedTempleWestLowerSmallChest;
    public string LakebedTempleWestSecondFloorCentralSmallChest;
    public string LakebedTempleWestSecondFloorNortheastChest;
    public string LakebedTempleWestSecondFloorSoutheastChest;
    public string LakebedTempleWestSecondFloorSouthwestUnderwaterChest;
    public string LakebedTempleWestWaterSupplyChest;
    public string LakebedTempleWestWaterSupplySmallChest;
    public string LanayruFieldBehindGateUnderwaterChest;
    public string LanayruFieldBridgePoe;
    public string LanayruFieldFemaleStagBeetle;
    public string LanayruFieldMaleStagBeetle;
    public string LanayruFieldPoeGrottoLeftPoe;
    public string LanayruFieldPoeGrottoRightPoe;
    public string LanayruFieldSkulltulaGrottoChest;
    public string LanayruFieldSpinnerTrackChest;
    public string LanayruIceBlockPuzzleCaveChest;
    public string LanayruSpringBackRoomLanternChest;
    public string LanayruSpringBackRoomLeftChest;
    public string LanayruSpringBackRoomRightChest;
    public string LanayruSpringEastDoubleClawshotChest;
    public string LanayruSpringUnderwaterLeftChest;
    public string LanayruSpringUnderwaterRightChest;
    public string LanayruSpringWestDoubleClawshotChest;
    public string LinksBasementChest;
    public string LostWoodsBoulderPoe;
    public string LostWoodsLanternChest;
    public string LostWoodsWaterfallPoe;
    public string NorthCastleTownGoldenWolf;
    public string NorthFaronWoodsDekuBabaChest;
    public string OrdonCatRescue;
    public string OrdonRanchGrottoLanternChest;
    public string OrdonShield;
    public string OrdonSpringGoldenWolf;
    public string OrdonSword;
    public string OutsideArbitersGroundsLanternChest;
    public string OutsideArbitersGroundsPoe;
    public string OutsideBulblinCampPoe;
    public string OutsideLanayruSpringLeftStatueChest;
    public string OutsideLanayruSpringRightStatueChest;
    public string OutsideSouthCastleTownDoubleClawshotChasmChest;
    public string OutsideSouthCastleTownFemaleLadybug;
    public string OutsideSouthCastleTownFountainChest;
    public string OutsideSouthCastleTownGoldenWolf;
    public string OutsideSouthCastleTownMaleLadybug;
    public string OutsideSouthCastleTownPoe;
    public string OutsideSouthCastleTownTektiteGrottoChest;
    public string OutsideSouthCastleTownTightropeChest;
    public string PalaceofTwilightBigKeyChest;
    public string PalaceofTwilightCentralFirstRoomChest;
    public string PalaceofTwilightCentralOutdoorChest;
    public string PalaceofTwilightCentralTowerChest;
    public string PalaceofTwilightCollectBothSols;
    public string PalaceofTwilightEastWingFirstRoomEastAlcove;
    public string PalaceofTwilightEastWingFirstRoomNorthSmallChest;
    public string PalaceofTwilightEastWingFirstRoomWestAlcove;
    public string PalaceofTwilightEastWingFirstRoomZantHeadChest;
    public string PalaceofTwilightEastWingSecondRoomNortheastChest;
    public string PalaceofTwilightEastWingSecondRoomNorthwestChest;
    public string PalaceofTwilightEastWingSecondRoomSoutheastChest;
    public string PalaceofTwilightEastWingSecondRoomSouthwestChest;
    public string PalaceofTwilightWestWingChestBehindWallofDarkness;
    public string PalaceofTwilightWestWingFirstRoomCentralChest;
    public string PalaceofTwilightWestWingSecondRoomCentralChest;
    public string PalaceofTwilightWestWingSecondRoomLowerSouthChest;
    public string PalaceofTwilightWestWingSecondRoomSoutheastChest;
    public string PalaceofTwilightZantHeartContainer;
    public string PlummFruitBalloonMinigame;
    public string RenadosLetter;
    public string RutelasBlessing;
    public string STARPrize1;
    public string STARPrize2;
    public string SacredGroveBabaSerpentGrottoChest;
    public string SacredGroveFemaleSnail;
    public string SacredGroveMaleSnail;
    public string SacredGroveMasterSwordPoe;
    public string SacredGrovePastOwlStatueChest;
    public string SacredGroveSpinnerChest;
    public string SacredGroveTempleofTimeOwlStatuePoe;
    public string SeraShopSlingshot;
    public string SkybookFromImpaz;
    public string SnowboardRacingPrize;
    public string SnowpeakAboveFreezardGrottoPoe;
    public string SnowpeakBlizzardPoe;
    public string SnowpeakCaveIceLanternChest;
    public string SnowpeakCaveIcePoe;
    public string SnowpeakFreezardGrottoChest;
    public string SnowpeakIcySummitPoe;
    public string SnowpeakPoeAmongTrees;
    public string SnowpeakRuinsBallandChain;
    public string SnowpeakRuinsBlizzetaHeartContainer;
    public string SnowpeakRuinsBrokenFloorChest;
    public string SnowpeakRuinsChapelChest;
    public string SnowpeakRuinsChestAfterDarkhammer;
    public string SnowpeakRuinsCourtyardCentralChest;
    public string SnowpeakRuinsDungeonReward;
    public string SnowpeakRuinsEastCourtyardBuriedChest;
    public string SnowpeakRuinsEastCourtyardChest;
    public string SnowpeakRuinsIceRoomPoe;
    public string SnowpeakRuinsLobbyArmorPoe;
    public string SnowpeakRuinsLobbyChandelierChest;
    public string SnowpeakRuinsLobbyEastArmorChest;
    public string SnowpeakRuinsLobbyPoe;
    public string SnowpeakRuinsLobbyWestArmorChest;
    public string SnowpeakRuinsMansionMap;
    public string SnowpeakRuinsNortheastChandelierChest;
    public string SnowpeakRuinsOrdonPumpkinChest;
    public string SnowpeakRuinsWestCannonRoomCentralChest;
    public string SnowpeakRuinsWestCannonRoomCornerChest;
    public string SnowpeakRuinsWestCourtyardBuriedChest;
    public string SnowpeakRuinsWoodenBeamCentralChest;
    public string SnowpeakRuinsWoodenBeamChandelierChest;
    public string SnowpeakRuinsWoodenBeamNorthwestChest;
    public string SouthFaronCaveChest;
    public string TaloSharpshooting;
    public string TelmaInvoice;
    public string TempleofTimeArmogohmaHeartContainer;
    public string TempleofTimeArmosAntechamberEastChest;
    public string TempleofTimeArmosAntechamberNorthChest;
    public string TempleofTimeArmosAntechamberStatueChest;
    public string TempleofTimeBigKeyChest;
    public string TempleofTimeChestBeforeDarknut;
    public string TempleofTimeDarknutChest;
    public string TempleofTimeDungeonReward;
    public string TempleofTimeFirstStaircaseArmosChest;
    public string TempleofTimeFirstStaircaseGohmaGateChest;
    public string TempleofTimeFirstStaircaseWindowChest;
    public string TempleofTimeFloorSwitchPuzzleRoomUpperChest;
    public string TempleofTimeGilloutineChest;
    public string TempleofTimeLobbyLanternChest;
    public string TempleofTimeMovingWallBeamosRoomChest;
    public string TempleofTimeMovingWallDinalfosRoomChest;
    public string TempleofTimePoeAboveScales;
    public string TempleofTimePoeBehindGate;
    public string TempleofTimeScalesGohmaChest;
    public string TempleofTimeScalesUpperChest;
    public string UliCradleDelivery;
    public string UpperZorasRiverFemaleDragonfly;
    public string UpperZorasRiverPoe;
    public string WestHyruleFieldFemaleButterfly;
    public string WestHyruleFieldGoldenWolf;
    public string WestHyruleFieldHelmasaurGrottoChest;
    public string WestHyruleFieldMaleButterfly;
    public string WoodenStatue;
    public string WoodenSwordChest;
    public string WrestlingWithBo;
    public string ZorasDomainChestBehindWaterfall;
    public string ZorasDomainChestByMotherandChildIsles;
    public string ZorasDomainExtinguishAllTorchesChest;
    public string ZorasDomainLightAllTorchesChest;
    public string ZorasDomainMaleDragonfly;
    public string ZorasDomainMotherandChildIslePoe;
    public string ZorasDomainUnderwaterGoron;
    public string ZorasDomainWaterfallPoe;
}

public class SpoilerManager : MonoBehaviour
{
    private static SpoilerManager instance;

    public static SpoilerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpoilerManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SpoilerManager).Name);
                    instance = singletonObject.AddComponent<SpoilerManager>();
                }
            }
            return instance;
        }
    }

    public SpoilerLog spoilerLog;
    public ItemPlacements spoilerLogItems;

    [Header("Setup")]
    public string folderName = "SpoilerLog"; // folder to create
    public string folderPath; // location of new folder

    [Header("Scan")]
    public List<string> jsonFiles = new List<string>(); // list of files found in folder
    public List<string> jsonFilesForDisplay = new List<string>(); // trimmed json file names

    [Header("Import")]
    public string[] flightByFowlItems = new string[5];

    [Header("Item Lists")]
    public List<string> keyItems = new List<string>();
    public List<string> junkItems = new List<string>();

    [Header("Barren Checks")]
    public string[] allDungeons;
    public List<GameObject> barrenCheckCount = new List<GameObject>();

    [Header("Search")]
    public List<GameObject> availableChecks = new List<GameObject>();
    public List<GameObject> positiveHits = new List<GameObject>();
    public int matchEntryPoint;

    [Header("Fanadi")]
    public List<string>FanadiUsedChecks = new List<string>();
    public List<string> FanadiGeneratedHints = new List<string>();
    public int currentFanadiIndex;

    [Header("General Links")]
    public GameObject scanFolderButton;
    public TMP_Dropdown fileListDropdown;
    public GameObject loadPage;
    public GameObject hintPage;
    public GameObject noSelection; // text when trying to import without a file
    public GameObject Map;
    public GameObject Viewport;
    public Toggle rupeeMode;
    public GameObject ButtonYesReset;

    [Header("Spirit Assets")]
    public TMP_Text OrdonaText;
    public TMP_Text FaronText;
    public TMP_Text EldinText;
    public TMP_Text LanayruText;

    public Toggle OrdonaToggle;
    public Toggle FaronToggle;
    public Toggle EldinToggle;
    public Toggle LanayruToggle;

    [Header("Fanadi Assets")]
    public TMP_Text FanadiText;
    public TMP_Text DialogIndexText;
    public Button FanadiLeftArrow;
    public Button FanadiRightArrow;

    [Header("Import Toggles")]
    public Toggle AutoSettings;
    public Toggle AutoItemLayout;
    public Toggle AutoDungeons;
    public Toggle AutoStartingItems;
    public Toggle AutoExcludedChecks;
    public Toggle AutoReset;

    [Header("Settings Toggles/Dropdowns")]
    public TMP_Dropdown HyruleCastleRequirements;
    public TMP_Dropdown PalaceOfTwilightRequirements;
    public TMP_Dropdown FaronWoodsLogic;
    public Toggle SkipPrologue;
    public Toggle FaronTwilightCleared;
    public Toggle EldinTwilightCleared;
    public Toggle LanayruTwilightCleared;
    public Toggle SkipMDH;
    public Toggle EarlyLakebed;
    public Toggle EarlyArbiters;
    public Toggle EarlySnowpeak;
    public Toggle EarlyCitS;
    public TMP_Dropdown MinesEntrance;
    public TMP_Dropdown ToTEntrance;
    public Toggle WalletIncrease;
    public Toggle OpenDoorofTime;
    public Toggle UnlockMapRegions;
    public Toggle BonksDoDamage;
    public Toggle TransformAnywhere;
    public TMP_Dropdown SmallKeys;
    public TMP_Dropdown BigKeys;
    public TMP_Dropdown DamageMultiplier;

    [Header("For Auto Tabs")]
    public Toggle MainTab;
    public Toggle PoesTab;
    public Toggle BugsTab;

    [Header("For Auto Item Layout")]
    public GameObject ShowDungeons;
    public Button PresetMedium;
    public Toggle FixedHeight;
    public Slider ItemColumns;
    public Toggle ShowBugs;
    public Toggle ShowPoes;
    public Toggle ShowFusedShadows;
    public Toggle ShowMirrorShards;
    public Toggle ShowSkybook;
    public Toggle ShowVesselsOfLight;
    public Toggle ShowDungeonKeys;

    [Header("For Auto Starting Items")]
    public GameObject ShieldButton;
    public GameObject MagicArmorButton;
    public GameObject ZoraArmorButton;
    public GameObject ShadowCrystalButton;
    public GameObject HawkeyeButton;
    public GameObject SwordButton;
    public GameObject BoomerangButton;
    public GameObject SpinnerButton;
    public GameObject BCButton;
    public GameObject BowButton;
    public GameObject ClawshotButton;
    public GameObject IronBootsButton;
    public GameObject DominionRodButton;
    public GameObject LanternButton;
    public GameObject FishingRodButton;
    public GameObject SlingshotButton;
    public GameObject GiantBombBagButton;
    public GameObject BombBagButton;
    public GameObject BottleButton;
    public GameObject HorseCallButton;
    public GameObject AuruButton;
    public GameObject AsheiButton;
    public GameObject HiddenSkillButton;
    public GameObject SkyBookButton;
    public GameObject GateKeysButton;
    public GameObject BulblinCampKeyButton;
    public GameObject ForestKeyButton;

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

    void Start()
    {
        // Get the path for spoiler log folder
        folderPath = Path.Combine(Application.dataPath, folderName);

        // Check if the folder already exists
        if (!Directory.Exists(folderPath))
        {
            // If it doesn't exist, create the folder
            Directory.CreateDirectory(folderPath);
        }

        noSelection.SetActive(false);

        loadPage.SetActive(true);
        hintPage.SetActive(false);

        allDungeons = new string[] { "ForestTemple", "GoronMines", "LakebedTemple", "ArbitersGrounds", "SnowpeakRuins", "TempleOfTime", "CityInTheSky", "PalaceOfTwilight" };
    }

    public void ScanFolder()
    {
        noSelection.SetActive(false);

        // get and turn off scan result text
        Transform NoFiles = scanFolderButton.transform.GetChild(0);
        Transform YesFiles = scanFolderButton.transform.GetChild(1);

        NoFiles.gameObject.SetActive(false);
        YesFiles.gameObject.SetActive(false);

        // clear dropdown options and file list contents
        fileListDropdown.ClearOptions();
        jsonFiles.Clear();
        jsonFilesForDisplay.Clear();

        // Get all json files in directory 
        string[] arrayJsonFiles = Directory.GetFiles(folderPath, "*.json");
        // convert to list
        for (int i = 0; i < arrayJsonFiles.Length; i++)
        {
            jsonFiles.Add(arrayJsonFiles[i]);
            jsonFilesForDisplay.Add(arrayJsonFiles[i]);
        }

        if (jsonFiles.Count > 0) // files present
        {
            // scan result text
            if (jsonFiles.Count == 1)
                YesFiles.GetComponent<TMP_Text>().text = "1 json file found";
            else
                YesFiles.GetComponent<TMP_Text>().text = jsonFiles.Count + " json files found";

            YesFiles.gameObject.SetActive(true);

            // extract playthrough name
            for (int i = 0; i < jsonFilesForDisplay.Count; i++)
            {
                string noExtFile = Path.GetFileNameWithoutExtension(jsonFilesForDisplay[i]);
                string[] playthroughName = noExtFile.Split("--");
                jsonFilesForDisplay[i] = playthroughName[1];

            }

            // add simplified file names to dropdown
            fileListDropdown.AddOptions(jsonFilesForDisplay);
        }
        else // no files present
        {
            NoFiles.gameObject.SetActive(true);
        }
    }

    public void ImportJson()
    {
        if (jsonFiles.Count > 0)
        {
            // get specific file from dropdown selection
            string selectedJsonFile = jsonFiles[fileListDropdown.value];
            // json to string
            string jsonContent = File.ReadAllText(selectedJsonFile);
            // remove spaces
            string modifiedContent = jsonContent.Replace(" ", "");
            // Parse the JSON data
            spoilerLog = JsonUtility.FromJson<SpoilerLog>(modifiedContent);
            spoilerLogItems = spoilerLog.itemPlacements;

            // set playthrough name
            TMP_Text HintHeader = hintPage.transform.GetChild(0).GetComponent<TMP_Text>();
            HintHeader.text = spoilerLog.playthroughName;

            // reset Fanadi
            FanadiUsedChecks.Clear();
            FanadiGeneratedHints.Clear();
            currentFanadiIndex = 0;
            FanadiText.text = "Fortunes, prophecies, divination.You want it? It's yours my friend! As long as you have enough <color=#00ff00>rupees...</color>";
            ArrowInteractivity();
            IndexCounterUpdate();

            PopulateCheckContents();
            GenerateKeyItemsList();
            LoadSpiritHints();

            GameManager.Instance.HintRefresh();

            // auto import settings

            if (AutoReset.isOn)
            {
                ButtonYesReset.GetComponent<ResetBehaviour>().SetInput("Tracker");
                ButtonYesReset.GetComponent<ResetBehaviour>().OnClick();
            }

            if (AutoSettings.isOn)
            {
                ButtonYesReset.GetComponent<ResetBehaviour>().SetInput("Settings");
                ButtonYesReset.GetComponent<ResetBehaviour>().OnClick();

                if (spoilerLog.settings.castleRequirements == "All_Dungeons")
                    HyruleCastleRequirements.value = 1;
                else if (spoilerLog.settings.castleRequirements == "Mirror_Shards")
                    HyruleCastleRequirements.value = 2;
                else if (spoilerLog.settings.castleRequirements == "Fused_Shadows")
                    HyruleCastleRequirements.value = 3;
                else if (spoilerLog.settings.castleRequirements == "Open")
                    HyruleCastleRequirements.value = 4;

                if (spoilerLog.settings.palaceRequirements == "Mirror_Shards")
                    PalaceOfTwilightRequirements.value = 1;
                else if (spoilerLog.settings.palaceRequirements == "Fused_Shadows")
                    PalaceOfTwilightRequirements.value = 2;
                else if (spoilerLog.settings.palaceRequirements == "Open")
                    PalaceOfTwilightRequirements.value = 3;

                if (spoilerLog.settings.faronWoodsLogic == "Closed")
                    FaronWoodsLogic.value = 1;

                if (spoilerLog.settings.skipPrologue == true)
                    SkipPrologue.isOn = true;

                if (spoilerLog.settings.faronTwilightCleared == true)
                    FaronTwilightCleared.isOn = true;

                if (spoilerLog.settings.eldinTwilightCleared == true)
                    EldinTwilightCleared.isOn = true;

                if (spoilerLog.settings.lanayruTwilightCleared == true)
                    LanayruTwilightCleared.isOn = true;

                if (spoilerLog.settings.skipMdh == true)
                    SkipMDH.isOn = true;

                if (spoilerLog.settings.skipLakebedEntrance == true)
                    EarlyLakebed.isOn = true;

                if (spoilerLog.settings.skipArbitersEntrance == true)
                    EarlyArbiters.isOn = true;

                if (spoilerLog.settings.skipSnowpeakEntrance == true)
                    EarlySnowpeak.isOn = true;

                if (spoilerLog.settings.skipCityEntrance == true)
                    EarlyCitS.isOn = true;

                if (spoilerLog.settings.goronMinesEntrance == "NoWrestling")
                    MinesEntrance.value = 1;
                else if (spoilerLog.settings.goronMinesEntrance == "Open")
                    MinesEntrance.value = 2;

                if (spoilerLog.settings.totEntrance == "OpenGrove")
                    ToTEntrance.value = 1;
                else if (spoilerLog.settings.totEntrance == "Open")
                    ToTEntrance.value = 2;

                if (spoilerLog.settings.openDot == true)
                    OpenDoorofTime.isOn = true;

                if (spoilerLog.settings.increaseWallet == true)
                    WalletIncrease.isOn = true;

                if (spoilerLog.settings.openMap == true)
                    UnlockMapRegions.isOn = true;

                if (spoilerLog.settings.bonksDoDamage == "True")
                    BonksDoDamage.isOn = true;

                if (spoilerLog.settings.transformAnywhere == true)
                    TransformAnywhere.isOn = true;

                if (spoilerLog.settings.smallKeySettings == "Own_Dungeon")
                    SmallKeys.value = 1;
                else if (spoilerLog.settings.smallKeySettings == "Any_Dungeon")
                    SmallKeys.value = 2;
                else if (spoilerLog.settings.smallKeySettings == "Anywhere")
                    SmallKeys.value = 3;
                else if (spoilerLog.settings.smallKeySettings == "Keysy")
                    SmallKeys.value = 4;

                if (spoilerLog.settings.bigKeySettings == "Own_Dungeon")
                    BigKeys.value = 1;
                else if (spoilerLog.settings.bigKeySettings == "Any_Dungeon")
                    BigKeys.value = 2;
                else if (spoilerLog.settings.bigKeySettings == "Anywhere")
                    BigKeys.value = 3;
                else if (spoilerLog.settings.bigKeySettings == "Keysy")
                    BigKeys.value = 4;

                if (spoilerLog.settings.damageMagnification == "Double")
                    DamageMultiplier.value = 1;
                else if (spoilerLog.settings.damageMagnification == "Triple")
                    DamageMultiplier.value = 2;
                else if (spoilerLog.settings.damageMagnification == "Quadruple")
                    DamageMultiplier.value = 3;
                else if (spoilerLog.settings.damageMagnification == "OHKO")
                    DamageMultiplier.value = 4;

                MainTab.isOn = true;

                if (spoilerLog.settings.shufflePoes == "Vanilla")
                    PoesTab.isOn = false;
                else
                    PoesTab.isOn = true;

                if (spoilerLog.settings.shuffleGoldenBugs == false)
                    BugsTab.isOn = false;
                else
                    BugsTab.isOn = true;

                GameManager.Instance.Refresh();
            }

            if (AutoItemLayout.isOn)
            {
                PresetMedium.onClick.Invoke();

                if (spoilerLog.requiredDungeons.Length > 4)
                {
                    FixedHeight.isOn = true;
                    ItemColumns.value = 7;
                }

                if (spoilerLog.settings.shuffleNpcItems == false)
                    ShowBugs.isOn = false;

                if (spoilerLog.settings.shufflePoes == "Vanilla")
                    ShowPoes.isOn = false;

                ShowFusedShadows.isOn = false;
                ShowMirrorShards.isOn = false;

                if (spoilerLog.settings.castleRequirements == "Fused_Shadows" || spoilerLog.settings.palaceRequirements == "Fused_Shadows")
                    ShowFusedShadows.isOn = true;

                if (spoilerLog.settings.castleRequirements == "Mirror_Shards" || spoilerLog.settings.palaceRequirements == "Mirror_Shards")
                    ShowMirrorShards.isOn = true;

                if (spoilerLog.settings.skipCityEntrance == true)
                    ShowSkybook.isOn = true;

                if (spoilerLog.settings.faronTwilightCleared == false
                    || spoilerLog.settings.eldinTwilightCleared == false
                    || spoilerLog.settings.lanayruTwilightCleared == false)
                    ShowVesselsOfLight.isOn = true;

                if (spoilerLog.settings.smallKeySettings == "Keysy" && spoilerLog.settings.bigKeySettings == "Keysy")
                {
                    FixedHeight.isOn = false;
                    ShowDungeonKeys.isOn = true;
                }

                AutoPopulateDungeons();
            }

            if (AutoDungeons.isOn)
                AutoPopulateDungeons();

            if (AutoExcludedChecks.isOn)
            {
                int rupees = 0;
                barrenCheckCount.Clear();

                foreach (string exCheck in spoilerLog.settings.excludedChecks)
                {
                    bool breaker = false;

                    foreach (Transform child1 in Map.transform)
                    {
                        if (breaker == true)
                            break;

                        foreach (Transform child2 in child1.transform)
                        {
                            string removeUnderscores = exCheck.Replace(" ", "");
                            if (removeUnderscores.StartsWith(child2.name))
                            {
                                if (child2.GetComponent<Toggle>().isOn == true)
                                {
                                    child2.GetComponent<Toggle>().isOn = false;
                                    rupees += child2.GetComponent<ChecksBehaviour>().rupeesWorth;
                                }
                                breaker = true;
                                break;
                            }
                        }
                    }

                    foreach (Transform child1 in Viewport.transform)
                    {
                        if (breaker == true)
                            break;

                        foreach (Transform child2 in child1.transform)
                        {
                            string removeUnderscores = exCheck.Replace(" ", "");
                            if (child2.name == removeUnderscores)
                            {
                                if (child2.GetComponent<Toggle>().isOn == true)
                                {
                                    child2.GetComponent<Toggle>().isOn = false;
                                    rupees += child2.GetComponent<ListChecksBehaviour>().rupeesWorth;
                                }
                                breaker = true;
                                break;
                            }
                        }
                    }
                }

                // removes barren dungeon checks
                if (spoilerLog.settings.barrenDungeons == true)
                {
                    foreach (string dungeonName in allDungeons)
                    {
                        if (CheckForDungeon(dungeonName) == false)
                        {
                            foreach (Transform dungeonContainer in Viewport.transform)
                            {
                                if (dungeonContainer.name.StartsWith(dungeonName))
                                {
                                    foreach (Transform check in dungeonContainer.transform)
                                    {
                                        if (check.GetComponent<Toggle>().isOn == true)
                                        {
                                            check.GetComponent<Toggle>().isOn = false;
                                            rupees += check.GetComponent<ListChecksBehaviour>().rupeesWorth;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                GameManager.Instance.walletCount -= rupees;
                GameManager.Instance.HintRefresh();
            }

            if (AutoStartingItems.isOn)
            {
                foreach (string item in spoilerLog.settings.startingItems)
                {
                    if (item == "Ordon_Shield" || item == "Hylian_Shield")
                    {
                        ShieldButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Magic_Armor")//new
                    {
                        MagicArmorButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Zora_Armor")
                    {
                        ZoraArmorButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Shadow_Crystal")
                    {
                        ShadowCrystalButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Hawkeye")//new
                    {
                        HawkeyeButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Sword")
                    {
                        SwordButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Boomerang")
                    {
                        BoomerangButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Spinner")
                    {
                        SpinnerButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Ball_and_Chain")
                    {
                        BCButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Bow")
                    {
                        BowButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Clawshot")
                    {
                        ClawshotButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Iron_Boots")
                    {
                        IronBootsButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Dominion_Rod")
                    {
                        DominionRodButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Lantern")
                    {
                        LanternButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Fishing_Rod")
                    {
                        FishingRodButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Slingshot")
                    {
                        SlingshotButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Giant_Bomb_Bag")//new
                    {
                        GiantBombBagButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Filled_Bomb_Bag")
                    {
                        BombBagButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Empty_Bottle")
                    {
                        BottleButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Horse_Call")
                    {
                        HorseCallButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Aurus_Memo")
                    {
                        AuruButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Asheis_Sketch")
                    {
                        AsheiButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Hidden_Skill")//new
                    {
                        HiddenSkillButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Progressive_Sky_Book")
                    {
                        SkyBookButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }

                    if (item == "Gate_Keys")
                    {
                        GateKeysButton.GetComponent<ItemBehaviour>().ItemIncrement();
                        continue;
                    }
                }

                if (spoilerLog.settings.skipArbitersEntrance == true)
                    BulblinCampKeyButton.GetComponent<ItemBehaviour>().ItemIncrement();

                if (spoilerLog.settings.smallKeySettings == "Keysy")
                    GateKeysButton.GetComponent<ItemBehaviour>().ItemIncrement();
            }

            loadPage.SetActive(false);
            hintPage.SetActive(true);
        }
        else
        {
            noSelection.SetActive(true); // if no json file
        }
    }

    public void SaveSpoilerLog()
    {
        PlayerPrefs.SetString("currentSpoilerLog", JsonUtility.ToJson(spoilerLog));

        PlayerPrefs.SetString("OrdonaText", OrdonaText.text);
        PlayerPrefs.SetString("FaronText", FaronText.text);
        PlayerPrefs.SetString("EldinText", EldinText.text);
        PlayerPrefs.SetString("LanayruText", LanayruText.text);

        PlayerPrefs.SetInt("OrdonaOn", OrdonaToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("FaronOn", FaronToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("EldinOn", EldinToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("LanayruOn", LanayruToggle.isOn ? 1 : 0);

        int keyItemsCounter = 0;
        for (int i = 0; i < keyItems.Count; i++)
        {
            PlayerPrefs.SetString("keyItems" + i, keyItems[i]);
            keyItemsCounter++;
        }
        PlayerPrefs.SetInt("KeyItemsCounter", keyItemsCounter);

        int FanadiUsedChecksCounter = 0;
        for (int i = 0; i < FanadiUsedChecks.Count; i++)
        {
            PlayerPrefs.SetString("FanadiUsedChecks" + i, FanadiUsedChecks[i]);
            FanadiUsedChecksCounter++;
        }
        PlayerPrefs.SetInt("FanadiUsedChecksCounter", FanadiUsedChecksCounter);

        int FanadiGeneratedHintsCounter = 0;
        for (int i = 0; i < FanadiGeneratedHints.Count; i++)
        {
            PlayerPrefs.SetString("FanadiGeneratedHints" + i, FanadiGeneratedHints[i]);
            FanadiGeneratedHintsCounter++;
        }
        PlayerPrefs.SetInt("FanadiGeneratedHintsCounter", FanadiGeneratedHintsCounter);

        PlayerPrefs.SetInt("currentFanadiIndex", currentFanadiIndex);
    }

    public void LoadSavedSpoilerLog(string savedLog)
    {
        spoilerLog = JsonUtility.FromJson<SpoilerLog>(savedLog);
        spoilerLogItems = spoilerLog.itemPlacements;

        TMP_Text HintHeader = hintPage.transform.GetChild(0).GetComponent<TMP_Text>();
        HintHeader.text = spoilerLog.playthroughName;

        PopulateCheckContents();

        OrdonaText.text = PlayerPrefs.GetString("OrdonaText");
        FaronText.text = PlayerPrefs.GetString("FaronText");
        EldinText.text = PlayerPrefs.GetString("EldinText");
        LanayruText.text = PlayerPrefs.GetString("LanayruText");

        OrdonaToggle.isOn = PlayerPrefs.GetInt("OrdonaOn") != 0;
        FaronToggle.isOn = PlayerPrefs.GetInt("FaronOn") != 0;
        EldinToggle.isOn = PlayerPrefs.GetInt("EldinOn") != 0;
        LanayruToggle.isOn = PlayerPrefs.GetInt("LanayruOn") != 0;

        keyItems.Clear();

        for (int i = 0; i < PlayerPrefs.GetInt("KeyItemsCounter"); i++)
        {
            keyItems.Add(PlayerPrefs.GetString("keyItems" + i));
        }

        FanadiUsedChecks.Clear();

        for (int i = 0; i < PlayerPrefs.GetInt("FanadiUsedChecksCounter"); i++)
        {
            FanadiUsedChecks.Add(PlayerPrefs.GetString("FanadiUsedChecks" + i));
        }

        FanadiGeneratedHints.Clear();

        for (int i = 0; i < PlayerPrefs.GetInt("FanadiGeneratedHintsCounter"); i++)
        {
            FanadiGeneratedHints.Add(PlayerPrefs.GetString("FanadiGeneratedHints" + i));
        }

        if (FanadiGeneratedHints.Count == 0)
        {
            FanadiText.text = "Fortunes, prophecies, divination.You want it? It's yours my friend! As long as you have enough <color=#00ff00>rupees...</color>";
        }

        currentFanadiIndex = PlayerPrefs.GetInt("currentFanadiIndex");
        if (FanadiGeneratedHints.Count > 0)
            FanadiText.text = FanadiGeneratedHints[currentFanadiIndex];

        ArrowInteractivity();
        IndexCounterUpdate();

        GameManager.Instance.HintRefresh();
        GameManager.Instance.Refresh();

        loadPage.SetActive(false);
        hintPage.SetActive(true);
    }

    public void PopulateCheckContents()
    {
        foreach (Transform child1 in Map.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                string checkName = child2.gameObject.name;
                Type type = spoilerLogItems.GetType();
                FieldInfo field = type.GetField(checkName, BindingFlags.Public | BindingFlags.Instance);

                if (field != null)
                {
                    object locationObj = field.GetValue(spoilerLogItems);
                    child2.GetComponent<ChecksBehaviour>().checkContents = locationObj.ToString();
                }
                else if (child2.gameObject.name == "FlightByFowl")
                {
                    flightByFowlItems[0] = spoilerLogItems.FlightByFowlTopPlatformReward;
                    flightByFowlItems[1] = spoilerLogItems.FlightByFowlSecondPlatformChest;
                    flightByFowlItems[2] = spoilerLogItems.FlightByFowlThirdPlatformChest;
                    flightByFowlItems[3] = spoilerLogItems.FlightByFowlFourthPlatformChest;
                    flightByFowlItems[4] = spoilerLogItems.FlightByFowlFifthPlatformChest;
                }
                else
                {
                    Debug.LogError("Variable not found: " + checkName);
                }
            }
        }

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                string checkName = child2.gameObject.name;
                Type type = spoilerLogItems.GetType();
                FieldInfo field = type.GetField(checkName, BindingFlags.Public | BindingFlags.Instance);

                if (field != null)
                {
                    object locationObj = field.GetValue(spoilerLogItems);
                    child2.GetComponent<ListChecksBehaviour>().checkContents = locationObj.ToString();
                }
                else
                {
                    Debug.LogError("Variable not found: " + checkName);
                }
            }
        }
    }

    public void GenerateKeyItemsList()
    {
        keyItems.Clear();

        if (NotInStartingInventory("Progressive_Sword", 4))
            keyItems.Add("Progressive_Sword");

        if (NotInStartingInventory("Progressive_Fishing_Rod", 2))
            keyItems.Add("Progressive_Fishing_Rod");

        if (NotInStartingInventory("Lantern", 1))
            keyItems.Add("Lantern");

        if (NotInStartingInventory("Boomerang", 1))
            keyItems.Add("Boomerang");

        if (NotInStartingInventory("Progressive_Bow", 1))
            keyItems.Add("Progressive_Bow");

        if (NotInStartingInventory("Filled_Bomb_Bag", 1))
            keyItems.Add("Filled_Bomb_Bag");

        if (NotInStartingInventory("Iron_Boots", 1))
            keyItems.Add("Iron_Boots");

        if (NotInStartingInventory("Progressive_Dominion_Rod", 2))
            keyItems.Add("Progressive_Dominion_Rod");

        if (NotInStartingInventory("Aurus_Memo", 1)
            && spoilerLog.settings.shuffleNpcItems == true)
            keyItems.Add("Aurus_Memo");

        if (NotInStartingInventory("Ball_and_Chain", 1))
            keyItems.Add("Ball_and_Chain");

        if (NotInStartingInventory("Spinner", 1))
            keyItems.Add("Spinner");

        if (NotInStartingInventory("Zora_Armor", 1)
            && spoilerLog.settings.shuffleNpcItems == true)
            keyItems.Add("Zora_Armor");

        if (NotInStartingInventory("Progressive_Clawshot", 2))
            keyItems.Add("Progressive_Clawshot");

        if (NotInStartingInventory("Asheis_Sketch", 1)
            && spoilerLog.settings.shuffleNpcItems == true)
            keyItems.Add("Asheis_Sketch");

        if (NotInStartingInventory("Shadow_Crystal", 1))
            keyItems.Add("Shadow_Crystal");

        if (NotInStartingInventory("Progressive_Sky_Book", 7)
            && spoilerLog.settings.skipCityEntrance == false
            && spoilerLog.settings.shuffleSkyCharacters == true)
        {
            if (spoilerLog.settings.barrenDungeons == true)
            {
                foreach (string dungeon in spoilerLog.requiredDungeons)
                {
                    if (dungeon == "CityInTheSky")
                        keyItems.Add("Progressive_Sky_Book");
                }
            }
            else
            {
                keyItems.Add("Progressive_Sky_Book");
            }
        }

        if (NotInStartingInventory("Gerudo_Desert_Bulblin_Camp_Key", 1)
            && spoilerLog.settings.skipArbitersEntrance == false
            && spoilerLog.settings.smallKeySettings != "Vanilla")
            keyItems.Add("Gerudo_Desert_Bulblin_Camp_Key");

        if (NotInStartingInventory("Gate_Keys", 1)
            && spoilerLog.settings.smallKeySettings != "Keysy")
            keyItems.Add("Gate_Keys");

        // Small Keys
        if (spoilerLog.settings.smallKeySettings == "Any_Dungeon" || spoilerLog.settings.smallKeySettings == "Anywhere")
        {
            foreach (string dungeon in spoilerLog.requiredDungeons)
            {
                if (dungeon == "ForestTemple")
                {
                    keyItems.Add("Forest_Temple_Small_Key");
                    continue;
                }
                if (dungeon == "GoronMines")
                {
                    keyItems.Add("Goron_Mines_Small_Key");
                    continue;
                }
                if (dungeon == "LakebedTemple")
                {
                    keyItems.Add("Lakebed_Temple_Small_Key");
                    continue;
                }
                if (dungeon == "ArbitersGrounds")
                {
                    keyItems.Add("Arbiters_Grounds_Small_Key");
                    continue;
                }
                if (dungeon == "SnowpeakRuins")
                {
                    keyItems.Add("Snowpeak_Ruins_Small_Key");
                    keyItems.Add("Snowpeak_Ruins_Ordon_Goat_Cheese");
                    keyItems.Add("Snowpeak_Ruins_Ordon_Pumpkin");
                    continue;
                }
                if (dungeon == "TempleOfTime")
                {
                    keyItems.Add("Temple_of_Time_Small_Key");
                    continue;
                }
                if (dungeon == "CityInTheSky")
                {
                    keyItems.Add("City_in_The_Sky_Small_Key");
                    continue;
                }
                if (dungeon == "PalaceOfTwilight")
                {
                    keyItems.Add("Palace_of_Twilight_Small_Key");
                    continue;
                }
            }

            keyItems.Add("Hyrule_Castle_Small_Key");
        }

        // Big Keys
        if (spoilerLog.settings.bigKeySettings == "Any_Dungeon" || spoilerLog.settings.bigKeySettings == "Anywhere")
        {
            foreach (string dungeon in spoilerLog.requiredDungeons)
            {
                if (dungeon == "ForestTemple")
                {
                    keyItems.Add("Forest_Temple_Big_Key");
                    continue;
                }
                if (dungeon == "GoronMines")
                {
                    keyItems.Add("Goron_Mines_Key_Shard");
                    continue;
                }
                if (dungeon == "LakebedTemple")
                {
                    keyItems.Add("Lakebed_Temple_Big_Key");
                    continue;
                }
                if (dungeon == "ArbitersGrounds")
                {
                    keyItems.Add("Arbiters_Grounds_Big_Key");
                    continue;
                }
                if (dungeon == "SnowpeakRuins")
                {
                    keyItems.Add("Snowpeak_Ruins_Bedroom_Key");
                    continue;
                }
                if (dungeon == "TempleOfTime")
                {
                    keyItems.Add("Temple_of_Time_Big_Key");
                    continue;
                }
                if (dungeon == "CityInTheSky")
                {
                    keyItems.Add("City_in_The_Sky_Big_Key");
                    continue;
                }
                if (dungeon == "PalaceOfTwilight")
                {
                    keyItems.Add("Palace_of_Twilight_Big_Key");
                    continue;
                }
            }

            keyItems.Add("Hyrule_Castle_Big_Key");
        }
    }

    public bool NotInStartingInventory(string inputItem, int numToCheck)
    {
        int tempCount = 0;

        foreach (string item in spoilerLog.settings.startingItems)
        {
            if (item == inputItem)
                tempCount += 1;
            if (tempCount >= numToCheck)
                return false;
        }
        return true;
    }

    public void LoadSpiritHints()
    {
        if (keyItems.Count > 0)
        {
            string chosenItemOrdona = GetChecksWithRandomItem();
            ChangeSpiritText(OrdonaText, chosenItemOrdona, true);
            RemoveUsedIndex(chosenItemOrdona);

            string chosenItemFaron = GetChecksWithRandomItem();
            ChangeSpiritText(FaronText, chosenItemFaron, false);
            RemoveUsedIndex(chosenItemFaron);

            string chosenItemEldin = GetChecksWithRandomItem();
            ChangeSpiritText(EldinText, chosenItemEldin, false);
            RemoveUsedIndex(chosenItemEldin);

            string chosenItemLanayru = GetChecksWithRandomItem();
            ChangeSpiritText(LanayruText, chosenItemLanayru, true);
            RemoveUsedIndex(chosenItemLanayru);
        }
        else
        {
            OrdonaText.text = "No hints available...";
            FaronText.text = "No hints available...";
            EldinText.text = "No hints available...";
            LanayruText.text = "No hints available...";
        }
    }

    public string GetChecksWithRandomItem()
    {
        positiveHits.Clear();
        int randomItemInt = UnityEngine.Random.Range(0, keyItems.Count);
        if (keyItems.Count > 0)
        {
            string randomItemStr = keyItems[randomItemInt];

            foreach (Transform child1 in Map.transform)
            {
                foreach (Transform child2 in child1.transform)
                {
                    if (child2.gameObject.name == "FlightByFowl")
                    {
                        for (int i = 0; i < flightByFowlItems.Length; i++)
                        {
                            if (flightByFowlItems[i] == randomItemStr)
                                positiveHits.Add(child2.gameObject);
                        }
                    }
                    else if (child2.GetComponent<ChecksBehaviour>().checkContents == randomItemStr)
                        positiveHits.Add(child2.gameObject);
                }
            }

            foreach (Transform child1 in Viewport.transform)
            {
                foreach (Transform child2 in child1.transform)
                {
                    if (child2.GetComponent<ListChecksBehaviour>().checkContents == randomItemStr)
                        positiveHits.Add(child2.gameObject);
                }
            }

            return randomItemStr;
        }

        return "";
    }

    public void ChangeSpiritText(TMP_Text spirit, string chosenItem, bool includeItem)
    {
        if (positiveHits.Count > 0)
        {
            // picks a random check from the list
            int randomCheckInt = UnityEngine.Random.Range(0, positiveHits.Count);

            string itemNameFormatted = FormatItemName(chosenItem);

            string locationNameFormatted = FormatLocationName(positiveHits[randomCheckInt].name);

            // changes text
            if (includeItem == true)
                spirit.text = itemNameFormatted + "... " + locationNameFormatted + "... ";
            else
                spirit.text = locationNameFormatted + "...";
            
        }
    }

    public void RemoveUsedIndex(string chosenItem)
    {
        int usedIndex = keyItems.FindIndex(item => item == chosenItem);
        if (keyItems.Count > 0)
            keyItems.RemoveAt(usedIndex);
    }

    public void FanadiTier1()
    {
        GetAvailableChecksStrict();
        string matchResult = "";
        int randomItemInt = UnityEngine.Random.Range(0, junkItems.Count);

        for (int i = 0; i < junkItems.Count; i++)
        {
            string randomItemStr = junkItems[randomItemInt];
            matchResult = LookForMatch(randomItemStr);

            if (matchResult != null)
                break;
            else
            {
                randomItemInt++;
                if (randomItemInt >= junkItems.Count)
                    randomItemInt = 0;
            }
        }

        if (matchResult != null)
        {
            FanadiUsedChecks.Add(matchResult);
            string fanadiFormattedText = FormatFanadi1(matchResult);
            FanadiGeneratedHints.Add(fanadiFormattedText);
            FanadiText.text = FanadiGeneratedHints[FanadiGeneratedHints.Count - 1];
            GameManager.Instance.walletCount -= 5;
        }
        else
        {
            FanadiGeneratedHints.Add("Hmm... your future is hidden from me. I won't charge you, feel free to <color=#00ffaa>try again another time</color>.");
            FanadiText.text = FanadiGeneratedHints[FanadiGeneratedHints.Count - 1];
        }

        GameManager.Instance.HintRefresh();
        currentFanadiIndex = FanadiGeneratedHints.Count - 1;
        IndexCounterUpdate();
        ArrowInteractivity();
    }

    public void FanadiTier2()
    {
        GetAvailableChecks();
        string matchResult = "";
        string randomItemStr = "";
        int randomItemInt = UnityEngine.Random.Range(0, keyItems.Count);

        for (int i = 0; i < keyItems.Count; i++)
        {
            randomItemStr = keyItems[randomItemInt];
            matchResult = LookForMatch(randomItemStr);

            if (matchResult != null)
                break;
            else
            {
                randomItemInt++;
                if (randomItemInt >= keyItems.Count)
                    randomItemInt = 0;
            }
        }

        if (matchResult != null)
        {
            string region = GetRegion();
            FanadiUsedChecks.Add(matchResult);
            string fanadiFormattedText = FormatFanadi2(region, randomItemStr);
            FanadiGeneratedHints.Add(fanadiFormattedText);
            FanadiText.text = FanadiGeneratedHints[FanadiGeneratedHints.Count - 1];
            GameManager.Instance.walletCount -= 20;
        }
        else
        {
            FanadiGeneratedHints.Add("Hmm... my crystal ball is clouded. I won't charge you, feel free to <color=#00ffaa>try again another time</color>.");
            FanadiText.text = FanadiGeneratedHints[FanadiGeneratedHints.Count - 1];
        }

        GameManager.Instance.HintRefresh();
        currentFanadiIndex = FanadiGeneratedHints.Count - 1;
        IndexCounterUpdate();
        ArrowInteractivity();
    }

    public void FanadiTier3()
    {
        GetAvailableChecks();
        string matchResult = "";
        string randomItemStr = "";
        int randomItemInt = UnityEngine.Random.Range(0, keyItems.Count);

        for (int i = 0; i < keyItems.Count; i++)
        {
            randomItemStr = keyItems[randomItemInt];
            matchResult = LookForMatch(randomItemStr);

            if (matchResult != null)
                break;
            else
            {
                randomItemInt++;
                if (randomItemInt >= keyItems.Count)
                    randomItemInt = 0;
            }
        }

        if (matchResult != null)
        {
            FanadiUsedChecks.Add(matchResult);
            string fanadiFormattedText = FormatFanadi3(matchResult, randomItemStr);
            FanadiGeneratedHints.Add(fanadiFormattedText);
            FanadiText.text = FanadiGeneratedHints[FanadiGeneratedHints.Count - 1];
            GameManager.Instance.walletCount -= 50;
        }
        else
        {
            FanadiGeneratedHints.Add("Hmm... the spirits have gone quiet. I won't charge you, feel free to <color=#00ffaa>try again another time</color>.");
            FanadiText.text = FanadiGeneratedHints[FanadiGeneratedHints.Count - 1];
        }

        GameManager.Instance.HintRefresh();
        currentFanadiIndex = FanadiGeneratedHints.Count - 1;
        IndexCounterUpdate();
        ArrowInteractivity();
    }

    public void GetAvailableChecks()
    {
        availableChecks.Clear();

        foreach (Transform child1 in Map.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                if (child2.GetComponent<ChecksBehaviour>().checkAvailibility == true
                    && child2.GetComponent<ChecksBehaviour>().checkCompletion == false)
                    availableChecks.Add(child2.gameObject);
            }
        }

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                if (child2.GetComponent<ListChecksBehaviour>().checkAvailibility == true
                    && child2.GetComponent<ListChecksBehaviour>().checkCompletion == false
                    && !child2.name.StartsWith("Agitha"))
                    availableChecks.Add(child2.gameObject);
            }
        }

        foreach (string usedStr in FanadiUsedChecks)
        {
            foreach(GameObject check in availableChecks)
            {
                if (check.name == usedStr)
                {
                    int usedIndex = availableChecks.FindIndex(item => item == check);
                    availableChecks.RemoveAt(usedIndex);
                    break;
                }

            }
        }
    }

    public void GetAvailableChecksStrict()
    {
        availableChecks.Clear();
        barrenCheckCount.Clear();

        foreach (Transform child1 in Map.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                if (child2.GetComponent<ChecksBehaviour>().checkAvailibility == true
                    && child2.GetComponent<ChecksBehaviour>().checkCompletion == false)
                    availableChecks.Add(child2.gameObject);
            }
        }

        foreach (Transform child1 in Viewport.transform)
        {
            foreach (Transform child2 in child1.transform)
            {
                if (child2.GetComponent<ListChecksBehaviour>().checkAvailibility == true
                    && child2.GetComponent<ListChecksBehaviour>().checkCompletion == false
                    && !child2.name.StartsWith("Agitha"))
                    availableChecks.Add(child2.gameObject);
            }
        }

        foreach (string usedStr in FanadiUsedChecks)
        {
            foreach (GameObject check in availableChecks)
            {
                if (check.name == usedStr)
                {
                    int usedIndex = availableChecks.FindIndex(item => item == check);
                    availableChecks.RemoveAt(usedIndex);
                    break;
                }

            }
        }

        foreach (string exCheck in spoilerLog.settings.excludedChecks)
        {
            foreach (GameObject check in availableChecks)
            {
                if (check.name == exCheck)
                {
                    int exIndex = availableChecks.FindIndex(item => item == check);
                    availableChecks.RemoveAt(exIndex);
                    break;
                }
            }
        }

        if (spoilerLog.settings.shuffleNpcItems == false)
        {
            foreach (GameObject check in availableChecks)
            {
                if (check.name.StartsWith("Agitha"))
                    barrenCheckCount.Add(check);
            }
        }

        if (spoilerLog.settings.barrenDungeons == true)
        {
            foreach (string dungeon in allDungeons)
            {
                if (CheckForDungeon(dungeon) == false)
                {
                    foreach (GameObject check in availableChecks)
                    {
                        string dungeonFormat1 = dungeon.Replace("In", "in");
                        string dungeonFormat2 = dungeonFormat1.Replace("Of", "of");

                        if (check.name.StartsWith(dungeonFormat2))
                            barrenCheckCount.Add(check);
                    }
                }
            }
        }

        foreach (GameObject check in barrenCheckCount)
        {
            int exIndex = availableChecks.FindIndex(item => item == check);
            availableChecks.RemoveAt(exIndex);
        }
    }

    public bool CheckForDungeon(string dungeonName)
    {
        foreach (string dungeon in spoilerLog.requiredDungeons)
        {
            if (dungeon == dungeonName)
                return true;
        }

        return false;
    }

    public string GetRegion()
    {
        if (availableChecks[matchEntryPoint].GetComponent<ChecksBehaviour>() != null)
            return availableChecks[matchEntryPoint].GetComponent<ChecksBehaviour>().region;
        else if (availableChecks[matchEntryPoint].GetComponent<ListChecksBehaviour>() != null)
            return availableChecks[matchEntryPoint].GetComponent<ListChecksBehaviour>().region;
        else
            return null;
    }

    public string LookForMatch(string item)
    {
        matchEntryPoint = UnityEngine.Random.Range(0, availableChecks.Count);

        for (int i = 0; i < availableChecks.Count; i++)
        {
            if (availableChecks[matchEntryPoint].GetComponent<ChecksBehaviour>() != null)
            {
                if (availableChecks[matchEntryPoint].GetComponent<ChecksBehaviour>().checkContents == item)
                {
                    return availableChecks[matchEntryPoint].name;
                }
            }

            if (availableChecks[matchEntryPoint].GetComponent<ListChecksBehaviour>() != null)
            {
                if (availableChecks[matchEntryPoint].GetComponent<ListChecksBehaviour>().checkContents == item)
                {
                    return availableChecks[matchEntryPoint].name;
                }
            }

            matchEntryPoint += 1;
            if (matchEntryPoint >= availableChecks.Count)
            {
                matchEntryPoint = 0;
            }

        }
        return null;
    }

    public string AgithaFormat(string checkName)
    {
        checkName.Replace("Agitha", "");
        checkName.Replace("Reward", "");
        if (checkName.StartsWith("Male"))
            checkName.Replace("Male", "Male_");
        else
            checkName.Replace("Female", "Female_");

        if (checkName.EndsWith("StagBeetle"))
            checkName.Replace("StagBeetle", "Stag_Beetle");
        if (checkName.EndsWith("PillBug"))
            checkName.Replace("PillBug", "Pill_Bug");

        Debug.Log(checkName);
        return checkName;
    }

    public string FormatFanadi1(string checkName)
    {
        string checkNameFormatted = FormatLocationName(checkName);
        int randomLine = UnityEngine.Random.Range(0, 3);

        if (randomLine == 0)
        {
            string comp1 = "The spirits say <color=#ffff00>" + checkNameFormatted + "</color>. Whatever it is, it's not worth your time...";
            return comp1;
        }
        else if (randomLine == 1)
        {
            string comp2 = "<color=#ffff00>" + checkNameFormatted + "</color>... From what I can tell, your energy would best be spent elsewhere.";
            return comp2;
        }
        else
        {
            string comp3 = "Some places are best avoided. <color=#ffff00>" + checkNameFormatted + "</color>... Yes, that is one of them...";
            return comp3;
        }
    }

    public string FormatFanadi2(string regionName, string checkContents)
    {
        string itemNameFormatted = FormatItemName(checkContents);
        string itemArticle = GetItemArticle(itemNameFormatted);
        int randomLine = UnityEngine.Random.Range(0, 3);

        if (randomLine == 0)
        {
            string comp1 = "If " + itemArticle + "<color=#00ffaa>" + itemNameFormatted + "</color> is what you seek... <color=#ffff00>" + regionName + "</color>, is what the spirits whisper...";
            return comp1;
        }
        else if (randomLine == 1)
        {
            string comp2 = "<color=#ffff00>" + regionName + "</color>... Yes, I see " + itemArticle + "<color=#00ffaa>" + itemNameFormatted + "</color> in your future should you travel there...";
            return comp2;
        }
        else
        {
            string comp3 = "For your journey, " + itemArticle + "<color=#00ffaa>" + itemNameFormatted + "</color> could be of much use. <color=#ffff00>" + regionName + "</color>... Yes, that's where your path should guide you.";
            return comp3;
        }
    }

    public string FormatFanadi3(string checkName, string checkContents)
    {
        string checkNameFormatted = FormatLocationName(checkName);
        string itemNameFormatted = FormatItemName(checkContents);
        string article = GetItemArticle(itemNameFormatted);
        int randomLine = UnityEngine.Random.Range(0, 3);

        if (randomLine == 0)
        {
            string comp1 = "Clear as day! I see " + article + "<color=#00ffaa>" + itemNameFormatted + "</color>... The spirits say <color=#ffff00>" + checkNameFormatted + "</color>, whatever that means...";
            return comp1;
        }
        else if (randomLine == 1)
        {
            string comp2 = "<color=#ffff00>" + checkNameFormatted + "</color>... I feel strongly that " + article + "<color=#00ffaa>" + itemNameFormatted + "</color> can be found there...";
            return comp2;
        }
        else
        {
            string comp3 = "I sense " + article + "<color=#00ffaa>" + itemNameFormatted + "</color> in your future... <color=#ffff00>" + checkNameFormatted + "</color> is written in the stars...";
            return comp3;
        }
    }

    public string FormatItemName(string itemName)
    {
        // formats item name
        string itemNameFormatted1 = itemName.Replace("_", " ");
        string itemNameFormatted2 = itemNameFormatted1.Replace("Progressive", "");
        string itemNameFormatted3 = itemNameFormatted2.Replace("Aurus", "Auru's");
        string itemNameFormatted4 = itemNameFormatted3.Replace("Asheis", "Ashei's");
        string itemNameFormatted5 = itemNameFormatted4.Replace("Gerudo Desert", "");
        string itemNameFormatted6 = itemNameFormatted5.Replace("Snowpeak Ruins Ordon Goat Cheese", "Goat Cheese");
        string itemNameFormatted7 = itemNameFormatted6.Replace("Snowpeak Ruins Ordon Pumpkin", "Pumpkin");
        string itemNameFormatted8 = itemNameFormatted7.Replace("Arbiters", "Arbiter's");
        if (itemNameFormatted8[0] == ' ')
            itemNameFormatted8 = itemNameFormatted8.Remove(0, 1);

        return itemNameFormatted8;
    }

    public string FormatLocationName(string locationName)
    {
        string locationNameFormatted1 = locationName;
        string locationNameFormatted2 = string.Empty;

        foreach (char letter in locationNameFormatted1)
        {
            if (char.IsUpper(letter))
                locationNameFormatted2 += " " + letter;
            else
                locationNameFormatted2 += letter;
        }
        if (!string.IsNullOrEmpty(locationNameFormatted2) && locationNameFormatted2[0] == ' ')
            locationNameFormatted2 = locationNameFormatted2.Remove(0, 1);

        string locationNameFormatted3 = locationNameFormatted2.Replace("Templeof", "Temple of");
        string locationNameFormatted4 = locationNameFormatted3.Replace("Cityin", "City in");
        string locationNameFormatted5 = locationNameFormatted4.Replace("Palaceof", "Palace of");
        string locationNameFormatted6 = locationNameFormatted5.Replace("Caveof", "Cave of");
        string locationNameFormatted7 = locationNameFormatted6.Replace("Bridgeof", "Bridge of");
        string locationNameFormatted8 = locationNameFormatted7.Replace("Isleof", "Isle of");
        string locationNameFormatted9 = locationNameFormatted8.Replace("Motherand", "Mother and");
        string locationNameFormatted10 = locationNameFormatted9.Replace("Balland", "Ball and");
        string locationNameFormatted11 = locationNameFormatted10.Replace("Hideand", "Hide and");
        string locationNameFormatted12 = locationNameFormatted11.Replace("Prize1", "Prize 1");
        string locationNameFormatted13 = locationNameFormatted12.Replace("Prize2", "Prize 2");

        return locationNameFormatted13;
    }

    public string GetItemArticle(string check)
    {
        string article;

        if (check == "Sword"
            || check == "Fishing Rod"
            || check == "Bow"
            || check == "Filled Bomb Bag"
            || check == "Dominion Rod"
            || check == "Clawshot"
            || check == "Sky Book"
            || check == "Forest Temple Small Key"
            || check == "Goron Mines Small Key"
            || check == "Goron Mines Key Shard"
            || check == "Lakebed Temple Small Key"
            || check == "Snowpeak Ruins Small Key"
            || check == "Temple of Time Small Key"
            || check == "Palace of Twilight Small Key"
            || check == "Hyrule Castle Small Key")
        {
            article = "a ";
        }
        else if (check == "Arbiter's Grounds Small Key")
            article = "an ";
        else if (check == "Auru's Memo" || check == "Ashei's Sketch")
            article = "";
        else
            article = "the ";

        return article;
    }

    public void IncrementDialog()
    {
        if (currentFanadiIndex < (FanadiGeneratedHints.Count - 1))
        {
            currentFanadiIndex += 1;
            FanadiText.text = FanadiGeneratedHints[currentFanadiIndex];
        }

        IndexCounterUpdate();
        ArrowInteractivity();
    }

    public void DecrementDialog()
    {
        if (currentFanadiIndex > 0)
        {
            currentFanadiIndex -= 1;
            FanadiText.text = FanadiGeneratedHints[currentFanadiIndex];
        }

        IndexCounterUpdate();
        ArrowInteractivity();
    }

    public void ArrowInteractivity()
    {
        if (FanadiGeneratedHints.Count == 0)
        {
            FanadiLeftArrow.interactable = false;
            FanadiRightArrow.interactable = false;
        }
        else
        {
            FanadiLeftArrow.interactable = true;
            FanadiRightArrow.interactable = true;
        }

        if (currentFanadiIndex >= (FanadiGeneratedHints.Count - 1))
            FanadiRightArrow.interactable = false;
        else
            FanadiRightArrow.interactable = true;

        if (currentFanadiIndex <= 0)
            FanadiLeftArrow.interactable = false;
        else
            FanadiLeftArrow.interactable = true;
    }

    public void IndexCounterUpdate()
    {
        int count = currentFanadiIndex + 1;
        if (FanadiGeneratedHints.Count > 0)
        {
            DialogIndexText.text = count + "/" + FanadiGeneratedHints.Count;
        }
        else
            DialogIndexText.text = "";
    }

    public void AutoPopulateDungeons()
    {
        foreach (Transform dungeonToggle in ShowDungeons.transform)
        {
            dungeonToggle.GetComponent<Toggle>().isOn = false;

            foreach (string requiredDungeon in spoilerLog.requiredDungeons)
            {
                if (requiredDungeon == "ForestTemple" && dungeonToggle.name == "ShowForestTemple")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "GoronMines" && dungeonToggle.name == "ShowGoronMines")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "LakebedTemple" && dungeonToggle.name == "ShowLakebedTemple")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "ArbitersGrounds" && dungeonToggle.name == "ShowArbitersGrounds")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "SnowpeakRuins" && dungeonToggle.name == "ShowSnowpeakRuins")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "TempleOfTime" && dungeonToggle.name == "ShowTempleOfTime")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "CityInTheSky" && dungeonToggle.name == "ShowCityInTheSky")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }

                if (requiredDungeon == "PalaceOfTwilight" && dungeonToggle.name == "ShowPalaceOfTwilight")
                {
                    dungeonToggle.GetComponent<Toggle>().isOn = true;
                    break;
                }
            }
        }
    }
}
