## Order Management App
This app includes a database created using Code First in Entity Framework, with test data for orders, windows, and sub-elements. The app interface allows users to view and edit order data, including the order state, name, and dimensions. Users can also add and remove windows and sub-elements from orders.

## Prerequisites
- .NET Core SDK
- SQL Server

## Getting Started
<b>1. Clone this repository: </b> <br>
- git clone https://github.com/dev-forhad/intus-order-management.git
- Change appsettings with database credentials. 
- Add migrations and update database in Infrastructure Project 

## Build from.Net CLI
dotnet build
## Run from.Net CLI
<br><b>2. Navigate to the project directory:  </b><br>
cd BlazorFullStackCrud/Server
dotnet run

## Features
- Add/Update/Delete Order
- Add/Update/Delete Window
- Add/Update/Delete Sub-elements
- Entity Framework
- Code First
- Automapper
- DAL
- BLL
- Service / Repository Pattern



