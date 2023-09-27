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
    "id": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "accountId": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "type": "Income",
    "amount": 0,
    "description": "My Movement Description",
}
```