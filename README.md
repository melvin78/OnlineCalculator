<p align="center"><a href="https://calculator.webmelvin.me" target="_blank">
<img src="https://raw.githubusercontent.com/melvin78/OnlineCalculator/master/blob/calculator.png" width="400"></a></p>

## Demo

Check out [here](https://calculator.webmelvin.me)

## Calculator App

A c# calculator built using blazor server side architecture. Arithmetic expression are first parsed as strings then passed to regex functions
which then compute the calculations and then returns the results. Answers are immediately returned without the need of hitting the equal 
button with the help of blazor's two way binding and [In-Memory State Management](https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-6.0&pivots=server).

## ScreenShots

### Main Page:

<img src="https://raw.githubusercontent.com/melvin78/OnlineCalculator/master/blob/calc-demo.png" alt="here">

## Installation:

```bash
# Ensure you are in the project's root directory

# Restore Packages
$ dotnet restore

# Start Blazor Server
$ dotnet run

#Start Blazor Server With Hot Reload

$dotnet watch

