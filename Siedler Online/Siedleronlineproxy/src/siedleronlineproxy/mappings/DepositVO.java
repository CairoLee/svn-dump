/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import javax.swing.Icon;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.DepositRegistry;

/**
 *
 * @author nspecht
 */
public class DepositVO extends GenericMapping {
    public Integer amount = 0;
    public Integer emptied = 0;
    public String name_string = "";
    public Integer depositGroupId = 0;
    public Integer gridIdx = 0;
    public Integer maxAmount = 0;
    public Integer accessible = 0;
    public String goSetListName_string="";

    public DepositVO() {
        this.registerProceedLater();
    }

    @Override
    public void proceed() {
        DepositRegistry.getInstance().add(this);
        BuildingRegistry.getInstance().removePosition(this.gridIdx);
    }

    @Override
    public void manipulate(boolean incoming) {
    }

    public Icon getIcon() {
        return Resource.getIconByString(this.name_string);
    }

    public String getName() {
        return Resource.getNameByString(this.name_string);
    }
}
