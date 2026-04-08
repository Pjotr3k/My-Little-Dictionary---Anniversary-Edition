import { Button, Input } from "@mui/material";

import { useContext, useState } from "react";

import useDictionaryCreate from "../../../hooks/queries/useDictionaryCreate";
import { ProjectContext, TProjectContext } from "../../../contexts/ProjectProvider";
import { useNavigate } from "react-router";
import FieldWrapper from "../../../components/FieldWrapper";
import SelectList from "../../../components/SelectList";
import { Language } from "../../../types/data-models";
import useLanguages from "../../../hooks/queries/useLanguages";

export default function CreateDictionary(){
    const [name, setName] = useState<string>("");    
    const [code, setCode] = useState<string>("");    
    const [description, setDescription] = useState<string>("");
    const [language, setLanguage] = useState<Language | undefined>(undefined);
  const {
    projectData: { id: projectId },
  } = useContext(ProjectContext) as TProjectContext;
    
    const {data, error, mutateAsync} = useDictionaryCreate()
    const navigate = useNavigate()

    function handleSubmit(){
        if([name, code, description].some(item => !item))
            return;

        mutateAsync({
            data: {name,
            code,
            description},
            languageID: language?.id || "",
            projectID: projectId
        }).then((response) => {
            // const {code} = response.result;
            // navigate("/" + code);
        })
    }

    return <div className="max-w-[800px] mx-auto flex flex-col gap-4">
        <FieldWrapper name="Name"><Input value={name} onChange={(e) => setName(e.target.value)} /></FieldWrapper>
        <FieldWrapper name="Code"><Input value={code} onChange={(e) => setCode(e.target.value)} /></FieldWrapper>
        <FieldWrapper name="Description"><Input value={description} onChange={(e) => setDescription(e.target.value)} multiline maxRows={8} /></FieldWrapper>
        <FieldWrapper name="Language">
            <SelectList maxHeight={36} itemKey={(item) => item.id} selectedItem={language} setItem={(item) => setLanguage(item)} mapper={(item) => `${item.name} (${item.code})`} useItems={useLanguages} />
        </FieldWrapper>
        <Button onClick={handleSubmit}>Create Project</Button>
    </div>
}