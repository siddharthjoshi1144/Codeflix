# How to Run Codeflix

This guide explains how to set up and run the Codeflix Movie/TV Library Search System.


## 1. Clone the Repository


git clone https://github.com/YOUR_USERNAME/Codeflix.git


## 2. Open the Project

- Open Visual Studio
- Click Open a project or solution
- Select: Codeflix.sln


## 3. Setup the Database

- Open SQL Server Management Studio (SSMS)
- Run the SQL script located at:

SQL/create_database.sql

- This will create the database and required tables
- Update the connection string in the application if needed


## 4. Build the Project

- Click Build → Build Solution
- Ensure there are no errors


## 5. Run the Application

- Press F5 or click Start
- The console application will launch


## 6. Use the System

- Add media items
- Search by title
- Display all records
- Delete records
- Load/Save data from/to database


## Notes

- Ensure SQL Server is running
- Check connection string if errors occur
