# Refactoring Assessment

This repository contains a terribly written Web API project. It's terrible on purpose, so you can show us how we can improve it.

## Getting Started

Fork this repository, and make the changes you would want to see if you had to maintain this api. To set up the project:

 - Open in Visual Studio (2015 or later is preferred)
 - Restore the NuGet packages and rebuild
 - Run the project
 
 Once you are satisied, replace the contents of the readme with a summary of what you have changed, and why. If there are more things that could be improved, list them as well.

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

Models should conform to the following formats:

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

**Refactor for maintainability**

- Added services to handle all SQL queries, making it easier to maintain and make changes
- removed sql methods from models, moved to new services ... models should be only concerned with properties, fields, and get - set methods.
- Removed sql queries from controllers, moved to new services .. api contract remains the same, so earlier users of the api endpoints will still recieve same result.

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
