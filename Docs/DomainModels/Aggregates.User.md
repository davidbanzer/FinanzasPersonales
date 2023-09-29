# Domain Models

## User

```csharp
class User {
    User Create();
    void AddAccount(Account account);
    void AddCategory(Category category);
    void DeleteAccount(Guid accountId);
    void DeleteCategory(Guid categoryId);
    void UpdateAccount(Account account);
    void UpdateCategory(Category category);
}
```

```json
{
    "id": {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"},
    "firstName": "David",
    "lastName": "Banzer",
    "email": "davidbanzer@gmail.com",
    "password": "P@ssword1",
    "accountsIds": [
        {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"}, 
        {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"}
    ],
    "categoriesIds": [
        {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"}, 
        {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"}
    ],
}
```