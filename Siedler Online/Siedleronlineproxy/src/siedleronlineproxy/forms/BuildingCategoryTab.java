/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.forms;

import java.awt.GridBagLayout;
import java.util.Hashtable;
import javax.swing.JComponent;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTabbedPane;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.util.CollectionTable;

/**
 *
 * @author nspecht
 */
public class BuildingCategoryTab extends JTabbedPane {

    JComponent[] items = new JComponent[Building.BuildingCategory.ALL.ordinal() + 1];
    String[] itemnames = new String[Building.BuildingCategory.ALL.ordinal() + 1];
    CollectionTable<String, JComponent> additionalitems = new CollectionTable<String, JComponent>();

    public BuildingCategoryTab() {
        org.jdesktop.application.ResourceMap resourceMap = org.jdesktop.application.Application.getInstance(siedleronlineproxy.SiedlerOnlineProxyApp.class).getContext().getResourceMap(Building.class);
        for (Building.BuildingCategory cat : Building.BuildingCategory.values()) {
            this.items[cat.ordinal()] = this.createGenericPanel();
            this.itemnames[cat.ordinal()] = resourceMap.getString(cat.toString() + ".text");
        }
        this.update();
    }

    public JPanel createGenericPanel() {
        JPanel panel = new JPanel();
        GridBagLayout layout = new java.awt.GridBagLayout();
        panel.setLayout(layout);
        
        //uncomment these lines for top-aligment
        /*
        panel.setAlignmentY(TOP_ALIGNMENT);
        JPanel placeholder = new JPanel();
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.gridx = 0;
        gbc.gridy = 200;
        gbc.weighty = 1;
        panel.add(placeholder, gbc);
         */
        return panel;
    }

    public void update() {
        this.removeAll();
        for (int i = 0; i < this.items.length; i++) {
            JScrollPane scroll = new JScrollPane(this.items[i]);
            this.addTab(this.itemnames[i], scroll);
        }
        for (String name : this.additionalitems.keySet()) {
            JScrollPane scroll = new JScrollPane(this.additionalitems.get(name));
            this.addTab(name, scroll);
        }
    }

    public JComponent getItem(Building.BuildingCategory cat) {
        return this.items[cat.ordinal()];
    }

    public void setItem(Building.BuildingCategory cat, JComponent item) {
        this.items[cat.ordinal()] = item;
        this.update();
    }

    public void addItem(String name, JComponent item) {
        this.additionalitems.put(name, item);
        this.update();
    }
}
