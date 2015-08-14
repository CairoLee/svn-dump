﻿package Enums
{

    public class DIRTY_INDICATOR extends Object
    {
        public static const DATA_DELETED_BIT:int = 1 << 3;
        public static const CLEAN:int = 0;
        public static const DATA_MODIFIED_BIT:int = 1 << 4;
        public static const WEAK_MODIFICATION_BIT:int = 1 << 5;
        public static const CREATED_BIT:int = 1 << 0;
        public static const MODIFIED_BIT:int = 1 << 1;
        public static const DATA_ADDED_BIT:int = 1 << 2;

        public function DIRTY_INDICATOR()
        {
            return;
        }// end function

    }
}
