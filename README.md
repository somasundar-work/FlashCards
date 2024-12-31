# FlashCards

Flashcards a learning tool designed to help with memory retention and recall.

# Angular New Project Command

### dry run

```sh
ng new FlashCards.UI --strict -g -p FlashCards --standalone true  --style scss --routing --ssr false --dry-run
```

### Actual Execution

```sh
ng new FlashCards.UI --strict -g -p FlashCards --standalone true  --style scss --routing --ssr false
```

### appsettings.developement.json

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=MyDatabase;User Id=myuser;Password=mypassword;Encrypt=True;TrustServerCertificate=True;",
    }
}
```