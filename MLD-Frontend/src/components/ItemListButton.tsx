import { Button } from "@mui/material";
import { Link } from "react-router-dom";

type Props = {
    img: string,
    to: string,
    name: string,
    hint: string,
}

export default function ItemListButton({hint, img, name, to}:Props){

    return <Link to={to}>
    <Button>
        <img src={img} />
    </Button>
    </Link>
}