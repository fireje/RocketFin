import React, { useEffect, ChangeEvent, useState, SyntheticEvent } from "react";
import { PortfolioResponse } from "../../datamodel";
import { getPortfolio } from "../../api";
import Portfolio from "../../Components/Portfolio/Portfolio";
import PortfolioRow from "../../Components/PortfolioRow/PortfolioRow";
import Search from "../../Components/Search/Search";



type Props = {};

const PortfolioPage = (props: Props) => {

    const [portfolioResult, setPortfolioResult] = useState<PortfolioResponse[]>([]);
    const [search, setSearch] = useState<string>("");
    const [serverError, setServerError] = useState<string | null>(null);

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    };

    const onSearchSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const result = await getPortfolio(search);
        //setServerError(result.data);
        if (typeof result === "string") {
            setServerError(result);
        } else if (Array.isArray(result.data)) {
            setPortfolioResult(result.data);
            console.log(result.data);
        }
    };


    useEffect(() => {
        const getPortfolioInit = async () => {
            const result = await getPortfolio("");
            if (typeof result === "string") {
                setServerError(result);
            } else if (Array.isArray(result.data)) {
                setPortfolioResult(result.data);
            }
        };
        getPortfolioInit();
    }, []);

   
    console.log(portfolioResult[0]);

    return (
        <>
            <Search
                onSearchSubmit={onSearchSubmit}
                search={search}
                handleSearchChange={handleSearchChange}
                searchText="Search Portoflio"
            />

            <div>
                            
                {portfolioResult.length > 0 &&   <PortfolioRow />}
                {portfolioResult.length > 0 ? (                   
                   

                    portfolioResult.map((result) => {
                        return (
                            <Portfolio key={result.transactionId} id={result.transactionId} searchResult={result} />
                        );
                    })

                ) : (
                    <p >
                            No results!<br />
                            
                    </p>
                )}
            </div>



        </>
    );
};

export default PortfolioPage;