# SalesSummaryProject
This document serves as the comprehensive technical guideline for the Sales Summary project, which is part of the interview process for developer role at Virgin Media. Here, you'll find a detailed breakdown of all requirements, points of emphasis, and expectations for this task.

## Project Overview

We would like you to design a simple web app that displays the list of sales from the data.csv file in a
summary back to the user. The summary should be displayed in a method of your choosing.
We would like to see the best of breed techniques and industry best practice utilised.

# Technical Requirements:
This document outlines the interaction between a front-end application and a set of microservices via an API Gateway. The primary functionality is to allow users to  view list of sales.

## Components
### Front-end Application:
A user interface that display list of sales data. It communicates with the backend services through the API Gateway.

### API Gateway :
Acts as the entry point for the front-end application to interact with the backend microservices. It routes requests to the appropriate services and aggregates results.

### Microservices:
### SalesSummaryInternalService:
 This service read data from CSV files.

 ## Technology Stack
●	Core Technology: C# .NET 8

●	Rate Limiting: ASP.NET Core rate limiting middleware

●	SDKs/Libraries: MediatR and CsvHelper 

●	Front End Framework : ASP.NET CORE WEB MVC

●	Documentation: Swagger

## Development Considerations
●	Coding Best Practices: Following SOLID principles, clean code practices.

●	Documentation: Comprehensive documentation of code, architecture, and design decisions.

●	Scalability & Maintainability: Ensuring that the platform can handle growth and is easy to maintain.


# Architectural Patterns:
●	Implementing CQRS (Command Query Responsibility Segregation) 

●	Domain-driven design, Gateway pattern.

## High Level Architecture:
![image](https://github.com/user-attachments/assets/5ad85ecc-aacb-4853-80f3-002af73c554d)


# Front End App Setup

1.Ensure you have .NET 8 installed on your system.

2.Open the folder WebUI.sln

3.Build WebUI.sln and Run 


# Back-End Services Setup
1.Ensure you have .NET 8 installed on your system.

2.Open Services folder and open Services.sln

3.Build Services.sln and Run

4.Open APIGateway folder and open APIGateway.sln

5.Build APIGateway solution and run
