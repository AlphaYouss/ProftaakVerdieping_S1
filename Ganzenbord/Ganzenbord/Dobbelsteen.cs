using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class Dobbelsteen
    {
        public int worpTotaal { get; private set; }

        public int XD6(int X)
        {
            for (int i = 1; i < X; i++)
            {
            Random rnd = new Random();
            int worp = rnd.Next(1, 7);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD2(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 3);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD3(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 4);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD4(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 5);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD8(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 8);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD10(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 11);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD12(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 13);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD16(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 17);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD20(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 21);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public  int XD30(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 31);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public int XD100(int X)
        {
            for (int i = 1; i < X; i++)
            {
                Random rnd = new Random();
                int worp = rnd.Next(1, 101);
                worpTotaal = worpTotaal + worp;
            }
            return worpTotaal;
        }

        public void ResetWorp()
        {
            worpTotaal = 0;
        }
    }
}
