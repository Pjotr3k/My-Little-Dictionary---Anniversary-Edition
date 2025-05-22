import { Outlet } from "react-router";
import Header from "./Header";
import withAuthentication from "../../hoc/withAuthentication";

function AppContainer(){
    return <div className="h-full">
        <Header />
        <div className=" bg-amber-300 flex h-[calc(100vh-120px)] items-stretch">
          <Outlet />
        </div>
    </div>
}

export default withAuthentication(AppContainer)