@ECHO OFF
SET /P _inputplugintype=Choose a type of plugin to create (GenericPlugin, LibraryPlugin, or MetadataPlugin): 
GOTO name

:name
SET /P _inputpluginname=Project Name: 
GOTO create

:create
ECHO Creating a new %_inputplugintype% project ("%_inputpluginname%") at %CD%.
Toolbox.exe new "%_inputplugintype%" "%_inputpluginname%" "%CD%"
pause
