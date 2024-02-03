import {
    InterestTypeResponse,
    CreateInterestTypeRequest,
    OpenAPI,
    InterestTypeService,
  } from './openapi';

  import {
    InterestResponse,
    CreateInterestRequest,
    InterestService,
  } from './openapi';

  const { getInterestType, postInterestType, getInterestType1, putInterestType, deleteInterestType } = InterestTypeService;
  const { getInterest, postInterest } = InterestService;


  OpenAPI.BASE = 'http://107.175.36.34:32777';

  export const getInterests = async () => {
    try {
      const interests: InterestResponse[] = await getInterest();
      return interests;
    } catch (error) {
      throw new Error(error);
    }
  };

  export const getInterestTypes = async () => {
    try {
      const interests: InterestTypeResponse[] = await getInterestType();
      return interests;
    } catch (error) {
      throw new Error(error);
    }
  };