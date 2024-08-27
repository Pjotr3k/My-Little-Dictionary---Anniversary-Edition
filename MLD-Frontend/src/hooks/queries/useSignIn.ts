import axios, { AxiosResponse } from "axios";
import { ApiResponse, LoginResponse, RegisterRequest } from "../../types";
import { useMutation } from "react-query";
import { backendURL } from "../../config";
import { handeLoginResponse } from "./useLogin";
import { useNavigate } from "react-router";

export default function useSignIn(redirectURL: string = "/app"){
    const navigate = useNavigate();
    return useMutation<AxiosResponse<ApiResponse<LoginResponse>>, unknown, RegisterRequest>({
        mutationKey: ["login"],
        mutationFn: async (request: RegisterRequest) =>
            axios.post(backendURL + "Security/Register", request),
        onSuccess(response) {
            if(response.data.errors.length)
                return;
            const {result} = response.data;
            handeLoginResponse(result, navigate, redirectURL)
    }
})
}