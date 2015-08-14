/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.constants.Building;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author nspecht
 */
public class Pumpkinfield02Test {
    
    private GenericBuilding _object;
    
    public Pumpkinfield02Test() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new Pumpkinfield02();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        
        assertEquals("Normaler Fiedhof der Kürbisse", this._object.getName());
        assertEquals(Building.BuildingTypes.PUMPKINFIELD_02, this._object.getType());
        assertEquals(Building.BuildingCategory.AKTION, this._object.category);
        assertEquals(4 * 60 * 60, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertTrue(this._object.getNeeds().isEmpty());
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.HALLOWEENRESOURCE));
        assertSame(1 , this._object.getProducts().get(Products.HALLOWEENRESOURCE));
    }
}
