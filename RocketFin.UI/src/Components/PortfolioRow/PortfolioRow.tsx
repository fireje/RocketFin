import React, { SyntheticEvent } from "react";
import './PortfolioRow.css';

interface Props {
   
}

const PortfolioRow: React.FC<Props> = ({

}: Props): JSX.Element => {

    
    return (
        <div className="divRow">
            <div className="divHeader">
                <p> Transaction Id</p>
            </div>
            <div className="divHeader">
                <p> Instrument</p>
            </div>
            <div className="divHeader">
                <p> Number of Shares</p>
            </div>
            <div className="divHeader">
                <p> Price per Share</p>
            </div>
            <div className="divHeader">
                <p> Total Price</p>
            </div>
            <div className="divHeader">
                <p> Timestamp</p>
            </div>
        </div>
    );
};

export default PortfolioRow;