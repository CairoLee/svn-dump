/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.mappings;

import siedleronlineproxy.PropertyManager;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.util.CollectionList;

/**
 *
 * @author nspecht
 */
public class MappingRegistry {

    private static MappingRegistry instance = null;
    private static boolean locked = false;

    public static MappingRegistry getInstance() {
        if (MappingRegistry.instance == null) {
            MappingRegistry.instance = new MappingRegistry();
        }
        return MappingRegistry.instance;
    }
    private CollectionList<GenericMapping> registry_proceed = new CollectionList<GenericMapping>();
    private CollectionList<GenericMapping> registry_proceedLater = new CollectionList<GenericMapping>();
    private CollectionList<GenericMapping> registry_manipulate = new CollectionList<GenericMapping>();

    public boolean registerProceed(GenericMapping map) {
        if (MappingRegistry.locked) {
            return false;
        }

        this.registry_proceed.add(map);
        DebugLog.put(this, this.registry_proceed.size() + " registered " + map.getClass().getCanonicalName());
        return true;
    }

    public boolean registerProceedLater(GenericMapping map) {
        if (MappingRegistry.locked) {
            return false;
        }

        this.registry_proceedLater.add(map);
        DebugLog.put(this, this.registry_proceedLater.size() + " registered " + map.getClass().getCanonicalName());
        return true;
    }

    public void proceed() {
        if (MappingRegistry.locked) {
            return;
        }
        MappingRegistry.locked = true;

        Object[] procs = this.registry_proceed.toArray();
        if (procs.length != this.registry_proceed.size()) {
            return;
        }
        this.registry_proceed.clear();
        if (procs.length > 0) {
            DebugLog.put(this, "try to proceed " + procs.length + " mappings; " + this.registry_proceedLater.size() + " waiting");
            for (int i = 0; i < procs.length; i++) {
                GenericMapping mapping = (GenericMapping) procs[i];
                if (mapping != null) {
                    try {

                        DebugLog.put(this, "Proceeding " + i + ": " + mapping.getClass().getCanonicalName());
                        mapping.proceed();
                    } catch (Exception e) {
                        DebugLog.put(this, e);
                    }
                }
            }
        } else {
            DebugLog.put(this, "Queuesize is: " + procs.length);
        }
        if (this.registry_proceedLater.size() > 0) {
            this.addToRegistry(this.registry_proceed, this.registry_proceedLater);
            DebugLog.put(this, "Queuesize after copy: " + this.registry_proceed.size());
        }
        MappingRegistry.locked = false;
    }

    private void addToRegistry(CollectionList<GenericMapping> dst, CollectionList<GenericMapping> src) {
        if (src != null) {
            dst.addAll(src);
            src.clear();
        }
    }

    public boolean registerManipulate(GenericMapping map) {
        if (MappingRegistry.locked) {
            return false;
        }
        this.registry_manipulate.add(map);
        return true;
    }

    public void manipulate(boolean incoming) {
        if (MappingRegistry.locked) {
            return;
        }
        MappingRegistry.locked = true;
        boolean m_in = new Boolean(PropertyManager.getInstance().get("manipulate_incoming", "false"));
        boolean m_out = new Boolean(PropertyManager.getInstance().get("manipulate_outgoing", "false"));

        boolean mani = m_in | m_out;

        Object[] procs = this.registry_manipulate.toArray();
        this.registry_manipulate.clear();
        DebugLog.put(this, "try to manipulate " + procs.length + " mappings");
        for (int i = 0; i < procs.length; i++) {
            GenericMapping mapping = (GenericMapping) procs[i];
            try {
                if (mani) {
                    DebugLog.put(this, "Manipulating: " + mapping.getClass().getCanonicalName());
                    mapping.manipulate(true);
                }
            } catch (Exception e) {
                DebugLog.put(this, e);
            }
        }

        MappingRegistry.locked = false;
    }
}
