using System;
using Awesomium.Core;
using log4net;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Awesomium {

	public class AwesomiumComponent {
		public delegate void OnLoadCompletedDelegate();
		public delegate void OnDocumentCompletedDelegate();

		protected ILog mLogger = null;
		protected bool mFinishedLoading;
		protected string mBasePath;

		public bool PauseUiDraw = false;
		public bool PauseUiUpdate = false;

		public Texture2D WebTexture {
			get;
			protected set;
		}

		public WebSession WebSession {
			get;
			protected set;
		}

		public WebView WebView {
			get;
			protected set;
		}

		public ILog Logger {
			get;
			protected set;
		}

		public OnLoadCompletedDelegate OnLoadCompleted {
			get;
			set;
		}

		public OnDocumentCompletedDelegate OnDocumentCompleted {
			get;
			set;
		}


		public AwesomiumComponent() {
		}

		public AwesomiumComponent(ILog logger) {
			Logger = logger;
		}


		public void Initialize(GraphicsDevice device, int renderTargetWidth, int renderTargetHeight, string basePath, string customCss = "") {
			mBasePath = basePath;

			//OnLoadCompleted = new OnLoadCompletedDelegate();

			//WebCore.Initialize(new WebCoreConfig() { CustomCSS = "::-webkit-scrollbar { visibility: hidden; }" });			
			//WebCore.Initialize(new WebConfig() { CustomCSS = customCSS, SaveCacheAndCookies = true });  //1.7
			//WebCore.Initialize(new WebCoreConfig() { CustomCSS = customCSS, SaveCacheAndCookies = true });
			var webConfig = new WebConfig {
				LogPath = Environment.CurrentDirectory,
				LogLevel = LogLevel.Verbose
			};
			WebCore.Initialize(webConfig);

			var webPreferences = new WebPreferences {
				CustomCSS = "::-webkit-scrollbar { visibility: hidden; }"
			};
			WebSession = WebCore.CreateWebSession(webPreferences);

			if (mLogger != null)
				mLogger.Info("WEBCORE initialized.");

			WebTexture = new Texture2D(device, renderTargetWidth, renderTargetHeight);

			if (mLogger != null)
				mLogger.Info("Rendertarget created.");


			WebView = WebCore.CreateWebView(renderTargetWidth, renderTargetHeight, WebSession);

			//LoadingFrameComplete still seems to take an
			//inordinate amout of time with local files...
			//SOMETIMES.  
			//As long as you haven't navigated to an online
			//page and back it is instant.  Odd.
			WebView.DocumentReady += OnDocumentReadyInternal;
			WebView.LoadingFrameComplete += OnLoadingFrameCompleteInternal;

			if (mLogger != null)
				mLogger.Info("WebView created.");

			WebView.IsTransparent = true;
		}

		public void Shutdown() {
			if (mLogger != null)
				mLogger.Info("Shutting down WebCore.");

			WebCore.Shutdown();

			WebSession.Dispose();
		}


		public void Focus() {
			WebView.FocusView();
		}


		/// <summary>
		/// Load a URL into the webView.
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public bool LoadFromUrl(string url) {
			var success = false;

			try {
				mFinishedLoading = false;

				if (mLogger != null)
					mLogger.Info(string.Format("Loading: {0}", url));

				// @TODO: There is probably a better way to do this
				if (url.ToUpper().Contains("HTTP") == false) {
					url = mBasePath + "\\" + url;
				}

				WebView.Source = new Uri(url);
				success = true;
			} catch (Exception e) {
				if (mLogger != null) {
					mLogger.Error(e);
				}
			}

			return success;
		}


		private void OnDocumentReadyInternal(object sender, UrlEventArgs e) {
			if (mLogger != null)
				mLogger.Info("Documente ready.");

			if (OnDocumentCompleted != null) {
				OnDocumentCompleted();
			}
		}


		private void OnLoadingFrameCompleteInternal(object sender, FrameEventArgs e) {
			if (!e.IsMainFrame) {
				return;
			}

			mFinishedLoading = true;
			Focus();

			if (mLogger != null) {
				mLogger.Info("Load finished.");
			}

			if (OnLoadCompleted != null) {
				OnLoadCompleted();
			}
		}

		public void Update() {
			if (PauseUiUpdate) {
				return;
			}

			WebCore.Update();
		}

		public bool NeedsToBeDrawn() {
			if (PauseUiDraw) {
				return false;
			}

			if (WebView.Surface == null) {
				return false;
			}

			if (((BitmapSurface)WebView.Surface).IsDirty == false || WebTexture == null) {
				return false;
			}

			return true;
		}

		public void RenderWebView() {
			if (PauseUiDraw) {
				return;
			}

			try {
				var surface = (BitmapSurface)WebView.Surface;
				if (surface != null) {
					surface.RenderTexture2D(WebTexture);
				}
			} catch (Exception ex) {
				if (mLogger != null) {
					mLogger.Fatal(this, ex);
				}

				System.Diagnostics.Debug.WriteLine(ex);
			}
		}


		//http://wiki.awesomium.com/javascript-integration/introduction-to-javascript-integration.html

		public JSObject CreateJsObject(string objectName) {
			return CreateGlobalJsObject(objectName);
		}

		public void CreateJsObject(string objectName, string method, JavascriptMethodEventHandler callback) {
			var jsObject = CreateJsObject(objectName);

			jsObject.Bind(method, false, callback);
			//This used to be SetObjectCallback.
		}

		/// <summary>
		/// Global JS Objects persist between pages.
		/// </summary>
		/// <param name="objectName"></param>
		/// <returns></returns>
		public JSObject CreateGlobalJsObject(string objectName) {
			//webView.CreateObject(objectName); 
			return WebView.CreateGlobalJavascriptObject(objectName);
		}

		public object CallJavascriptWithResult(string javaScript) {
			var val = WebView.ExecuteJavascriptWithResult(javaScript);
			return val;
		}

		public void CallJavascript(string javaScript) {
			WebView.ExecuteJavascript(javaScript);
		}

		public void CallJavascriptFunction(string function, string message, string objectName = "") {
			//webView.CallJavascriptFunction(objectName, function, args);
			WebView.ExecuteJavascript(function + "('" + message + "');");
		}


		public void InjectKeyboardEvent(int msg, int wParam, int lParam) {
			//webView.InjectKeyboardEventWin((int)msg, (int)wParam, (int)lParam);

			const Modifiers modifiers = new Modifiers();
			var keyEvent = new WebKeyboardEvent((uint)msg, (IntPtr)wParam, (IntPtr)lParam, modifiers);

			WebView.InjectKeyboardEvent(keyEvent);
		}


		public void InjectMouseMove(int x, int y) {
			WebView.InjectMouseMove(x, y);
		}

		public void InjectMouseDown(WinMouseButton mouseButton) {
			WebView.InjectMouseDown((MouseButton)((int)mouseButton - 1));
		}

		public void InjectMouseUp(WinMouseButton mouseButton) {
			WebView.InjectMouseUp((MouseButton)((int)mouseButton - 1));
		}

		public void MouseUpHandler(WinMouseButton mouseButton) {
			WebView.InjectMouseUp((MouseButton)((int)mouseButton - 1));
		}

	}

}
