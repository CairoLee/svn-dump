using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#if (!XBOX && !XBOX_FAKE)
using System.Media;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
#endif

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	/// <summary>
	/// Defines the base class for all controls.
	/// </summary>    
	public class Control : Component {

		public static readonly Color UndefinedColor = new Color(255, 255, 255, 0);

		internal static ControlsList Stack = new ControlsList();

#if (!XBOX && !XBOX_FAKE)
		private Cursor cursor = null;
#endif

		private Color color = UndefinedColor;
		private Color textColor = UndefinedColor;
		private Color backColor = Color.Transparent;
		private byte alpha = 255;
		private EAnchors anchor = EAnchors.Left | EAnchors.Top;
		private EAnchors resizeEdge = EAnchors.All;
		private string text = "Control";
		private bool visible = true;
		private bool enabled = true;
		private SkinControl skin = null;
		private Control parent = null;
		private Control root = null;
		private int left = 0;
		private int top = 0;
		private int width = 64;
		private int height = 64;
		private bool suspended = false;
		private ContextMenu contextMenu = null;
		private long tooltipTimer = 0;
		private long doubleClickTimer = 0;
		private EMouseButton doubleClickButton = EMouseButton.None;
		private Type toolTipType = typeof(ToolTip);
		private ToolTip toolTip = null;
		private bool doubleClicks = true;
		private bool outlineResizing = false;
		private bool outlineMoving = false;
		private string name = "Control";
		private object tag = null;
		private EGamePadActions gamePadActions = new EGamePadActions();
		private bool designMode = false;
		private bool partialOutline = true;
		private Rectangle drawingRect = Rectangle.Empty;

		private ControlsList controls = new ControlsList();
		private Rectangle movableArea = Rectangle.Empty;
		private bool passive = false;
		private bool detached = false;
		private bool movable = false;
		private bool resizable = false;
		private bool invalidated = true;
		private bool canFocus = true;
		private int resizerSize = 4;
		private int minimumWidth = 0;
		private int maximumWidth = 4096;
		private int minimumHeight = 0;
		private int maximumHeight = 4096;
		private int topModifier = 0;
		private int leftModifier = 0;
		private int virtualHeight = 64;
		private int virtualWidth = 64;
		private bool stayOnBack = false;
		private bool stayOnTop = false;

		private RenderTarget2D target;
		private Point pressSpot = Point.Zero;
		private int[] pressDiff = new int[4];
		private EAlignment resizeArea = EAlignment.None;
		private bool hovered = false;
		private bool inside = false;
		private bool[] pressed = new bool[32];
		private bool isMoving = false;
		private bool isResizing = false;
		private Margins margins = new Margins(4, 4, 4, 4);
		private Margins anchorMargins = new Margins();
		private Margins clientMargins = new Margins();
		private Rectangle outlineRect = Rectangle.Empty;

#if (!XBOX && !XBOX_FAKE)
		/// <summary>
		/// Gets or sets the cursor displaying over the control.
		/// </summary>
		public Cursor Cursor {
			get { return cursor; }
			set { cursor = value; }
		}
#endif

		/// <summary>
		/// Gets a list of all child controls.
		/// </summary>
		public virtual IEnumerable<Control> Controls {
			get { return controls; }
		}

		/// <summary>
		/// Gets or sets a rectangular area that reacts on moving the control with the mouse.
		/// </summary>
		public virtual Rectangle MovableArea {
			get { return movableArea; }
			set { movableArea = value; }
		}

		/// <summary>
		/// Gets a value indicating whether this control is a child control.
		/// </summary>
		public virtual bool IsChild {
			get { return (parent != null); }
		}

		/// <summary>
		/// Gets a value indicating whether this control is a parent control.
		/// </summary>
		public virtual bool IsParent {
			get { return (controls != null && controls.Count > 0); }
		}

		/// <summary>
		/// Gets a value indicating whether this control is a root control.
		/// </summary>
		public virtual bool IsRoot {
			get { return (root == this); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control can receive focus. 
		/// </summary>
		public virtual bool CanFocus {
			get { return canFocus; }
			set { canFocus = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control is rendered off the parents texture.
		/// </summary>
		public virtual bool Detached {
			get { return detached; }
			set { detached = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this controls can receive user input events.
		/// </summary>
		public virtual bool Passive {
			get { return passive; }
			set { passive = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control can be moved by the mouse.
		/// </summary>
		public virtual bool Movable {
			get { return movable; }
			set { movable = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control can be resized by the mouse.
		/// </summary>
		public virtual bool Resizable {
			get { return resizable; }
			set { resizable = value; }
		}

		/// <summary>
		/// Gets or sets the size of the rectangular borders around the control used for resizing by the mouse.
		/// </summary>
		public virtual int ResizerSize {
			get { return resizerSize; }
			set { resizerSize = value; }
		}

		/// <summary>
		/// Gets or sets the ContextMenu associated with this control.
		/// </summary>
		public virtual ContextMenu ContextMenu {
			get { return contextMenu; }
			set { contextMenu = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control should process mouse double-clicks.
		/// </summary>
		public virtual bool DoubleClicks {
			get { return doubleClicks; }
			set { doubleClicks = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control should use ouline resizing.
		/// </summary>
		public virtual bool OutlineResizing {
			get { return outlineResizing; }
			set { outlineResizing = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control should use outline moving.
		/// </summary>
		public virtual bool OutlineMoving {
			get { return outlineMoving; }
			set { outlineMoving = value; }
		}

		/// <summary>
		/// Gets or sets the object that contains data about the control.
		/// </summary>
		public virtual object Tag {
			get { return tag; }
			set { tag = value; }
		}

		/// <summary>
		/// Gets or sets the value indicating the distance from another control. Usable with StackPanel control.
		/// </summary>
		public virtual Margins Margins {
			get { return margins; }
			set { margins = value; }
		}

		/// <summary>
		/// Gets or sets the value indicating wheter control is in design mode.
		/// </summary>
		public virtual bool DesignMode {
			get { return designMode; }
			set { designMode = value; }
		}

		/// <summary>
		/// Gets or sets gamepad actions for the control.
		/// </summary>
		public virtual EGamePadActions GamePadActions {
			get { return gamePadActions; }
			set { gamePadActions = value; }
		}

		/// <summary>
		/// Gets or sets the value indicating whether the control outline is displayed only for certain edges. 
		/// </summary>   
		public virtual bool PartialOutline {
			get { return partialOutline; }
			set { partialOutline = value; }
		}

		/// <summary>
		/// Gets or sets the value indicating whether the control is allowed to be brought in the front.
		/// </summary>
		public virtual bool StayOnBack {
			get { return stayOnBack; }
			set {
				if (value && stayOnTop)
					stayOnTop = false;
				stayOnBack = value;
			}
		}

		/// <summary>
		/// Gets or sets the value indicating that the control should stay on top of other controls.
		/// </summary>
		public virtual bool StayOnTop {
			get { return stayOnTop; }
			set {
				if (value && stayOnBack)
					stayOnBack = false;
				stayOnTop = value;
			}
		}

		/// <summary>
		/// Gets or sets a name of the control.
		/// </summary>
		public virtual string Name {
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control has input focus.
		/// </summary>
		public virtual bool Focused {
			get { return (Manager.FocusedControl == this); }
			set {
				this.Invalidate();
				if (value) {
					bool f = Focused;
					Manager.FocusedControl = this;
					if (!Suspended && value && !f)
						OnFocusGained(new EventArgs());
					if (Focused && Root != null && Root is Container) {
						(Root as Container).ScrollTo(this);
					}
				} else {
					bool f = Focused;
					if (Manager.FocusedControl == this)
						Manager.FocusedControl = null;
					if (!Suspended && !value && f)
						OnFocusLost(new EventArgs());
				}
			}
		}

		/// <summary>
		/// Gets a value indicating current state of the control.
		/// </summary>
		public virtual EControlState ControlState {
			get {
				if (DesignMode)
					return EControlState.Enabled;
				else if (Suspended)
					return EControlState.Disabled;
				else {
					if (!enabled)
						return EControlState.Disabled;

					if ((IsPressed && inside) || (Focused && IsPressed))
						return EControlState.Pressed;
					else if (hovered && !IsPressed)
						return EControlState.Hovered;
					else if ((Focused && !inside) || (hovered && IsPressed && !inside) || (Focused && !hovered && inside))
						return EControlState.Focused;
					else
						return EControlState.Enabled;
				}
			}
		}

		public virtual Type ToolTipType {
			get { return toolTipType; }
			set {
				toolTipType = value;
				if (toolTip != null) {
					toolTip.Dispose();
					toolTip = null;
				}
			}
		}

		public virtual ToolTip ToolTip {
			get {
				if (toolTip == null) {
					Type[] t = new Type[1] { typeof(Manager) };
					object[] p = new object[1] { Manager };

					toolTip = (ToolTip)toolTipType.GetConstructor(t).Invoke(p);
					toolTip.Init();
					toolTip.Visible = false;
				}
				return toolTip;
			}
			set { toolTip = value; }
		}

		internal protected virtual bool IsPressed {
			get {
				for (int i = 0; i < pressed.Length - 1; i++) {
					if (pressed[i])
						return true;
				}
				return false;
			}
		}

		internal virtual int TopModifier {
			get { return topModifier; }
			set { topModifier = value; }
		}

		internal virtual int LeftModifier {
			get { return leftModifier; }
			set { leftModifier = value; }
		}
		internal virtual int VirtualHeight {
			get { return GetVirtualHeight(); }
			//set { virtualHeight = value; }
		}
		internal virtual int VirtualWidth {
			get { return GetVirtualWidth(); }
			//set { virtualWidth = value; }
		}

		/// <summary>
		/// Gets an area where is the control supposed to be drawn.
		/// </summary>
		public Rectangle DrawingRect {
			get { return drawingRect; }
			private set { drawingRect = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control should receive any events.
		/// </summary>
		public virtual bool Suspended {
			get { return suspended; }
			set { suspended = value; }
		}

		internal protected virtual bool Hovered {
			get { return hovered; }
		}

		internal protected virtual bool Inside {
			get { return inside; }
		}

		internal protected virtual bool[] Pressed {
			get { return pressed; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this controls is currently being moved.
		/// </summary>
		protected virtual bool IsMoving {
			get { return isMoving; }
			set { isMoving = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this controls is currently being resized.
		/// </summary>
		protected virtual bool IsResizing {
			get { return isResizing; }
			set { isResizing = value; }
		}

		/// <summary>
		/// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
		/// </summary>
		public virtual EAnchors Anchor {
			get { return anchor; }
			set {
				anchor = value;
				SetAnchorMargins();
				if (!Suspended)
					OnAnchorChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Gets or sets the edges of the contol which are allowed for resizing.
		/// </summary>
		public virtual EAnchors ResizeEdge {
			get { return resizeEdge; }
			set { resizeEdge = value; }
		}

		/// <summary>
		/// Gets or sets the skin used for rendering the control.
		/// </summary>
		public virtual SkinControl Skin {
			get { return skin; }
			set {
				skin = value;
				ClientMargins = skin.ClientMargins;
			}
		}

		/// <summary>
		/// Gets or sets the text associated with this control.
		/// </summary>
		public virtual string Text {
			get { return text; }
			set {
				text = value;
				Invalidate();
				if (!Suspended)
					OnTextChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Gets or sets the alpha value for this control.
		/// </summary>
		public virtual byte Alpha {
			get { return alpha; }
			set {
				alpha = value;
				if (!Suspended)
					OnAlphaChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Gets or sets the background color for the control.
		/// </summary>
		public virtual Color BackColor {
			get { return backColor; }
			set {
				backColor = value;
				Invalidate();
				if (!Suspended)
					OnBackColorChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Gets or sets the color for the control.
		/// </summary>
		public virtual Color Color {
			get { return color; }
			set {
				if (value != color) {
					color = value;
					Invalidate();
					if (!Suspended)
						OnColorChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		/// Gets or sets the text color for the control.
		/// </summary>
		public virtual Color TextColor {
			get { return textColor; }
			set {
				if (value != textColor) {
					textColor = value;
					Invalidate();
					if (!Suspended)
						OnTextColorChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the control can respond to user interaction.
		/// </summary>
		public virtual bool Enabled {
			get { return enabled; }
			set {
				if (Root != null && Root != this && !Root.Enabled && value) {
					return;
				}

				enabled = value;
				Invalidate();

				foreach (Control c in controls) {
					c.Enabled = value;
				}

				if (!Suspended) {
					OnEnabledChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		/// Gets or sets a value that indicates whether the control is rendered.
		/// </summary>
		public virtual bool Visible {
			get { return (visible && (parent == null || parent.Visible)); }
			set {
				visible = value;
				Invalidate();

				if (!Suspended)
					OnVisibleChanged(new EventArgs());
			}
		}

		/// <summary>
		/// Gets or sets the parent for the control.
		/// </summary>
		public virtual Control Parent {
			get { return parent; }
			set {
				if (parent != value) {
					if (value != null)
						value.Add(this);
					else
						Manager.Add(this);
				}
			}
		}

		/// <summary>
		/// Gets or sets the root for the control.
		/// </summary>
		public virtual Control Root {
			get { return root; }
			private set {
				if (root != value) {
					root = value;

					foreach (Control c in controls) {
						c.Root = root;
					}

					if (!Suspended)
						OnRootChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		/// Gets or sets the distance, in pixels, between the left edge of the control and the left edge of its parent.
		/// </summary>
		public virtual int Left {
			get { return left; }
			set {
				if (left != value) {
					int old = left;
					left = value;

					SetAnchorMargins();

					if (!Suspended)
						OnMove(new MoveEventArgs(left, top, old, top));
				}
			}
		}

		/// <summary>
		/// Gets or sets the distance, in pixels, between the top edge of the control and the top edge of its parent.
		/// </summary>
		public virtual int Top {
			get { return top; }
			set {
				if (top != value) {
					int old = top;
					top = value;

					SetAnchorMargins();

					if (!Suspended)
						OnMove(new MoveEventArgs(left, top, left, old));
				}
			}
		}

		/// <summary>
		/// Gets or sets the width of the control.
		/// </summary>
		public virtual int Width {
			get { return width; }
			set {
				if (width != value) {
					int old = width;
					width = value;

					if (skin != null) {
						if (width + skin.OriginMargins.Horizontal > MaximumWidth)
							width = MaximumWidth - skin.OriginMargins.Horizontal;
					} else {
						if (width > MaximumWidth)
							width = MaximumWidth;
					}
					if (width < MinimumWidth)
						width = MinimumWidth;

					if (width > 0)
						SetAnchorMargins();

					if (!Suspended)
						OnResize(new ResizeEventArgs(width, height, old, height));
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// </summary>
		public virtual int Height {
			get { return height; }
			set {
				if (height != value) {
					int old = height;

					height = value;

					if (skin != null) {
						if (height + skin.OriginMargins.Vertical > MaximumHeight)
							height = MaximumHeight - skin.OriginMargins.Vertical;
					} else {
						if (height > MaximumHeight)
							height = MaximumHeight;
					}
					if (height < MinimumHeight)
						height = MinimumHeight;

					if (height > 0)
						SetAnchorMargins();

					if (!Suspended)
						OnResize(new ResizeEventArgs(width, height, width, old));
				}

			}

		}

		/// <summary>
		/// Gets or sets the minimum width in pixels the control can be sized to.
		/// </summary>
		public virtual int MinimumWidth {
			get { return minimumWidth; }
			set {
				minimumWidth = value;
				if (minimumWidth < 0)
					minimumWidth = 0;
				if (minimumWidth > maximumWidth)
					minimumWidth = maximumWidth;
				if (width < MinimumWidth)
					Width = MinimumWidth;
			}
		}

		/// <summary>
		/// /// Gets or sets the minimum height in pixels the control can be sized to.
		/// </summary>
		public virtual int MinimumHeight {
			get { return minimumHeight; }
			set {
				minimumHeight = value;
				if (minimumHeight < 0)
					minimumHeight = 0;
				if (minimumHeight > maximumHeight)
					minimumHeight = maximumHeight;
				if (height < MinimumHeight)
					Height = MinimumHeight;
			}
		}

		/// <summary>
		/// /// Gets or sets the maximum width in pixels the control can be sized to.
		/// </summary>
		public virtual int MaximumWidth {
			get {
				int max = maximumWidth;
				if (max > Manager.TargetWidth)
					max = Manager.TargetWidth;
				return max;
			}
			set {
				maximumWidth = value;
				if (maximumWidth < minimumWidth)
					maximumWidth = minimumWidth;
				if (width > MaximumWidth)
					Width = MaximumWidth;
			}
		}

		/// <summary>
		/// Gets or sets the maximum height in pixels the control can be sized to.
		/// </summary>
		public virtual int MaximumHeight {
			get {
				int max = maximumHeight;
				if (max > Manager.TargetHeight)
					max = Manager.TargetHeight;
				return max;
			}
			set {
				maximumHeight = value;
				if (maximumHeight < minimumHeight)
					maximumHeight = minimumHeight;
				if (height > MaximumHeight)
					Height = MaximumHeight;
			}
		}

		public virtual int AbsoluteLeft {
			get {
				if (parent == null)
					return left + LeftModifier;
				else if (parent.Skin == null)
					return parent.AbsoluteLeft + left + LeftModifier;
				else
					return parent.AbsoluteLeft + left - parent.Skin.OriginMargins.Left + LeftModifier;
			}
		}
		public virtual int AbsoluteTop {
			get {
				if (parent == null)
					return top + TopModifier;
				else if (parent.Skin == null)
					return parent.AbsoluteTop + top + TopModifier;
				else
					return parent.AbsoluteTop + top - parent.Skin.OriginMargins.Top + TopModifier;
			}
		}

		public virtual int OriginLeft {
			get {
				if (skin == null)
					return AbsoluteLeft;
				return AbsoluteLeft - skin.OriginMargins.Left;
			}
		}

		public virtual int OriginTop {
			get {
				if (skin == null)
					return AbsoluteTop;
				return AbsoluteTop - skin.OriginMargins.Top;
			}
		}

		public virtual int OriginWidth {
			get {
				if (skin == null)
					return width;
				return width + skin.OriginMargins.Left + skin.OriginMargins.Right;
			}
		}

		public virtual int OriginHeight {
			get {
				if (skin == null)
					return height;
				return height + skin.OriginMargins.Top + skin.OriginMargins.Bottom;
			}
		}

		public virtual Margins ClientMargins {
			get { return clientMargins; }
			set {
				clientMargins = value;
			}
		}

		public virtual int ClientLeft {
			get { return ClientMargins.Left; }
		}

		public virtual int ClientTop {
			get { return ClientMargins.Top; }
		}

		public virtual int ClientWidth {
			get { return OriginWidth - ClientMargins.Left - ClientMargins.Right; }
			set { Width = value + ClientMargins.Horizontal - skin.OriginMargins.Horizontal; }
		}

		public virtual int ClientHeight {
			get { return OriginHeight - ClientMargins.Top - ClientMargins.Bottom; }
			set { Height = value + ClientMargins.Vertical - skin.OriginMargins.Vertical; }
		}

		public virtual Rectangle AbsoluteRect {
			get { return new Rectangle(AbsoluteLeft, AbsoluteTop, OriginWidth, OriginHeight); }
		}

		public virtual Rectangle OriginRect {
			get { return new Rectangle(OriginLeft, OriginTop, OriginWidth, OriginHeight); }
		}

		public virtual Rectangle ClientRect {
			get { return new Rectangle(ClientLeft, ClientTop, ClientWidth, ClientHeight); }
		}

		public virtual Rectangle ControlRect {
			get { return new Rectangle(Left, Top, Width, Height); }
			set {
				Left = value.Left;
				Top = value.Top;
				Width = value.Width;
				Height = value.Height;
			}
		}

		private Rectangle OutlineRect {
			get { return outlineRect; }
			set {
				outlineRect = value;
				if (value != Rectangle.Empty) {
					if (outlineRect.Width > MaximumWidth)
						outlineRect.Width = MaximumWidth;
					if (outlineRect.Height > MaximumHeight)
						outlineRect.Height = MaximumHeight;
					if (outlineRect.Width < MinimumWidth)
						outlineRect.Width = MinimumWidth;
					if (outlineRect.Height < MinimumHeight)
						outlineRect.Height = MinimumHeight;
				}
			}
		}

		public event EventHandler Click;
		public event EventHandler DoubleClick;
		public event MouseEventHandler MouseDown;
		public event MouseEventHandler MousePress;
		public event MouseEventHandler MouseUp;
		public event MouseEventHandler MouseMove;
		public event MouseEventHandler MouseOver;
		public event MouseEventHandler MouseOut;
		public event KeyEventHandler KeyDown;
		public event KeyEventHandler KeyPress;
		public event KeyEventHandler KeyUp;
		public event GamePadEventHandler GamePadDown;
		public event GamePadEventHandler GamePadUp;
		public event GamePadEventHandler GamePadPress;
		public event MoveEventHandler Move;
		public event MoveEventHandler ValidateMove;
		public event ResizeEventHandler Resize;
		public event ResizeEventHandler ValidateResize;
		public event DrawEventHandler Draw;
		public event EventHandler MoveBegin;
		public event EventHandler MoveEnd;
		public event EventHandler ResizeBegin;
		public event EventHandler ResizeEnd;
		public event EventHandler ColorChanged;
		public event EventHandler TextColorChanged;
		public event EventHandler BackColorChanged;
		public event EventHandler TextChanged;
		public event EventHandler AnchorChanged;
		public event EventHandler SkinChanging;
		public event EventHandler SkinChanged;
		public event EventHandler ParentChanged;
		public event EventHandler RootChanged;
		public event EventHandler VisibleChanged;
		public event EventHandler EnabledChanged;
		public event EventHandler AlphaChanged;
		public event EventHandler FocusLost;
		public event EventHandler FocusGained;
		public event DrawEventHandler DrawTexture;


		public Control(Manager manager)
			: this(manager, false) {
		}

		public Control(Manager manager, bool autoInit)
			: base(manager) {
			if (Manager == null) {
				throw new Exception("Control cannot be created. Manager instance is needed.");
			} else if (Manager.Skin == null) {
				throw new Exception("Control cannot be created. No skin loaded.");
			}

			text = Utilities.DeriveControlName(this);
			root = this;

			InitSkin();

			CheckLayer(skin, "Control");

			if (Skin != null) {
				SetDefaultSize(width, height);
				SetMinimumSize(MinimumWidth, MinimumHeight);
				ResizerSize = skin.ResizerSize;
			}

			Stack.Add(this);


			mAutoInit = autoInit;
			if (AutoInit) {
				Init();
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (parent != null)
					parent.Remove(this);
				else if (Manager != null)
					Manager.Remove(this);
				if (Manager.OrderList != null)
					Manager.OrderList.Remove(this);

				// Possibly we added the menu to another parent than this control, 
				// so we dispose it manually, beacause in logic it belongs to this control.        
				if (contextMenu != null) {
					contextMenu.Dispose();
					contextMenu = null;
				}

				// Recursively disposing all controls. The collection might change from its children, 
				// so we check it on count greater than zero.
				if (controls != null) {
					int c = controls.Count;
					for (int i = 0; i < c; i++) {
						if (controls.Count > 0) {
							controls[0].Dispose();
						}
					}
				}

				// Disposes tooltip owned by Manager        
				if (toolTip != null && !Manager.Disposing) {
					toolTip.Dispose();
					toolTip = null;
				}

				// Removing this control from the global stack.
				Stack.Remove(this);

				if (target != null) {
					target.Dispose();
					target = null;
				}
			}
			base.Dispose(disposing);
		}

		private int GetVirtualHeight() {
			if (this.Parent is Container && (this.Parent as Container).AutoScroll) {
				int maxy = 0;

				foreach (Control c in Controls) {
					if ((c.Anchor & EAnchors.Bottom) != EAnchors.Bottom && c.Visible) {
						if (c.Top + c.Height > maxy)
							maxy = c.Top + c.Height;
					}
				}
				if (maxy < Height)
					maxy = Height;

				return maxy;
			} else {
				return Height;
			}
		}

		private int GetVirtualWidth() {
			if (this.Parent is Container && (this.Parent as Container).AutoScroll) {
				int maxx = 0;

				foreach (Control c in Controls) {
					if ((c.Anchor & EAnchors.Right) != EAnchors.Right && c.Visible) {
						if (c.Left + c.Width > maxx)
							maxx = c.Left + c.Width;
					}
				}
				if (maxx < Width)
					maxx = Width;

				return maxx;
			} else {
				return Width;
			}
		}

		private Rectangle GetClippingRect(Control c) {
			Rectangle r = Rectangle.Empty;

			r = new Rectangle(c.OriginLeft - root.AbsoluteLeft,
							  c.OriginTop - root.AbsoluteTop,
							  c.OriginWidth,
							  c.OriginHeight);

			int x1 = r.Left;
			int x2 = r.Right;
			int y1 = r.Top;
			int y2 = r.Bottom;

			Control ctrl = c.Parent;
			while (ctrl != null) {
				int cx1 = ctrl.OriginLeft - root.AbsoluteLeft;
				int cy1 = ctrl.OriginTop - root.AbsoluteTop;
				int cx2 = cx1 + ctrl.OriginWidth;
				int cy2 = cy1 + ctrl.OriginHeight;

				if (x1 < cx1)
					x1 = cx1;
				if (y1 < cy1)
					y1 = cy1;
				if (x2 > cx2)
					x2 = cx2;
				if (y2 > cy2)
					y2 = cy2;

				ctrl = ctrl.Parent;
			}

			int fx2 = x2 - x1;
			int fy2 = y2 - y1;

			if (x1 < 0)
				x1 = 0;
			if (y1 < 0)
				y1 = 0;
			if (fx2 < 0)
				fx2 = 0;
			if (fy2 < 0)
				fy2 = 0;
			if (x1 > root.Width) { x1 = root.Width; }
			if (y1 > root.Height) { y1 = root.Height; }
			if (fx2 > root.Width)
				fx2 = root.Width;
			if (fy2 > root.Height)
				fy2 = root.Height;

			Rectangle ret = new Rectangle(x1, y1, fx2, fy2);

			return ret;
		}

		private RenderTarget2D CreateRenderTarget(int width, int height) {
			if (width > 0 && height > 0) {
				return new RenderTarget2D(Manager.GraphicsDevice,
										  width,
										  height,
										  false,
										  SurfaceFormat.Color,
										  DepthFormat.None,
										  Manager.GraphicsDevice.PresentationParameters.MultiSampleCount,
										  Manager._RenderTargetUsage);

			}

			return null;
		}

		internal virtual void PrepareTexture(Renderer renderer, GameTime gameTime) {
			if (visible) {
				if (invalidated) {
					OnDrawTexture(new DrawEventArgs(renderer, new Rectangle(0, 0, OriginWidth, OriginHeight), gameTime));

					if (target == null || target.Width < OriginWidth || target.Height < OriginHeight) {
						if (target != null) {
							target.Dispose();
							target = null;
						}

						int w = OriginWidth + (Manager.TextureResizeIncrement - (OriginWidth % Manager.TextureResizeIncrement));
						int h = OriginHeight + (Manager.TextureResizeIncrement - (OriginHeight % Manager.TextureResizeIncrement));

						if (h > Manager.TargetHeight)
							h = Manager.TargetHeight;
						if (w > Manager.TargetWidth)
							w = Manager.TargetWidth;

						target = CreateRenderTarget(w, h);
					}

					if (target != null) {
						Manager.GraphicsDevice.SetRenderTarget(target);
						target.GraphicsDevice.Clear(backColor);

						Rectangle rect = new Rectangle(0, 0, OriginWidth, OriginHeight);
						DrawControls(renderer, rect, gameTime, false);

						Manager.GraphicsDevice.SetRenderTarget(null);
					}
					invalidated = false;
				}
			}
		}

		private bool CheckDetached(Control c) {
			Control parent = c.Parent;
			while (parent != null) {
				if (parent.Detached) {
					return true;
				}
				parent = parent.Parent;
			}

			return c.Detached;
		}

		private void DrawChildControls(Renderer renderer, GameTime gameTime, bool firstDetachedLevel) {
			if (controls != null) {
				foreach (Control c in controls) {
					// We skip detached controls for first level after root (they are rendered separately in Draw() method)
					if (((c.Root == c.Parent && !c.Detached) || c.Root != c.Parent) && AbsoluteRect.Intersects(c.AbsoluteRect) && c.visible) {
						Manager.GraphicsDevice.ScissorRectangle = GetClippingRect(c);

						Rectangle rect = new Rectangle(c.OriginLeft - root.AbsoluteLeft, c.OriginTop - root.AbsoluteTop, c.OriginWidth, c.OriginHeight);
						if (c.Root != c.Parent && ((!c.Detached && CheckDetached(c)) || firstDetachedLevel)) {
							rect = new Rectangle(c.OriginLeft, c.OriginTop, c.OriginWidth, c.OriginHeight);
							Manager.GraphicsDevice.ScissorRectangle = rect;
						}

						renderer.Begin(EBlendingMode.Default);
						c.DrawingRect = rect;
						c.DrawControl(renderer, rect, gameTime);

						DrawEventArgs args = new DrawEventArgs();
						args.Rectangle = rect;
						args.Renderer = renderer;
						args.GameTime = gameTime;
						c.OnDraw(args);
						renderer.End();

						c.DrawChildControls(renderer, gameTime, firstDetachedLevel);

						c.DrawOutline(renderer, true);
					}
				}
			}
		}

		private void DrawControls(Renderer renderer, Rectangle rect, GameTime gameTime, bool firstDetach) {
			renderer.Begin(EBlendingMode.Default);

			DrawingRect = rect;
			DrawControl(renderer, rect, gameTime);

			DrawEventArgs args = new DrawEventArgs();
			args.Rectangle = rect;
			args.Renderer = renderer;
			args.GameTime = gameTime;
			OnDraw(args);

			renderer.End();

			DrawChildControls(renderer, gameTime, firstDetach);
		}

		private void DrawDetached(Control control, Renderer renderer, GameTime gameTime) {
			if (control.Controls != null) {
				foreach (Control c in control.Controls) {
					if (c.Detached && c.Visible) {
						c.DrawControls(renderer, new Rectangle(c.OriginLeft, c.OriginTop, c.OriginWidth, c.OriginHeight), gameTime, true);
					}
				}
			}
		}

		internal virtual void Render(Renderer renderer, GameTime gameTime) {
			if (visible && target != null) {
				bool draw = true;

				if (draw) {
					renderer.Begin(EBlendingMode.Default);
					renderer.Draw(target, OriginLeft, OriginTop, new Rectangle(0, 0, OriginWidth, OriginHeight), Color.FromNonPremultiplied(255, 255, 255, Alpha));
					renderer.End();

					DrawDetached(this, renderer, gameTime);

					DrawOutline(renderer, false);
				}
			}
		}

		private void DrawOutline(Renderer renderer, bool child) {
			if (!OutlineRect.IsEmpty) {
				Rectangle r = OutlineRect;
				if (child) {
					r = new Rectangle(OutlineRect.Left + (parent.AbsoluteLeft - root.AbsoluteLeft), OutlineRect.Top + (parent.AbsoluteTop - root.AbsoluteTop), OutlineRect.Width, OutlineRect.Height);
				}

				Texture2D t = Manager.Skin.Controls["Control.Outline"].Layers[0].Image.Resource;

				int s = resizerSize;
				Rectangle r1 = new Rectangle(r.Left + leftModifier, r.Top + topModifier, r.Width, s);
				Rectangle r2 = new Rectangle(r.Left + leftModifier, r.Top + s + topModifier, resizerSize, r.Height - (2 * s));
				Rectangle r3 = new Rectangle(r.Right - s + leftModifier, r.Top + s + topModifier, s, r.Height - (2 * s));
				Rectangle r4 = new Rectangle(r.Left + leftModifier, r.Bottom - s + topModifier, r.Width, s);

				Color c = Manager.Skin.Controls["Control.Outline"].Layers[0].States.Enabled.Color;

				renderer.Begin(EBlendingMode.Default);
				if ((ResizeEdge & EAnchors.Top) == EAnchors.Top || !partialOutline)
					renderer.Draw(t, r1, c);
				if ((ResizeEdge & EAnchors.Left) == EAnchors.Left || !partialOutline)
					renderer.Draw(t, r2, c);
				if ((ResizeEdge & EAnchors.Right) == EAnchors.Right || !partialOutline)
					renderer.Draw(t, r3, c);
				if ((ResizeEdge & EAnchors.Bottom) == EAnchors.Bottom || !partialOutline)
					renderer.Draw(t, r4, c);
				renderer.End();
			} else if (DesignMode && Focused) {
				Rectangle r = ControlRect;
				if (child) {
					r = new Rectangle(r.Left + (parent.AbsoluteLeft - root.AbsoluteLeft), r.Top + (parent.AbsoluteTop - root.AbsoluteTop), r.Width, r.Height);
				}

				Texture2D t = Manager.Skin.Controls["Control.Outline"].Layers[0].Image.Resource;

				int s = resizerSize;
				Rectangle r1 = new Rectangle(r.Left + leftModifier, r.Top + topModifier, r.Width, s);
				Rectangle r2 = new Rectangle(r.Left + leftModifier, r.Top + s + topModifier, resizerSize, r.Height - (2 * s));
				Rectangle r3 = new Rectangle(r.Right - s + leftModifier, r.Top + s + topModifier, s, r.Height - (2 * s));
				Rectangle r4 = new Rectangle(r.Left + leftModifier, r.Bottom - s + topModifier, r.Width, s);

				Color c = Manager.Skin.Controls["Control.Outline"].Layers[0].States.Enabled.Color;

				renderer.Begin(EBlendingMode.Default);
				renderer.Draw(t, r1, c);
				renderer.Draw(t, r2, c);
				renderer.Draw(t, r3, c);
				renderer.Draw(t, r4, c);
				renderer.End();
			}
		}

		public virtual void SetPosition(int left, int top) {
			this.left = left;
			this.top = top;
		}

		public virtual void SetSize(int width, int height) {
			this.width = width;
			this.height = height;
		}

		internal void SetAnchorMargins() {
			if (Parent != null) {
				anchorMargins.Left = Left;
				anchorMargins.Top = Top;
				anchorMargins.Right = Parent.VirtualWidth - Width - Left;
				anchorMargins.Bottom = Parent.VirtualHeight - Height - Top;
			} else {
				anchorMargins = new Margins();
			}
		}

		private void ProcessAnchor(ResizeEventArgs e) {
			if (((Anchor & EAnchors.Right) == EAnchors.Right) && ((Anchor & EAnchors.Left) != EAnchors.Left)) {
				Left = Parent.VirtualWidth - Width - anchorMargins.Right;
			} else if (((Anchor & EAnchors.Right) == EAnchors.Right) && ((Anchor & EAnchors.Left) == EAnchors.Left)) {
				Width = Parent.VirtualWidth - Left - anchorMargins.Right;
			} else if (((Anchor & EAnchors.Right) != EAnchors.Right) && ((Anchor & EAnchors.Left) != EAnchors.Left)) {
				int diff = (e.Width - e.OldWidth);
				if (e.Width % 2 != 0 && diff != 0) {
					diff += (diff / Math.Abs(diff));
				}
				Left += (diff / 2);
			}
			if (((Anchor & EAnchors.Bottom) == EAnchors.Bottom) && ((Anchor & EAnchors.Top) != EAnchors.Top)) {
				Top = Parent.VirtualHeight - Height - anchorMargins.Bottom;
			} else if (((Anchor & EAnchors.Bottom) == EAnchors.Bottom) && ((Anchor & EAnchors.Top) == EAnchors.Top)) {
				Height = Parent.VirtualHeight - Top - anchorMargins.Bottom;
			} else if (((Anchor & EAnchors.Bottom) != EAnchors.Bottom) && ((Anchor & EAnchors.Top) != EAnchors.Top)) {
				int diff = (e.Height - e.OldHeight);
				if (e.Height % 2 != 0 && diff != 0) {
					diff += (diff / Math.Abs(diff));
				}
				Top += (diff / 2);
			}
		}

		public override void Init() {
			base.Init();

			OnMove(new MoveEventArgs());
			OnResize(new ResizeEventArgs());
		}

		protected internal virtual void InitSkin() {
			if (Manager != null && Manager.Skin != null && Manager.Skin.Controls != null) {
				SkinControl s = Manager.Skin.Controls[Utilities.DeriveControlName(this)];
				if (s != null)
					Skin = new SkinControl(s);
				else
					Skin = new SkinControl(Manager.Skin.Controls["Control"]);
			} else {
				throw new Exception("Control skin cannot be initialized. No skin loaded.");
			}
		}

		protected virtual void SetDefaultSize(int width, int height) {
			if (skin.DefaultSize.Width > 0)
				Width = skin.DefaultSize.Width;
			else
				Width = width;
			if (skin.DefaultSize.Height > 0)
				Height = skin.DefaultSize.Height;
			else
				Height = height;
		}

		protected virtual void SetMinimumSize(int minimumWidth, int minimumHeight) {
			if (skin.MinimumSize.Width > 0)
				MinimumWidth = skin.MinimumSize.Width;
			else
				MinimumWidth = minimumWidth;
			if (skin.MinimumSize.Height > 0)
				MinimumHeight = skin.MinimumSize.Height;
			else
				MinimumHeight = minimumHeight;
		}

		protected internal void OnDeviceSettingsChanged(DeviceEventArgs e) {
			if (!e.Handled) {
				Invalidate();
			}
		}

		protected virtual void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			if (backColor != UndefinedColor && backColor != Color.Transparent) {
				renderer.Draw(Manager.Skin.Images["Control"].Resource, rect, backColor);
			}
			renderer.DrawLayer(this, skin.Layers[0], rect);
		}

		protected internal override void Update(GameTime gameTime) {
			base.Update(gameTime);

			ToolTipUpdate();

			if (controls != null) {
				ControlsList list = new ControlsList();
				list.AddRange(controls);
				foreach (Control c in list) {
					c.Update(gameTime);
				}
			}
		}

		protected internal virtual void CheckLayer(SkinControl skin, string layer) {
			if (!(skin != null && skin.Layers != null && skin.Layers.Count > 0 && skin.Layers[layer] != null)) {
				throw new Exception("Unable to read skin layer \"" + layer + "\" for control \"" + Utilities.DeriveControlName(this) + "\".");
			}
		}

		protected internal virtual void CheckLayer(SkinControl skin, int layer) {
			if (!(skin != null && skin.Layers != null && skin.Layers.Count > 0 && skin.Layers[layer] != null)) {
				throw new Exception("Unable to read skin layer with index \"" + layer.ToString() + "\" for control \"" + Utilities.DeriveControlName(this) + "\".");
			}
		}

		public virtual Control GetControl(string name) {
			Control ret = null;
			foreach (Control c in Controls) {
				if (c.Name.ToLower() == name.ToLower()) {
					ret = c;
					break;
				} else {
					ret = c.GetControl(name);
					if (ret != null)
						break;
				}
			}
			return ret;
		}

		public virtual void Add(Control control) {
			if (control != null) {
				if (!controls.Contains(control)) {
					if (control.Parent != null)
						control.Parent.Remove(control);
					else
						Manager.Remove(control);

					control.Manager = Manager;
					control.parent = this;
					control.Root = root;
					control.Enabled = (Enabled ? control.Enabled : Enabled);
					controls.Add(control);

					virtualHeight = GetVirtualHeight();
					virtualWidth = GetVirtualWidth();

					Manager.DeviceSettingsChanged += new DeviceEventHandler(control.OnDeviceSettingsChanged);
					Manager.SkinChanging += new SkinEventHandler(control.OnSkinChanging);
					Manager.SkinChanged += new SkinEventHandler(control.OnSkinChanged);
					Resize += new ResizeEventHandler(control.OnParentResize);

					control.SetAnchorMargins();

					if (!Suspended)
						OnParentChanged(new EventArgs());
				}
			}
		}

		public virtual void Remove(Control control) {
			if (control != null) {
				if (control.Focused && control.Root != null)
					control.Root.Focused = true;
				else if (control.Focused)
					control.Focused = false;

				controls.Remove(control);

				control.parent = null;
				control.Root = control;

				Resize -= control.OnParentResize;
				Manager.DeviceSettingsChanged -= control.OnDeviceSettingsChanged;
				Manager.SkinChanging -= control.OnSkinChanging;
				Manager.SkinChanged -= control.OnSkinChanged;

				if (!Suspended)
					OnParentChanged(new EventArgs());
			}
		}

		public virtual bool Contains(Control control, bool recursively) {
			if (Controls != null) {
				foreach (Control c in Controls) {
					if (c == control)
						return true;
					if (recursively && c.Contains(control, true))
						return true;
				}
			}
			return false;
		}

		public virtual void Invalidate() {
			invalidated = true;

			if (parent != null) {
				parent.Invalidate();
			}
		}

		public virtual void BringToFront() {
			if (Manager != null)
				Manager.BringToFront(this);
		}

		public virtual void SendToBack() {
			if (Manager != null)
				Manager.SendToBack(this);
		}

		public virtual void Show() {
			Visible = true;
		}

		public virtual void Hide() {
			Visible = false;
		}

		public virtual void Refresh() {
			OnMove(new MoveEventArgs(left, top, left, top));
			OnResize(new ResizeEventArgs(width, height, width, height));
		}

		public virtual void SendMessage(EMessage message, EventArgs e) {
			MessageProcess(message, e);
		}

		protected virtual void MessageProcess(EMessage message, EventArgs e) {
			switch (message) {
				case EMessage.Click: {
						ClickProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.MouseDown: {
						MouseDownProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.MouseUp: {
						MouseUpProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.MousePress: {
						MousePressProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.MouseMove: {
						MouseMoveProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.MouseOver: {
						MouseOverProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.MouseOut: {
						MouseOutProcess(e as MouseEventArgs);
						break;
					}
				case EMessage.GamePadDown: {
						GamePadDownProcess(e as GamePadEventArgs);
						break;
					}
				case EMessage.GamePadUp: {
						GamePadUpProcess(e as GamePadEventArgs);
						break;
					}
				case EMessage.GamePadPress: {
						GamePadPressProcess(e as GamePadEventArgs);
						break;
					}
				case EMessage.KeyDown: {
						KeyDownProcess(e as KeyEventArgs);
						break;
					}
				case EMessage.KeyUp: {
						KeyUpProcess(e as KeyEventArgs);
						break;
					}
				case EMessage.KeyPress: {
						KeyPressProcess(e as KeyEventArgs);
						break;
					}
			}
		}

		private void GamePadPressProcess(GamePadEventArgs e) {
			Invalidate();
			if (!Suspended)
				OnGamePadPress(e);
		}

		private void GamePadUpProcess(GamePadEventArgs e) {
			Invalidate();

			if (e.Button == GamePadActions.Press && pressed[(int)e.Button]) {
				pressed[(int)e.Button] = false;
			}

			if (!Suspended)
				OnGamePadUp(e);

			if (e.Button == GamePadActions.ContextMenu && !e.Handled) {
				if (contextMenu != null) {
					contextMenu.Show(this, AbsoluteLeft + 8, AbsoluteTop + 8);
				}
			}
		}

		private void GamePadDownProcess(GamePadEventArgs e) {
			Invalidate();

			ToolTipOut();

			if (e.Button == GamePadActions.Press && !IsPressed) {
				pressed[(int)e.Button] = true;
			}

			if (!Suspended)
				OnGamePadDown(e);
		}

		private void KeyPressProcess(KeyEventArgs e) {
			Invalidate();
			if (!Suspended)
				OnKeyPress(e);
		}


		private void KeyDownProcess(KeyEventArgs e) {
			Invalidate();

			ToolTipOut();

			if (e.Key == Microsoft.Xna.Framework.Input.Keys.Space && !IsPressed) {
				pressed[(int)EMouseButton.None] = true;
			}

			if (!Suspended)
				OnKeyDown(e);
		}

		private void KeyUpProcess(KeyEventArgs e) {
			Invalidate();

			if (e.Key == Microsoft.Xna.Framework.Input.Keys.Space && pressed[(int)EMouseButton.None]) {
				pressed[(int)EMouseButton.None] = false;
			}

			if (!Suspended)
				OnKeyUp(e);

			if (e.Key == Microsoft.Xna.Framework.Input.Keys.Apps && !e.Handled) {
				if (contextMenu != null) {
					contextMenu.Show(this, AbsoluteLeft + 8, AbsoluteTop + 8);
				}
			}
		}

		private void MouseDownProcess(MouseEventArgs e) {
			Invalidate();
			pressed[(int)e.Button] = true;

			if (e.Button == EMouseButton.Left) {
				pressSpot = new Point(TransformPosition(e).Position.X, TransformPosition(e).Position.Y);

				if (CheckResizableArea(e.Position)) {
					pressDiff[0] = pressSpot.X;
					pressDiff[1] = pressSpot.Y;
					pressDiff[2] = Width - pressSpot.X;
					pressDiff[3] = Height - pressSpot.Y;

					IsResizing = true;
					if (outlineResizing)
						OutlineRect = ControlRect;
					if (!Suspended)
						OnResizeBegin(e);
				} else if (CheckMovableArea(e.Position)) {
					IsMoving = true;
					if (outlineMoving)
						OutlineRect = ControlRect;
					if (!Suspended)
						OnMoveBegin(e);
				}
			}

			ToolTipOut();

			if (!Suspended)
				OnMouseDown(TransformPosition(e));
		}

		private void MouseUpProcess(MouseEventArgs e) {
			Invalidate();
			if (pressed[(int)e.Button] || isMoving || isResizing) {
				pressed[(int)e.Button] = false;

				if (e.Button == EMouseButton.Left) {
					if (IsResizing) {
						IsResizing = false;
						if (outlineResizing) {
							Left = OutlineRect.Left;
							Top = OutlineRect.Top;
							Width = OutlineRect.Width;
							Height = OutlineRect.Height;
							OutlineRect = Rectangle.Empty;
						}
						if (!Suspended)
							OnResizeEnd(e);
					} else if (IsMoving) {
						IsMoving = false;
						if (outlineMoving) {
							Left = OutlineRect.Left;
							Top = OutlineRect.Top;
							OutlineRect = Rectangle.Empty;
						}
						if (!Suspended)
							OnMoveEnd(e);
					}
				}
				if (!Suspended)
					OnMouseUp(TransformPosition(e));
			}
		}

		void MousePressProcess(MouseEventArgs e) {
			if (pressed[(int)e.Button] && !IsMoving && !IsResizing) {
				if (!Suspended)
					OnMousePress(TransformPosition(e));
			}
		}

		private void MouseOverProcess(MouseEventArgs e) {
			Invalidate();
			hovered = true;
			ToolTipOver();

#if (!XBOX && !XBOX_FAKE)
			if (cursor != null && Manager.Cursor != cursor)
				Manager.Cursor = cursor;
#endif

			if (!Suspended)
				OnMouseOver(e);
		}

		private void MouseOutProcess(MouseEventArgs e) {
			Invalidate();
			hovered = false;
			ToolTipOut();

#if (!XBOX && !XBOX_FAKE)
			Manager.Cursor = Manager.Skin.Cursors["Default"].Resource;
#endif

			if (!Suspended)
				OnMouseOut(e);
		}

		private void MouseMoveProcess(MouseEventArgs e) {
			if (CheckPosition(e.Position) && !inside) {
				inside = true;
				Invalidate();
			} else if (!CheckPosition(e.Position) && inside) {
				inside = false;
				Invalidate();
			}

			PerformResize(e);

			if (!IsResizing && IsMoving) {
				int x = (parent != null) ? parent.AbsoluteLeft : 0;
				int y = (parent != null) ? parent.AbsoluteTop : 0;

				int l = e.Position.X - x - pressSpot.X - leftModifier;
				int t = e.Position.Y - y - pressSpot.Y - topModifier;

				if (!Suspended) {
					MoveEventArgs v = new MoveEventArgs(l, t, Left, Top);
					OnValidateMove(v);

					l = v.Left;
					t = v.Top;
				}

				if (outlineMoving) {
					OutlineRect = new Rectangle(l, t, OutlineRect.Width, OutlineRect.Height);
					if (parent != null)
						parent.Invalidate();
				} else {
					Left = l;
					Top = t;
				}
			}

			if (!Suspended) {
				OnMouseMove(TransformPosition(e));
			}
		}

		private void ClickProcess(EventArgs e) {
			long timer = (long)TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds;

			MouseEventArgs ex = (e is MouseEventArgs) ? (MouseEventArgs)e : new MouseEventArgs();

			if ((doubleClickTimer == 0 || (timer - doubleClickTimer > Manager.DoubleClickTime)) ||
				!doubleClicks) {
				TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
				doubleClickTimer = (long)ts.TotalMilliseconds;
				doubleClickButton = ex.Button;

				if (!Suspended)
					OnClick(e);


			} else if (timer - doubleClickTimer <= Manager.DoubleClickTime && (ex.Button == doubleClickButton && ex.Button != EMouseButton.None)) {
				doubleClickTimer = 0;
				if (!Suspended)
					OnDoubleClick(e);
			} else {
				doubleClickButton = EMouseButton.None;
			}

			if (ex.Button == EMouseButton.Right && contextMenu != null && !e.Handled) {
				contextMenu.Show(this, ex.Position.X, ex.Position.Y);
			}
		}

		private void ToolTipUpdate() {
			if (Manager.ToolTipsEnabled && toolTip != null && tooltipTimer > 0 && (TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds - tooltipTimer) >= Manager.ToolTipDelay) {
				tooltipTimer = 0;
				toolTip.Visible = true;
				Manager.Add(toolTip);
			}
		}

		private void ToolTipOver() {
			if (Manager.ToolTipsEnabled && toolTip != null && tooltipTimer == 0) {
				TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
				tooltipTimer = (long)ts.TotalMilliseconds;
			}
		}

		private void ToolTipOut() {
			if (Manager.ToolTipsEnabled && toolTip != null) {
				tooltipTimer = 0;
				toolTip.Visible = false;
				Manager.Remove(toolTip);
			}
		}

		private bool CheckPosition(Point pos) {
			if ((pos.X >= AbsoluteLeft) && (pos.X < AbsoluteLeft + Width)) {
				if ((pos.Y >= AbsoluteTop) && (pos.Y < AbsoluteTop + Height)) {
					return true;
				}
			}
			return false;
		}

		private bool CheckMovableArea(Point pos) {
			if (movable) {
				Rectangle rect = movableArea;

				if (rect == Rectangle.Empty) {
					rect = new Rectangle(0, 0, width, height);
				}

				pos.X -= AbsoluteLeft;
				pos.Y -= AbsoluteTop;

				if ((pos.X >= rect.X) && (pos.X < rect.X + rect.Width)) {
					if ((pos.Y >= rect.Y) && (pos.Y < rect.Y + rect.Height)) {
						return true;
					}
				}
			}
			return false;
		}

		private bool CheckResizableArea(Point pos) {
			if (resizable) {
				pos.X -= AbsoluteLeft;
				pos.Y -= AbsoluteTop;

				if ((pos.X >= 0 && pos.X < resizerSize && pos.Y >= 0 && pos.Y < Height) ||
					(pos.X >= Width - resizerSize && pos.X < Width && pos.Y >= 0 && pos.Y < Height) ||
					(pos.Y >= 0 && pos.Y < resizerSize && pos.X >= 0 && pos.X < Width) ||
					(pos.Y >= Height - resizerSize && pos.Y < Height && pos.X >= 0 && pos.X < Width)) {
					return true;
				}
			}
			return false;
		}

		private MouseEventArgs TransformPosition(MouseEventArgs e) {
			MouseEventArgs ee = new MouseEventArgs(e.State, e.Button, e.Position);
			ee.Difference = e.Difference;

			ee.Position.X = ee.State.X - AbsoluteLeft;
			ee.Position.Y = ee.State.Y - AbsoluteTop;
			return ee;
		}

		private int CheckWidth(ref int w) {
			int diff = 0;

			if (w > MaximumWidth) {
				diff = MaximumWidth - w;
				w = MaximumWidth;
			}
			if (w < MinimumWidth) {
				diff = MinimumWidth - w;
				w = MinimumWidth;
			}

			return diff;
		}

		private int CheckHeight(ref int h) {
			int diff = 0;

			if (h > MaximumHeight) {
				diff = MaximumHeight - h;
				h = MaximumHeight;
			}
			if (h < MinimumHeight) {
				diff = MinimumHeight - h;
				h = MinimumHeight;
			}

			return diff;
		}

		private void PerformResize(MouseEventArgs e) {
			if (resizable && !IsMoving) {
				if (!IsResizing) {
#if (!XBOX && !XBOX_FAKE)
					GetResizePosition(e);
					Manager.Cursor = Cursor = GetResizeCursor();
#endif
				}

				if (IsResizing) {
					invalidated = true;

					bool top = false;
					bool bottom = false;
					bool left = false;
					bool right = false;

					if ((resizeArea == EAlignment.TopCenter ||
						resizeArea == EAlignment.TopLeft ||
						resizeArea == EAlignment.TopRight) && (resizeEdge & EAnchors.Top) == EAnchors.Top)
						top = true;

					else if ((resizeArea == EAlignment.BottomCenter ||
							 resizeArea == EAlignment.BottomLeft ||
							 resizeArea == EAlignment.BottomRight) && (resizeEdge & EAnchors.Bottom) == EAnchors.Bottom)
						bottom = true;

					if ((resizeArea == EAlignment.MiddleLeft ||
						resizeArea == EAlignment.BottomLeft ||
						resizeArea == EAlignment.TopLeft) && (resizeEdge & EAnchors.Left) == EAnchors.Left)
						left = true;

					else if ((resizeArea == EAlignment.MiddleRight ||
							 resizeArea == EAlignment.BottomRight ||
							 resizeArea == EAlignment.TopRight) && (resizeEdge & EAnchors.Right) == EAnchors.Right)
						right = true;

					int w = Width;
					int h = Height;
					int l = Left;
					int t = Top;

					if (outlineResizing && !OutlineRect.IsEmpty) {
						l = OutlineRect.Left;
						t = OutlineRect.Top;
						w = OutlineRect.Width;
						h = OutlineRect.Height;
					}

					int px = e.Position.X - (parent != null ? parent.AbsoluteLeft : 0);
					int py = e.Position.Y - (parent != null ? parent.AbsoluteTop : 0);

					if (left) {
						w = w + (l - px) + leftModifier + pressDiff[0];
						l = px - leftModifier - pressDiff[0] - CheckWidth(ref w);

					} else if (right) {
						w = px - l - leftModifier + pressDiff[2];
						CheckWidth(ref w);
					}

					if (top) {
						h = h + (t - py) + topModifier + pressDiff[1];
						t = py - topModifier - pressDiff[1] - CheckHeight(ref h);
					} else if (bottom) {
						h = py - t - topModifier + pressDiff[3];
						CheckHeight(ref h);
					}

					if (!Suspended) {
						ResizeEventArgs v = new ResizeEventArgs(w, h, Width, Height);
						OnValidateResize(v);

						if (top) {
							// Compensate for a possible height change from Validate event
							t += (h - v.Height);
						}
						if (left) {
							// Compensate for a possible width change from Validate event
							l += (w - v.Width);
						}
						w = v.Width;
						h = v.Height;
					}

					if (outlineResizing) {
						OutlineRect = new Rectangle(l, t, w, h);
						if (parent != null)
							parent.Invalidate();
					} else {
						Width = w;
						Height = h;
						Top = t;
						Left = l;
					}
				}
			}
		}

#if (!XBOX && !XBOX_FAKE)
		private Cursor GetResizeCursor() {
			Cursor cur = Cursor;
			switch (resizeArea) {
				case EAlignment.TopCenter: {
						return ((resizeEdge & EAnchors.Top) == EAnchors.Top) ? Manager.Skin.Cursors["Vertical"].Resource : Cursor;
					}
				case EAlignment.BottomCenter: {
						return ((resizeEdge & EAnchors.Bottom) == EAnchors.Bottom) ? Manager.Skin.Cursors["Vertical"].Resource : Cursor;
					}
				case EAlignment.MiddleLeft: {
						return ((resizeEdge & EAnchors.Left) == EAnchors.Left) ? Manager.Skin.Cursors["Horizontal"].Resource : Cursor;
					}
				case EAlignment.MiddleRight: {
						return ((resizeEdge & EAnchors.Right) == EAnchors.Right) ? Manager.Skin.Cursors["Horizontal"].Resource : Cursor;
					}
				case EAlignment.TopLeft: {
						return ((resizeEdge & EAnchors.Left) == EAnchors.Left && (resizeEdge & EAnchors.Top) == EAnchors.Top) ? Manager.Skin.Cursors["DiagonalLeft"].Resource : Cursor;
					}
				case EAlignment.BottomRight: {
						return ((resizeEdge & EAnchors.Bottom) == EAnchors.Bottom && (resizeEdge & EAnchors.Right) == EAnchors.Right) ? Manager.Skin.Cursors["DiagonalLeft"].Resource : Cursor;
					}
				case EAlignment.TopRight: {
						return ((resizeEdge & EAnchors.Top) == EAnchors.Top && (resizeEdge & EAnchors.Right) == EAnchors.Right) ? Manager.Skin.Cursors["DiagonalRight"].Resource : Cursor;
					}
				case EAlignment.BottomLeft: {
						return ((resizeEdge & EAnchors.Bottom) == EAnchors.Bottom && (resizeEdge & EAnchors.Left) == EAnchors.Left) ? Manager.Skin.Cursors["DiagonalRight"].Resource : Cursor;
					}
			}
			return Manager.Skin.Cursors["Default"].Resource;
		}
#endif

		private void GetResizePosition(MouseEventArgs e) {
			int x = e.Position.X - AbsoluteLeft;
			int y = e.Position.Y - AbsoluteTop;
			bool l = false, t = false, r = false, b = false;

			resizeArea = EAlignment.None;

			if (CheckResizableArea(e.Position)) {
				if (x < resizerSize)
					l = true;
				if (x >= Width - resizerSize)
					r = true;
				if (y < resizerSize)
					t = true;
				if (y >= Height - resizerSize)
					b = true;

				if (l && t)
					resizeArea = EAlignment.TopLeft;
				else if (l && b)
					resizeArea = EAlignment.BottomLeft;
				else if (r && t)
					resizeArea = EAlignment.TopRight;
				else if (r && b)
					resizeArea = EAlignment.BottomRight;
				else if (l)
					resizeArea = EAlignment.MiddleLeft;
				else if (t)
					resizeArea = EAlignment.TopCenter;
				else if (r)
					resizeArea = EAlignment.MiddleRight;
				else if (b)
					resizeArea = EAlignment.BottomCenter;
			} else {
				resizeArea = EAlignment.None;
			}
		}

		protected virtual void OnMouseUp(MouseEventArgs e) {
			if (MouseUp != null)
				MouseUp.Invoke(this, e);
		}

		protected virtual void OnMouseDown(MouseEventArgs e) {
			if (MouseDown != null)
				MouseDown.Invoke(this, e);
		}

		protected virtual void OnMouseMove(MouseEventArgs e) {
			if (MouseMove != null)
				MouseMove.Invoke(this, e);
		}

		protected virtual void OnMouseOver(MouseEventArgs e) {
			if (MouseOver != null)
				MouseOver.Invoke(this, e);
		}

		protected virtual void OnMouseOut(MouseEventArgs e) {
			if (MouseOut != null)
				MouseOut.Invoke(this, e);
		}

		protected virtual void OnClick(EventArgs e) {
			if (Click != null)
				Click.Invoke(this, e);
		}

		protected virtual void OnDoubleClick(EventArgs e) {
			if (DoubleClick != null)
				DoubleClick.Invoke(this, e);
		}

		protected virtual void OnMove(MoveEventArgs e) {
			if (parent != null)
				parent.Invalidate();
			if (Move != null)
				Move.Invoke(this, e);
		}

		protected virtual void OnResize(ResizeEventArgs e) {
			Invalidate();
			if (Resize != null)
				Resize.Invoke(this, e);
		}

		protected virtual void OnValidateResize(ResizeEventArgs e) {
			if (ValidateResize != null)
				ValidateResize.Invoke(this, e);
		}

		protected virtual void OnValidateMove(MoveEventArgs e) {
			if (ValidateMove != null)
				ValidateMove.Invoke(this, e);
		}


		protected virtual void OnMoveBegin(EventArgs e) {
			if (MoveBegin != null)
				MoveBegin.Invoke(this, e);
		}

		protected virtual void OnMoveEnd(EventArgs e) {
			if (MoveEnd != null)
				MoveEnd.Invoke(this, e);
		}

		protected virtual void OnResizeBegin(EventArgs e) {
			if (ResizeBegin != null)
				ResizeBegin.Invoke(this, e);
		}

		protected virtual void OnResizeEnd(EventArgs e) {
			if (ResizeEnd != null)
				ResizeEnd.Invoke(this, e);
		}

		protected virtual void OnParentResize(object sender, ResizeEventArgs e) {
			ProcessAnchor(e);
		}

		protected virtual void OnKeyUp(KeyEventArgs e) {
			if (KeyUp != null)
				KeyUp.Invoke(this, e);
		}

		protected virtual void OnKeyDown(KeyEventArgs e) {
			if (KeyDown != null)
				KeyDown.Invoke(this, e);
		}

		protected virtual void OnKeyPress(KeyEventArgs e) {
			if (KeyPress != null)
				KeyPress.Invoke(this, e);
		}

		protected virtual void OnGamePadUp(GamePadEventArgs e) {
			if (GamePadUp != null)
				GamePadUp.Invoke(this, e);
		}

		protected virtual void OnGamePadDown(GamePadEventArgs e) {
			if (GamePadDown != null)
				GamePadDown.Invoke(this, e);
		}

		protected virtual void OnGamePadPress(GamePadEventArgs e) {
			if (GamePadPress != null)
				GamePadPress.Invoke(this, e);
		}

		protected internal void OnDraw(DrawEventArgs e) {
			if (Draw != null)
				Draw.Invoke(this, e);
		}

		protected void OnDrawTexture(DrawEventArgs e) {
			if (DrawTexture != null)
				DrawTexture.Invoke(this, e);
		}


		protected virtual void OnColorChanged(EventArgs e) {
			if (ColorChanged != null)
				ColorChanged.Invoke(this, e);
		}

		protected virtual void OnTextColorChanged(EventArgs e) {
			if (TextColorChanged != null)
				TextColorChanged.Invoke(this, e);
		}

		protected virtual void OnBackColorChanged(EventArgs e) {
			if (BackColorChanged != null)
				BackColorChanged.Invoke(this, e);
		}

		protected virtual void OnTextChanged(EventArgs e) {
			if (TextChanged != null)
				TextChanged.Invoke(this, e);
		}

		protected virtual void OnAnchorChanged(EventArgs e) {
			if (AnchorChanged != null)
				AnchorChanged.Invoke(this, e);
		}

		protected internal virtual void OnSkinChanged(EventArgs e) {
			if (SkinChanged != null)
				SkinChanged.Invoke(this, e);
		}

		protected internal virtual void OnSkinChanging(EventArgs e) {
			if (SkinChanging != null)
				SkinChanging.Invoke(this, e);
		}

		protected virtual void OnParentChanged(EventArgs e) {
			if (ParentChanged != null)
				ParentChanged.Invoke(this, e);
		}

		protected virtual void OnRootChanged(EventArgs e) {
			if (RootChanged != null)
				RootChanged.Invoke(this, e);
		}

		protected virtual void OnVisibleChanged(EventArgs e) {
			if (VisibleChanged != null)
				VisibleChanged.Invoke(this, e);
		}

		protected virtual void OnEnabledChanged(EventArgs e) {
			if (EnabledChanged != null)
				EnabledChanged.Invoke(this, e);
		}

		protected virtual void OnAlphaChanged(EventArgs e) {
			if (AlphaChanged != null)
				AlphaChanged.Invoke(this, e);
		}

		protected virtual void OnFocusLost(EventArgs e) {
			if (FocusLost != null)
				FocusLost.Invoke(this, e);
		}

		protected virtual void OnFocusGained(EventArgs e) {
			if (FocusGained != null)
				FocusGained.Invoke(this, e);
		}

		protected virtual void OnMousePress(MouseEventArgs e) {
			if (MousePress != null)
				MousePress.Invoke(this, e);
		}

	}

}