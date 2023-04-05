# MinistryOfDefence.Assignment

The solution is hosted on AWS Cloud as three containers:
BackEnd
FrontEnd
SQL Server

Here is the [link](http://ec2-54-84-185-24.compute-1.amazonaws.com:90/).

The FrontEnd is implemented with Angular.

## Installation Instructions

1. Clone the repository

2. Run the sql script dbCreateScript.sql in MS SQL Server Management Studio

3. Change the connection string in appsettings.json file

4. Open cmd and run following commands: 
    
    a. cd YOUR_REPO_LOCATION\MinistryOfDefence.Assignment\MinistryOfDefence.Assignment
    
    b. dotnet run

    c. Find the following line "Now listening on: http://XXXX"

5. Go to the Front folder and open the file src\environments\environment.ts

    a. Change the apiUrl to one from the step 4.c.

    b. Open another cmd and from Front folder run the following commands:

        I.   npm install --save mobx-angular mobx
        II.  npm i
        III. ng serve

6. Find the line "Angular Live Development Server is listening on http://XXXXX" and follow this url