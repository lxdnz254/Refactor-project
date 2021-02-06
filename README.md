# Refactoring Assessment

- Added service classes to handle all SQL queries, making it easier to maintain and make changes
- removed sql methods from models, moved to new services ... models should be only concerned with properties, fields, and get - set methods.
- Removed sql queries from controllers, moved to new services .. api contract remains the same, so earlier users of the api endpoints will still recieve same result.
- Using the service query classes we can place common fields or properties in the parent `QueryService` class, and keep queries specific to each controller, or table, within their own classes,

The api is composed of the following endpoints:

| Verb     | Path                                   | Description
|----------|----------------------------------------|--------------------------------------------------------
| `GET`    | `/api/Accounts`                        | Gets the list of all accounts
| `GET`    | `/api/Accounts/{id:guid}`              | Gets an account by the specified id
| `POST`   | `/api/Accounts`                        | Creates a new account
| `PUT`    | `/api/Accounts/{id:guid}`              | Updates an account
| `DELETE` | `/api/Accounts/{id:guid}`              | Deletes an account
| `GET`    | `/api/Accounts/{id:guid}/Transactions` | Gets the list of transactions for an account
| `POST`   | `/api/Accounts/{id:guid}/Transactions` | Adds a transaction to an account, and updates the amount of money in the account

Models conform to the following formats:

**Account**
```
{
    "Id": "01234567-89ab-cdef-0123-456789abcdef",
    "Name": "Savings",
    "Number": "012345678901234",
    "Amount": 123.4
}
```	

**Transaction**
```
{
    "Date": "2018-09-01",
    "Amount": -12.3
}
```

**Future enhancements**

*These will all be new api endpoints*

| Verb     | Path                                                       | Description
|----------|------------------------------------------------------------|--------------------------------------------------------
| `GET`    | `/api/Accounts/{string:number}`                            | Get an account by "Account number"
| `GET`    | `/api/Accounts/search/{string:name}`                       | Get list of accounts matching a "Name" -- user search case
| `GET`    | `/api/Accounts/{id:guid}/Transactions/today`               | Get list of transactions for an account for today
| `GET`    | `/api/Accounts/{id:guid}/Transactions/{string:datetimes}`  | Get list of transactions for an account between two dates
| `GET`    | `/api/Accounts/{string:datetime}`                          | Get list of transactions for all accounts for a given date
| `GET`    | `/api/Accounts/{string:datetime}/Transactions`             | Get total balance of all accounts for a given date