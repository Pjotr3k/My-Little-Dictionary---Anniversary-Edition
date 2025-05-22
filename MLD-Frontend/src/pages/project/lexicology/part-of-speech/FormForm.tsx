import { Button, Input } from "@mui/material";
import FieldWrapper from "../../../../components/FieldWrapper";
import { useState } from "react";
import { FormDescr } from "../../../../types/data-models";

type Props = {
  baseForm: FormDescr;
  submit: (elem: FormDescr) => void;
  formDisabled: boolean;
};

export default function FormForm({ baseForm, submit, formDisabled }: Props) {
  const [form, setForm] = useState<FormDescr>(baseForm);

  return (
    <div className="max-w-[800px] mx-auto flex flex-col gap-4">
      <FieldWrapper name="Name">
        <Input
          disabled={formDisabled}
          value={form.name}
          onChange={(e) =>
            setForm((prev) => {
              return { ...prev, name: e.target.value };
            })
          }
        />
      </FieldWrapper>
      <FieldWrapper name="Description">
        <Input
          disabled={formDisabled}
          value={form.description}
          onChange={(e) =>
            setForm((prev) => {
              return { ...prev, description: e.target.value };
            })
          }
          multiline
          maxRows={8}
        />
      </FieldWrapper>
      <Button disabled={formDisabled} onClick={() => submit(form)}>
        Add Form
      </Button>
    </div>
  );
}
