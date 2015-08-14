/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.network;

import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketTimeoutException;
import siedleronlineproxy.PropertyManager;
import siedleronlineproxy.debug.DebugLog;

/**
 *
 * @author nspecht
 */
public class Proxy extends Thread {
    private int port_local = 1234;
    private ServerSocket proxy = null;

    public boolean connected = false;

    @Override
    public void run() {
        this.port_local = new Integer(PropertyManager.getInstance().get("solpport", ""+this.port_local));
        try {
            this.proxy = new ServerSocket(this.port_local);
            this.proxy.setSoTimeout(1000);
            this.connected = true;
            Socket incoming = null;
            
            while (connected) {
                try {
                    incoming = this.proxy.accept();
                    ProxyThread t = new ProxyThread(incoming);
                    t.start();
                } catch (SocketTimeoutException e) {
                    //Ist normal, wenn innerhalb des Timeouts keine Verbindung einging
                }
            }
            ProxyThreadRegistry.getInstance().disconnectAll();

        } catch (Exception e) {
            DebugLog.put(this, e);
        } finally {
            try {
                if (this.proxy.isBound()) this.proxy.close();
            } catch (Exception e) {
                
            }
            DebugLog.put(this,"Proxy closed");
        }
    }

    public void disconnect() {
        this.connected = false;
    }
}
