import { Button } from "@mui/material";
import { Project } from "../types/data-models"
import { useNavigate } from "react-router";

type Props = {
    item: Project;
}

export default function ProjectSelectItem({item} : Props){
    console.log("ProjectSelectItem", {...item});
    
    const navigate = useNavigate();
    return <div>
        <div>{item.name} ({item.code})</div>
        <div>{item.description}</div>
        <Button onClick={() => navigate(`/${item.code}`)}>Browse</Button>
    </div>
}