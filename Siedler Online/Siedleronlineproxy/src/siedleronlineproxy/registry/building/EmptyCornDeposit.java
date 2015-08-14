package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyCornDeposit extends GenericEmptyDeposit {
    public EmptyCornDeposit() {
        super();
        this.name = "Leeres Getreidefeld";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITCORN;
    }
}
