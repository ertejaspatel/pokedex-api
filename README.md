<br/>

<div align="center">
	<img height="200" src="https://raw.githubusercontent.com/PokeAPI/media/master/logo/pokeapi.svg?sanitize=true" alt="PokeAPI">


<br/>

</div>

<br/>

A RESTful API wrapper for getting basic Pokemon details


## Setup 

- Download/Clone this source code into a working directory

- Install the required dependencies/packages listed in project file  using:

    ```sh
     dotnet restore    
    ```

- Build the project and all of its dependencies:

    ```sh
    dotnet build
    ```

- Run the server using the following command:

    ```sh
    dotnet run
    ```


Visit [https://localhost:5001/swagger/](https://localhost:5001/swagger/) to see the running API and it's living documentation!

Pokemon Api and Translation Api details are configured in appsettings.json file. Create copy of appsettings.json to appsettings.production.json for production use and make appropriate changes based on production env.

## 🤓 API Documentation

### Usage

Send all data requests to:

```
https://localhost:5001/pokemon
```

### Endpoints


- `GET` /pokemon/{name}

- `GET` /pokemon/translated/{name}

### Parameters

#### `GET` /pokemon/{name}

| Parameter     | Required      
| ------------- |:-------------:| 
| name          | `yes`         |


##### URL example
```
https://localhost:5001/pokemon/mewtwo
```

##### Response example
```json
{
  "success": true,
  "message": null,
  "data": {
    "id": 150,
    "name": "mewtwo",
    "habitat": "rare",
    "description": "It was created by\na scientist after\nyears of horrific\fgene splicing and\nDNA engineering\nexperiments.",
    "isLegendary": true
  }
}
```

#### `GET` /pokemon/translated/{name}

| Parameter     | Required      
| ------------- |:-------------:| 
| name          | `yes`         |


##### URL example
```
https://localhost:5001/pokemon/translated/mewtwo
```

##### Response example
```json
{
  "success": true,
  "message": null,
  "data": {
    "id": 150,
    "name": "mewtwo",
    "habitat": "rare",
    "description": "Created by a scientist after years of horrific gene splicing and dna engineering experiments,  it was.",
    "isLegendary": true
  }
}
```

## 🤓 Future Improvements
- Implemnt Logging with NLog like library to write logs to multiple targets
- Implement Caching
- Implement Retry mechanism (ie.Exponential Backoff) for transient fault
- Implement Circuit breaker for long lasting transient fault
- Currently all response are OK 200 even with error, needs to be improved to send proper status code.
- Implement Tests