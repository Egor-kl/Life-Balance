# Life-Balance

![.NET Core](https://github.com/egor-kl/life-balance/workflows/.NET/badge.svg)

### Email settings

For the correct functioning of sending mail, you must add the **mailsettings.json** file to the root of the [Web](https://github.com/Egor-kl/Life-Balance/tree/master/src/Life-Balance.WebApp) project filled in according to the pattern below.

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

## Deployment to Heroku

After you install the Heroku CLI, run the following `login` commands:

```
heroku login
heroku container:login
```

For the application (HEROKU_APP) correct work, a database is required. To add PortgreSQL database on [Heroku](https://heroku.com/), use the following command:

```
heroku addons:create heroku-postgresql:hobby-dev --app:HEROKU_APP
```

To start the deployment to Heroku, run the following commands from the project folder:

```
docker build -t HEROKU_APP .
docker tag HEROKU_APP registry.heroku.com/HEROKU_APP/web
heroku container:push web -a HEROKU_APP
heroku container:release web -a HEROKU_APP
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

## License

This project is under the MIT License - see the [LICENSE.md](https://github.com/Egor-kl/Life-Balance/blob/master/LICENSE) file for details.
