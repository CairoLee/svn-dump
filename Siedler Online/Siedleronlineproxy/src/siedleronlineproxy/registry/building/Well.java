/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Well extends GenericBuilding {
    public Well() {
        super();
        this.name = "Brunnen";
        this.type = BuildingTypes.WELL;
        this.category = BuildingCategory.WATER;
        this.productionTime = 3*60;
        this.needs.put(Products.WATERDEPOSIT, 1);
        this.produces.put(Products.WATER, 1);
    }

    @Override
    public int getResourceTime() {
        return 4;
    }
}
