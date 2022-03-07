# hello-windows-service
Windows service that says hello world and is attached to an installer project that allows to install/remove/update the program

## Dependencies
* NetFramework 4.8
* That's all for now

## What to learn
* Windows services workflow
* Visual Studio Installer Projects
* Event logs
* Timers
* Releases with GitHub
* Adding Jenkins integration *-new-*

## Documentation
* https://docs.microsoft.com/en-us/dotnet/framework/windows-services/

## Commands


### Command Prompt

Go to the directory that contains the program and executes this line of code.

**Install**

```
installutil HelloService.exe
```

**Uninstall**
```
installutil /u HelloService.exe
```


### Powershell
