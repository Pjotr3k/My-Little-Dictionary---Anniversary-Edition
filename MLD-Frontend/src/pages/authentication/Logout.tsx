import { useEffect } from "react"
import { bearerExpiration, bearerRefresh, bearerToken } from "../../helpers/storage-dictionary"
import { useNavigate } from "react-router";

export default function Logout(){
    const navigate = useNavigate();
    useEffect(() => {
        localStorage.removeItem(bearerToken);
        localStorage.removeItem(bearerExpiration);
        localStorage.removeItem(bearerRefresh)

        navigate("/auth/login")
    })
    return <div>
        Logging out....
    </div>
}