/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy;

import javax.swing.JComboBox;
import javax.swing.UIManager;
import javax.swing.UIManager.LookAndFeelInfo;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.SortedComboBoxModel;
import siedleronlineproxy.util.CollectionTable;

/**
 *
 * @author nspecht
 */
public class LookAndFeel {
    private CollectionTable<String,String> themes = new CollectionTable<String,String>();

    private static LookAndFeel instance = null;
    public static LookAndFeel getInstance() {
        if (LookAndFeel.instance == null) LookAndFeel.instance = new LookAndFeel();
        return LookAndFeel.instance;
    }

    public LookAndFeel() {
        LookAndFeelInfo[] themeArray = UIManager.getInstalledLookAndFeels();
        for(int i = 0; i < themeArray.length; i++) {
            this.themes.put(themeArray[i].getName(), themeArray[i].getClassName());
        }

        this.themes.put("SeaGlass", "com.seaglasslookandfeel.SeaGlassLookAndFeel");
        //this.themes.put("Oyoaha", "com.oyoaha.swing.plaf.oyoaha.OyoahaLookAndFeel");
        //jTattoo
        this.addJTattooTheme("Acryl");
        this.addJTattooTheme("Aero");
        this.addJTattooTheme("Aluminium");
        this.addJTattooTheme("Bernstein");
        this.addJTattooTheme("Fast");
        this.addJTattooTheme("Graphite");
        this.addJTattooTheme("HiFi");
        this.addJTattooTheme("Luna");
        this.addJTattooTheme("McWin");
        this.addJTattooTheme("Mint");
        this.addJTattooTheme("Noire");
        this.addJTattooTheme("Smart");
    }

    @Override
    public String toString() {
        StringBuilder buf = new StringBuilder();
        for (String key : this.themes.keySet()) {
            buf.append(key).append(" ").append(this.themes.get(key)).append("\n");
        }
        return buf.toString();
    }

    public void setLayout(String key) {
        try {
            PropertyManager.getInstance().put("theme", key);
            UIManager.setLookAndFeel(this.themes.get(key));
            Runtime.getRuntime().exec("java -jar SiedlerOnlineProxy.jar");
            System.exit(0);
        } catch (Exception e) {
            DebugLog.put(this, e);
        }
    }

    public void setLayout() {
        String theme = (String)PropertyManager.getInstance().get("theme", "Metal");
        System.out.println("Set layout to " + theme + "("+this.themes.get(theme)+")");
        try {
            UIManager.setLookAndFeel(this.themes.get(theme));
        } catch (Exception e) {
            PropertyManager.getInstance().put("theme", "Metal");
            DebugLog.put(this,e);
        }
    }

    public void fillComboBox(JComboBox box) {
        box.removeAllItems();
        
        box.setModel(new SortedComboBoxModel());
        for (String key : this.themes.keySet()) {
            box.addItem(key);
        }
    }

    private void addJTattooTheme(String name) {
        this.themes.put("jTattoo/"+name,"com.jtattoo.plaf."+name.toLowerCase()+"."+name+"LookAndFeel");
    }
}
