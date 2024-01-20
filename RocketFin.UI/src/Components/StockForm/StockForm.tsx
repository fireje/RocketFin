import { SrvRecord } from 'dns';
import React from 'react'

interface Props {
    onSubmit: (data: SubmissionFormData) => void;
    instrument: string;
    price: number;
}

export interface SubmissionFormData {
    numberOfStocks: number;
    instrumentName: string;
    strockPrice : number
}

const StockForm = ({ onSubmit, instrument, price }: Props) => {
    const [FormFilledData, setFormFilledData] = React.useState<SubmissionFormData>({ numberOfStocks: 0, instrumentName: instrument, strockPrice: price  });

    function handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setFormFilledData({ ...FormFilledData, [name]: value });
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        onSubmit(FormFilledData);
    }

     return (

         <>
       

        <form onSubmit={handleSubmit}>
            
            <b>Number of Stock: </b>
                 <input type="number" name="numberOfStocks"  onChange={handleInputChange} />
            
            <br />
                 <input name="instrumentName" type="hidden" onChange={handleInputChange}  />
  
            <button type="submit">Submit</button>
             </form>

         </>
    );
}

export default StockForm;