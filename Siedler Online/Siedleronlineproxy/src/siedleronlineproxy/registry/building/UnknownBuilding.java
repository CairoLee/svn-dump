/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;

/**
 *
 * @author nspecht
 */
public class UnknownBuilding extends GenericDoNothingBuilding {

    public UnknownBuilding() {
        super();
        this.name = "Unknown";
        this.category = BuildingCategory.__UNKNOWN;
    }
}
