import { useState } from "react";
import { getInterests, updateInterests } from "./apiWrapper";
import { InterestResponse, UpdateInterestRequest } from "./openapi";

function AppInterestService() {
    const [interests, setInterests] = useState<InterestResponse[]>([]);

    const fetch = async () => {
        const interests = await getInterests();
        setInterests(interests)
        console.log("Interest fetch")
        console.log(interests)
    }

    const update = async (interestId: string, requestBody: UpdateInterestRequest) => {
        const newValue = await updateInterests(interestId, requestBody)

        const elem = interests.find(e => e.interestId === interestId);
        if (elem){
            elem.name = newValue.name;
            elem.interestType = newValue.interestType;
        }

        console.log("Interest update")
        console.log(interests)
    }

    
}