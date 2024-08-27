import { Box, ButtonGroup } from "@mui/material";
import { NavLink, Outlet } from "react-router-dom";
import withLoggedRedirect from "../../hoc/withLoggedRedirect";

function LoginContainer(){
    return <div className="grid grid-cols-1 place-items-center h-[100vh] w-full">
        <div>

        <Box>
            <ButtonGroup>
            <NavLink to={"/auth/login"} >
        <div className="w-full text-left bg-black bg-opacity-0 hover:bg-opacity-10 p-4 shadow-lg">Login</div>
    </NavLink>                <NavLink to={"/auth/signin"} >
        <div className="w-full text-left bg-black bg-opacity-0 hover:bg-opacity-10 p-4 shadow-lg">Sign In</div>
    </NavLink>
            </ButtonGroup>
        </Box>
        <Box>
            <Outlet />
        </Box>
        </div>
    </div>
}

export default withLoggedRedirect(LoginContainer)