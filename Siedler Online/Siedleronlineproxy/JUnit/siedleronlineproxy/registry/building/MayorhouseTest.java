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
import static org.junit.Assert.*;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class MayorhouseTest {
    
    private GenericBuilding _object;
    
    public MayorhouseTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new Mayorhouse();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertTrue(GenericDoNothingBuilding.class.isInstance(this._object));
        
        assertEquals("Rathaus", this._object.getName());
        assertEquals(Building.BuildingTypes.MAYORHOUSE, this._object.getType());
        assertEquals(Building.BuildingCategory.STORAGE, this._object.category);
        assertSame(0, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertTrue(this._object.getNeeds().isEmpty());
    }
    
    @Test
    public void testProducts() {
        assertEquals(1.0, this._object.getProducesPerDayByLevel(1).size(),0);
        assertTrue(this._object.getProducesPerDayByLevel(1).containsKey(Products.POPULATION));
        assertEquals(50.0, this._object.getProducesPerDayByLevel(1).get(Products.POPULATION),0);
        assertEquals(this._object.getProducesPerDayByLevel(1).get(Products.POPULATION),
                    this._object.getProducesPerDayByLevel(10).get(Products.POPULATION));
    }
}
