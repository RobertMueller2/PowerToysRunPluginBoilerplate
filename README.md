# Boilerplate plugin for PowerToys Run

This is a plugin for [PowerToys Run](https://learn.microsoft.com/windows/powertoys/run) that allows to copy text from text files located in `%localappdata%\Boilerplate`. My use case is to provide quick access to frequently used text snippets ("boilerplate"), such as "Best regards, NAME" e.g. for use in emails in order to save some typing.

![image](/images/Screenshot_2023-12-22_162250.png)

## Limitations, TODOs and potential ideas for the future

The plugin contains the bare minimum code to make it work. I don't know how much I'm going to work on this in the future. Feel free to just use this as reference if it's useful.

- Currently, there is no file extension or file content plausibility check
- I believe the action prefix `##` I am using is free, but I have not spent too much effort with research ;)
- There is no localisation
- The search is done against the filenames, not the content
- File system limitations apply, e.g. if you had a few thousand text files, it might be slow
- Instead of just using flat files, a config file could provide keys and content or even locations to look for flat files, but scanning for changes and dealing with errors adds complexity
- Instead of just copying the text, e.g. `SendInput` via P/Invoke could be used to type the text or trigger Paste. I feel this is more useful once a configuration file is possible, because delays might have different sweet spots depending on user and/or environment
- I was too lazy to remove the `.pdb` files from the release package

## Usage

- Follow install instructions
- Open PowerToys Run
- Place some text files in `%localappdata%\Boilerplate`
- Type `##`, optionally followed by search for filename
- Press enter to copy the selected file's content to clipboard

## Install

Use one of the releases and copy the archive content to `%localappdata\PowerToys\RunPlugins\BoilerplateText`.

Please note, if you are updating, and if you have just PowerToys Run, you may have to exit PowerToys because otherwise the files may be in use.

Or you could follow the build instructions, build with Release configuration and copy the plugin from the release folder.

## Build

Before you do this, make sure you have sufficient disk space. I had to resize my VM disk twice. My PowerToys folder now contains almost 90 GiB with both Debug and Release config. :p

- Clone [PowerToys](https://github.com/microsoft/PowerToys)
- if you're worried about working with upstream changes, you could fork it and rebase as needed
- `cd <powertoys repository>\src\modules\launcher\Plugins`
- `git submodule add https://github.com/RobertMueller2/PowerToysRunPluginBoilerplate.git`
- Add the newly added submodules .csproj file as project to the solution
- if you want to try it, you could build the solution with debug config and launch the PowerLauncher subproject, it should automatically load the Boilerplate plugin. Otherwise, build release config.

## Other remarks

This was helpful for me to understand how to create a module for PowerToys Run, as well as test and build it:

- [How to create a PowerToys Run plugin](https://senpai.club/how-to-create-a-powertoys-run-plugin/)
- [Winget plugin for PowerToys Run](https://github.com/bostrot/PowerToysRunPluginWinget)

