import Card from "../components/Card";

const cards: Array<{to: string, label:string}> = [
    {
        label: "Browse your projects...",
        to: "my-projects",
    },
    {
        label: "...discover projects of others...",
        to: "projects",
    },
    {
        label: "...or create new project",
        to: "new-project",
    },

]

export default function Home(){
    return <div className="flex flex-wrap p-6 gap-4">
        {cards.map(card => <Card to={card.to} label={card.label} />)}
    </div>
}