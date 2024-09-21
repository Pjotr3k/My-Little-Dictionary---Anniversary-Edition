import { useQuery } from "react-query";
import { Language } from "../../types/data-models";
import getAxiosInstance from "../../helpers/axios-instance";
import { ApiResponse, PaginationRequest, PaginationResponse } from "../../types/api-communication";

export default function useLanguages(request: PaginationRequest){
    const axiosInstance = getAxiosInstance();
    return useQuery<PaginationResponse<Language>>({
        queryKey: ["languages"],
        queryFn: async () =>
            axiosInstance.post("/Linguistics/Languages", request)
        .then(res => res.data)
    })
}

export function useLanguage(id: string){
    const axiosInstance = getAxiosInstance();
  return useQuery<ApiResponse<Language>>({
      queryKey: ["language", id],
      queryFn: async () =>
        axiosInstance.get(`Linguistics/Language/${id}`)
      .then(res => res.data)
  })
}