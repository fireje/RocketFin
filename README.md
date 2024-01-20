# RocketFin

The solution is divided into three projects

The API connects with the SQLLite db. The database has one table called Ledger. 

To create build and create the API container execute the below. To execute go the directory where is the RocketFin.API
Nb. Keep the port as it is since the ui is refering to the url with 8020

docker build --file Dockerfile --tag rocketfin.api .

docker run --name RocketFinApi -p 8020:80 -d rocketfin.api 

The UI conencts with the API
  Click on the portfolio to retreive the ledgers table, you can search by the  instrument name. The search has to be the extact name. 
  Click on Buy Share to purchase a stock, in the search enter th ticker like AAPL to retreive the details. Once the details are retrieve you can purchase the stock

Use the below commands to build and run the application in docker container

docker build --file Dockerfile --tag rocketfin.ui .

docker run --name RocketFinUI -p 3000:3000 -d rocketfin.ui
