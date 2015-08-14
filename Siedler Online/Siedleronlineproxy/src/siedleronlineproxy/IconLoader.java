/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy;

import siedleronlineproxy.debug.DebugLog;

/**
 *
 * @author nspecht
 */
public class IconLoader {

    public javax.swing.Icon getIconById(String id, String cat) {
        org.jdesktop.application.ResourceMap resourceMap =
                org.jdesktop.application.Application.getInstance(siedleronlineproxy.SiedlerOnlineProxyApp.class).getContext().getResourceMap(this.getClass());

        
        String icon = "default.icon";
        if (resourceMap.containsKey(cat + "_" + id + ".icon")) {
            icon = cat + "_" + id + ".icon";
        } else if (resourceMap.containsKey(cat + "_default.icon")) {
            DebugLog.put(this, "No icon for "+cat+" "+id, DebugLog.LogLevel.WARNING);
            icon = cat + "_default.icon";
        } else {
            DebugLog.put(this, "No default icon for "+cat, DebugLog.LogLevel.WARNING);
        }

        try {
            return resourceMap.getIcon(icon);
        } catch (Exception e) {
            e.printStackTrace();
        }

        return resourceMap.getIcon("default.icon");
    }
}
