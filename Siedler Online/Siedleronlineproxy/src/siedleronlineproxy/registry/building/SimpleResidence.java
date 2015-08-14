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
public class SimpleResidence extends GenericDoNothingBuilding {
    public SimpleResidence() {
        super();
        this.name = "Wohnhaus";
        this.type = BuildingTypes.SIMPLERESIDENCE;
        this.category = BuildingCategory.__MISC;
        this.productionTime = 24*60*60;
        this.produces.put(Products.POPULATION,10);
    }
}
