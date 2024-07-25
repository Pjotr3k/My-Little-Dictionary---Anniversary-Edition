import ItemList from "../../components/ItemList";
import useLanguages from "../../hooks/useLanguages";
import { Language } from "../../types";
import LanguageItemDetail from "./LanguageItemDetail";

export default function Linguistics(){
    const {data, isLoading, isError} = useLanguages();

    if(isLoading)
        return <div>Loading, please wait...</div>

    if(isError || !data?.result)
        return <div>Error fetching data</div>

    return <div>
        <ItemList data={data.result} detailsComponent={LanguageItemDetail} getBrowseRoute={getBrowseRoute} />
    </div>
}

function getBrowseRoute(item: Language){
    return `/linguistics/${item.id}`
}