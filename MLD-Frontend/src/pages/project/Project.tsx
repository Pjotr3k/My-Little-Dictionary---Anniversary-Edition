import Card from "../../components/Card"

const cards: Array<{to: string, label:string}> = [
    {
        label: "Linguistic",
        to: "lexicology",
    },
    {
        label: "Dictionary",
        to: "dictionary",
    },
    {
        label: "Library",
        to: "library",
    },
    {
        label: "Texts",
        to: "texts",
    },
]


export default function Project(){
    return <div className="flex flex-wrap p-6 gap-4">
        {cards.map(card => <Card to={card.to} label={card.label} />)}
    </div>
}