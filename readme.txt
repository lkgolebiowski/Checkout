1. Go to solution folder and run command: docker-compose up -d
2. Go to http://localhost:5000/swagger

3. Endpoints
[POST] api/payments
Validaiton: 
if card number starts with 1234 the processing will return: Unsuccessful.

[GET]  api/payments/:id

