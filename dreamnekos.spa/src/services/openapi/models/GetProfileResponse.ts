/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { LinkResponse } from './LinkResponse';
import type { UserInterestLinkResponse } from './UserInterestLinkResponse';
export type GetProfileResponse = {
    id?: string;
    tgId?: number;
    about?: string | null;
    interest?: Array<UserInterestLinkResponse> | null;
    links?: Array<LinkResponse> | null;
};

