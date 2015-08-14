class Splash{
protected:
	BOOL Create( HWND hWnd );
	BOOL RegisterClass( LPCTSTR WndClassName );
	void OnPaint( HWND hWnd );
	static LRESULT CALLBACK WndProc( HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam );
private:
	HWND RealWnd, FakeWnd;
	static Splash *SplashWnd;
	static ATOM WndClass;
	static int TimerDelay;
	HBITMAP BitmapSplash;
public:
	Splash( HWND hWnd );
	static BOOL Show( HWND hWnd, int delayTime );
	static void Hide();
};