import axios from "axios";
import { backendURL } from "../config";
import { bearerExpiration, bearerRefresh, bearerToken } from "./storage-dictionary";
import { handeLoginResponse } from "../hooks/queries/useLogin";
import { json } from "react-router";

function getAxiosInstance() {


    const instance = axios.create({
        baseURL: backendURL,
    })
    instance.interceptors.request.use(async req => {

        let token = localStorage.getItem(bearerToken)
        const expires = localStorage.getItem(bearerExpiration)
        const refresh = localStorage.getItem(bearerRefresh)
    
        const expired = !expires || new Date(expires) < new Date();
    
        if (expired && refresh) {
            token = await getBearerWithRefreshToken(refresh) || ""                             
        }

        console.log(token)

        req["headers"] = req.headers ?? {};
req.headers["Authorization"] = `Bearer ${token}`;

    
        return req
    })

    return instance;
}

export async function getBearerWithRefreshToken(refresh: string){
    let req = {
        url: backendURL + "Security/RefreshBearer",
        method: 'POST',
        data: JSON.stringify(refresh), 
        headers: {
            'Content-Type': 'application/json'
        }
    }; 
    const response = await axios(req);
    return handeLoginResponse(response.data.result)
}

export default getAxiosInstance;