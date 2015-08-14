/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;

/**
 *
 * @author nspecht
 */
public class GuildVO extends GenericMapping {
    public String tag;
    public Number foundTime;
    public ArrayCollection log;
    public GuildPlayerPermissionVO playerPermissions;
    public Integer size;
    public Integer id;
    public ArrayCollection ranks;
    public Integer bannerID;
    public String desciption;
    public String name;
    public String motd;
    public Number cacheTimestamp;
    public Integer maxSize;
    public ArrayCollection members;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
