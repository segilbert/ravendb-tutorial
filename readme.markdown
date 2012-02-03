First and foremost you need to have a RavenDB server running. For the simplest setup you can just go into \packages\RavenDB.1.0.573\server\ folder in the solution and run Raven.Server.exe and keep it running. Or you can issue 'Raven.Server.exe /install' command to install it as a service. You won't have to remember to start it up in order to work with Raven and for me this is the preferred way of working.

With Raven running you might want to take a look at a folder you clone from GitHub containing four project directories:

+ Geekbeing.Blog.RavenDb.Tutorial.Lib - where model definitions are kept, to be reused in other projects
+ Geekbeing.Blog.RavenDb.Tutorial.Initializer - *start with this one* - set it up as a StartUp Project in Visual Studio and run. This will create and populate database with records we will be working on in this tutorial
+ Geekbeing.Blog.RavenDb.Tutorial.Querying - examples on basic queries that might be run with RavenDB
+ Geekbeing.Blog.RavenDb.Tutorial.Web - small ASP .NET MVC 3 application with more code examples on how to implement certain functionalities with Raven.

Should you have problems running the examples - don't hesitate contacting me - either via e-mail or comments on the blog.