/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import siedleronlineproxy.registry.StockRegistry;

/**
 *
 * @author nspecht
 */
public class ResourceVO extends GenericMapping {
    public Integer amount;
    public String name_string;

    public ResourceVO() {
        MappingRegistry.getInstance().registerProceedLater(this);
    }
    @Override
    public void proceed() {
        StockRegistry.getInstance().update(this);
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
