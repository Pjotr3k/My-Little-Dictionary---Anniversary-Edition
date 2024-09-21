import { Input } from "@mui/material";
import { useEffect, useState } from "react";
import { PaginationRequest, PaginationResponse } from "../types/api-communication";
import { UseQueryResult } from "react-query";

type Props<T extends object> = {
    itemKey: (item: T) => string
    selectedItem?: T;
    setItem: (item: T) => void,
    useItems: (request: PaginationRequest) => UseQueryResult<PaginationResponse<T>, unknown>
    mapper: (item: T) => JSX.Element | string | null
    maxHeight: number | string
}

export default function SelectList<T extends object>({selectedItem, setItem, mapper, useItems, itemKey, maxHeight=36} : Props<T>){
    const [pageNumber, setPageNumber] = useState(1)
    const [items, setItems] = useState<T[]>([])
    const [searchPhrase, setSearchPhrase] = useState("")
    const {data, refetch} = useItems({
        pageNumber: pageNumber,
        pageSize: 10,
        searchPhrase: searchPhrase,
    })

    function handleSearch(e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>){
        setItems([]);
        setPageNumber(1);
        setSearchPhrase(e.target.value);
    }

    function handleScroll(e: React.UIEvent<HTMLUListElement, UIEvent>){
        const elem = e.currentTarget;
        if(!data?.overlimit && elem.scrollTop + elem.clientHeight >= elem.scrollHeight)
            setPageNumber(prev => prev+1)
    }

    useEffect(() => {
        refetch().then((val) => {
            const newLangs = val?.data?.result || []
            setItems(newLangs)
        }
        )
    }, [searchPhrase])

    useEffect(() => {
        refetch().then((val) => {
            const newLangs = val?.data?.result || []
            setItems(prev => [...prev, ...newLangs])
        }
        )
    }, [pageNumber])

    return <>
            {selectedItem ? <div className="p-3 border border-solid border-amber-700">{mapper(selectedItem)}</div> : null}
            <Input value={searchPhrase} onChange={(e) => handleSearch(e)} placeholder="Search language" />
            <ul onScroll={(e) => handleScroll(e)} className={`overflow-auto max-h-36`}>
                {items?.map(item => {
                    const selected = selectedItem && itemKey(item) === itemKey(selectedItem)
                    const selectedClass = selected ? " bg-black bg-opacity-20" : "";
                    
                    return (
                    <li
                        key={itemKey(item)}
                        className={"p-1 hover:bg-black hover:bg-opacity-20 hover:cursor-pointer" + selectedClass}
                        onClick={() => setItem(item)}
                    >
                        {mapper(item)}
                    </li>)
                })}
            </ul>
    </>
}