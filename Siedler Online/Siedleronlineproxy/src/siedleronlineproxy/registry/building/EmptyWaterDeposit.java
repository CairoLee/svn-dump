package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyWaterDeposit extends GenericEmptyDeposit {
    public EmptyWaterDeposit() {
        super();
        this.name = "Ausgetrockneter Brunnen";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITWATER;
    }
}
