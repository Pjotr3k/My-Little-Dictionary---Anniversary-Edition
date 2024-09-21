import { useSelector } from "react-redux"
import { NavLink, useLocation } from "react-router-dom";
import { Breadcrumb } from "../../types/data-models";
import { Fragment } from "react/jsx-runtime";

export default function Breadcrumbs(){
    const breadcrumbs: Breadcrumb[] = useSelector(state => {        
        return state.breadcrumbs.items
    });

    const location = useLocation();
  const { pathname } = location;

    const mapped = breadcrumbs.map((bc, idx) => {
        const {link, label} = bc;
        const separator = idx !== breadcrumbs.length - 1 && "/"
        return <Fragment key={idx}>
            <NavLink  className={() => link === pathname ? "font-semibold" : "underline"} to={link}>{label}</NavLink>
        <span>
            {separator}
            </span>
            </Fragment>
    })

    return <div className="flex gap-4 h-8 px-1 pb-0 pt-auto">
        {mapped}
    </div>
}