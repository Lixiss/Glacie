﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Glacie.Targeting.Generic
{
    internal static class UnifiedRecordPathCaseFixer
    {
        private static readonly HashSet<string> s_path = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            // TQAE
            "Actor.tpl",
            "ActorHideable.tpl",
            "AmbientCharacter.tpl",
            "AmbientPak.tpl",
            "Apparatus.tpl",
            "AreaOfInterest.tpl",
            "Armor_Clothing.tpl",
            "Armor_Forearm.tpl",
            "Armor_Head.tpl",
            "Armor_LowerBody.tpl",
            "Armor_UpperBody.tpl",
            "Armor_Vestment.tpl",
            "AttributePak.tpl",
            "BandariTeleportPoint.tpl",
            "BonusSharing.tpl",
            "BossMusicPak.tpl",
            "BoundingVolume.tpl",
            "BoundingVolumeBossMonster.tpl",
            "BoundingVolumeBox.tpl",
            "BoundingVolumeChangePlaylists.tpl",
            "BoundingVolumeHeal.tpl",
            "BoundingVolumeLerpDaylight.tpl",
            "BoundingVolumeMultiple.tpl",
            "BoundingVolumeMusicEvent.tpl",
            "BoundingVolumeNpcNetwork.tpl",
            "BoundingVolumeSoundFxOneShot.tpl",
            "BoundingVolumeTimedEvent.tpl",
            "BoundingVolumeWind.tpl",
            "CasinoMerchantConf.tpl",
            "Cerberus.tpl",
            "CerberusGeyserMarker.tpl",
            "ChainLaserBeam.tpl",
            "ChaosBeam.tpl",
            "Character.tpl",
            "CharAnimationTable.tpl",
            "CharFxPak.tpl",
            "CharonGeyserMarker.tpl",
            "CombatEquations.tpl",
            "ControllerAI.tpl",
            "ControllerAktaios.tpl",
            "ControllerBandari.tpl",
            "ControllerBaseCharacter.tpl",
            "ControllerCerberus.tpl",
            "ControllerCharacter.tpl",
            "ControllerCyclops.tpl",
            "ControllerGraeae.tpl",
            "ControllerHades.tpl",
            "ControllerMegalesios.tpl",
            "ControllerMegalesiosConduit.tpl",
            "ControllerMegalesiosSpirit.tpl",
            "ControllerMonster.tpl",
            "ControllerMonsterHidden.tpl",
            "ControllerMonsterSynergy.tpl",
            "ControllerNpc.tpl",
            "ControllerNpc2.tpl",
            "ControllerNpcHerdAnimal.tpl",
            "ControllerNpcHerder.tpl",
            "ControllerOrmenos.tpl",
            "ControllerPlayer.tpl",
            "ControllerSpirit.tpl",
            "ControllerSpiritHost.tpl",
            "ControllerStationaryMonster.tpl",
            "ControllerTelkine.tpl",
            "ControllerTerracotta.tpl",
            "ControllerTyphon.tpl",
            "ControllerTyphonChained.tpl",
            "DbrArray.tpl",
            "Decal.tpl",
            "DecalType.tpl",
            "Decoration.tpl",
            "DialogPak.tpl",
            "DLCActorSpawner.tpl",
            "Doppelganger.tpl",
            "DummyItem.tpl",
            "DynamicBarrier.tpl",
            "DynGridEntrance.tpl",
            "DynGridExitOneWay.tpl",
            "Effect.tpl",
            "EndlessModeController.tpl",
            "EndlessModeModifier.tpl",
            "EndlessModeProxy.tpl",
            "Engine/Billboard.tpl",
            "Engine/GridEntrance.tpl",
            "Engine/GridSystem.tpl",
            "Engine/Light.tpl",
            "Engine/NightLight.tpl",
            "EventMusicPak.tpl",
            "ExperienceLevelControl.tpl",
            "FixedItemContainer.tpl",
            "FixedItemContainerTartarus.tpl",
            "FixedItemDoor.tpl",
            "FixedItemDoorSwapping.tpl",
            "FixedItemGravestone.tpl",
            "FixedItemLevelEquation.tpl",
            "FixedItemLoot.tpl",
            "FixedItemLootTartarus.tpl",
            "FixedItemQuestObject.tpl",
            "FixedItemShrine.tpl",
            "FixedItemSkill_Buff.tpl",
            "FixedItemSkill_SpawnMonster.tpl",
            "FixedItemTeleport.tpl",
            "FixedItemTyphonPortal.tpl",
            "FlyingBolt.tpl",
            "FontStyle.tpl",
            "FxMesh.tpl",
            "FxPak.tpl",
            "GameEngine.tpl",
            "GameRuleMapBinding.tpl",
            "GameRules.tpl",
            "GMIActor_Icy.tpl",
            "GoldGenerator.tpl",
            "GridEntranceDynamic.tpl",
            "GridExitOneWay.tpl",
            "Guard.tpl",
            "Hades.tpl",
            "HallOfFameCamera.tpl",
            "HallOfFameStand.tpl",
            "HealthManaRegen.tpl",
            "InGameUI/BarGraph.tpl",
            "InGameUI/BitmapSingle.tpl",
            "InGameUI/ButtonHidden.tpl",
            "InGameUI/ButtonHiddenText.tpl",
            "InGameUI/ButtonSkillTemplate.tpl",
            "InGameUI/ButtonStatic.tpl",
            "InGameUI/ButtonStaticText.tpl",
            "InGameUI/CaravanWindow.tpl",
            "InGameUI/CaravanWindowPrivate.tpl",
            "InGameUI/CaravanWindowPublic.tpl",
            "InGameUI/CaravanWindowRelicVault.tpl",
            "InGameUI/CasinoMerchantWindow.tpl",
            "InGameUI/CharacterWindow.tpl",
            "InGameUI/CharStatsTab1 AE.tpl",
            "InGameUI/CharStatsTab1.tpl",
            "InGameUI/CharStatsTab2 AE.tpl",
            "InGameUI/CharStatsTab2.tpl",
            "InGameUI/CharStatsTab3.tpl",
            "InGameUI/ChatWindow.tpl",
            "InGameUI/ColorPulse.tpl",
            "InGameUI/CombinedArmorRolloverWindow.tpl",
//            "InGameUI/copy of bitmapsingle.tpl", // need remove this.
            "InGameUI/DetailMapWindow.tpl",
            "InGameUI/EditBox.tpl",
            "InGameUI/ElasticWidget.tpl",
            "InGameUI/EnchanterArtifactBox.tpl",
            "InGameUI/EnchanterArtifactTab.tpl",
            "InGameUI/EnchanterItemBox.tpl",
            "InGameUI/EnchanterReagentBox.tpl",
            "InGameUI/EnchanterRecoveryTab.tpl",
            "InGameUI/EnchanterWindow.tpl",
            "InGameUI/ExitWindow.tpl",
            "InGameUI/FlexibleBorders.tpl",
            "InGameUI/GamepadButtonsDescriptionBox.tpl",
            "InGameUI/HotSlotButton.tpl",
            "InGameUI/Hud.tpl",
            "InGameUI/HudCompass.tpl",
            "InGameUI/HudOptions.tpl",
            "InGameUI/HudPlayerStatusIcons.tpl",
            "InGameUI/HudPortraitAndStatsSummary.tpl",
            "InGameUI/HudStatus.tpl",
            "InGameUI/HudToolbar.tpl",
            "InGameUI/Includes/Border.tpl",
            "InGameUI/Includes/Ext2.tpl",
            "InGameUI/Includes/Rect.tpl",
            "InGameUI/Includes/StringRollover.tpl",
            "InGameUI/Includes/TextBoxBase.tpl",
            "InGameUI/Includes/Vec2.tpl",
            "InGameUI/Includes/WidgetPane.tpl",
            "InGameUI/Includes/WidgetWindow.tpl",
            "InGameUI/InGameUI.tpl",
            "InGameUI/InventoryGrid.tpl",
            "InGameUI/InventoryWindow.tpl",
            "InGameUI/ItemBox.tpl",
            "InGameUI/ItemBoxHand.tpl",
            "InGameUI/ItemSpawnWindow.tpl",
            "InGameUI/MarketInventoryGrid.tpl",
            "InGameUI/MarketWindow.tpl",
            "InGameUI/MasteryPane.tpl",
            "InGameUI/MasteryTabPrimary.tpl",
            "InGameUI/MasteryTabSecondary.tpl",
            "InGameUI/MiniMapWindow.tpl",
            "InGameUI/NpcDialogWindow.tpl",
            "InGameUI/PartyListBox.tpl",
            "InGameUI/PickTemplate.tpl",
            "InGameUI/PotionBox.tpl",
            "InGameUI/PotionSlot.tpl",
            "InGameUI/QuestJournalEntryTab.tpl",
            "InGameUI/QuestJournalListWindow.tpl",
            "InGameUI/QuestLogDialogTab.tpl",
            "InGameUI/QuestLogSummaryTab.tpl",
            "InGameUI/QuestMap.tpl",
            "InGameUI/QuestMapMarker.tpl",
            "InGameUI/QuestWindow.tpl",
            "InGameUI/QuestWindowTab.tpl",
            "InGameUI/RolloverOptions.tpl",
            "InGameUI/RolloverStyle.tpl",
            "InGameUI/RolloverStyleGroundItems.tpl",
            "InGameUI/RolloverStyleUIHelp.tpl",
            "InGameUI/SceneView.tpl",
            "InGameUI/ScrollableWindow.tpl",
            "InGameUI/ScrollBar.tpl",
            "InGameUI/SkillButton.tpl",
            "InGameUI/SkillButtonSlot.tpl",
            "InGameUI/SkillPaneBase.tpl",
            "InGameUI/SkillPaneCtrl.tpl",
            "InGameUI/SkillsWindow.tpl",
            "InGameUI/SkillTabCtrl.tpl",
            "InGameUI/SlotConfigWindow.tpl",
            "InGameUI/SlotSelectWindow.tpl",
            "InGameUI/TartarusBuffsWidget.tpl",
            "InGameUI/TartarusHelperUI.tpl",
            "InGameUI/TartarusUI.tpl",
            "InGameUI/TextBox.tpl",
            "InGameUI/TextBoxMeasureable.tpl",
            "InGameUI/TextListTree.tpl",
            "InGameUI/TextNumber.tpl",
            "InGameUI/TextOneShot.tpl",
            "InGameUI/TextStaticString.tpl",
            "InGameUI/TextString.tpl",
            "InGameUI/TextWindow.tpl",
            "InGameUI/TradeWindow.tpl",
            "InGameUI/UIArtifactReagent.tpl",
            "InGameUI/UICasinoMerchantWidget.tpl",
            "InGameUI/UIInspectItem.tpl",
            "InGameUI/UIItemUpgradeWidget.tpl",
            "InGameUI/UITutorialPage.tpl",
            "InGameUI/UITutorialPageInstance.tpl",
            "InGameUI/UITutoriaNugget.tpl",
            "InGameUI/UItutoriaNuggetPlus.tpl",
            "InGameUI/UpgradeItemBox.tpl",
            "InGameUI/UpgradeItemWindow.tpl",
            "InGameUI/WidgetBackground.tpl",
            "InGameUI/WorldLMapWindow.tpl",
            "InGameUI/WorldMapInstance.tpl",
            "InGameUI/ZoneCommon.tpl",
            "ItemArtifact.tpl",
            "ItemArtifactFormula.tpl",
            "ItemCharm.tpl",
            "ItemCost.tpl",
            "ItemRecipe.tpl",
            "ItemRelic.tpl",
            "ItemSet.tpl",
            "ItemUpgrade.tpl",
            "ItemUpgradeConf.tpl",
            "Jewelry_Amulet.tpl",
            "Jewelry_Bracelet.tpl",
            "Jewelry_Ring.tpl",
            "JukeBox.tpl",
            "LevelParameters.tpl",
            "Lightning.tpl",
            "LightOfRaMarker.tpl",
            "LootItemTable_DynWeight.tpl",
            "LootItemTable_FixedWeight.tpl",
            "LootMasterTable.tpl",
            "LootRandomizer.tpl",
            "LootRandomizerTable.tpl",
            "LootTable.tpl",
            "Market.tpl",
            "MarketLevelEquation.tpl",
            "Megalesios.tpl",
            "MegalesiosConduit.tpl",
            "Menu/MenuWindow.tpl",
            "MenuLight.tpl",
            "MenuScene.tpl",
            "MenuSound.tpl",
            "MerchantDialogPak.tpl",
            "Monster.tpl",
            "MonsterIconSet.tpl",
            "Mount.tpl",
            "MountedActor.tpl",
            "MusicPak.tpl",
            "NoiseTexture.tpl",
            "NotificationManager.tpl",
            "Npc.tpl",
            "NpcCaravan.tpl",
            "NpcCasinoMerchant.tpl",
            "NpcConversation.tpl",
            "NpcConversationPak.tpl",
            "NpcEnchanter.tpl",
            "NpcItemUpgrader.tpl",
            "NpcMerchant.tpl",
            "NpcSkillReallocator.tpl",
            "NpcTartarusHelper.tpl",
            "NpcTrafficNode.tpl",
            "NpcWanderPoint.tpl",
            "OneShot.tpl",
            "OneShot_Dye.tpl",
            "OneShot_Gold.tpl",
            "OneShot_InstantReward.tpl",
            "OneShot_PotionHealth.tpl",
            "OneShot_PotionMana.tpl",
            "OneShot_Sack.tpl",
            "OneShot_Scroll.tpl",
            "Ormenos.tpl",
            "OrmenosDropZone.tpl",
            "Parchment.tpl",
            "ParticleSystem.tpl",
            "PartyWindow.tpl",
            "PatrolPoint.tpl",
            "Pet.tpl",
            "PetBonus.tpl",
            "PetNonScaling.tpl",
            "Player.tpl",
            "PlayerHorse.tpl",
            "PlayerSpawnPoint.tpl",
            "PlayStats.tpl",
            "ProjectileAreaEffect.tpl",
            "ProjectileArrowLike.tpl",
            "ProjectileExploding.tpl",
            "ProjectileFireballLike.tpl",
            "ProjectileGrenade.tpl",
            "ProjectileMine.tpl",
            "ProjectileTelekinesis.tpl",
            "ProjectileTerrainFollowing.tpl",
            "Prop.tpl",
            "Proxy.tpl",
            "ProxyAccessoryPool.tpl",
            "ProxyAmbush.tpl",
            "ProxyEquation.tpl",
            "ProxyLimits.tpl",
            "ProxyPool.tpl",
            "ProxyPoolEquation.tpl",
            "Puppet.tpl",
            "Quest.tpl",
            "QuestAction_GiveBonus.tpl",
            "QuestAction_GiveItem.tpl",
            "QuestAction_SpawnObject.tpl",
            "QuestAction_TakeItem.tpl",
            "QuestDecoration.tpl",
            "QuestItem.tpl",
            "QuestLocation.tpl",
            "Quests.tpl",
            "QuestStep_ContactNpc.tpl",
            "QuestStep_EnterRegion.tpl",
            "QuestStep_MonsterDeath.tpl",
            "QuestStep_PickUpItem.tpl",
            "QuestStep_QuestObject.tpl",
            "QuestStep_Timer.tpl",
            "QuestStep_TouchItem.tpl",
            "QuestStep_Unconditional.tpl",
            "QuestStep_UserInfo.tpl",
            "QuestTask.tpl",
            "RadiusMagic.tpl",
            "ReferencePoint.tpl",
            "ReferencePointDebug.tpl",
            "RenderGroupManager.tpl",
            "RenderGroupNode.tpl",
            "RespawnPoint.tpl",
            "RolloverLine1.tpl",
            "RolloverLine2.tpl",
            "RolloverLine3.tpl",
            "RolloverLine4.tpl",
            "RolloverLine5.tpl",
            "RolloverLine6.tpl",
            "ScriptPoint.tpl",
            "SkillAutoCastController.tpl",
            "SkillBuff_BuffImmobilize.tpl",
            "SkillBuff_Contageous.tpl",
            "SkillBuff_Debuf.tpl",
            "SkillBuff_DebufFreeze.tpl",
            "SkillBuff_DebufTrap.tpl",
            "SkillBuff_Passive.tpl",
            "SkillBuff_Passive2.tpl",
            "SkillBuff_PassiveDebuff.tpl",
            "SkillBuff_PassiveShield.tpl",
            "SkillGodBeam.tpl",
            "SkillLocation.tpl",
            "SkillSecondary_AttackRadius.tpl",
            "SkillSecondary_Bonus.tpl",
            "SkillSecondary_BuffRadius.tpl",
            "SkillSecondary_ChainBonus.tpl",
            "SkillSecondary_ChainLightning.tpl",
            "SkillSecondary_ForkLightning.tpl",
            "SkillSecondary_PetModifier.tpl",
            "SkillSecondary_PetSpawn.tpl",
            "SkillTree.tpl",
            "Skill_AktaiosLightOfRa.tpl",
            "Skill_AktaiosMirage.tpl",
            "Skill_AllPetAttack.tpl",
            "Skill_AttackBuff.tpl",
            "Skill_AttackBuffRadius.tpl",
            "Skill_AttackChain.tpl",
            "Skill_AttackInherent.tpl",
            "Skill_AttackProjectile.tpl",
            "Skill_AttackProjectileAreaEffect.tpl",
            "Skill_AttackProjectileBurst.tpl",
            "Skill_AttackProjectileDebuf.tpl",
            "Skill_AttackProjectileFan.tpl",
            "Skill_AttackProjectileMultiHit.tpl",
            "Skill_AttackProjectileRing.tpl",
            "Skill_AttackProjectileSpawnPet.tpl",
            "Skill_AttackRadius.tpl",
            "Skill_AttackRadiusLightning.tpl",
            "Skill_AttackSpell.tpl",
            "Skill_AttackSpellChaos.tpl",
            "Skill_AttackSpellTeleport.tpl",
            "Skill_AttackSpellTeleportSelf.tpl",
            "Skill_AttackTelekinesis.tpl",
            "Skill_AttackWave.tpl",
            "Skill_AttackWeapon.tpl",
            "Skill_AttackWeaponBlink.tpl",
            "Skill_AttackWeaponCharge.tpl",
            "Skill_AttackWeaponRangedSpread.tpl",
            "Skill_BuffAttackRadiusDuration.tpl",
            "Skill_BuffAttackRadiusToggled.tpl",
            "Skill_BuffEffect.tpl",
            "Skill_BuffOther.tpl",
            "Skill_BuffRadius.tpl",
            "Skill_BuffRadiusToggled.tpl",
            "Skill_BuffSelfColossus.tpl",
            "Skill_BuffSelfDuration.tpl",
            "Skill_BuffSelfImmoblize.tpl",
            "Skill_BuffSelfInvulnerable.tpl",
            "Skill_BuffSelfShield.tpl",
            "Skill_BuffSelfToggled.tpl",
            "Skill_CerberusGeysers.tpl",
            "Skill_CharonGeysers.tpl",
            "Skill_DefensiveGround.tpl",
            "Skill_DefensiveProjectileGroundRing.tpl",
            "Skill_DefensiveWall.tpl",
            "Skill_DispelMagic.tpl",
            "Skill_DropProjectileTelekinesis.tpl",
            "Skill_E3FauxAttack.tpl",
            "Skill_GiveBonus.tpl",
            "Skill_Mastery.tpl",
            "Skill_MeleeModifierRadius.tpl",
            "Skill_Modifier.tpl",
            "Skill_MonsterGenerator.tpl",
            "Skill_OnDeathSpawnActor.tpl",
            "Skill_OnHitAttackRadius.tpl",
            "Skill_OnHitBuffSelf.tpl",
            "Skill_OrmenosChainLaser.tpl",
            "Skill_Passive.tpl",
            "Skill_PassiveDualWieldWeapon.tpl",
            "Skill_PassiveOnHitBuffSelf.tpl",
            "Skill_PassiveOnLifeBuffSelf.tpl",
            "Skill_PassiveShield.tpl",
            "Skill_PlayAttackAnimation.tpl",
            "Skill_ProjectileModifier.tpl",
            "Skill_RefreshCooldown.tpl",
            "Skill_SpawnMegalesiosSpirit.tpl",
            "Skill_SpawnPet.tpl",
            "Skill_SpawnPetMonster.tpl",
            "Skill_SpawnQuestPet.tpl",
            "Skill_Teleport.tpl",
            "Skill_TurretFireControl.tpl",
            "Skill_TyphonSkillTransfer.tpl",
            "Skill_WeaponPool_Basic.tpl",
            "Skill_WeaponPool_ChargedFinale.tpl",
            "Skill_WeaponPool_ChargedLinear.tpl",
            "Skill_WeaponPool_Default.tpl",
            "Skill_WeaponPool_WarmUp.tpl",
            "Skill_WPAttack_BasicAttack.tpl",
            "Skill_WPAttack_Melee.tpl",
            "Skill_WPAttack_Ranged.tpl",
            "SoundObject.tpl",
            "SoundPak.tpl",
            "SpecialCharHandler_FadeAwayFromPlayer.tpl",
            "SpecialCharHandler_FadeNearPlayer.tpl",
            "SpecialCharHandler_Freeze.tpl",
            "SpiritHost.tpl",
            "StrategicMovementMarker.tpl",
            "StrategicMovementRespawnShrine.tpl",
            "StrategicMovementTeleportShrine.tpl",
            "TeamRespawnPoint.tpl",
            "TemplateBase/AmbientCharacterSkillManager.tpl",
            "TemplateBase/Armor.tpl",
            "TemplateBase/Bonus.tpl",
            "TemplateBase/CharacterBio.tpl",
            "TemplateBase/CharacterLoot.tpl",
            "TemplateBase/CombatManager.tpl",
            "TemplateBase/DoppelgangerLoot.tpl",
            "TemplateBase/DoppelSkillManager.tpl",
            "TemplateBase/FixedItem.tpl",
            "TemplateBase/FixedItemSkill_Base.tpl",
            "TemplateBase/GameText.tpl",
            "TemplateBase/GMIActor.tpl",
            "TemplateBase/ItemBase.tpl",
            "TemplateBase/ItemEquipment.tpl",
            "TemplateBase/ItemSkillAugment.tpl",
            "TemplateBase/LootItemTableRandomizer.tpl",
            "TemplateBase/MonsterSkillManager.tpl",
            "TemplateBase/OneShot.tpl",
            "TemplateBase/ParametersOffensive.tpl",
            "TemplateBase/Parameters_Character.tpl",
            "TemplateBase/Parameters_Defensive.tpl",
            "TemplateBase/Parameters_Offensive.tpl",
            "TemplateBase/Parameters_Retaliation.tpl",
            "TemplateBase/Parameters_Skill.tpl",
            "TemplateBase/Parameters_WeaponBonusOffensive.tpl",
            "TemplateBase/PetBonusInc.tpl",
            "TemplateBase/ProjectileBase.tpl",
            "TemplateBase/ProjectileTrapBase.tpl",
            "TemplateBase/ProjectileTrapLauncherBase.tpl",
            "TemplateBase/QuestStep.tpl",
            "TemplateBase/RacialBonus.tpl",
            "TemplateBase/RadiusEffect.tpl",
            "TemplateBase/Reward.tpl",
            "TemplateBase/SkillBuff.tpl",
            "TemplateBase/SkillManager.tpl",
            "TemplateBase/Skill_Activated.tpl",
            "TemplateBase/Skill_Attack.tpl",
            "TemplateBase/Skill_Base.tpl",
            "TemplateBase/Skill_Bonus.tpl",
            "TemplateBase/Skill_Buff.tpl",
            "TemplateBase/Skill_Cast.tpl",
            "TemplateBase/Skill_Charge.tpl",
            "TemplateBase/Skill_Lightning.tpl",
            "TemplateBase/Skill_OnHit.tpl",
            "TemplateBase/Skill_PassiveLE.tpl",
            "TemplateBase/Skill_PassiveModifier.tpl",
            "TemplateBase/Skill_ProjectileBase.tpl",
            "TemplateBase/Skill_Radius.tpl",
            "TemplateBase/Skill_Secondary.tpl",
            "TemplateBase/Skill_Spawning.tpl",
            "TemplateBase/Skill_Spell.tpl",
            "TemplateBase/Skill_WarmUp.tpl",
            "TemplateBase/Skill_WPAttack.tpl",
            "TemplateBase/StrategicMovementBase.tpl",
            "TemplateBase/Timer.tpl",
            "TemplateBase/Weapon.tpl",
            "TerrainType.tpl",
            "Tile.tpl",
            "TrailEffect.tpl",
            "Trigger.tpl",
            "Turret.tpl",
            "Typhon.tpl",
            "Typhon2.tpl",
            "TyphonChained.tpl",
            "TyphonChains.tpl",
            "TyphonStatue.tpl",
            "UI Templates/Hud.tpl",
            "UI Templates/SkillWindow.tpl",
            "UIDialogManager.tpl",
            "UnlockCode.tpl",
            "WaterInteraction.tpl",
            "WaterType.tpl",
            "WeaponArmor_Shield.tpl",
            "WeaponEnchantmentPak.tpl",
            "WeaponTrail.tpl",
            "Weapon_Axe.tpl",
            "Weapon_Bow.tpl",
            "Weapon_Mace.tpl",
            "Weapon_RangedOneHand.tpl",
            "Weapon_Spear.tpl",
            "Weapon_Staff.tpl",
            "Weapon_Sword.tpl",
            "Zone.tpl",

            // GD
            "Achievement.tpl",
            "AchievementGroup.tpl",
            "AreaTrigger.tpl",
            "Armor_Chest.tpl",
            "Armor_Feet.tpl",
            "Armor_Hands.tpl",
            "Armor_Legs.tpl",
            "Armor_Shoulders.tpl",
            "Armor_Waist.tpl",
            "BindingInteractable.tpl",
            "BoxTrigger.tpl",
            "ChallengeArea.tpl",
            "CharacterAttributeEquations.tpl",
            "CharacterEnemy.tpl",
            "CharacterHookPack.tpl",
            "ChatterPack.tpl",
            "ChestHookPack.tpl",
            "Climate.tpl",
            "ClimateSystem.tpl",
            "ControllerTotem.tpl",
            "Conversation.tpl",
            "CriticalResources.tpl",
            "Destructible.tpl",
            "DestructibleHookPack.tpl",
            "DevotionSkillTree.tpl",
            "DoorHookPack.tpl",
            "DungeonEntrance.tpl",
            "DynamicTeleporter.tpl",
            "EndlessBuffShrine.tpl",
            "EndlessDungeonEntrance.tpl",
            "EndlessDungeonExit.tpl",
            "EndlessDungeonFloor.tpl",
            "EndlessDungeonGenerator.tpl",
            "EnemyAttributeEquations.tpl",
            "Engine/DayNightLight.tpl",
            "Engine/FireLight.tpl",
            "Engine/FlickerLight.tpl",
            "Engine/LightRig.tpl",
            "Engine/PulseLight.tpl",
            "Entity.tpl",
            "EntityHookPack.tpl",
            "FactionMarket.tpl",
            "FactionPack.tpl",
            "FactionTier.tpl",
            "FixedDoor.tpl",
            "FixedItemBlastContainer.tpl",
            "FixedItemDoorX.tpl",
            "FixedLever.tpl",
            "Floater.tpl",
            "GameAdjustment.tpl",
            "Gib.tpl",
            "GibEffectEntity.tpl",
            "Hireling.tpl",
            "InGameUI/AchievementWindow.tpl",
            "InGameUI/BarGraphAnimated.tpl",
            "InGameUI/BitmapMulti.tpl",
            "InGameUI/ButtonMultistate.tpl",
            "InGameUI/ButtonStaticText2.tpl",
            "InGameUI/ChallengeAreaHud.tpl",
            "InGameUI/CharStatsTab4.tpl",
            "InGameUI/CheckBox.tpl",
            "InGameUI/CodexJournal.tpl",
            "InGameUI/CodexLog.tpl",
            "InGameUI/CodexLogTree.tpl",
            "InGameUI/ConversationWindow.tpl",
            "InGameUI/DevotionButton.tpl",
            "InGameUI/DevotionConstellation.tpl",
            "InGameUI/DevotionJournal.tpl",
            "InGameUI/DevotionPane.tpl",
            "InGameUI/EnchanterConvertTab.tpl",
            "InGameUI/EnchanterDismantleTab.tpl",
            "InGameUI/EnchanterTinkerTab.tpl",
            "InGameUI/EndlessHud.tpl",
            "InGameUI/FactionsWindow.tpl",
            "InGameUI/GamepadHud.tpl",
            "InGameUI/GamepadHudWindow.tpl",
            "InGameUI/HelpIndex.tpl",
            "InGameUI/HelpIndexTree.tpl",
            "InGameUI/HelpPage.tpl",
            "InGameUI/HirelingWindow.tpl",
            "InGameUI/Includes/StringRollover2Tags.tpl",
            "InGameUI/InfoIconPane.tpl",
            "InGameUI/LootFilterWindow.tpl",
            "InGameUI/MapWindow.tpl",
            "InGameUI/NetworkAddressWindow.tpl",
            "InGameUI/ObjectiveWindow.tpl",
            "InGameUI/Quest2Journal.tpl",
            "InGameUI/Quest2Log.tpl",
            "InGameUI/Quest2LogTree.tpl",
            "InGameUI/Quest2Window.tpl",
            "InGameUI/QuestOverview.tpl",
            "InGameUI/QuestRewardIcon.tpl",
            "InGameUI/QuestRewardWindow.tpl",
            "InGameUI/QuestWidget.tpl",
            "InGameUI/ShrineWindow.tpl",
            "InGameUI/SimpleRollover.tpl",
            "InGameUI/SkillWheelWindow.tpl",
            "InGameUI/SpeechWindow.tpl",
            "InGameUI/StackWindow.tpl",
            "InGameUI/SurvivalPane.tpl",
            "InGameUI/TransmuterItemBox.tpl",
            "InGameUI/TransmuterWindow.tpl",
            "InGameUI/TutorialTrigger.tpl",
            "InGameUI/UIActorDescription.tpl",
            "InGameUI/UIWorldActorDescription.tpl",
            "InGameUI/WorldMapSection.tpl",
            "InGameUI/WorldMapWindow.tpl",
            "InteractableHookPack.tpl",
            "ItemAttributeReset.tpl",
            "ItemDevotionReset.tpl",
            "ItemDifficultyUnlock.tpl",
            "ItemEnchantment.tpl",
            "ItemFactionBooster.tpl",
            "ItemFactionWarrant.tpl",
            "ItemHookPack.tpl",
            "ItemNote.tpl",
            "ItemRandomSetFormula.tpl",
            "ItemSetFormula.tpl",
            "ItemTransmuter.tpl",
            "ItemTransmuterSet.tpl",
            "ItemUsableSkill.tpl",
            "Jewelry_Medal.tpl",
            "LevelTable.tpl",
            "Lightning2.tpl",
            "LineEffect2.tpl",
            "LootItemTable_DynItemList.tpl",
            "LootItemTable_DynWeighted_DynAffix.tpl",
            "LootRandomizerTableDynamic.tpl",
            "Menu/MenuConstants.tpl",
            "Menu/MenuGDX2Logo.tpl",
            "Menu/MenuParticleSystem.tpl",
            "MonsterPortal.tpl",
            "MonsterShrine.tpl",
            "MonsterSpawner.tpl",
            "Mutator.tpl",
            "MutatorPak.tpl",
            "NavBlocker.tpl",
            "NpcCrafter.tpl",
            "NpcTransmuter.tpl",
            "OneShot_EndlessDungeon.tpl",
            "OneShot_Food.tpl",
            "PetPlayerScaling.tpl",
            "PhysicsDecoration.tpl",
            "PointDisturbance.tpl",
            "PointTrigger.tpl",
            "ProjectileBoomerang.tpl",
            "ProjectileChain.tpl",
            "ProjectileHoming.tpl",
            "ProjectileInverse.tpl",
            "ProjectileOrbiting.tpl",
            "ProjectileSpark.tpl",
            "ProxyEndless.tpl",
            "ProxyHookPack.tpl",
            "ProxyLevelVarianceEquation.tpl",
            "ProxyMenu.tpl",
            "Punctuation.tpl",
            "QuestMarker.tpl",
            "RacialProfile.tpl",
            "RolloverLine7.tpl",
            "RolloverLine8.tpl",
            "Rubble.tpl",
            "ScriptEntity.tpl",
            "SetPiece.tpl",
            "SetPiecePart.tpl",
            "SetPiecePool.tpl",
            "ShrineHookPack.tpl",
            "ShrineIcon.tpl",
            "Skill_AttackLine.tpl",
            "Skill_AttackPathCharge.tpl",
            "Skill_AttackProjectileChain.tpl",
            "Skill_AttackProjectileDrop.tpl",
            "Skill_AttackProjectileOrbiting.tpl",
            "Skill_AttackRadiusDisengage.tpl",
            "Skill_AttackRadiusLeap.tpl",
            "Skill_AttackRadiusLightning2.tpl",
            "Skill_AttackRadiusLightningSpawnPet.tpl",
            "Skill_AttackRadiusSpin.tpl",
            "Skill_AttackRadiusTeleport.tpl",
            "Skill_AttackSpellBeam.tpl",
            "Skill_AttackSpellChaosSpawnPet.tpl",
            "Skill_AttackSpellCone.tpl",
            "Skill_AttackSpellDrain.tpl",
            "Skill_AttackSpellReflectLink.tpl",
            "Skill_AttackWeaponRadius.tpl",
            "Skill_BuffAttackRadiusDrop.tpl",
            "Skill_BuffAttackRadiusLightning.tpl",
            "Skill_BuffSelfSick.tpl",
            "Skill_ChargedBuffOther.tpl",
            "Skill_DefensiveLine.tpl",
            "Skill_Kick.tpl",
            "Skill_Move.tpl",
            "Skill_PassiveEquation.tpl",
            "Skill_PassiveOnCritBuffSelf.tpl",
            "Skill_PassiveOnHitBuffShield.tpl",
            "Skill_PetAttack.tpl",
            "Skill_ProjectileTransmuter.tpl",
            "Skill_RefreshCooldownModifier.tpl",
            "Skill_SpawnMiniPet.tpl",
            "Skill_SpawnPetTransmuter.tpl",
            "Skill_Suicide.tpl",
            "Skill_TargetedSpawnPet.tpl",
            "Skill_Transmuter.tpl",
            "Skill_WeaponPool_ChargedScaling.tpl",
            "Skill_WPAttack_AttackWave.tpl",
            "Skill_WPAttack_ProjectileBurst.tpl",
            "Skill_WPAttack_RadialCrit.tpl",
            "SkillBuff_DebufRadius.tpl",
            "SkillBuff_PassiveCharged.tpl",
            "SkillBuff_PassiveEndless.tpl",
            "SkillChanneled.tpl",
            "SkillSecondary_AttackProjectileAreaEffect.tpl",
            "SkillSecondary_AttackProjectileOrbiting.tpl",
            "SkillSecondary_BuffAttackRadiusDuration.tpl",
            "SkillSecondary_BuffSelfDuration.tpl",
            "SkillSecondary_OnHitBuffRadius.tpl",
            "SkillSecondary_OnKillAttackRadius.tpl",
            "SkillSecondary_Tether.tpl",
            "Skybox.tpl",
            "SpawnedDecoration.tpl",
            "SpawnedWeatherDecoration.tpl",
            "SpawnOnDeathPool.tpl",
            "StaticRespawner.tpl",
            "StaticShrine.tpl",
            "StaticTeleporter.tpl",
            "TemplateBase/CharacterBioEnemy.tpl",
            "TemplateBase/FixedActor.tpl",
            "TemplateBase/ItemSkillModifiers.tpl",
            "TemplateBase/LootContainer.tpl",
            "TemplateBase/LootItemTable_DynAffixTable.tpl",
            "TemplateBase/NpcSkillManager.tpl",
            "TemplateBase/Parameters_CharacterEquation.tpl",
            "TemplateBase/Parameters_Conversion.tpl",
            "TemplateBase/Skill_PassiveModifierEquation.tpl",
            "TerrainDecoration.tpl",
            "Weapon_Axe2H.tpl",
            "Weapon_Dagger.tpl",
            "Weapon_Mace2H.tpl",
            "Weapon_OffHand.tpl",
            "Weapon_Ranged1H.tpl",
            "Weapon_Ranged2H.tpl",
            "Weapon_Scepter.tpl",
            "Weapon_Sword2H.tpl",
            "WeatherDecoration.tpl",
            "WeatherManager.tpl",
            "WeatherSystem.tpl",
        };

        public static bool TryMapValue(Path path, [NotNullWhen(true)] out Path result)
        {
            var normalized = path.Convert(
                PathConversions.Relative
                | PathConversions.Strict
                | PathConversions.Normalized
                | PathConversions.DirectorySeparator);

            if (s_path.TryGetValue(normalized.ToString(), out var mappedValue))
            {
                // Allow only fixing case.
                DebugCheck.That(string.Equals(path.ToString(), mappedValue, StringComparison.OrdinalIgnoreCase));

                result = Path.Implicit(mappedValue);
                return true;
            }
            else
            {
                result = path;
                return false;
            }
        }
    }
}
