# BlogTemplateApi

## Configuring your application

1. After running `Update-Database` for the first time, the migration will generate a default `User` with the following attributes:
```json
{
  "Name": "admin",
  "Email": "admin@admin.com",
  "Password": "admin",
  "IsAdmin": "true"
}
```
* Be sure to modfiy this default attributes when running on a production environment !!!
