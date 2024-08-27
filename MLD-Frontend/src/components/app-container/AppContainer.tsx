import { Outlet } from "react-router";
import Header from "./Header";
import Breadcrumbs from "./Breadcrumbs";
import SideMenu from "./SideMenu";
import withAuthentication from "../../hoc/withAuthentication";

function AppContainer(){
    return <div className="py-6 h-full">
        <Header />
        <div className=" bg-amber-400 flex items-stretch">
          <SideMenu />
          <div className="shadow-lg w-full pr-12">
            <Breadcrumbs />
            <Outlet />
          </div>
        </div>
    </div>
}

export default withAuthentication(AppContainer)