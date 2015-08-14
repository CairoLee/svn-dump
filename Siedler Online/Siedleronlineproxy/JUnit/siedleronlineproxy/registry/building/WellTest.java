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
public class WellTest {
    
    private GenericBuilding _object;
    
    public WellTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new Well();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertEquals("Brunnen", this._object.getName());
        assertEquals(Building.BuildingTypes.WELL, this._object.getType());
        assertEquals(Building.BuildingCategory.WATER, this._object.category);
        assertEquals(3 * 60 + 8, this._object.getCycleTime());
    }
    
    @Test 
    public void testGetResourceTime() {
        assertEquals(4, this._object.getResourceTime());
    }
    
    @Test
    public void testNeeds() {
        assertSame(1, this._object.getNeeds().size());
        assertTrue(this._object.getNeeds().containsKey(Products.WATERDEPOSIT));
        assertSame(1 , this._object.getNeeds().get(Products.WATERDEPOSIT));
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.WATER));
        assertSame(1 , this._object.getProducts().get(Products.WATER));
    }
}
