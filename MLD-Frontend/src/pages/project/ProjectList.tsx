import { useState } from "react";
import SelectList from "../../components/SelectList";
import useProjects from "../../hooks/queries/useProjects";
import { Project } from "../../types/data-models";
import ProjectSelectItem from "../ProjectSelectItem";

export default function ProjectList(){
    const [project, setProject] = useState<Project | undefined>(undefined)

    return <div>
        <SelectList maxHeight={"full"} itemKey={(item) => item.id} selectedItem={project} setItem={setProject} mapper={(item) => <ProjectSelectItem item={item} />} useItems={useProjects} />
</div>
}