import { NavLink } from "react-router-dom"

type Props = {
    to: string,
    label: string,
} & React.HTMLAttributes<HTMLDivElement>


export default function Card({to, label, ...rest}: Props){
    return <NavLink to={to} >
    <div className="h-[240px] w-[180px] bg-neutral-300 p-4" {...rest}>{label}</div>
</NavLink>
}