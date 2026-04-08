import { Input } from "@mui/material";
import { PaginationRequest, PaginationResponse } from "../types/api-communication";
import { UseQueryResult } from "react-query";
import usePaginateQuery from "../hooks/usePagination";

type Props<T extends object> = {
  itemKey: (item: T) => string
  selectedItem?: T;
  setItem: (item: T) => void,
  useItems: (request: PaginationRequest) => UseQueryResult<PaginationResponse<T>, unknown>
  mapper: (item: T) => JSX.Element | string | null
  maxHeight: number | string
} & React.HTMLAttributes<HTMLUListElement>

export default function SelectList<T extends object>({selectedItem, setItem, mapper, useItems, itemKey, ...rest} : Props<T>){
  const {data, searchPhrase, handleSearch, items, setPageNumber} = usePaginateQuery({itemKey, useItems})

  console.log("selectList", {items, ...data});
  
  
  function handleScroll(e: React.UIEvent<HTMLUListElement, UIEvent>){
    const elem = e.currentTarget;
    if(!data?.result.overlimit && elem.scrollTop + elem.clientHeight >= elem.scrollHeight)
      setPageNumber(prev => prev+1)
    }
    
    return <>
      <Input value={searchPhrase} onChange={(e) => handleSearch(e.target.value)} placeholder="Search language" />
      <ul {...rest} onScroll={(e) => handleScroll(e)} className={`overflow-auto ${rest.className}`}>
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