// BabRoot.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <iostream>
#include <sstream>
#include <string>
#include <cstdlib>
#include <cmath>

using namespace std;

int main() {
	// Thomas Queenan
	double Square;
	double X;
	double Guess;

	cin >> Square;
	Guess = 1;
	X = 0;
	do {
		X = Guess;
		Guess = 1 / 2 * (Guess + Square / Guess);
	} while (pow(Guess, 2) != Square && Guess != X);
	cout << "The Square root is " << Guess << endl;
}

