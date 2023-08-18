-----Full tutorial------
https://leidos.udemy.com/course/build-rest-apis-with-aspnet-core-web-api-entity-framework

//Information is gathered from the db context to create c# classes which will act as sql tables --> c# will convert to sql tables

Add-Migration "Name of Migration"

//Now run the Migration to Update the database of any missing tables doing: 

Update-Database

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

View, Other Windows, C# interactive console to generate things like guid etc

--------------------------------------