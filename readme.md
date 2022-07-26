# **DeltaX Assignment**
`Clean Architecture` was implemented in the project as an N-Tier application. The APIs are created only to create the mock screens provided. The Database was designed keeping mock screens in mind.

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


## **2. Producer**
- To Create a producer, Send a `POST` Request like following

    **Endpoint**:
    > https://localhost:44322/api/v1/Producers

    **Content-Type** 
    > application/json

    **Body**
    
        {
            "name": "Some Producer",
            "bio": "Some bio",
            "dateofBirth": "2022-07-25T20:04:09.746Z",
            "company": "Company A",
            "gender": "Male"
        }

    Response
    
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                "name": "Some Producer",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T20:04:09.746Z",
                "company": "Company A",
                "gender": "Male"
            }
        }
- To Get a single record, Send a `GET` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Producers/981b71eb-6122-4c5b-bc4b-cc94d6dfc88d

    **Response**
        
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                "name": "Some Producer",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T20:04:09.746Z",
                "company": "Company A",
                "gender": "Male"
            }
        }
- To Get paginated list of records, Send a `GET` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Producers?PageNumber=1&PageSize=2

    **Response**
        
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "items": [
                {
                    "id": "501287ff-7787-4804-8886-47ed4dc06bbe",
                    "name": "Venkatesh Producer",
                    "bio": "Some Bio",
                    "dateofBirth": "2022-07-25T16:21:18.004",
                    "company": "X Company",
                    "gender": "Male"
                },
                {
                    "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                    "name": "Some Producer",
                    "bio": "Some bio",
                    "dateofBirth": "2022-07-25T20:04:09.746",
                    "company": "Company A",
                    "gender": "Male"
                }
                ],
                "pageNumber": 1,
                "totalPages": 1,
                "totalCount": 2,
                "hasPreviousPage": true,
                "hasNextpage": false
            }
        }
- To update an existing record, send a `PUT` request like below
    
    **Endpoint**
    > https://localhost:44322/api/v1/Producers/501287ff-7787-4804-8886-47ed4dc06bbe

    **Content-Type**
    > application/json

    **Body**

        {
            "id": "501287ff-7787-4804-8886-47ed4dc06bbe",
            "name": "Venkatesh Producer 2",
            "bio": "Some Bio",
            "dateofBirth": "2022-07-25T16:21:18.004",
            "company": "X Company",
            "gender": "Male"
        }
    
    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "501287ff-7787-4804-8886-47ed4dc06bbe",
                "name": "Venkatesh Producer 2",
                "bio": "Some Bio",
                "dateofBirth": "2022-07-25T16:21:18.004",
                "company": "X Company",
                "gender": "Male"
            }
        }

- To delete an existing record, send a `DELETE` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Producers/501287ff-7787-4804-8886-47ed4dc06bbe

    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": ""
        }



## **3. Movie**
- To upload a poster, Send a `POST` Request like following
    
    **Endpint**
    > https://localhost:44322/api/v1/Movies/UploadPoster

    **Content-Type**
    > multipart/form-data

    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG"
        }

- To Create a movie, send a `POST` request like below. We need to include the list of Actor user Id's and the producer's user id.
    
    **Endpoint**:
    > https://localhost:44322/api/v1/Movies

    **Content-Type** 
    > application/json

    **Body**
    
        {
            "name": "Titanic",
            "plot": "Some plot",
            "dateofRelease": "2022-07-25T20:01:30.150Z",
            "poster": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG",
            "producer": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
            "actors": [
                "8c3bcdd8-c8aa-4317-8016-511690807335",
                "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1"
            ]
        }

    Response
    
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5",
                "name": "Titanic",
                "plot": "Some plot",
                "dateofRelease": "2022-07-25T20:01:30.15Z",
                "poster": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG",
                "producer": {
                "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                "name": "Some Producer",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T20:04:09.746",
                "company": "Company A",
                "gender": "Male"
                },
                "actors": [
                {
                    "id": "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1",
                    "name": "Dharavath Actor",
                    "bio": "SomeBio",
                    "dateofBirth": "2022-07-25T16:22:12.739",
                    "gender": "Male"
                }
                ]
            }
        }
- To Get a single record, Send a `GET` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Movies/6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5

    **Response**
        
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5",
                "name": "Titanic",
                "plot": "Some plot",
                "dateofRelease": "2022-07-25T20:01:30.15",
                "poster": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG",
                "producer": {
                "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                "name": "Some Producer",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T20:04:09.746",
                "company": "Company A",
                "gender": "Male"
                },
                "actors": [
                {
                    "id": "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1",
                    "name": "Dharavath Actor",
                    "bio": "SomeBio",
                    "dateofBirth": "2022-07-25T16:22:12.739",
                    "gender": "Male"
                }
                ]
            }
        }
- To Get paginated list of records, Send a `GET` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Movies?PageNumber=1&PageSize=2

    **Response**
        
        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "items": [
                {
                    "id": "33fe3bcc-3141-4f95-8b73-982604d0d4ad",
                    "name": "string",
                    "plot": "string",
                    "dateofRelease": "2022-07-25T16:21:04.298",
                    "poster": "C:\\Users\\WZ744QS\\OneDrive - EY\\Desktop\\DeltaX\\DeltaX\\API\\Images429b45ec-d025-49ff-9131-46b4f0533131.PNG",
                    "producer": {
                    "id": "501287ff-7787-4804-8886-47ed4dc06bbe",
                    "name": "Venkatesh Producer 2",
                    "bio": "Some Bio",
                    "dateofBirth": "2022-07-25T16:21:18.004",
                    "company": "X Company",
                    "gender": "Male"
                    },
                    "actors": []
                },
                {
                    "id": "6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5",
                    "name": "Titanic",
                    "plot": "Some plot",
                    "dateofRelease": "2022-07-25T20:01:30.15",
                    "poster": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG",
                    "producer": {
                    "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                    "name": "Some Producer",
                    "bio": "Some bio",
                    "dateofBirth": "2022-07-25T20:04:09.746",
                    "company": "Company A",
                    "gender": "Male"
                    },
                    "actors": [
                    {
                        "id": "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1",
                        "name": "Dharavath Actor",
                        "bio": "SomeBio",
                        "dateofBirth": "2022-07-25T16:22:12.739",
                        "gender": "Male"
                    }
                    ]
                }
                ],
                "pageNumber": 1,
                "totalPages": 1,
                "totalCount": 2,
                "hasPreviousPage": true,
                "hasNextpage": false
            }
        }

- To update an existing record, send a `PUT` request like below
    
    **Endpoint**
    > https://localhost:44322/api/v1/Movies/6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5

    **Content-Type**
    > application/json

    **Body**

        {
            "id": "6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5",
            "name": "Titanic",
            "plot": "Some plot",
            "dateofRelease": "2022-07-25T20:01:30.150Z",
            "poster": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG",
            "producer": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
            "actors": [
                "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1",
                "e4078c10-e20f-459b-9f7d-3a6d6041f3c0"
            ]
        }
    
    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": {
                "id": "6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5",
                "name": "Titanic",
                "plot": "Some plot",
                "dateofRelease": "2022-07-25T20:01:30.15Z",
                "poster": "/StaticFiles/Images/f6766868-09fe-44b4-8ef3-cfbc9d86eeb2.PNG",
                "producer": {
                "id": "981b71eb-6122-4c5b-bc4b-cc94d6dfc88d",
                "name": "Some Producer",
                "bio": "Some bio",
                "dateofBirth": "2022-07-25T20:04:09.746",
                "company": "Company A",
                "gender": "Male"
                },
                "actors": [
                {
                    "id": "cde4424b-7f86-45e6-bdf3-bbdd5a743eb1",
                    "name": "Dharavath Actor",
                    "bio": "SomeBio",
                    "dateofBirth": "2022-07-25T16:22:12.739",
                    "gender": "Male"
                },
                {
                    "id": "e4078c10-e20f-459b-9f7d-3a6d6041f3c0",
                    "name": "Venkatesh",
                    "bio": "Some bio",
                    "dateofBirth": "2022-07-25T19:29:24.668",
                    "gender": "Male"
                }
                ]
            }
        }

- To delete an existing record, send a `DELETE` request like below

    **Endpoint**
    > https://localhost:44322/api/v1/Movies/6663e4c5-fcd0-43ef-8cd0-8abb89ec43d5

    **Response**

        {
            "Errors": null,
            "Message": null,
            "Version": "v1",
            "StatusCode": 200,
            "Result": ""
        }
