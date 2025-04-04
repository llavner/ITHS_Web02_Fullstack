# CRUD-API For E-commerce
**Version 1.0**  
This API interacts with the backend service of an E-commerce application.  
It uses endpoints such as Categories, Products, and Users.

## Content

- [Category](#category)
- [Product](#product)
- [User](#user)

## Category

### List all Categories:
**GET /api/Category**  
Required parameter: none  
[No body]

```json
Response
200 OK
[
    {
        "id": 29,
        "name": "MiniDisc"
    },
    {
        "id": 30,
        "name": "FlexiDisc"
    },
    {
        "id": 31,
        "name": "DVD"
    }
]
```

### List specific Category:

**GET /api/Category/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "31"
}

Response
200 OK

Response Body:
{
    "id": "0",
    "name": "DVD"
}
```

### Create a new Category:

**POST /api/Category**
```json
Request Body:
{
    "id": "0",
    "name": "DVD"
}

Response
200 OK

Response Body:
{
    "message": "Added category DVD",
    "id": 31,
    "name": "DVD"
}
```

### Update specific Category:

**PUT /api/Category/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "32",
    "name": "CDr"
}

Response
200 OK

Response Body:
{
    "id": "32",
    "name": "CDr"
}
```

### Delete specific Category:

**DELETE /api/Category/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "32"
}

Response
200 OK

Response Body:
{
    "message": "CDr deleted"
}
```
[To the top](#content)

## Product

### List all Products:

**GET /api/Product**

Required parameter: none

[No Request body]
```json

Response
200 OK

Response body:

[
  {
    "id": 28,
    "pictureUrl": "Beastie-Boys-License-To-Ill.webp",
    "artist": "Beastie Boys",
    "albumTitle": "License to Ill",
    "price": 159,
    "stockQuantity": 50,
    "isProductAvailable": true,
    "categoryId": 25,
    "category": {
      "id": 25,
      "name": "CD"
    }
  },
  {
    "id": 29,
    "pictureUrl": "Beatles-Abbey-Road.webp",
    "artist": "Beatles",
    "albumTitle": "Abbey Road",
    "price": 159,
    "stockQuantity": 50,
    "isProductAvailable": true,
    "categoryId": 25,
    "category": {
      "id": 25,
      "name": "CD"
    }
  },
]
```

### List specific Product:

**GET /api/Product/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "103"
}

Response
200 OK

Response Body:
{
    "id": "103",
    "name": "Butter",
    "price": 25.00,
    "categoryId": 1
}
```

### Create a new Product:
**POST /api/Product**

Required parameter: categoryId (in this case 25 for CD)
```json
Request Body:
{
  "id": 0,
  "artist": "string",
  "albumTitle": "string",
  "pictureUrl": "string",
  "price": 50000,
  "stockQuantity": 500,
  "isProductAvailable": true,
  "categoryId": 25,
  "category": {
    "id": 0,
    "name": "string"
    }
}

Response
200 OK

Response Body:
{
  "message": "Added Product string string",
  "product": {
    "id": 56,
    "pictureUrl": "string",
    "artist": "string",
    "albumTitle": "string",
    "price": 50000,
    "stockQuantity": 500,
    "isProductAvailable": true,
    "categoryId": 25,
    "category": null
  }
}
```

### Update specific Product:

**PUT /api/Product/{id}**

Required parameter: id
```json
Request Body:
{
  "id": 56,
  "pictureUrl": "string",
  "artist": "Judas Priest",
  "albumTitle": "Painkiller",
  "price": 199,
  "stockQuantity": 50,
  "isProductAvailable": true,
  "categoryId": 0,
  "category": {
    "id": 0,
    "name": "string"
  }
}

Response
200 OK

Response Body:
{
  "message": "56 has been updated."
}
```

### Delete specific Product:

**DELETE /api/Product/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "56"
}
Response

200 OK
Response Body:
{
  "message": "56 deleted."
}
```
[To the top](#content)

## User

### List specific User:

**GET /api/User/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "103"
}

Response
200 OK

Response Body:
{
    "id": "103",
    "name": "John Doe",
    "email": "john.doe@example.com"
}
```
### List specific User:

**GET /api/User/{id}**

Required parameter: id
```json
Request Body:
{
    "id": "2"
}

Response
200 OK

Response Body:

{
    "id": 2,
    "firstName": "Jane",
    "lastName": "Doe",
    "email": "string",
    "address": "string",
    "phoneNumber": "string",
    "isAdmin": true
}
```

### Create a new User:

**POST /api/User**

Required parameter: none

```json
Request Body:
{
    "id": 0,
    "firstName": "John",
    "lastName": "Doe",
    "email": "string",
    "address": "string",
    "phoneNumber": "string",
    "isAdmin": false
}

Response
200 OK

Response Body:
{
    "message": "Added user John Doe string",
    "user": {
        "id": 2,
        "firstName": "John",
        "lastName": "Doe",
        "email": "string",
        "address": "string",
        "phoneNumber": "string",
        "isAdmin": false
    }
}
```

### Update specific User:

**PUT /api/User/{id}**

Required parameter: id
```json
Request Body:

{
    "id": 2,
    "firstName": "Jane",
    "lastName": "Doe",
    "email": "string",
    "address": "string",
    "phoneNumber": "string",
    "isAdmin": true
}

Response
200 OK

{
    "message": "User has been updated."
}
```
### Delete User:

**PUT /api/User/{id}**

Required parameter: id
```json
Request Body:

{
    "id": 2,
}

Response
200 OK

{
    "message": "User with Id: 2 deleted."
}
```

[Top the top](#content)
