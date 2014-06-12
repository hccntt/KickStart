#KickStart

Application start-up helper to initialize things like an IoC container, register mapping information or run a task.

[![Build status](https://ci.appveyor.com/api/projects/status/lk092y48a2b9f8ys)](https://ci.appveyor.com/project/LoreSoft/kickstart)

##Download

The KickStart library is available on nuget.org via package name `KickStart`.

To install KickStart, run the following command in the Package Manager Console

    PM> Install-Package KickStart
    
More information about NuGet package avaliable at
<https://nuget.org/packages/KickStart>

##Development Builds


Development builds are available on the myget.org feed.  A development build is promoted to the main NuGet feed when it's determined to be stable. 

In your Package Manager settings add the following package source for development builds:
<http://www.myget.org/F/loresoft/>

##Features

- Run tasks on application start-up
- Extension model to add library specific start up tasks
- Common IoC container adaptor
- Sigleton instance of an application level IoC container


##Example

This example will scan the assembly containing UserModule.  Then it will find all Autofac modules and register them with Autofac.  Then, all AutoMapper profiles will be registered with Automapper. Finally, it will find all classes that implement `IStartupTask` and run it. 

    Kick.Start(config => config
        .IncludeAssemblyFor<UserModule>()
        .UseAutofac()
        .UseAutoMapper()
        .UseStartupTask()
        .LogLevel(TraceLevel.Verbose)
    );

##Extensions

- StartupTask - Run any class that implements `IStartupTask`
- Autofac - Registers all Autofac `Module` classes and creates the container
- AutoMapper - Registers all AutoMapper `Profile` classes
- MongoDB - Registers all `BsonClassMap` classes with MongoDB serialization.
- Ninject - Registers all `NinjectModule` classes and creates an `IKernal`.
- SimpleInjector - Run all `ISimpleInjectorRegistration` instances allowing container registration
- Unity - Run all `IUnityRegistration` instances allowing container registration

###StartupTask

The StartupTask extension allows running code on application start-up. To use this extension, implement the `IStartupTask` interface. Use the Priority property to control the order of execution.


Basic usage

    Kick.Start(config => config
        .IncludeAssemblyFor<UserModule>() // where to look for tasks
        .UseStartupTask() // include startup tasks in the Kick Start        
    );

Use the Common Container to resolve startup tasks

    Kick.Start(config => config
        .IncludeAssemblyFor<UserModule>()
        .UseAutofac() // init Autofac or any other IoC as container
        .UseStartupTask(c => c.UseContainer()) // config to use the shared container
    );

###Autofac

The Autofac extension allows registration of types to be resolved.  The extension also creates a default container and sets it to the `Kick.Container` singleton for access later.

Basic usage

    Kick.Start(config => config
        .IncludeAssemblyFor<UserRepository>() // where to look for tasks
        .UseAutofac() // initialize Autofac        
    );

To install Autofac extension, run the following command in the Package Manager Console

    PM> Install-Package KickStart.Autofac

###SimpleInjector 

The SimpleInjector extension allows registration of types to be resolved by running all instances of `ISimpleInjectorRegistration`.  The extension also creates a default container and sets it to the `Kick.Container` singleton for access later.

Basic usage

    Kick.Start(config => config
        .IncludeAssemblyFor<UserRepository>() // where to look
        .UseSimpleInjector () // initialize SimpleInjector         
    );

To install SimpleInjector extension, run the following command in the Package Manager Console

    PM> Install-Package KickStart.SimpleInjector

###Unity 

The Unity extension allows registration of types to be resolved by running all instances of `IUnityRegistration`.  The extension also creates a default container and sets it to the `Kick.Container` singleton for access later.

Basic usage

    Kick.Start(config => config
        .IncludeAssemblyFor<UserRepository>() // where to look
        .UseUnity () // initialize Unity         
    );

To install Unity extension, run the following command in the Package Manager Console

    PM> Install-Package KickStart.Unity

