/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;
import java.util.Iterator;
import siedleronlineproxy.registry.StockRegistry;

/**
 *
 * @author nspecht
 */
public class ResourceListVO extends GenericMapping {
    public ArrayCollection resourceList;

    public ResourceListVO() {
        this.registerProceedLater();
        this.registerManipulate();
    }

    @Override
    public void proceed() {
        Iterator i = this.resourceList.iterator();
        int c = 0;
        while(i.hasNext()) {
            Integer menge = (Integer)i.next();
            StockRegistry.getInstance().update(c, menge);
            c++;
        }
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
