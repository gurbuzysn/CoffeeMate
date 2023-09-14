# COFFEE MATE

### Migrations
```
add-migration InitialCreate -Context CoffeeMateContext -o Data/Migrations
update-database -Context CoffeeMateContext

add-migration InitialIdentity -Context AppIdentityContext -o Identity/Migrations
update-database -Context AppIdentityContext
```