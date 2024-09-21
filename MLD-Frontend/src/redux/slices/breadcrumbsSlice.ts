import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Breadcrumb } from "../../types/data-models";



type StateType = {

    items: Breadcrumb[];
}

const initialState: StateType = {
    items: [],
}

const breadcrumbsSlice = createSlice({
    name: 'breadcrumbs',
    initialState: initialState,
    reducers: {
        setBreadcrumbs(state, action: PayloadAction<Array<Breadcrumb>>){
            state.items = action.payload;
        }
    }
})

export {breadcrumbsSlice }
export const breadcrumbsActions = breadcrumbsSlice.actions