import { createContext, useEffect, useState } from "react";
import { CreateInterestRequest, InterestResponse, InterestTypeResponse, UpdateInterestRequest } from "../../services/openapi";
import { getInterests, updateInterests, getInterestTypes, deleteInterests, createInterests } from "../../services/apiWrapper";
import React from "react";

interface InterestControllService {
    interests: InterestResponse[],
    typesOfInterests: Promise<InterestTypeResponse[]>,
    createInterest: (requestBody: CreateInterestRequest) => Promise<void> | null,
    updateInterest: (interestId: string, requestBody: UpdateInterestRequest) => Promise<void> | null,
    deleteInterest: (interestId: string) => Promise<void> | null
}

export const defaultInterestControllService: InterestControllService = {
  interests: [],
  typesOfInterests: getInterestTypes(),
  createInterest: (requestBody: UpdateInterestRequest) => null,
  updateInterest: (interestId: string, requestBody: UpdateInterestRequest) => null,
  deleteInterest: (interestId: string) => null
};

export const InterestControllContext = createContext(defaultInterestControllService);

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

    const interestCreate = async (requestBody: UpdateInterestRequest) => {
      var newInterest = await createInterests(requestBody)
      interests.push(newInterest)
      setInterests([...interests])
    }

    const InterestControllService: InterestControllService = {
      interests: interests,
      typesOfInterests: getInterestTypes(),
      createInterest: interestCreate,
      updateInterest: interestUpdate,
      deleteInterest: interestDelete
    };

    return (
      <InterestControllContext.Provider value={ InterestControllService }>
        {children}
      </InterestControllContext.Provider>
    );
  };