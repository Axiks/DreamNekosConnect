import './styles/App.css'
import HomePage from './home/components/HomePage'
import {
  createBrowserRouter,
  Navigate,
  RouterProvider,
} from "react-router-dom";
import ErrorPage from "./error/components/ErrorPage";
import InterestView from './home/components/InterestView';
import InterestTypeView from './home/components/InterestTypeView';
import { useEffect, useState } from 'react';

import { InterestTypeResponse } from './services/openapi';
import { getInterestTypes } from './services/apiWrapper';
import { InterestControllProvider } from './home/context/InterestControllContext';
import Head from './header/components/Head';

function App() {
  const [interestsTypes, setData] = useState<InterestTypeResponse[]>([]);

    useEffect(() => {
      // declare the data fetching function
      const fetchData = async () => {
        const data = await getInterestTypes();
        console.log(data)
        setData(data)
      }
    
      // call the function
      fetchData()
        // make sure to catch any error
        .catch(console.error);
    }, [])

    const router = createBrowserRouter([
      {
        path: "/",
        element: <HomePage />,
        errorElement: <ErrorPage />,
        children: [
          {
            index: true, 
            element: <Navigate to="/interests" replace />
          },
          {
            path: "/interests",
            element: <InterestView />,
          },
          {
            path: "/interestTypes",
            element: <InterestTypeView InterestTypes={interestsTypes} />,
          },
        ]
      },
    ]);

    return (
      <div className="flex flex-col max-w-screen-lg w-full ">
        <Head />
        <InterestControllProvider>
          <RouterProvider router={router} />
        </InterestControllProvider>
      </div>
  )
}

export default App