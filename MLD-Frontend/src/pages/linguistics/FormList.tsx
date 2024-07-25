import ItemList from "../../components/ItemList";
import useForms from "../../hooks/useForms";
import FormItemDetail from "./FormItemDetail";

type Props = {
    partOfSpeechId: string
}

export default function FormList({partOfSpeechId}: Props){
    const {data, isLoading, isError} = useForms(partOfSpeechId);

    if(isLoading)
        return <div>Loading, please wait...</div>

    if(isError || !data?.result)
        return <div>Error fetching data</div>

    return <div>
        <ItemList data={data.result} detailsComponent={FormItemDetail} />
    </div>
}