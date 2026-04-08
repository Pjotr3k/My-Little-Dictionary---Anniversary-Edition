import { useContext, useState } from "react";
import { Button, ToggleButton, ToggleButtonGroup } from "@mui/material";
import {
  ProjectContext,
  TProjectContext,
} from "../../../contexts/ProjectProvider";
import { useDictionaryData } from "../../../hooks/queries/useDictionaryData";
import Loader from "../../../components/Loader";
import DictionaryInfo from "./DictionaryInfo";
import CreateDictionary from "./CreateDictionary";
import { useSearchParams } from "react-router-dom";

type ButtonGroupItem = {
  value: string;
  action: "read" | "update";
};

const bulletStyles = {
  borderRadius: "999px",
  px: 3,
  py: 1,
  textTransform: "none",
};

export default function Lexicology() {
  const {
    projectData: { id: projectId },
  } = useContext(ProjectContext) as TProjectContext;
  const { data, isLoading, isError } = useDictionaryData(projectId);
  const [searchParams, setSearchParams] = useSearchParams();
  const [chosenOption, setChosenOption] = useState<
    ButtonGroupItem | undefined
  >();

  if (isLoading) return <Loader />;

  if (!projectId || isError || !data?.result)
    return <div>Error fetching data</div>;

  console.log("Lexicology", { data });

  function mapDictionary() {
    if (!data?.result) return null;

    console.log({result: data.result});
    

    return Object.entries(data.result).map(([key, { name }]) => (
      <ToggleButton
        key={key}
        value={{ value: key, action: "read" }}
        sx={bulletStyles}
      >
        {name}
      </ToggleButton>
    ));
  }

  function renderContent() {
    console.log("Rendering content!!!", { chosenOption });

    if (!chosenOption) return null;

    const { action, value } = chosenOption;

    console.log({chosenOption});
    

    if (action === "read") return <DictionaryInfo dictionaryId={value} />;

    switch (value) {
      case "new":
        return <CreateDictionary />;
    }
  }

  const buttonGroupProps = {
    onChange: (_, value: ButtonGroupItem) => setChosenOption(value),
    className: "justify-between",
    exclusive: true,
    value: chosenOption,
  };

  return (
    <div>
      <div className="flex justify-between">
        <ToggleButtonGroup {...buttonGroupProps}>
          {mapDictionary()}
        </ToggleButtonGroup>
        <ToggleButtonGroup {...buttonGroupProps}>
          <ToggleButton
            value={{ value: "new", action: "update" }}
            sx={bulletStyles}
          >
            New
          </ToggleButton>
        </ToggleButtonGroup>
      </div>
      <div>{renderContent()}</div>
    </div>
  );
}
