/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AddUserInterestRequest } from '../models/AddUserInterestRequest';
import type { CreateProfileRequest } from '../models/CreateProfileRequest';
import type { GetProfileResponse } from '../models/GetProfileResponse';
import type { InterestResponse } from '../models/InterestResponse';
import type { LinkResponse } from '../models/LinkResponse';
import type { UpdateProfileRequest } from '../models/UpdateProfileRequest';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class ProfileService {
    /**
     * @param userId
     * @returns GetProfileResponse Success
     * @throws ApiError
     */
    public static getProfile(
        userId: string,
    ): CancelablePromise<GetProfileResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Profile/{userId}',
            path: {
                'userId': userId,
            },
            errors: {
                404: `Not Found`,
            },
        });
    }
    /**
     * @param userId
     * @param requestBody
     * @returns GetProfileResponse Success
     * @throws ApiError
     */
    public static putProfile(
        userId: string,
        requestBody?: UpdateProfileRequest,
    ): CancelablePromise<GetProfileResponse> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/Profile/{userId}',
            path: {
                'userId': userId,
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
     * @param requestBody
     * @returns GetProfileResponse Success
     * @throws ApiError
     */
    public static postProfile(
        requestBody?: CreateProfileRequest,
    ): CancelablePromise<GetProfileResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Profile',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                401: `Unauthorized`,
            },
        });
    }
    /**
     * @param userId
     * @param requestBody
     * @returns InterestResponse Success
     * @throws ApiError
     */
    public static postProfileInterests(
        userId: string,
        requestBody?: AddUserInterestRequest,
    ): CancelablePromise<InterestResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Profile/{userId}/interests',
            path: {
                'userId': userId,
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
     * @param userId
     * @param interestId
     * @returns void
     * @throws ApiError
     */
    public static deleteProfileInterests(
        userId: string,
        interestId: string,
    ): CancelablePromise<void> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/Profile/{userId}/interests/{interestId}',
            path: {
                'userId': userId,
                'interestId': interestId,
            },
            errors: {
                401: `Unauthorized`,
                404: `Not Found`,
            },
        });
    }
    /**
     * @param userId
     * @param name
     * @param url
     * @returns LinkResponse Success
     * @throws ApiError
     */
    public static postProfileLinks(
        userId: string,
        name?: string,
        url?: string,
    ): CancelablePromise<LinkResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Profile/{userId}/links',
            path: {
                'userId': userId,
            },
            query: {
                'name': name,
                'url': url,
            },
            errors: {
                401: `Unauthorized`,
                404: `Not Found`,
            },
        });
    }
    /**
     * @param userId
     * @param linkId
     * @returns void
     * @throws ApiError
     */
    public static deleteProfileLinks(
        userId: string,
        linkId: string,
    ): CancelablePromise<void> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/Profile/{userId}/links/{linkId}',
            path: {
                'userId': userId,
                'linkId': linkId,
            },
            errors: {
                401: `Unauthorized`,
                404: `Not Found`,
            },
        });
    }
}
