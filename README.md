# Revenue Recognition System

## Overview
The Revenue Recognition System is a REST API application designed for ABC Corporation to address complex revenue recognition challenges in the finance domain. This system ensures accurate and compliant revenue recognition for various types of products, enhancing financial transparency and trust.

## Project Context
The system aims to manage various aspects of revenue recognition for ABC Corporation, including client management, software license management, contract and revenue calculation.

## Functional Requirements

### Managing Clients
- **Individuals:** Store first name, last name, address, email, phone number, and PESEL (Polish National Identification Number).
- **Companies:** Store company name, address, email, phone number, and KRS number (National Court Register number).
- Support adding, updating, and soft deleting clients (individuals), while ensuring PESEL and KRS numbers remain immutable.

### Software License Management
- Manage software systems sold with an upfront cost.
- **Discounts:** Apply discounts upfront costs, with specified time ranges and percentage values.

### Contract Management
- **Upfront Cost Contracts:**
  - Create contracts with start and end dates, price including discounts, and support period.
  - Ensure full payment within a specified time range (3 to 30 days) to validate contracts.
  - Support single or multiple installment payments.
  - Contracts are immutable once created and can only be removed if needed.

### Revenue Calculation
- Calculate current and predicted revenue for the company, specific products, and currencies.
- Use public exchange rates to convert revenues to the required currencies.

## Technologies Used
- **ASP.NET Core:** For building the REST API.
- **Entity Framework Core:** For ORM (Object-Relational Mapping) using the Code-First approach.
- **Migrations:** For managing database schema changes.
- **SQL Server:** As the database management system.
- **Swagger:** For API documentation and testing.
- **Dependency Injection:** For managing dependencies.
- **Authentication and Authorization:** Role-based access control for securing endpoints.
