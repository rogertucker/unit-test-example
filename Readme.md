## Introduction
<p>This project is intended to be a simple web api used to demonstrate how one might develop an n-tier web application using Entity Framework as an ORM.  One of the main focuses of the application is to demonstrate project structure and good use of unit testing practices.  The application is divided into threes layers with self-explanitory names: DBLayer, ServiceLayer, ViewLayer.  Each layer has an associated "src" folder containing all of the source code and a "test" folder which contains associated unit testing for that layer.
</p>  

### DBLayer
<p>The DBLayer contains the framework used to connect to a SQL Server database using Entity Framework.  The models consist of a User and associated Addresses and PhoneNumbers"  The database can be access via set of "Repository" objects.  Each Repository object extends a BaseRepository object which contains boilplate database functionality: GetById, Create, Delete, etc...  Model specific repository functionality can be added to each model specific repository<p>

```
namespace DBLayer.Repositories{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExampleDbContext context) : base(context, context.Users)
        {
        }

        public User GetUserByLastName(string name)
        {
            return (from u in DataSet where u.LastName == name select u).SingleOrDefault();
        }
    }
}

```

#### DBContext Design Time Functionality
<p>In order to keep the Migration and update functionality isolated to the DBLayer an implementation of</p>

    DesignTimeDbContextFactory

<p>is included in DBContextFactory.cs. This allows the EntityFramework code and DBContext to be isolated to the DBLayer</p>



### ServiceLayer
<p>The intent of the service layer is to encapsulate business functionality.  For instance objects might need to be manipulated of calculations performed prior to creating or updating a database record.  In this simple application the service layer simply makes a call to the DBLayer to perfrom the requested CRUD operation</p>

### ViewLayer
<p>The View recieves requests from the user input.  Any manipulation of the request data needed prior to making a service call would be done at this point.  Likewise, responses received from a service call might be manipulated at this level prior to sending the response back to the user</p> 

There are three endpoints available in the __UserController__

1. POST api/user
2. GET api/user{userId}
3. GET api/user/lastname/{lastname}

## Tests
<p>Unit testing is achieved using the mstest framework and the Moq framework.  Each public method is unit tested in isolation.  Calls to other public methods with in the unit under test are mocked and verified in accordance with good unit testing practices.</p>

<p>
An in memory SQLite database is used for repository testing.  Each Repository test seeds the SQLite database and runs the test against real data.  We can have the religious argument about database testing against real data. 
</p>

### Coverage Report
The test projects each use coverlet and cobertura to calculate code coverage and generate a code coverage report.  The coverage report is a web site that is  generated inside the __Report__ directory.  The coverage report can be generated by running the build.sh command and viewing __index.htm__ in the __Report__ directory.

    Windows users can duplicate the functionality of build.sh in Powershell or run the build.sh using the Windows bash shell


## Requirements
* SQLServer
* .NET Core 3.0
* dotnet ef tools

## Running
### Install Entity Framework Core tools.
Follow the instuctions at 
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet
to install the Entity Framework Core tools.  You'll need this to run migrations and build the database

### Configuration
Modify the appsetting files in the DBLayer and ViewLayer project to reflect the SQLServer connection strings for your database.

### Build the database
From the root directory run 

    dotnet ef database update --project DBLayer/src/DBLayer.csproj


This will run the included migrations and build the database

### Run the application
You can either run the code from the command line or the VSCode/Visual Studio IDE

To run the application from the command line.

    cd ViewLayer/src
    dotnet run

To run from the IDE follow the instructions in your IDE for debugging or running.

### Calling the endpoints
Use curl, Postman, Insomnia or similar to call the endpoints
#### Create a user
    POST to http://localhost:5000/api/user/
Example body

    {
	"firstName": "First",
	"lastName": "Last",
	"addresses": [{
		"address1": "433 My Street Name",
		"city": "Some City",
		"state": "IL",
		"postalCode": "6000"
	},
	{
		"address1": "2103 My Other Street Name",
		"city": "Another City",
		"state": "IL",
		"postalCode": "60046"
	}
	],
	"phoneNumbers":[{
		"number": "222-333-4444",
		"phoneType": "Home"
	},
	{
		"number": "999-888-777",
		"phoneType": "Mobile"
	}]
    }
The api returns the created object with Location header element containing the newly created resource location

#### Get By ID
    GET to http://localhost:5000/api/user/{userId}
returns the user with the given user id

#### Get By ID
    GET to http://localhost:5000/api/user/lastname/{lastname}
returns the user with the given lastname



