import { useQuery } from "react-query";
import { Project } from "../../types/data-models";
import getAxiosInstance from "../../helpers/axios-instance";
import { PaginationRequest, PaginationResponse } from "../../types/api-communication";

export default function useProjects(request: PaginationRequest){
    const axiosInstance = getAxiosInstance();
    return useQuery<PaginationResponse<Project>>({
        queryKey: ["projects"],
        queryFn: async () =>
            axiosInstance.post("/Project/Projects", request)
        .then(res => res.data)
    })
}