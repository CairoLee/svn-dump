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
public class Warehouse extends GenericDoNothingBuilding {
    public Warehouse() {
        super();
        this.name = "Lager";
        this.type = BuildingTypes.WAREHOUSE;
        this.category = BuildingCategory.STORAGE;
    }
}
