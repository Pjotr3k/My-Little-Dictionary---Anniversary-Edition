import React, { useEffect, useState } from "react"
import { bearerExpiration, bearerRefresh, bearerToken } from "../helpers/storage-dictionary"
import { useNavigate } from "react-router"
import { getBearerWithRefreshToken } from "../helpers/axios-instance"
import Loader from "../components/Loader"

export default function withAuthentication<TProps extends object>(WrappedComponent: React.ComponentType<TProps>){
    return (props: TProps) => {
        const navigate = useNavigate();
        const [isAuthorized, setIsAuthorized] = useState(false);

        useEffect(() => {
            let token = localStorage.getItem(bearerToken)
            const expiration = localStorage.getItem(bearerExpiration)
            const refresh = localStorage.getItem(bearerRefresh)

            const hasExpired = !expiration || new Date(expiration) < new Date();
    
            if(!token || hasExpired){
                if(refresh){
                    getBearerWithRefreshToken(refresh)
                    .then((res => {
                        if(!res) 
                            navigate("/auth/login")
                        else setIsAuthorized(true);
                    })).catch(() => navigate("/auth/login"));
                }
                else
                navigate("/auth/login")
            }
            else
            setIsAuthorized(true);
        }, []);

        if(!isAuthorized)
            return <Loader />

        return <WrappedComponent {...props} /> 
    }
}