/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.network;

import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.util.CollectionList;

/**
 *
 * @author nspecht
 */
public class ProxyThreadRegistry {
    private CollectionList<ProxyThread> registry = new CollectionList<ProxyThread>();

    private static ProxyThreadRegistry instance = null;
    public static ProxyThreadRegistry getInstance() {
        if (ProxyThreadRegistry.instance == null) ProxyThreadRegistry.instance = new ProxyThreadRegistry();
        return ProxyThreadRegistry.instance;
    }

    public void add(ProxyThread thread) {
        this.registry.add(thread);
        DebugLog.put(this, this.registry.size()+" active threads");
    }

    public void remove(ProxyThread thread) {
        this.registry.remove(thread);
        DebugLog.put(this, this.registry.size()+" active threads");
    }

    public void disconnectAll() {
        for (ProxyThread t : this.registry) {
            t.disconnect();
        }
    }
}
