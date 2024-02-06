import { createContext, useEffect, useState } from "react";
import { InterestTypeResponse, UpdateInterestTypeRequest } from "../../services/openapi";
import { deleteInterestTypes, getInterestTypes, updateInterestTypes } from "../../services/apiWrapper";
import React from "react";

interface InterestTypeControllService {
    interestTypes: InterestTypeResponse[],
    updateInterestType: (interestTypeId: string, requestBody: UpdateInterestTypeRequest) => Promise<void> | null,
    deleteInterestType: (interestTypeId: string) => Promise<void> | null
}

export const defaultInterestTypeControllService: InterestTypeControllService = {
  interestTypes: [],
  updateInterestType: (interestTypeId: string, requestBody: UpdateInterestTypeRequest) => null,
  deleteInterestType: (interestTypeId: string) => null
};

export const InterestTypeControllContext = createContext(defaultInterestTypeControllService);

interface AuxProps {
  children:  React.ReactNode;
}

export const InterestTypeControllProvider = ({ children }: AuxProps) => {

    const [interestTypes, setInterestTypes] = useState<InterestTypeResponse[]>([]);

    useEffect(() => {
      // declare the data fetching function
      const fetchData = async () => {
        const interestTypes = await getInterestTypes();
        console.log("Load interests types!!")
        console.log(interestTypes)
        setInterestTypes(interestTypes)
      }
    
      // call the function
      fetchData()
        // make sure to catch any error
        .catch(console.error);
    }, [])

    const interestTypeUpdate = async (interestTypeId: string, requestBody: UpdateInterestTypeRequest) => {
      const newValue = await updateInterestTypes(interestTypeId, requestBody)

      const elemIndex = interestTypes.findIndex(e => e.interestTypeId === interestTypeId);

      if (elemIndex){
        interestTypes[elemIndex].name = newValue.name;
      }

      setInterestTypes([...interestTypes])
    }

    const interestTypeDelete = async (interestTypeId: string) => {
      await deleteInterestTypes(interestTypeId);

      const elem = interestTypes.findIndex(e => e.interestTypeId === interestTypeId);

      if (elem > -1) { // only splice array when item is found
        interestTypes.splice(elem, 1); // 2nd parameter means remove one item only
      }
      setInterestTypes([...interestTypes])
    };

    const InterestTypeControllService: InterestTypeControllService = {
      interestTypes: interestTypes,
      updateInterestType: interestTypeUpdate,
      deleteInterestType: interestTypeDelete
    };

    return (
      <InterestTypeControllContext.Provider value={ InterestTypeControllService }>
        {children}
      </InterestTypeControllContext.Provider>
    );
  };