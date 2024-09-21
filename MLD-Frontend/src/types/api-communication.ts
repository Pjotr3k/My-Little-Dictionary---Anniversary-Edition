export type ApiResponse<T> = {
    notifications: string[],
    warnings: string[],
    errors: string[],
    result: T
}

export type PaginationResponse<T> = ApiResponse<T[]> & {
    request: PaginationRequest;
    totalCount: number;
    totalPages: number;
    overlimit: boolean;
};

export type PaginationRequest = {
    pageSize: number;
    pageNumber: number;
    searchPhrase?: string;
};