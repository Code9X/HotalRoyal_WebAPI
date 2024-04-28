API (Application Programming Interface) : it is a way for multiple Application to communicate with each other.

[Get,Post..]	             HTTP Req
Client -->    Rest API     --> Server
       <--	               <--
    JSON/XML	             HTTP Res

* How HTTP Works
   **Request**	| **Response**
   Verb		      | Status Code
   Header	      | Header
   Content	    | Content

*The Request Object 
   Verb - GET    : Fetches the resourse
          POST   : Create a resourse
          PUT    : Update a resourse
          PATCH  : Update specific part of the resourse
          DELETE : Delete a resourse
          More..

   Header - it is the Request's MetaData
          - it has   : Content Type like binary data,JSON File, XML File or Plain File
		                 : Content Length
		                 : Authorization (Who is making the request)
		                 : Accept (which types are accrpted is it JSON,XML...)
   Content(Optional) : HTML,CSS,XML,JSON
		                 : Info for the requuest 
		                 : Blobs etc..

*if the Request is Get then there will be no Content in the Request

The Response Object 
Status Code - 100-199 : Information
	      200-299 : Success (200-OK,201-Created,204-No Content)
	      300-399 : Redircction
	      400-499 : Client Errors (400-bad Req,404-Not found,409-Confict)
	      500-599 : Server Errors (500-internal Server Error)
Header	    - Response's MetaData
	    	      : Content type
	    	      : Content Length
	    	      : Expires (when this response will be invalid)
Content(Optional)     : HTML,CSS,XML,JSON
		      : Info for the requuest 
		      : Blobs etc..
