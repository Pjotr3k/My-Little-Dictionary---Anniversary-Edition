import { Box, ButtonGroup } from "@mui/material"
import { WithID } from "../types"
import ItemListButton from "./ItemListButton"
import eyeIcon from "/icons/eye-icon.svg"
import editIcon from "/icons/pencil-icon.svg"
import { DetailedHTMLProps } from "react"

type Props<T> = {
    data: T,
    getEditRoute?: (item: T) => string,
    getBrowseRoute?: (item: T) => string,
    detailsComponent: React.ComponentType<{item: T}>,
} & DetailedHTMLProps<React.HTMLAttributes<HTMLDivElement>, HTMLDivElement>


export default function ListItem<T extends DetailedHTMLProps<React.HTMLAttributes<HTMLDivElement>, HTMLDivElement>>({data, detailsComponent: Details, getBrowseRoute, getEditRoute, ...rest} : Props<T>){
    const browseButton = getBrowseRoute
    ? <ItemListButton hint="browse" img={eyeIcon} name="Browse" to={getBrowseRoute(data)} key={`${data.id}-browse`} />
    : null

    const editButton = getEditRoute
    ? <ItemListButton hint="edit" img={editIcon} name="Edit" to={getEditRoute(data)} key={`${data.id}-edit`} />
    : null

    return <div {...rest} className={`flex flex-items-stretch w-full ${rest.className}`}>
            <div className="w-8">
                <ButtonGroup variant="text" className="w-full">
                {browseButton}
                {editButton}
            </ButtonGroup>
            </div>
                <Details item={data} />
        </div>
}