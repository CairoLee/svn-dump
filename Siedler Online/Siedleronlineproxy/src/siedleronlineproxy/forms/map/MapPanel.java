/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.forms.map;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.GraphicsConfiguration;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Image;
import java.awt.image.BufferedImage;
import java.text.DecimalFormat;
import javax.swing.ImageIcon;
import javax.swing.JPanel;
import siedleronlineproxy.IconLoader;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.GridPosition;
import siedleronlineproxy.mappings.DepositVO;
import siedleronlineproxy.registry.building.GenericBuilding;
import siedleronlineproxy.util.CollectionList;

/**
 *
 * @author nspecht
 */
public final class MapPanel extends JPanel {
    class SpotItem {
        ImageIcon icon = null;
        String text = null;
        GridPosition position = null;
        GridPosition pathto = null;
        Color color = null;
    }
    private Image map = null;

    private int zoom = 1;
    private Integer offsetX = null;
    private Integer offsetY = null;
    private Double stepX = null;
    private Double stepY = null;

    private CollectionList<SpotItem> spots = new CollectionList<SpotItem>();
    private boolean pauseUpdate = false;

    public MapPanel() {
        super();
        this.setZoom(0);
        this.repaintMap();
    }
    
    @Override
    public void paintComponent(Graphics g) {
        if (g != null) g.clearRect(0, 0, this.getWidth(), this.getHeight());
        super.paintComponent(g);
        try {
            if (g != null) g.drawImage(this.map, 0, 0, null);
        } catch (java.lang.OutOfMemoryError e) {
            this.zoom = this.zoom+1;
            this.repaintMap();
        }
    }

    public  void repaintMap() {
        if (this.pauseUpdate) return;
        try {
            IconLoader il = new IconLoader();
            this.map = ((ImageIcon)(il.getIconById("map", "stuff"))).getImage();
            BufferedImage bimg = null;


            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            try {
                GraphicsDevice gd = ge.getDefaultScreenDevice();
                GraphicsConfiguration gc = gd.getDefaultConfiguration();
                bimg = gc.createCompatibleImage(this.map.getWidth(null), this.map.getHeight(null),BufferedImage.TYPE_INT_RGB);
            } catch (Exception e) {
                DebugLog.put(this, e);
            } finally {
                if (bimg != null) {
                    bimg.createGraphics().drawImage(((ImageIcon)(il.getIconById("map", "stuff"))).getImage(), 0, 0, null);
                    this.map = bimg;
                }
            }

            if (bimg == null) return;

            if (this.map instanceof BufferedImage) {
                Graphics g = this.map.getGraphics();

                //Positionen
                for(SpotItem spot : this.spots) {
                    if (spot.color == null) g.setColor(Color.yellow);
                    else g.setColor(spot.color);
                    Integer[] position = this.getPosition(spot.position);
                    g.drawArc(position[0]-16, position[1]-16, 32, 32, 0, 360);
                    g.drawArc(position[0]- 8, position[1]- 8, 16, 16, 0, 360);
                    g.drawArc(position[0]- 4, position[1]- 4,  8,  8, 0, 360);
                    g.drawArc(position[0]- 2, position[1]- 2,  4,  4, 0, 360);
                    if (spot.icon != null) {
                        g.drawImage(spot.icon.getImage(), position[0] - 16, position[1] - 16, 32, 32, null);
                    }
                    if (spot.text != null) {
                        g.setColor(Color.white);
                        g.drawString(spot.text, position[0]-16, position[1]+10);
                    }
                    if (spot.pathto != null) {
                        g.setColor(Color.ORANGE);
                        Integer[] from = this.getPosition(spot.position);
                        Integer[] to = this.getPosition(spot.pathto);
                        g.drawLine(from[0], from[1], to[0], to[1]);
                    }
                }
            }

            //Zoom
            int width = (int)(this.map.getWidth(null) / Math.pow(2, this.zoom));
            int height = (int)(this.map.getHeight(null) / Math.pow(2, this.zoom));
            Dimension d = new Dimension(width,height);
            this.setMaximumSize(d);
            this.setMinimumSize(d);
            this.setPreferredSize(d);
            this.map = (Image)this.map.getScaledInstance(width, height, Image.SCALE_FAST);
        } catch (java.lang.OutOfMemoryError e) {
            this.zoom = this.zoom+1;
            this.repaintMap();
        }
        this.updateUI();
        this.repaint();
    }

    public void setZoom(int z) {
        this.zoom = z;
    }

    public void clearSpots() {
        this.spots.clear();
    }

    public void addSpot(GridPosition p) {
        SpotItem i = new SpotItem();
        i.position = p;
        this.spots.add(i);
    }

    public void addSpot(GenericBuilding b) {
        SpotItem i = new SpotItem();
        i.position = new GridPosition(b.getBuildingVO().buildingGrid);
        i.text = b.getName().substring(0, 4)+". Lvl."+b.getBuildingVO().upgradeLevel;
        i.icon = (ImageIcon)b.getIcon();
        if (b.getType().toString().startsWith("MINEDEPLETEDDEPOSIT")) i.color = Color.red;
        if (b.getResourceCreation() != null) {
            int pos = b.getResourceCreation().depositBuildingGridPos;
            if (pos != 0) i.pathto = new GridPosition(pos);
        }
        this.spots.add(i);
    }

    public void addSpot(DepositVO dvo) {
        DecimalFormat df = new DecimalFormat("0.00");
        SpotItem i = new SpotItem();
        i.position = new GridPosition(dvo.gridIdx);
        i.icon = (ImageIcon)Resource.getIconByString(dvo.name_string);
        i.text = df.format((double)dvo.amount/(double)dvo.maxAmount*100.0);
        i.color = Color.ORANGE;

        this.spots.add(i);
    }

    private Integer[] getPosition(GridPosition pos) {
        if (this.stepX == null) {
            double p1_cX = 9.;   double p1_cY = 114.;     //Koordinaten des unteren linken Steinbruches
            double p1_pX = 275.; double p1_pY = 1143.;    //Koordinaten auf der Karte

            double p2_cX = 56.;  double p2_cY = 8.;       //Koordinaten der oberen rechten Goldmine
            double p2_pX = 1718.; double p2_pY = 138.;    //Koordinaten auf der Karte

            
            this.stepX = (p1_pX - p2_pX) / (p1_cX - p2_cX);
            this.stepY = (p1_pY - p2_pY) / (p1_cY - p2_cY);

            this.offsetX = (int)(p1_pX - p1_cX * this.stepX);
            this.offsetY = (int)(p2_pY - p2_cY * this.stepY);
        }

        Integer[] ret = new Integer[]{0,0};

        
        ret[0]=(int)(this.stepX * pos.x + this.offsetX);
        ret[1]=(int)(this.stepY * pos.y + this.offsetY);
        return ret;
    }

    public void stopUpdating() {
        this.pauseUpdate = true;
    }

    public void continueUpdating() {
        this.pauseUpdate = false;
        this.repaintMap();
    }
}
