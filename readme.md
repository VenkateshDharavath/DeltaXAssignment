# **API Documentation**

## **1. Actor**
- To Create an actor, Send a `POST` Request like following

    **Endpoint**:
    > https://localhost:44322/api/v1/Actors

    **Content-Type** 
    > application/json

    **Body**
    
        {
            "name": "Venkatesh",
            "bio": "Some bio",
            "dateofBirth": "2022-07-25T19:29:24.668Z",
            "gender": "Male"
        }

    Response
    
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 201,
            "Result": {
                "id": "e4078c10-e20f-459b-9f7d-3a6d6041f3c0",
                "name": "Venkatesh",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T19:29:24.668Z",
                "gender": "Male"
            }
        }
- To Get a single record, Send a `GET` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Actors/e4078c10-e20f-459b-9f7d-3a6d6041f3c0

    **Response**
        
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "e4078c10-e20f-459b-9f7d-3a6d6041f3c0",
                "name": "Venkatesh",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T19:29:24.668",
                "gender": "Male"
            }
        }
- To Get paginated list of records, Send a `GET` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Actors?PageNumber=1&PageSize=2

    **Response**
        
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "items": [
                {
                    "id": "8c3bcdd8-c8aa-4317-8016-511690807335",
                    "name": "Venkatesh Actor",
                    "bio": "Some bio",
                    "dateofBirth": "2022-07-25T16:12:21.202",
                    "gender": "Male"
                },
                {
                    "id": "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1",
                    "name": "Dharavath Actor",
                    "bio": "SomeBio",
                    "dateofBirth": "2022-07-25T16:22:12.739",
                    "gender": "Male"
                }
                ],
                "pageNumber": 1,
                "totalPages": 2,
                "totalCount": 3,
                "hasPreviousPage": true,
                "hasNextpage": true
            }
        }
- To update an existing record, send a `PUT` request like below
    
    **Endpoint**
    > https://localhost:44322/api/v1/Actors/8c3bcdd8-c8aa-4317-8016-511690807335

    **Content-Type**
    > application/json

    **Body**

        {
            "id": "8c3bcdd8-c8aa-4317-8016-511690807335",
            "name": "Venkatesh Dharavath",
            "bio": "Some bio",
            "dateofBirth": "2022-07-25T16:12:21.202",
            "gender": "Male"
        }
    
    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "8c3bcdd8-c8aa-4317-8016-511690807335",
                "name": "Venkatesh Dharavath",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T16:12:21.202",
                "gender": "Male"
            }
        }

- To delete an existing record, send a `DELETE` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Actors/8c3bcdd8-c8aa-4317-8016-511690807335

    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": ""
        }

## **2. Movie**
