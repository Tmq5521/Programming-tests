#pragma once

//sets my Debug level in my code
#ifndef DEBUG_LEVEL
 #define DEBUG_LEVEL 4
#else
 #if DEBUG_LEVEL > 4
  #define DEBUG_LEVEL 4
 #endif
#endif

//DEBUG_LEVEL
//0 - No log
//1 - Info Level
//2 - Fine Level
//3 - Warnning Level
//4 - Error Level

#include <iostream>
#include <vector>
#include <deque>
#include <thread>
#include <chrono>


namespace tqLogging 
{
    class outputLog
    {
    private:  //io vector
        std::vector< std::deque< std::string > > output_stream;
    private: //channel vector
        std::vector< std::string > levels = { "", "Info: ", "Fine: ", "Warning: ", "Error: " };

    public:
        outputLog()
        {
            //io vector message levels
            for (unsigned long long int i = 0; i <= DEBUG_LEVEL; i++)
                output_stream.push_back(std::deque< std::string >(1));
        }
    
    public:
        void printThread()
        {
            //while (true)
            do
            {
                for (int i = 0; i <= DEBUG_LEVEL; i++)
                {
                    for (int size = 0; size <= output_stream[i].size() - 1; size++)
                    {
                        std::cout << levels[i].c_str() << output_stream[i][0].c_str() << std::endl;
                        output_stream[i].pop_front();
                    }

                }
            } while (false);
        }
    };

};

