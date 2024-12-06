Some points to clarify :
If i would have more time i would implement :

Azure Authentication :
- It reads the bearer token from the authorization header in the HTTP request.
- It validates the token.
- It validates the permissions (scopes) in the token.
- It reads the claims that are encoded in the token (optional).
- It responds to the HTTP request.