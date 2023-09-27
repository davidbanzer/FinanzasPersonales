# Domain Models

# Account

```csharp
class Account {
    Account Create();
    void AddMovement(Movement movement);
    void AddTransaction(Transaction transaction);
    void DeleteMovement(Guid movementId);
    void DeleteTransaction(Guid transactionId);
    void UpdateMovement(Movement movement);
    void UpdateTransaction(Transaction transaction);
    void Delete();
    void Update(Account account);
}
```

```json
{
    "id": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "movementsId": [
        "6B29FC40-CA47-1067-B31D-00DD010662DA",
        "6B29FC40-CA47-1067-B31D-00DD010662DA"
    ],
    "transactionsId": [
        "6B29FC40-CA47-1067-B31D-00DD010662DA",
        "6B29FC40-CA47-1067-B31D-00DD010662DA"
    ],
    "userId": "6B29FC40-CA47-1067-B31D-00DD010662DA",
    "name": "My Account",
    "description": "My Account Description",
    "initialBalance": 0,
    "currentBalance": 0,
}
```