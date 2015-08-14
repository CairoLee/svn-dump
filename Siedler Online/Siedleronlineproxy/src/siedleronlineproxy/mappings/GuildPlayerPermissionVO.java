/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class GuildPlayerPermissionVO extends GenericMapping {
    public Integer invite;
    public Integer kick;
    public Integer ranksEdit;
    public Integer officerNote;
    public Integer joinRequestAllow;
    public Integer guildMail;
    public Integer officersChannel;
    public Integer description;
    public Integer joinRequestAccept;
    public Integer motd;
    public Integer ranksAssign;
    public Integer note;
    public Integer banner;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
