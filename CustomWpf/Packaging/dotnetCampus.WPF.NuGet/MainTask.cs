using System.Reflection;

using dotnetCampus.Configurations;
using dotnetCampus.DotNETBuild.Context;
using dotnetCampus.DotNETBuild.Utils;
using dotnetCampus.GitCommand;

namespace dotnetCampus.WPF.NuGet;

class MainTask
{
    public void Run()
    {
        var appConfigurator = AppConfigurator.GetAppConfigurator();
        FileSniff fileSniff = new FileSniff(appConfigurator);
        fileSniff.Sniff();

        // 重新寻找 CustomWpf.sln 所在文件夹
        var slnFolder = FindDirectoryByFile(new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!), "CustomWpf.sln")!;

        var compileConfiguration = appConfigurator.Of<CompileConfiguration>();
        
        Git git = new Git(new DirectoryInfo(compileConfiguration.CodeDirectory));
        var currentCommit = git.GetCurrentCommit();

        // 找到 Version 版本号文件
        var versionFile = Path.Combine(slnFolder.FullName, @"build\Version.props");

    }

    /// <summary>
    /// 向上寻找到存在某个文件名的文件夹
    /// </summary>
    /// <param name="currentDirectory"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private static DirectoryInfo FindDirectoryByFile(DirectoryInfo currentDirectory, string fileName)
    {
        var directory = currentDirectory;
        while (directory != null)
        {
            var file = Path.Combine(directory.FullName, fileName);
            if (File.Exists(file))
            {
                return directory;
            }
            else
            {
                directory = directory.Parent;
            }
        }

        throw new ArgumentException($"Can not find any Directory. CurrentDirectory =\"{currentDirectory}\";FileName=\"{fileName}\"");
    }
}
