import {
    InterestTypeResponse,
    CreateInterestTypeRequest,
    OpenAPI,
    InterestTypeService,
    UpdateInterestRequest,
    UpdateInterestTypeRequest,
  } from './openapi';

  import {
    InterestResponse,
    CreateInterestRequest,
    InterestService,
  } from './openapi';

  const { getInterestType, postInterestType, getInterestType1, putInterestType, deleteInterestType } = InterestTypeService;
  const { getInterest, postInterest, putInterest, deleteInterest } = InterestService;

  OpenAPI.BASE = 'http://107.175.36.34:32777';
  OpenAPI.TOKEN = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBcHAgSUQgPC0gaW4gZnV0dXJlIiwiQ3VzdG9tZXJUeXBlIjoiMy1wYXJ0eSBhcHAiLCJqdGkiOiI4NjM1YzdkNy0wZGNlLTQ1NjktODc3MS03NGEwMWRmZDIwNjkiLCJleHAiOjE4NjQyOTkwOTAsImlzcyI6IlZhbmlsbGEgYXBwIiwiYXVkIjoiVmFuaWxsYSBhcHAifQ.UjwhCG6PLTfmcj9O3zQbRiU_cUuDuaVsXRaYpVB6WBc';

  export const getInterests = async () => {
    try {
      const interests: InterestResponse[] = await getInterest();
      return interests;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const createInterests = async (requestBody: CreateInterestRequest) => {
    console.log("Update interest!!!")
    try {
      const interest: InterestResponse = await postInterest(requestBody);
      return interest;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const updateInterests = async (interestId: string, requestBody: UpdateInterestRequest) => {
    console.log("Update interest!!!")
    try {
      const interest: InterestResponse = await putInterest(interestId, requestBody);
      return interest;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const deleteInterests = async (interestId: string) => {
    console.log("Delete interest!!!")
    console.log(interestId)
    try {
      await deleteInterest(interestId);
    } catch (error) {
      throw new Error(error);
    }
  };

  export const getInterestTypes = async () => {
    try {
      const interestType: InterestTypeResponse[] = await getInterestType();
      return interestType;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const createInterestTypes = async ( requestBody: UpdateInterestTypeRequest) => {
    try {
      const interestType: InterestTypeResponse = await postInterestType(requestBody);
      return interestType;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const updateInterestTypes = async ( interestTypeId: string, requestBody: CreateInterestTypeRequest) => {
    try {
      const interestType: InterestTypeResponse = await putInterestType(interestTypeId, requestBody);
      return interestType;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const deleteInterestTypes = async ( interestTypeId: string) => {
    try {
      await deleteInterestType(interestTypeId);
    } catch (error) {
      throw new Error(error);
    }
  };