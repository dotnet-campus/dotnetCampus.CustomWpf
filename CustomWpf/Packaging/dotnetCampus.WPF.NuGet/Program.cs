using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dotnetCampus.Configurations;
using dotnetCampus.DotNETBuild.Utils;

namespace dotnetCampus.WPF.NuGet;

// 这个项目现在完全没有被用上
// 不删除，后续需要再发布 x64 版本
internal class Program
{
    public static void Main(string[] args)
    {
        MainTask mainTask = new MainTask();
        mainTask.Run();
    }
}
