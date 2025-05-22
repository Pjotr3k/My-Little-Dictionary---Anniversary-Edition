import { Outlet } from "react-router";
import SideMenu from "../../components/app-container/SideMenu";
import ProjectProvider from "../../contexts/ProjectProvider";

export default function ProjectContainer() {
  return (
    <ProjectProvider>
      <SideMenu />
      <div className="shadow-lg overflow-auto max-h-[calc(100vh-110px)] w-full pl-6 pr-12 py-4">
        <Outlet />
      </div>
    </ProjectProvider>
  );
}
