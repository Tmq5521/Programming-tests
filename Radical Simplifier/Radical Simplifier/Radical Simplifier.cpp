// Radical Simplifier.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <iostream>
#include <cmath>
#include <string>
#include <sstream>

//Types
typedef std::string string;

//Functions

//simplifies radicals
string radSimp(string str1, string str2)
{
	std::ostringstream strObj;
	double radicand = std::stod(str1);
	double index = std::stod(str2);
	for (double i = floor(pow(radicand, (1 / index))); i >= 1; i--)
	{
		if (fmod(radicand, pow(i, index)) == 0)
		{
			if (radicand / pow(i, index) == 1)
				strObj << i << std::endl;
			else if (i == 1)
				strObj << index << " roots of ( " << radicand << ")" << std::endl;
			else
				strObj << i << " * ( " << index << " roots of ( " << radicand / pow(i, index) << "))" << std::endl;
			return strObj.str();
		}
	}
}

//checks if double
bool isFloat(string str)
{
	try //sees if it can convert
	{
		std::stod(str);
		return true;
	}
	catch (...) //else
	{
		return false;
	}
}

int main()
{
	//Variables
	string strRadicand;
	string strIndex;
	string output;

	while (true)
	{
		//Input
		std::cout << "Radicand: ";
		std::cin >> strRadicand;

		std::cout << "Index: ";
		std::cin >> strIndex;

		//Error checks
		if (isFloat(strRadicand) && isFloat(strIndex)) //is number
		{
			if (log10(std::stod(strRadicand)) <= 16 && log10(std::stod(strIndex)) <= 16) // accuracy
			{
				if ((std::stod(strRadicand) >= 0) || (std::stod(strIndex) > 1)) //math errors
				{
					//Calc and print
					std::cout << radSimp(strRadicand, strIndex) << std::endl;
				}
				else //catch for math errors
				{
					std::cout << "Error: negitive radicand or <1 Index" << std::endl;
				} 
			}
			else //catch for size error
			{
				std::cout << "Error: Too large to be precice" << std::endl;
			}
		}
		else //catch for number error
		{
			std::cout << "Error: not a number" << std::endl;
		}
	}
	return 0;
}