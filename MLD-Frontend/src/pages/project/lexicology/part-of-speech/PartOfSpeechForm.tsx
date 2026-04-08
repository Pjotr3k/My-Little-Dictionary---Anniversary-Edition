import { Input } from "@mui/material";
import FieldWrapper from "../../../../components/FieldWrapper";
import { useState } from "react";
import { FormDescr } from "../../../../types/data-models";
import getCollectionActions, {
  Collection,
  getData,
} from "../../../../helpers/collection-helper";
import FormCollection from "./FormCollection";
import PartOfSpeechSubmitButton from "./PartOfSpeechSubmitButton";

type Props = {
  dictionaryId: string;
};

export default function PartOfSpeechForm({ dictionaryId }: Props) {
  const [name, setName] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [code, setCode] = useState<string>("");
  const [forms, setForms] = useState<Collection<FormDescr>>([]);
  const [formDisabled, setFormDisabled] = useState<boolean>(false);

  return (
    <div className="max-w-[800px] mx-auto flex flex-col gap-4">
      <FieldWrapper name="Name">
        <Input
          value={name}
          onChange={(e) => setName(e.target.value)}
          disabled={formDisabled}
        />
      </FieldWrapper>
      <FieldWrapper name="Code">
        <Input
          value={code}
          onChange={(e) => setCode(e.target.value)}
          disabled={formDisabled}
        />
      </FieldWrapper>
      <FieldWrapper name="Description">
        <Input
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          multiline
          maxRows={8}
          disabled={formDisabled}
        />
      </FieldWrapper>
      <FormCollection
        {...getCollectionActions(setForms)}
        forms={forms}
        formDisabled={formDisabled}
      />
      <PartOfSpeechSubmitButton
        request={{
          projectID: dictionaryId,
          data: {
            name,
            code,
            description,
          },
          forms: getData(forms),
        }}
        onLoading={() => setFormDisabled(true)}
        onLoadingFinished={() => setFormDisabled(false)}
      />
    </div>
  );
}
