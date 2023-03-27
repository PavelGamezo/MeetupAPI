#Hello! 
This is my Meetup_API test introductory task. In order to use the application, you need to perform several actions:

1. Copy this repository to your computer using the command "git clone [link]";
2. The resulting application needs to be launched using a suitable workbench (ex. VisualStudio 2019+) and restore all nuget packages installed in the project;
3. In appsettings.json update "MeetupConnection" link on your active in your database;
4. In Package Manager Console use "update-database" command or "dotnet ef database update" in Terminal. You will have updated database with all entities;
5. Start the project. You will see the Swagger and all methods implemented in it. If you will try to activate one of them, you will have 401 response;
6. To bypass this error, you need to register. Enter username, email and new password for your account;
7. After registration you need to login into your account. Check "Login" method and get bearer token as a response;
8. Click on Autorization button, enter your coppied token in style "Bearer xxxxxxxxxxxxxxxxxxxx";
9. Now you have access to all the methods of the MeetingСontroller, and the 401 error will disappear.
