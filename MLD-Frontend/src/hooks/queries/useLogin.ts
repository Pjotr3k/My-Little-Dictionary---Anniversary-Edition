import { useMutation } from "react-query";
import { backendURL } from "../../config";
import axios, { AxiosResponse } from "axios";
import { bearerExpiration, bearerRefresh, bearerToken } from "../../helpers/storage-dictionary";
import { NavigateFunction, useNavigate } from "react-router";
import { ApiResponse } from "../../types/api-communication";
import { LoginRequest, LoginResponse } from "../../types/security";

export default function useLogin(redirectURL: string = "/"){
    const navigate = useNavigate();
    return useMutation<AxiosResponse<ApiResponse<LoginResponse>>, unknown, LoginRequest>({
        mutationKey: ["login"],
        mutationFn: async (request: LoginRequest) =>
            axios.post(backendURL + "Security/Login", request),
        onSuccess(response) {
            if(response.data.errors.length)
                return;
            const {result} = response.data;
            handeLoginResponse(result, navigate, redirectURL)
    }
})
}

export function handeLoginResponse(result: LoginResponse, navigate?: NavigateFunction, redirectURL: string = "/"){
    if(result.status === "Success" && result.token){
        localStorage.setItem(bearerToken, result.token)
        localStorage.setItem(bearerExpiration, result.expiration.toString())
        localStorage.setItem(bearerRefresh, result.refreshToken.toString())
        if(navigate) navigate(redirectURL)

        return result.token;
}     

}