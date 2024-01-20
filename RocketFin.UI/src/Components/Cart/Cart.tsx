//import React, { SyntheticEvent, ChangeEvent } from "react";
//import { InstrumentResponse } from "../../datamodel";

//interface FormProps {
//    id: string;
//    searchResult: InstrumentResponse;
//    onSubmit: (data: FormFilledData) => void;
//}

//interface FormFilledData {
//    name: string;
//    age: number;
//}



//function  Cart ({ onSubmit, searchResult }: FormProps) {

//    const [FormFilledData, setFormFilledData] = React.useState<FormFilledData>({ name: '', age: 0 });

//    function handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
//        const { name, value } = event.target;
//        setFormFilledData({ ...FormFilledData, [name]: value });
//    }


//    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
//        event.preventDefault();
//        onSubmit(FormFilledData);
//    }




//    return (

//        <>
//            <div className="divRow">
//                <div className="divCol">
//                    <p> {searchResult.ask}</p>
//                </div>
//                <div className="divCol">
//                    <p> {searchResult.cangeInPercentageCurrentDay}</p>
//                </div>
//                <div className="divCol">
//                    <p> {searchResult.bid}</p>
//                </div>
//                <div className="divCol">
//                    <p> {searchResult.name}</p>
//                </div>
//                <div className="divCol">
//                    <p> {searchResult.currentPrice}</p>
//                </div>

//            </div>
//            <form onSubmit={handleSubmit}>
//                <label>
//                    Name:
//                    <input type="text" name="name" value={FormFilledData.name} onChange={handleInputChange} />
//                </label>
//                <br />
//                <label>
//                    Age:
//                    <input type="number" name="age" value={FormFilledData.age} onChange={handleInputChange} />
//                </label>
//                <br />
//                <button type="submit">Submit</button>
//            </form>
//        </>



//    );
//};

//export default Cart;


import React from 'react'

interface FormProps {
    onSubmit: (data: FormFilledData) => void;
}

export  interface FormFilledData {
    name: string;
    age: number;
}

export const Form = ({ onSubmit }: FormProps) => {
    const [FormFilledData, setFormFilledData] = React.useState<FormFilledData>({ name: '', age: 0 });

    function handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setFormFilledData({ ...FormFilledData, [name]: value });
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        onSubmit(FormFilledData);
    }

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Name:
                <input type="text" name="name" value={FormFilledData.name} onChange={handleInputChange} />
            </label>
            <br />
            <label>
                Age:
                <input type="number" name="age" value={FormFilledData.age} onChange={handleInputChange} />
            </label>
            <br />
            <button type="submit">Submit</button>
        </form>
    );
}

export default Form;