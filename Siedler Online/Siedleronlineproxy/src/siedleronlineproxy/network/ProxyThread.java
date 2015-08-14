/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.network;

import java.io.IOException;
import java.net.Socket;
import java.net.SocketException;
import java.net.UnknownHostException;
import siedleronlineproxy.PropertyManager;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.mappings.MappingRegistry;

/**
 *
 * @author nspecht
 */
public class ProxyThread extends Thread {

    private boolean connected = false;
    private Socket incoming = null;
    private Socket outgoing = null;
    private byte threadType = 0;
    private String caption = null;

    public ProxyThread(Socket in) {
        this.incoming = in;
        ProxyThreadRegistry.getInstance().add(this);
    }

    public ProxyThread(Socket in, Socket out) {
        this(in);
        this.outgoing = out;
    }

    public void setThreadType(byte t) {
        this.threadType = t;
    }

    public void setCaption(String c) {
        this.caption = c;
    }

    private String getTarget(byte[] buffer) {
        String tmp = new String(buffer);
        int start = tmp.indexOf("Host: ");
        if (start < 0) {
            return null;
        }
        start += "Host: ".length();
        int end = tmp.indexOf("\r\n", start);

        return tmp.substring(start, end);
    }

    private boolean setUpOutgoingConnection(byte[] buffer) throws UnknownHostException, IOException {
        //Init outgoing connection
        if (this.outgoing == null) {
            if (new Boolean(PropertyManager.getInstance().get("useproxy", "" + false))) {
                //System.out.println(this.getTarget(buffer));
                this.outgoing = new Socket(
                        PropertyManager.getInstance().get("proxyname", ""),
                        new Integer(PropertyManager.getInstance().get("proxyport", "1")));
            } else {
                String target = this.getTarget(buffer);
                if (target == null) {
                    return false;
                }
                DebugLog.put(this, "Initiating Connection to: " + target);
                this.outgoing = new Socket(
                        target,
                        80);

            }
            ProxyThread ret = new ProxyThread(this.outgoing, this.incoming);
            ret.setThreadType((byte) 1);
            ret.setCaption(this.caption);
            ret.start();
        }
        return true;
    }

    @Override
    public void run() {
        //Debuging done
        try {

            this.connected = true;
            //read from socket
            PreferedAMFDeserializer amf = new PreferedAMFDeserializer();
            while (this.connected) {
                byte[] buffer = new byte[1024];
                int read = this.incoming.getInputStream().read(buffer, 0, buffer.length);

                boolean manipulate = (new Boolean(PropertyManager.getInstance().get("manipulate_incoming", "false")) & this.threadType == 1)
                        | (new Boolean(PropertyManager.getInstance().get("manipulate_outgoing", "false")) & this.threadType == 0);

                if (read < 0) {
                    this.incoming.close();
                    this.outgoing.close();
                } else {
                    amf.add(buffer, read);
                    if (this.outgoing != null && (!manipulate || !amf.canBeManipulated)) {
                        this.outgoing.getOutputStream().write(buffer, 0, read);
                    }
                    if (this.outgoing == null) {
                        if (this.setUpOutgoingConnection(amf.getBuffer()) && (!manipulate || !amf.canBeManipulated)) {
                            this.outgoing.getOutputStream().write(amf.getBuffer(), 0, amf.getBuffer().length);
                        }
                    }

                    if (amf.completed()) {
                        amf.readMessage();
                        if (manipulate) {
                            MappingRegistry.getInstance().manipulate(this.threadType == 1);

                            if (this.outgoing != null && amf.canBeManipulated) {
                                //System.err.print('s');
                                amf.serialize(this.outgoing.getOutputStream());
                            }
                        }
                        amf = new PreferedAMFDeserializer();
                        amf.canBeManipulated = manipulate;
                    }
                }
            }
        } catch (SocketException e) {
            //Das brauche ich nicht zu wissen
        } catch (UnknownHostException e) {
            System.exit(-1);
        } catch (Exception e) {
            DebugLog.put(this, e);
        } finally {
            ProxyThreadRegistry.getInstance().remove(this);
            try {
                if (this.incoming != null) {
                    if (!this.incoming.isClosed()) {
                        this.incoming.close();
                    }
                }
                if (this.outgoing != null) {
                    if (!this.outgoing.isClosed()) {
                        this.outgoing.close();
                    }
                }
            } catch (Exception e) {
                DebugLog.put(this, e);
            }
        }
    }

    public void disconnect() {
        this.connected = false;
    }
}
