import { Outlet } from "react-router";
import Header from "./Header";
import Breadcrumbs from "./Breadcrumbs";
import SideMenu from "./SideMenu";
import withAuthentication from "../../hoc/withAuthentication";

function AppContainer(){
    return <div className="h-full">
        <Header />
        <div className=" bg-amber-300 flex h-[calc(100vh-120px)] items-stretch">
          <SideMenu />
          <div className="shadow-lg overflow-auto max-h-[calc(100vh-110px)] w-full pl-6 pr-12 py-4">
            <Breadcrumbs />
            <Outlet />
          </div>
        </div>
    </div>
}

export default withAuthentication(AppContainer)