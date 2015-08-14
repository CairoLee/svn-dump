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
public class Brewery extends GenericBuilding {
    public Brewery() {
        super();
        this.name = "Brauerei";
        this.type = BuildingTypes.BREWERY;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 6*60;
        this.needs.put(Products.CORN, 1);
        this.needs.put(Products.WATER, 2);
        this.produces.put(Products.BEER,1);
    }
}
