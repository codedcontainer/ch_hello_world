# Hello World Application (MVC, OOP, API)
Uses Visual Studio C# MVC and C# API

=== Requirements == 
1. The program has 1 current business requirement a write Hello World to the console/screen.
2. The program should have an API that is separated from the program logic to eventually support mobile applications, web applications, console applications or windows services.
3. The program should support future enhancements for writing to a database, console application, etc.
  a. Use common design patterns (inheritance, e.g.) to account for these future concerns.
  b. Use configuration files or another industry standard mechanism for determining where to write the information to.
4. Write unit tests to support the API.


=== Build Process ===
* Add two inputs, first name and last name
  * Valiate these forms on the client side, formvalidation.io or built in validators?
    * Fiels cannot be empty and must be strings not integers
  * Send these inputs to our process page which will include a class with 4 different methods
    * method 1: Grab values from the form and send each value to method 2.
    * method 2: Verify that the values from the form are valid using the previous validation methods but include a regex to parse out any special characters suchs [$,&,&,.] - Use this method when using the API. If false print result back to the page
    * method 3: See if the first and last name are a match in the db, if not then add. 
      * SELECT * FROM names WHERE fname="" AND lname =""; 
    * method 4: Concatinate the strings together if they are valid from method 2
* Have an API page
  * Grab all values form db and list them on a page
  * ?firstname="string"&lastname="string"
    * return the item form the db and list as json for use in another application
    * return false message if firstname or lastname are not valid using regix from method 2 or if empty
    * return false if using other search parameter and notify the user of their mistake. 
    
      
