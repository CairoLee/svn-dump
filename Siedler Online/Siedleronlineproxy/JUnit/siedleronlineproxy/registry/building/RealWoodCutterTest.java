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
public class RealWoodCutterTest {
    
    private GenericBuilding _object;
    
    public RealWoodCutterTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new RealWoodCutter();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertEquals("Laubholzfällerhütte", this._object.getName());
        assertEquals(Building.BuildingTypes.REALWOODCUTTER, this._object.getType());
        assertEquals(Building.BuildingCategory.REALWOOD, this._object.category);
        assertEquals(4 * 60 + 30, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertSame(1, this._object.getNeeds().size());
        assertTrue(this._object.getNeeds().containsKey(Products.REALTREE));
        assertSame(1 , this._object.getNeeds().get(Products.REALTREE));
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.REALWOOD));
        assertSame(1 , this._object.getProducts().get(Products.REALWOOD));
    }
}
