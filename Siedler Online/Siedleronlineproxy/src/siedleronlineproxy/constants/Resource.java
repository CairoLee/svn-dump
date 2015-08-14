/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.constants;

import javax.swing.Icon;
import siedleronlineproxy.IconLoader;

/**
 *
 * @author nspecht
 */
public class Resource {
    private static Resource instance = null;
    public static Resource getInstance() {
        if (Resource.instance == null) instance = new Resource();
        return Resource.instance;
    }
    
    public enum Products {
        POPULATION,
        HARDCURRENCY,
        WOOD, PLANK,
        REALWOOD, REALPLANK,
        EXOTICWOOD, EXOTICPLANK,
        COAL,
        BRONZEORE, BRONZE,
        TOOL, //11
        IRONORE, IRON, STEEL,
        GOLDORE, GOLD, COIN,
        TITANIUMORE, TITANIUM, SALPETER, GUNPOWDER,
        STONE, MARBLE, GRANITE,
        WATER, CORN, FISH, BEER,
        MEAT, SAUSAGE,
        FLOUR, BREAD,
        HORSE, WHEEL, CARRIAGE,
        BRONZESWORD, IRONSWORD, STEELSWORD, TITANIUMSWORD,
        BOW, LONGBOW, CROSSBOW, CANNON, 
        EVENTRESOURCE, MAPPART, 
        HALLOWEENRESOURCE, CHRISTMASRESOURCE,

        RECRUIT, BOWMAN, CAVALRY,
        MILITIA, LONGBOWMAN,    ELITESOLDIER,
        SOLDIER, CROSSBOWMAN,   CANNONEER,
        MUSKETEER,

        __SIZE,
        SEED, TREE, REALTREE, EXOTICTREE,
        STONEDEPOSIT, MARBLEDEPOSIT,
        COALDEPOSIT, BRONZEDEPOSIT, IRONDEPOSIT, GOLDDEPOSIT,
        WATERDEPOSIT, FISHDEPOSIT, CORNDEPOSIT, MEATDEPOSIT,
        XP,
        __ALLSIZE
    }

    public enum Deposits {
        WOOD, REALWOOD, EXOTICWOOD,
        STONE, MARBLE, GRANITE,
        COAL, BRONZEORE, IRONORE, GOLDORE, TITANIUMORE, SALPETER,
        WATER, CORN, FISH, MEAT, HALLOWEENRESOURCE, 
        __SIZE
    }

    public String[] names = new String[Products.__ALLSIZE.ordinal()];
    public String[] icons = new String[Products.__ALLSIZE.ordinal()];

    public Resource() {
        this.initNames();
        this.initIcons();
    }

    private void initNames() {
        for(int i=0;i<this.names.length;i++) this.names[i]=Products.values()[i].toString();

        this.names[Products.POPULATION.ordinal()] = "Siedler";
        this.names[Products.HARDCURRENCY.ordinal()] = "Edelsteine";
        this.names[Products.WOOD.ordinal()] = "Nadelholz";
        this.names[Products.PLANK.ordinal()] = "Nadelholzbrett";
        this.names[Products.REALWOOD.ordinal()] = "Laubholz";
        this.names[Products.REALPLANK.ordinal()] = "Laubholzbrett";
        this.names[Products.EXOTICWOOD.ordinal()] = "Edelholz";
        this.names[Products.EXOTICPLANK.ordinal()] = "Edelholzbrett";
        this.names[Products.COAL.ordinal()] = "Kohle";
        this.names[Products.BRONZEORE.ordinal()] = "Kupfererz";
        this.names[Products.BRONZE.ordinal()] = "Kupfer";
        this.names[Products.TOOL.ordinal()] = "Werkzeug";
        this.names[Products.IRONORE.ordinal()] = "Eisenerz";
        this.names[Products.IRON.ordinal()] = "Eisen";
        this.names[Products.STEEL.ordinal()] = "Stahl";
        this.names[Products.GOLDORE.ordinal()] = "Golderz";
        this.names[Products.GOLD.ordinal()] = "Gold";
        this.names[Products.COIN.ordinal()] = "Goldmünze";
        this.names[Products.TITANIUMORE.ordinal()] = "Titaniumerz";
        this.names[Products.TITANIUM.ordinal()] = "Titanium";
        this.names[Products.SALPETER.ordinal()] = "Salpeter";
        this.names[Products.GUNPOWDER.ordinal()] = "Schwarzpulver";
        this.names[Products.STONE.ordinal()] = "Stein";
        this.names[Products.MARBLE.ordinal()] = "Mamor";
        this.names[Products.GRANITE.ordinal()] = "Granit";
        this.names[Products.WATER.ordinal()] = "Wasser";
        this.names[Products.CORN.ordinal()] = "Getreide";
        this.names[Products.FISH.ordinal()] = "Fisch";
        this.names[Products.BEER.ordinal()] = "Bier";
        this.names[Products.MEAT.ordinal()] = "Fleisch";
        this.names[Products.SAUSAGE.ordinal()] = "Wurst";
        this.names[Products.FLOUR.ordinal()] = "Mehl";
        this.names[Products.BREAD.ordinal()] = "Brot";
        this.names[Products.HORSE.ordinal()] = "Pferd";
        this.names[Products.WHEEL.ordinal()] = "Rad";
        this.names[Products.CARRIAGE.ordinal()] = "Karren";
        this.names[Products.BRONZESWORD.ordinal()] = "Bronzeschwert";
        this.names[Products.IRONSWORD.ordinal()] = "Eisenschwert";
        this.names[Products.STEELSWORD.ordinal()] = "Stahlschwert";
        this.names[Products.TITANIUMSWORD.ordinal()] = "Titaniumschwert";
        this.names[Products.BOW.ordinal()] = "Bogen";
        this.names[Products.LONGBOW.ordinal()] = "Langbogen";
        this.names[Products.CROSSBOW.ordinal()] = "Armbrust";
        this.names[Products.CANNON.ordinal()] = "Kanone";
        this.names[Products.EVENTRESOURCE.ordinal()] = "Osterei";
        this.names[Products.MAPPART.ordinal()] = "Kartenstück";
        this.names[Products.HALLOWEENRESOURCE.ordinal()] = "Kürbis";
        this.names[Products.CHRISTMASRESOURCE.ordinal()] = "Geschenke";

        this.names[Products.BOWMAN.ordinal()] = "Bogenschütze";
        this.names[Products.CANNONEER.ordinal()] = "Kanonier";
        this.names[Products.CAVALRY.ordinal()] = "Reiterei";
        this.names[Products.CROSSBOWMAN.ordinal()] = "Armbrustschütze";
        this.names[Products.ELITESOLDIER.ordinal()] = "Elitesoldat";
        this.names[Products.LONGBOWMAN.ordinal()] = "Langbogenschütze";
        this.names[Products.MILITIA.ordinal()] = "Miliz";
        this.names[Products.MUSKETEER.ordinal()] = "MUSKETEER";
        this.names[Products.RECRUIT.ordinal()] = "Rekrut";
        this.names[Products.SOLDIER.ordinal()] = "Soldat";

        this.names[Products.SEED.ordinal()] = "Samen";
        this.names[Products.TREE.ordinal()] = "Nadelbaum";
        this.names[Products.REALTREE.ordinal()] = "Laubbaum";
        this.names[Products.EXOTICTREE.ordinal()] = "Edelbaum";

        this.names[Products.STONEDEPOSIT.ordinal()] = "Steinvorkommen";
        this.names[Products.MARBLEDEPOSIT.ordinal()] = "Mamorvorkommen";

        this.names[Products.COALDEPOSIT.ordinal()] = "Kohlevorkommen";
        this.names[Products.BRONZEDEPOSIT.ordinal()] = "Bronzevorkommen";
        this.names[Products.IRONDEPOSIT.ordinal()] = "Eisenvorkommen";
        this.names[Products.GOLDDEPOSIT.ordinal()] = "Kohlevorkommen";

        this.names[Products.WATERDEPOSIT.ordinal()] = "Wasservorkommen";
        this.names[Products.FISHDEPOSIT.ordinal()] = "Fischvorkommen";
        this.names[Products.CORNDEPOSIT.ordinal()] = "Getreidefeld";
        this.names[Products.MEATDEPOSIT.ordinal()] = "Fleischvorkommen";
    }

    private void initIcons() {
        for(int i=0;i<this.icons.length;i++) this.icons[i]="default";

        this.icons[Products.POPULATION.ordinal()] = "settler";
        this.icons[Products.HARDCURRENCY.ordinal()] = "gems";
        this.icons[Products.WOOD.ordinal()] = "wood";
        this.icons[Products.PLANK.ordinal()] = "planks";
        this.icons[Products.REALWOOD.ordinal()] = "realwood";
        this.icons[Products.REALPLANK.ordinal()] = "realplanks";
        this.icons[Products.EXOTICWOOD.ordinal()] = "exoticwood";
        this.icons[Products.EXOTICPLANK.ordinal()] = "exoticplanks";
        this.icons[Products.COAL.ordinal()] = "coal";
        this.icons[Products.BRONZEORE.ordinal()] = "bronzeore";
        this.icons[Products.BRONZE.ordinal()] = "bronze";
        this.icons[Products.TOOL.ordinal()] = "tools";
        this.icons[Products.IRONORE.ordinal()] = "ironore";
        this.icons[Products.IRON.ordinal()] = "iron";
        this.icons[Products.STEEL.ordinal()] = "steel";
        this.icons[Products.GOLDORE.ordinal()] = "goldore";
        this.icons[Products.GOLD.ordinal()] = "gold";
        this.icons[Products.COIN.ordinal()] = "coins";
        this.icons[Products.TITANIUMORE.ordinal()] = "titaniumore";
        this.icons[Products.TITANIUM.ordinal()] = "titanium";
        this.icons[Products.SALPETER.ordinal()] = "salpeter";
        this.icons[Products.GUNPOWDER.ordinal()] = "gunpowder";
        this.icons[Products.STONE.ordinal()] = "stone";
        this.icons[Products.MARBLE.ordinal()] = "marble";
        this.icons[Products.GRANITE.ordinal()] = "granite";
        this.icons[Products.WATER.ordinal()] = "water";
        this.icons[Products.CORN.ordinal()] = "corn";
        this.icons[Products.FISH.ordinal()] = "fish";
        this.icons[Products.BEER.ordinal()] = "beer";
        this.icons[Products.MEAT.ordinal()] = "meat";
        this.icons[Products.SAUSAGE.ordinal()] = "sausage";
        this.icons[Products.FLOUR.ordinal()] = "flour";
        this.icons[Products.BREAD.ordinal()] = "bread";
        this.icons[Products.HORSE.ordinal()] = "horse";
        this.icons[Products.WHEEL.ordinal()] = "wheel";
        this.icons[Products.CARRIAGE.ordinal()] = "carriage";
        this.icons[Products.BRONZESWORD.ordinal()] = "bronzesword";
        this.icons[Products.IRONSWORD.ordinal()] = "ironsword";
        this.icons[Products.STEELSWORD.ordinal()] = "steelsword";
        this.icons[Products.TITANIUMSWORD.ordinal()] = "titaniumsword";
        this.icons[Products.BOW.ordinal()] = "bow";
        this.icons[Products.LONGBOW.ordinal()] = "longbow";
        this.icons[Products.CROSSBOW.ordinal()] = "crossbow";
        this.icons[Products.CANNON.ordinal()] = "cannon";
        this.icons[Products.EVENTRESOURCE.ordinal()] = "unknown";

        this.icons[Products.BOWMAN.ordinal()] = "bowman";
        this.icons[Products.CANNONEER.ordinal()] = "cannoneer";
        this.icons[Products.CAVALRY.ordinal()] = "cavalry";
        this.icons[Products.CROSSBOWMAN.ordinal()] = "crossbowman";
        this.icons[Products.ELITESOLDIER.ordinal()] = "elitesoldier";
        this.icons[Products.LONGBOWMAN.ordinal()] = "longbowman";
        this.icons[Products.MILITIA.ordinal()] = "militia";
        this.icons[Products.MUSKETEER.ordinal()] = "musketeer";
        this.icons[Products.RECRUIT.ordinal()] = "recruit";
        this.icons[Products.SOLDIER.ordinal()] = "soldier";
    }

    public static Icon getIconByString(String str) {
        return getIconByType(getTypeByString(str));
    }

    public static String getNameByType(Products t) {
        return Resource.getInstance().names[t.ordinal()];
    }
    
    public static String getNameByString(String str) {
        return getNameByType(getTypeByString(str));
    }

    public static Products getTypeByString(String str) {
        return Products.valueOf(str.toUpperCase());
    }

    public static Icon getIconByType(Products t) {
        return new IconLoader().getIconById(
                Resource.getInstance().icons[t.ordinal()],"res"
                );
    }

    
}
