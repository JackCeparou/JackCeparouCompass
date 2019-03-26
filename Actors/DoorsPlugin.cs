// ActorSnoEnum conversion by DysfunctionaI
namespace Turbo.Plugins.Jack.Actors
{
    using SharpDX.DirectInput;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class DoorsPlugin : BasePlugin, IInGameWorldPainter, IKeyEventHandler
    {
        public WorldDecoratorCollection DoorsDecorators { get; set; }
        public WorldDecoratorCollection BreakablesDoorsDecorators { get; set; }
        public WorldDecoratorCollection BridgesDecorators { get; set; }

        public WorldDecoratorCollection DebugDecorators { get; set; }

        public string GroundSymbol { get; set; }

        public bool ShowInTown { get; set; }
        public bool GroundLabelsOnScreen { get; set; }

        public bool Debug { get; set; }
        public bool DebugEnabled { get; set; }
        public IKeyEvent ToggleKeyEvent { get; set; }

        public Key HotKey
        {
            get => ToggleKeyEvent.Key;
            set => ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, value, false, false, false);
        }

        public readonly HashSet<ActorSnoEnum> BridgesIds = new HashSet<ActorSnoEnum>
        {
            ActorSnoEnum._x1_westm_bridge,
            ActorSnoEnum._a3dun_keep_siegetowerdoor_a,
            ActorSnoEnum._x1_westm_bridge_scoundrel,
            ActorSnoEnum._a3dun_keep_bridge_icy
        };
        public readonly HashSet<ActorSnoEnum> BreakableDoorsIds = new HashSet<ActorSnoEnum>
        {
            ActorSnoEnum._a3dun_keep_door_destructable,
            ActorSnoEnum._p4_ruins_frost_breakable_door,
            ActorSnoEnum._trdun_cath_wooddoor_a_barricaded,
            ActorSnoEnum._a1dun_leor_jail_door_breakable_a,
            ActorSnoEnum._p1_cesspools_door_breakable,
            ActorSnoEnum._a1dun_leor_jail_door_breakable_a,
            ActorSnoEnum._cemetary_gate_trout_wilderness_no_lock,
        }; // ActorSnoEnum._uber_bossportal_door };
        public readonly HashSet<ActorSnoEnum> DoorsIdsBlackList = new HashSet<ActorSnoEnum>() {
            ActorSnoEnum._cald_merchant_cart, // A2 to belial
			ActorSnoEnum._a2dun_cald_exit_gate, // A2 to belial
			ActorSnoEnum._a2dunswr_gates_causeway_gates_non_op, // A2 to belial
			ActorSnoEnum._a2dun_cald_belial_acid_attack, // A2 to belial
			ActorSnoEnum._a2dun_cald_belial_room_gate_a, // A2 to belial
            ActorSnoEnum._trout_cultists_summoning_portal_b, // A2 Alcarnus
            ActorSnoEnum._caout_target_dummy, // A2 City
			ActorSnoEnum._start_location_team_0, // A2 City
            ActorSnoEnum._a3dun_crater_st_demon_chainpylon_fire_azmodan, // A3 rakkis crossing
			ActorSnoEnum._a3dun_keep_bridge, // A3 rakkis crossing
            ActorSnoEnum._a3dun_rmpt_frozendoor_a, // A3 stonefort
            ActorSnoEnum._catapult_a3dunkeep_warmachines_snow_firing, // A3 battlefields
            ActorSnoEnum._x1_crusader_trebuchet_pending_tar,
            ActorSnoEnum._event_1000monster_portal,
            ActorSnoEnum._a2dun_zolt_sandbridgebase_bossfight,
            ActorSnoEnum._px_highlands_camp_resurgentcult_portal,
            ActorSnoEnum._x1_bog_catacombsportal_beaconloc,
            ActorSnoEnum._x1_malthael_boss_orb_collapse, // malthael fight
            ActorSnoEnum._caout_oasis_mine_entrance_a, // check this one, maybe a bounty
            ActorSnoEnum._trout_leor_painting, // leoric manor
            ActorSnoEnum._a4dun_sigil_room_platform_a, // Holy Sanctum
            ActorSnoEnum._a3dun_rmpt_catapult_follower_event_gate, // a3 catapult event
            ActorSnoEnum._a1dun_leor_jail_door_superlocked_a_fake,
            ActorSnoEnum._cos_pet_mimic_01,
            ActorSnoEnum._shoulderpads_norm_base_flippy, // ???
            ActorSnoEnum._x1_abattoir_barricade_solid,
            ActorSnoEnum._x1_fortress_floatrubble_a,
            ActorSnoEnum._a3dun_keep_barrel_snow_no_skirt, // Sturdy Barrel
            ActorSnoEnum._x1_fortress_crystal_prison_shield,
            ActorSnoEnum._x1_westm_railing_a_01_piece1,
            ActorSnoEnum._x1_pand_hexmaze_corpse, // Corpse
            ActorSnoEnum._dh_companion_runec,
            ActorSnoEnum._loottype2_tristramvillager_male_c_corpse_01, // Dead Villager
            ActorSnoEnum._uber_bossworld3_st_demon_chainpylon_fire_azmodan, // uber realm
            ActorSnoEnum._trdun_crypt_skeleton_king_throne_parts, // uber realm
            ActorSnoEnum._double_crane_a_caout_miningevent_chest_minievent, // A2 howling plateau event
            ActorSnoEnum._p6_church_bloodchannel_a, // A2 Temple of Unborn 1
            ActorSnoEnum._a4dun_sigil_tile_invis_wall, // A4 Bounty "Watch Your Step"
            ActorSnoEnum._p1_tgoblin_gate, // Greed door
            ActorSnoEnum._p1_tgoblin_vault_door, // Vault door
            ActorSnoEnum._x1_urzael_soundspawner, // Urzael fight
            ActorSnoEnum._x1_urzael_soundspawner_02, // Urzael fight
            ActorSnoEnum._x1_urzael_soundspawner_03, // Urzael fight
            ActorSnoEnum._x1_urzael_soundspawner_04, // Urzael fight
        };

        public DoorsPlugin()
        {
            Enabled = true;
            Debug = false;
            DebugEnabled = true;
            ShowInTown = false;
            GroundLabelsOnScreen = false;
            GroundSymbol = "\uD83D\uDEAA"; //🚪
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            DoorsDecorators = CreateDecorators(255, 216, 0);
            BreakablesDoorsDecorators = CreateDecorators(250, 0, 0);
            BridgesDecorators = CreateDecorators(0, 195, 255);
            DebugDecorators = CreateDecorators(255, 255, 255, 255, 10);
            HotKey = Key.End;
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.IsPressed && ToggleKeyEvent.Matches(keyEvent))
            {
                Debug = !Debug;
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Game.IsInTown && !ShowInTown) return;

            Hud.Game.Actors
                .Where(a => a.GizmoType == GizmoType.Door || a.GizmoType == GizmoType.BreakableDoor)
                .ForEach(door =>
                {
                    if (BreakableDoorsIds.Contains(door.SnoActor.Sno))
                    {
                        PaintActor(layer, door, BreakablesDoorsDecorators);
                    }
                    else if (door.GizmoType == GizmoType.Door && door.DisplayOnOverlay && !DoorsIdsBlackList.Contains(door.SnoActor.Sno))
                    {
                        PaintActor(layer, door, BridgesIds.Contains(door.SnoActor.Sno) ? BridgesDecorators : DoorsDecorators);
                        //if (!doorsDebugWhiteList.Contains(door.SnoActor.Sno)) Says.Debug(string.Format("DOOR?? {0} {1} {2} {3} {4} {5} {6}", door.SnoActor.Sno, door.SnoActor.NameLocalized, door.IsOperated, door.IsClickable, door.IsDisabled, door.SnoActor.Kind, door.SnoActor.Code));/**/
                    }

                    //if (!doorsDebugWhiteList.Contains(door.SnoActor.Sno)) Says.Debug(string.Format("DOOR?? {0} {1} {2} {3} {4} {5} {6}", door.SnoActor.Sno, door.SnoActor.NameLocalized, door.IsOperated, door.IsClickable, door.IsDisabled, door.SnoActor.Kind, door.SnoActor.Code));/**/
                });
        }

        public WorldDecoratorCollection CreateDecorators(int r, int g, int b, int a = 200, int size = 18)
        {
            return new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    TextFont = Hud.Render.CreateFont("tahoma", size, a, r, g, b, false, false, true),
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new DoorShapePainter(Hud),
                    Radius = 6f,
                    Brush = Hud.Render.CreateBrush(a, r, g, b, 1),
                }
            );
        }

        private void PaintActor(WorldLayer layer, IActor actor, WorldDecoratorCollection decorator)
        {
            if (GroundLabelsOnScreen)
                decorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen);

            if (DebugEnabled && Debug)
            {
                var text = string.Format("{0} : {1} {2}\n{3} {4} {5} {6}\n{7}",
                    actor.SnoActor.Sno,
                    actor.SnoActor.NameLocalized,
                    actor.SnoActor.Kind,
                    actor.GizmoType,
                    actor.IsOperated ? "Operated" : "Not Operated",
                    actor.IsClickable ? "Clickable" : "Not Clickable",
                    actor.IsDisabled ? "Disabled" : "Not Disabled",
                    actor.SnoActor.Code);
                DebugDecorators.Paint(layer, actor, actor.FloorCoordinate, text);
            }
            else
            {
                decorator.Paint(layer, actor, actor.FloorCoordinate, GroundSymbol);
            }
        }
    }
}

/*

        //170245
        private readonly HashSet<uint> doorsDebugWhiteList = new HashSet<uint>() {
            309222, 308241, 454, // ??
            309812, // X1 ??
            104888,
            258595,
            4267,
            362651,
            447673,
            162386,
            415665,
            4393,
            219702,
            250031,
            //102711
            343582,
            230324,
        };*/
