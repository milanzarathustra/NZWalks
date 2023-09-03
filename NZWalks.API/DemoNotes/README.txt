Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

Automapper
Automapper.Extensions.Microsoft.DependencyInjection

Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.IdentityModel.Tokens
System.IdentityModel.Tokens.Jwt
Microsoft.AspNetCore.Identity.EntityFrameworkCore


-----Full tutorial------
https://leidos.udemy.com/course/build-rest-apis-with-aspnet-core-web-api-entity-framework

//Information is gathered from the db context to create c# classes which will act as sql tables --> c# will convert to sql tables

Add-Migration "Name of Migration"

//Now run the Migration to Update the database of any missing tables doing: 

Update-Database

//ALTERNATIVE: If you have multiple db contexts then you have to do:

Add-Migration "Name of Migration -Context "Name of DB Context in Data folder"

//Same applies to update database

Update-Database -Context "Name of DB Context in Data folder"

-----------------------------------------

When Creating Controller make sure to choose Empty API Controller. Naming of controller must be suffixed with PluralOfClassController i.e RegionsController

--------------------------------

Auto Mapper

Install Auto Mapper Package NuGet + Install the Dependancy Injection one as well

Usage: CreateMap<UserDTO, UserDomain>() to map these classes and use .ReverseMap() in the end to allow vice versa 

if you want to map where properties are diffirent usage would be:

CreateMap<UserDTO, UserDomain>()
	.ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName))
	.ReverseMap

---------------------------------------

View, Other Windows, C# interactive console to generate things like guid etc -- Guid.NewGuid()

--------------------------------------

TODO After end of tutorial

migrate to another db instead of sql - find out what AWS cheaper ones are with security and backups possibly mongo db and obviously something that supports EF CORE

learn how to Encapsulate the things in the controller to the a seperate class like a command? 

Add forgot password and reset password

Instead of having images in local folder, store them as blob in db OR AWS FILE Image thing - Image and Video Uploading 

Add Tests to everything we currently have, testing controllers and repositories

Use enums for type such as roles/permissions

Once created a script for packages needed and renamed project setup and create aws account