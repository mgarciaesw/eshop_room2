![Tests](https://github.com/mgarciaesw/eshop_room2/actions/workflows/tests.yml/badge.svg?branch=main)

Eshop
=====

DDD course project

## Set Up

1. **Set environment variables.** Create a `.env` using `.env.example` as template and assign the missings values.
1. 
2. **Build and start the containers.**

3. **Execute the migrations.** Check the related doc in the section *Migrations*.

## Migrations

The solution includes a Tools.MigrationRunner, the project to be use as entrypoint to execute any command related to EF migrations like add or remove migrations, drop or update the database, ...

To use it, first, we have to set up the settings file. Go to the project folder, create a `appsettings.json` using `appsettings.json.example` as template and then replace the dummy values with the proper ones.

### Update Database

Using `Package Manager Console`. Using the referred console from VS, set `Tools.MigrationRunner` as startup project and `Infrastructure` as default project and then execute the following command:

```console
Update-Database
```

Using `dotnet-ef`. Open a terminal like PowerShell and execute the following command:

```console
dotnet-ef database update --project .\Infrastructure\ --startup-project .\Tools.MigrationRunner\
```