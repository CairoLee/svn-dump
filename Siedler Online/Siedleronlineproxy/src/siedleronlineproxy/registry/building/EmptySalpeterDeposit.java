package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptySalpeterDeposit extends GenericEmptyDeposit {

    public EmptySalpeterDeposit() {
        super();
        this.name = "Leere Salpetermine";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITSALPETER;
    }
}
