# Payroll API

This is a Payroll API that processes timekeeping information and generates payroll reports. The API provides endpoints for uploading CSV files containing employee work data and for retrieving payroll reports based on that data.

## Instructions on How to Build/Run the Application

### Prerequisites

- .NET 8 SDK
- SQL Server or SQL Server LocalDB

### Build

1. Clone the repository to your local machine:
    ```bash
    git clone <repository-url>
    cd PayrollAPI
    ```

2. Restore the project dependencies:
    ```bash
    dotnet restore
    ```

3. Build the project:
    ```bash
    dotnet build
    ```

### Database Setup

1. Update the connection string in `appsettings.json` to point to your SQL Server or LocalDB instance.
2. Run the database migrations to create the necessary tables:
    ```bash
    dotnet ef database update
    ```

### Run

1. To run the application, use the following command:
    ```bash
    dotnet run
    ```
   
2. The API will be available at `https://localhost:5139`.

### Testing

You can use tools like Postman or curl to test the endpoints.

## API Endpoints

### 1. Upload Time Report
- **URL**: `http://localhost:5139/api/timeReport/upload`
- **Method**: `POST`
- **Description**: Uploads a CSV file containing time report data.
  
### 2. Get Payroll Report
- **URL**: `http://localhost:5139/api/payrollReport/report`
- **Method**: `GET`
- **Description**: Retrieves a JSON payroll report based on the uploaded data.

## How Did You Test That Your Implementation Was Correct?

- **Unit Tests**: Unit tests were written to verify the functionality of the key components, including the CSV processing and payroll calculation logic.
- **Manual Testing**: The API endpoints were tested using Postman, covering various scenarios such as uploading valid/invalid files, checking duplicate report uploads, and verifying the accuracy of the payroll reports.

## If This Application Was Destined for a Production Environment, What Would You Add or Change?

1. **Error Handling and Logging**: Implement comprehensive error handling and logging mechanisms using tools like Serilog to capture and analyze errors in real time.
2. **Security**: Add authentication and authorization to secure the endpoints, ensuring that only authorized users can upload files or retrieve payroll data.
3. **Scalability**: Implement caching for frequently requested data, optimize database queries, and consider using a more robust database solution if the data volume increases significantly.
4. **Validation**: Implement additional data validation to ensure the integrity of the uploaded CSV files and the accuracy of the payroll data.
5. **Deployment**: Set up CI/CD pipelines using GitHub Actions or Azure DevOps for automated testing, building, and deployment to production.

## What Compromises Did You Have to Make Due to the Time Constraints of This Challenge?

- **Simplified Validation**: Due to time constraints, the validation of the CSV data is basic and might not catch all edge cases.
- **Limited Error Handling**: Error handling was kept minimal to focus on the core functionality.
- **Testing**: While the application was tested manually and with some unit tests, more comprehensive testing, including performance and stress testing, was not conducted.
- **Basic Documentation**: The documentation provided is straightforward, and more detailed documentation, including API specs and diagrams, would be beneficial for a production environment.
