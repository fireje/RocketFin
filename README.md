# RocketFin Assigment - Joseph D'Amato

#### The backen api is written with .Net7.0. The below are information about the controllers
 - The Intrumenent Controller: The GET method will retreive the instrument details by calling the IYH Finance API
 - The Share Controller: The GET method will connect to the SQLite DB to retreive the portfolio. The POST method inserts data into the SQLite DB
 
Follow the below steps to build and run the API as a docker container. 

- Open CMD and go the directory where is the RocketFin.Api folder
- Execute this command to build the image `docker build --file Dockerfile --tag rocketfin.api .`
- Execute this command to run the image `docker run --name RocketFinApi -p 8020:80 -d rocketfin.api`

#### SQLLite:
- It has one table called Ledger. The below are the columns
     
    - Id - Primary key and auto increment
     - TransactionId
     - TransactionTimeStampUTC
     - InstrumentName
     - NumberOfShares
     - Price
    
Since it is a for demo there is no need to add volumn while running the docker command


### Testing Project using the Xunit
- It tests the domain

### Frontend is built using React
- The Portfolio page retreives the user portfolio. The user can also search by the instrument name. [Click here](http://localhost:3000/portfolio) to access the portfolio page 
- The Buy Share provides the possibality to buy shares. The user has to search for the Stock by entering the ticker symbol (example: MSFT,AAPL,GOOG,GOOGL,AMZN). Once the Stock information is retreived the user can place the order. [Click here](http://localhost:3000/shares) to access the buy Shares page 

Follow the below steps to build and run the Frontend as a docker container. 

- Open CMD and go the directory where is the rocketfin.ui folder
- Execute this command to build the image `docker build --file Dockerfile --tag rocketfin.ui .`
- Execute this command to run the image `docker run --name RocketFinUI -p 3000:3000 -d rocketfin.ui`

