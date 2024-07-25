import { Paper } from "@mui/material";
import { PartOfSpeech } from "../../types"
import FormList from "./FormList";

type Props = {
    item: PartOfSpeech
}

export default function PartsOfSpeechItemDetail({item}: Props){
    const { description, name, id} = item;
    return<div className="p-4 bg-amber-500 rounded-md">
        <h3>{name}</h3>
        <p>
            {description}
            <FormList partOfSpeechId={id} />
        </p>
    </div>
}