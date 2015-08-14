#include "I_O.h"


std::string I_O::IntToString(int number)
{
   std::stringstream ss;//create a stringstream
   ss << number;//add number to the stream
   return ss.str();//return a string with the contents of the stream
}

std::string I_O::FloatToString(float number)
{
   //Round our number down
   number = floorf(number);
   std::stringstream ss;
   ss << number;
   return ss.str();
}
