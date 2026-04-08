import { useQuery } from "react-query";
import { DictionaryData } from "../../types/data-models";
import getAxiosInstance from "../../helpers/axios-instance";
import { ApiResponse } from "../../types/api-communication";

export function useDictionaryData(projectId: string){
    const axiosInstance = getAxiosInstance();

  return useQuery<ApiResponse<{[dictionaryId: string] : DictionaryData}>>({
      queryKey: ["DictionaryData", projectId],
      queryFn: async () =>
          axiosInstance.get(`Dictionary/DictionaryDataByProject/${projectId}`)
      .then((res) => res.data)        
  })
}