/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CreateInterestTypeRequest } from '../models/CreateInterestTypeRequest';
import type { InterestTypeResponse } from '../models/InterestTypeResponse';
import type { UpdateInterestTypeRequest } from '../models/UpdateInterestTypeRequest';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class InterestTypeService {
    /**
     * @returns InterestTypeResponse Success
     * @throws ApiError
     */
    public static getInterestType(): CancelablePromise<Array<InterestTypeResponse>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/InterestType',
        });
    }
    /**
     * @param requestBody
     * @returns InterestTypeResponse Success
     * @throws ApiError
     */
    public static postInterestType(
        requestBody?: CreateInterestTypeRequest,
    ): CancelablePromise<InterestTypeResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/InterestType',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                401: `Unauthorized`,
            },
        });
    }
    /**
     * @param interestTypeId
     * @returns InterestTypeResponse Success
     * @throws ApiError
     */
    public static getInterestType1(
        interestTypeId: string,
    ): CancelablePromise<InterestTypeResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/InterestType/{interestTypeId}',
            path: {
                'interestTypeId': interestTypeId,
            },
            errors: {
                404: `Not Found`,
            },
        });
    }
    /**
     * @param interestTypeId
     * @param requestBody
     * @returns InterestTypeResponse Success
     * @throws ApiError
     */
    public static putInterestType(
        interestTypeId: string,
        requestBody?: UpdateInterestTypeRequest,
    ): CancelablePromise<InterestTypeResponse> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/InterestType/{interestTypeId}',
            path: {
                'interestTypeId': interestTypeId,
            },
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                401: `Unauthorized`,
                404: `Not Found`,
            },
        });
    }
    /**
     * @param interestTypeId
     * @returns void
     * @throws ApiError
     */
    public static deleteInterestType(
        interestTypeId: string,
    ): CancelablePromise<void> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/InterestType/{interestTypeId}',
            path: {
                'interestTypeId': interestTypeId,
            },
            errors: {
                401: `Unauthorized`,
                404: `Not Found`,
            },
        });
    }
}
