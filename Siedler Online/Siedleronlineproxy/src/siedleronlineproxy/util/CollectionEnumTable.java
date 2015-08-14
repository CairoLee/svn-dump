/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.util;

import java.util.EnumMap;

/**
 *
 * @author nspecht
 */
public class CollectionEnumTable<K extends Enum<K>,V> extends EnumMap<K, V> {
    public CollectionEnumTable(Class enumClass) {
        super(enumClass);
    }
}
