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
public class Farmfield extends GenericDoNothingBuilding {
    public Farmfield() {
        super();
        this.name = "Getreidefeld";
        this.type = BuildingTypes.FARMFIELD;
        this.category = BuildingCategory.CORN;
    }
}
