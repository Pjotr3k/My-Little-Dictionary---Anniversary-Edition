export type WithID = {
    id: string;
}

export type ApiResponse<T> = {
    notifications: string[],
    warnings: string[],
    errors: string[],
    result: T
}

export type Language = {
    name: string;
    code: string;
    description: string; 
} & WithID;

export type PartOfSpeech = {
    name: string;
    description: string; 
} & WithID

export type Form = {
    name: string;
    description: string; 
} & WithID

export type Breadcrumb = {
    label: string,
    link: string
}