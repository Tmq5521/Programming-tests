// Primes List.cpp : Defines the entry point for the console application.
//

#include <cmath>
#include <iostream>
#include <chrono>
#include <windows.h>

#include <deque>
#include <vector>
#include <thread>

#define _DEBUG_ true

//using for ease
using namespace std;
using namespace chrono;

//local sqrt is much faster
double (*sqrt_local)(double) = sqrt;

void isPrime(vector<unsigned int> &nums, unsigned int i, int id)
{
    //calc sqrt
	double root = sqrt_local(i);

    //test previous primes
	for (unsigned int test = 0; nums[test] <= root; ++test)
	{
        //out of primes to test by
		if (nums[test] > root)
		{
            //store in the back
			nums.push_back(i);

            //display
#if _DEBUG_
                cout << "Warning: Thread[" << id << "]: " << i << endl;
#endif            
            //end
            return;
		}
        //was divisible
		else if (i % nums[test] == 0)
		{
            //not prime
            //end
			return;
		}
	}
    //??? escaped some how add to the list
    nums.push_back(i);
    
    //display as a warning instead
#if _DEBUG_
        cout << "Info: Thread[" << id << "]: " << i << endl;
#endif
    //end
    return;
}

void main()
{
    //window title
	SetConsoleTitle(TEXT("Primes List"));

    //start clock
	high_resolution_clock::time_point start = high_resolution_clock::now();

    //max number to test
	const int ammount = 20000000; //20000000

    //Max number of threads
    int tMax = thread::hardware_concurrency();

    //Display number of threads
#if _DEBUG_
        cout << "Info: Max threads:" << tMax << endl;
#endif
    //prime list and pre-seeding
    std::vector<unsigned int> numbers;
    numbers.push_back(2);

    //thread list
    std::deque<std::thread> threads;

    //start counter at 3 incerment by 2
    unsigned int i = 3;

    //while below max number to test
    while (i <= ammount)
    {
        //can be checked fast
        //if (sqrt_local(i) < numbers.back())
        if (true)
        {
            //max threads
            while ((unsigned int)tMax <= threads.size())
            {
                //debug full threads warning
#if _DEBUG_
                    cout << "Warning: Threads full @ " << tMax << " Threads" << endl;
#endif
                //for all threads
                for (unsigned int counter = 0; counter < threads.size(); counter++)
                {
                    //still running
                    if (!threads[counter].joinable())
                    {
                        //debug thread stopping
#if _DEBUG_
                            cout << "Info: Thread[" << counter << "]: Deleted" << endl;
#endif
                        //clear thread slot
                        threads.erase(threads.begin()+counter);
                    }
                }
                //shrink to smallest
                threads.shrink_to_fit();
            }

            //add thread
            threads.push_front(std::thread(isPrime, ref(numbers), i, threads.size()));
            threads.front().detach();
            
            //debug infodump
#if _DEBUG_
            cout << "Info: Size: " << threads.size() << " int: " << i << " Primes: " << numbers.size() << endl;
#endif
            i += 2; //inc if testing num
        }

        //cant check fast
        else
        {
            //warn that i is a slow calculation and wait till it is not
#if _DEBUG_
            cout << "Warning: " << i << " exceeds sqrt(" << numbers[numbers.size()-1] << ")" << endl;
#endif
        }
    }

    //clear list at the end
    threads.empty();

    //timing calc
	high_resolution_clock::time_point end = high_resolution_clock::now();
	duration<double> time_span = duration_cast<duration<double>>(end - start);

    //display time taken and #of primes
	cout << "Info: Time:  " << time_span.count() << endl;
	cout << "Info: Primes: " << numbers.size() << endl;

    //wait for input
	system("pause");
	cout << endl;

    //display primes
	for (unsigned int i = 0; i <= numbers.size() - 1; ++i)
	{
        //print prime with which prime
		cout << "Info: Prime[" << i+1 << "]: " << numbers[i] << endl;
	}

    //wait to close
	system("pause");
}

