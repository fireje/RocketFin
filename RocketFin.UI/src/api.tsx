import axios from "axios";
import {
    PortfolioResponse,
    InstrumentResponse
} from "./datamodel";


export interface SearchResponse {
    data: PortfolioResponse[];
}


export const getPortfolio = async (query: string) => {
    try {
        const data = await axios.get<SearchResponse>(
            `${process.env.REACT_APP_API_URL}api/Shares?ticker=${query}`
        );

        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
};

export const getInstrument = async (query: string) => {
    try {

        const data = await axios.get<InstrumentResponse>(
            `${process.env.REACT_APP_API_URL}api/Instrument?ticker=${query}`
        );

        return data;
    } catch (error: any) {
        console.log("error message: ", error.message);
    }
};



export const purchaseStock = async (numberOfShares: number, instrumentName: string, price : number ) => {
    const data = await axios.post(`${process.env.REACT_APP_API_URL}api/Shares`, {
        numberOfShares: numberOfShares,
        instrumentName: instrumentName,
        price : price
    })
    .then((response) => {
        console.log(response);
    });
};



