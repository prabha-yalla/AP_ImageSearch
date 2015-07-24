##### Project:
Helps the user to search images by entering a keyword. It uses AP Content API to fetch and display the images in a responsive UI.

##### Architecture:

##### AngularJS-Client ------> ASP.NET Web API (Proxy Layer) ------> AP Content API
- Client sends the "keyword” entered by the user to proxy layer.

- Proxy layer appends the API Key to the request and forwards it the AP Content API.

- Proxy layer get the image url from AP Content API and send the response to Angular Client.

- Angular client parses the JSON response and displays the images.

- Since image request also requires API Key to be appended, they are routed via Proxy Layer.

##### ASP.NET Web API (Proxy Layer) 
This has 2 services one to support the search request and second one to support the image request

##### Architecture Highlights:

Instead of requesting data from “AP Content API “directly through AngularJS application, I have created a ASP.NET Web API service to handle the requests from the client to secure private information in this case API Key. Otherwise the web application can be inspected in browser and API Key of the Company will be exposed to outside world.

##### Technologies:

AngularJS, HTML5, CSS3, JavaScript, ASP.NET Web API, C#, ASP.NET MVC, IIS Express

##### Steps to download and run the sample:
-	Download the sample as Zip and extract the files to a folder.
-	Open the solution in Visual Studio.
-	Set “APM.client” as a startup project.
-	Build and run the solution(This takes to http://localhost:52436/index.html)






