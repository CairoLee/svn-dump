#include "Insanity.h"
#include "Splash.h"

Splash *Splash::SplashWnd = 0;
ATOM Splash::WndClass = 0;
int Splash::TimerDelay = 0;

Splash::Splash( HWND hWnd ){
	RealWnd = hWnd;
}

BOOL Splash::Show( HWND hWnd, int delayTime ){
	TimerDelay = delayTime;
	if( SplashWnd == 0 ) {
		SplashWnd = new Splash( hWnd );
		if ( !SplashWnd->Create( hWnd ) ){
			//MessageBox( 0, L"Failed to create Splash Screen?", L"Insanity - Client Protection", 0 );
			delete SplashWnd;
			SplashWnd = 0;
			return FALSE;
		}
	}

	if( hWnd )
		UpdateWindow( hWnd );
	if( TimerDelay )
		SetTimer( SplashWnd->FakeWnd, 1, TimerDelay, 0);

	ShowWindow( SplashWnd->FakeWnd, SW_SHOW );
	UpdateWindow( SplashWnd->FakeWnd );
	InvalidateRect( SplashWnd->FakeWnd, 0, FALSE );

	MSG msg;
    while( PeekMessage( &msg, SplashWnd->FakeWnd, 0, 0, PM_REMOVE ) ){ 
		TranslateMessage( &msg );
		DispatchMessage( &msg );
	}

	return TRUE;
}

void Splash::Hide(){
	if( SplashWnd != 0 ) {
		DestroyWindow( SplashWnd->FakeWnd );
		if( SplashWnd->RealWnd && ::IsWindow( SplashWnd->RealWnd ) )
			UpdateWindow( SplashWnd->RealWnd );
	}
}

BOOL Splash::RegisterClass(LPCTSTR WndClassName) {
	WNDCLASSEX wcex;
	wcex.cbSize = sizeof(WNDCLASSEX); 
	wcex.hbrBackground	= (HBRUSH) (COLOR_WINDOW + 1);
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hIcon			= LoadIconW(NULL, IDI_APPLICATION);//LoadIconW(NULL, L"icon1.ico");
	wcex.hInstance		= GetModuleHandle(NULL);
	wcex.lpfnWndProc	= (WNDPROC)WndProc;
	wcex.lpszClassName	= WndClassName;
	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	SetLastError(0);
	WndClass = RegisterClassEx(&wcex);
	log(L"Splash::RegisterClass: RegisterClassEx last error = %d..\n", GetLastError());

	return (BOOL)(WndClass != 0);
}

BOOL Splash::Create( HWND hWnd ){
	BitmapSplash = (HBITMAP)LoadImageW( GetModuleHandleW( 0 ), L"insanity.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE | LR_CREATEDIBSECTION | LR_DEFAULTSIZE );
	if( BitmapSplash == NULL ) {
		log(L"Splash::Create: Failed to load splash bitmap..\n");
		return FALSE;
	}
	HWND hwndDesktop = GetDesktopWindow( ); 
    HDC hdcDesktop = GetDC( hwndDesktop ); 

	BITMAPINFO bitmapInfo;
	memset( &bitmapInfo, 0, sizeof( BITMAPINFOHEADER ) );
	bitmapInfo.bmiHeader.biSize = sizeof( BITMAPINFOHEADER );
	GetDIBits( hdcDesktop, BitmapSplash, 0, 0, 0, &bitmapInfo, DIB_RGB_COLORS );

	if( WndClass == 0 ) {
		BOOL result = this->RegisterClassW(L"ProtSplash");
		if (result != TRUE) {
			log(L"Splash::Create: Failed to register class ProtSplash, last error = %d..\n", GetLastError());
			return FALSE;
		}
	}

	RECT parentRect;
	if( hWnd == 0 )
		GetWindowRect( GetDesktopWindow( ), &parentRect );
	else
		GetWindowRect( hWnd, &parentRect );

	FakeWnd = CreateWindowExW(
		0,
		L"ProtSplash",
		L"Insanity - Client Protection",
		WS_POPUP | WS_VISIBLE,
		parentRect.left + ( parentRect.right - parentRect.left ) / 2 - ( bitmapInfo.bmiHeader.biWidth / 2 ),
		parentRect.top + ( parentRect.bottom - parentRect.top ) / 2 - ( bitmapInfo.bmiHeader.biHeight / 2 ),
		bitmapInfo.bmiHeader.biWidth,
		bitmapInfo.bmiHeader.biHeight,
		hWnd,
		0,
		GetModuleHandle( 0 ),
		this
	);
	
	if( FakeWnd == 0 ) {
		log(L"Splash::Create: Failed to create fake wnd..\n");
		return FALSE;
	}

	if( hWnd == 0 ){
		SetWindowPos( FakeWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE );
	}

	return TRUE;
}

LRESULT CALLBACK Splash::WndProc( HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam ){
	switch( message ){
		case WM_PAINT:
			SplashWnd->OnPaint( hWnd );
			break;
		case WM_TIMER:
			SplashWnd->Hide();
			break;
		default:
			return DefWindowProc( hWnd, message, wParam, lParam );
   }
   return 0;
}

void Splash::OnPaint( HWND hWnd ){
	PAINTSTRUCT ps;
	HDC paintDC = BeginPaint( hWnd, &ps );
	HDC imageDC = CreateCompatibleDC( paintDC );

	BITMAPINFO bitmapInfo;
	memset( &bitmapInfo, 0, sizeof( BITMAPINFOHEADER ) );
	bitmapInfo.bmiHeader.biSize = sizeof( BITMAPINFOHEADER );
	GetDIBits( imageDC, BitmapSplash, 0, 0, 0, &bitmapInfo, DIB_RGB_COLORS );

	HBITMAP pOldBitmap = ( HBITMAP ) SelectObject( imageDC, BitmapSplash );
	BitBlt( paintDC, 0, 0, bitmapInfo.bmiHeader.biWidth, bitmapInfo.bmiHeader.biHeight, imageDC, 0, 0, SRCCOPY );
	SelectObject( imageDC, pOldBitmap );
	EndPaint( hWnd, &ps );
}
