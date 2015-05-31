using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Plugin
{
    public interface IPlugin
    {
        string GetName();
        double Execute(double a, double b);
    }
}