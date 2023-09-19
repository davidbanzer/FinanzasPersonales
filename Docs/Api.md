
## Auth

### Register
```js
POST {{host}}/auth/register
```

#### Register Request
```json
{
  "fisrtName": "David",
  "lastName": "Banzer",
  "email": "davidbanzer@gmail.com",
  "password":"P@ssword1"
}
```

### Login
```js
POST {{host}}/auth/login
```

#### Login Request
```json
{
  "email": "davidbanzer@gmail.com",
  "password":"P@ssword1"
}