# Application Insights Telemetry Initializers

Corduras implementation and samples, on how to inject Telemetry Initializers into Application Insights in .Net MVC and WCF

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them

```
Azure Application Insights Resource
```

```
Visual Studio Enterprise for testing the project and managing NuGet packages
```

### Installing

A step by step series of examples that tell you how to get a development env running


```
Create the Azure Application Insights Resource, and copy the Instrumentation Key from the resource dashboard
```
```
Add the telemetry key to the Application Settings on the Azure resource, or to the Web.config file in your project
```
```
Run the application in IIS Express using Visual Studio
```

If using WCF try testing the method calls using the WCFtestclient, and if MVC, try making a post request to the Home controller.

## Built With

* [ApplicationInsightsSDK](http://www.dropwizard.io/1.0.2/docs/) - The web framework used

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.
