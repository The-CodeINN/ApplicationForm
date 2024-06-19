# ApplicationForm API

## Overview

The **ApplicationForm API** is a web service designed to manage program application forms and candidate responses. The API allows employers to create, update, and retrieve application forms, and enables candidates to submit responses to these forms. The application uses Azure Cosmos DB for data storage and ASP.NET Core for the API framework.

## Features

- **Employer Operations:**
  - Create a new application form.
  - Retrieve an existing application form by ID.
  - Update an existing application form.
  - Retrieve candidate responses by form ID.

- **Candidate Operations:**
  - Retrieve application form questions by form ID.
  - Submit responses to an application form.

## Technologies Used

- **Backend:** ASP.NET Core
- **Database:** Azure Cosmos DB
- **Serialization:** Newtonsoft.Json
- **Dependency Injection:** Microsoft.Extensions.DependencyInjection
- **Mapping:** AutoMapper

## Project Structure

- **Controllers:** Handles incoming HTTP requests and responses.
- **Models:** Defines the data structures used by the application.
- **DTOs:** Data Transfer Objects for encapsulating data sent to and from the API.
- **Repositories:** Provides an abstraction layer for data access.
- **Enums:** Defines enumerations for question types and groups.

## Getting Started

### Prerequisites

- .NET SDK
- Azure Cosmos DB account
- Configuration for Cosmos DB connection string in `appsettings.json`

### Installation

1. **Clone the repository:**
   ```sh
   git clone https://github.com/The-CodeINN/ApplicationForm.git
   cd ApplicationForm
   ```

2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

3. **Update `appsettings.json`:**
   Configure your Azure Cosmos DB connection string and database name.

4. **Run the application:**
   ```sh
   dotnet run
   ```

### API Endpoints

#### Employer Endpoints

- **Create Form:**
  - `POST /api/employer/create-form`
  - Request Body: `CreateProgramApplicationFormRequestDto`

- **Get Form by ID:**
  - `GET /api/employer/{formId}`
  - Response Body: `CreateProgramApplicationFormRequestDto`

- **Update Form:**
  - `PUT /api/employer/{formId}`
  - Request Body: `CreateProgramApplicationFormRequestDto`

- **Get Responses by Form ID:**
  - `GET /api/employer/responses/{formId}`
  - Response Body: `IEnumerable<CandidateResponseDto>`

#### Candidate Endpoints

- **Get Form Questions:**
  - `GET /api/candidate/form/{formId}`
  - Response Body: `CreateProgramApplicationFormRequestDto`

- **Submit Response:**
  - `POST /api/candidate/response/{formId}`
  - Request Body: `CandidateResponseDto`

## Example Requests

### Create Form (Employer)

```json
{
  "title": "Example Program Application Form",
  "description": "This form contains all possible question types and groups.",
  "questions": [
    {
      "title": "What is your full name?",
      "type": "Text",
      "group": "PersonalInformation"
    },
    {
      "title": "Tell us about yourself.",
      "type": "Paragraph",
      "group": "PersonalInformation"
    }
    // Other questions...
  ]
}
```

### Submit Response (Candidate)

```json
{
  "formId": "f2833e66-e2ca-4b68-8828-937567e525a3",
  "responses": [
    {
      "questionId": "d76e82be-311f-4e3e-880f-7ae03e84ff90",
      "response": "John Doe"
    },
    {
      "questionId": "ad796f12-5afe-4f03-8837-9e6ef3a7dad2",
      "response": "I am a software developer with over 10 years of experience in various programming languages and technologies."
    }
    // Other responses...
  ]
}
```

## Contributing

Contributions are welcome! Please fork the repository and submit pull requests.

## License

This project is licensed under the MIT License.

---

With ❤️ from [The CodeINN](https://github.com/The-CodeINN/)