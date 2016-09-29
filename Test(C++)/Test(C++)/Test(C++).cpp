// Test(C++).cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

int main()
{
	double x = 1;
	while (true)
	{
		x *= x + 1;
		std::cout << x << std::endl;
	}
    return 0;
}

