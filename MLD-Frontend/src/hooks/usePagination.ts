import { useEffect, useState } from "react";
import { PaginationRequest, PaginationResponse } from "../types/api-communication";
import { UseQueryResult } from "react-query";

type Props<T extends object> = {
  itemKey: (item: T) => string
  useItems: (request: PaginationRequest) => UseQueryResult<PaginationResponse<T>, unknown>
}

export default function usePaginateQuery<T extends object>({useItems, itemKey} : Props<T>){
  const [pageNumber, setPageNumber] = useState(1)
  const [items, setItems] = useState<T[]>([])
  const [searchPhrase, setSearchPhrase] = useState("")

  const {data, refetch} = useItems({
    pageNumber: pageNumber,
    pageSize: 10,
    searchPhrase: searchPhrase,
  })  

  function handleSearch(searchPhrase: string){
    setItems([]);
    setPageNumber(1);
    setSearchPhrase(searchPhrase);
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
      setItems(prev => {
        const toAdd = newLangs.filter(itemA => {
          const keyA = itemKey(itemA)
          !prev.some(itemB => keyA === itemKey(itemB))
        })
        return [...prev, ...toAdd]
      }
    )
    })
  }, [pageNumber])

  return {
    items,
    data,
    searchPhrase,
    handleSearch,
    pageNumber,
    setPageNumber
  }
}