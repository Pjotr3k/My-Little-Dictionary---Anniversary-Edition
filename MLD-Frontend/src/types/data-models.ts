export type WithID = {
    id: string;
}

export type Project = {
    name: string;
    code: string;
    description: string; 
    language: Language;
} & WithID;

export type Language = {
    name: string;
    code: string;
    description: string; 
} & WithID;

export type PartOfSpeech = {
    name: string;
    description: string;
    forms?: Form[] 
} & WithID

export type Form = {
    name: string;
    description: string; 
} & WithID

export type Breadcrumb = {
    label: string,
    link: string
}    