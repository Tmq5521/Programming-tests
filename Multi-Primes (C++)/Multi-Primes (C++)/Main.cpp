#pragma once
#define DEBUG_LEVEL 10

#include "Thread.cpp"

#include <iostream>
#include <windows.h>
#include <cmath>

#include <vector>
#include <deque>

#include <thread>
#include <chrono>

int main()
{
    //error logging
    tqLogging::outputLog log;
    //log.output_stream[0].push_back("Hello World");
    log.printThread();

    return 0;
}

