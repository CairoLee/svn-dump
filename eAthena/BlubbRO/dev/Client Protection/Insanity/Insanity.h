#include <windows.h>
#include <detours.h>
#include <tchar.h>
#include <stdio.h>
#include <time.h>

#include <string>
#include <map>

void log( const wchar_t *string, ... );
