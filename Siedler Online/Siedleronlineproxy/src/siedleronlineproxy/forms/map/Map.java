/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Map.java
 *
 * Created on 20.07.2011, 12:32:08
 */
package siedleronlineproxy.forms.map;

import java.awt.GridBagConstraints;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.util.Date;
import javax.swing.ImageIcon;
import javax.swing.JCheckBox;
import javax.swing.JPanel;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.mappings.DepositVO;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.DepositRegistry;
import siedleronlineproxy.registry.building.GenericBuilding;
import siedleronlineproxy.registry.building.UnknownBuilding;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class Map extends javax.swing.JPanel {

    private static Map instance = null;
    public static Map getInstance() {
        return Map.instance;
    }
    private CollectionEnumTable<BuildingTypes, JCheckBox> filterBoxes_building = new CollectionEnumTable<Building.BuildingTypes, JCheckBox>(Building.BuildingTypes.class);
    private CollectionEnumTable<Products, JCheckBox> filterBoxes_resource = new CollectionEnumTable<Resource.Products, JCheckBox>(Resource.Products.class);

    private Date lastChange = new Date();
    
    /** Creates new form Map */
    public Map() {
        initComponents();
        Map.instance = this;
        for (int i = 0; i < Building.BuildingCategory.values().length; i++) {
            JCheckBox checkall = new JCheckBox("Alle auswählen");
            checkall.setName(Building.BuildingCategory.values()[i].toString());
            checkall.addActionListener(new java.awt.event.ActionListener() {

                public void actionPerformed(ActionEvent e) {
                    checkAll((JCheckBox) e.getSource());
                }
            });
            GridBagConstraints gbc = new GridBagConstraints();
            gbc.gridx = 1;
            gbc.gridy = 1;
            gbc.fill = GridBagConstraints.BOTH;
            gbc.anchor = GridBagConstraints.WEST;
            this.buildingCategoryTab1.getItem(Building.BuildingCategory.values()[i]).add(checkall, gbc);

            JPanel placeholder = new JPanel();
            gbc = new GridBagConstraints();
            gbc.gridx = 1;
            gbc.gridy = 2;
            gbc.fill = GridBagConstraints.BOTH;
            gbc.anchor = GridBagConstraints.WEST;
            this.buildingCategoryTab1.getItem(Building.BuildingCategory.values()[i]).add(placeholder, gbc);
        }

        //Buildings
        for (int i = 0; i < Building.BuildingTypes.__SIZE.ordinal(); i++) {
            try {
                Class c = Building.getInstance().classes[i];

                GenericBuilding g = (GenericBuilding) c.newInstance();
                g.setType(Building.BuildingTypes.values()[i]);

                if (!(g instanceof UnknownBuilding)) {
                    Image ic = ((ImageIcon) Building.getIconByType(Building.BuildingTypes.values()[i])).getImage();
                    ic = ic.getScaledInstance(16, 16, Image.SCALE_FAST);

                    JCheckBox box = new JCheckBox();
                    box.setName(Building.BuildingTypes.values()[i].toString());
                    box.setText(g.getName());
                    box.setIcon(new ImageIcon(ic));
                    box.addActionListener(new java.awt.event.ActionListener() {

                        public void actionPerformed(java.awt.event.ActionEvent evt) {
                            lastChange.setTime(0);
                            updateMap();
                        }
                    });

                    GridBagConstraints gbc = new GridBagConstraints();
                    gbc.gridx = 1;
                    gbc.gridy = 3 + i;
                    gbc.fill = GridBagConstraints.BOTH;
                    gbc.anchor = GridBagConstraints.WEST;
                    this.buildingCategoryTab1.getItem(g.getCategory()).add(box, gbc);
                    //this.buildingCategoryTab1.getItem(Building.BuildingCategory.ALL).add(box, gbc);
                    filterBoxes_building.put(Building.BuildingTypes.values()[i], box);
                }
            } catch (Exception e) {
                DebugLog.put(this, e);
            }
        }
        //Deposits
        JPanel resPanel = this.buildingCategoryTab1.createGenericPanel();
        this.buildingCategoryTab1.addItem("Ressourcen", resPanel);
        for (int i = 0; i < Resource.Deposits.__SIZE.ordinal(); i++) {
            Resource.Products p = Resource.Products.valueOf(Resource.Deposits.values()[i].toString());
            Image ic = ((ImageIcon) Resource.getIconByType(p)).getImage();
            ic = ic.getScaledInstance(16, 16, Image.SCALE_FAST);

            JCheckBox box = new JCheckBox();
            box.setName(p.toString());
            box.setText(Resource.getNameByType(p));
            box.setIcon(new ImageIcon(ic));
            box.addActionListener(new java.awt.event.ActionListener() {
                public void actionPerformed(java.awt.event.ActionEvent evt) {
                    lastChange.setTime(0);                            
                    updateMap();
                }
            });

            GridBagConstraints gbc = new GridBagConstraints();
            gbc.gridx = 1;
            gbc.gridy = 2 + i;
            gbc.fill = GridBagConstraints.BOTH;
            gbc.anchor = GridBagConstraints.WEST;

            resPanel.add(box, gbc);
            //this.buildingCategoryTab1.getItem(Building.BuildingCategory.ALL).add(box, gbc);

            filterBoxes_resource.put(p, box);
        }
    }

    public void checkAll(JCheckBox box) {
        this.mapPanel1.stopUpdating();
        Building.BuildingCategory cat = Building.BuildingCategory.valueOf(box.getName());
        for (int i = 0; i < Building.BuildingTypes.__SIZE.ordinal(); i++) {
            try {
                Class c = Building.getInstance().classes[i];
                GenericBuilding g = (GenericBuilding) c.newInstance();
                if (g.getCategory() == cat) {
                    JCheckBox cbox = this.filterBoxes_building.get(Building.BuildingTypes.values()[i]);
                    cbox.setSelected(box.isSelected());
                }
            } catch (Exception e) {
                DebugLog.put(this, e);
            }            
        }
        this.lastChange.setTime(0);
        this.mapPanel1.continueUpdating();
    }

    public void setMap(String zoneMapName) {
        DebugLog.put(this, "Your are now on map: "+zoneMapName);
    }
    
    public void updateMap() {
        if (!(
                this.lastChange.getTime() < BuildingRegistry.getInstance().lastChange.getTime() 
                || this.lastChange.getTime() < DepositRegistry.getInstance().lastChange.getTime()
                )) return;
        
        this.mapPanel1.clearSpots();
        for (GenericBuilding b : BuildingRegistry.getInstance().getItems()) {
            JCheckBox box = filterBoxes_building.get(b.getType());
            if (box != null) {
                if (box.isSelected()) {
                    this.mapPanel1.addSpot(b);
                }
            }
        }

        for (DepositVO dvo : DepositRegistry.getInstance().getItems()) {
            Resource.Deposits d = Resource.Deposits.valueOf(dvo.name_string.toUpperCase());
            Resource.Products p = Resource.Products.valueOf(d.toString());
            if (filterBoxes_resource.get(p).isSelected()) {
                this.mapPanel1.addSpot(dvo);
            }
        }
        this.lastChange = new Date();
        this.mapPanel1.repaintMap();
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {
        java.awt.GridBagConstraints gridBagConstraints;

        jSplitPane1 = new javax.swing.JSplitPane();
        jPanel2 = new javax.swing.JPanel();
        jButton1 = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jSlider1 = new javax.swing.JSlider();
        jScrollPane1 = new javax.swing.JScrollPane();
        mapPanel1 = new siedleronlineproxy.forms.map.MapPanel();
        buildingCategoryTab1 = new siedleronlineproxy.forms.BuildingCategoryTab();

        setName("Form"); // NOI18N
        setLayout(new java.awt.GridBagLayout());

        jSplitPane1.setDividerLocation(400);
        jSplitPane1.setName("jSplitPane1"); // NOI18N

        jPanel2.setName("jPanel2"); // NOI18N
        jPanel2.setLayout(new java.awt.GridBagLayout());

        org.jdesktop.application.ResourceMap resourceMap = org.jdesktop.application.Application.getInstance(siedleronlineproxy.SiedlerOnlineProxyApp.class).getContext().getResourceMap(Map.class);
        jButton1.setText(resourceMap.getString("jButton1.text")); // NOI18N
        jButton1.setName("jButton1"); // NOI18N
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        jPanel2.add(jButton1, gridBagConstraints);

        jLabel1.setHorizontalAlignment(javax.swing.SwingConstants.RIGHT);
        jLabel1.setText(resourceMap.getString("jLabel1.text")); // NOI18N
        jLabel1.setToolTipText(resourceMap.getString("jLabel1.toolTipText")); // NOI18N
        jLabel1.setName("jLabel1"); // NOI18N
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.gridwidth = java.awt.GridBagConstraints.REMAINDER;
        gridBagConstraints.gridheight = java.awt.GridBagConstraints.REMAINDER;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.anchor = java.awt.GridBagConstraints.NORTHWEST;
        jPanel2.add(jLabel1, gridBagConstraints);

        jSlider1.setMaximum(4);
        jSlider1.setMinimum(-2);
        jSlider1.setPaintLabels(true);
        jSlider1.setPaintTicks(true);
        jSlider1.setSnapToTicks(true);
        jSlider1.setValue(0);
        jSlider1.setName("jSlider1"); // NOI18N
        jSlider1.addChangeListener(new javax.swing.event.ChangeListener() {
            public void stateChanged(javax.swing.event.ChangeEvent evt) {
                jSlider1StateChanged(evt);
            }
        });
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.anchor = java.awt.GridBagConstraints.NORTHWEST;
        jPanel2.add(jSlider1, gridBagConstraints);

        jScrollPane1.setViewportBorder(new javax.swing.border.LineBorder(new java.awt.Color(0, 0, 0), 1, true));
        jScrollPane1.setMaximumSize(new java.awt.Dimension(100, 100));
        jScrollPane1.setName("jScrollPane1"); // NOI18N

        mapPanel1.setName("mapPanel1"); // NOI18N

        javax.swing.GroupLayout mapPanel1Layout = new javax.swing.GroupLayout(mapPanel1);
        mapPanel1.setLayout(mapPanel1Layout);
        mapPanel1Layout.setHorizontalGroup(
            mapPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 2048, Short.MAX_VALUE)
        );
        mapPanel1Layout.setVerticalGroup(
            mapPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 1313, Short.MAX_VALUE)
        );

        jScrollPane1.setViewportView(mapPanel1);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.gridwidth = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        jPanel2.add(jScrollPane1, gridBagConstraints);

        jSplitPane1.setLeftComponent(jPanel2);

        buildingCategoryTab1.setName("buildingCategoryTab1"); // NOI18N
        jSplitPane1.setRightComponent(buildingCategoryTab1);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        add(jSplitPane1, gridBagConstraints);
    }// </editor-fold>//GEN-END:initComponents

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        this.updateMap();
    }//GEN-LAST:event_jButton1ActionPerformed

    private void jSlider1StateChanged(javax.swing.event.ChangeEvent evt) {//GEN-FIRST:event_jSlider1StateChanged
        this.mapPanel1.setZoom(this.jSlider1.getValue());
        this.mapPanel1.repaintMap();
    }//GEN-LAST:event_jSlider1StateChanged
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private siedleronlineproxy.forms.BuildingCategoryTab buildingCategoryTab1;
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JSlider jSlider1;
    private javax.swing.JSplitPane jSplitPane1;
    private siedleronlineproxy.forms.map.MapPanel mapPanel1;
    // End of variables declaration//GEN-END:variables
}
