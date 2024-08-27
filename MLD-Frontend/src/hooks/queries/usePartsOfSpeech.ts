import { useQuery } from "react-query";
import { ApiResponse, PartOfSpeech } from "../../types";
import getAxiosInstance from "../../helpers/axios-instance";

export default function usePartsOfSpeech(code?: string){
    const axiosInstance = getAxiosInstance();

    const params = code ? `?code=${encodeURIComponent(code)}` : ""
    return useQuery<ApiResponse<Array<PartOfSpeech>>>({
        queryKey: ["parts-of-speech"],
        queryFn: async () =>
            axiosInstance.get("Linguistics/PartOfSpeech" + params)
        .then((res) => res.data)        
    })
}

export function usePartOfSpeech(id: string){
    const axiosInstance = getAxiosInstance();

    return useQuery<ApiResponse<PartOfSpeech>>({
      queryKey: ["part-of-speech", id],
      queryFn: async () =>
        axiosInstance.get( `Linguistics/PartOfSpeech/${id}`)
      .then((res) => res.data)        
  })
}