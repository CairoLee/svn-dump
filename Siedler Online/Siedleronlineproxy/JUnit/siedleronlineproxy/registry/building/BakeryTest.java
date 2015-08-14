/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Resource.Products;
import static org.junit.Assert.*;

/**
 *
 * @author nspecht
 */
public class BakeryTest {
    
    private GenericBuilding _object;
    
    public BakeryTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new Bakery();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertEquals("Bäckerei", this._object.getName());
        assertEquals(Building.BuildingTypes.BAKERY, this._object.getType());
        assertEquals(Building.BuildingCategory.FOOD, this._object.category);
        assertEquals(3 * 60, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertSame(2, this._object.getNeeds().size());
        assertTrue(this._object.getNeeds().containsKey(Products.FLOUR));
        assertTrue(this._object.getNeeds().containsKey(Products.WATER));
        assertSame(1 , this._object.getNeeds().get(Products.FLOUR));
        assertSame(2 , this._object.getNeeds().get(Products.WATER));
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.BREAD));
        assertSame(1 , this._object.getProducts().get(Products.BREAD));
    }
}
