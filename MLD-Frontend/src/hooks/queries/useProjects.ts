import { useQuery } from "react-query";
import { Project } from "../../types/data-models";
import getAxiosInstance from "../../helpers/axios-instance";
import { ApiResponse, PaginationRequest, PaginationResponse } from "../../types/api-communication";

export default function useProjects(request: PaginationRequest){
    const axiosInstance = getAxiosInstance();
    return useQuery<PaginationResponse<Project>>({
        queryKey: ["projects"],
        queryFn: async () =>
            axiosInstance.post("/Linguistics/Projects", request)
        .then(res => res.data)
    })
}

export function useProject(id: string){
    const axiosInstance = getAxiosInstance();
  return useQuery<ApiResponse<Project>>({
      queryKey: ["project", id],
      queryFn: async () =>
        axiosInstance.get(`Linguistics/Project/${id}`)
      .then(res => res.data)
  })
}