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

export type LoginRequest = {
    userName: string;
    password: string;
}
