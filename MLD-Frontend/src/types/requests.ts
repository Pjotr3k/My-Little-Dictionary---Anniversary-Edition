import { DictionaryData, FormDescr, PartOfSpeechDescr } from "./data-models";

export type ProjectData = {
    name: string;
    code: string;
    description?: string;
};

export type ProjectInsert = {
    data: ProjectData,
    baseLanguage: string;
};

export type PartOfSpeechInsert = {
    projectID: string;
    data: PartOfSpeechDescr;
    forms: FormDescr[];
}

export type DictionaryInsert = {
    data: DictionaryData,
    projectID: string;
    languageID: string;
};