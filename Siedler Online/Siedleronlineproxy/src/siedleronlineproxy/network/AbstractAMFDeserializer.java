/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.network;

import java.io.OutputStream;
import org.apache.commons.lang.ArrayUtils;
import siedleronlineproxy.debug.DebugLog;

/**
 *
 * @author nspecht
 */
public abstract class AbstractAMFDeserializer {
    protected byte[] message = new byte[0];

    protected abstract void init();
    protected abstract void __readMessage(byte[] mess) throws Exception;
    protected abstract void __serialize(OutputStream ops) throws Exception;
    
    public void readMessage() {
        try {
            if (!this.isAMFStream()) return;
            this.init();
            this.__readMessage(this.removeHeader());
        } catch (Exception e) {
            DebugLog.put(this, e);
        }
    }

    public void serialize(OutputStream ops) {
        try {
            if (this.isAMFStream()) {
                ops.write(this.getHeader());
                this.__serialize(ops);
            } else {
                ops.write(this.message,0,this.message.length);
            }
        } catch (Exception e) {
            DebugLog.put(this, e);
        }
    }

    public void add(byte[] mess,int length) {
        mess = ArrayUtils.subarray(mess, 0, length);
        /*
        while (mess.length > length) {
            mess = ArrayUtils.remove(mess, mess.length-1);
        }*/
        this.message = ArrayUtils.addAll(this.message, mess);
        //System.err.println(this.completed()+": "+this.removeHeader().length);
    }

    public byte[] removeHeader() {
        String tmp = new String(this.message);
        String pattern = "\r\n\r\n";
        int start = tmp.indexOf(pattern)+pattern.length();

        if (start>=this.message.length) return this.message;
        if (start > 0) {
            return AbstractAMFDeserializer.removeOffset(this.message, start);
        }
        return this.message;
    }

    public byte[] getHeader() {
        String tmp = new String(this.message);
        String pattern = "\r\n\r\n";
        int end = tmp.indexOf(pattern)+pattern.length();
        return tmp.substring(0, end).getBytes();
    }

    public static byte[] removeOffset(byte[] mess,int offset) {
        return ArrayUtils.subarray(mess, offset, mess.length);
    }

    public boolean isAMFStream() {
        if (this.message.length < 100) return false;
        String tmp = new String(this.message);

        if (!tmp.startsWith("POST") && !tmp.startsWith("GET") && !tmp.startsWith("HTTP")) return false;
        if (!tmp.contains("Content-Type: application/x-amf")) return false;
        if (!tmp.contains("Content-Length: ")) return false;

        return true;
    }

    public boolean isValidHeader(byte[] msg) {
        String tmp = new String(msg);
        if (!tmp.startsWith("POST") && !tmp.startsWith("GET") && !tmp.startsWith("HTTP")) return false;
        return true;
    }

    public boolean completed() {
        return this.completed(true);
    }

    public boolean completed(boolean quite) {
        String tmp = new String(this.message);
        
        //Kein richtiger Header, also durchpusten
        if (!this.isValidHeader(this.message)) {
            DebugLog.put(this,"Kein gültiger Header, Packet wird somit gesendet",DebugLog.LogLevel.WARNING);
            return true;
        }
        //Kein Content-Type, also behalten
        if (!tmp.contains("Content-Type: ") && !tmp.contains("\r\n\r\n")) {
            DebugLog.put(this,"Header noch nicht fertig, Content-Type fehlt",DebugLog.LogLevel.SUCCESS);
            return false;
        }
        //anderes Interessiert nicht
        if (!tmp.contains("Content-Type: application/x-amf") && tmp.contains("\r\n\r\n")) {
            DebugLog.put(this,"Header komplett, aber uninteressant",DebugLog.LogLevel.SUCCESS);
            return true;
        }
        //noch keine Content-Length, also behalten
        if (!tmp.contains("Content-Length: ") && !tmp.contains("\r\n\r\n")) {
            DebugLog.put(this,"Header noch nicht fertig, Content-Length fehlt",DebugLog.LogLevel.SUCCESS);
            return false;
        }
        if (!tmp.contains("Content-Length: ") && tmp.contains("\r\n\r\n")) {
            DebugLog.put(this,"Header fertig, Content-Length fehlt",DebugLog.LogLevel.WARNING);
            return true;
        }
        
        String pattern = "Content-Length: ";
        int start = tmp.indexOf(pattern)+pattern.length();
        pattern = "\r\n";
        int end = tmp.indexOf(pattern,start);

        //Header ist noch nicht vollständig
        if (end < start) return false;
        int length = new Integer(tmp.substring(start,end));
        int loaded = this.removeHeader().length;
        boolean ret = (length == loaded ? true : false);
        if (ret) DebugLog.put(this, "Package completly loaded", DebugLog.LogLevel.SUCCESS);
        else DebugLog.put(this, "Package incomplete", DebugLog.LogLevel.WARNING);
        return ret;
    }

    public byte[] getBuffer() {
        return this.message;
    }
}
