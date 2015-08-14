/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.constants;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.Icon;
import siedleronlineproxy.IconLoader;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.registry.building.*;

/**
 *
 * @author nspecht
 */
public class Building {

    private static Building instance = null;

    public static Building getInstance() {
        if (Building.instance == null) {
            instance = new Building();
        }
        return Building.instance;
    }

    public enum BuildingTypes {
        //Leere Vorkommen

        MINEDEPLETEDDEPOSITBRONZEORE, MINEDEPLETEDDEPOSITIRONORE, MINEDEPLETEDDEPOSITGOLDORE,
        MINEDEPLETEDDEPOSITCOAL, MINEDEPLETEDDEPOSITSTONE, MINEDEPLETEDDEPOSITMARBLE,
        MINEDEPLETEDDEPOSITCORN, MINEDEPLETEDDEPOSITWATER,
        MINEDEPLETEDDEPOSITSALPETER,
        //Lager
        MAYORHOUSE, WAREHOUSE,
        //Einfache
        WOODCUTTER,
        SAWMILL, FORESTER, MASON,
        SIMPLERESIDENCE, FISHER, PROVISIONHOUSE,
        //Verbesserte
        BRONZEMINE, COKINGPLANT, BRONZESMELTER,
        TOOLMAKER, BARRACKS, FARMFIELD, FARMFIELD_03,
        BREWERY, FARM, WELL, WELL_03,
        BRONZEWEAPONSMITH, TAVERN, MILLER,
        BAKERY, BOWMAKER, GUILD_BUILDING,
        LOGISTICS,
        //Gehobene
        REALWOODCUTTER, REALWOODSAWMILL, MARBLEMASON,
        REALWOODFORESTER, IRONSMELTER, IRONWEAPONSMITH,
        IRONMINE, NOBLERESIDENCE, STABLE,
        HUNTER, BUTCHER, COALMINE,
        LONGBOWMAKER, GOLDMINE, GOLDSMELTER,
        COINAGE, STEELFORGE, STEELWEAPONSMITH,
        //Luxus
        EXOTICWOODSAWMILL, titaniumsmelter, crossbowfactory,
        wheelfactory, carriagefactory, titaniumweaponsmith,
        powdermill, cannonfactory,
        //Gekaufte Gebäude
        WATERMILL, SILO,
        //Andere
        GARRISON,
        //Aktionen
        PUMPKINFIELD_01, PUMPKINFIELD_02, PUMPKINFIELD_03,
        //Banditen
        BANDITSLVL1, BANDITSLVL2, BANDITSLVL3, BANDITSLEADER,
        TENT_RIDERS_00, TENT_RIDERS_01, TENT_RIDERS_LEADER,
        TENT_TRAITORS_00, TENT_TRAITORS_01, TENT_TRAITORS_02, TENT_TRAITORS_LEADER,
        TENT_NORDS_00, TENT_NORDS_01, TENT_NORDS_02, TENT_NORDS_LEADER,
        BANDITSLEADER_DARK, BANDITS_DARK,
        BANDITS_ADVENTURE, BANDITSLEADER_ADVENTURE,
        SMALLWATCHTOWER, MEDIUMWATCHTOWER,
        EVIL_SALAD,
        WITCHTOWER, DARK_CASTLE_01, BONECHURCH,
        //MAUERN
        WALLCORNERNORTH_01, WALLCORNEREAST_01, WALLCORNERSOUTH_01, WALLCORNERWEST_01,
        WALLSIDE_01, WALLSIDE_02, WALLSIDE_03,
        WALLFRONT_01,WALLFRONT_02, WALLFRONT_03,
        FENCECORNERNORTH_01, FENCECORNEREAST_01, FENCECORNERSOUTH_01, FENCECORNERWEST_01,
        FENCEFRONT_01, FENCEFRONT_02, FENCEFRONT_03,
        FENCELEFT_01, FENCELEFT_02, FENCELEFT_03,
        FENCERIGHT_01, FENCERIGHT_02, FENCERIGHT_03,
        FENCEBACK_01, FENCEBACK_02, FENCEBACK_03,
        WITCHTOWER_GATE_LEFT_01, WITCHTOWER_GATE_RIGHT_01,
        WITCHTOWER_GATE_LEFT_WEST,
        WITCHTOWER_GATE_RIGHT_NORTH, WITCHTOWER_GATE_RIGHT_WEST,
        WITCHTOWER_WALL_NORTH_01, WITCHTOWER_WALL_EAST_01, WITCHTOWER_WALL_SOUTH_01, WITCHTOWER_WALL_WEST_01,
        WITCHTOWER_WALL_NORTH_02, WITCHTOWER_WALL_EAST_02, WITCHTOWER_WALL_SOUTH_02, WITCHTOWER_WALL_WEST_02,
        WITCHTOWER_WALL_EDGE_NORTH_01, WITCHTOWER_WALL_EDGE_EAST_01, WITCHTOWER_WALL_EDGE_SOUTH_01, WITCHTOWER_WALL_EDGE_WEST_01,
        BANDITS_WALL_EDGE_NORTH,BANDITS_WALL_EDGE_EAST,BANDITS_WALL_EDGE_SOUTH, BANDITS_WALL_EDGE_WEST,
        BANDITS_WALL_NORTH,BANDITS_WALL_EAST,BANDITS_WALL_SOUTH,BANDITS_WALL_WEST,
        //DEKO
        STATUETRADER, COLLUMSTATUETRADER, STATUESOLDIER, STATUEGIRL,
        PIRATE_HUT01, PIRATE_HUT02, PIRATE_STOREHOUSE, PIRATE_SHIP_SMALL, PIRATE_SHIP_BIG,
        FIREWOODHUT, FIREBOWL, FIREBOW3, LANTERNQUADGOLD,
        BARRELTRANSPORTER, BROKENWAGON, LOADEDCART,
        SIGNPOST_01, SIGNPOST_02, SIGNPOST_03, SIGNPOSTBROKEN,
        BENCHIRON, BENCHSTONE2,
        STONEFLOWERED,
        BED,FLOWERBED_YELLOW, FLOWERBED_RED,
        FLOWERBED_GREEN_SALAT,
        WELL_02, WHEELBROKEN,
        RUINANCIENTLIBRARY_01, RUINANCIENTLIBRARY_02,
        WITCHTOWER_STATUE_SOUTH,
        RESIDENCEA, RESIDENCEB, RESIDENCEC, RESIDENCED,
        WITCHTOWER_STATUE_WEST, WITCHTOWER_STATUE_EAST,
        SHEPHERD,
        VASES, CRATES,
        //KEINE AHNUNG
        __SIZE, UNKNOWN
    }

    public enum BuildingCategory {
        WOOD, REALWOOD, EXOTICWOOD,
        STONE, MINE, METAL,
        CORN, FOOD, WATER,
        STORAGE, ARMY,
        EMPTYDEPOSIT, NPC, AKTION,
        __MISC, WALL, DEKO, __UNKNOWN, ALL
    }
    
    public Class[] classes = new Class[BuildingTypes.__SIZE.ordinal()];
    public String[] icons = new String[BuildingTypes.__SIZE.ordinal()];

    public Building() {
        this.initClasses();
        this.initIcons();
    }

    private void initClasses() {
        for (int i = 0; i < this.classes.length; i++) {
            this.classes[i] = UnknownBuilding.class;
        }
        //Mauern
        for(int i = BuildingTypes.WALLCORNERNORTH_01.ordinal(); i <= BuildingTypes.BANDITS_WALL_WEST.ordinal();i++) {
            this.classes[i] = GenericWall.class;
        }
        //Dekoration
        for(int i = BuildingTypes.STATUETRADER.ordinal(); i <= BuildingTypes.CRATES.ordinal();i++) {
            this.classes[i] = GenericDecoration.class;
        }
        //Räuber
        this.classes[BuildingTypes.BANDITSLVL1.ordinal()] = BanditLvl1.class;
        this.classes[BuildingTypes.BANDITSLVL2.ordinal()] = BanditLvl2.class;
        this.classes[BuildingTypes.BANDITSLVL3.ordinal()] = BanditLvl3.class;
        this.classes[BuildingTypes.BANDITSLEADER.ordinal()] = BanditLeader.class;
        this.classes[BuildingTypes.TENT_RIDERS_00.ordinal()] = TentRiders00.class;
        this.classes[BuildingTypes.TENT_RIDERS_01.ordinal()] = TentRiders01.class;
        this.classes[BuildingTypes.TENT_RIDERS_LEADER.ordinal()] = TentRidersLeader.class;
        this.classes[BuildingTypes.TENT_TRAITORS_00.ordinal()] = TentTraitors00.class;
        this.classes[BuildingTypes.TENT_TRAITORS_01.ordinal()] = TentTraitors01.class;
        this.classes[BuildingTypes.TENT_TRAITORS_02.ordinal()] = TentTraitors02.class;
        this.classes[BuildingTypes.TENT_TRAITORS_LEADER.ordinal()] = TentTraitorsLeader.class;
        this.classes[BuildingTypes.TENT_NORDS_00.ordinal()] = TentNords00.class;
        this.classes[BuildingTypes.TENT_NORDS_01.ordinal()] = TentNords01.class;
        this.classes[BuildingTypes.TENT_NORDS_02.ordinal()] = TentNords02.class;
        this.classes[BuildingTypes.TENT_NORDS_LEADER.ordinal()] = TentNordsLeader.class;
        this.classes[BuildingTypes.BANDITSLEADER_ADVENTURE.ordinal()] = Banditsleader_Adventure.class;
        this.classes[BuildingTypes.BANDITS_ADVENTURE.ordinal()] = Bandits_Adventure.class;
        this.classes[BuildingTypes.BANDITSLEADER_DARK.ordinal()] = Banditsleader_Dark.class;
        this.classes[BuildingTypes.BANDITS_DARK.ordinal()] = Bandits_dark.class;
        this.classes[BuildingTypes.EVIL_SALAD.ordinal()] = EvilSalad.class;
        this.classes[BuildingTypes.WITCHTOWER.ordinal()] = WitchTower.class;
        this.classes[BuildingTypes.DARK_CASTLE_01.ordinal()] = DarkCastle01.class;
        this.classes[BuildingTypes.BONECHURCH.ordinal()] = Bonechurch.class;

        this.classes[BuildingTypes.SMALLWATCHTOWER.ordinal()] = SmallWatchtower.class;
        this.classes[BuildingTypes.MEDIUMWATCHTOWER.ordinal()] = MediumWatchtower.class;
        //Gebäude ohne Produktion
        this.classes[BuildingTypes.MAYORHOUSE.ordinal()] = Mayorhouse.class;
        this.classes[BuildingTypes.WAREHOUSE.ordinal()] = Warehouse.class;
        this.classes[BuildingTypes.SIMPLERESIDENCE.ordinal()] = SimpleResidence.class;
        this.classes[BuildingTypes.NOBLERESIDENCE.ordinal()] = NobleResidence.class;
        this.classes[BuildingTypes.PROVISIONHOUSE.ordinal()] = ProvisionHouse.class;
        this.classes[BuildingTypes.TAVERN.ordinal()] = Tavern.class;
        this.classes[BuildingTypes.GUILD_BUILDING.ordinal()] = Guild.class;
        this.classes[BuildingTypes.LOGISTICS.ordinal()] = Logistics.class;

        //Nahrung
        this.classes[BuildingTypes.FISHER.ordinal()] = Fisher.class;
        this.classes[BuildingTypes.FARM.ordinal()] = Farm.class;
        this.classes[BuildingTypes.FARMFIELD.ordinal()] = Farmfield.class;
        this.classes[BuildingTypes.FARMFIELD_03.ordinal()] = Farmfield_03.class;
        this.classes[BuildingTypes.WELL.ordinal()] = Well.class;
        this.classes[BuildingTypes.WELL_03.ordinal()] = Well_03.class;
        this.classes[BuildingTypes.BREWERY.ordinal()] = Brewery.class;
        this.classes[BuildingTypes.MILLER.ordinal()] = Miller.class;
        this.classes[BuildingTypes.BAKERY.ordinal()] = Bakery.class;
        this.classes[BuildingTypes.HUNTER.ordinal()] = Hunter.class;
        this.classes[BuildingTypes.BUTCHER.ordinal()] = Butcher.class;

        //Holz
        this.classes[BuildingTypes.FORESTER.ordinal()] = Forester.class;
        this.classes[BuildingTypes.WOODCUTTER.ordinal()] = WoodCutter.class;
        this.classes[BuildingTypes.SAWMILL.ordinal()] = Sawmill.class;
        this.classes[BuildingTypes.REALWOODCUTTER.ordinal()] = RealWoodCutter.class;
        this.classes[BuildingTypes.REALWOODFORESTER.ordinal()] = RealWoodForester.class;
        this.classes[BuildingTypes.REALWOODSAWMILL.ordinal()] = RealWoodSawmill.class;
        this.classes[BuildingTypes.EXOTICWOODSAWMILL.ordinal()] = ExoticWoodSawmill.class;
        //Steinbrüche
        this.classes[BuildingTypes.MASON.ordinal()] = Mason.class;
        this.classes[BuildingTypes.MARBLEMASON.ordinal()] = MarbleMason.class;

        //Minen + Verarbeitung
        this.classes[BuildingTypes.COALMINE.ordinal()] = Coalmine.class;
        this.classes[BuildingTypes.COKINGPLANT.ordinal()] = Cokingplant.class;
        this.classes[BuildingTypes.BRONZEMINE.ordinal()] = Bronzemine.class;
        this.classes[BuildingTypes.BRONZESMELTER.ordinal()] = BronzeSmelter.class;
        this.classes[BuildingTypes.TOOLMAKER.ordinal()] = Toolmaker.class;
        this.classes[BuildingTypes.IRONMINE.ordinal()] = Ironmine.class;
        this.classes[BuildingTypes.IRONSMELTER.ordinal()] = IronSmelter.class;
        this.classes[BuildingTypes.GOLDMINE.ordinal()] = Goldmine.class;
        this.classes[BuildingTypes.GOLDSMELTER.ordinal()] = GoldSmelter.class;
        this.classes[BuildingTypes.COINAGE.ordinal()] = Coinage.class;
        this.classes[BuildingTypes.STEELFORGE.ordinal()] = SteelForge.class;


        //Leere Vorkommen
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITBRONZEORE.ordinal()] = EmptyBronzeMine.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITIRONORE.ordinal()] = EmptyIronMine.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITGOLDORE.ordinal()] = EmptyGoldMine.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITCOAL.ordinal()] = EmptyCoalMine.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITSTONE.ordinal()] = EmptyStoneDeposit.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITMARBLE.ordinal()] = EmptyMarbleDeposit.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITCORN.ordinal()] = EmptyCornDeposit.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITWATER.ordinal()] = EmptyWaterDeposit.class;
        this.classes[BuildingTypes.MINEDEPLETEDDEPOSITSALPETER.ordinal()] = EmptySalpeterDeposit.class;

        //Militär
        this.classes[BuildingTypes.GARRISON.ordinal()] = Garrison.class;
        this.classes[BuildingTypes.BARRACKS.ordinal()] = Barracks.class;
        this.classes[BuildingTypes.STABLE.ordinal()] = Stable.class;
        this.classes[BuildingTypes.BRONZEWEAPONSMITH.ordinal()] = BronzeWeaponsmith.class;
        this.classes[BuildingTypes.IRONWEAPONSMITH.ordinal()] = IronWeaponsmith.class;
        this.classes[BuildingTypes.STEELWEAPONSMITH.ordinal()] = SteelWeaponsmith.class;
        this.classes[BuildingTypes.BOWMAKER.ordinal()] = Bowmaker.class;
        this.classes[BuildingTypes.LONGBOWMAKER.ordinal()] = LongBowmaker.class;

        //Gekaufte Gebäude
        this.classes[BuildingTypes.WATERMILL.ordinal()] = Watermill.class;
        this.classes[BuildingTypes.SILO.ordinal()] = Silo.class;

        //Aktionen
        this.classes[BuildingTypes.PUMPKINFIELD_01.ordinal()] = Pumpkinfield01.class;
        this.classes[BuildingTypes.PUMPKINFIELD_02.ordinal()] = Pumpkinfield02.class;
        this.classes[BuildingTypes.PUMPKINFIELD_03.ordinal()] = Pumpkinfield03.class;
        //Deko

    }

    private void initIcons() {
        for (int i = 0; i < this.icons.length; i++) {
            this.icons[i] = BuildingTypes.values()[i].toString().toLowerCase();
        }
        //Mauern
        for(int i = BuildingTypes.WALLCORNERNORTH_01.ordinal(); i <= BuildingTypes.BANDITS_WALL_WEST.ordinal();i++) {
            this.icons[i] = "wall";
        }
        //Dekoration
        for(int i = BuildingTypes.STATUETRADER.ordinal(); i <= BuildingTypes.CRATES.ordinal();i++) {
            this.icons[i] = "deko";
        }
        //Dekoration
        for(int i = BuildingTypes.BANDITSLVL1.ordinal(); i <= BuildingTypes.BONECHURCH.ordinal();i++) {
            this.icons[i] = "bandit";
        }
        this.icons[BuildingTypes.EVIL_SALAD.ordinal()] = "evilsalad";
    }

    public static Icon getIconByType(BuildingTypes t) {
        try {
            return new IconLoader().getIconById(
                    Building.getInstance().icons[t.ordinal()], "building");
        } catch (ArrayIndexOutOfBoundsException e) {
        }
        return new IconLoader().getIconById("unknown", "building");
    }
    
    public GenericBuilding getBuildingInstanceByType(BuildingTypes t) {
        try {
            GenericBuilding b = (GenericBuilding) this.classes[t.ordinal()].newInstance();
            b.setType(t);
            return b;
        } catch (Exception e) {
            DebugLog.put(this, e);
        }
        return null;
    }
}
