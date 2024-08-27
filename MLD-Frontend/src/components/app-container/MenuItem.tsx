import { NavLink } from "react-router-dom";

export type MenuItemProps = {
    to: string,
    label: string,
}

export default function MenuItem({to, label}: MenuItemProps){

    // className="w-full p-1.5 bg-amber-400"
    return <NavLink to={to} >
        <div className="w-full text-left bg-black bg-opacity-0 hover:bg-opacity-10 p-4 shadow-lg">{label}</div>
    </NavLink>
}