# Domain Models

## Transaction

```csharp
class Transaction {
    Transaction Create();
    void Update(Transaction transaction);
    void Delete();
    void AddOriginMovement(Movement movement);
    void AddDestinationMovement(Movement movement);
}
```

```json
{
    "id": {"value":"6B29FC40-CA47-1067-B31D-00DD010662DA" } ,
    "originAccountId": {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"} ,
    "destinationAccountId": {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"} ,
    "amount": 0,
    "description": "My Transaction Description",
    "originMovementId": {"value":"6B29FC40-CA47-1067-B31D-00DD010662DA"} ,
    "destinationMovementId": {"value": "6B29FC40-CA47-1067-B31D-00DD010662DA"} ,
    "createdDate": "2020-01-01T00:00:00.000Z",
}
```