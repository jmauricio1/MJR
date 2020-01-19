2019-20 Class Project Inception
=====================================

## Summary of Our Approach to Software Development

We intend to use ASP.NET framework with MVC5 protocols for launching and maintaining this web app service. Deployment will be through Microsoft Azure and databases will be done with SQL. An 

## Initial Vision Discussion with Stakeholders

Primary Stakeholder -- Katimichael Phelpedecky, swimming legend and hopeful entrepreneur

Katimichael's experience being on the US Olympic team led to an appreciation of how advanced tools can help athletes perform at their best.  The problem is those tools are very expensive and require personnel with advanced training, i.e. elite analysts for elite athletes.  They want to create a business to give regular swimming coaches, from high school, club, college, and masters, advanced analytical and predictive tools to help the athletes on their teams.  Katimichael has assembled a team of investors to fund this project and is hiring your team to create the product.

The product is centered around three core features:

1. Record, store and provide tracking, viewing and simple stats for race results for swimming athletes.  This would have a number of features found in [Athletic.net](https://www.athletic.net/), which is used for Track and Cross Country running.
2. Provide complex analysis of athlete performance over time and over different race types, to give coaches deep insight into their athlete's fitness and performance that they cannot get from their own analyses.  This includes machine learning to predict future performance based on records of past race performance, given different training scenarios.  Validation of this feature will enable the next feature.
3. Create a tool that will optimize a coach’s strategy for winning a specific meet.  This feature will automatically assign athletes to specific races based on their predicted race times in order to beat an opponent coach's strategy.  There will be two modes: one in which we have no knowledge of the opponent team's performance, and one where we do have their performance and can predict their times.

## Initial Requirements Elaboration and Elicitation

What we know:
Core Features
Record, store, track, view simple stats for race results for swimming athletes
Complex analysis of athlete performance over time of different kinds of races. Learning to predict future performances based on past performances given different training scenarios
Create tool that optimizes coach’s strategy for winning a specific meet
Putting athletes on certain races
2 Models
No knowledge of team’s performance
We do have performance and can predict their times
Needs
Nice looking site that have swimming and competition
Free and paid features
Anyone can view all results  Anyone can search by name, team, coach, date, or location
No need to search by state or school
Login for viewing stats and other advanced features
Admin login for logging in new data
“Standard” logins  unique valid email as username and 8+ char pwd
Athletes can change teams
Stats needed
PR in each event
Historical picture of performance, per race type and distance
Measurement of how they rank compared to other athletes, current and historical
How often they compete in each race event


### Questions

How did they want to view how frequent an athlete participated in an event? (pie chart, graph)
Did they want stats ONLY in those that they have participated in? So, we can eliminate any future redundancies.
What way should we point out that a student is an “active” athlete?
Should the login be on the home page or on a separate page?
Should a person be able to make a new account from the home page or a separate page?
When the administrator uploads a spreadsheet what format will the spreadsheet be in?
At what point is monetization going to be considered, after an amount of time, or after a threshold of a user base is established?
Machine learning was mentioned, there’s a number of machine learning API’s available, would you have any preference towards Amazon’s machine learning on AWS, IBM’s Watson, Google’s Cloud AI or Microsoft’s Azure Cognitive services or should we seek other options?
How many coaches can a team or does a team have?

### Interviews
Dev 1: How do you want athlete data to be displayed?
Stakeholder: We think that a table of some sort would be the easiest to understand.
Dev 1: How many coaches can a team have?
Stakeholder: We assume that each team will only have one representative coach but that coach must be easily changeable.

Dev 1: How many different types of users are you anticipating for use with this service?
Stakeholder: We anticipate that there will be administrators, registered and verified coaches that may upload their results, registered visitors and non-registered visitors. 


### Other Elicitation Activities?

## List of Needs and Features

1. They want a nice looking site, with a clean light modern style, images that evoke swimming and competition.  (More like [Strava](https://www.strava.com/features) and less like [Athletic.net](https://www.athletic.net/TrackAndField/Division/Event.aspx?DivID=100004&Event=14))  It should be easy to find the features available for free and then have an obvious link to register for an account or log in.  It should be fast and easily navigable.  
2. The general public will be able to view all results (just the race distance, type and time).  These are public events and the results should be freely available.  They should be able to search by athlete name, team, coach or possibly event date and location.  Not sure if they want to be able to filter or drill down as Athletic.net does.  They're not trying to organize by state, school, etc. Athletes are athletes and it doesn't matter where they're competing.  This is completely general, but only for swimming.
3. Logins will be required for viewing statistics and all other advanced features.  We eventually plan to offer paid plans for accessing these advanced features.  They'll be free initially and we'll transition to paid plans once we get people hooked.
4. Admin logins are needed for entering new data.  Only employees and contractors will be allowed to enter, edit or delete data.
5. "Standard" logins are fine.  Use email (must be unique) for username and then require an 8+ character password.  Will eventually need to confirm email to try to prevent some forms of misuse.  Admins and contractors must have an offline confirmation by our employees and then the "super" admin adds them manually.
6. The core entity is the athlete.  They are essentially free agents in the system.  They can be a member of one or more teams at one time, then change at any time.  Later when we want to have teams and do predictive analysis we'll let the coaches assemble their own teams and add/remove athletes from their rosters.
7. The first stats we want are: 1) display PR's prominently in each race event, 2) show a historical picture/plot of performance, per race type and distance, 3) some measure of how they rank compared to other athletes, both current and historical, 4) something that shows how often they compete in each race event, i.e. which events are they competing in most frequently, and alternately, which events are they "avoiding"
8. Some form of machine learning should be implemented. We want it to be able to use predictions to form a team of swimmers for a coach that is the most likely to win any given event. This should be able to predict based on swimmers records for each individual event and should be able to predict based on no knowledge of the opposing team or based on having knowledge of the opposing team. 
9.

## Initial Modeling

### Use Case Diagrams

### Other Modeling

## Identify Non-Functional Requirements

1. User accounts and data must be stored indefinitely.  They don't want to delete; rather, mark items as "deleted" but don't actually delete them.  They also used the word "inactive" as a synonym for deleted.
2. Passwords should not expire
3. Site should never return debug error pages.  Web server should have a custom 404 page that is cute or funny and has a link to the main index page.
4. All server errors must be logged so we can investigate what is going on in a page accessible only to Admins.
5. English will be the default language.
6. The web page should have a near 100% uptime so that the service is constantly available to users.
7. We would like the web servers to be able to handle at least 1,000 concurrent users on the page at any given time.
9. Web page response times should be relatively quick, we don’t want users waiting long periods of time for access to their viewed results. 

## Identify Functional Requirements (User Stories)

E: Epic  
U: User Story  
T: Task  

1. [U] As a visitor to the site I would like to see a fantastic and modern homepage that introduces me to the site and the features currently available.
   1. [T] Create starter ASP dot NET MVC 5 Web Application with Individual User Accounts and no unit test project
   2. [T] Choose CSS library (Bootstrap 3, 4, or ?) and use it for all pages
   3. [T] Create nice homepage: write initial content, customize navbar, hide links to login/register
   4. [T] Create SQL Server database on Azure and configure web app to use it. Hide credentials.
2. [U] As a visitor to the site I would like to be able to register an account so I will be able to access athlete statistics
   1. [T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP script
   2. [T] Configure web app to use our db with Identity tables in it
   3. [T] Create a user table and customize user pages to display additional data
   4. [T] Re-enable login/register links
   5. [T] Manually test register and login; user should easily be able to see that they are logged in
3. [E] As an administrator I want to be able to upload a spreadsheet of results so that new data can be added to our system
[U] As an administrator I want to be able to create an administrator account so I can access administrator only features.
[U] As an administrator I want the ability to create a spreadsheet that can be uploaded to the website so I can add data to the system.
[U] As an administrator I want to be able to upload my spreadsheet of athlete data to the website so visitors and I can view that data.
[U] As an administrator I want the data being uploaded to be verified so that it meets the standards/requirements of the system
4. [U] As a visitor I want to be able to search for an athlete and then view their athlete page so I can find out more information about them
	1.[T] Implement a search feature that searches based on an athlete’s name.
	2.[T] From the search redirect the visitor to a page.
	3.[T] The page should get the athlete data and display it.
5. [U] As a visitor I want to be able to view race results for an athlete so I can see how they have performed
6. [U] As a visitor I want to be able to view PR's (personal records) for an athlete so I can see their best performances
7. [U] As a visitor I want to be able to move quickly and easily between pages and features via a navigation bar seen on all pages
8. [U] As a robot I would like to be prevented from creating an account on your website so I don't ask millions of my friends to join your website and try to add comments about male enhancement drugs.
9. [E] As a coach I would like to use a tool to be able to create an optimized team for winning events.
     1.[U] As a coach I want a tool for if I know the opposing coach’s strategy so that I can create that would give me the highest chance of winning.
     2.[U] As a coach i want a tool in case I do not know the opposing coach’s strategy so that I can create that would give me the highest chance of winning.
	

## Initial Architecture Envisioning

## Agile Data Modeling

## Timeline and Release Plan
Week 1: Inception Phase
Week 2 (Sprint 1): Set up pivotal tracker, mini-iteration, azure deployment
Week 3 (Sprint 2): Full iteration practice
Week 4: Retrospective


## Refined Vision Statement
For coaches who want to analyze their athlete’s data using advanced analytics tools, the Athlete Data Tracker is a website that will allow coaches to upload athlete data to the website. This page will allow coaches to record and store their data. All visitors of this service, coaches and the public alike will have access to these race results through our service. With this data, coaches will be able to able to use our suite of analytical tools to perform complex analysis of their athlete’s performance results. Another feature of our service is a machine learning algorithm that will build ideal teams for a coach based on their athlete’s prior performances. Unlike current competing products on the market, our product will have a lower price point and be more easily accessible and usable for coaches without the need for specialized personnel with advanced training.

We estimate that within the first 4 sprints (week 8) of the project we should have a working web service with a home page with defined user types with the ability to upload and view data. By the end of the 7th sprint (week 14) we estimate that the advanced analytical tools will be complete and functional, with machine learning in place to aid coaches in forming ideal teams for winning swim events.

	We estimate that the overall cost of the project will be 1,000,000$ USD alongside over time maintenance fees for a large scale web deployment via Azure and server capacity from SQL server. 

This project will be built using an ASP.NET MVC5 framework. The web application will be deployed to the web via Microsoft Azure services and databases will be managed through SQL server. An API will likely be used to implement the machine learning aspect of the analytical tools.

Potential risks include complications with the machine learning API, however if the initial choice proves to be problematic, other options are currently available on the market as fallbacks. Another potential risk is misuse of the system but we intend to handle this with proper verification so that only trusted users have the ability to alter or add to the database.


