import { Button } from "@mui/material";
import { FormDescr } from "../../../../types/data-models"
import { useState } from "react";
import FormForm from "./FormForm";

type Props = {
  element: FormDescr;
  modifyItem: (item: FormDescr) => void;
  removeItem: () => void;
  formDisabled: boolean;
}

export default function FormCollectionItem({element, modifyItem, removeItem, formDisabled} : Props){
  const [showModify, setShowModify] = useState<boolean>(false);
  const {name, description} = element
  return (
    <div>
      <div>
        {name} - {description}
        <Button onClick={() => setShowModify(prev => !prev)}>modify</Button>
        <Button onClick={() => removeItem()}>remove</Button> 
      </div>
      {showModify
        ? <FormForm formDisabled={formDisabled} baseForm={element} submit={(elem) => modifyItem(elem)} />
        : null}
    </div>  
  )
}