import MenuItem, { MenuItemProps } from "./MenuItem";

const menuItems: Array<MenuItemProps> = [
    {
        to: "/",
        label: "Home"
    },
   {
        to: "/auth/logout",
        label: "Log Out"
    }

]
export default function SideMenu(){
    return <div className="w-[240px] border-solid border-amber-600">
        {menuItems.map(item => <MenuItem {...item} className="w-full text-left bg-black bg-opacity-0 hover:bg-opacity-10 p-4 shadow-lg"/>)}
    </div>
}