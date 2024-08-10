import { configureStore } from "@reduxjs/toolkit";
import {breadcrumbsSlice, breadcrumbsActions} from "./slices/breadcrumbsSlice";

const store = configureStore({
    reducer: {
        breadcrumbs: breadcrumbsSlice.reducer
    }
})

export { store, breadcrumbsActions };