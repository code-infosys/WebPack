# WebPack
WebPack create new helper for create your private or publick nuage package and host on git.

Create New private Package on Github

1. Go to github account >> Open Setting >> Developer setting >> Personal access tokens 
 ------Given note name and check scopes >> repo all, write: package, read: package.   and click to generate token.
 ------and copy your token in safe place.
2. First create new Class library project
 ------this project should have nuget.config file, create like below.
  <?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <clear />
        <add key="github" value="https://nuget.pkg.github.com/<GitUserName>/index.json" />
    </packageSources>
    <packageSourceCredentials>
        <github>
            <add key="Username" value="<GitUserName>" />
            <add key="ClearTextPassword" value="PasteYourTokenHere" />
        </github>
    </packageSourceCredentials>
</configuration>

 ------right-click on your project and edit the project file and add below tags.
    <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <PackageId>YourProjectName</PackageId>
    <Version>1.0.0</Version>
    <Authors>Author Name</Authors>
    <Company>CompanyName</Company>
    <PackageDescription>This package adds a YourProjectName</PackageDescription>
    <RepositoryUrl>https://github.com/<GitUserName>/<YourRepositoryName>/</RepositoryUrl>
  </PropertyGroup>

 ------this project should have the main method (otherwise pack failed)
 ------write you methods here which you want to expose.
 ------push your latest code on GitHub repository.
 ------right-click on project >> Open folder in file explorer.
 ------open cmd prompt here. run below commands here one by one.
    dotnet pack --configuration Release 
    dotnet nuget push "bin/Release/YourProjectName.1.0.0.nupkg" --source "github"
  --if in last command having error like ___setApiKey___ then run these commands first
    nuget source Add -Name "GitHub"  -Source "https://nuget.pkg.github.com/<GitUserName>/index.json"
    nuget setApiKey $TOKEN  -Source "https://nuget.pkg.github.com/<GitUserName>/index.json"
  --then try again with 
     dotnet nuget push "bin/Release/YourProjectName.1.0.0.nupkg" --source "github"


3. where you want to install your package go on that project.
 ------right-click project open Manage Nuget Packages... 
 ------Go in setting and + add new Available package source.
 ------provide Name of Package and Source=https://nuget.pkg.github.com/<GitUserName>/index.json
 ------and save it.
 ------when the first time you will select this package source, it will be asking for authentication username and password, fill up your username and password = Token (which you already created above on GitHub)
 ------next time all package will be available.

___________
use this command for update credentical for you private nuget packages
nuget.exe sources update -Name "PackageName" -Username YouUserName -Password YourGeneratedPasswordToken
