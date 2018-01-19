#include <iostream>
#include <stdio.h>
#include <vector>
#include <deque>

using namespace std;

void bitPrint(unsigned int);
unsigned int readLineBinChar();
void writeLineBinChar(unsigned int);

void main()
{
    unsigned int a, b, c, d;
    unsigned int key;

    a = 0xfbaeacdb;
    b = 0xdc495921;
    c = 0xacbfa4d1;
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

void bitPrint(unsigned int bits)
{
    cout << bits << " (bin:)";
    for(;bits; bits = bits >> 1)
    {
        cout << (bits & 1);
    }
    cout << endl;
}

unsigned int readLineBinChar()
{
    unsigned int bits = 0x00;
    unsigned int c = 0x00;
    do
    {
        c = getchar();
        bits += (unsigned int)c;
        bits = bits << 8;
    } while (c != '\n');

    return bits;
}

void writeLineBinChar(unsigned int bits)
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