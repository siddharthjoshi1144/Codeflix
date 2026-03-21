# Codeflix – Movie/TV Library Search System

## Project Overview
Codeflix is a C# based console application designed to manage and search a collection of movies and TV shows efficiently. The system uses a **Binary Search Tree (BST)** as a custom data structure to enable fast searching, sorting, and management of media records. It also integrates with a **SQL database** for persistent storage.


## Features
- Add new movies/TV shows
- Search media by title
- Display all media in sorted order
- Delete media records
- Input validation for reliable data entry
- SQL database integration (save & load data)
- Unit testing for system validation


## Technologies Used
- **Language:** C#
- **Framework:** .NET (Console Application)
- **Database:** SQL Server
- **Data Structure:** Binary Search Tree (BST)
- **Testing:** MSTest / Unit Testing Framework
- **Version Control:** Git & GitHub


## System Design

### Data Structure Choice
A **Binary Search Tree (BST)** is used because:
- Efficient search, insert, delete operations
- Automatically maintains sorted order
- Demonstrates understanding of core data structures

### Time Complexity
| Operation | Average Case | Worst Case |
|----------|-------------|------------|
| Insert   | O(log n)    | O(n)       |
| Search   | O(log n)    | O(n)       |
| Delete   | O(log n)    | O(n)       |



## Database Integration
The system connects to a SQL database to:
- Store media records permanently
- Load existing data into the application
- Ensure data persistence beyond runtime


