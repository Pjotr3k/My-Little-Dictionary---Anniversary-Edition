import { Button } from "@mui/material";
import PartOfSpeechForm from "./part-of-speech/PartOfSpeechForm";
import SelectList from "../../../components/SelectList";
import PartsOfSpeechItemDetail from "./part-of-speech/PartsOfSpeechItemDetail";
import { PartOfSpeech } from "../../../types/data-models";
import { useState } from "react";
import usePartsOfSpeech from "../../../hooks/queries/usePartsOfSpeech";

type Props = {
    dictionaryId: string
}

export default function DictionaryInfo({ dictionaryId } : Props) {
  const [pos, setPos] = useState<PartOfSpeech | undefined>(undefined);
  const [showPosForm, setShowPosForm] = useState<boolean>(false);

  return (
    <div>
      <Button onClick={() => setShowPosForm((prev) => !prev)}>
        Add Part of Speech
      </Button>
      {showPosForm ? <PartOfSpeechForm dictionaryId={dictionaryId} /> : null}
      {/* {pos ? <div className="p-3 border border-solid border-amber-700">{<PartsOfSpeechItemDetail item={pos} />}</div> : null} */}
      <SelectList
        maxHeight={"full"}
        itemKey={(item) => item.id}
        selectedItem={pos}
        setItem={setPos}
        mapper={(item) => <PartsOfSpeechItemDetail item={item} />}
        useItems={(req) => usePartsOfSpeech(req, dictionaryId)}
      />
    </div>
  );
}
