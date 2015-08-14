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
public class TentRidersLeader extends GenericNPCBuilding {
    public TentRidersLeader() {
        super();
        this.name = "Reitervolk Anführerlager";
        this.type = BuildingTypes.TENT_RIDERS_LEADER;
    }
}
