# Software Quality - Stock Exchange
## Project Goal
The goal of this project is to create a stock exchange application that collects new data every day and compares it with the previous day's data. The difference between the two is then sent to the user via email.
## Project structure
### Console application
The Stocks Console is a console application that allows the user to interact with the Stock Exchange. It is the main entry point of the application.

After starting the application, today's stock prices are downloaded and if there is an older stock price file, a difference between the two is calculated and displayed in the console.

Then the application saves the difference between the two stock prices in a html file and sends it to the email address specified in the configuration file.
### Tests project
The Stocks.Tests project contains tests for the Stocks project.
### Stocks service
The Stocks service is a class library that contains the logic for downloading stock prices and calculating the difference between two stock prices.


## How to run the application
After building the solution, the user can run the application by running the *Stocks.Console* project.

The settings are stored in the appsettings.json file. The user can change the settings in this file to his liking.

This application uses Google's Gmail SMTP server to send emails. To use this feature, the **user must enter his Gmail address and password** in the appsettings.json file.