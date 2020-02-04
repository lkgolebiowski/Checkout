1. Go to solution folder and run command: docker-compose up -d
2. Go to http://localhost:5000/swagger

3. Endpoints
[POST] api/payments
Validaiton: 
if card number starts with 1234 the processing will return: Unsuccessful.

[GET]  api/payments/:id


Things to improve:
1. Refactor application structure into several projects based for example on onion architecture.
2. Add authentication and authorization (cookies/jwt)
3. Add caching (Redis)
4. Add persistent database
5. Add logging (serilog)
6. Add metrics (appmetrics + influxdb + graphana)
7. Create CI pipeline (TeamCity + Octopus)
8. Add key vault for secret and configurations (Azure, Hashicorp)
9. Use docker orchestrator like Rancher to manage containers
10. Add unit tests, and automated tests


