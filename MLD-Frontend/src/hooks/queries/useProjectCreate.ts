import { useMutation } from "react-query";
import getAxiosInstance from "../../helpers/axios-instance";
import { ProjectInsert } from "../../types/requests";
import { ApiResponse } from "../../types/api-communication";
import { Project } from "../../types/data-models";

export default function useProjectCreate(){
    const axiosInstance = getAxiosInstance();

    return useMutation<ApiResponse<Project>, unknown, ProjectInsert>({
        mutationKey: ["project"],
        mutationFn: async (data: ProjectInsert) =>
            axiosInstance.post("Linguistics/Project", data)
        .then((res) => res.data)        
    })
}