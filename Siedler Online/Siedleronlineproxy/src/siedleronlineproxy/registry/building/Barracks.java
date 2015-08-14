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
public class Barracks extends GenericDoNothingBuilding {
    public Barracks() {
        super();
        this.name = "Kaserne";
        this.category = BuildingCategory.ARMY;
        this.type = BuildingTypes.BARRACKS;
    }
}
