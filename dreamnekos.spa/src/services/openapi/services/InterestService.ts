/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CreateInterestRequest } from '../models/CreateInterestRequest';
import type { InterestResponse } from '../models/InterestResponse';
import type { UpdateInterestRequest } from '../models/UpdateInterestRequest';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class InterestService {
    /**
     * @returns InterestResponse Success
     * @throws ApiError
     */
    public static getInterest(): CancelablePromise<Array<InterestResponse>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Interest',
        });
    }
    /**
     * @param requestBody
     * @returns InterestResponse Success
     * @throws ApiError
     */
    public static postInterest(
        requestBody?: CreateInterestRequest,
    ): CancelablePromise<InterestResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Interest',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                401: `Unauthorized`,
            },
        });
    }
    /**
     * @param interestId
     * @param requestBody
     * @returns InterestResponse Success
     * @throws ApiError
     */
    public static putInterest(
        interestId: string,
        requestBody?: UpdateInterestRequest,
    ): CancelablePromise<InterestResponse> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/Interest/{interestId}',
            path: {
                'interestId': interestId,
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
     * @param interestId
     * @returns void
     * @throws ApiError
     */
    public static deleteInterest(
        interestId: string,
    ): CancelablePromise<void> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/Interest/{interestId}',
            path: {
                'interestId': interestId,
            },
            errors: {
                401: `Unauthorized`,
                404: `Not Found`,
            },
        });
    }
}
