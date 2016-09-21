// Primes List.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <cmath>
#include <iostream>
#include <chrono>

using namespace std;
using namespace chrono;

float (*sqrt_global)(float) = sqrt;

static bool isPrime(unsigned int nums[],unsigned int i)
{
	double root = sqrt_global(i);
	for (unsigned int test = 1; test <= root; ++test)
	{
		if (nums[test] > root)
		{
		return true;
		}
		else if (i % nums[test] == 0)
		{
			return false;
		}
	}
	return true;
}

void main()
{

	high_resolution_clock::time_point start = high_resolution_clock::now();


	int index = 3;
	const int ammount = 20000000;
	unsigned int *nums = new unsigned int[ammount];
	nums[0] = 2;
	nums[1] = 3;
	nums[2] = 5;

	for (unsigned int i = 5; i <= ammount; i += 2)
	{
		if (isPrime(nums, i))
		{
			nums[index] = i;
			++index;
		}
	}

	high_resolution_clock::time_point end = high_resolution_clock::now();
	duration<double> time_span = duration_cast<duration<double>>(end - start);

	int random;

	cout << time_span.count() << endl;
	cout << index << endl;
	
	system("pause");
	cout << endl;

	for (int i = 0; i <= index - 1; ++i)
	{
		cout << nums[i];
	}
	system("pause");
}

