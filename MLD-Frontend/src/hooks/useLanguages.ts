import { useQuery } from "react-query";
import { backendURL } from "../config";
import { ApiResponse, Language } from "../types";

export default function useLanguages(){
    return useQuery<ApiResponse<Array<Language>>>({
        queryKey: ["languages"],
        queryFn: async () =>
            fetch(backendURL + "Linguistics/Language")
        .then((res) => res.json())        
    })
}

export function useLanguage(id: string){
  return useQuery<ApiResponse<Language>>({
      queryKey: ["language", id],
      queryFn: async () =>
          fetch(backendURL + `Linguistics/Language/${id}`)
      .then((res) => res.json())        
  })
}