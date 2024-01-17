# ShipitSmarter.Core

ShipitSmarter Core is an opinionated Nuget package with the intention of being reusable across multiple ShipitSmarter projects and SDK's.

Specific documentation and usage of the library can be found [here](src/ShipItSmarter.Core/README.md)

## Features
* Exceptions
  * Set of commonly used exceptions within all applications
* Use cases
  * Use case dispatcher, will validate the input for you before calling Handle on the use case
* Validation
  * Implement your own Validator using the IValidationService

## Versioning
This is based on the `dotnet` version the code is build for.  
So dotnet 8.x will use `v8.x.x` as a version for the package.

## Getting Started

Install via Nuget

```
dotnet add package ShipitSmarter.Core 
```



## Roadmap

There is no specific roadmap defined for this project and we will be adding things as we see the need for them arise or we find a lot of similar code in use in other projects.

## License

This project is licensed under MIT