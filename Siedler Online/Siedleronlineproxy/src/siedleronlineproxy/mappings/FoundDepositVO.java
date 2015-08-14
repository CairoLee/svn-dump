/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.DepositRegistry;

/**
 *
 * @author nspecht
 */
public class FoundDepositVO extends GenericMapping {
    public Integer exploredDepositResult;
    public DepositVO depositVO;
    public UniqueID specialistID;

    public FoundDepositVO() {
        this.registerProceed();
    }

    @Override
    public void proceed() {
        if (this.depositVO != null) {
            DepositRegistry.getInstance().add(this.depositVO);
            if (this.depositVO.gridIdx != null) BuildingRegistry.getInstance().removePosition(this.depositVO.gridIdx);
        }
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
