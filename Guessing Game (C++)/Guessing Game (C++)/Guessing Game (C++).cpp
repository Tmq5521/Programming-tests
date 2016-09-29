// Guessing Game (C++).cpp : Defines the entry point for the console application.
//Thomas M. Queenan

#include "stdafx.h"
#include <iostream> // i/o
#include <cmath> // math functions
#include <windows.h> // console name


using namespace std; // easy i/o


void main()
{
	SetConsoleTitle(TEXT("Guessing Game"));
	cout << "The Number Guessing Game!" << endl; // introduce game
	int num = (rand() % 100) + 1; // initiate number to guess
	int guess = num; // set guess to num so no weird message appears
	do // allways do once at least
	{
		if (guess > num) // tell user if to high
			cout << "Too high." << endl;
		if (guess < num) // tell user if to low
			cout << "Too low." << endl;
		cout << "Pick a number between 1 and 100." << endl; // ask to pick a number
		cin >> guess; // read guess
	} while (guess != num); // repeat as long as not correct
	cout << "you win!" << endl; // reply win
	system("pause"); // pause till end
}