import { ButtonGroup, SwipeableDrawer } from "@mui/material";
import MenuItem, { MenuItemProps } from "./MenuItem";
import { convertLength } from "@mui/material/styles/cssUtils";

const menuItems: Array<MenuItemProps> = [
    {
        to: "/",
        label: "Home"
    },
    {
        to: "/linguistics",
        label: "Language Admin"
    }
]
////className="w-[240px] p-0.5 bg-amber-600 flex flex-col gap-0.5">
export default function SideMenu(){
    return <div className="w-[240px] border-solid border-amber-600">
        {menuItems.map(item => <MenuItem {...item} />)}
    </div>
}