using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Ball
    {
        public int[] Pos = new int[2]; // x,y
        public int[] Vel = new int[2]; // x,y
        public char Char = 'o';
        public bool score = false;
        public Paddle Last;

        public Ball( int x, int y, int vx, int vy)
        {
            Pos[0] = x;
            Pos[1] = y;
            Vel[0] = vx;
            Vel[1] = vy;
        }
    }

    class Paddle
    {
        public int[] Pos = new int[2]; // x,y
        public int Size;
        public char Char = '|';
        public char[] Keys = new char[2]; // up,down

        public Paddle (int x, int y, int size, char key1, char key2)
        {
            Pos[0] = x;
            Pos[1] = y;
            Size = size;
            Keys[0] = key1;
            Keys[1] = key2;
        }
    }

    class Program
    {
        static void BounceY(Ball b1)
        {
            if (b1.Pos[1] >= Console.WindowTop || b1.Pos[1] <= 0)
                b1.Vel[1] = -b1.Vel[1];
        }

        static void BounceX(Paddle p1, Ball b1)
        {
            if ((b1.Pos[1] <= p1.Pos[1] && b1.Pos[1] >= p1.Pos[1] - p1.Size) && (p1.Pos[0] >= b1.Pos[0] - (b1.Vel[0] + 1)   && p1.Pos[0] <= b1.Pos[0] + b1.Vel[0]))
            {
                b1.Vel[0] = -b1.Vel[0];
                b1.Last = p1;
            }
        }

        static void DrawB(Ball b1)
        {
            try
            {
                Console.SetCursorPosition(b1.Pos[0], b1.Pos[1]);
                Console.Write(b1.Char);
            }
            catch
            {
                b1.Pos[0] = -b1.Pos[0];
            }
        }

        static void MoveB(Ball b1)
        {
            b1.Pos[0] = b1.Pos[0] + b1.Vel[0];
            b1.Pos[1] = b1.Pos[1] + b1.Vel[1];

            if (b1.Pos[0] <= 0 || b1.Pos[0] >= Console.WindowWidth)
                b1.score = true;
        }

        static void DrawP(Paddle p1)
        {
            for (int i = 0; i <= p1.Size; i++)
            {
                try
                {
                    Console.SetCursorPosition(p1.Pos[0], p1.Pos[1] - i);
                    Console.Write(p1.Char);
                }
                catch { }
            }
        }




        static void Main(string[] args)
        {
            Console.Title = "Pong";
            bool end = true;

            Console.ReadKey();

            Ball[] b1 = new Ball[5];
            b1[0] = new Ball(10, 0, 1, 0);
            b1[1] = new Ball(10, 1, 2, 0);
            b1[2] = new Ball(10, 2, 3, 0);
            b1[3] = new Ball(10, 3, 4, 0);
            b1[4] = new Ball(10, 4, 5, 0);


            Paddle[] p1 = new Paddle[2];
            p1[0] = new Paddle(1, 5, 4, 'w', 's');
            p1[1] = new Paddle(100, 5, 4, 'i', 'k');

            while (end)
            {
                Console.Clear();

                foreach (Ball b in b1)
                {
                    foreach(Paddle p in p1)
                    {
                        DrawP(p);
                        BounceX( p, b);
                    }
                    BounceY(b);
                    MoveB(b);
                    DrawB(b);
                    if (b.score)
                        end = false;
                }
                
            }
            Console.ReadKey();
        }
    }
}
