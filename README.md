# Ânkh

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/ae9278e5d7714c948665b1e10f238992)](https://app.codacy.com/gh/NY-Daystar/Ankh/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![Ânkh-CI](https://github.com/NY-Daystar/ankh/actions/workflows/dotnet.yml/badge.svg)](https://github.com/NY-Daystar/ankh/actions/workflows/dotnet.yml) [![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0) [![Version](https://img.shields.io/github/tag/NY-Daystar/ankh.svg)](https://github.com/NY-Daystar/ankh/releases)

![GitHub repo size](https://img.shields.io/github/repo-size/ny-daystar/ankh) ![GitHub language count](https://img.shields.io/github/languages/count/ny-daystar/ankh) ![GitHub top language](https://img.shields.io/github/languages/top/ny-daystar/ankh)

![GitHub issues](https://img.shields.io/github/issues/ny-daystar/ankh) ![GitHub closed issues](https://img.shields.io/github/issues-closed-raw/ny-daystar/ankh) ![GitHub commit activity (branch)](https://img.shields.io/github/commit-activity/m/ny-daystar/ankh/main) ![All Contributors](https://img.shields.io/badge/all_contributors-1-blue.svg?style=circular)

![GitHub watchers](https://img.shields.io/github/watchers/ny-daystar/ankh) ![GitHub forks](https://img.shields.io/github/forks/ny-daystar/ankh) ![GitHub Repo stars](https://img.shields.io/github/stars/ny-daystar/ankh)

**Version: v1.2.0**

C# project to rename every files in folder quickly.  
Source code analysed with [DeepSource](https://deepsource.com/) and [Codacy](https://app.codacy.com)

![Ânkh program](./Assets/Ankh%20program.png)

## Summary

- [Requirements](#requirements)
- [How to use](#how-to-use)
- [For developpers](#for-developpers)
    - [Activate hook](#activate-hook)
    - [Create MSI](#create-msi)
- [Contact](#contact)
- [Credits](#credits)

## Requirements

- [.NET Framework / .NET 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) >= .NET 10
- [VS 2026](https://visualstudio.microsoft.com/fr/vs/)
- Packages to install
    - [ConsoleTables](https://www.nuget.org/packages/ConsoleTables/2.7.0?_src=template)

## How to use

1. Download Ankh project from [this link](https://github.com/NY-Daystar/Ankh/releases/download/v1.2.0/AnkhSetup.msi)
    > If not working you can download [portable version](https://github.com/NY-Daystar/Ankh/releases/download/v1.2.0/AnkhPortable.zip)
2. Install .msi file
3. Launch `Ânkh.exe` - The project ask you to choose a folder in your computer to rename files. - It will list folder files and submit several renaming. - After choosing one the application rename files automatically

![Ânkh program](./Assets/Ankh%20program.png)

    > Let's say you want to numerate files from a folder in a numeric order
    > Example:

    ```
    One.Piece.S01E001.VOSTFR.DVDRip.x264.mp4
    One.Piece.S01E002.VOSTFR.DVDRip.x264.mp4
    One.Piece.S01E003.VOSTFR.DVDRip.x264.mp4
    ...
    ```

    And you want

    ```
    One Piece S01E1.mp4
    One Piece S01E2.mp4
    One Piece S01E3.mp4
    ...
    ```

## For developpers

1. Clone repository

```bash
$ git clone git@github.com:NY-Daystar/Ankh.git
```

2. Open VS 2022 -> `Open project or solution`
3. Select `Ankh.sln`
4. Rebuild solution
5. F5 to launch project in Debug mode

### Activate hook

You can activate git hooks with this command

```bash
git config --global core.hooksPath .githooks
```

#### Create MSI

1. Add executable in Setup Project
    - Right click in `Setup project`
    - View > File System
    - Right click in `Application folder`
    - Add > Project Output
    - Choose `Primary Output`

2. Create shortcut
    - Right click on `Primary Output`
    - Create Shortcut
    - Rename it
    - Drag into `User’s Desktop` or `User’s Programs Menu`

3. Configuration
    - Go into Setup's property and change
    - `ProductName` : Name of the application
    - `Manufacturer` : Name of the company
    - `InstallAllUsers`: True
    - `InstallScope` : perMachine
    - `RemovePreviousVersions` : True
    - `Version` : 1.0.0

## Contact

- To make a pull request: https://github.com/NY-Daystar/ankh/pulls
- To summon an issue: https://github.com/NY-Daystar/ankh/issues
- For any specific demand by mail: [luc4snoga@gmail.com](mailto:luc4snoga@gmail.com?subject=[GitHub]%ankh%20Project)

## Credits

Made by Lucas Noga.  
Licensed under GPLv3.
