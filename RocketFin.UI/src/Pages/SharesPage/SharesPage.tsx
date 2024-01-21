import React, { useEffect, ChangeEvent, useState, SyntheticEvent } from "react";
import { InstrumentResponse } from "../../datamodel";
import { getInstrument } from "../../api";
import Search from "../../Components/Search/Search";
import { Form } from "../../Components/Cart/Cart";
import { SubmissionFormData } from "../../Components/StockForm/StockForm";
import StockCart from "../../Components/StockCart/StockCart";
import { purchaseStock } from "../../api";



type Props = {};


const SharesPage = (props: Props) => {

    const [search, setSearch] = useState<string>("");
    const [instrument, setInstrument] = useState<InstrumentResponse>();
    const [purchaseStatus, setPurchaseStatus] = useState<string>("");
    const [formValidation, setFormValidation] = useState<string>("");
    

    const symbols = ["AAPL", "MSFT", "GOOG", "GOOGL", "AMZN", "NVDA", "META"];

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    };

    function handleSubmit (formData: SubmissionFormData) {
        console.log(formData);
        if (formData.numberOfStocks <= 0) {
            setFormValidation("Please enter a valid number of stocks");
        } else {
            purchaseStock(formData.numberOfStocks, formData.instrumentName, formData.strockPrice);
            setSearch("");
            setInstrument(undefined);
            setPurchaseStatus("Purchased " + formData.numberOfStocks + " (" + formData.instrumentName + ")");
        }       
    }

     


    const onSearchSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const result = await getInstrument(search);
        setInstrument(result?.data);
        setPurchaseStatus("");
        console.log(result?.data);
    };

    return (
        <>
            <Search
                onSearchSubmit={onSearchSubmit}
                search={search}
                handleSearchChange={handleSearchChange}
                searchText="Search Share"
            />

        

            {purchaseStatus && (<div>{purchaseStatus}</div>) }


            
            {instrument && <StockCart searchResult={instrument} handleSubmit={handleSubmit} formValidation={formValidation} />}

         
           
        </>
    );
};

export default SharesPage;