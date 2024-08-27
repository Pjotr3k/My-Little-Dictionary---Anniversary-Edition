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
export type LoginRequest = {
    userName: string;
    password: string;
}

export type RegisterRequest = {
    userName: string; 
    password: string; 
    passwordConfirm: string; 
    email: string; 
    emailConfirm: string; 
    }

    export type LoginResponse = {
        token: string ,
        expiration: Date ,
        loginStatusCode: number, 
        status: string,
        refreshToken: string,
    }