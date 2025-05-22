import { MenuItem, Select, SelectChangeEvent } from "@mui/material";
import { useNavigate, useParams } from "react-router";

type projMockup = {
    id: string;
    slug: string;
    name: string;
    description?: string;
}

const projs: projMockup[] = [
    {
        id:"123123123",
        name: "Gothic",
        slug: "GOTH_1",
        description: "Language of goths"
    },
    {
        id:"443366262",
        name: "Cornish",
        slug: "CORN_1",
        description: "Revival project of native language of Cornwall"
    },
    {
        id:"3215212",
        name: "Aramaic",
        slug: "ARAM_1",
        description: "Language of arams"
    },
    {
        id:"52753543",
        name: "Maori",
        slug: "MAOR_1",
        description: "Keeping Te Reo Maori alive!!!!"
    },
]

export default function ProjectData(){
    const { project } = useParams();
    const navigate = useNavigate()

    function handleChange(e: SelectChangeEvent<string>){
        const val = e.target.value;
        navigate(`/${val}`)
    }

    return <div className="w-[160px] p-2">
        <Select onChange={handleChange} value={project} className="w-full h-10">
            {projs.map(proj => <MenuItem value={proj.slug}>{proj.name}</MenuItem>)}
        </Select>
    </div>
}