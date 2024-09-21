import { Paper } from "@mui/material";
import { Form } from "../../types";

type Props = {
    item: Form
}

export default function FormItemDetail({item}: Props){
    const { description, name} = item;
    return<Paper className="grid  px-6 py-2 grid-cols-2 w-full">
        <div>{name}</div>
        <div>
            {description}
        </div>
    </Paper>
}