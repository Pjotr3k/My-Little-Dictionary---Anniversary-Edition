import { useQuery } from "react-query";
import { PartOfSpeech } from "../../types/data-models";
import getAxiosInstance from "../../helpers/axios-instance";
import { ApiResponse, PaginationRequest } from "../../types/api-communication";

export default function usePartsOfSpeech(request: PaginationRequest, code: string){
    const axiosInstance = getAxiosInstance();

    const params = code ? `?code=${encodeURIComponent(code)}` : ""
    return useQuery<ApiResponse<Array<PartOfSpeech>>>({
        queryKey: ["parts-of-speech"],
        queryFn: async () =>
            axiosInstance.post(`Linguistics/PartOfSpeech/${code}`, request)
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