import React, { SyntheticEvent } from "react";
import { PortfolioResponse } from "../../datamodel";
import './Portfolio.css';

interface Props {
    id: string;
    searchResult: PortfolioResponse;
}

const Portfolio: React.FC<Props> = ({
    id,
    searchResult,
}: Props): JSX.Element => {

   
    return (
        <div className="divRow">
            <div className="divCol">
                <p> {searchResult.transactionId}</p>
            </div>
            <div className="divCol">
                <p> {searchResult.instrumentName}</p>
            </div>
            <div className="divCol">
                <p> {searchResult.numberOfShares}</p>
            </div>
            <div className="divCol">
                <p> {searchResult.pricePerShare}</p>
            </div>
            <div className="divCol">
                <p> {searchResult.totalPrice}</p>
            </div>
            <div className="divCol">
                <p> {searchResult.timestamp}</p>
            </div>
        </div>
    );
};

export default Portfolio;