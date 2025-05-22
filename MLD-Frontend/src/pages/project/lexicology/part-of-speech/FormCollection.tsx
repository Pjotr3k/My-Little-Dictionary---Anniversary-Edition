import { Button } from "@mui/material";
import {
  Collection,
  CollectionActions,
} from "../../../../helpers/collection-helper";
import { FormDescr } from "../../../../types/data-models";
import { useState } from "react";
import FormCollectionItem from "./FormCollectionItem";
import FormForm from "./FormForm";

type Props = {
  forms: Collection<FormDescr>;
  formDisabled: boolean;
} & CollectionActions<FormDescr>;

const baseItem: FormDescr = {
  name: "",
  description: "",
};

export default function FormCollection({
  forms,
  formDisabled,
  addItem,
  modifyItem,
  removeItem,
}: Props) {
  const [formState, setFormState] = useState(false);

  return (
    <div>
      <Button onClick={() => setFormState((prev) => !prev)}>Add form</Button>
      {formState ? <FormForm formDisabled={formDisabled} baseForm={baseItem} submit={addItem} /> : null}
      {forms.map((elem) => (
        <FormCollectionItem
          formDisabled={formDisabled}
          element={elem.element}
          modifyItem={(data) => modifyItem({ ...elem, element: data })}
          removeItem={() => removeItem(elem.orderNo)}
        />
      ))}
    </div>
  );
}
