import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import PortfolioPage from "../Pages/PortfolioPage/PortfolioPage";
import SharesPage from "../Pages/SharesPage/SharesPage";


export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "portfolio", element: <PortfolioPage /> },
            { path: "shares", element: <SharesPage /> },
        ],
    },
]);