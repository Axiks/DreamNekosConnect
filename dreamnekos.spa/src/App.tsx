import './App.css'
import Home from './Home'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import ErrorPage from "./Error-Page";
import InterestView from './InterestType';
import InterestTypeView from './InterestTypeView';
import { useEffect, useState } from 'react';
import { InterestResponse, InterestTypeResponse } from './services/openapi';
import { getInterests, getInterestTypes } from './services/apiWrapper';

function App() {
  const [interests, setInterests] = useState<InterestResponse[]>([]);
  const [interestsTypes, setData] = useState<InterestTypeResponse[]>([]);

    useEffect(() => {
      // declare the data fetching function
      const fetchData = async () => {
        const data = await getInterestTypes();
        console.log(data)
        setData(data)

        const interests = await getInterests();
        console.log(interests)
        setInterests(interests)
      }
    
      // call the function
      fetchData()
        // make sure to catch any error
        .catch(console.error);
    }, [])

    const router = createBrowserRouter([
      {
        path: "/",
        element: <Home />,
        errorElement: <ErrorPage />,
        children: [
          {
            path: "/",
            element: <InterestView interests={interests} />,
          },
          {
            path: "/interests",
            element: <InterestView interests={interests} />,
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
        <div className="container p-4 text-xl font-medium mx-auto">
          Vanilla
        </div>
        <RouterProvider router={router} />
      </div>
  )
}

export default App