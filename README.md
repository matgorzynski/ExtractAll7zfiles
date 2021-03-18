# ExtractAll7zfiles

7zip extracter, can be use to unzip all 7z files in folder and all subfolder.

### HowToUse

`release` folder contains necessary files to use program.

`app.config` file have two value:
    - `RootFolder` - is a path to root folder, when are archive files is located.
    Replace `PathToFolder` to folder, ex.
    | C:/users/someUser/files
    - `DeleteExtractedFiles` - this option responsible to give information to program, when after extract files, program should delete 7z archive. This flag have to option:
    | True - delete 7z file, after extract
    | False - only extract

Which all settings is prepared and putted in app.config, run `7zFilesExtracter.exe`. Program running console and write extract information to runned console.

Enjoy.