import { WithID } from "../types"
import ListItem from "./ListItem"

type Props<T extends WithID> = {
    data: T[],
    getEditRoute?: (item: T) => string,
    getBrowseRoute?: (item: T) => string,
    addRoute?: string,
    detailsComponent: React.ComponentType<{item: T}>,
    addComponent?: JSX.Element,
}

export default function ItemList<T extends WithID>({data, addComponent, detailsComponent, addRoute, getBrowseRoute, getEditRoute} :Props<T>){
    return <ul className="flex flex-col gap-2">
        {data.map(item => <ListItem
            key={item.id}
            data={item}
            detailsComponent={detailsComponent}
            getBrowseRoute={getBrowseRoute}
            getEditRoute={getEditRoute}
            />)}
    </ul>
}