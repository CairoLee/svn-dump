/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class NewMailCountVO extends GenericMapping {
    public Integer count;

    public NewMailCountVO() {
        this.registerProceedLater();
    }

    @Override
    public void proceed() {
        if (this.count>0) System.out.println("Mails: "+count);
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
