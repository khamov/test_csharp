using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestApp
{
    public class Calc
    {
        virtual public int Sum(int a, int b)
        {
            return a + b;
        }

        virtual public int VersionNumber()
        {
            return 0;
        }
    }
}
