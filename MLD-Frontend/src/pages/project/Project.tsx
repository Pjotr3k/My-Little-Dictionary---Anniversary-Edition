import { useContext } from "react";
import Card from "../../components/Card";
import {
  ProjectContext,
  TProjectContext,
} from "../../contexts/ProjectProvider";
import { Project as TProject } from "../../types/data-models";

const cards: Array<{ to: string; label: string }> = [
  {
    label: "Linguistic",
    to: "lexicology",
  },
  {
    label: "Dictionary",
    to: "dictionary",
  },
  {
    label: "Library",
    to: "library",
  },
  {
    label: "Texts",
    to: "texts",
  },
];

export default function Project() {
  const {
    projectData: { name, description },
  } = useContext(ProjectContext) as TProjectContext;

  return (
    <>
      <div>
        {name} - {description}
      </div>
      <div className="flex flex-wrap p-6 gap-4">
        {cards.map((card) => (
          <Card to={card.to} label={card.label} />
        ))}
      </div>
    </>
  );
}
