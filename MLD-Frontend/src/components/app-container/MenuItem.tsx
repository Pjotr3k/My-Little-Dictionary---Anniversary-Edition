import { NavLink } from "react-router-dom";

export type MenuItemProps = {
    to: string,
    label: string,
} & React.HTMLAttributes<HTMLDivElement>

export default function MenuItem({to, label, ...rest}: MenuItemProps){

    return <NavLink to={to} >
        <div {...rest}>{label}</div>
    </NavLink>
}