// Primes List.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <cmath>
#include <iostream>
#include <chrono>

using namespace std;
using namespace chrono;



bool isPrime(unsigned long int nums[],unsigned long int i)
{
	double root = sqrt(i);
	for (unsigned long int test = 1; test <= root; ++test)
	{
		if (nums[test] >= i)
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


	int index = 2;
	const int ammount = 20000;
	unsigned long int nums[ammount] = { 2,3,5 };

	for (unsigned long int i = 5; i <= 20000000; i += 2)
	{
		if (isPrime(nums, i))
		{
			//cout << i;
			nums[index] = i;
			index += 1;
		}
	}

	high_resolution_clock::time_point end = high_resolution_clock::now();
	duration<double> time_span = duration_cast<duration<double>>(end - start);

	int random;

	cout << time_span.count() << endl;
	cout << index << endl;
	cin>>random;

}

