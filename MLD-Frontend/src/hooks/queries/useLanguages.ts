import { useQuery } from "react-query";
import { ApiResponse, Language } from "../../types";
import getAxiosInstance from "../../helpers/axios-instance";

export default function useLanguages(){
    const axiosInstance = getAxiosInstance();
    return useQuery<ApiResponse<Array<Language>>>({
        queryKey: ["languages"],
        queryFn: async () =>
            axiosInstance.get("/Linguistics/Language",)
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