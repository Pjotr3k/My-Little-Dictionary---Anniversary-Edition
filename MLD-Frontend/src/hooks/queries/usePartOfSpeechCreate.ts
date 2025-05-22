import { useMutation } from "react-query";
import getAxiosInstance from "../../helpers/axios-instance";
import { PartOfSpeechInsert } from "../../types/requests";
import { ApiResponse } from "../../types/api-communication";
import { Project } from "../../types/data-models";

export default function usePartOfSpeechCreate(){
    const axiosInstance = getAxiosInstance();

    return useMutation<ApiResponse<Project>, unknown, PartOfSpeechInsert>({
        mutationKey: ["part-of-speech"],
        mutationFn: async (data: PartOfSpeechInsert) =>
            axiosInstance.post("Linguistics/PartOfSpeech", data)
        .then((res) => res.data)        
    })
}