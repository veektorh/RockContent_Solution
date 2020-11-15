# Rock Content Coding Challenge Solution


### Backend
- Asp net core 3.1
- Entity Framework
- MsSQL

### Frontend
- React

### HTTP Response Codes

Each response will be returned with one of the following HTTP status codes:

- `200` `OK` The request was successful
- `400` `Bad Request` There was a problem with the request (malformed)
- `404` `Not Found` An attempt was made to access a resource that does not exist in the API
- `500` `Server Error` An error on the server occurred


#### API Routes

| URI                                                     | HTTP Method | Description                               |
| ------------------------------------------------------- | ----------- | ----------------------------------------- |
| articles                                                | `GET`       | Fetch all articles                        |
| articles/like/{id}                                      | `POST`      | Like an article                           |
