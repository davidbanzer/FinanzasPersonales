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
    "id": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "originAccountId": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "destinationAccountId": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "amount": 0,
    "description": "My Transaction Description",
    "originMovementId": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "destinationMovementId": "6B29FC40-CA47-1067-B31D-00DD010662DA",
}
```