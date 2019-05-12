# Journey Requirements: Step 10
**Author:** Sam Amara
**Date:** 5/8/19

## Basic User Requirements: 

1. As a user, you can sign up by providing:
   - valid e-mail
   - password that has a minimum of eight characters
   - password confirmation
   - Account creation date is stored in the DB
   
2. As a user, you can login by providing your e-mail and password. You will be redirected to the home page on success or asked to login again if authentication failed.

3. As a user, you can view and update your profile info, all data below is optional:
   - First, Last Name
   - Phone#, DOB, Gender
   - Secondary Email, 
   - About Me, Occupation, Hobbies, and Social Media Info
   
4. As a user, you can add, update and delete your profile picture:
   - Select profile photo from existing albums
   - Upload photo file from computer (max size 6 mb), info will be stored in DB
   - Add a profile Album to DB if doesn't exist
   - The current profile picture is always the last photo in AlbumPhoto Table
   
5. As a user, you can add, update and delete cities info, for each city the data below can be entered:
   - city name, country (required)
   - city state/province (optional)
   - select if the city is where you currently live (enter start date, address)
   - select if you previously lived in the city (enter start/end date, address)
   - select if you want to visit a city (enter start date/end date)
   - select if you previously visited a city (enter start date/end date)

6. As a user, you can add, update and delete trips, for each trip the data below can be entered:
   - Trip name, date trip was created is automatically entered (Required) 
   - Start/End Dates, Description (optional)

7. As a user, you can add, update and delete cities from trips, for each trip cities the the data below can be entered:   
   - Start/End Dates(required)
   - Note (optional)
   
8. As a user, you can add, update and delete trip details, the data below can be entered:
   - Accommodation, Inbound / Outbound transportation (required); preferably select from list (hotel, AirBnB, plane, train, other, etc ...)
   - Accommodation and transportation details (optional)

9. As a user, you can add, update and delete trip activities, the data below can be entered:   
   - Activity name (required)
   - date, type (list), cost/currency, note (optional)
   
10. As a user, you can search other users and see basic information (name, gender, location, about)

11. As a user, you can add and delete relationships with other users, the data below can be entered:
    - Relationship, select from list (friend, family, spouse) (required) 
	- Once the other users accepts the request, StartDate is populated in DB
	
12. As a user, you can follow or unfollow other users, the data below is entered:
    - Following
      - If a Relationship exists, follower is set to True in DB
	  - Otherwise relationship is set to Follower, start date is set to current date, and follower is set to True in DB
	- UnFollowing
	  - Follower is set to False in DB

13. As a user, you can set any users you have a relationship with as Emergency contact

14. As a user, you can add, update and delete Albums, the data below can be entered:
    - Album name, Date created populated automatically (required)
	- Description, Tag Existing Trip, Select Album Cover Thumbnail (optional)

15. As a user, you can add, update and delete Albums, the data below can be entered:
    - Select photos from existing albums
    - Upload photo files from computer
	
16. As a user, you can add, update and delete a Photo from an Album, the data below can be entered:
    - File Path (uri), Date Photo Added to server, Date Photo Added to album, sequence number in album (required)
	- Photo Name, Location, Thumbnail (optional)
	
17. As a user you can access the home page which should display:
    - Navigation menu (profile, trips, relationships, photos)
	- Search bar 
	- Upcoming/recent trips
	- Feed from relationships
	- Popular destinations 

## Stretched User Requirements: 

a. Add Administrator role to manage users
b. Give user option to login using OAuth
c. Give user capability to reset password, change primary e-mail/password, and implement account activation
d. Give user capability to post/send messages/block users
e. Give user capability to custom page/settings
f. Display user trips on map