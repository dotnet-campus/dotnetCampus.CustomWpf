# 私有发布的 WPF 仓库

这个仓库包含了官方没有合入的功能

## 给开发者

本仓库当前固定 dotnet 版本号，用来解决引用依赖问题。如有升级 dotnet runtime 版本，请同步更改 global.json 的 sdk 版本号，以及 `.github\workflows\` 里面的构建代码的安装版本号