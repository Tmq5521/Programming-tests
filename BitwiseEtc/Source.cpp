#include <iostream>
#include <stdio.h>
#include <vector>
#include <deque>

using namespace std;

void bitPrint(unsigned long long int);
unsigned long long int readLineBinChar();
void writeLineBinChar(unsigned long long int);

void main()
{
    unsigned long long int a, b, c, d;
    unsigned long long int key;

    a = 0xfbaeacdbabcdefce;
    b = 0xdc49592112bc93af;
    c = 0xacbfa4d1f3492dce;
    d = readLineBinChar();
   
    key = a ^ b ^ c ^ d;

    bitPrint(a);
    bitPrint(b);
    bitPrint(c);
    bitPrint(d);
    bitPrint(key);

    writeLineBinChar(a^b^c^key);


    system("pause");
}

void bitPrint(unsigned long long int bits)
{
    cout << bits << " (bin:)";
    for(;bits; bits = bits >> 1)
    {
        cout << (bits & 1);
    }
    cout << endl;
}

unsigned long long int readLineBinChar()
{
    unsigned long long int bits = 0x00;
    unsigned long long int c = 0x00;
    do
    {
        c = getchar();
        bits += (unsigned long long int)c;
        bits = bits << 8;
    } while (c != '\n');

    return bits;
}

void writeLineBinChar(unsigned long long int bits)
{
    deque<char> stream;
    while (bits)
    {
        stream.push_front((char)(bits & 0xff));
        bits = bits >> 8;
    }
    for (unsigned short i = 0; i < stream.size(); i++)
    {
        cout << stream.front();
        stream.pop_front();
    }
    cout << endl;
}