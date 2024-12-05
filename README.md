Some points to clarify :
In my understanding, The solution should use the Azure B2C for authentication it means that :

It reads the bearer token from the authorization header in the HTTP request.

It validates the token.

It validates the permissions (scopes) in the token.

It reads the claims that are encoded in the token (optional).

It responds to the HTTP request.