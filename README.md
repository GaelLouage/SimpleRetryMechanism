SimpleRetryMechanism

Overview

SimpleRetryMechanism is an ASP.NET Core API that demonstrates a retry mechanism for handling transient failures. It includes an API endpoint that reads data from a file with a retry logic to enhance reliability.

Features

ASP.NET Core API with a retry mechanism

RetryHelper class for handling transient failures

Reads data from a file with retry attempts on failure

Configurable retry attempts and delay interval

Technologies Used

ASP.NET Core 6+

C#

Task-based asynchronous programming

Installation & Setup

Clone the repository:

git clone https://github.com/your-repo/SimpleRetryMechanism.git

Navigate to the project directory:

cd SimpleRetryMechanism

Open the project in Visual Studio or your preferred IDE.

Restore dependencies:

dotnet restore

Run the application:

dotnet run

Usage

API Endpoint

GET /api/home/get

Description: Reads the contents of hello.txt with retry logic if any failure occurs.

Response:

200 OK: Returns file content with "test" appended.

400 Bad Request: Returns error message if all retries fail.

Example Request

curl -X GET http://localhost:5000/api/home/get

Code Explanation

RetryHelper Class

The RetryHelper class provides a static method ExecuteWithRetry to execute an operation with retry logic.

public static async Task<T?> ExecuteWithRetry<T>(Func<Task<T>> operation, int maxRetries, TimeSpan delay)

operation: The function to execute with retries.

maxRetries: Maximum number of retry attempts.

delay: Delay between retries.

HomeController

The Get method calls RetryHelper.ExecuteWithRetry to attempt reading a file up to 3 times before failing.

Error Handling

If all retry attempts fail, an exception is thrown with the message: "Failed all retries!".

Contributing

Feel free to fork the repository and submit pull requests for improvements.
