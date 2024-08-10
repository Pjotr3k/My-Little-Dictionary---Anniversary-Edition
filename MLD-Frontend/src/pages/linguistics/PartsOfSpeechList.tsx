import ItemList from "../../components/ItemList";
import usePartsOfSpeech from "../../hooks/queries/usePartsOfSpeech";
import PartsOfSpeechItemDetail from "./PartsOfSpeechItemDetail";

type Props = {
    langCode: string
}

export default function PartsOfSpeechList({langCode}: Props){
    const {data, isLoading, isError} = usePartsOfSpeech(langCode);

    if(isLoading)
        return <div>Loading, please wait...</div>

    if(isError || !data?.result)
        return <div>Error fetching data</div>

    return <div>
        <ItemList data={data.result} detailsComponent={PartsOfSpeechItemDetail} />
    </div>
}