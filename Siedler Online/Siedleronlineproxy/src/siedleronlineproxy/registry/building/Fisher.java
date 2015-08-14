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
public class Fisher extends GenericBuilding {
    public Fisher() {
        super();
        this.name = "Fischerhütte";
        this.type = BuildingTypes.FISHER;
        this.category = BuildingCategory.FOOD;
        this.productionTime = 3*60;
        this.needs.put(Products.FISHDEPOSIT, 1);
        this.produces.put(Products.FISH, 1);
    }
}
