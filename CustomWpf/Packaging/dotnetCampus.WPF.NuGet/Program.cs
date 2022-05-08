using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dotnetCampus.Configurations;
using dotnetCampus.DotNETBuild.Utils;

namespace dotnetCampus.WPF.NuGet;

internal class Program
{
    public static void Main(string[] args)
    {
        MainTask mainTask = new MainTask();
        mainTask.Run();
    }
}
