/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import siedleronlineproxy.debug.DebugLog;

/**
 *
 * @author nspecht
 */
public abstract class GenericMapping {
    public void registerProceed() {
        GenericMapping.RegistyThread t = new RegistyThread(this,GenericMapping.RegistyThread.Type.PROCEED);
        t.start();
    }

    public void registerProceedLater() {
        GenericMapping.RegistyThread t = new RegistyThread(this,GenericMapping.RegistyThread.Type.PROCEEDLATER);
        t.start();
    }

    public void registerManipulate() {
        GenericMapping.RegistyThread t = new RegistyThread(this,GenericMapping.RegistyThread.Type.MANIPULATE);
        t.start();
    }



    public static class RegistyThread extends Thread {
        public enum Type {
            PROCEED, PROCEEDLATER, MANIPULATE
        };
        GenericMapping mapping = null;
        Type type;
        public RegistyThread(GenericMapping m,Type t){
            this.mapping = m;
            this.type = t;
        }

        @Override
        public void run() {
            switch(this.type) {
                case PROCEED      : while(!MappingRegistry.getInstance().registerProceed     (this.mapping)) {try {sleep(10);} catch (Exception e) {}} break;
                case PROCEEDLATER : while(!MappingRegistry.getInstance().registerProceedLater(this.mapping)) {try {sleep(10);} catch (Exception e) {}} break;
                case MANIPULATE   : while(!MappingRegistry.getInstance().registerManipulate  (this.mapping)) {try {sleep(10);} catch (Exception e) {}} break;
                default : DebugLog.put(this, "Registrytype unknown",DebugLog.LogLevel.ERROR);
            }
        }
    }

    public abstract void proceed();
    public abstract void manipulate(boolean incoming);
}
