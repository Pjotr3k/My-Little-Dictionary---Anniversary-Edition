import { useDispatch } from "react-redux";
import { breadcrumbsActions } from "../redux/slices/breadcrumbsSlice";
import { Breadcrumb } from "../types/data-models";
import { useEffect } from "react";

export default function useBreadcrumbs(breadcrumbs: Breadcrumb[]){
    useEffect(() => {
        return () => {
    dispatch(breadcrumbsActions.setBreadcrumbs([]))
}
    }, [])
    const dispatch = useDispatch();
    dispatch(breadcrumbsActions.setBreadcrumbs(breadcrumbs))
}