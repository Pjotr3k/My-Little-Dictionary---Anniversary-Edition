import { useQuery } from "react-query";
import { ApiResponse, PartOfSpeech } from "../../types/data-models";
import getAxiosInstance from "../../helpers/axios-instance";

export default function useForms(pos?: string){
    const axiosInstance = getAxiosInstance();

    const params = pos ? `?pos=${encodeURIComponent(pos)}` : ""
    return useQuery<ApiResponse<Array<PartOfSpeech>>>({
        queryKey: ["forms", params],
        queryFn: async () =>
            axiosInstance.get("Dictionary/Form" + params)
        .then((res) => res.data)        
    })
}

export function usePartOfSpeech(id: string){
    const axiosInstance = getAxiosInstance();

  return useQuery<ApiResponse<PartOfSpeech>>({
      queryKey: ["form", id],
      queryFn: async () =>
          axiosInstance.get(`Dictionary/Form/${id}`)
      .then((res) => res.data)        
  })
}