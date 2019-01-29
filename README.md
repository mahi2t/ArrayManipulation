# ArrayManipulation
ArrayManipulation with out using LINQ or Built in array functions


## Reverse array items.

Request:
http://localhost:57313/api/arraycalc/reverse?productIds=222&productIds=33&productIds=443&productids=100

Response:
[100,443,33,222]

## Delete an item from array.

Request:
http://localhost:57313/api/arraycalc/deletepart?position=17&productIds=100&productIds=6&productIds=31&productIds=92&productIds=50&productIds=65&productids=39&productIds=72

Response:
http://localhost:57313/api/arraycalc/deletepart?position=3&productIds=100&productIds=6&productIds=31&productIds=92&productIds=50&productIds=65&productids=39&productIds=72
[100,6,92,50,65,39,72]

Note: if the position is zero or greater than the productIds length then does nothing.
