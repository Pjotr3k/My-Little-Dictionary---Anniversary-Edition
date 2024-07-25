import { useQuery } from "react-query";
import { backendURL } from "../config";
import { ApiResponse, PartOfSpeech } from "../types";

export default function usePartsOfSpeech(code?: string){
    const params = code ? `?code=${encodeURIComponent(code)}` : ""
    return useQuery<ApiResponse<Array<PartOfSpeech>>>({
        queryKey: ["parts-of-speech"],
        queryFn: async () =>
            fetch(backendURL + "Linguistics/PartOfSpeech" + params)
        .then((res) => res.json())        
    })
}

export function usePartOfSpeech(id: string){
  return useQuery<ApiResponse<PartOfSpeech>>({
      queryKey: ["part-of-speech", id],
      queryFn: async () =>
          fetch(backendURL + `Linguistics/PartOfSpeech/${id}`)
      .then((res) => res.json())        
  })
}