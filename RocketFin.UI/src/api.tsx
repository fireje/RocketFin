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
            `http://localhost:8020/api/Shares?ticker=${query}`
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
            `http://localhost:8020/api/Instrument?ticker=${query}`
        );

        return data;
    } catch (error: any) {
        console.log("error message: ", error.message);
    }
};



export const purchaseStock = async (numberOfShares: number, instrumentName: string, price : number ) => {
    const data = await axios.post(`http://localhost:8020/api/Shares`, {
        numberOfShares: numberOfShares,
        instrumentName: instrumentName,
        price : price
    })
    .then((response) => {
        console.log(response);
    });
};



