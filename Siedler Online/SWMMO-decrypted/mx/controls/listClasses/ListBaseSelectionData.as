package mx.controls.listClasses
{

    public class ListBaseSelectionData extends Object
    {
        public var data:Object;
        var prevSelectionData:ListBaseSelectionData;
        var nextSelectionData:ListBaseSelectionData;
        public var approximate:Boolean;
        public var index:int;
        static const VERSION:String = "3.5.0.12683";

        public function ListBaseSelectionData(param1:Object, param2:int, param3:Boolean)
        {
            this.data = param1;
            this.index = param2;
            this.approximate = param3;
            return;
        }// end function

    }
}
