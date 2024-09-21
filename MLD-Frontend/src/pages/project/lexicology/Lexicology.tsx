import { useParams } from "react-router";
import ItemList from "../../../components/ItemList";
import usePartsOfSpeech from "../../../hooks/queries/usePartsOfSpeech";
import PartsOfSpeechItemDetail from "./part-of-speech/PartsOfSpeechItemDetail";
import { PartOfSpeech } from "../../../types/data-models";
import { useState } from "react";
import SelectList from "../../../components/SelectList";


export default function Lexicology(){
    const { project } = useParams();
    // const {data, isLoading, isError} = usePartsOfSpeech(project);
    const [pos, setPos] = useState<PartOfSpeech | undefined>(undefined)

    // if(isLoading)
    //     return <div>Loading, please wait...</div>

    if(!project)
        return <div>Error fetching data</div>

    return <div>
        <SelectList maxHeight={"full"} itemKey={(item) => item.id} selectedItem={pos} setItem={setPos} mapper={(item) => <PartsOfSpeechItemDetail item={item} />} useItems={(req) => usePartsOfSpeech(req, project)} />
        </div>
}