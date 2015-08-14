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
public class BanditLeader extends GenericNPCBuilding {
    public BanditLeader() {
        super();
        this.name = "Räuberhauptlager";
        this.type = BuildingTypes.BANDITSLEADER;
    }
}
