export type ApiResponse<T> = {
    notifications: string[],
    warnings: string[],
    errors: string[],
    result: T
}

export type PaginationResponse<T> = ApiResponse<PaginationResult<T>>

export type PaginationResult<T> = {
    request: PaginationRequest;
    totalCount: number;
    totalPages: number;
    overlimit: boolean;
    data: T[];
}

export type PaginationRequest = {
    pageSize: number;
    pageNumber: number;
    searchPhrase?: string;
};