import MenuItem, { MenuItemProps } from "./MenuItem";

const menuItems: Array<MenuItemProps> = [
    {
        to: "/account",
        label: "Account"
    },
    {
        to: "/auth/logout",
        label: "Log Out"
    }

]
export default function HeaderMenu(){
    return <div className="border-solid flex border-amber-600">
        {menuItems.map(item => <MenuItem className="w-[120px] grid grid-cols-1 place-items-center h-full text-center bg-black bg-opacity-0 hover:bg-opacity-10 p-4 shadow-lg" {...item} />)}
    </div>
}