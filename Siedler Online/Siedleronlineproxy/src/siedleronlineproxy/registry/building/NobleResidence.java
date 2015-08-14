/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.util.CollectionTable;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class NobleResidence extends GenericDoNothingBuilding {
    public NobleResidence() {
        super();
        this.name = "Gehobenes Wohnhaus";
        this.type = BuildingTypes.NOBLERESIDENCE;
        this.category = BuildingCategory.__MISC;
        this.productionTime = 24*60*60;
        this.produces.put(Products.POPULATION,10);
    }

    @Override
    public CollectionEnumTable<Resource.Products, Double> getProducesPerDayByLevel(int level) {
        CollectionEnumTable< Products, Double> ret = super.getProducesPerDayByLevel(level);
        ret.put(Products.POPULATION, ret.get(Products.POPULATION) + 20);
        return ret;
    }
}
