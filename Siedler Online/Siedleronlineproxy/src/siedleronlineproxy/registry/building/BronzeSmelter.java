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
public class BronzeSmelter extends GenericBuilding {
    public BronzeSmelter() {
        super();
        this.name = "Kupferschmelze";
        this.type = BuildingTypes.BRONZESMELTER;
        this.category = BuildingCategory.METAL;
        this.productionTime = 6*60;
        this.needs.put(Products.BRONZEORE, 1);
        this.needs.put(Products.COAL, 1);
        this.produces.put(Products.BRONZE, 1);
    }
}
