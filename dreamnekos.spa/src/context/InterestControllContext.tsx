import { ReactChild, ReactChildren, ReactFragment, ReactPortal, createContext, useEffect, useState } from "react";
import { InterestResponse, InterestTypeResponse, UpdateInterestRequest } from "../services/openapi";
import { getInterests, updateInterests, getInterestTypes, deleteInterests } from "../services/apiWrapper";
import React from "react";

interface InterestControllService {
    interests: InterestResponse[],
    typesOfInterests: Promise<InterestTypeResponse[]>,
    updateInterest: (interestId: string, requestBody: UpdateInterestRequest) => Promise<void> | null,
    deleteInterest: (interestId: string) => Promise<void>
}

// function loadTypesOfInterests() {
//   let typesOfInterests: InterestTypeResponse[] | undefined;

//   const fetchData = () => {
//     return Promise.resolve(getInterestTypes())
//       .then(data => {
//         typesOfInterests = data;
//       })
//       .catch(err => {
//         console.error(err);
//         typesOfInterests = undefined;
//       });
//   };

//   fetchData().then(() => {
//     console.log("TEST loadTypesOfInterests");
//     console.log(typesOfInterests);
//     console.log("TEST END loadTypesOfInterests");
//   });

//   return typesOfInterests;
// }

export const defaultInterestControllService: InterestControllService = {
  interests: [],
  typesOfInterests: getInterestTypes(),
  updateInterest:  (interestId: string, requestBody: UpdateInterestRequest) => null
};

export const InterestControllContexttt = createContext(defaultInterestControllService);

interface AuxProps {
  children:  React.ReactNode;
}

export const InterestControllProvider = ({ children }: AuxProps) => {

    const [interests, setInterests] = useState<InterestResponse[]>([]);

    useEffect(() => {
      // declare the data fetching function
      const fetchData = async () => {
        const interests = await getInterests();
        console.log("Load interests!!")
        console.log(interests)
        setInterests(interests)
      }
    
      // call the function
      fetchData()
        // make sure to catch any error
        .catch(console.error);
    }, [])

    const interestUpdate = async (interestId: string, requestBody: UpdateInterestRequest) => {
      const newValue = await updateInterests(interestId, requestBody)

      const elemIndex = interests.findIndex(e => e.interestId === interestId);

      if (elemIndex){
        interests[elemIndex].name = newValue.name;
        interests[elemIndex].interestType = newValue.interestType;
      }

      setInterests([...interests])
    }

    const interestDelete = async (interestId: string) => {
      await deleteInterests(interestId);

      const elem = interests.findIndex(e => e.interestId === interestId);

      if (elem > -1) { // only splice array when item is found
        interests.splice(elem, 1); // 2nd parameter means remove one item only
      }
      setInterests([...interests])
    };

    const InterestControllService: InterestControllService = {
      interests: interests,
      typesOfInterests: getInterestTypes(),
      updateInterest: interestUpdate,
      deleteInterest: interestDelete
    };

    return (
      <InterestControllContexttt.Provider value={ InterestControllService }>
        {children}
      </InterestControllContexttt.Provider>
    );
  };