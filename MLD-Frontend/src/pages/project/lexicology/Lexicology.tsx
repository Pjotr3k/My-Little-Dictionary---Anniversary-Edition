import { useParams } from "react-router";
import usePartsOfSpeech from "../../../hooks/queries/usePartsOfSpeech";
import PartsOfSpeechItemDetail from "./part-of-speech/PartsOfSpeechItemDetail";
import { PartOfSpeech } from "../../../types/data-models";
import { useState } from "react";
import SelectList from "../../../components/SelectList";
import { Button } from "@mui/material";
import PartOfSpeechForm from "./part-of-speech/PartOfSpeechForm";

export default function Lexicology(){
  const { project } = useParams();
  const [pos, setPos] = useState<PartOfSpeech | undefined>(undefined)
  const [showPosFork, setShowPosFork] = useState<boolean>(false)

  if(!project)
      return <div>Error fetching data</div>

  return <div>
    <Button onClick={() => setShowPosFork(prev => !prev)}>Add Part of Speech</Button>
    {showPosFork ? <PartOfSpeechForm /> : null}
    {/* {pos ? <div className="p-3 border border-solid border-amber-700">{<PartsOfSpeechItemDetail item={pos} />}</div> : null} */}
    <SelectList
      maxHeight={"full"}
      itemKey={(item) => item.id} selectedItem={pos}
      setItem={setPos}
      mapper={(item) => <PartsOfSpeechItemDetail item={item} />}
      useItems={(req) => usePartsOfSpeech(req, project)} />
  </div>
}