import MenuItem, { MenuItemProps } from "./MenuItem";

const menuItems: Array<MenuItemProps> = [
    {
        to: "/",
        label: "Home"
    },
    {
        to: "/linguistics",
        label: "Language Admin"
    },
    {
        to: "/auth/logout",
        label: "Log Out"
    }

]
export default function SideMenu(){
    return <div className="w-[240px] border-solid border-amber-600">
        {menuItems.map(item => <MenuItem {...item} />)}
    </div>
}