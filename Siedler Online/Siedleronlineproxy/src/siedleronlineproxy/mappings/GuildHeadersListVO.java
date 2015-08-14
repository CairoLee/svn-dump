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
public class GuildHeadersListVO extends GenericMapping {
    public Integer page;
    public Integer maxPages;
    public ArrayCollection list;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
