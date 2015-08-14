/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy;

import java.io.File;
import java.util.Properties;
import javax.swing.JCheckBox;
import javax.swing.JComboBox;
import javax.swing.JSpinner;
import javax.swing.JTextField;
import siedleronlineproxy.debug.DebugLog;

/**
 *
 * @author nspecht
 */
public class PropertyManager {

    private static PropertyManager instance = null;

    public static PropertyManager getInstance() {
        if (PropertyManager.instance == null) {
            PropertyManager.instance = new PropertyManager();
        }
        return PropertyManager.instance;
    }
    private final static String PROPEXT = ".properties";
    private Properties props = null;
    private File propertyFile = null;

    public PropertyManager() {
        try {
            this.props = new Properties();
            this.propertyFile = new File(System.getProperty("user.home"), ".siedleronlineproxy" + PropertyManager.PROPEXT);
            if (!this.propertyFile.exists()) {
                this.propertyFile.createNewFile();
            }

            java.io.InputStream propStream;
            propStream = new java.io.FileInputStream(this.propertyFile);
            this.props.load(propStream);
            propStream.close();

        } catch (Exception ex) {
            DebugLog.put(this, ex);
        }
    }

    public void save() {
        try {
            java.io.OutputStream propStream;
            propStream = new java.io.FileOutputStream(this.propertyFile);
            this.props.store(propStream, "Properties for SiedlerOnlineProxy");
            propStream.close();
        } catch (Exception e) {
            DebugLog.put(this, e);
        }
    }

    public boolean keyExists(String key) {
        return this.props.containsKey(key);
    }

    public String get(String key, String defaultValue) {
        if (!this.keyExists(key)) {
            this.put(key, defaultValue);
        }
        return this.props.getProperty(key, defaultValue);
    }

    public void put(Object key, Object value) {
        this.props.put(key, value);
        this.save();
    }

    public static void LoadTextField(Object obj) {
        JTextField comp = (JTextField)obj;
        comp.setText(PropertyManager.getInstance().get(comp.getName(),""));
    }

    public static void SaveTextField(Object obj) {
        JTextField comp = (JTextField)obj;
        PropertyManager.getInstance().put(comp.getName(),comp.getText());
    }

    public static void LoadSpinner(Object obj) {
        JSpinner comp = (JSpinner)obj;
        comp.setValue(new Integer(PropertyManager.getInstance().get(comp.getName(),""+comp.getValue())));
    }

    public static void SaveSpinner(Object obj) {
        JSpinner comp = (JSpinner)obj;
        PropertyManager.getInstance().put(comp.getName(),""+comp.getValue());
    }

    public static void LoadComboBox(Object obj) {
        JComboBox comp = (JComboBox)obj;
        String selected = PropertyManager.getInstance().get(comp.getName(),"");
        for (int i=0;i<comp.getItemCount();i++) {
            if (comp.getItemAt(i).equals(selected)) comp.setSelectedIndex(i);
        }
    }

    public static void SaveComboBox(Object obj) {
        JComboBox comp = (JComboBox)obj;
        PropertyManager.getInstance().put(comp.getName(),""+comp.getSelectedItem().toString());
    }

    public static void LoadCheckbox(Object obj) {
        JCheckBox comp = (JCheckBox)obj;
        comp.setSelected(new Boolean(PropertyManager.getInstance().get(comp.getName(),""+comp.isSelected())));
    }

    public static void SaveCheckbox(Object obj) {
        JCheckBox comp = (JCheckBox)obj;
        PropertyManager.getInstance().put(comp.getName(),""+comp.isSelected());
    }
}
