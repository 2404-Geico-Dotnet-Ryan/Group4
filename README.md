
# Group4  
**Team Members:** Bobbi Baker, Dawn Brinson, Katherine Piper, Johanna Smith
## Project 2: Trips.com
### Application Overview:
Group 4 will build upon Johanna's "Trip" application and add the following functionality:
 - Convert the application from ADO.Net to EF Core
 - Add an ASP.NET RESTful API
 - Verification of functionality via Swagger
 - Add a customer facing UI using HTML  
 - Add ability to persist data from the UI to a SQL database

### Trips.com UI functionality
 - Create new customer accounts
 - Customer login
 - Search Trips
 - Review and update a customer's saved trips
 - Review and update a customer's profile
 - Delete a customer's saved trip

![Login]()![alt text](Login.jpg)
![Customer]()![alt text](Trips.jpg)


### Login - Bobbi
> display the User Name, First & Last Name
- User can then:  
    - C - save a trip to their profile
    - R - find/review existing trips - Trips Container
    - U - update their profile - User Information container
    - D - delete from saved trips
- Admin can: 
    - C - create a new trip + add to lookups
    - R - find/review trips, saved trips, users/admins
    - U - update all records
    - D - delete trips
- Log Out > return the login screen
        
### Create Account - Bobbi
> return "Account Created"
- display options based on the user type

### User Info 
> container to display logged in User info on the page - click link to update
- admin > option to see a list of all users and update a selected user
    - select user by Username
- User sees their own info and can update from this container if they click update link


### Create a Trip 
> display the fields with a text box or drop list for selecting from the lookups
- Admin only
- hide from Users


### Trips list - Kat
> display list of trips 
- filter by location (other filters are nice to have)
    
### Saved Trips container  
- user - display list of saved trips with option to delete
- admin - display list of all saved trips with user name
    - view only

### Trip Details - Johanna
> display full details of the selected trip
- *nice to have
- select button for the user to save the trip from the detailed view


## Notes:

### Delete 
> Delete trips : make sure deleting a trip doesn't break anything when  there's a related saved trip


