# Life-Balance

![.NET Core](https://github.com/egor-kl/life-balance/workflows/.NET/badge.svg)

### Email settings

For the correct functioning of sending mail, you must add the **sendersettings.json** file to the root of the [Web](https://github.com/Egor-kl/Life-Balance/tree/master/src/Life-Balance.WebApp) project filled in according to the pattern below.

```
{
  "MailSettings": {
    "Server": "smtp.your.server",
    "Port": "555",
    "EmailAddress": "email",
    "Password": "password"
  }
}
```

## Built with
- [Clean architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures);
- [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/);
- [MimeKit](http://www.mimekit.net/);
- [Automapper](https://automapper.org/);
- [xUnit](https://xunit.net/);
- [Moq](https://github.com/Moq/moq4/wiki/Quickstart);

## Author
[Egor Kl.](https://www.linkedin.com/in/egor-kliutsuk/) - Software Engineer;
