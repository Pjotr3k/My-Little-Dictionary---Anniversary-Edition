import { Language } from "../../types"

type Props = {
    item: Language
}

export default function LanguageItemDetail({item}: Props){
    const {code, description, name} = item;
    return<div className="w-full">
        <h3 className="uppercase px-2 border border-bottom border-b-amber-800 font-medium">{name} {code ? `(${code})` : null}</h3>
        <p className="py-4 px-2 border border-bottom border-b-amber-800">
            {description}
        </p>
    </div>
}   