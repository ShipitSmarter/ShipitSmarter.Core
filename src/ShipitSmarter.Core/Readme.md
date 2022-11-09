# ShipitSmarter Core functionality

## Exceptions

At ShipItSmarter, we have the preference to throw exceptions rather than returning null. This is for readability/clarity reasons as well as maintainability reasons.

'DomainException' is the base exception for all other exceptions. It is based upon the 'ProblemDetails' class so that it can bubble up and be handled at ta higher level
