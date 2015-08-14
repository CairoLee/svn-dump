/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class BanditLvl1 extends GenericNPCBuilding {
    public BanditLvl1() {
        super();
        this.name = "Räuberlager (leicht)";
        this.type = BuildingTypes.BANDITSLVL1;
    }
}
