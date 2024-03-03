# School42 API Services Library
*Work in progress...*

This library is designed to work seamlessly with the School42 OAuth Authentication Library, providing easy access to user information from School42's API within ASP.NET Core applications. It allows developers to retrieve detailed user profiles, including personal information, educational background, and project participation, using the authenticated user's access token.

## Features

- Retrieve authenticated user's information from School42 API.
- Fetch specific user information by login name.
- Seamless integration with School42 OAuth Authentication for ASP.NET Core.
- Easy to use within any ASP.NET Core project that utilizes School42 authentication.

## Prerequisites

Before using this library, you should have:

- An ASP.NET Core project set up and running.
- The [School42.OAuth Authentication Library](https://github.com/ReyanCarlier/School42.OAuth) integrated into your project.
- A registered application on School42's platform with valid client ID and client secret.
- Basic understanding of ASP.NET Core, HTTP requests, and OAuth authentication flows.

## Installation

This library is intended to be used as part of an ASP.NET Core application. Ensure that you have the [School42.OAuth Authentication Library](https://github.com/ReyanCarlier/School42.OAuth) already set up in your project. If not, refer to the [README](https://github.com/ReyanCarlier/School42.OAuth/blob/main/README.md) of that library for setup instructions.

## Configuration

No additional configuration is needed specifically for this library beyond what is required for the [School42.OAuth Authentication Library](https://github.com/ReyanCarlier/School42.OAuth). Ensure that your application is correctly set up to authenticate users with School42's OAuth service.

## Usage

Here's how to use the `UserService` in your ASP.NET Core application:

1. Inject the `IHttpContextAccessor` into your service or controller where you intend to use `UserService`. This is required to access the current HTTP context and, consequently, the user's OAuth token.

    ```csharp
    public class MyController : Controller
    {
        private readonly UserService _userService;

        public MyController(IHttpContextAccessor httpContextAccessor)
        {
            _userService = new UserService(httpContextAccessor);
        }
    }
    ```

2. Use the `UserService` to retrieve user information:

    ```csharp
    public async Task<IActionResult> GetUserProfile()
    {
        var user = await UserService.GetUserInfoFromJson(HttpContext);
        if (user == null)
        {
            return Unauthorized(); // Or handle accordingly
        }

        return View(user);
    }
    ```

3. To retrieve another user's information by login:

    ```csharp
    public async Task<IActionResult> GetOtherUserProfile(string login)
    {
        var user = await UserService.GetUserFromLoginAsync(HttpContext, login);
        if (user == null)
        {
            return NotFound(); // Or handle accordingly
        }

        return View(user);
    }
    ```

## Customization

You can extend the `UserService` and `User` classes to include additional endpoints from the School42 API or to handle different data structures as needed.

## Contributing

Contributions to this library are welcome. Please feel free to fork the repository, make your changes, and submit a pull request.

---

This library is designed to complement the School42 OAuth Authentication Library, providing a streamlined way to access user data after authentication. Ensure that your School42 OAuth setup is correct before using this service library.
