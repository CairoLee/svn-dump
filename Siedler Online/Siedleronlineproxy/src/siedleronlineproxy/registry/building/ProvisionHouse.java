/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class ProvisionHouse extends GenericDoNothingBuilding {
    public ProvisionHouse() {
        super();
        this.name = "Proviantlager";
        this.type = BuildingTypes.PROVISIONHOUSE;
        this.category = BuildingCategory.__MISC;
    }
}
