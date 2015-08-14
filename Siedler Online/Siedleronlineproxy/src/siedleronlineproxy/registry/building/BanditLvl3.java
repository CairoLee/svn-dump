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
public class BanditLvl3 extends GenericNPCBuilding {
    public BanditLvl3() {
        super();
        this.name = "Räuberlager (schwer)";
        this.type = BuildingTypes.BANDITSLVL3;
    }
}
