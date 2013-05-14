#Extensions
Horribly misnamed, this solution started out as a library for sharing C# extension methods between projects.

It then became the container for my `JamesDibble.Application` namespace that defines my little application framework.
___
##Application Framework
The `Application` project is my attempt at an application management framework.  Essentially, it is a static wrapper for access to essential functions from within the various layers of a system such as persistence, logging and configuration.  It is by no means perfect and it creates some interesting design decisions as it can lead to persistence being accessible from presentation layers if not configured properly.

It uses Microsofts [Managed Extensibility Framework (MEF)](http://mef.codeplex.com/) as an IOC so that types can be resolved using the `[Export]` attribute.  Most of the namespaces within the project contain interfaces to build domain specific implementations of each "Manager".  The other projects provide implementations of some of those managers that I have shared between applications.  At some point I will create some more extensive documentation on each of these.

##Building the Solution
All the projects will require you to reference MEF by downloading the latest version from the Codeplex Site, unless building the solution using .Net 4.5.

The `Data` project will require a local reference to the Entity Framework as I delpoy to a shared hosting provider, I build my web projects with pretty much everything that isn't part of the core .Net Framework.