[![Ânkh-CI](https://github.com/NY-Daystar/ankh/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/NY-Daystar/Ankh/actions/workflows/dotnet.yml)
![License](https://img.shields.io/github/license/ny-daystar/Ankh)
[![Version](https://img.shields.io/github/tag/NY-Daystar/ankh.svg)](https://github.com/NY-Daystar/Ankh/releases)
[![Total views](https://img.shields.io/sourcegraph/rrc/github.com/NY-Daystar/ankh.svg)](https://sourcegraph.com/github.com/NY-Daystar/ankh)

![GitHub watchers](https://img.shields.io/github/watchers/ny-daystar/ankh)
![GitHub forks](https://img.shields.io/github/forks/ny-daystar/ankh)
![GitHub Repo stars](https://img.shields.io/github/stars/ny-daystar/ankh)
![GitHub repo size](https://img.shields.io/github/repo-size/ny-daystar/ankh)
![GitHub language count](https://img.shields.io/github/languages/count/ny-daystar/ankh)
![GitHub top language](https://img.shields.io/github/languages/top/ny-daystar/ankh)

![GitHub commit activity (branch)](https://img.shields.io/github/commit-activity/m/ny-daystar/ankh/develop)
![GitHub issues](https://img.shields.io/github/issues/ny-daystar/Ankh)
![GitHub closed issues](https://img.shields.io/github/issues-closed-raw/ny-daystar/Ankh)
[![All Contributors](https://img.shields.io/badge/all_contributors-1-blue.svg?style=circular)](#contributors)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

# Ânkh

C# project to rename every files in folder quickly.

Source code analysed with [DeepSource](https://deepsource.com/)

[Installation Setup realize with this tutorial](https://gaby277.developpez.com/Tutoriels/VisualStudioInstallerProject/)

## Summary

-   [Requirements](#requirements)
-   [How to use](#how-to-use)
-   [Setup project](#setup-project)
-   [Contact](#contact)
-   [Credits](#credits)

## Requirements

-   [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) >= 7.0
-   For developpment: [VS 2022](https://visualstudio.microsoft.com/fr/vs/) >= 2022
-   Packages to install
    -   [ConsoleTables](https://www.nuget.org/packages/ConsoleTables/2.4.2?_src=template)

## How to use

1. Download Ankh project from [this link](https://github.com/NY-Daystar/Ankh/releases/download/v1.0.0/Ankh.v1.0.zip)

2. Extract zip on your computer

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

3. Launch `Ânkh.exe` - The project ask you to choose a folder in your computer to rename files. - It will list folder files and submit several renaming. - After choosing one the application rename files automatically

![Ânkh program](./Assets/Ankh%20program.png)

## Setup project

1. Clone repository

```bash
$ git clone git@github.com:NY-Daystar/Ankh.git
```

2. Open VS 2022 -> `Open project or solution`
3. Select `Ankh.sln`
4. Rebuild solution
5. F5 to launch project in Debug mode

## For developpers

You can activate git hooks with this command

```bash
git config --global core.hooksPath .githooks
```

## Contact

-   To make a pull request: https://github.com/NY-Daystar/ankh/pulls
-   To summon an issue: https://github.com/NY-Daystar/ankh/issues
-   For any specific demand by mail: [luc4snoga@gmail.com](mailto:luc4snoga@gmail.com?subject=[GitHub]%ankh%20Project)

## Credits

Made by Lucas Noga.  
Licensed under GPLv3.
