import { Button, Input } from "@mui/material";
import FieldWrapper from "../../components/FieldWrapper";
import useLanguages from "../../hooks/queries/useLanguages";
import { useState } from "react";
import { Language } from "../../types/data-models";
import SelectList from "../../components/SelectList";
import useProjectCreate from "../../hooks/queries/useProjectCreate";
import { useNavigate } from "react-router";

export default function CreateProject(){
    const [name, setName] = useState<string>("");    
    const [code, setCode] = useState<string>("");    
    const [description, setDescription] = useState<string>("");
    const [language, setLanguage] = useState<Language | undefined>(undefined);
    
    const {data, error, mutateAsync} = useProjectCreate()
    const navigate = useNavigate()

    function handleSubmit(){
        if([name, code, description, language?.id].some(item => !item))
            return;

        mutateAsync({
            name,
            code,
            description,
            language: language?.id
        }).then((response) => {
            const {code} = response.result;
            navigate("/" + code);
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