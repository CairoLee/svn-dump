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
public class WatermillTest {
    
    private GenericBuilding _object;
    
    public WatermillTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new Watermill();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertEquals("Wassermühle", this._object.getName());
        assertEquals(Building.BuildingTypes.WATERMILL, this._object.getType());
        assertEquals(Building.BuildingCategory.WATER, this._object.category);
        assertEquals(3 * 60, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertTrue(this._object.getNeeds().isEmpty());
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.WATER));
        assertSame(1 , this._object.getProducts().get(Products.WATER));
    }
}
