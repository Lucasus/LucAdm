### Administration module reference project
This project is a reference for technologies, architecture and best practices used by me. Because of this, currently there is a lot of infrastructure code here, but with not many real features implemented.

##### Technologies used

* **Core**: Entity Framework 6.0, Fluent Validation  
* **Web**: ASP.NET Web API 2.0, Castle Windsor, AutoMapper, 
* **Client**: AngularJS 1.2, Bootstrap 3.0, Angular-Bootstrap 1.2
* **Tests**: xUnit 2.0, NSubstitute, Fluent Assertions, Selenium

##### Installation prequisites

* Visual Studio 2013 installed (not tested on earlier editions),
* Sql Server 2014 Express installed (not tested on earlier editions)
* npm and git installed,
* Selenium server + chrome driver installed (required to run acceptance tests),
* Paths to npm and git in the PATH environment variable,
* Path to MSBuild in MSBUILD_PATH environment variable (required to run acceptance tests)

##### This is how main view currently looks like

![alt tag](https://github.com/Lucasus/LucAdm/blob/master/Docs/main-view.png)
