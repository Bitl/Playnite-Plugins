@ECHO OFF
CLS
SET ClassName="GenericPlugin"
SET /P _inputplugintype= Choose a type of plugin to create (Generic, Library, or Metadata):
IF "%_inputplugintype%"=="Generic" SET "%ClassName%"="GenericPlugin"
IF "%_inputplugintype%"=="Generic" GOTO name
IF "%_inputplugintype%"=="Library" SET "%ClassName%"="LibraryPlugin"
IF "%_inputplugintype%"=="Library" GOTO name
IF "%_inputplugintype%"=="Metadata" SET "%ClassName%"="MetadataPlugin"
IF "%_inputplugintype%"=="Metadata" GOTO name

:name
CLS
SET /P _inputpluginname=Project Name:
GOTO create

:create
CLS
ECHO Creating a new %ClassName% project ("%_inputpluginname%") at %CD%.
Toolbox.exe new %ClassName% "%_inputpluginname%" "%CD%"
pause
