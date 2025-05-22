import { FormDescr, PartOfSpeechDescr } from "./data-models";

export type ProjectInsert = {
    name: string;
    code: string;
    description?: string;
    language: string;
};


export type PartOfSpeechInsert = {
    projectID: string;
    data: PartOfSpeechDescr;
    forms: FormDescr[];
}