package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;


/**
 *
 * @author nspecht
 */
public class EmptyStoneDeposit extends GenericEmptyDeposit {
    public EmptyStoneDeposit() {
        super();
        this.name = "Leeres Steinvorkommen";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITSTONE;
    }
}
