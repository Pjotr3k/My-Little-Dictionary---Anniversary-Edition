export type WithID = {
  id: string;
};

export type Project = {
  name: string;
  code: string;
  description: string;
  data: {
    name: string;
    code: string;
    description: string;
  };
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
  forms?: Form[];
} & WithID;

export type Form = {
  name: string;
  description: string;
} & WithID;

export type FormDescr = {
  name: string;
  description: string;
};

export type PartOfSpeechDescr = {
  name: string;
  code: string;
  description: string;
};

export type Breadcrumb = {
  label: string;
  link: string;
};
