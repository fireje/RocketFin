import React, { ChangeEvent, useState, SyntheticEvent, FormEvent } from "react";
import './Search.css';


interface Props {
    onSearchSubmit: (e: SyntheticEvent) => void;
    search: string | undefined;
    handleSearchChange: (e: ChangeEvent<HTMLInputElement>) => void;
    searchText: string
}


const Search: React.FC<Props> = ({
    onSearchSubmit,
    search,
    handleSearchChange,
    searchText
}: Props): JSX.Element => {
    return (
        <section className="searchSection">
            <div className="">
                <form
                    className=""
                    onSubmit={onSearchSubmit}
                >
                    <input
                        className="searchTextBox"
                        id="search-input"
                        placeholder={searchText}
                        value={search}
                        onChange={handleSearchChange}
                    />

                    <button className="searchButton" type="submit">Search</button>
                </form>
            </div>
        </section>
    );
};

export default Search;