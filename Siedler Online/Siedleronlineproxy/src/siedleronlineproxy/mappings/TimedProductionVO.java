/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;

/**
 *
 * @author nspecht
 */
public class TimedProductionVO extends GenericMapping {
    public Integer amount;
    public String type_string;
    public Integer playerId;
    public ArrayCollection uniqueIds;
    public Number collectedTime;
    public Integer producedItems;
    public Integer productionType;
    public UniqueID uniqueId;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
