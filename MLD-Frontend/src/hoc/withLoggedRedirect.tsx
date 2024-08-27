import React, { useEffect } from "react"
import { bearerExpiration, bearerToken } from "../helpers/storage-dictionary"
import { useNavigate } from "react-router"

export default function withLoggedRedirect<TProps extends object>(WrappedComponent: React.ComponentType<TProps>){
    return (props: TProps) => {
        const navigate = useNavigate()

        useEffect(() => {
            const token = localStorage.getItem(bearerToken)
            const expiration = localStorage.getItem(bearerExpiration)
            const hasExpired = !expiration || new Date(expiration) < new Date();
    
            if(token && !hasExpired)
                navigate("/app")
        })

        return <WrappedComponent {...props} /> 
    }
}