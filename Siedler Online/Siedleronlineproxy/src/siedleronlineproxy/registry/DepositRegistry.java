/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry;

import java.util.Collection;
import java.util.Date;
import siedleronlineproxy.mappings.DepositVO;
import siedleronlineproxy.util.CollectionTable;

/**
 *
 * @author nspecht
 */
public class DepositRegistry {

    private static DepositRegistry instance = null;

    public static DepositRegistry getInstance() {
        if (DepositRegistry.instance == null) {
            DepositRegistry.instance = new DepositRegistry();
        }
        return DepositRegistry.instance;
    }
    CollectionTable<Integer, DepositVO> deposits = new CollectionTable<Integer,DepositVO>();
    public Date lastChange = new Date();

    public void onChange() {
        this.lastChange = new Date();
    }
    
    public void add(DepositVO dep) {
        if (dep==null) return;
        this.deposits.put(dep.gridIdx, dep);
        this.onChange();
    }

    public Collection<DepositVO> getItems() {
        return this.deposits.values();
    }
    
    public DepositVO getDepositByPosition(int p) {
        return this.deposits.get(p);
    }

    public void reset() {
        this.deposits.clear();
        this.onChange();
    }
}
