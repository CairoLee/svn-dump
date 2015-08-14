/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy;

import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.buildings.Buildings;
import siedleronlineproxy.forms.connection.Connection;
import siedleronlineproxy.forms.deposits.RohstoffVorkommen;
import siedleronlineproxy.forms.map.Map;
import siedleronlineproxy.forms.resourceCreations.ResourceCreationTable;
import siedleronlineproxy.forms.stock.Stock;
import siedleronlineproxy.mappings.MappingRegistry;

/**
 *
 * @author nspecht
 */
public class TheAllUpdatingThread extends Thread {

    private boolean goToSleep = true;
    private Integer forceUpdateCounter = 0;

    @Override
    public void run() {
        while (true) {
            Connection.getInstance().updateGUI();
            if (!this.goToSleep) {
                this.forceUpdateCounter = (this.forceUpdateCounter + 1) % Integer.parseInt(PropertyManager.getInstance().get("ForcedTableUpdate", "30"));
                if (this.forceUpdateCounter == 0) {
                    Buildings.getInstance().forceUpdate();
                }
                MappingRegistry.getInstance().proceed();

                Stock.getInstance().update();
                RohstoffVorkommen.getInstance().update();
                Buildings.getInstance().update();
                ResourceCreationTable.getInstance().update();
                Map.getInstance().updateMap();
            }
            try {
                sleep(1000);
            } catch (InterruptedException ex) {
                DebugLog.put(this, ex);
            }
        }
    }

    public void goToSleep() {
        this.goToSleep = true;
    }

    public void wakeUp() {
        this.goToSleep = false;
    }
}
