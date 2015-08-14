#include <iostream>
#include <Windows.h>
#include <sstream>
#include <string>

static class I_O
{
public:
	static std::string IntToString(int number);
	static std::string CharToString(char * text, int length);
	static std::string FloatToString(float number);
};


