using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameSoundManager
{
    private bool[] activeSounds;
    private AudioSource arcaneReady;
    private AudioSource arcaneTaunt1;
    private AudioSource arcaneTaunt2;
    private AudioSource archerReady;
    private AudioSource archerTaunt1;
    private AudioSource archerTaunt2;
    private AudioSource arrowHit1;
    private AudioSource arrowHit2;
    private AudioSource arrowRelease1;
    private AudioSource arrowRelease2;
    private AudioSource artilleryBfgReady;
    private AudioSource artilleryBfgTaunt1;
    private AudioSource artilleryBfgTaunt2;
    private AudioSource artilleryReady;
    private AudioSource artilleryTaunt1;
    private AudioSource artilleryTaunt2;
    private AudioSource artilleryTeslaReady;
    private AudioSource artilleryTeslaTaunt1;
    private AudioSource artilleryTeslaTaunt2A;
    private AudioSource artilleryTeslaTaunt2B;
    private AudioSource artilleryTeslaTaunt2C;
    private AudioSource axe;
    private AudioSource barrackBarbarianMove;
    private AudioSource barrackBarbarianReady;
    private AudioSource barrackBarbarianTaunt1;
    private AudioSource barrackBarbarianTaunt2;
    private AudioSource barrackMove;
    private AudioSource barrackPaladinMove;
    private AudioSource barrackPaladinReady;
    private AudioSource barrackPaladinTaunt1;
    private AudioSource barrackPaladinTaunt2;
    private AudioSource barrackReady;
    private AudioSource barrackTaunt1;
    private AudioSource barrackTaunt2;
    private AudioSource bombExplosion;
    private AudioSource bombShoot;
    private AudioSource buttonCommon;
    private AudioSource buyAchievementWin;
    private AudioSource buyUpgrade;
    private AudioClip clipArcaneReady;
    private AudioClip clipArcaneTaunt1;
    private AudioClip clipArcaneTaunt2;
    private AudioClip clipArcherReady;
    private AudioClip clipArcherTaunt1;
    private AudioClip clipArcherTaunt2;
    private AudioClip clipArrowHit1;
    private AudioClip clipArrowHit2;
    private AudioClip clipArrowRelease1;
    private AudioClip clipArrowRelease2;
    private AudioClip clipArtilleryBfgReady;
    private AudioClip clipArtilleryBfgTaunt1;
    private AudioClip clipArtilleryBfgTaunt2;
    private AudioClip clipArtilleryReady;
    private AudioClip clipArtilleryTaunt1;
    private AudioClip clipArtilleryTaunt2;
    private AudioClip clipArtilleryTeslaReady;
    private AudioClip clipArtilleryTeslaTaunt1;
    private AudioClip clipArtilleryTeslaTaunt2A;
    private AudioClip clipArtilleryTeslaTaunt2B;
    private AudioClip clipArtilleryTeslaTaunt2C;
    private AudioClip clipAxe;
    private AudioClip clipBarrackBarbarianMove;
    private AudioClip clipBarrackBarbarianReady;
    private AudioClip clipBarrackBarbarianTaunt1;
    private AudioClip clipBarrackBarbarianTaunt2;
    private AudioClip clipBarrackMove;
    private AudioClip clipBarrackPaladinMove;
    private AudioClip clipBarrackPaladinReady;
    private AudioClip clipBarrackPaladinTaunt1;
    private AudioClip clipBarrackPaladinTaunt2;
    private AudioClip clipBarrackReady;
    private AudioClip clipBarrackTaunt1;
    private AudioClip clipBarrackTaunt2;
    private AudioClip clipBombExplosion;
    private AudioClip clipBombShoot;
    private AudioClip clipButtonCommon;
    private AudioClip clipBuyAchievementWin;
    private AudioClip clipBuyUpgrade;
    private AudioClip clipCoins;
    private AudioClip clipCommonAreaAttack;
    private AudioClip clipDeathBig;
    private AudioClip clipDeathExplosion;
    private AudioClip clipDeathGoblin;
    private AudioClip clipDeathHuman1;
    private AudioClip clipDeathHuman2;
    private AudioClip clipDeathHuman3;
    private AudioClip clipDeathHuman4;
    private AudioClip clipDeathOrc;
    private AudioClip clipDeathPuff;
    private AudioClip clipDeathSkeleton;
    private AudioClip clipDeathTroll;
    private AudioClip clipDesintegrate;
    private AudioClip clipElfTaunt1;
    private AudioClip clipElfTaunt2;
    private AudioClip clipEnemyChieftain;
    private AudioClip clipEnemyHealing;
    private AudioClip clipEnemyRocketeer;
    private AudioClip clipFireballHit;
    private AudioClip clipFireballRelease;
    private AudioClip clipHealing;
    private AudioClip clipHeroDwarfBreaHit;
    private AudioClip clipHeroDwarfBreaShoot;
    private AudioClip clipHeroDwarfDeath;
    private AudioClip clipHeroDwarfMine;
    private AudioClip clipHeroDwarfTaunt1;
    private AudioClip clipHeroDwarfTaunt2;
    private AudioClip clipHeroDwarfTaunt3;
    private AudioClip clipHeroDwarfTaunt4;
    private AudioClip clipHeroElvenArrow;
    private AudioClip clipHeroElvenDeath;
    private AudioClip clipHeroElvenTaunt1;
    private AudioClip clipHeroElvenTaunt2;
    private AudioClip clipHeroElvenTaunt3;
    private AudioClip clipHeroElvenTaunt4;
    private AudioClip clipHeroElvenWildCatHit;
    private AudioClip clipHeroElvenWildCatSummon;
    private AudioClip clipHeroFireDeath;
    private AudioClip clipHeroFireSpecialArea;
    private AudioClip clipHeroFireSpecialFireballEnd;
    private AudioClip clipHeroFireSpecialFireballStart;
    private AudioClip clipHeroFireTaunt1;
    private AudioClip clipHeroFireTaunt2;
    private AudioClip clipHeroFireTaunt3;
    private AudioClip clipHeroFireTaunt4;
    private AudioClip clipHeroFrostDeath;
    private AudioClip clipHeroFrostGroundFreeze;
    private AudioClip clipHeroFrostIceRainBreak;
    private AudioClip clipHeroFrostIceRainDrop;
    private AudioClip clipHeroFrostIceRainSummon;
    private AudioClip clipHeroFrostTaunt1;
    private AudioClip clipHeroFrostTaunt2;
    private AudioClip clipHeroFrostTaunt3;
    private AudioClip clipHeroFrostTaunt4;
    private AudioClip clipHeroKingAttack;
    private AudioClip clipHeroKingBuff1;
    private AudioClip clipHeroKingBuff2;
    private AudioClip clipHeroKingDeath;
    private AudioClip clipHeroKingTaunt1;
    private AudioClip clipHeroKingTaunt2;
    private AudioClip clipHeroKingTaunt3;
    private AudioClip clipHeroKingTaunt4;
    private AudioClip clipHeroLevelUp;
    private AudioClip clipHeroMageBlueRainCharge;
    private AudioClip clipHeroMageBlueRainDrop;
    private AudioClip clipHeroMageDeath;
    private AudioClip clipHeroMageShadows;
    private AudioClip clipHeroMageTaunt1;
    private AudioClip clipHeroMageTaunt2;
    private AudioClip clipHeroMageTaunt3;
    private AudioClip clipHeroMageTaunt4;
    private AudioClip clipHeroPaladinDeath;
    private AudioClip clipHeroPaladinDeflect;
    private AudioClip clipHeroPaladinShieldBuff;
    private AudioClip clipHeroPaladinTaunt1;
    private AudioClip clipHeroPaladinTaunt2;
    private AudioClip clipHeroPaladinTaunt3;
    private AudioClip clipHeroPaladinTaunt4;
    private AudioClip clipHeroReinforcementChargeSpecial;
    private AudioClip clipHeroReinforcementDeath;
    private AudioClip clipHeroReinforcementHit;
    private AudioClip clipHeroReinforcementJumpSpecial;
    private AudioClip clipHeroReinforcementTaunt1;
    private AudioClip clipHeroReinforcementTaunt2;
    private AudioClip clipHeroReinforcementTaunt3;
    private AudioClip clipHeroReinforcementTaunt4;
    private AudioClip clipHeroRobotDeath;
    private AudioClip clipHeroRobotDrill;
    private AudioClip clipHeroRobotShoot;
    private AudioClip clipHeroRobotTaunt1;
    private AudioClip clipHeroRobotTaunt2;
    private AudioClip clipHeroRobotTaunt3;
    private AudioClip clipHeroRobotTaunt4;
    private AudioClip clipHeroSamuraiDeath;
    private AudioClip clipHeroSamuraiDeathStrike;
    private AudioClip clipHeroSamuraiGroundSawblades;
    private AudioClip clipHeroSamuraiTaunt1;
    private AudioClip clipHeroSamuraiTaunt2;
    private AudioClip clipHeroSamuraiTaunt3;
    private AudioClip clipHeroSamuraiTaunt4;
    private AudioClip clipHeroThorDeath;
    private AudioClip clipHeroThorElectricalDeath;
    private AudioClip clipHeroThorElectricAttack;
    private AudioClip clipHeroThorHammer;
    private AudioClip clipHeroThorTaunt1;
    private AudioClip clipHeroThorTaunt2;
    private AudioClip clipHeroThorTaunt3;
    private AudioClip clipHeroThorTaunt4;
    private AudioClip clipHeroThorThunder;
    private AudioClip clipHeroVikingBearStartAttack;
    private AudioClip clipHeroVikingCall;
    private AudioClip clipHeroVikingDeath;
    private AudioClip clipHeroVikingHit;
    private AudioClip clipHeroVikingTaunt1;
    private AudioClip clipHeroVikingTaunt2;
    private AudioClip clipHeroVikingTaunt3;
    private AudioClip clipHeroVikingTaunt4;
    private AudioClip clipHeroVikingTransform;
    private AudioClip clipInfernoBossDeath;
    private AudioClip clipInfernoBossHorns;
    private AudioClip clipInfernoBossStomp;
    private AudioClip clipJTAttack;
    private AudioClip clipJTDeath;
    private AudioClip clipJTEat;
    private AudioClip clipJTExplode;
    private AudioClip clipJTHitIce1;
    private AudioClip clipJTHitIce2;
    private AudioClip clipJTHitIce3;
    private AudioClip clipJTRest;
    private AudioClip clipJuggernautDeath;
    private AudioClip clipLoseLife;
    private AudioClip clipMageBolt;
    private AudioClip clipMageReady;
    private AudioClip clipMageTaunt1;
    private AudioClip clipMageTaunt2;
    private AudioClip clipMapNewFlag;
    private AudioClip clipMapNewRoad;
    private AudioClip clipMeleeSword;
    private AudioClip clipMushroomBossDeath;
    private AudioClip clipMushroomBossGas;
    private AudioClip clipMushroomCreepDeath;
    private AudioClip clipMushroomCreepNacimiento;
    private AudioClip clipMusketeerReady;
    private AudioClip clipMusketeerSniper;
    private AudioClip clipMusketeerTaunt1;
    private AudioClip clipMusketeerTaunt2;
    private AudioClip clipNotificationClose;
    private AudioClip clipNotificationOpen;
    private AudioClip clipNotificationPaperOver;
    private AudioClip clipNotificationSecondLevel;
    private AudioClip clipPolymorph;
    private AudioClip clipQuestCompleted;
    private AudioClip clipQuestFailed;
    private AudioClip clipQuickmenuOpen;
    private AudioClip clipQuickmenuOver;
    private AudioClip clipRallyPlaced;
    private AudioClip clipRangerReady;
    private AudioClip clipRangerTaunt1;
    private AudioClip clipRangerTaunt2;
    private AudioClip clipRayArcane;
    private AudioClip clipReinforcementTaunt1;
    private AudioClip clipReinforcementTaunt2;
    private AudioClip clipReinforcementTaunt3;
    private AudioClip clipReinforcementTaunt4;
    private AudioClip clipRockElementalDeath;
    private AudioClip clipRockElementalRally;
    private AudioClip clipRocketLaunch;
    private AudioClip clipSasquashRally;
    private AudioClip clipSasquashReady;
    private AudioClip clipSheep;
    private AudioClip clipShotgun;
    private AudioClip clipShrapnel;
    private AudioClip clipSniper;
    private AudioClip clipSorcererBolt;
    private AudioClip clipSorcererReady;
    private AudioClip clipSorcererTaunt1;
    private AudioClip clipSorcererTaunt2;
    private AudioClip clipSpellRefresh;
    private AudioClip clipSpellSelect;
    private AudioClip clipSpiderAttack1;
    private AudioClip clipSpiderAttack2;
    private AudioClip clipTeleport;
    private AudioClip clipTeslaAttack1;
    private AudioClip clipTeslaAttack2;
    private AudioClip clipThorn;
    private AudioClip clipTowerBuilding;
    private AudioClip clipTowerOpenDoor;
    private AudioClip clipTowerSell;
    private AudioClip clipTowerUpgrade;
    private AudioClip clipTransitionClose;
    private AudioClip clipTransitionOpen;
    private AudioClip clipVeznanAttack;
    private AudioClip clipVeznanDeath;
    private AudioClip clipVeznanDemonFire;
    private AudioClip clipVeznanHoldCast;
    private AudioClip clipVeznanHoldDissipate;
    private AudioClip clipVeznanHoldHit;
    private AudioClip clipVeznanHoldTrap;
    private AudioClip clipVeznanPortalIn;
    private AudioClip clipVeznanPortalSummon;
    private AudioClip clipVeznanToDemon;
    private AudioClip clipWaveIncoming;
    private AudioClip clipWaveReady;
    private AudioClip clipWinStars;
    private AudioClip clipWolfAttack1;
    private AudioClip clipWolfAttack2;
    private AudioSource coins;
    private AudioSource commonAreaAttack;
    private AudioSource deathBig;
    private AudioSource deathExplosion;
    private AudioSource deathGoblin;
    private AudioSource deathHuman1;
    private AudioSource deathHuman2;
    private AudioSource deathHuman3;
    private AudioSource deathHuman4;
    private AudioSource deathOrc;
    private AudioSource deathPuff;
    private AudioSource deathSkeleton;
    private AudioSource deathTroll;
    private AudioSource desintegrate;
    private AudioSource elfTaunt1;
    private AudioSource elfTaunt2;
    private AudioSource enemyChieftain;
    private AudioSource enemyHealing;
    private AudioSource enemyRocketeer;
    private AudioSource fireballHit;
    private AudioSource fireballRelease;
    private AudioSource healing;
    private AudioSource heroDwarfBreaHit;
    private AudioSource heroDwarfBreaShoot;
    private AudioSource heroDwarfDeath;
    private AudioSource heroDwarfMine;
    private AudioSource heroDwarfTaunt1;
    private AudioSource heroDwarfTaunt2;
    private AudioSource heroDwarfTaunt3;
    private AudioSource heroDwarfTaunt4;
    private AudioSource heroElvenArrow;
    private AudioSource heroElvenDeath;
    private AudioSource heroElvenTaunt1;
    private AudioSource heroElvenTaunt2;
    private AudioSource heroElvenTaunt3;
    private AudioSource heroElvenTaunt4;
    private AudioSource heroElvenWildCatHit;
    private AudioSource heroElvenWildCatSummon;
    private AudioSource heroFireDeath;
    private AudioSource heroFireSpecialArea;
    private AudioSource heroFireSpecialFireballEnd;
    private AudioSource heroFireSpecialFireballStart;
    private AudioSource heroFireTaunt1;
    private AudioSource heroFireTaunt2;
    private AudioSource heroFireTaunt3;
    private AudioSource heroFireTaunt4;
    private AudioSource heroFrostDeath;
    private AudioSource heroFrostGroundFreeze;
    private AudioSource heroFrostIceRainBreak;
    private AudioSource heroFrostIceRainDrop;
    private AudioSource heroFrostIceRainSummon;
    private AudioSource heroFrostTaunt1;
    private AudioSource heroFrostTaunt2;
    private AudioSource heroFrostTaunt3;
    private AudioSource heroFrostTaunt4;
    private AudioSource heroKingAttack;
    private AudioSource heroKingBuff1;
    private AudioSource heroKingBuff2;
    private AudioSource heroKingDeath;
    private AudioSource heroKingTaunt1;
    private AudioSource heroKingTaunt2;
    private AudioSource heroKingTaunt3;
    private AudioSource heroKingTaunt4;
    private AudioSource heroLevelUp;
    private AudioSource heroMageBlueRainCharge;
    private AudioSource heroMageBlueRainDrop;
    private AudioSource heroMageDeath;
    private AudioSource heroMageShadows;
    private AudioSource heroMageTaunt1;
    private AudioSource heroMageTaunt2;
    private AudioSource heroMageTaunt3;
    private AudioSource heroMageTaunt4;
    private AudioSource heroPaladinDeath;
    private AudioSource heroPaladinDeflect;
    private AudioSource heroPaladinShieldBuff;
    private AudioSource heroPaladinTaunt1;
    private AudioSource heroPaladinTaunt2;
    private AudioSource heroPaladinTaunt3;
    private AudioSource heroPaladinTaunt4;
    private AudioSource heroReinforcementChargeSpecial;
    private AudioSource heroReinforcementDeath;
    private AudioSource heroReinforcementHit;
    private AudioSource heroReinforcementJumpSpecial;
    private AudioSource heroReinforcementTaunt1;
    private AudioSource heroReinforcementTaunt2;
    private AudioSource heroReinforcementTaunt3;
    private AudioSource heroReinforcementTaunt4;
    private AudioSource heroRobotDeath;
    private AudioSource heroRobotDrill;
    private AudioSource heroRobotShoot;
    private AudioSource heroRobotTaunt1;
    private AudioSource heroRobotTaunt2;
    private AudioSource heroRobotTaunt3;
    private AudioSource heroRobotTaunt4;
    private AudioSource heroSamurai;
    private AudioSource heroSamuraiDeath;
    private AudioSource heroSamuraiDeathStrike;
    private AudioSource heroSamuraiGroundSawblades;
    private AudioSource heroSamuraiTaunt1;
    private AudioSource heroSamuraiTaunt2;
    private AudioSource heroSamuraiTaunt3;
    private AudioSource heroSamuraiTaunt4;
    private AudioSource heroThorDeath;
    private AudioSource heroThorElectricalDeath;
    private AudioSource heroThorElectricAttack;
    private AudioSource heroThorHammer;
    private AudioSource heroThorTaunt1;
    private AudioSource heroThorTaunt2;
    private AudioSource heroThorTaunt3;
    private AudioSource heroThorTaunt4;
    private AudioSource heroThorThunder;
    private AudioSource heroVikingBearStartAttack;
    private AudioSource heroVikingCall;
    private AudioSource heroVikingDeath;
    private AudioSource heroVikingHit;
    private AudioSource heroVikingTaunt1;
    private AudioSource heroVikingTaunt2;
    private AudioSource heroVikingTaunt3;
    private AudioSource heroVikingTaunt4;
    private AudioSource heroVikingTransform;
    private AudioSource infernoBossDeath;
    private AudioSource infernoBossHorns;
    private AudioSource infernoBossStomp;
    private static GameSoundManager instance;
    private bool isAttackPlaying;
    private AudioSource jtAttack;
    private AudioSource jtDeath;
    private AudioSource jtEat;
    private AudioSource jtExplode;
    private AudioSource jtHitIce1;
    private AudioSource jtHitIce2;
    private AudioSource jtHitIce3;
    private AudioSource jtRest;
    private AudioSource juggernautDeath;
    private AudioSource loseLife;
    private AudioSource mageBolt;
    private AudioSource mageReady;
    private AudioSource mageTaunt1;
    private AudioSource mageTaunt2;
    private AudioSource mapNewFlag;
    private AudioSource mapNewRoad;
    private AudioSource meleeSword;
    private AudioSource mushroomBossDeath;
    private AudioSource mushroomBossGas;
    private AudioSource mushroomCreepMuerte;
    private AudioSource mushroomCreepNacimiento;
    private bool musicMuted;
    private AudioSource musketeerReady;
    private AudioSource musketeerSniper;
    private AudioSource musketeerTaunt1;
    private AudioSource musketeerTaunt2;
    private AudioSource notificationClose;
    private AudioSource notificationOpen;
    private AudioSource notificationPaperOver;
    private AudioSource notificationSecondLevel;
    private AudioSource polymorph;
    private ArrayList poolActiveArrowRelease1;
    private ArrayList poolActiveArrowRelease2;
    private ArrayList poolActiveAxe;
    private ArrayList poolActiveBombExplosion;
    private ArrayList poolActiveBombShoot;
    private ArrayList poolActiveCommonAreaAttack;
    private ArrayList poolActiveDeathBig;
    private ArrayList poolActiveDeathExplosion;
    private ArrayList poolActiveDeathGoblin;
    private ArrayList poolActiveDeathOrc;
    private ArrayList poolActiveDeathPuff;
    private ArrayList poolActiveDeathSkeleton;
    private ArrayList poolActiveDeathTroll;
    private ArrayList poolActiveDesintegrate;
    private ArrayList poolActiveElementalDeath;
    private ArrayList poolActiveEnemyCheiftain;
    private ArrayList poolActiveEnemyHealing;
    private ArrayList poolActiveEnemyRocketeer;
    private ArrayList poolActiveFireballHit;
    private ArrayList poolActiveFireballRelease;
    private ArrayList poolActiveHealing;
    private ArrayList poolActiveHeroMageRainDrop;
    private ArrayList poolActiveHuman1;
    private ArrayList poolActiveHuman2;
    private ArrayList poolActiveHuman3;
    private ArrayList poolActiveHuman4;
    private ArrayList poolActiveMageBolt;
    private ArrayList poolActiveMapNewFlag;
    private ArrayList poolActivePolymorph;
    private ArrayList poolActiveRayArcane;
    private ArrayList poolActiveRocketLaunch;
    private ArrayList poolActiveSheep;
    private ArrayList poolActiveShotgun;
    private ArrayList poolActiveShrapnel;
    private ArrayList poolActiveSniper;
    private ArrayList poolActiveSorcererBolt;
    private ArrayList poolActiveTeleport;
    private ArrayList poolActiveTeslaAttack1;
    private ArrayList poolActiveTeslaAttack2;
    private ArrayList poolActiveThorn;
    private ArrayList poolActiveVeznanAttack;
    private ArrayList poolActiveVeznanHoldDissipate;
    private ArrayList poolActiveVeznanHoldHit;
    private ArrayList poolActiveVeznanPortalIn;
    private ArrayList poolActiveWinStars;
    private ArrayList poolArrowRelease1;
    private ArrayList poolArrowRelease2;
    private ArrayList poolAxe;
    private ArrayList poolBombExplosion;
    private ArrayList poolBombShoot;
    private ArrayList poolCommonAreaAttack;
    private ArrayList poolDeathBig;
    private ArrayList poolDeathExplosion;
    private ArrayList poolDeathGoblin;
    private ArrayList poolDeathOrc;
    private ArrayList poolDeathPuff;
    private ArrayList poolDeathSkeleton;
    private ArrayList poolDeathTroll;
    private ArrayList poolDesintegrate;
    private ArrayList poolElementalDeath;
    private ArrayList poolEnemyCheiftain;
    private ArrayList poolEnemyHealing;
    private ArrayList poolEnemyRocketeer;
    private ArrayList poolFireballHit;
    private ArrayList poolFireballRelease;
    private ArrayList poolHealing;
    private ArrayList poolHeroMageRainDrop;
    private ArrayList poolHuman1;
    private ArrayList poolHuman2;
    private ArrayList poolHuman3;
    private ArrayList poolHuman4;
    private ArrayList poolMageBolt;
    private ArrayList poolMapNewFlag;
    private ArrayList poolPolymorph;
    private ArrayList poolRayArcane;
    private ArrayList poolRocketLaunch;
    private ArrayList poolSheep;
    private ArrayList poolShotgun;
    private ArrayList poolShrapnel;
    private ArrayList poolSniper;
    private ArrayList poolSorcererBolt;
    private ArrayList poolTeleport;
    private ArrayList poolTeslaAttack1;
    private ArrayList poolTeslaAttack2;
    private ArrayList poolThorn;
    private ArrayList poolVeznanAttack;
    private ArrayList poolVeznanHoldDissipate;
    private ArrayList poolVeznanHoldHit;
    private ArrayList poolVeznanPortalIn;
    private ArrayList poolWinStars;
    private AudioSource questCompleted;
    private AudioSource questFailed;
    private AudioSource quickmenuOpen;
    private AudioSource quickmenuOver;
    private AudioSource rallyPlaced;
    private AudioSource rangerReady;
    private AudioSource rangerTaunt1;
    private AudioSource rangerTaunt2;
    private AudioSource rayArcane;
    private AudioSource reinforcementTaunt1;
    private AudioSource reinforcementTaunt2;
    private AudioSource reinforcementTaunt3;
    private AudioSource reinforcementTaunt4;
    private AudioSource rockElementalDeath;
    private AudioSource rockElementalRally;
    private AudioSource rocketLaunch;
    private AudioSource sasquashRally;
    private AudioSource sasquashReady;
    private AudioSource sheep;
    private AudioSource shotgun;
    private AudioSource shrapnel;
    private AudioSource sniper;
    private AudioSource sorcererBolt;
    private AudioSource sorcererReady;
    private AudioSource sorcererTaunt1;
    private AudioSource sorcererTaunt2;
    private int soundArcherTauntActive;
    private const float soundArcherTauntTime = 1.5f;
    private float soundArcherTauntTimeStop;
    private int soundBarbarianTauntActive;
    private int soundElfTauntActive;
    private int soundEngineerTauntActive;
    private const float soundEngineerTauntTime = 1.5f;
    private float soundEngineerTauntTimeStop;
    private int soundHeroArcherTauntActive;
    private int soundHeroElementalTauntActive;
    private int soundHeroEngineerTauntActive;
    private int soundHeroFrostTauntActive;
    private int soundHeroKingBuffActive;
    private int soundHeroKingTauntActive;
    private int soundHeroMageTauntActive;
    private int soundHeroPaladinTauntActive;
    private int soundHeroReinforcementTauntActive;
    private int soundHeroRobotTauntActive;
    private int soundHeroSamuraiTauntActive;
    private int soundHeroThorTauntActive;
    private const float soundHeroTime = 1f;
    private float soundHeroTimeStop;
    private int soundHeroVikingTauntActive;
    private int soundJtHitIceActive;
    private int soundMageTauntActive;
    private const float soundMageTauntTime = 1.5f;
    private float soundMageTauntTimeStop;
    private int soundMusketeerTauntActive;
    private bool soundMuted;
    private int soundPaladinTauntActive;
    private int soundRangerTauntActive;
    private int soundReinforcementTauntActive;
    private const float soundSheepsTauntTime = 1.5f;
    private float soundSheepsTauntTimeStop;
    private int soundSoldierTauntActive;
    private const float soundSoldierTauntTime = 1.5f;
    private float soundSoldierTauntTimeStop;
    private int soundSorcererTauntActive;
    private AudioSource[] soundSources;
    private const float soundSpiderAttackTime = 1.5f;
    private float soundSpiderAttackTimeStop;
    private int soundTeslaToastyActive;
    private const float soundWolfAttackTime = 1.5f;
    private float soundWolfAttackTimeStop;
    private AudioSource spellRefresh;
    private AudioSource spellSelect;
    private AudioSource spiderAttack1;
    private AudioSource spiderAttack2;
    private StageBase stage;
    private AudioSource teleport;
    private AudioSource teslaAttack1;
    private AudioSource teslaAttack2;
    private AudioSource thorn;
    private AudioSource towerBuilding;
    private AudioSource towerOpenDoor;
    private AudioSource towerSell;
    private AudioSource towerUpgrade;
    private AudioSource transitionClose;
    private AudioSource transitionOpen;
    private AudioSource veznanAttack;
    private AudioSource veznanDeath;
    private AudioSource veznanDemonFire;
    private AudioSource veznanHoldCast;
    private AudioSource veznanHoldDissipate;
    private AudioSource veznanHoldHit;
    private AudioSource veznanHoldTrap;
    private AudioSource veznanPortalIn;
    private AudioSource veznanPortalSummon;
    private AudioSource veznanToDemon;
    private const float VOLUME_ARROW_MAX = 0.9f;
    private const float VOLUME_ARROW_MIN = 0.8f;
    private const float VOLUME_AXE_MAX = 0.8f;
    private const float VOLUME_AXE_MIN = 0.6f;
    private const float VOLUME_BOMB_EXPLOSION = 0.65f;
    private const float VOLUME_BOMB_EXPLOSION_SHOT = 0.65f;
    private const float VOLUME_DEATH_EXPLOSION = 0.4f;
    private const float VOLUME_DEATH_SOUND_MAX = 0.9f;
    private const float VOLUME_DEATH_SOUND_MEDIUM = 0.8f;
    private const float VOLUME_DEATH_SOUND_MIN = 0.6f;
    private const float VOLUME_DESINTEGRATE = 1f;
    private const float VOLUME_FIREBALL = 0.5f;
    private const float VOLUME_GUI = 1f;
    private const float VOLUME_GUI_LOW = 0.8f;
    private const float VOLUME_GUI_LOWEST = 0.6f;
    private const float VOLUME_GUI_MAX = 1f;
    private const float VOLUME_GUI_MEDIUM = 1f;
    private const float VOLUME_HIT_SOUND = 0.15f;
    private const float VOLUME_JT_MAX = 1f;
    private const float VOLUME_JT_MEDIUM = 0.7f;
    private const float VOLUME_MAGE_BOLT = 0.68f;
    private const float VOLUME_MELEE_SWORDS = 0.6f;
    private const float VOLUME_PALADIN_HEALING = 0.8f;
    private const float VOLUME_POLYMORPH = 0.9f;
    private const float VOLUME_ROCKET_LAUNCH = 0.8f;
    private const float VOLUME_SHEEP = 0.7f;
    private const float VOLUME_TAUNTS = 0.6f;
    private const float VOLUME_TELEPORTH = 1f;
    private const float VOLUME_TESLA_ATTACK = 0.6f;
    private const float VOLUME_THORN = 0.8f;
    private const float VOLUME_VEZNAN_MAX = 1f;
    private const float VOLUME_VEZNAN_MEDIUM = 0.7f;
    private float volumeFxPercentage;
    private float volumeMusicPercentage;
    private AudioSource waveIncoming;
    private AudioSource waveReady;
    private AudioSource winStars;
    private AudioSource wolfAttack1;
    private AudioSource wolfAttack2;

    public GameSoundManager()
    {
        base..ctor();
        if (instance == null)
        {
            goto Label_001B;
        }
        Debug.LogError("Cannot have two instances of singleton.");
        return;
    Label_001B:
        instance = this;
        this.Init();
        return;
    }

    public static void CheckSoldiersFight()
    {
        bool flag;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        AudioSource source;
        IDisposable disposable;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        flag = 0;
        if ((Instance.stage == null) == null)
        {
            goto Label_0040;
        }
        Instance.stage = GameObject.Find("Stage").GetComponent<StageBase>();
    Label_0040:
        enumerator = Instance.stage.GetSoldiers().GetEnumerator();
    Label_0057:
        try
        {
            goto Label_00A1;
        Label_005C:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsDead() != null)
            {
                goto Label_00A1;
            }
            if (soldier.IsWalking() != null)
            {
                goto Label_00A1;
            }
            if (soldier.IsFighting() == null)
            {
                goto Label_00A1;
            }
            if ((soldier.GetEnemy() != null) == null)
            {
                goto Label_00A1;
            }
            flag = 1;
            goto Label_00AC;
        Label_00A1:
            if (enumerator.MoveNext() != null)
            {
                goto Label_005C;
            }
        Label_00AC:
            goto Label_00C6;
        }
        finally
        {
        Label_00B1:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00BE;
            }
        Label_00BE:
            disposable.Dispose();
        }
    Label_00C6:
        if (flag == null)
        {
            goto Label_0115;
        }
        if (Instance.isAttackPlaying != null)
        {
            goto Label_0143;
        }
        source = Instance.meleeSword;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.isAttackPlaying = 1;
        goto Label_0143;
    Label_0115:
        if (Instance.isAttackPlaying == null)
        {
            goto Label_0143;
        }
        Instance.meleeSword.GetComponent<AudioSource>().Stop();
        Instance.isAttackPlaying = 0;
    Label_0143:
        return;
    }

    private ArrayList CreateActivePool(int size)
    {
        ArrayList list;
        int num;
        list = new ArrayList();
        num = 0;
        goto Label_001E;
    Label_000D:
        list.Add((bool) 0);
        num += 1;
    Label_001E:
        if (num < size)
        {
            goto Label_000D;
        }
        return list;
    }

    private void CreateActiveSoundPools()
    {
        Instance.poolActiveArrowRelease1 = this.CreateActivePool(3);
        Instance.poolActiveArrowRelease2 = this.CreateActivePool(3);
        Instance.poolActiveMageBolt = this.CreateActivePool(4);
        Instance.poolActiveBombExplosion = this.CreateActivePool(8);
        Instance.poolActiveBombShoot = this.CreateActivePool(4);
        Instance.poolActiveShotgun = this.CreateActivePool(4);
        Instance.poolActiveShrapnel = this.CreateActivePool(4);
        Instance.poolActiveSniper = this.CreateActivePool(4);
        Instance.poolActiveFireballRelease = this.CreateActivePool(4);
        Instance.poolActiveFireballHit = this.CreateActivePool(4);
        Instance.poolActiveSorcererBolt = this.CreateActivePool(4);
        Instance.poolActivePolymorph = this.CreateActivePool(4);
        Instance.poolActiveDesintegrate = this.CreateActivePool(4);
        Instance.poolActiveTeleport = this.CreateActivePool(4);
        Instance.poolActiveThorn = this.CreateActivePool(4);
        Instance.poolActiveHealing = this.CreateActivePool(4);
        Instance.poolActiveAxe = this.CreateActivePool(4);
        Instance.poolActiveRocketLaunch = this.CreateActivePool(4);
        Instance.poolActiveRayArcane = this.CreateActivePool(4);
        Instance.poolActiveTeslaAttack1 = this.CreateActivePool(2);
        Instance.poolActiveTeslaAttack2 = this.CreateActivePool(2);
        Instance.poolActiveCommonAreaAttack = this.CreateActivePool(4);
        Instance.poolActiveEnemyHealing = this.CreateActivePool(4);
        Instance.poolActiveEnemyRocketeer = this.CreateActivePool(4);
        Instance.poolActiveEnemyCheiftain = this.CreateActivePool(4);
        Instance.poolActiveHeroMageRainDrop = this.CreateActivePool(8);
        Instance.poolActiveWinStars = this.CreateActivePool(3);
        Instance.poolActiveMapNewFlag = this.CreateActivePool(2);
        Instance.poolActiveElementalDeath = this.CreateActivePool(3);
        Instance.poolActiveVeznanAttack = this.CreateActivePool(2);
        Instance.poolActiveVeznanHoldDissipate = this.CreateActivePool(4);
        Instance.poolActiveVeznanHoldHit = this.CreateActivePool(4);
        Instance.poolActiveVeznanPortalIn = this.CreateActivePool(4);
        Instance.poolActiveDeathGoblin = this.CreateActivePool(4);
        Instance.poolActiveDeathOrc = this.CreateActivePool(3);
        Instance.poolActiveDeathExplosion = this.CreateActivePool(4);
        Instance.poolActiveDeathPuff = this.CreateActivePool(4);
        Instance.poolActiveDeathSkeleton = this.CreateActivePool(4);
        Instance.poolActiveDeathTroll = this.CreateActivePool(4);
        Instance.poolActiveDeathBig = this.CreateActivePool(4);
        Instance.poolActiveHuman1 = this.CreateActivePool(3);
        Instance.poolActiveHuman2 = this.CreateActivePool(3);
        Instance.poolActiveHuman3 = this.CreateActivePool(2);
        Instance.poolActiveHuman4 = this.CreateActivePool(2);
        Instance.poolActiveSheep = this.CreateActivePool(2);
        return;
    }

    private AudioSource CreateAudioSource(AudioClip clip, bool looping = false)
    {
        GameObject obj2;
        AudioSource source;
        obj2 = new GameObject("Audio: " + clip.name);
        obj2.transform.position = Camera.main.transform.position;
        source = obj2.AddComponent<AudioSource>();
        source.playOnAwake = 0;
        source.clip = clip;
        UnityEngine.Object.DontDestroyOnLoad(obj2.gameObject);
        if (looping == null)
        {
            goto Label_005D;
        }
        source.loop = 1;
    Label_005D:
        return source;
    }

    private ArrayList CreatePool(GameObject sound, int size)
    {
        ArrayList list;
        int num;
        GameObject obj2;
        list = new ArrayList();
        list.Add(sound.GetComponent<AudioSource>());
        num = 0;
        goto Label_003D;
    Label_001A:
        obj2 = UnityEngine.Object.Instantiate(sound) as GameObject;
        UnityEngine.Object.DontDestroyOnLoad(obj2);
        list.Add(obj2.GetComponent<AudioSource>());
        num += 1;
    Label_003D:
        if (num < (size - 1))
        {
            goto Label_001A;
        }
        return list;
    }

    private void CreateSoundPools()
    {
        Instance.poolArrowRelease1 = this.CreatePool(Instance.arrowRelease1.gameObject, 3);
        Instance.poolArrowRelease2 = this.CreatePool(Instance.arrowRelease2.gameObject, 3);
        Instance.poolMageBolt = this.CreatePool(Instance.mageBolt.gameObject, 4);
        Instance.poolBombExplosion = this.CreatePool(Instance.bombExplosion.gameObject, 5);
        Instance.poolBombShoot = this.CreatePool(Instance.bombShoot.gameObject, 4);
        Instance.poolShotgun = this.CreatePool(Instance.shotgun.gameObject, 4);
        Instance.poolSniper = this.CreatePool(Instance.sniper.gameObject, 4);
        Instance.poolShrapnel = this.CreatePool(Instance.shrapnel.gameObject, 4);
        Instance.poolFireballRelease = this.CreatePool(Instance.fireballRelease.gameObject, 4);
        Instance.poolFireballHit = this.CreatePool(Instance.fireballHit.gameObject, 4);
        Instance.poolSorcererBolt = this.CreatePool(Instance.sorcererBolt.gameObject, 4);
        Instance.poolPolymorph = this.CreatePool(Instance.polymorph.gameObject, 4);
        Instance.poolDesintegrate = this.CreatePool(Instance.desintegrate.gameObject, 4);
        Instance.poolTeleport = this.CreatePool(Instance.teleport.gameObject, 4);
        Instance.poolThorn = this.CreatePool(Instance.thorn.gameObject, 4);
        Instance.poolHealing = this.CreatePool(Instance.healing.gameObject, 4);
        Instance.poolAxe = this.CreatePool(Instance.axe.gameObject, 4);
        Instance.poolRocketLaunch = this.CreatePool(Instance.rocketLaunch.gameObject, 4);
        Instance.poolRayArcane = this.CreatePool(Instance.rayArcane.gameObject, 4);
        Instance.poolTeslaAttack1 = this.CreatePool(Instance.teslaAttack1.gameObject, 2);
        Instance.poolTeslaAttack2 = this.CreatePool(Instance.teslaAttack2.gameObject, 2);
        Instance.poolCommonAreaAttack = this.CreatePool(Instance.commonAreaAttack.gameObject, 4);
        Instance.poolEnemyHealing = this.CreatePool(Instance.enemyHealing.gameObject, 4);
        Instance.poolEnemyRocketeer = this.CreatePool(Instance.enemyRocketeer.gameObject, 4);
        Instance.poolEnemyCheiftain = this.CreatePool(Instance.enemyChieftain.gameObject, 4);
        Instance.poolHeroMageRainDrop = this.CreatePool(Instance.heroMageBlueRainDrop.gameObject, 8);
        Instance.poolWinStars = this.CreatePool(Instance.winStars.gameObject, 3);
        Instance.poolMapNewFlag = this.CreatePool(Instance.mapNewFlag.gameObject, 2);
        Instance.poolElementalDeath = this.CreatePool(Instance.rockElementalDeath.gameObject, 3);
        Instance.poolVeznanAttack = this.CreatePool(Instance.veznanAttack.gameObject, 2);
        Instance.poolVeznanHoldDissipate = this.CreatePool(Instance.veznanHoldDissipate.gameObject, 4);
        Instance.poolVeznanHoldHit = this.CreatePool(Instance.veznanHoldHit.gameObject, 4);
        Instance.poolVeznanPortalIn = this.CreatePool(Instance.veznanPortalIn.gameObject, 4);
        Instance.poolDeathGoblin = this.CreatePool(Instance.deathGoblin.gameObject, 4);
        Instance.poolDeathOrc = this.CreatePool(Instance.deathOrc.gameObject, 3);
        Instance.poolDeathExplosion = this.CreatePool(Instance.deathExplosion.gameObject, 4);
        Instance.poolDeathPuff = this.CreatePool(Instance.deathPuff.gameObject, 4);
        Instance.poolDeathSkeleton = this.CreatePool(Instance.deathSkeleton.gameObject, 4);
        Instance.poolDeathTroll = this.CreatePool(Instance.deathTroll.gameObject, 4);
        Instance.poolDeathBig = this.CreatePool(Instance.deathBig.gameObject, 4);
        Instance.poolHuman1 = this.CreatePool(Instance.deathHuman1.gameObject, 3);
        Instance.poolHuman2 = this.CreatePool(Instance.deathHuman2.gameObject, 3);
        Instance.poolHuman3 = this.CreatePool(Instance.deathHuman3.gameObject, 2);
        Instance.poolHuman4 = this.CreatePool(Instance.deathHuman4.gameObject, 2);
        Instance.poolSheep = this.CreatePool(Instance.sheep.gameObject, 2);
        return;
    }

    public static float GetVolumeFx()
    {
        return Instance.volumeFxPercentage;
    }

    public static float GetVolumeMusic()
    {
        return Instance.volumeMusicPercentage;
    }

    private void Init()
    {
        int num;
        Instance.volumeFxPercentage = 1f;
        Instance.volumeMusicPercentage = 0.7f;
        num = (int) Enum.GetNames(typeof(soundID)).Length;
        Instance.activeSounds = new bool[num];
        Instance.clipArrowRelease1 = Resources.Load("sound & music/_sfx/sfx game/Sound_ArrowRelease2", typeof(AudioClip)) as AudioClip;
        Instance.clipArrowRelease2 = Resources.Load("sound & music/_sfx/sfx game/Sound_ArrowRelease3", typeof(AudioClip)) as AudioClip;
        Instance.clipTowerBuilding = Resources.Load("sound & music/_sfx/sfx game/Sound_TowerBuilding", typeof(AudioClip)) as AudioClip;
        Instance.clipArcherReady = Resources.Load("sound & music/_sfx/sfx voice over/Archer_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipArcherTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Archer_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipArcherTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Archer_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipTowerSell = Resources.Load("sound & music/_sfx/sfx game/Sound_TowerSell", typeof(AudioClip)) as AudioClip;
        Instance.clipRangerReady = Resources.Load("sound & music/_sfx/sfx voice over/Ranger_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipRangerTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Ranger_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipRangerTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Ranger_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipMusketeerReady = Resources.Load("sound & music/_sfx/sfx voice over/Muskateer_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipMusketeerTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Muskateer_Event1", typeof(AudioClip)) as AudioClip;
        Instance.clipMusketeerTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Muskateer_Event2", typeof(AudioClip)) as AudioClip;
        Instance.clipMusketeerSniper = Resources.Load("sound & music/_sfx/sfx voice over/Muskateer_Snipe", typeof(AudioClip)) as AudioClip;
        Instance.clipMageReady = Resources.Load("sound & music/_sfx/sfx voice over/Mage_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipMageTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Mage_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipArcaneReady = Resources.Load("sound & music/_sfx/sfx voice over/Arcane_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipArcaneTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Arcane_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipArcaneTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Arcane_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipSorcererReady = Resources.Load("sound & music/_sfx/sfx voice over/Sorcerer_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipSorcererTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Sorcerer_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipSorcererTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Sorcerer_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipSheep = Resources.Load("sound & music/_sfx/sfx game/Sound_Sheep", typeof(AudioClip)) as AudioClip;
        Instance.clipRockElementalDeath = Resources.Load("sound & music/_sfx/sfx game/Sound_RockElementalDeath", typeof(AudioClip)) as AudioClip;
        Instance.clipRockElementalRally = Resources.Load("sound & music/_sfx/sfx game/Sound_RockElementalRally", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackReady = Resources.Load("sound & music/_sfx/sfx voice over/Barrack_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Barrack_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Barrack_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackMove = Resources.Load("sound & music/_sfx/sfx voice over/Barrack_Move", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackBarbarianReady = Resources.Load("sound & music/_sfx/sfx voice over/Barbarian_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackBarbarianTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Barbarian_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackBarbarianTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Barbarian_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackBarbarianMove = Resources.Load("sound & music/_sfx/sfx voice over/Barbarian_Move", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackPaladinReady = Resources.Load("sound & music/_sfx/sfx voice over/Paladin_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackPaladinTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Paladin_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackPaladinTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Paladin_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipBarrackPaladinMove = Resources.Load("sound & music/_sfx/sfx voice over/Paladin_Move", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryReady = Resources.Load("sound & music/_sfx/sfx voice over/Artillery_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Artillery_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Artillery_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryBfgReady = Resources.Load("sound & music/_sfx/sfx voice over/BFG_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryBfgTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/BFG_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryBfgTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/BFG_Taunt2", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTeslaReady = Resources.Load("sound & music/_sfx/sfx voice over/Tesla_Ready", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTeslaTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Tesla_Taunt1", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTeslaTaunt2A = Resources.Load("sound & music/_sfx/sfx voice over/Tesla_Taunt2a", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTeslaTaunt2B = Resources.Load("sound & music/_sfx/sfx voice over/Tesla_Taunt2b", typeof(AudioClip)) as AudioClip;
        Instance.clipArtilleryTeslaTaunt2C = Resources.Load("sound & music/_sfx/sfx voice over/Tesla_Taunt2c", typeof(AudioClip)) as AudioClip;
        Instance.clipReinforcementTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Reinforcements_Event1", typeof(AudioClip)) as AudioClip;
        Instance.clipReinforcementTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Reinforcements_Event2", typeof(AudioClip)) as AudioClip;
        Instance.clipReinforcementTaunt3 = Resources.Load("sound & music/_sfx/sfx voice over/Reinforcements_Event3", typeof(AudioClip)) as AudioClip;
        Instance.clipReinforcementTaunt4 = Resources.Load("sound & music/_sfx/sfx voice over/Reinforcements_Event4", typeof(AudioClip)) as AudioClip;
        Instance.clipElfTaunt1 = Resources.Load("sound & music/_sfx/sfx voice over/Elf_Taun1", typeof(AudioClip)) as AudioClip;
        Instance.clipElfTaunt2 = Resources.Load("sound & music/_sfx/sfx voice over/Elf_Taun2", typeof(AudioClip)) as AudioClip;
        Instance.clipSasquashRally = Resources.Load("sound & music/_sfx/sfx game/Sound_TowerSoldierSasquashRally", typeof(AudioClip)) as AudioClip;
        Instance.clipSasquashReady = Resources.Load("sound & music/_sfx/sfx game/Sound_TowerSoldierSasquashReady", typeof(AudioClip)) as AudioClip;
        Instance.clipJuggernautDeath = Resources.Load("sound & music/_sfx/sfx game/Sound_JuggernautDeath", typeof(AudioClip)) as AudioClip;
        Instance.clipJTAttack = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyJtAttack", typeof(AudioClip)) as AudioClip;
        Instance.clipJTDeath = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyJtDeath", typeof(AudioClip)) as AudioClip;
        Instance.clipJTEat = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyJtEat", typeof(AudioClip)) as AudioClip;
        Instance.clipJTExplode = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyJtExplode", typeof(AudioClip)) as AudioClip;
        Instance.clipJTRest = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyJtRest", typeof(AudioClip)) as AudioClip;
        Instance.clipJTHitIce1 = Resources.Load("sound & music/_sfx/sfx game/Sound_HitIce1", typeof(AudioClip)) as AudioClip;
        Instance.clipJTHitIce2 = Resources.Load("sound & music/_sfx/sfx game/Sound_HitIce2", typeof(AudioClip)) as AudioClip;
        Instance.clipJTHitIce3 = Resources.Load("sound & music/_sfx/sfx game/Sound_HitIce3", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanAttack = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyVeznan_attack", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanDeath = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyVeznan_death", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanDemonFire = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyVeznan_demonFire", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanHoldCast = Resources.Load("sound & music/_sfx/sfx game/Sound_SpellTowerHold_Cast", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanHoldDissipate = Resources.Load("sound & music/_sfx/sfx game/Sound_SpellTowerHold_Dissipate", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanHoldHit = Resources.Load("sound & music/_sfx/sfx game/Sound_SpellTowerHold_Hit", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanHoldTrap = Resources.Load("sound & music/_sfx/sfx game/Sound_SpellTowerHold_Trap", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanPortalIn = Resources.Load("sound & music/_sfx/sfx game/Sound_DemonPortal_Telein", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanPortalSummon = Resources.Load("sound & music/_sfx/sfx game/Sound_DemonPortal_Summon", typeof(AudioClip)) as AudioClip;
        Instance.clipVeznanToDemon = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyVeznan_toDemon", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathBig = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyBigDead", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathExplosion = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyExplode1", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathGoblin = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyGoblinDead", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathHuman1 = Resources.Load("sound & music/_sfx/sfx game/Sound_HumanDead1", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathHuman2 = Resources.Load("sound & music/_sfx/sfx game/Sound_HumanDead2", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathHuman3 = Resources.Load("sound & music/_sfx/sfx game/Sound_HumanDead3", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathHuman4 = Resources.Load("sound & music/_sfx/sfx game/Sound_HumanDead4", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathOrc = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyOrcDead", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathPuff = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyPuffDead", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathSkeleton = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemySkeletonBreak", typeof(AudioClip)) as AudioClip;
        Instance.clipDeathTroll = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyTrollDead", typeof(AudioClip)) as AudioClip;
        Instance.clipRallyPlaced = Resources.Load("sound & music/_sfx/sfx game/Sound_RallyPointPlaced", typeof(AudioClip)) as AudioClip;
        Instance.clipTowerOpenDoor = Resources.Load("sound & music/_sfx/sfx game/Sound_TowerOpenDoor", typeof(AudioClip)) as AudioClip;
        Instance.clipWaveIncoming = Resources.Load("sound & music/_sfx/sfx game/Sound_WaveIncoming", typeof(AudioClip)) as AudioClip;
        Instance.clipWaveReady = Resources.Load("sound & music/_sfx/sfx game/Sound_NextWaveReady", typeof(AudioClip)) as AudioClip;
        Instance.clipCoins = Resources.Load("sound & music/_sfx/sfx game/Sound_Coins", typeof(AudioClip)) as AudioClip;
        Instance.clipLoseLife = Resources.Load("sound & music/_sfx/sfx game/Sound_LooseLife", typeof(AudioClip)) as AudioClip;
        Instance.clipSpellSelect = Resources.Load("sound & music/_sfx/sfx gui/Sound_SpellSelect", typeof(AudioClip)) as AudioClip;
        Instance.clipSpellRefresh = Resources.Load("sound & music/_sfx/sfx gui/Sound_SpellRefresh", typeof(AudioClip)) as AudioClip;
        Instance.clipWinStars = Resources.Load("sound & music/_sfx/sfx gui/Sound_WinStars", typeof(AudioClip)) as AudioClip;
        Instance.clipQuestCompleted = Resources.Load("sound & music/_sfx/sfx gui/Sound_QuestCompleted", typeof(AudioClip)) as AudioClip;
        Instance.clipQuestFailed = Resources.Load("sound & music/_sfx/sfx gui/Sound_QuestFailed", typeof(AudioClip)) as AudioClip;
        Instance.clipNotificationClose = Resources.Load("sound & music/_sfx/sfx gui/Sound_NotificationClose", typeof(AudioClip)) as AudioClip;
        Instance.clipNotificationOpen = Resources.Load("sound & music/_sfx/sfx gui/Sound_NotificationOpen", typeof(AudioClip)) as AudioClip;
        Instance.clipNotificationPaperOver = Resources.Load("sound & music/_sfx/sfx gui/Sound_NotificationPaperOver", typeof(AudioClip)) as AudioClip;
        Instance.clipNotificationSecondLevel = Resources.Load("sound & music/_sfx/sfx gui/Sound_NotificationSecondLevel", typeof(AudioClip)) as AudioClip;
        Instance.clipButtonCommon = Resources.Load("sound & music/_sfx/sfx gui/Sound_GUIButtonCommon", typeof(AudioClip)) as AudioClip;
        Instance.clipBuyUpgrade = Resources.Load("sound & music/_sfx/sfx gui/Sound_GUIBuyUpgrade", typeof(AudioClip)) as AudioClip;
        Instance.clipBuyAchievementWin = Resources.Load("sound & music/_sfx/sfx gui/Sound_AchievementWin", typeof(AudioClip)) as AudioClip;
        Instance.clipQuickmenuOpen = Resources.Load("sound & music/_sfx/sfx gui/Sound_GUIOpenTowerMenu", typeof(AudioClip)) as AudioClip;
        Instance.clipQuickmenuOver = Resources.Load("sound & music/_sfx/sfx gui/Sound_GUIMouseOverTowerIcon", typeof(AudioClip)) as AudioClip;
        Instance.clipMapNewFlag = Resources.Load("sound & music/_sfx/sfx game/Sound_MapNewFlag", typeof(AudioClip)) as AudioClip;
        Instance.clipMapNewRoad = Resources.Load("sound & music/_sfx/sfx game/Sound_MapRoad", typeof(AudioClip)) as AudioClip;
        Instance.clipTransitionOpen = Resources.Load("sound & music/_sfx/sfx gui/GUITransitionOpen", typeof(AudioClip)) as AudioClip;
        Instance.clipTransitionClose = Resources.Load("sound & music/_sfx/sfx gui/GUITransitionClose", typeof(AudioClip)) as AudioClip;
        Instance.clipMageBolt = Resources.Load("sound & music/_sfx/sfx game/Sound_MageShot", typeof(AudioClip)) as AudioClip;
        Instance.clipBombExplosion = Resources.Load("sound & music/_sfx/sfx game/Sound_Bomb1", typeof(AudioClip)) as AudioClip;
        Instance.clipBombShoot = Resources.Load("sound & music/_sfx/sfx game/Sound_EngineerShot", typeof(AudioClip)) as AudioClip;
        Instance.clipArrowHit1 = Resources.Load("sound & music/_sfx/sfx game/Sound_ArrowHit2", typeof(AudioClip)) as AudioClip;
        Instance.clipArrowHit2 = Resources.Load("sound & music/_sfx/sfx game/Sound_ArrowHit3", typeof(AudioClip)) as AudioClip;
        Instance.clipShotgun = Resources.Load("sound & music/_sfx/sfx game/Sound_Shootgun", typeof(AudioClip)) as AudioClip;
        Instance.clipShrapnel = Resources.Load("sound & music/_sfx/sfx game/Sound_Shrapnel", typeof(AudioClip)) as AudioClip;
        Instance.clipSniper = Resources.Load("sound & music/_sfx/sfx game/Sound_Sniper", typeof(AudioClip)) as AudioClip;
        Instance.clipFireballRelease = Resources.Load("sound & music/_sfx/sfx game/Sound_FireballUnleash", typeof(AudioClip)) as AudioClip;
        Instance.clipFireballHit = Resources.Load("sound & music/_sfx/sfx game/Sound_FireballHit", typeof(AudioClip)) as AudioClip;
        Instance.clipMeleeSword = Resources.Load("sound & music/_sfx/sfx game/Sound_SoldiersFighting", typeof(AudioClip)) as AudioClip;
        Instance.clipSorcererBolt = Resources.Load("sound & music/_sfx/sfx game/Sound_Sorcerer", typeof(AudioClip)) as AudioClip;
        Instance.clipPolymorph = Resources.Load("sound & music/_sfx/sfx game/Sound_Polimorph", typeof(AudioClip)) as AudioClip;
        Instance.clipDesintegrate = Resources.Load("sound & music/_sfx/sfx game/Sound_ArcaneDesintegrate", typeof(AudioClip)) as AudioClip;
        Instance.clipTeleport = Resources.Load("sound & music/_sfx/sfx game/Sound_Teleport", typeof(AudioClip)) as AudioClip;
        Instance.clipThorn = Resources.Load("sound & music/_sfx/sfx game/Sound_Thorn", typeof(AudioClip)) as AudioClip;
        Instance.clipHealing = Resources.Load("sound & music/_sfx/sfx game/Sound_PaladinHeal", typeof(AudioClip)) as AudioClip;
        Instance.clipAxe = Resources.Load("sound & music/_sfx/sfx game/Sound_BattleAxe", typeof(AudioClip)) as AudioClip;
        Instance.clipRocketLaunch = Resources.Load("sound & music/_sfx/sfx game/Sound_RocketLaunt", typeof(AudioClip)) as AudioClip;
        Instance.clipRayArcane = Resources.Load("sound & music/_sfx/sfx game/Sound_RayArcane", typeof(AudioClip)) as AudioClip;
        Instance.clipTeslaAttack1 = Resources.Load("sound & music/_sfx/sfx game/Sound_Tesla_attack_1", typeof(AudioClip)) as AudioClip;
        Instance.clipTeslaAttack2 = Resources.Load("sound & music/_sfx/sfx game/Sound_Tesla_attack_2", typeof(AudioClip)) as AudioClip;
        Instance.clipCommonAreaAttack = Resources.Load("sound & music/_sfx/sfx game/Sound_CommonAreaHit", typeof(AudioClip)) as AudioClip;
        Instance.clipSpiderAttack1 = Resources.Load("sound & music/_sfx/sfx game/Sound_SpiderAttack", typeof(AudioClip)) as AudioClip;
        Instance.clipSpiderAttack2 = Resources.Load("sound & music/_sfx/sfx game/Sound_SpiderAttack2", typeof(AudioClip)) as AudioClip;
        Instance.clipWolfAttack1 = Resources.Load("sound & music/_sfx/sfx game/Sound_WolfAttack", typeof(AudioClip)) as AudioClip;
        Instance.clipWolfAttack2 = Resources.Load("sound & music/_sfx/sfx game/Sound_WolfAttack2", typeof(AudioClip)) as AudioClip;
        Instance.clipEnemyHealing = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyHealing", typeof(AudioClip)) as AudioClip;
        Instance.clipEnemyRocketeer = Resources.Load("sound & music/_sfx/sfx game/Sound_EnemyRocketeer", typeof(AudioClip)) as AudioClip;
        Instance.clipEnemyChieftain = Resources.Load("sound & music/_sfx/sfx game/Sound_Chieftain", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroLevelUp = Resources.Load("sound & music/_sfx/sfx hero/Level_up", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Holy-Paladin-01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Holy-Paladin-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Holy-Paladin-03b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Holy-Paladin-04a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinDeflect = Resources.Load("sound & music/_sfx/sfx hero/Paladin_deflect", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinShieldBuff = Resources.Load("sound & music/_sfx/sfx hero/Paladin_shield_buff", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroPaladinDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Holy-Paladin-Death_b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Young-Mage-01d", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Young-Mage-02a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Young-Mage-03c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Young-Mage-04c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Young-Mage-Death_c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageBlueRainCharge = Resources.Load("sound & music/_sfx/sfx hero/Mage_blue_rain_charge", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageBlueRainDrop = Resources.Load("sound & music/_sfx/sfx hero/Mage_blue_rain_drop", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroMageShadows = Resources.Load("sound & music/_sfx/sfx hero/Mage_shadows", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenArrow = Resources.Load("sound & music/_sfx/sfx hero/Aleria_special_arrow", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Female-Elven-Archer-Death_a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Female-Elven-Archer-01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Female-Elven-Archer-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Female-Elven-Archer-03a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Female-Elven-Archer-04b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenWildCatHit = Resources.Load("sound & music/_sfx/sfx hero/Aleria_wildcat_hit", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroElvenWildCatSummon = Resources.Load("sound & music/_sfx/sfx hero/Aleria_sumon", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementChargeSpecial = Resources.Load("sound & music/_sfx/sfx hero/Motumbo_charge_special", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Reinforcement-Death_c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementHit = Resources.Load("sound & music/_sfx/sfx hero/Motumbo_hit", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementJumpSpecial = Resources.Load("sound & music/_sfx/sfx hero/Motumbo_jump_special", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Reinforcement-01a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Reinforcement-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Reinforcement-03c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroReinforcementTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Reinforcement-04b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfBreaHit = Resources.Load("sound & music/_sfx/sfx hero/Dwarf_brea_shot_hit", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfBreaShoot = Resources.Load("sound & music/_sfx/sfx hero/Dwarf_brea_shot2", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfMine = Resources.Load("sound & music/_sfx/sfx hero/Dwarf_mine", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Dwarf-Rifleman-Death_c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Dwarf-Rifleman-01a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Dwarf-Rifleman-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Dwarf-Rifleman-03c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroDwarfTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Dwarf-Rifleman-04c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingAttack = Resources.Load("sound & music/_sfx/sfx hero/KingDenas_sfx_attack", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingBuff1 = Resources.Load("sound & music/_sfx/sfx hero/KingDenas_sfx_order1", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingBuff2 = Resources.Load("sound & music/_sfx/sfx hero/KingDenas_sfx_order3", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/KingDenas-01d", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/KingDenas-02d", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/KingDenas-03g", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/KingDenas-04e", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroKingDeath = Resources.Load("sound & music/_sfx/sfx hero voice/KingDenas-05c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Elemental-Death_c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireSpecialArea = Resources.Load("sound & music/_sfx/sfx hero/Cinder_special_area", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireSpecialFireballEnd = Resources.Load("sound & music/_sfx/sfx hero/Cinder_special_fireball_2_end", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireSpecialFireballStart = Resources.Load("sound & music/_sfx/sfx hero/Cinder_special_fireball_1_start", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Elemental-01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Elemental-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Elemental-03b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFireTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Elemental-04c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Viking-01b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Viking-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Viking-03b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Viking-01b", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Viking-Death_01d", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingHit = Resources.Load("sound & music/_sfx/sfx hero/Viking_Hit", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingBearStartAttack = Resources.Load("sound & music/_sfx/sfx hero/Viking_StartAttack", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingTransform = Resources.Load("sound & music/_sfx/sfx hero/Viking_Transform", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroVikingCall = Resources.Load("sound & music/_sfx/sfx hero/Viking_Call", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostTaunt1 = Resources.Load("sound & music/_sfx/sfx hero voice/Frost-Mage-01a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostTaunt2 = Resources.Load("sound & music/_sfx/sfx hero voice/Frost-Mage-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostTaunt3 = Resources.Load("sound & music/_sfx/sfx hero voice/Frost-Mage-03d", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostTaunt4 = Resources.Load("sound & music/_sfx/sfx hero voice/Frost-Mage-04a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostDeath = Resources.Load("sound & music/_sfx/sfx hero voice/Frost-Mage-Death_01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostGroundFreeze = Resources.Load("sound & music/_sfx/sfx hero/Elora_GroundFreeze", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostIceRainBreak = Resources.Load("sound & music/_sfx/sfx hero/Elora_IceShardBreak", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostIceRainDrop = Resources.Load("sound & music/_sfx/sfx hero/Elora_IceShard", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroFrostIceRainSummon = Resources.Load("sound & music/_sfx/sfx hero/Elora_IceShardSummon", typeof(AudioClip)) as AudioClip;
        Instance.clipTowerUpgrade = Resources.Load("sound & music/_sfx/sfx game/Sound_TowerUpgrade", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorTaunt1 = Resources.Load("sound & music/_sfx/update newYear/Thor_01a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorTaunt2 = Resources.Load("sound & music/_sfx/update newYear/Thor_02a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorTaunt3 = Resources.Load("sound & music/_sfx/update newYear/Thor_03c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorTaunt4 = Resources.Load("sound & music/_sfx/update newYear/Thor_04c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorDeath = Resources.Load("sound & music/_sfx/update newYear/Thor_05c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorHammer = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_thor_lanzamartillo_op2", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorElectricAttack = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_thor_ataqueelectrico", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorElectricalDeath = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_thor_muerte", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroThorThunder = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_thor_thunder", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiTaunt1 = Resources.Load("sound & music/_sfx/update inferno/Oni-01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiTaunt2 = Resources.Load("sound & music/_sfx/update inferno/Oni-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiTaunt3 = Resources.Load("sound & music/_sfx/update inferno/Oni-03c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiTaunt4 = Resources.Load("sound & music/_sfx/update inferno/Oni-04a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiDeath = Resources.Load("sound & music/_sfx/update inferno/Oni-Death01a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiGroundSawblades = Resources.Load("sound & music/_sfx/update inferno/inferno_oni_groundSwords", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroSamuraiDeathStrike = Resources.Load("sound & music/_sfx/update inferno/inferno_oni_instakill", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotTaunt1 = Resources.Load("sound & music/_sfx/update inferno/Hacksaw-01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotTaunt2 = Resources.Load("sound & music/_sfx/update inferno/Hacksaw-02c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotTaunt3 = Resources.Load("sound & music/_sfx/update inferno/Hacksaw-03a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotTaunt4 = Resources.Load("sound & music/_sfx/update inferno/Hacksaw-04a", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotDeath = Resources.Load("sound & music/_sfx/update inferno/Hacksaw-Death01c", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotDrill = Resources.Load("sound & music/_sfx/update inferno/inferno_lumberjack_drill", typeof(AudioClip)) as AudioClip;
        Instance.clipHeroRobotShoot = Resources.Load("sound & music/_sfx/update inferno/inferno_lumberjack_shootSaw", typeof(AudioClip)) as AudioClip;
        Instance.clipMushroomBossGas = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_mushroomboss_gas_op1", typeof(AudioClip)) as AudioClip;
        Instance.clipMushroomBossDeath = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_mushroomboss_muerte", typeof(AudioClip)) as AudioClip;
        Instance.clipMushroomCreepDeath = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_mushroomcreep_muerte_edit_vanzen", typeof(AudioClip)) as AudioClip;
        Instance.clipMushroomCreepNacimiento = Resources.Load("sound & music/_sfx/update newYear/KR_sfx_mushroomcreep_nacimiento", typeof(AudioClip)) as AudioClip;
        Instance.clipInfernoBossHorns = Resources.Load("sound & music/_sfx/update inferno/inferno_boss_horns", typeof(AudioClip)) as AudioClip;
        Instance.clipInfernoBossStomp = Resources.Load("sound & music/_sfx/update inferno/inferno_boss_stomp", typeof(AudioClip)) as AudioClip;
        Instance.clipInfernoBossDeath = Resources.Load("sound & music/_sfx/update inferno/inferno_boss_death", typeof(AudioClip)) as AudioClip;
        Instance.mageBolt = this.CreateAudioSource(Instance.clipMageBolt, 0);
        Instance.bombExplosion = this.CreateAudioSource(Instance.clipBombExplosion, 0);
        Instance.bombShoot = this.CreateAudioSource(Instance.clipBombShoot, 0);
        Instance.shotgun = this.CreateAudioSource(Instance.clipShotgun, 0);
        Instance.shrapnel = this.CreateAudioSource(Instance.clipShrapnel, 0);
        Instance.sniper = this.CreateAudioSource(Instance.clipSniper, 0);
        Instance.fireballRelease = this.CreateAudioSource(Instance.clipFireballRelease, 0);
        Instance.fireballHit = this.CreateAudioSource(Instance.clipFireballHit, 0);
        Instance.meleeSword = this.CreateAudioSource(Instance.clipMeleeSword, 1);
        Instance.sorcererBolt = this.CreateAudioSource(Instance.clipSorcererBolt, 0);
        Instance.polymorph = this.CreateAudioSource(Instance.clipPolymorph, 0);
        Instance.desintegrate = this.CreateAudioSource(Instance.clipDesintegrate, 0);
        Instance.teleport = this.CreateAudioSource(Instance.clipTeleport, 0);
        Instance.thorn = this.CreateAudioSource(Instance.clipThorn, 0);
        Instance.healing = this.CreateAudioSource(Instance.clipHealing, 0);
        Instance.axe = this.CreateAudioSource(Instance.clipAxe, 0);
        Instance.rocketLaunch = this.CreateAudioSource(Instance.clipRocketLaunch, 0);
        Instance.rayArcane = this.CreateAudioSource(Instance.clipRayArcane, 0);
        Instance.teslaAttack1 = this.CreateAudioSource(Instance.clipTeslaAttack1, 0);
        Instance.teslaAttack2 = this.CreateAudioSource(Instance.clipTeslaAttack2, 0);
        Instance.commonAreaAttack = this.CreateAudioSource(Instance.clipCommonAreaAttack, 0);
        Instance.spiderAttack1 = this.CreateAudioSource(Instance.clipSpiderAttack1, 0);
        Instance.spiderAttack2 = this.CreateAudioSource(Instance.clipSpiderAttack2, 0);
        Instance.wolfAttack1 = this.CreateAudioSource(Instance.clipWolfAttack1, 0);
        Instance.wolfAttack2 = this.CreateAudioSource(Instance.clipWolfAttack2, 0);
        Instance.enemyHealing = this.CreateAudioSource(Instance.clipEnemyHealing, 0);
        Instance.enemyRocketeer = this.CreateAudioSource(Instance.clipEnemyRocketeer, 0);
        Instance.enemyChieftain = this.CreateAudioSource(Instance.clipEnemyChieftain, 0);
        Instance.arrowRelease1 = this.CreateAudioSource(Instance.clipArrowRelease1, 0);
        Instance.arrowRelease2 = this.CreateAudioSource(Instance.clipArrowRelease2, 0);
        Instance.towerBuilding = this.CreateAudioSource(Instance.clipTowerBuilding, 0);
        Instance.towerSell = this.CreateAudioSource(Instance.clipTowerSell, 0);
        Instance.archerReady = this.CreateAudioSource(Instance.clipArcherReady, 0);
        Instance.archerTaunt1 = this.CreateAudioSource(Instance.clipArcherTaunt1, 0);
        Instance.archerTaunt2 = this.CreateAudioSource(Instance.clipArcherTaunt2, 0);
        Instance.rangerReady = this.CreateAudioSource(Instance.clipRangerReady, 0);
        Instance.rangerTaunt1 = this.CreateAudioSource(Instance.clipRangerTaunt1, 0);
        Instance.rangerTaunt2 = this.CreateAudioSource(Instance.clipRangerTaunt2, 0);
        Instance.musketeerReady = this.CreateAudioSource(Instance.clipMusketeerReady, 0);
        Instance.musketeerTaunt1 = this.CreateAudioSource(Instance.clipMusketeerTaunt1, 0);
        Instance.musketeerTaunt2 = this.CreateAudioSource(Instance.clipMusketeerTaunt2, 0);
        Instance.musketeerSniper = this.CreateAudioSource(Instance.clipMusketeerSniper, 0);
        Instance.mageReady = this.CreateAudioSource(Instance.clipMageReady, 0);
        Instance.mageTaunt1 = this.CreateAudioSource(Instance.clipMageTaunt1, 0);
        Instance.arcaneReady = this.CreateAudioSource(Instance.clipArcaneReady, 0);
        Instance.arcaneTaunt1 = this.CreateAudioSource(Instance.clipArcaneTaunt1, 0);
        Instance.arcaneTaunt2 = this.CreateAudioSource(Instance.clipArcaneTaunt2, 0);
        Instance.sorcererReady = this.CreateAudioSource(Instance.clipSorcererReady, 0);
        Instance.sorcererTaunt1 = this.CreateAudioSource(Instance.clipSorcererTaunt1, 0);
        Instance.sorcererTaunt2 = this.CreateAudioSource(Instance.clipSorcererTaunt2, 0);
        Instance.sheep = this.CreateAudioSource(Instance.clipSheep, 0);
        Instance.rockElementalDeath = this.CreateAudioSource(Instance.clipRockElementalDeath, 0);
        Instance.rockElementalRally = this.CreateAudioSource(Instance.clipRockElementalRally, 0);
        Instance.barrackReady = this.CreateAudioSource(Instance.clipBarrackReady, 0);
        Instance.barrackTaunt1 = this.CreateAudioSource(Instance.clipBarrackTaunt1, 0);
        Instance.barrackTaunt2 = this.CreateAudioSource(Instance.clipBarrackTaunt2, 0);
        Instance.barrackMove = this.CreateAudioSource(Instance.clipBarrackMove, 0);
        Instance.barrackPaladinReady = this.CreateAudioSource(Instance.clipBarrackPaladinReady, 0);
        Instance.barrackPaladinTaunt1 = this.CreateAudioSource(Instance.clipBarrackPaladinTaunt1, 0);
        Instance.barrackPaladinTaunt2 = this.CreateAudioSource(Instance.clipBarrackPaladinTaunt2, 0);
        Instance.barrackPaladinMove = this.CreateAudioSource(Instance.clipBarrackPaladinMove, 0);
        Instance.barrackBarbarianReady = this.CreateAudioSource(Instance.clipBarrackBarbarianReady, 0);
        Instance.barrackBarbarianTaunt1 = this.CreateAudioSource(Instance.clipBarrackBarbarianTaunt1, 0);
        Instance.barrackBarbarianTaunt2 = this.CreateAudioSource(Instance.clipBarrackBarbarianTaunt2, 0);
        Instance.barrackBarbarianMove = this.CreateAudioSource(Instance.clipBarrackBarbarianMove, 0);
        Instance.artilleryReady = this.CreateAudioSource(Instance.clipArtilleryReady, 0);
        Instance.artilleryTaunt1 = this.CreateAudioSource(Instance.clipArtilleryTaunt1, 0);
        Instance.artilleryTaunt2 = this.CreateAudioSource(Instance.clipArtilleryTaunt2, 0);
        Instance.artilleryBfgReady = this.CreateAudioSource(Instance.clipArtilleryBfgReady, 0);
        Instance.artilleryBfgTaunt1 = this.CreateAudioSource(Instance.clipArtilleryBfgTaunt1, 0);
        Instance.artilleryBfgTaunt2 = this.CreateAudioSource(Instance.clipArtilleryBfgTaunt2, 0);
        Instance.artilleryTeslaReady = this.CreateAudioSource(Instance.clipArtilleryTeslaReady, 0);
        Instance.artilleryTeslaTaunt1 = this.CreateAudioSource(Instance.clipArtilleryTeslaTaunt1, 0);
        Instance.artilleryTeslaTaunt2A = this.CreateAudioSource(Instance.clipArtilleryTeslaTaunt2A, 0);
        Instance.artilleryTeslaTaunt2B = this.CreateAudioSource(Instance.clipArtilleryTeslaTaunt2B, 0);
        Instance.artilleryTeslaTaunt2C = this.CreateAudioSource(Instance.clipArtilleryTeslaTaunt2C, 0);
        Instance.reinforcementTaunt1 = this.CreateAudioSource(Instance.clipReinforcementTaunt1, 0);
        Instance.reinforcementTaunt2 = this.CreateAudioSource(Instance.clipReinforcementTaunt2, 0);
        Instance.reinforcementTaunt3 = this.CreateAudioSource(Instance.clipReinforcementTaunt3, 0);
        Instance.reinforcementTaunt4 = this.CreateAudioSource(Instance.clipReinforcementTaunt4, 0);
        Instance.elfTaunt1 = this.CreateAudioSource(Instance.clipElfTaunt1, 0);
        Instance.elfTaunt2 = this.CreateAudioSource(Instance.clipElfTaunt2, 0);
        Instance.sasquashRally = this.CreateAudioSource(Instance.clipSasquashRally, 0);
        Instance.sasquashReady = this.CreateAudioSource(Instance.clipSasquashReady, 0);
        Instance.juggernautDeath = this.CreateAudioSource(Instance.clipJuggernautDeath, 0);
        Instance.jtAttack = this.CreateAudioSource(Instance.clipJTAttack, 0);
        Instance.jtDeath = this.CreateAudioSource(Instance.clipJTDeath, 0);
        Instance.jtEat = this.CreateAudioSource(Instance.clipJTEat, 0);
        Instance.jtExplode = this.CreateAudioSource(Instance.clipJTExplode, 0);
        Instance.jtHitIce1 = this.CreateAudioSource(Instance.clipJTHitIce1, 0);
        Instance.jtHitIce2 = this.CreateAudioSource(Instance.clipJTHitIce2, 0);
        Instance.jtHitIce3 = this.CreateAudioSource(Instance.clipJTHitIce3, 0);
        Instance.jtRest = this.CreateAudioSource(Instance.clipJTRest, 0);
        Instance.veznanAttack = this.CreateAudioSource(Instance.clipVeznanAttack, 0);
        Instance.veznanDeath = this.CreateAudioSource(Instance.clipVeznanDeath, 0);
        Instance.veznanDemonFire = this.CreateAudioSource(Instance.clipVeznanDemonFire, 0);
        Instance.veznanHoldCast = this.CreateAudioSource(Instance.clipVeznanHoldCast, 0);
        Instance.veznanHoldDissipate = this.CreateAudioSource(Instance.clipVeznanHoldDissipate, 0);
        Instance.veznanHoldHit = this.CreateAudioSource(Instance.clipVeznanHoldHit, 0);
        Instance.veznanHoldTrap = this.CreateAudioSource(Instance.clipVeznanHoldTrap, 0);
        Instance.veznanPortalIn = this.CreateAudioSource(Instance.clipVeznanPortalIn, 0);
        Instance.veznanPortalSummon = this.CreateAudioSource(Instance.clipVeznanPortalSummon, 0);
        Instance.veznanToDemon = this.CreateAudioSource(Instance.clipVeznanToDemon, 0);
        Instance.deathBig = this.CreateAudioSource(Instance.clipDeathBig, 0);
        Instance.deathExplosion = this.CreateAudioSource(Instance.clipDeathExplosion, 0);
        Instance.deathGoblin = this.CreateAudioSource(Instance.clipDeathGoblin, 0);
        Instance.deathHuman1 = this.CreateAudioSource(Instance.clipDeathHuman1, 0);
        Instance.deathHuman2 = this.CreateAudioSource(Instance.clipDeathHuman2, 0);
        Instance.deathHuman3 = this.CreateAudioSource(Instance.clipDeathHuman3, 0);
        Instance.deathHuman4 = this.CreateAudioSource(Instance.clipDeathHuman4, 0);
        Instance.deathOrc = this.CreateAudioSource(Instance.clipDeathOrc, 0);
        Instance.deathPuff = this.CreateAudioSource(Instance.clipDeathPuff, 0);
        Instance.deathSkeleton = this.CreateAudioSource(Instance.clipDeathSkeleton, 0);
        Instance.deathTroll = this.CreateAudioSource(Instance.clipDeathTroll, 0);
        Instance.rallyPlaced = this.CreateAudioSource(Instance.clipRallyPlaced, 0);
        Instance.towerOpenDoor = this.CreateAudioSource(Instance.clipTowerOpenDoor, 0);
        Instance.waveIncoming = this.CreateAudioSource(Instance.clipWaveIncoming, 0);
        Instance.waveReady = this.CreateAudioSource(Instance.clipWaveReady, 0);
        Instance.coins = this.CreateAudioSource(Instance.clipCoins, 0);
        Instance.loseLife = this.CreateAudioSource(Instance.clipLoseLife, 0);
        Instance.spellSelect = this.CreateAudioSource(Instance.clipSpellSelect, 0);
        Instance.spellRefresh = this.CreateAudioSource(Instance.clipSpellRefresh, 0);
        Instance.winStars = this.CreateAudioSource(Instance.clipWinStars, 0);
        Instance.questCompleted = this.CreateAudioSource(Instance.clipQuestCompleted, 0);
        Instance.questFailed = this.CreateAudioSource(Instance.clipQuestFailed, 0);
        Instance.notificationClose = this.CreateAudioSource(Instance.clipNotificationClose, 0);
        Instance.notificationOpen = this.CreateAudioSource(Instance.clipNotificationOpen, 0);
        Instance.notificationPaperOver = this.CreateAudioSource(Instance.clipNotificationPaperOver, 0);
        Instance.notificationSecondLevel = this.CreateAudioSource(Instance.clipNotificationSecondLevel, 0);
        Instance.buttonCommon = this.CreateAudioSource(Instance.clipButtonCommon, 0);
        Instance.buyUpgrade = this.CreateAudioSource(Instance.clipBuyUpgrade, 0);
        Instance.buyAchievementWin = this.CreateAudioSource(Instance.clipBuyAchievementWin, 0);
        Instance.quickmenuOpen = this.CreateAudioSource(Instance.clipQuickmenuOpen, 0);
        Instance.quickmenuOver = this.CreateAudioSource(Instance.clipQuickmenuOver, 0);
        Instance.mapNewFlag = this.CreateAudioSource(Instance.clipMapNewFlag, 0);
        Instance.mapNewRoad = this.CreateAudioSource(Instance.clipMapNewRoad, 0);
        Instance.transitionOpen = this.CreateAudioSource(Instance.clipTransitionOpen, 0);
        Instance.transitionClose = this.CreateAudioSource(Instance.clipTransitionClose, 0);
        Instance.arrowHit1 = this.CreateAudioSource(Instance.clipArrowHit1, 0);
        Instance.arrowHit2 = this.CreateAudioSource(Instance.clipArrowHit2, 0);
        Instance.towerUpgrade = this.CreateAudioSource(Instance.clipTowerUpgrade, 0);
        Instance.heroLevelUp = this.CreateAudioSource(Instance.clipHeroLevelUp, 0);
        Instance.heroPaladinTaunt1 = this.CreateAudioSource(Instance.clipHeroPaladinTaunt1, 0);
        Instance.heroPaladinTaunt2 = this.CreateAudioSource(Instance.clipHeroPaladinTaunt2, 0);
        Instance.heroPaladinTaunt3 = this.CreateAudioSource(Instance.clipHeroPaladinTaunt3, 0);
        Instance.heroPaladinTaunt4 = this.CreateAudioSource(Instance.clipHeroPaladinTaunt4, 0);
        Instance.heroPaladinDeflect = this.CreateAudioSource(Instance.clipHeroPaladinDeflect, 0);
        Instance.heroPaladinShieldBuff = this.CreateAudioSource(Instance.clipHeroPaladinShieldBuff, 0);
        Instance.heroPaladinDeath = this.CreateAudioSource(Instance.clipHeroPaladinDeath, 0);
        Instance.heroMageBlueRainCharge = this.CreateAudioSource(Instance.clipHeroMageBlueRainCharge, 0);
        Instance.heroMageBlueRainDrop = this.CreateAudioSource(Instance.clipHeroMageBlueRainDrop, 0);
        Instance.heroMageDeath = this.CreateAudioSource(Instance.clipHeroMageDeath, 0);
        Instance.heroMageShadows = this.CreateAudioSource(Instance.clipHeroMageShadows, 0);
        Instance.heroMageTaunt1 = this.CreateAudioSource(Instance.clipHeroMageTaunt1, 0);
        Instance.heroMageTaunt2 = this.CreateAudioSource(Instance.clipHeroMageTaunt2, 0);
        Instance.heroMageTaunt3 = this.CreateAudioSource(Instance.clipHeroMageTaunt3, 0);
        Instance.heroMageTaunt4 = this.CreateAudioSource(Instance.clipHeroMageTaunt4, 0);
        Instance.heroElvenArrow = this.CreateAudioSource(Instance.clipHeroElvenArrow, 0);
        Instance.heroElvenDeath = this.CreateAudioSource(Instance.clipHeroElvenDeath, 0);
        Instance.heroElvenTaunt1 = this.CreateAudioSource(Instance.clipHeroElvenTaunt1, 0);
        Instance.heroElvenTaunt2 = this.CreateAudioSource(Instance.clipHeroElvenTaunt2, 0);
        Instance.heroElvenTaunt3 = this.CreateAudioSource(Instance.clipHeroElvenTaunt3, 0);
        Instance.heroElvenTaunt4 = this.CreateAudioSource(Instance.clipHeroElvenTaunt4, 0);
        Instance.heroElvenWildCatHit = this.CreateAudioSource(Instance.clipHeroElvenWildCatHit, 0);
        Instance.heroElvenWildCatSummon = this.CreateAudioSource(Instance.clipHeroElvenWildCatSummon, 0);
        Instance.heroReinforcementChargeSpecial = this.CreateAudioSource(Instance.clipHeroReinforcementChargeSpecial, 0);
        Instance.heroReinforcementDeath = this.CreateAudioSource(Instance.clipHeroReinforcementDeath, 0);
        Instance.heroReinforcementHit = this.CreateAudioSource(Instance.clipHeroReinforcementHit, 0);
        Instance.heroReinforcementJumpSpecial = this.CreateAudioSource(Instance.clipHeroReinforcementJumpSpecial, 0);
        Instance.heroReinforcementTaunt1 = this.CreateAudioSource(Instance.clipHeroReinforcementTaunt1, 0);
        Instance.heroReinforcementTaunt2 = this.CreateAudioSource(Instance.clipHeroReinforcementTaunt2, 0);
        Instance.heroReinforcementTaunt3 = this.CreateAudioSource(Instance.clipHeroReinforcementTaunt3, 0);
        Instance.heroReinforcementTaunt4 = this.CreateAudioSource(Instance.clipHeroReinforcementTaunt4, 0);
        Instance.heroDwarfBreaHit = this.CreateAudioSource(Instance.clipHeroDwarfBreaHit, 0);
        Instance.heroDwarfBreaShoot = this.CreateAudioSource(Instance.clipHeroDwarfBreaShoot, 0);
        Instance.heroDwarfDeath = this.CreateAudioSource(Instance.clipHeroDwarfDeath, 0);
        Instance.heroDwarfMine = this.CreateAudioSource(Instance.clipHeroDwarfMine, 0);
        Instance.heroDwarfTaunt1 = this.CreateAudioSource(Instance.clipHeroDwarfTaunt1, 0);
        Instance.heroDwarfTaunt2 = this.CreateAudioSource(Instance.clipHeroDwarfTaunt2, 0);
        Instance.heroDwarfTaunt3 = this.CreateAudioSource(Instance.clipHeroDwarfTaunt3, 0);
        Instance.heroDwarfTaunt4 = this.CreateAudioSource(Instance.clipHeroDwarfTaunt4, 0);
        Instance.heroKingAttack = this.CreateAudioSource(Instance.clipHeroKingAttack, 0);
        Instance.heroKingBuff1 = this.CreateAudioSource(Instance.clipHeroKingBuff1, 0);
        Instance.heroKingBuff2 = this.CreateAudioSource(Instance.clipHeroKingBuff2, 0);
        Instance.heroKingDeath = this.CreateAudioSource(Instance.clipHeroKingDeath, 0);
        Instance.heroKingTaunt1 = this.CreateAudioSource(Instance.clipHeroKingTaunt1, 0);
        Instance.heroKingTaunt2 = this.CreateAudioSource(Instance.clipHeroKingTaunt2, 0);
        Instance.heroKingTaunt3 = this.CreateAudioSource(Instance.clipHeroKingTaunt3, 0);
        Instance.heroKingTaunt4 = this.CreateAudioSource(Instance.clipHeroKingTaunt4, 0);
        Instance.heroFireDeath = this.CreateAudioSource(Instance.clipHeroFireDeath, 0);
        Instance.heroFireSpecialArea = this.CreateAudioSource(Instance.clipHeroFireSpecialArea, 0);
        Instance.heroFireSpecialFireballEnd = this.CreateAudioSource(Instance.clipHeroFireSpecialFireballEnd, 0);
        Instance.heroFireSpecialFireballStart = this.CreateAudioSource(Instance.clipHeroFireSpecialFireballStart, 0);
        Instance.heroFireTaunt1 = this.CreateAudioSource(Instance.clipHeroFireTaunt1, 0);
        Instance.heroFireTaunt2 = this.CreateAudioSource(Instance.clipHeroFireTaunt2, 0);
        Instance.heroFireTaunt3 = this.CreateAudioSource(Instance.clipHeroFireTaunt3, 0);
        Instance.heroFireTaunt4 = this.CreateAudioSource(Instance.clipHeroFireTaunt4, 0);
        Instance.heroVikingTaunt1 = this.CreateAudioSource(Instance.clipHeroVikingTaunt1, 0);
        Instance.heroVikingTaunt2 = this.CreateAudioSource(Instance.clipHeroVikingTaunt2, 0);
        Instance.heroVikingTaunt3 = this.CreateAudioSource(Instance.clipHeroVikingTaunt3, 0);
        Instance.heroVikingTaunt4 = this.CreateAudioSource(Instance.clipHeroVikingTaunt4, 0);
        Instance.heroVikingBearStartAttack = this.CreateAudioSource(Instance.clipHeroVikingBearStartAttack, 0);
        Instance.heroVikingCall = this.CreateAudioSource(Instance.clipHeroVikingCall, 0);
        Instance.heroVikingDeath = this.CreateAudioSource(Instance.clipHeroVikingDeath, 0);
        Instance.heroVikingHit = this.CreateAudioSource(Instance.clipHeroVikingHit, 0);
        Instance.heroVikingTransform = this.CreateAudioSource(Instance.clipHeroVikingTransform, 0);
        Instance.heroFrostDeath = this.CreateAudioSource(Instance.clipHeroFrostDeath, 0);
        Instance.heroFrostGroundFreeze = this.CreateAudioSource(Instance.clipHeroFrostGroundFreeze, 0);
        Instance.heroFrostIceRainBreak = this.CreateAudioSource(Instance.clipHeroFrostIceRainBreak, 0);
        Instance.heroFrostIceRainDrop = this.CreateAudioSource(Instance.clipHeroFrostIceRainDrop, 0);
        Instance.heroFrostIceRainSummon = this.CreateAudioSource(Instance.clipHeroFrostIceRainSummon, 0);
        Instance.heroFrostTaunt1 = this.CreateAudioSource(Instance.clipHeroFrostTaunt1, 0);
        Instance.heroFrostTaunt2 = this.CreateAudioSource(Instance.clipHeroFrostTaunt2, 0);
        Instance.heroFrostTaunt3 = this.CreateAudioSource(Instance.clipHeroFrostTaunt3, 0);
        Instance.heroFrostTaunt4 = this.CreateAudioSource(Instance.clipHeroFrostTaunt4, 0);
        Instance.heroThorTaunt1 = this.CreateAudioSource(Instance.clipHeroThorTaunt1, 0);
        Instance.heroThorTaunt2 = this.CreateAudioSource(Instance.clipHeroThorTaunt2, 0);
        Instance.heroThorTaunt3 = this.CreateAudioSource(Instance.clipHeroThorTaunt3, 0);
        Instance.heroThorTaunt4 = this.CreateAudioSource(Instance.clipHeroThorTaunt4, 0);
        Instance.heroThorDeath = this.CreateAudioSource(Instance.clipHeroThorDeath, 0);
        Instance.heroThorHammer = this.CreateAudioSource(Instance.clipHeroThorHammer, 0);
        Instance.heroThorElectricAttack = this.CreateAudioSource(Instance.clipHeroThorElectricAttack, 0);
        Instance.heroThorElectricalDeath = this.CreateAudioSource(Instance.clipHeroThorElectricalDeath, 0);
        Instance.heroThorThunder = this.CreateAudioSource(Instance.clipHeroThorThunder, 0);
        Instance.heroSamuraiTaunt1 = this.CreateAudioSource(Instance.clipHeroSamuraiTaunt1, 0);
        Instance.heroSamuraiTaunt2 = this.CreateAudioSource(Instance.clipHeroSamuraiTaunt2, 0);
        Instance.heroSamuraiTaunt3 = this.CreateAudioSource(Instance.clipHeroSamuraiTaunt3, 0);
        Instance.heroSamuraiTaunt4 = this.CreateAudioSource(Instance.clipHeroSamuraiTaunt4, 0);
        Instance.heroSamuraiDeath = this.CreateAudioSource(Instance.clipHeroSamuraiDeath, 0);
        Instance.heroSamuraiGroundSawblades = this.CreateAudioSource(Instance.clipHeroSamuraiGroundSawblades, 0);
        Instance.heroSamuraiDeathStrike = this.CreateAudioSource(Instance.clipHeroSamuraiDeathStrike, 0);
        Instance.heroRobotTaunt1 = this.CreateAudioSource(Instance.clipHeroRobotTaunt1, 0);
        Instance.heroRobotTaunt2 = this.CreateAudioSource(Instance.clipHeroRobotTaunt2, 0);
        Instance.heroRobotTaunt3 = this.CreateAudioSource(Instance.clipHeroRobotTaunt3, 0);
        Instance.heroRobotTaunt4 = this.CreateAudioSource(Instance.clipHeroRobotTaunt4, 0);
        Instance.heroRobotDeath = this.CreateAudioSource(Instance.clipHeroRobotDeath, 0);
        Instance.heroRobotDrill = this.CreateAudioSource(Instance.clipHeroRobotDrill, 0);
        Instance.heroRobotShoot = this.CreateAudioSource(Instance.clipHeroRobotShoot, 0);
        Instance.mushroomBossGas = this.CreateAudioSource(Instance.clipMushroomBossGas, 0);
        Instance.mushroomBossDeath = this.CreateAudioSource(Instance.clipMushroomBossDeath, 0);
        Instance.mushroomCreepMuerte = this.CreateAudioSource(Instance.clipMushroomCreepDeath, 0);
        Instance.mushroomCreepNacimiento = this.CreateAudioSource(Instance.clipMushroomCreepNacimiento, 0);
        Instance.infernoBossDeath = this.CreateAudioSource(Instance.clipInfernoBossDeath, 0);
        Instance.infernoBossHorns = this.CreateAudioSource(Instance.clipInfernoBossHorns, 0);
        Instance.infernoBossStomp = this.CreateAudioSource(Instance.clipInfernoBossStomp, 0);
        Instance.soundArcherTauntActive = 1;
        Instance.soundRangerTauntActive = 1;
        Instance.soundMusketeerTauntActive = 1;
        Instance.soundMageTauntActive = 1;
        Instance.soundSorcererTauntActive = 1;
        Instance.soundSoldierTauntActive = 1;
        Instance.soundPaladinTauntActive = 1;
        Instance.soundBarbarianTauntActive = 1;
        Instance.soundEngineerTauntActive = 1;
        Instance.soundTeslaToastyActive = 1;
        Instance.soundReinforcementTauntActive = 1;
        Instance.soundElfTauntActive = 1;
        Instance.soundJtHitIceActive = 1;
        Instance.soundHeroArcherTauntActive = 1;
        Instance.soundHeroMageTauntActive = 1;
        Instance.soundHeroEngineerTauntActive = 1;
        Instance.soundHeroPaladinTauntActive = 1;
        Instance.soundHeroReinforcementTauntActive = 1;
        Instance.soundHeroElementalTauntActive = 1;
        Instance.soundHeroKingTauntActive = 1;
        Instance.soundHeroKingBuffActive = 1;
        Instance.soundHeroVikingTauntActive = 1;
        Instance.soundHeroFrostTauntActive = 1;
        Instance.soundHeroThorTauntActive = 1;
        Instance.soundHeroSamuraiTauntActive = 1;
        Instance.soundHeroRobotTauntActive = 1;
        this.LoadSoundSourcesList();
        this.CreateSoundPools();
        this.CreateActiveSoundPools();
        return;
    }

    public static bool IsMusicMuted()
    {
        return Instance.musicMuted;
    }

    public static bool IsSoundMuted()
    {
        return Instance.soundMuted;
    }

    private void LoadSoundSourcesList()
    {
        int num;
        num = (int) Enum.GetNames(typeof(soundID)).Length;
        Instance.soundSources = new AudioSource[num];
        Instance.soundSources[0] = this.arrowHit1;
        Instance.soundSources[1] = this.arrowHit2;
        Instance.soundSources[2] = this.spiderAttack1;
        Instance.soundSources[3] = this.spiderAttack2;
        Instance.soundSources[4] = this.wolfAttack1;
        Instance.soundSources[5] = this.wolfAttack2;
        Instance.soundSources[6] = this.heroLevelUp;
        Instance.soundSources[7] = this.heroPaladinTaunt1;
        Instance.soundSources[8] = this.heroPaladinTaunt2;
        Instance.soundSources[9] = this.heroPaladinTaunt3;
        Instance.soundSources[10] = this.heroPaladinTaunt4;
        Instance.soundSources[11] = this.heroPaladinShieldBuff;
        Instance.soundSources[12] = this.heroPaladinDeflect;
        Instance.soundSources[13] = this.heroPaladinDeath;
        Instance.soundSources[14] = this.heroMageTaunt1;
        Instance.soundSources[15] = this.heroMageTaunt2;
        Instance.soundSources[0x10] = this.heroMageTaunt3;
        Instance.soundSources[0x11] = this.heroMageTaunt4;
        Instance.soundSources[0x12] = this.heroMageDeath;
        Instance.soundSources[0x13] = this.heroMageBlueRainCharge;
        Instance.soundSources[20] = this.heroMageShadows;
        Instance.soundSources[0x15] = this.heroElvenTaunt1;
        Instance.soundSources[0x16] = this.heroElvenTaunt2;
        Instance.soundSources[0x17] = this.heroElvenTaunt3;
        Instance.soundSources[0x18] = this.heroElvenTaunt4;
        Instance.soundSources[0x19] = this.heroElvenDeath;
        Instance.soundSources[0x1a] = this.heroElvenArrow;
        Instance.soundSources[0x1b] = this.heroElvenWildCatSummon;
        Instance.soundSources[0x1c] = this.heroElvenWildCatHit;
        Instance.soundSources[0x1d] = this.heroReinforcementTaunt1;
        Instance.soundSources[30] = this.heroReinforcementTaunt2;
        Instance.soundSources[0x1f] = this.heroReinforcementTaunt3;
        Instance.soundSources[0x20] = this.heroReinforcementTaunt4;
        Instance.soundSources[0x21] = this.heroReinforcementDeath;
        Instance.soundSources[0x22] = this.heroReinforcementChargeSpecial;
        Instance.soundSources[0x23] = this.heroReinforcementHit;
        Instance.soundSources[0x24] = this.heroReinforcementJumpSpecial;
        Instance.soundSources[0x25] = this.heroDwarfTaunt1;
        Instance.soundSources[0x26] = this.heroDwarfTaunt2;
        Instance.soundSources[0x27] = this.heroDwarfTaunt3;
        Instance.soundSources[40] = this.heroDwarfTaunt4;
        Instance.soundSources[0x29] = this.heroDwarfDeath;
        Instance.soundSources[0x2a] = this.heroDwarfBreaShoot;
        Instance.soundSources[0x2b] = this.heroDwarfMine;
        Instance.soundSources[0x2c] = this.heroDwarfBreaHit;
        Instance.soundSources[0x2d] = this.heroKingTaunt1;
        Instance.soundSources[0x2e] = this.heroKingTaunt2;
        Instance.soundSources[0x2f] = this.heroKingTaunt3;
        Instance.soundSources[0x30] = this.heroKingTaunt4;
        Instance.soundSources[0x31] = this.heroKingAttack;
        Instance.soundSources[50] = this.heroKingBuff1;
        Instance.soundSources[0x33] = this.heroKingBuff2;
        Instance.soundSources[0x34] = this.heroKingDeath;
        Instance.soundSources[0x35] = this.heroFireTaunt1;
        Instance.soundSources[0x36] = this.heroFireTaunt2;
        Instance.soundSources[0x37] = this.heroFireTaunt3;
        Instance.soundSources[0x38] = this.heroFireTaunt4;
        Instance.soundSources[0x39] = this.heroFireDeath;
        Instance.soundSources[0x3a] = this.heroFireSpecialArea;
        Instance.soundSources[0x3b] = this.heroFireSpecialFireballStart;
        Instance.soundSources[60] = this.heroFireSpecialFireballEnd;
        Instance.soundSources[0x3d] = this.heroVikingTaunt1;
        Instance.soundSources[0x3e] = this.heroVikingTaunt2;
        Instance.soundSources[0x3f] = this.heroVikingTaunt3;
        Instance.soundSources[0x40] = this.heroVikingTaunt4;
        Instance.soundSources[0x43] = this.heroVikingBearStartAttack;
        Instance.soundSources[0x45] = this.heroVikingCall;
        Instance.soundSources[0x41] = this.heroVikingDeath;
        Instance.soundSources[0x42] = this.heroVikingHit;
        Instance.soundSources[0x44] = this.heroVikingTransform;
        Instance.soundSources[0x4a] = this.heroFrostDeath;
        Instance.soundSources[0x4e] = this.heroFrostGroundFreeze;
        Instance.soundSources[0x4d] = this.heroFrostIceRainBreak;
        Instance.soundSources[0x4c] = this.heroFrostIceRainDrop;
        Instance.soundSources[0x4b] = this.heroFrostIceRainSummon;
        Instance.soundSources[70] = this.heroFrostTaunt1;
        Instance.soundSources[0x47] = this.heroFrostTaunt2;
        Instance.soundSources[0x48] = this.heroFrostTaunt3;
        Instance.soundSources[0x49] = this.heroFrostTaunt4;
        Instance.soundSources[0x4f] = this.towerBuilding;
        Instance.soundSources[80] = this.towerSell;
        Instance.soundSources[0x51] = this.rallyPlaced;
        Instance.soundSources[0x52] = this.towerOpenDoor;
        Instance.soundSources[0x53] = this.waveIncoming;
        Instance.soundSources[0x54] = this.waveReady;
        Instance.soundSources[0x55] = this.coins;
        Instance.soundSources[0x56] = this.loseLife;
        Instance.soundSources[0x57] = this.spellSelect;
        Instance.soundSources[0x58] = this.spellRefresh;
        Instance.soundSources[0x59] = this.questCompleted;
        Instance.soundSources[90] = this.questFailed;
        Instance.soundSources[0x5b] = this.notificationOpen;
        Instance.soundSources[0x5c] = this.notificationClose;
        Instance.soundSources[0x5d] = this.notificationPaperOver;
        Instance.soundSources[0x5e] = this.notificationSecondLevel;
        Instance.soundSources[0x5f] = this.buttonCommon;
        Instance.soundSources[0x60] = this.buyUpgrade;
        Instance.soundSources[0x61] = this.buyAchievementWin;
        Instance.soundSources[0x62] = this.quickmenuOpen;
        Instance.soundSources[0x63] = this.quickmenuOver;
        Instance.soundSources[100] = this.mapNewRoad;
        Instance.soundSources[0x65] = this.transitionOpen;
        Instance.soundSources[0x66] = this.transitionClose;
        Instance.soundSources[0x67] = this.archerReady;
        Instance.soundSources[0x68] = this.archerTaunt1;
        Instance.soundSources[0x69] = this.archerTaunt2;
        Instance.soundSources[0x6a] = this.rangerReady;
        Instance.soundSources[0x6b] = this.rangerTaunt1;
        Instance.soundSources[0x6c] = this.rangerTaunt2;
        Instance.soundSources[0x6d] = this.musketeerReady;
        Instance.soundSources[110] = this.musketeerTaunt1;
        Instance.soundSources[0x6f] = this.musketeerTaunt2;
        Instance.soundSources[0x70] = this.musketeerSniper;
        Instance.soundSources[0x71] = this.mageReady;
        Instance.soundSources[0x72] = this.mageTaunt1;
        Instance.soundSources[0x73] = this.arcaneReady;
        Instance.soundSources[0x74] = this.arcaneTaunt1;
        Instance.soundSources[0x75] = this.arcaneTaunt2;
        Instance.soundSources[0x76] = this.sorcererReady;
        Instance.soundSources[0x77] = this.sorcererTaunt1;
        Instance.soundSources[120] = this.sorcererTaunt2;
        Instance.soundSources[0x79] = this.sheep;
        Instance.soundSources[0x7a] = this.rockElementalRally;
        Instance.soundSources[0x7b] = this.barrackReady;
        Instance.soundSources[0x7c] = this.barrackTaunt1;
        Instance.soundSources[0x7d] = this.barrackTaunt2;
        Instance.soundSources[0x7e] = this.barrackMove;
        Instance.soundSources[0x7f] = this.barrackPaladinReady;
        Instance.soundSources[0x80] = this.barrackPaladinTaunt1;
        Instance.soundSources[0x81] = this.barrackPaladinTaunt2;
        Instance.soundSources[130] = this.barrackPaladinMove;
        Instance.soundSources[0x83] = this.barrackBarbarianReady;
        Instance.soundSources[0x84] = this.barrackBarbarianTaunt1;
        Instance.soundSources[0x85] = this.barrackBarbarianTaunt2;
        Instance.soundSources[0x86] = this.barrackBarbarianMove;
        Instance.soundSources[0x87] = this.artilleryReady;
        Instance.soundSources[0x88] = this.artilleryTaunt1;
        Instance.soundSources[0x89] = this.artilleryTaunt2;
        Instance.soundSources[0x8a] = this.artilleryBfgReady;
        Instance.soundSources[0x8b] = this.artilleryBfgTaunt1;
        Instance.soundSources[140] = this.artilleryBfgTaunt2;
        Instance.soundSources[0x8d] = this.artilleryTeslaReady;
        Instance.soundSources[0x8e] = this.artilleryTeslaTaunt1;
        Instance.soundSources[0x8f] = this.artilleryTeslaTaunt2A;
        Instance.soundSources[0x90] = this.artilleryTeslaTaunt2B;
        Instance.soundSources[0x91] = this.artilleryTeslaTaunt2C;
        Instance.soundSources[0x92] = this.reinforcementTaunt1;
        Instance.soundSources[0x93] = this.reinforcementTaunt2;
        Instance.soundSources[0x94] = this.reinforcementTaunt3;
        Instance.soundSources[0x95] = this.reinforcementTaunt4;
        Instance.soundSources[150] = this.elfTaunt1;
        Instance.soundSources[0x97] = this.elfTaunt2;
        Instance.soundSources[0x98] = this.sasquashRally;
        Instance.soundSources[0x99] = this.sasquashReady;
        Instance.soundSources[0x9a] = this.juggernautDeath;
        Instance.soundSources[0x9b] = this.jtAttack;
        Instance.soundSources[0x9c] = this.jtDeath;
        Instance.soundSources[0x9d] = this.jtEat;
        Instance.soundSources[0x9e] = this.jtExplode;
        Instance.soundSources[0x9f] = this.jtRest;
        Instance.soundSources[160] = this.jtHitIce1;
        Instance.soundSources[0xa1] = this.jtHitIce2;
        Instance.soundSources[0xa2] = this.jtHitIce3;
        Instance.soundSources[0xa3] = this.veznanDeath;
        Instance.soundSources[0xa4] = this.veznanDemonFire;
        Instance.soundSources[0xa5] = this.veznanToDemon;
        Instance.soundSources[0xa6] = this.veznanHoldTrap;
        Instance.soundSources[0xa7] = this.veznanHoldCast;
        Instance.soundSources[0xa8] = this.veznanPortalSummon;
        Instance.soundSources[0xa9] = this.towerUpgrade;
        Instance.soundSources[170] = this.heroThorTaunt1;
        Instance.soundSources[0xab] = this.heroThorTaunt2;
        Instance.soundSources[0xac] = this.heroThorTaunt3;
        Instance.soundSources[0xad] = this.heroThorTaunt4;
        Instance.soundSources[0xae] = this.heroThorDeath;
        Instance.soundSources[0xb0] = this.heroThorDeath;
        Instance.soundSources[0xaf] = this.heroThorElectricAttack;
        Instance.soundSources[0xb2] = this.heroThorThunder;
        Instance.soundSources[0xb1] = this.heroThorHammer;
        Instance.soundSources[0xb3] = this.heroSamuraiTaunt1;
        Instance.soundSources[180] = this.heroSamuraiTaunt2;
        Instance.soundSources[0xb5] = this.heroSamuraiTaunt3;
        Instance.soundSources[0xb6] = this.heroSamuraiTaunt4;
        Instance.soundSources[0xb7] = this.heroSamuraiDeath;
        Instance.soundSources[0xb9] = this.heroSamuraiDeathStrike;
        Instance.soundSources[0xb8] = this.heroSamuraiGroundSawblades;
        Instance.soundSources[0xba] = this.heroRobotTaunt1;
        Instance.soundSources[0xbb] = this.heroRobotTaunt2;
        Instance.soundSources[0xbc] = this.heroRobotTaunt3;
        Instance.soundSources[0xbd] = this.heroRobotTaunt4;
        Instance.soundSources[190] = this.heroRobotDeath;
        Instance.soundSources[0xbf] = this.heroRobotDrill;
        Instance.soundSources[0xc0] = this.heroRobotShoot;
        Instance.soundSources[0xc1] = this.infernoBossDeath;
        Instance.soundSources[0xc3] = this.infernoBossStomp;
        Instance.soundSources[0xc2] = this.infernoBossHorns;
        Instance.soundSources[0xc5] = this.mushroomBossDeath;
        Instance.soundSources[0xc4] = this.mushroomBossGas;
        Instance.soundSources[0xc6] = this.mushroomCreepMuerte;
        Instance.soundSources[0xc7] = this.mushroomCreepNacimiento;
        return;
    }

    public static void MuteMusic()
    {
        Instance.musicMuted = 1;
        return;
    }

    public static void MuteSound()
    {
        Instance.soundMuted = 1;
        return;
    }

    public static void Pause()
    {
        int num;
        int num2;
        AudioSource source;
        num = (int) Enum.GetNames(typeof(soundID)).Length;
        num2 = 0;
        goto Label_0048;
    Label_0019:
        source = Instance.soundSources[num2];
        if (source.isPlaying == null)
        {
            goto Label_0044;
        }
        Instance.activeSounds[num2] = 1;
        source.Pause();
    Label_0044:
        num2 += 1;
    Label_0048:
        if (num2 < num)
        {
            goto Label_0019;
        }
        if (Instance.isAttackPlaying == null)
        {
            goto Label_006D;
        }
        Instance.meleeSword.Pause();
    Label_006D:
        Instance.soundMuted = 1;
        PausePool(Instance.poolArrowRelease1, Instance.poolActiveArrowRelease1);
        PausePool(Instance.poolArrowRelease2, Instance.poolActiveArrowRelease2);
        PausePool(Instance.poolMageBolt, Instance.poolActiveMageBolt);
        PausePool(Instance.poolBombExplosion, Instance.poolActiveBombExplosion);
        PausePool(Instance.poolShotgun, Instance.poolActiveShotgun);
        PausePool(Instance.poolSniper, Instance.poolActiveSniper);
        PausePool(Instance.poolShrapnel, Instance.poolActiveShrapnel);
        PausePool(Instance.poolFireballRelease, Instance.poolActiveFireballRelease);
        PausePool(Instance.poolFireballHit, Instance.poolActiveFireballHit);
        PausePool(Instance.poolSorcererBolt, Instance.poolActiveSorcererBolt);
        PausePool(Instance.poolPolymorph, Instance.poolActivePolymorph);
        PausePool(Instance.poolDesintegrate, Instance.poolActiveDesintegrate);
        PausePool(Instance.poolTeleport, Instance.poolActiveTeleport);
        PausePool(Instance.poolThorn, Instance.poolActiveThorn);
        PausePool(Instance.poolHealing, Instance.poolActiveHealing);
        PausePool(Instance.poolAxe, Instance.poolActiveAxe);
        PausePool(Instance.poolRocketLaunch, Instance.poolActiveRocketLaunch);
        PausePool(Instance.poolRayArcane, Instance.poolActiveRayArcane);
        PausePool(Instance.poolTeslaAttack1, Instance.poolActiveTeslaAttack1);
        PausePool(Instance.poolTeslaAttack2, Instance.poolActiveTeslaAttack2);
        PausePool(Instance.poolCommonAreaAttack, Instance.poolActiveCommonAreaAttack);
        PausePool(Instance.poolEnemyHealing, Instance.poolActiveHealing);
        PausePool(Instance.poolEnemyRocketeer, Instance.poolActiveEnemyRocketeer);
        PausePool(Instance.poolEnemyCheiftain, Instance.poolActiveEnemyCheiftain);
        PausePool(Instance.poolHeroMageRainDrop, Instance.poolActiveHeroMageRainDrop);
        PausePool(Instance.poolWinStars, Instance.poolActiveWinStars);
        PausePool(Instance.poolMapNewFlag, Instance.poolActiveMapNewFlag);
        PausePool(Instance.poolElementalDeath, Instance.poolActiveElementalDeath);
        PausePool(Instance.poolVeznanAttack, Instance.poolActiveVeznanAttack);
        PausePool(Instance.poolVeznanHoldDissipate, Instance.poolActiveVeznanHoldDissipate);
        PausePool(Instance.poolVeznanHoldHit, Instance.poolActiveVeznanHoldHit);
        PausePool(Instance.poolVeznanPortalIn, Instance.poolActiveVeznanPortalIn);
        PausePool(Instance.poolDeathGoblin, Instance.poolActiveDeathGoblin);
        PausePool(Instance.poolDeathOrc, Instance.poolActiveDeathOrc);
        PausePool(Instance.poolDeathExplosion, Instance.poolActiveDeathExplosion);
        PausePool(Instance.poolDeathPuff, Instance.poolActiveDeathPuff);
        PausePool(Instance.poolDeathSkeleton, Instance.poolActiveDeathSkeleton);
        PausePool(Instance.poolDeathTroll, Instance.poolActiveDeathTroll);
        PausePool(Instance.poolDeathBig, Instance.poolActiveDeathBig);
        PausePool(Instance.poolHuman1, Instance.poolActiveHuman1);
        PausePool(Instance.poolHuman2, Instance.poolActiveHuman2);
        PausePool(Instance.poolHuman3, Instance.poolActiveHuman3);
        PausePool(Instance.poolHuman4, Instance.poolActiveHuman4);
        return;
    }

    private static void PausePool(ArrayList pool, ArrayList activePool)
    {
        object[] objArray1;
        int num;
        AudioSource source;
        num = 0;
        goto Label_0079;
    Label_0007:
        source = (AudioSource) pool[num];
        if ((source == null) == null)
        {
            goto Label_0057;
        }
        objArray1 = new object[] { source, " ", pool[num], " posicion", (int) num };
        Debug.Log(string.Concat(objArray1));
    Label_0057:
        if (source.isPlaying == null)
        {
            goto Label_0075;
        }
        activePool[num] = (bool) 1;
        source.Pause();
    Label_0075:
        num += 1;
    Label_0079:
        if (num < pool.Count)
        {
            goto Label_0007;
        }
        return;
    }

    public static void PlayArcaneRaySound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolRayArcane, 0.68f);
        return;
    }

    public static void PlayArcherTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundArcherTauntTimeStop) >= 1.5f)
        {
            goto Label_003F;
        }
        if (Instance.soundArcherTauntTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundArcherTauntActive - 1))
        {
            case 0:
                goto Label_0065;

            case 1:
                goto Label_0075;

            case 2:
                goto Label_0085;
        }
        goto Label_0095;
    Label_0065:
        source = Instance.archerReady;
        goto Label_0095;
    Label_0075:
        source = Instance.archerTaunt1;
        goto Label_0095;
    Label_0085:
        source = Instance.archerTaunt2;
    Label_0095:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundArcherTauntTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundArcherTauntActive += 1;
        if (Instance.soundArcherTauntActive <= 3)
        {
            goto Label_00ED;
        }
        Instance.soundArcherTauntActive = 1;
    Label_00ED:
        return;
    }

    public static void PlayAreaAttack()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolCommonAreaAttack, 1f);
        return;
    }

    public static void PlayArrow()
    {
        AudioSource source;
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.8f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0065;
        }
        PlaySoundPool(Instance.poolArrowRelease1, num);
        goto Label_0075;
    Label_0065:
        PlaySoundPool(Instance.poolArrowRelease2, num);
    Label_0075:
        return;
    }

    public static void PlayArtilleryBfgClusterTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.artilleryBfgTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayArtilleryBfgMissileTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.artilleryBfgTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayArtilleryBfgTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.artilleryBfgReady;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayArtilleryTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundEngineerTauntTimeStop) >= 1.5f)
        {
            goto Label_003F;
        }
        if (Instance.soundEngineerTauntTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundEngineerTauntActive - 1))
        {
            case 0:
                goto Label_0065;

            case 1:
                goto Label_0075;

            case 2:
                goto Label_0085;
        }
        goto Label_0095;
    Label_0065:
        source = Instance.artilleryReady;
        goto Label_0095;
    Label_0075:
        source = Instance.artilleryTaunt1;
        goto Label_0095;
    Label_0085:
        source = Instance.artilleryTaunt2;
    Label_0095:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundEngineerTauntTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundEngineerTauntActive += 1;
        if (Instance.soundEngineerTauntActive <= 3)
        {
            goto Label_00ED;
        }
        Instance.soundEngineerTauntActive = 1;
    Label_00ED:
        return;
    }

    public static void PlayArtilleryTeslaChargedBoltTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundTeslaToastyActive - 1))
        {
            case 0:
                goto Label_0036;

            case 1:
                goto Label_0046;

            case 2:
                goto Label_0056;
        }
        goto Label_0066;
    Label_0036:
        source = Instance.artilleryTeslaTaunt2A;
        goto Label_0066;
    Label_0046:
        source = Instance.artilleryTeslaTaunt2B;
        goto Label_0066;
    Label_0056:
        source = Instance.artilleryTeslaTaunt2C;
    Label_0066:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundTeslaToastyActive += 1;
        if (Instance.soundTeslaToastyActive <= 3)
        {
            goto Label_00AF;
        }
        Instance.soundTeslaToastyActive = 1;
    Label_00AF:
        return;
    }

    public static void PlayArtilleryTeslaOverchargeTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.artilleryTeslaTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayArtilleryTeslaTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.artilleryTeslaReady;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayAxeSound()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.8f)
        {
            goto Label_0037;
        }
        num = 0.8f;
    Label_0037:
        PlaySoundPool(Instance.poolAxe, num);
        return;
    }

    public static void PlayBarrackBarbarianDoubleAxesTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.barrackBarbarianMove;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayBarrackBarbarianTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundBarbarianTauntActive - 1))
        {
            case 0:
                goto Label_003A;

            case 1:
                goto Label_004A;

            case 2:
                goto Label_005A;

            case 3:
                goto Label_006A;
        }
        goto Label_007A;
    Label_003A:
        source = Instance.barrackBarbarianReady;
        goto Label_007A;
    Label_004A:
        source = Instance.barrackBarbarianTaunt1;
        goto Label_007A;
    Label_005A:
        source = Instance.barrackBarbarianTaunt2;
        goto Label_007A;
    Label_006A:
        source = Instance.barrackBarbarianMove;
    Label_007A:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundBarbarianTauntActive += 1;
        if (Instance.soundBarbarianTauntActive <= 4)
        {
            goto Label_00C3;
        }
        Instance.soundBarbarianTauntActive = 1;
    Label_00C3:
        return;
    }

    public static void PlayBarrackBarbarianThrowingAxesTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.barrackBarbarianReady;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayBarrackBarbarianTwisterTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.barrackBarbarianTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayBarrackPaladinHealingTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.barrackPaladinReady;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayBarrackPaladinHolyStrikeTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.barrackPaladinTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayBarrackPaladinShieldTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.barrackPaladinTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayBarrackPaladinTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundPaladinTauntActive - 1))
        {
            case 0:
                goto Label_003A;

            case 1:
                goto Label_004A;

            case 2:
                goto Label_005A;

            case 3:
                goto Label_006A;
        }
        goto Label_007A;
    Label_003A:
        source = Instance.barrackPaladinReady;
        goto Label_007A;
    Label_004A:
        source = Instance.barrackPaladinTaunt1;
        goto Label_007A;
    Label_005A:
        source = Instance.barrackPaladinTaunt2;
        goto Label_007A;
    Label_006A:
        source = Instance.barrackPaladinMove;
    Label_007A:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundPaladinTauntActive += 1;
        if (Instance.soundPaladinTauntActive <= 4)
        {
            goto Label_00C3;
        }
        Instance.soundPaladinTauntActive = 1;
    Label_00C3:
        return;
    }

    public static void PlayBarrackTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundSoldierTauntTimeStop) >= 1.5f)
        {
            goto Label_003F;
        }
        if (Instance.soundSoldierTauntTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundSoldierTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.barrackReady;
        goto Label_00A9;
    Label_0079:
        source = Instance.barrackTaunt1;
        goto Label_00A9;
    Label_0089:
        source = Instance.barrackTaunt2;
        goto Label_00A9;
    Label_0099:
        source = Instance.barrackMove;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundSoldierTauntTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundSoldierTauntActive += 1;
        if (Instance.soundSoldierTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundSoldierTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayBoltSorcererSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolSorcererBolt, 0.68f);
        return;
    }

    public static void PlayBoltSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolMageBolt, 0.68f);
        return;
    }

    public static void PlayBombExplosionSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolBombExplosion, 0.65f);
        return;
    }

    public static void PlayBombShootSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolBombShoot, 0.65f);
        return;
    }

    public static void PlayDeathBig()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolDeathBig, num);
        return;
    }

    public static void PlayDeathExplosion()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolDeathExplosion, 0.4f);
        return;
    }

    public static void PlayDeathGoblin()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolDeathGoblin, num);
        return;
    }

    public static void PlayDeathHuman()
    {
        AudioSource source;
        float num;
        int num2;
        int num3;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.9f)
        {
            goto Label_0039;
        }
        num = 0.9f;
    Label_0039:
        switch ((UnityEngine.Random.Range(1, 5) - 1))
        {
            case 0:
                goto Label_0060;

            case 1:
                goto Label_0075;

            case 2:
                goto Label_008A;

            case 3:
                goto Label_009F;
        }
        goto Label_00B4;
    Label_0060:
        PlaySoundPool(Instance.poolHuman1, num);
        goto Label_00B4;
    Label_0075:
        PlaySoundPool(Instance.poolHuman2, num);
        goto Label_00B4;
    Label_008A:
        PlaySoundPool(Instance.poolHuman3, num);
        goto Label_00B4;
    Label_009F:
        PlaySoundPool(Instance.poolHuman4, num);
    Label_00B4:
        return;
    }

    public static void PlayDeathOrc()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolDeathOrc, num);
        return;
    }

    public static void PlayDeathPuff()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolDeathPuff, 0.8f);
        return;
    }

    public static void PlayDeathSkeleton()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolDeathSkeleton, num);
        return;
    }

    public static void PlayDeathTroll()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.6f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolDeathTroll, num);
        return;
    }

    public static void PlayDesintegrateSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolDesintegrate, 1f);
        return;
    }

    public static void PlayElfTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        num = Instance.soundElfTauntActive;
        if (num == 1)
        {
            goto Label_0030;
        }
        if (num == 2)
        {
            goto Label_0040;
        }
        goto Label_0050;
    Label_0030:
        source = Instance.elfTaunt1;
        goto Label_0050;
    Label_0040:
        source = Instance.elfTaunt2;
    Label_0050:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundElfTauntActive += 1;
        if (Instance.soundElfTauntActive <= 2)
        {
            goto Label_0099;
        }
        Instance.soundElfTauntActive = 1;
    Label_0099:
        return;
    }

    public static void PlayEnemyChieftain()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolEnemyCheiftain, 0.6f);
        return;
    }

    public static void PlayEnemyHealing()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolEnemyHealing, 0.8f);
        return;
    }

    public static void PlayEnemyRocketeer()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolEnemyRocketeer, 0.6f);
        return;
    }

    public static void PlayerRangerPoisonTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.rangerTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayerRangerThornTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.rangerTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayFireballHit()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolFireballHit, 0.5f);
        return;
    }

    public static void PlayFireballRelease()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolFireballRelease, 0.5f);
        return;
    }

    public static void PlayFxCheck()
    {
        AudioSource source;
        source = Instance.buyUpgrade;
        source.volume = 0.8f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIAchievementWin()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.buyAchievementWin;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIButtonCommon()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.buttonCommon;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIBuyUpgrade()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.buyUpgrade;
        source.volume = 0.8f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUICoins()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.coins;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUILoseLife()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.loseLife;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIMapNewFlag()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolMapNewFlag, 1f);
        return;
    }

    public static void PlayGuimapNewRoad()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.mapNewRoad;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUINextWaveIncoming()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.waveIncoming;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUINextWaveReady()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.waveReady;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUINotificationClose()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.notificationClose;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUINotificationOpen()
    {
        AudioSource source;
        source = Instance.notificationOpen;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUINotificationPaperOver()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.notificationPaperOver;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUINotificationSecondLevel()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.notificationSecondLevel;
        source.volume = 0.8f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIQuestCompleted()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.questCompleted;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIQuestFailed()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.questFailed;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIQuickMenuOpen()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.quickmenuOpen;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIQuickMenuOver()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.quickmenuOver;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUISpellRefresh()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.spellRefresh;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUISpellSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.spellSelect;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUITowerOpenDoor()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.towerOpenDoor;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUITransitionClose()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.transitionClose;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUITransitionOpen()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.transitionOpen;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayGUIWinStars()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolWinStars, 1f);
        return;
    }

    public static void PlayHealingSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolHealing, 0.8f);
        return;
    }

    public static void PlayHeroArcherDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroElvenDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroArcherShoot()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroElvenArrow;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroArcherSummon()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroElvenWildCatSummon;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroArcherTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroArcherTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroElvenTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroElvenTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroElvenTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroElvenTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroArcherTauntActive += 1;
        if (Instance.soundHeroArcherTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroArcherTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroArcherTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroArcherTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroElvenTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroArcherWildCatHit()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroElvenWildCatHit;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDenasAttack()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroKingAttack;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDenasBuff()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        num = Instance.soundHeroKingBuffActive;
        if (num == 1)
        {
            goto Label_0030;
        }
        if (num == 2)
        {
            goto Label_0040;
        }
        goto Label_0050;
    Label_0030:
        source = Instance.heroKingBuff1;
        goto Label_0050;
    Label_0040:
        source = Instance.heroKingBuff2;
    Label_0050:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundHeroKingBuffActive += 1;
        if (Instance.soundHeroKingBuffActive <= 2)
        {
            goto Label_0099;
        }
        Instance.soundHeroKingBuffActive = 1;
    Label_0099:
        return;
    }

    public static void PlayHeroDenasDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroKingDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDenasTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroKingTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroKingTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroKingTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroKingTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroKingTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroKingTauntActive += 1;
        if (Instance.soundHeroKingTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroKingTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroDenasTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDenasTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroKingTaunt4;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDwarfBrea()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroDwarfBreaShoot;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDwarfBreaHit()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroDwarfBreaHit;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDwarfDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroDwarfDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDwarfMine()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroDwarfMine;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDwarfTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroEngineerTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroDwarfTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroDwarfTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroDwarfTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroDwarfTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroEngineerTauntActive += 1;
        if (Instance.soundHeroEngineerTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroEngineerTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroDwarfTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroDwarfTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroDwarfTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroFrostDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFrostDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroFrostGroundFreeze()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFrostGroundFreeze;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroFrostIceRainBreak()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFrostIceRainBreak;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroFrostIceRainDrop()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFrostIceRainDrop;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroFrostIceRainSummon()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFrostIceRainSummon;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroFrostTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroFrostTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroFrostTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroFrostTaunt3;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroFrostTaunt2;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroFrostTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroFrostTauntActive += 1;
        if (Instance.soundHeroFrostTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroFrostTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroFrostTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFrostTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroLevelUp()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroMageDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroMageDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroMageRainCharge()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroMageBlueRainCharge;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroMageRainDrop()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolHeroMageRainDrop, 0.6f);
        return;
    }

    public static void PlayHeroMageShadows()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroMageShadows;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroMageTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroMageTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroMageTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroMageTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroMageTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroMageTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroMageTauntActive += 1;
        if (Instance.soundHeroMageTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroMageTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroMageTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroMageTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroMageTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroPaladinDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroPaladinDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroPaladinDeflect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroPaladinDeflect;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroPaladinTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroPaladinTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroPaladinTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroPaladinTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroPaladinTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroPaladinTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroPaladinTauntActive += 1;
        if (Instance.soundHeroPaladinTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroPaladinTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroPaladinTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroPaladinTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroPaladinTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroPaladinValor()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroPaladinShieldBuff;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRainOfFireArea()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFireSpecialArea;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRainOfFireDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFireDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRainOfFireFireball1()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFireSpecialFireballStart;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRainOfFireFireball2()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFireSpecialFireballEnd;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRainOfFireTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroElementalTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroFireTaunt1;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroFireTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroFireTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroFireTaunt4;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroElementalTauntActive += 1;
        if (Instance.soundHeroElementalTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroElementalTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroRainOfFireTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRainOfFireTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroFireTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroReinforcementDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroReinforcementDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroReinforcementHit()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroReinforcementHit;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroReinforcementJump()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroReinforcementJumpSpecial;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroReinforcementSpecial()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroReinforcementChargeSpecial;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroReinforcementTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroReinforcementTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroReinforcementTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroReinforcementTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroReinforcementTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroReinforcementTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroReinforcementTauntActive += 1;
        if (Instance.soundHeroReinforcementTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroReinforcementTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroReinforcementTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroReinforcementTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroReinforcementTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRobotDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroRobotDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRobotDrill()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroRobotDrill;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRobotShoot()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroRobotShoot;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroRobotTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroRobotTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroRobotTaunt1;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroRobotTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroRobotTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroRobotTaunt4;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroRobotTauntActive += 1;
        if (Instance.soundHeroRobotTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroRobotTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroRobotTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroRobotTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroSamuraiDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroSamuraiDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroSamuraiDeathStrike()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroSamuraiDeathStrike;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroSamuraiTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroSamuraiTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroSamuraiTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroSamuraiTaunt3;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroSamuraiTaunt2;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroSamuraiTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroSamuraiTauntActive += 1;
        if (Instance.soundHeroSamuraiTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroSamuraiTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroSamuraiTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroSamuraiTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroSamuraiTaunt3;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroSamuraiTorment()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroSamuraiGroundSawblades;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroThorDeath()
    {
        AudioSource source;
        AudioSource source2;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroThorDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        source2 = Instance.heroThorElectricalDeath;
        source2.volume = 0.6f * Instance.volumeFxPercentage;
        source2.Play();
        return;
    }

    public static void PlayHeroThorElectricAttack()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroThorElectricAttack;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroThorHammer()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroThorHammer;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroThorTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroThorTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroThorTaunt1;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroThorTaunt2;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroThorTaunt3;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroThorTaunt4;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroThorTauntActive += 1;
        if (Instance.soundHeroThorTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroThorTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroThorTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroThorTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroThorTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroThorThunder()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroThorThunder;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingAttackHit()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroVikingHit;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingBearAttackStart()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroVikingBearStartAttack;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingBearTransform()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroVikingTransform;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingCall()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroVikingCall;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroVikingDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundHeroTimeStop) >= 1f)
        {
            goto Label_003F;
        }
        if (Instance.soundHeroTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundHeroVikingTauntActive - 1))
        {
            case 0:
                goto Label_0069;

            case 1:
                goto Label_0079;

            case 2:
                goto Label_0089;

            case 3:
                goto Label_0099;
        }
        goto Label_00A9;
    Label_0069:
        source = Instance.heroVikingTaunt4;
        goto Label_00A9;
    Label_0079:
        source = Instance.heroVikingTaunt3;
        goto Label_00A9;
    Label_0089:
        source = Instance.heroVikingTaunt2;
        goto Label_00A9;
    Label_0099:
        source = Instance.heroVikingTaunt1;
    Label_00A9:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundHeroTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundHeroVikingTauntActive += 1;
        if (Instance.soundHeroVikingTauntActive <= 4)
        {
            goto Label_0101;
        }
        Instance.soundHeroVikingTauntActive = 1;
    Label_0101:
        return;
    }

    public static void PlayHeroVikingTauntIntro()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroLevelUp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHeroVikingTauntSelect()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.heroVikingTaunt4;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayHitSound()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_003B;
        }
        source = Instance.arrowHit1;
        goto Label_0046;
    Label_003B:
        source = Instance.arrowHit2;
    Label_0046:
        source.volume = 0.15f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayInfernoBossDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.infernoBossDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayInfernoBossHorn()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.infernoBossHorns;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayInfernoBossStomp()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.infernoBossStomp;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayJTAttack()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.jtAttack;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayJTDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.jtDeath;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayJTEat()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.jtEat;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayJTExplode()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.jtExplode;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayJTHitIce()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundJtHitIceActive - 1))
        {
            case 0:
                goto Label_0036;

            case 1:
                goto Label_0046;

            case 2:
                goto Label_0056;
        }
        goto Label_0066;
    Label_0036:
        source = Instance.jtHitIce1;
        goto Label_0066;
    Label_0046:
        source = Instance.jtHitIce2;
        goto Label_0066;
    Label_0056:
        source = Instance.jtHitIce3;
    Label_0066:
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundJtHitIceActive += 1;
        if (Instance.soundJtHitIceActive <= 3)
        {
            goto Label_00AF;
        }
        Instance.soundJtHitIceActive = 1;
    Label_00AF:
        return;
    }

    public static void PlayJTRest()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.jtRest;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayJuggernautDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.juggernautDeath;
        source.volume = 0.9f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMageArcaneDesintegrateTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.arcaneTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMageArcaneTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.arcaneReady;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMageArcaneTeleportTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.arcaneTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMageSorcererAshesToAshesTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.sorcererTaunt2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMageSorcererTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundSorcererTauntActive - 1))
        {
            case 0:
                goto Label_0036;

            case 1:
                goto Label_0046;

            case 2:
                goto Label_0056;
        }
        goto Label_0066;
    Label_0036:
        source = Instance.sorcererReady;
        goto Label_0066;
    Label_0046:
        source = Instance.sorcererTaunt1;
        goto Label_0066;
    Label_0056:
        source = Instance.sorcererTaunt2;
    Label_0066:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundSorcererTauntActive += 1;
        if (Instance.soundSorcererTauntActive <= 3)
        {
            goto Label_00AF;
        }
        Instance.soundSorcererTauntActive = 1;
    Label_00AF:
        return;
    }

    public static void PlayMageTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundMageTauntTimeStop) >= 1.5f)
        {
            goto Label_003F;
        }
        if (Instance.soundMageTauntTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = null;
        switch ((Instance.soundMageTauntActive - 1))
        {
            case 0:
                goto Label_0065;

            case 1:
                goto Label_0075;

            case 2:
                goto Label_0085;
        }
        goto Label_0095;
    Label_0065:
        source = Instance.mageReady;
        goto Label_0095;
    Label_0075:
        source = Instance.mageTaunt1;
        goto Label_0095;
    Label_0085:
        source = Instance.mageTaunt2;
    Label_0095:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundMageTauntTimeStop = Time.time;
        manager1 = Instance;
        manager1.soundMageTauntActive += 1;
        if (Instance.soundMageTauntActive <= 2)
        {
            goto Label_00ED;
        }
        Instance.soundMageTauntActive = 1;
    Label_00ED:
        return;
    }

    public static void PlayMushroomBossDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.mushroomBossDeath;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMushroomBossGas()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.mushroomBossGas;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMushroomCreepBorn()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.mushroomCreepNacimiento;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMushroomCreepDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.mushroomCreepMuerte;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMusketeerShrapnelTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.musketeerTaunt1;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMusketeerSniperTaunt()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.musketeerSniper;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayMusketeerTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundMusketeerTauntActive - 1))
        {
            case 0:
                goto Label_0036;

            case 1:
                goto Label_0046;

            case 2:
                goto Label_0056;
        }
        goto Label_0066;
    Label_0036:
        source = Instance.musketeerReady;
        goto Label_0066;
    Label_0046:
        source = Instance.musketeerTaunt1;
        goto Label_0066;
    Label_0056:
        source = Instance.musketeerTaunt2;
    Label_0066:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundMusketeerTauntActive += 1;
        if (Instance.soundMusketeerTauntActive <= 3)
        {
            goto Label_00AF;
        }
        Instance.soundMusketeerTauntActive = 1;
    Label_00AF:
        return;
    }

    public static void PlayPolymorphSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolPolymorph, 0.9f);
        return;
    }

    public static void PlayRallyPoint()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.rallyPlaced;
        source.volume = 0.8f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayRangerTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundRangerTauntActive - 1))
        {
            case 0:
                goto Label_0036;

            case 1:
                goto Label_0046;

            case 2:
                goto Label_0056;
        }
        goto Label_0066;
    Label_0036:
        source = Instance.rangerReady;
        goto Label_0066;
    Label_0046:
        source = Instance.rangerTaunt1;
        goto Label_0066;
    Label_0056:
        source = Instance.rangerTaunt2;
    Label_0066:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundRangerTauntActive += 1;
        if (Instance.soundRangerTauntActive <= 3)
        {
            goto Label_00AF;
        }
        Instance.soundRangerTauntActive = 1;
    Label_00AF:
        return;
    }

    public static void PlayReinforcementTaunt()
    {
        GameSoundManager manager1;
        AudioSource source;
        int num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = null;
        switch ((Instance.soundReinforcementTauntActive - 1))
        {
            case 0:
                goto Label_003A;

            case 1:
                goto Label_004A;

            case 2:
                goto Label_005A;

            case 3:
                goto Label_006A;
        }
        goto Label_007A;
    Label_003A:
        source = Instance.reinforcementTaunt1;
        goto Label_007A;
    Label_004A:
        source = Instance.reinforcementTaunt2;
        goto Label_007A;
    Label_005A:
        source = Instance.reinforcementTaunt3;
        goto Label_007A;
    Label_006A:
        source = Instance.reinforcementTaunt4;
    Label_007A:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        manager1 = Instance;
        manager1.soundReinforcementTauntActive += 1;
        if (Instance.soundReinforcementTauntActive <= 4)
        {
            goto Label_00C3;
        }
        Instance.soundReinforcementTauntActive = 1;
    Label_00C3:
        return;
    }

    public static void PlayRockElementalDeath()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolElementalDeath, 0.6f);
        return;
    }

    public static void PlayRockElementalRally()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.rockElementalRally;
        source.volume = (0.6f * Instance.volumeFxPercentage) + 0.2f;
        source.Play();
        return;
    }

    public static void PlayRocketLaunchSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolRocketLaunch, 0.8f);
        return;
    }

    public static void PlaySasquashRally()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.sasquashRally;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlaySasquashReady()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.sasquashReady;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlaySheep()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolSheep, 0.6f);
        return;
    }

    public static void PlayShotgunSound()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.8f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolShotgun, num);
        return;
    }

    public static void PlayShrapnelSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolShrapnel, 0.7f);
        return;
    }

    public static void PlaySniperSound()
    {
        float num;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        num = UnityEngine.Random.Range(0f, 1f) + 0.8f;
        if (num <= 0.9f)
        {
            goto Label_0037;
        }
        num = 0.9f;
    Label_0037:
        PlaySoundPool(Instance.poolSniper, num);
        return;
    }

    private static void PlaySoundPool(ArrayList pool, float vol)
    {
        AudioSource source;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = pool.GetEnumerator();
    Label_0007:
        try
        {
            goto Label_0052;
        Label_000C:
            source = (AudioSource) enumerator.Current;
            if ((source == null) == null)
            {
                goto Label_002A;
            }
            Debug.Log(pool);
        Label_002A:
            if (source.isPlaying != null)
            {
                goto Label_0052;
            }
            source.volume = vol * Instance.volumeFxPercentage;
            source.Play();
            goto Label_005D;
        Label_0052:
            if (enumerator.MoveNext() != null)
            {
                goto Label_000C;
            }
        Label_005D:
            goto Label_0074;
        }
        finally
        {
        Label_0062:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006D;
            }
        Label_006D:
            disposable.Dispose();
        }
    Label_0074:
        return;
    }

    public static void PlaySpiderAttack()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundSpiderAttackTimeStop) >= 1.5f)
        {
            goto Label_003F;
        }
        if (Instance.soundSpiderAttackTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        source = Instance.spiderAttack2;
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundArcherTauntTimeStop = Time.time;
        return;
    }

    public static void PlayTeleporthSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolTeleport, 1f);
        return;
    }

    public static void PlayTeslaAttack()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0042;
        }
        PlaySoundPool(Instance.poolTeslaAttack1, 0.6f);
        goto Label_0056;
    Label_0042:
        PlaySoundPool(Instance.poolTeslaAttack2, 0.6f);
    Label_0056:
        return;
    }

    public static void PlayThornSound()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolThorn, 0.8f);
        return;
    }

    public static void PlayTowerBuilding()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.towerBuilding;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayTowerSell()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.towerSell;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayTowerUpgrade()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.towerUpgrade;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayVeznanAttack()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolVeznanAttack, 1f);
        return;
    }

    public static void PlayVeznanDeath()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.veznanDeath;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayVeznanDemonFire()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.veznanDemonFire;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayVeznanHoldCast()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.veznanHoldCast;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayVeznanHoldDissipate()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolVeznanHoldDissipate, 1f);
        return;
    }

    public static void PlayVeznanHoldHit()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolVeznanHoldHit, 1f);
        return;
    }

    public static void PlayVeznanHoldTrap()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.veznanHoldTrap;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayVeznanPortalIn()
    {
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        PlaySoundPool(Instance.poolVeznanPortalIn, 1f);
        return;
    }

    public static void PlayVeznanPortalSummon()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.veznanPortalSummon;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayVeznanToDemon()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        source = Instance.veznanToDemon;
        source.volume = 1f * Instance.volumeFxPercentage;
        source.Play();
        return;
    }

    public static void PlayWolfAttack()
    {
        AudioSource source;
        if (Instance.soundMuted == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if ((Time.time - Instance.soundWolfAttackTimeStop) >= 1.5f)
        {
            goto Label_003F;
        }
        if (Instance.soundWolfAttackTimeStop == 0f)
        {
            goto Label_003F;
        }
        return;
    Label_003F:
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0068;
        }
        source = Instance.wolfAttack1;
        goto Label_0073;
    Label_0068:
        source = Instance.wolfAttack2;
    Label_0073:
        source.volume = 0.6f * Instance.volumeFxPercentage;
        source.Play();
        Instance.soundWolfAttackTimeStop = Time.time;
        return;
    }

    public static void SetVolumeFx(float p)
    {
        Instance.volumeFxPercentage = p;
        return;
    }

    public static void SetVolumeMusic(float p)
    {
        Instance.volumeMusicPercentage = p;
        return;
    }

    public static void StopMeleeFight()
    {
        Instance.meleeSword.Stop();
        Instance.isAttackPlaying = 0;
        return;
    }

    public static void StopMusic()
    {
        GameObject obj2;
        GameObject obj3;
        obj2 = GameObject.Find("MapMusic");
        if ((obj2 != null) == null)
        {
            goto Label_0027;
        }
        obj2.GetComponent<AudioSource>().Stop();
        goto Label_0049;
    Label_0027:
        obj3 = GameObject.Find("MusicTheme");
        if ((obj3 != null) == null)
        {
            goto Label_0049;
        }
        obj3.GetComponent<AudioSource>().Stop();
    Label_0049:
        return;
    }

    public static void UnmuteMusic()
    {
        Instance.musicMuted = 0;
        return;
    }

    public static void UnmuteSound()
    {
        Instance.soundMuted = 0;
        return;
    }

    public static void Unpause()
    {
        int num;
        int num2;
        AudioSource source;
        num = (int) Enum.GetNames(typeof(soundID)).Length;
        num2 = 0;
        goto Label_004E;
    Label_0019:
        if (Instance.activeSounds[num2] == null)
        {
            goto Label_004A;
        }
        Instance.activeSounds[num2] = 0;
        source = Instance.soundSources[num2];
        source.Play();
    Label_004A:
        num2 += 1;
    Label_004E:
        if (num2 < num)
        {
            goto Label_0019;
        }
        if (Instance.isAttackPlaying == null)
        {
            goto Label_0073;
        }
        Instance.meleeSword.Play();
    Label_0073:
        Instance.soundMuted = 0;
        UnpausePool(Instance.poolArrowRelease1, Instance.poolActiveArrowRelease1);
        UnpausePool(Instance.poolArrowRelease2, Instance.poolActiveArrowRelease2);
        UnpausePool(Instance.poolMageBolt, Instance.poolActiveMageBolt);
        UnpausePool(Instance.poolBombExplosion, Instance.poolActiveBombExplosion);
        UnpausePool(Instance.poolShotgun, Instance.poolActiveShotgun);
        UnpausePool(Instance.poolShrapnel, Instance.poolActiveShrapnel);
        UnpausePool(Instance.poolFireballRelease, Instance.poolActiveFireballRelease);
        UnpausePool(Instance.poolFireballHit, Instance.poolActiveFireballHit);
        UnpausePool(Instance.poolSorcererBolt, Instance.poolActiveSorcererBolt);
        UnpausePool(Instance.poolPolymorph, Instance.poolActivePolymorph);
        UnpausePool(Instance.poolDesintegrate, Instance.poolActiveDesintegrate);
        UnpausePool(Instance.poolTeleport, Instance.poolActiveTeleport);
        UnpausePool(Instance.poolThorn, Instance.poolActiveThorn);
        UnpausePool(Instance.poolHealing, Instance.poolActiveHealing);
        UnpausePool(Instance.poolAxe, Instance.poolActiveAxe);
        UnpausePool(Instance.poolRocketLaunch, Instance.poolActiveRocketLaunch);
        UnpausePool(Instance.poolRayArcane, Instance.poolActiveRayArcane);
        UnpausePool(Instance.poolTeslaAttack1, Instance.poolActiveTeslaAttack1);
        UnpausePool(Instance.poolTeslaAttack2, Instance.poolActiveTeslaAttack2);
        UnpausePool(Instance.poolCommonAreaAttack, Instance.poolActiveCommonAreaAttack);
        UnpausePool(Instance.poolEnemyHealing, Instance.poolActiveHealing);
        UnpausePool(Instance.poolEnemyRocketeer, Instance.poolActiveEnemyRocketeer);
        UnpausePool(Instance.poolEnemyCheiftain, Instance.poolActiveEnemyCheiftain);
        UnpausePool(Instance.poolHeroMageRainDrop, Instance.poolActiveHeroMageRainDrop);
        UnpausePool(Instance.poolWinStars, Instance.poolActiveWinStars);
        UnpausePool(Instance.poolMapNewFlag, Instance.poolActiveMapNewFlag);
        UnpausePool(Instance.poolElementalDeath, Instance.poolActiveElementalDeath);
        UnpausePool(Instance.poolVeznanAttack, Instance.poolActiveVeznanAttack);
        UnpausePool(Instance.poolVeznanHoldDissipate, Instance.poolActiveVeznanHoldDissipate);
        UnpausePool(Instance.poolVeznanHoldHit, Instance.poolActiveVeznanHoldHit);
        UnpausePool(Instance.poolVeznanPortalIn, Instance.poolActiveVeznanPortalIn);
        UnpausePool(Instance.poolDeathGoblin, Instance.poolActiveDeathGoblin);
        UnpausePool(Instance.poolDeathOrc, Instance.poolActiveDeathOrc);
        UnpausePool(Instance.poolDeathExplosion, Instance.poolActiveDeathExplosion);
        UnpausePool(Instance.poolDeathPuff, Instance.poolActiveDeathPuff);
        UnpausePool(Instance.poolDeathSkeleton, Instance.poolActiveDeathSkeleton);
        UnpausePool(Instance.poolDeathTroll, Instance.poolActiveDeathTroll);
        UnpausePool(Instance.poolDeathBig, Instance.poolActiveDeathBig);
        UnpausePool(Instance.poolHuman1, Instance.poolActiveHuman1);
        UnpausePool(Instance.poolHuman2, Instance.poolActiveHuman2);
        UnpausePool(Instance.poolHuman3, Instance.poolActiveHuman3);
        UnpausePool(Instance.poolHuman4, Instance.poolActiveHuman4);
        return;
    }

    private static void UnpausePool(ArrayList pool, ArrayList activePool)
    {
        int num;
        AudioSource source;
        num = 0;
        goto Label_003C;
    Label_0007:
        if (((bool) activePool[num]) == null)
        {
            goto Label_0038;
        }
        activePool[num] = (bool) 0;
        source = (AudioSource) pool[num];
        source.Play();
    Label_0038:
        num += 1;
    Label_003C:
        if (num < activePool.Count)
        {
            goto Label_0007;
        }
        return;
    }

    public static GameSoundManager Instance
    {
        get
        {
            if (instance != null)
            {
                goto Label_0010;
            }
            new GameSoundManager();
        Label_0010:
            return instance;
        }
    }

    private enum soundID
    {
        idArrowHit1,
        idArrowHit2,
        idSpiderAttack1,
        idSpiderAttack2,
        idWolfAttack1,
        idWolfAttack2,
        idHeroLevelUp,
        idHeroPaladinTaunt1,
        idHeroPaladinTaunt2,
        idHeroPaladinTaunt3,
        idHeroPaladinTaunt4,
        idHeroPaladinShieldBuff,
        idHeroPaladinDeflect,
        idHeroPaladinDeath,
        idHeroMageTaunt1,
        idHeroMageTaunt2,
        idHeroMageTaunt3,
        idHeroMageTaunt4,
        idHeroMageDeath,
        idHeroMageBlueRainCharge,
        idHeroMageShadows,
        idHeroElvenTaunt1,
        idHeroElvenTaunt2,
        idHeroElvenTaunt3,
        idHeroElvenTaunt4,
        idHeroElvenDeath,
        idHeroElvenArrow,
        idHeroElvenWildCatSummon,
        idHeroElvenWildCatHit,
        idHeroReinforcementTaunt1,
        idHeroReinforcementTaunt2,
        idHeroReinforcementTaunt3,
        idHeroReinforcementTaunt4,
        idHeroReinforcementDeath,
        idHeroReinforcementChargeSpecial,
        idHeroReinforcementHit,
        idHeroReinforcementJumpSpecial,
        idHeroDwarfTaunt1,
        idHeroDwarfTaunt2,
        idHeroDwarfTaunt3,
        idHeroDwarfTaunt4,
        idHeroDwarfDeath,
        idHeroDwarfBreaShoot,
        idHeroDwarfMine,
        idHeroDwarfBreaHit,
        idHeroKingTaunt1,
        idHeroKingTaunt2,
        idHeroKingTaunt3,
        idHeroKingTaunt4,
        idHeroKingAttack,
        idHeroKingBuff1,
        idHeroKingBuff2,
        idHeroKingDeath,
        idHeroFireTaunt1,
        idHeroFireTaunt2,
        idHeroFireTaunt3,
        idHeroFireTaunt4,
        idHeroFireDeath,
        idHeroFireSpecialArea,
        idHeroFireSpecialFireballStart,
        idHeroFireSpecialFireballEnd,
        idHeroVikingTaunt1,
        idHeroVikingTaunt2,
        idHeroVikingTaunt3,
        idHeroVikingTaunt4,
        idHeroVikingDeath,
        idHeroVikingHit,
        idHeroVikingBearStartAttack,
        idHeroVikingTransform,
        idHeroVikingCall,
        idHeroFrostTaunt1,
        idHeroFrostTaunt2,
        idHeroFrostTaunt3,
        idHeroFrostTaunt4,
        idHeroFrostDeath,
        idHeroFrostIceRainSummon,
        idHeroFrostIceRainDrop,
        idHeroFrostIceRainBreak,
        idHeroFrostGroundFreeze,
        idTowerBuilding,
        idTowerSell,
        idRallyPlaced,
        idTowerOpenDoor,
        idWaveIncoming,
        idWaveReady,
        idCoins,
        idLoseLife,
        idSpellSelect,
        idSpellRefresh,
        idQuestCompleted,
        idQuestFailed,
        idNotificationOpen,
        idNotificationClose,
        idNotificationPaperOver,
        idNotificationSecondLevel,
        idButtonCommon,
        idBuyUpgrade,
        idBuyAchievementWin,
        idQuickmenuOpen,
        idQuickmenuOver,
        idMapNewRoad,
        idTransitionOpen,
        idTransitionClose,
        idArcherReady,
        idArcherTaunt1,
        idArcherTaunt2,
        idRangerReady,
        idRangerTaunt1,
        idRangerTaunt2,
        idMusketeerReady,
        idMusketeerTaunt1,
        idMusketeerTaunt2,
        idMusketeerSniper,
        idMageReady,
        idMageTaunt1,
        idArcaneReady,
        idArcaneTaunt1,
        idArcaneTaunt2,
        idSorcererReady,
        idSorcererTaunt1,
        idSorcererTaunt2,
        idSheep,
        idRockElementalRally,
        idBarrackReady,
        idBarrackTaunt1,
        idBarrackTaunt2,
        idBarrackMove,
        idBarrackPaladinReady,
        idBarrackPaladinTaunt1,
        idBarrackPaladinTaunt2,
        idBarrackPaladinMove,
        idBarrackBarbarianReady,
        idBarrackBarbarianTaunt1,
        idBarrackBarbarianTaunt2,
        idBarrackBarbarianMove,
        idArtilleryReady,
        idArtilleryTaunt1,
        idArtilleryTaunt2,
        idArtilleryBfgReady,
        idArtilleryBfgTaunt1,
        idArtilleryBfgTaunt2,
        idArtilleryTeslaReady,
        idArtilleryTeslaTaunt1,
        idArtilleryTeslaTaunt2A,
        idArtilleryTeslaTaunt2B,
        idArtilleryTeslaTaunt2C,
        idReinforcementTaunt1,
        idReinforcementTaunt2,
        idReinforcementTaunt3,
        idReinforcementTaunt4,
        idElfTaunt1,
        idElfTaunt2,
        idSasquashRally,
        idSasquashReady,
        idJuggernautDeath,
        idJtAttack,
        idJtDeath,
        idJtEat,
        idJtExplode,
        idJtRest,
        idJtHitIce1,
        idJtHitIce2,
        idJtHitIce3,
        idVeznanDeath,
        idVeznanDemonFire,
        idVeznanToDemon,
        idVeznanHoldTrap,
        idVeznanHoldCast,
        idVeznanPortalSummon,
        idTowerUpgrade,
        idHeroThorTaunt1,
        idHeroThorTaunt2,
        idHeroThorTaunt3,
        idHeroThorTaunt4,
        idHeroThorDeath,
        idHeroThorElectricAttack,
        idHeroThorElectricalDeath,
        idHeroThorHammer,
        idHeroThorThunder,
        idHeroSamuraiTaunt1,
        idHeroSamuraiTaunt2,
        idHeroSamuraiTaunt3,
        idHeroSamuraiTaunt4,
        idHeroSamuraiDeath,
        idHeroSamuraiGroundSawblades,
        idHeroSamuraiDeathStrike,
        idHeroRobotTaunt1,
        idHeroRobotTaunt2,
        idHeroRobotTaunt3,
        idHeroRobotTaunt4,
        idHeroRobotDeath,
        idHeroRobotDrill,
        idHeroRobotShoot,
        idInfernoBossDeath,
        idInfernoBossHorns,
        idInfernoBossStomp,
        idMushroomBossGas,
        idMushroomBossDeath,
        idMushroomCreepDeath,
        idMushroomCreepNacimiento
    }
}

