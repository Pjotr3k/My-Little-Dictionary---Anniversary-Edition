import { useQuery } from "react-query";
import { backendURL } from "../../config";
import { ApiResponse, PartOfSpeech } from "../../types";

export default function useForms(pos?: string){
    const params = pos ? `?code=${encodeURIComponent(pos)}` : ""
    return useQuery<ApiResponse<Array<PartOfSpeech>>>({
        queryKey: ["forms"],
        queryFn: async () =>
            fetch(backendURL + "Linguistics/Form" + params)
        .then((res) => res.json())        
    })
}

export function usePartOfSpeech(id: string){
  return useQuery<ApiResponse<PartOfSpeech>>({
      queryKey: ["form", id],
      queryFn: async () =>
          fetch(backendURL + `Linguistics/Form/${id}`)
      .then((res) => res.json())        
  })
}