2019-20 Group Project Inception --- Astronomical
=====================================

## Summary of Our Approach to Software Development
We will be running our web application through ASP.NET with MVC5. The website will be constantly deployed to prevent user interruption via Microsoft Azure web server hosting services. We will be using SpaceX’s API (https://github.com/r-spacex/SpaceX-API) to display information about rocket launches. NASA’s APOD (https://api.nasa.gov/planetary/apod) API will be used to display astronomical pictures.

## Initial Vision Discussion with Stakeholders
For those interested in all things space who want to learn more about SpaceX and NASA missions and space itself, the Astronomical Learning Website is an informational system that will allow people of all ages to learn about SpaceX, NASA and space in a variety of ways. Visitors will be able to see what missions SpaceX and NASA have completed and be able to view various information about each mission. The website will also include other ways of teaching people about what goes into space missions and other aspects of space. This will include interactive media such as games and quizzes. Unlike SpaceX’s launch manifest (https://www.spacex.com/missions), our product will be able to deliver more detailed information about SpaceX missions and in a format that is more appealing to younger audience alongside a much larger scope of topics.

## Initial Requirements Elaboration and Elicitation

### Questions
* How should the admin accounts be given?

### Interviews

### Other Elicitation Activities?

## List of Needs and Features

* A website with a visual design that appeals to people of any age and evokes the idea of space.
* Administrators should be able to have uniquely typed accounts that allow them to alter content on the website and edit or delete user comments. Additionally, they should be able to moderate non-administrator user accounts in case of malicious behavior.
* Visitors should be able to register for a user account that allows them to post comments, delete their own comments, have a basic profile page, and track the progress of certain website activities.
* We should be able to display detailed information about SpaceX mission launches, this data should be acquired through the SpaceX API (https://api.spacexdata.com/v3/launches).
* For both NASA and SpaceX sections, we should have timelines that show past events that when clicked on will display the information for that event.
* We should have embedded videos for mission launches where available, if videos of an event aren’t available then it isn’t expected for that specific mission.
* Users should be able to view data about how the sun is acting upon locations on earth through SunCalc’s API (https://www.torsten-hoffmann.de/apis/suncalcmooncalc/link_en.html)
* Users should be able to view data about how the moon is acting upon locations on earth through MoonCalc’s API
* (https://www.torsten-hoffmann.de/apis/suncalcmooncalc/link_en.html)
* Information should be available publicly available to any user covering a wide array of space related topics. This includes SpaceX, NASA, NASA rovers, space suits, the sun, the moon, the solar system, stars and the universe beyond our galaxy. 
* We should have a number of daily updating pieces of content so that the website never feels monotonous upon revisits. A picture of the day will be implemented through NASA’s APOD API (https://api.nasa.gov/planetary/apod). A fact of the day will be implemented through a database unless an API can be found to satisfy this condition. A “Today In History” will be implemented which will share historical events that occured on the same day/month in a year of the past. 
* Every major information component should have associated quizzes that users may take to test their knowledge. These quizzes should have varied difficulty levels which the user may dictate what difficulty of questions they wish to answer.
* There should be an event calendar that shows past events which is also interactable. Clicking on the event should redirect the user to the relevant page on the web site. 
* Simple games should be implemented to help break the monotony of information and allow visitors to interact with the website in a way that is designed solely for enjoyment. Every game should be space related and have relatively simple control schemes so that younger players may enjoy them as well. These should be done using HTML5 and Javascript so that they run effectively in a browser window.  

## Initial Modeling

### Use Case Diagrams

### Other Modeling

## Identify Non-Functional Requirements

## Identify Functional Requirements (User Stories)

E: Epic  
U: User Story  
T: Task  


Universe Information
* [E] The Sun
	* Information
	* [U] As a visitor, I want to be able to learn information about the sun.

* [E] SunCalc Api
	* [U] As a visitor, I would like to be able to see how the sun affects different areas at different times.

	[E] The Moon
		Information
[U] As a visitor, I want to be able to learn information about the moon.

MoonCalc Api
[U] As a visitor, I would like to be able to see how the moon affects different areas 		at different times. 

	[E] Solar System
		Information
[U] As a visitor, I want to be able to learn information about our solar system.
[U] As a visitor, I want to see basic information about the planets in our solar system so I can know some simple facts about the planets
[U] As a visitor, I want an image of the planet so I can see what the planet looks like

	[E] Outside Solar System
		Information
[U] As a visitor, I want to be able to learn information about things outside our	 	solar system.
[U] As a visitor, I want some information of the Kuiper belt so that I can learn about what exists right outside our solar system
[U] As a visitor, I want minimal information about the milky way galaxy to learn more about what exists outside our solar system
	[E] Stars
		Information
[U] As a visitor, I want a small graphic that shows the life cycle of a star so that I
can see what stars turn into and what they are made of
[U] As a visitor, I would like to know some of the biggest or smallest stars in that
we know of so that I can compare those stars to our Sun 


Corporation Information
[E] SpaceX information
Launch Profile
		[U] As a user, I can view data about SpaceX launches so I can learn more about			 	them. 
			[T] Get access to the api.
			[T] Create controller functions to get data.
			[T] Create javascript and ajax calls to get data.
			[T] Create page to display data.

SpaceX Missions Timeline
		[U] As a user, I want to be able to see a timeline of the SpaceX launches so I can 			learn more about how missions have changed over time.
			[T] Get access to the api.
			[T] Create controller functions to get data.
			[T] Create javascript and ajax calls to get data.
			[T] Create page to display data.


[E] Nasa Information
Mission Information
			[U] As a user, I want to be able to see information about Nasa launches				 so I can learn more about space missions.

Mission Timeline
			[U] As a user, I want to be able to see a timeline of Nasa’s missions so I				 can learn about the history of space missions
		

Interactive Components
[E] Games:
[U]: As a younger visitor, I want to play games related to space so that I can interact with the website instead of ONLY reading facts
[U: As a visitor, I would like to see a list of scores so that I could improve my gameplay and hopefully out-perform some of the top scores
[E] Quizzes
		[U] As a user, I want to be able to test my knowledge and review the concepts			 	that I learned.


Other Features

Administrator Account
	[U] As an administrator, I want to be able to create an administrator account to be able to 	manage the website.
		[T] Create a table for user accounts.
		[T] Create a page for users to create accounts.
		[T] Create a page for users to login to their accounts.

User Account
	[U] As a user, I want to be able to create an account so I can record my data. 
		[T] Create a table for user accounts.
		[T] Create a page for users to create accounts.
		[T] Create a page for users to login to their accounts.

Interactive Calendar:
U: As a user, I want to see a calendar that shows any launches in previous or latter months so that I can keep track of launches.
[T] Find api for calendar.

Fact of the day:
U: As a user, I want to see a new “fact of the day” on the homepage, so I can learn something “new” when I first come onto the site
[T] Create a table to store facts.
[T] Add code to grab a fact from the database.
[T] Create area on a page to display.




## Initial Architecture Envisioning

## Agile Data Modeling

## Timeline and Release Plan




