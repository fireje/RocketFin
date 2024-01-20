import React, { SyntheticEvent } from "react";
import './StockCart.css';
import { InstrumentResponse } from "../../datamodel";
import { SubmissionFormData } from "../../Components/StockForm/StockForm";
import  SubmissionForm  from "../../Components/StockForm/StockForm";

interface Props {
    searchResult: InstrumentResponse;
    handleSubmit: (data: SubmissionFormData) => void;
}

const StockCart: React.FC<Props> = ({
    searchResult,
    handleSubmit
}: Props): JSX.Element => {

    return (
        <div className="cartBox">
            <h1>Stock Information</h1>
            <p><b>Name: </b>{searchResult.name}</p>
            <p><b>Current Price: </b>{searchResult.currentPrice}</p>
            <p><b>Change in percentage (current day): </b>{searchResult.changeInPercentageCurrentDay}%</p>
            <p><b>Change in value (current day): </b>{searchResult.changeInValueCurrentDay}</p>
            <p><b>Bid: </b>{searchResult.ask}</p>
            <p><b>Ask: </b>{searchResult.ask}</p>

            <SubmissionForm onSubmit={handleSubmit} instrument={searchResult.name} price={searchResult.currentPrice} />

        </div>
    );
};

export default StockCart;