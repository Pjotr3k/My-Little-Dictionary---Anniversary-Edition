import { useQuery } from "react-query";
import getAxiosInstance from "../../helpers/axios-instance";
import { ApiResponse } from "../../types/api-communication";
import { Project } from "../../types/data-models";

export function useProject(code: string) {
  const axiosInstance = getAxiosInstance();
  return useQuery<ApiResponse<Project>>({
    queryKey: ["project", code],
    queryFn: async () =>
      axiosInstance
        .get(`Linguistics/Project/${code}`)
        .then((res) => res.data),
  });
}
