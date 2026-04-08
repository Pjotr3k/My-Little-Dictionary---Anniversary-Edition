import { useMutation } from "react-query";
import getAxiosInstance from "../../helpers/axios-instance";
import { ApiResponse } from "../../types/api-communication";
import { Dictionary } from "../../types/data-models";
import { DictionaryInsert } from "../../types/requests";

export default function useDictionaryCreate(){
    const axiosInstance = getAxiosInstance();

    return useMutation<ApiResponse<Dictionary>, unknown, DictionaryInsert>({
        mutationKey: ["dictionary"],
        mutationFn: async (data: DictionaryInsert) =>
            axiosInstance.post("Dictionary/Dictionary", data)
        .then((res) => res.data)        
    })
}