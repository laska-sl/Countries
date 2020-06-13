## Start the project in Production Mode

##### Requirements
1. .NET Core

#### 1. Attach the database 
* Attach the database from **Countries.Database** folder to SQL Server
or
* Change connection string in *appsetting.json* file in **Countries.API** folder

#### 2.  Start the project
1. Open terminal under the project folder
2. `cd Countries.API`
3. `dotnet run` or `dotnet watch run`

Or open .sln file in Visual Studio and run project



## Start the project in Development Mode

##### Requirements
1. .NET Core
2. NodeJS

#### 1. Attach the database 
* Attach the database from **Countries.Database** folder to SQL Server
or
* Change connection string in *appsetting.json* file in **Countries.API** folder

#### 2.  Start the backend
1. Open terminal under the project folder
2. `cd Countries.API`
3. `dotnet run` or `dotnet watch run`

Or open .sln file in Visual Studio and run project
#### 3. Start frontend
1. Open terminal under the project folder
2. `cd Countries-SPA`
3. `npm install`
4. `npm start`
5. Navigate to [http://localhost:4200/](http://localhost:4200/)
