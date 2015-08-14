package GUI.Components
{
    import GUI.Components.ToolTips.*;
    import mx.controls.*;
    import mx.events.*;
    import mx.styles.*;

    public class StandardCheckBox extends CheckBox
    {
        private var _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_mouseover_png_2011562618:Class;
        private var _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_mouseover_png_908720868:Class;
        private var _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_png_1110731462:Class;
        private var _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_png_130726088:Class;

        public function StandardCheckBox()
        {
            this._embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_mouseover_png_2011562618 = StandardCheckBox__embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_mouseover_png_2011562618;
            this._embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_png_1110731462 = StandardCheckBox__embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_png_1110731462;
            this._embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_mouseover_png_908720868 = StandardCheckBox__embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_mouseover_png_908720868;
            this._embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_png_130726088 = StandardCheckBox__embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_png_130726088;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.color = 16777215;
                this.textRollOverColor = 16777215;
                this.textSelectedColor = 16777215;
                this.upIcon = _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_png_130726088;
                this.overIcon = _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_mouseover_png_908720868;
                this.downIcon = _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_mouseover_png_2011562618;
                this.selectedUpIcon = _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_png_1110731462;
                this.selectedOverIcon = _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_active_mouseover_png_2011562618;
                this.selectedDownIcon = _embed_mxml_____data_src_gfx_embedded_checkbox_checkbox01_inactive_mouseover_png_908720868;
                return;
            }// end function
            ;
            this.addEventListener("toolTipCreate", this.___StandardCheckBox_CheckBox1_toolTipCreate);
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        public function ___StandardCheckBox_CheckBox1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

    }
}
