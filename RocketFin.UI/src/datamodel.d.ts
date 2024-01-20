export interface PortfolioResponse {

    instrumentName;
    transactionId;
    numberOfShares;
    pricePerShare;
    totalPrice;
    timestamp;
}

export interface InstrumentResponse {
    name; 
    bid;
    ask;
    currentPrice;
    changeInValueCurrentDay;
    changeInPercentageCurrentDay;
}
