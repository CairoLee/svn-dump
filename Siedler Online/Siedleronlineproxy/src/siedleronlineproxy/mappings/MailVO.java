/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class MailVO extends GenericMapping {
    public Number timestamp;
    public Integer id;
    public Object body;
    public String senderName;
    public String subject;
    public Integer deletedAr;
    public boolean read;
    public Integer senderId;
    public Integer type;
    public Integer reciepientId;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
