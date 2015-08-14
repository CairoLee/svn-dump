/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry;

import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.mappings.ResourceVO;

/**
 *
 * @author nspecht
 */
public class StockRegistry {
    private static StockRegistry instance = null;
    public static StockRegistry getInstance() {
        if (StockRegistry.instance == null) StockRegistry.instance = new StockRegistry();
        return StockRegistry.instance;
    }
    public int[] menge = new int[Resource.Products.__SIZE.ordinal()];

    public void update(int index,int m) {
        if (index < this.menge.length) {
            this.menge[index] = m;
        } else {
            DebugLog.put(this,"unknown stock item: "+index+" capacity: "+m, DebugLog.LogLevel.ERROR);
        }
    }
    public void update(ResourceVO res) {
        int id = Resource.Products.valueOf(res.name_string.toUpperCase()).ordinal();
        StockRegistry.getInstance().update(id, res.amount);
    }

    public void reset() {
        for(int i=0;i<this.menge.length;i++) {
            this.menge[i]=0;
        }
    }
}
