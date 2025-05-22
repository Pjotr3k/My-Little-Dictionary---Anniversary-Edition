import { useParams } from "react-router";
import { useProject } from "../hooks/queries/useProject";
import { createContext, PropsWithChildren } from "react";
import { Project } from "../types/data-models";

export type TProjectContext = {
  projectData: Project;
};

export const ProjectContext = createContext<TProjectContext | null>(null);

export default function ProjectProvider({ children }: PropsWithChildren) {
  const { project } = useParams();
  const { data, isLoading, isError } = useProject(project!);

  if (isLoading) return <div>Loading, please wait...</div>;

  if (isError || !data?.result) return <div>Error fetching data</div>;

  return (
    <>
      <ProjectContext.Provider value={{ projectData: data.result }}>
        {children}
      </ProjectContext.Provider>
    </>
  );
}
