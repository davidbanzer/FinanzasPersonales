# Domain Models

## Movement

```csharp
class Movement {
    Movement Create();
    void Update(Movement movement);
    void Delete();
}
```

```json
{
    "id": {"value":"6B29FC40-CA47-1067-B31D-00DD010662DA"} ,
    "description": "My Movement Description",
    "amount": 0,
    "type": "Ingreso",
    "accountId": {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"},
    "categoryId": {"value":"6B29FC40-CA47-1067-B31D-00DD010662DA"},
    "createdDate": "2020-01-01T00:00:00.000Z",
}
```