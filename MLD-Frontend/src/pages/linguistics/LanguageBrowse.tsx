import { useParams } from "react-router"
import { useLanguage } from "../../hooks/queries/useLanguages"
import PartsOfSpeechList from "./PartsOfSpeechList"
import useBreadcrumbs from "../../hooks/useBreadcrumbs"

export default function LanguageBrowse(){
    const {id} = useParams()
    const {data, isLoading, isError} = useLanguage(id!)

    useBreadcrumbs([
        {
            label: "Home",
            link: "/"
        },
        {
            label: "Linguistics",
            link: "/linguistics"
        },
        {
            label: data?.result.name ? data?.result.name : "Loading...",
            link: `/linguistics/${id}`
        }

    ])


    if(isLoading)
        return <div>Loading, please wait...</div>

    if(isError || !data?.result)
        return <div>Error fetching data</div>

    const {code, description,name} = data.result

    return<div className="border border-solid border-amber-600 p-4 flex flex-col gap-4">
        <h3 className="uppercase font-medium text-2xl border-b border-b-solid border-b-amber-600">{name} ({code})</h3>
        <p>
            {description}
        </p>
            <PartsOfSpeechList langCode={code} />
    </div>

}