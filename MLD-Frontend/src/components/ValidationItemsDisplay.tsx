type TStyle = "error" | "warning" | "info";

type Props = {
    items: string[];
    style: TStyle
}

const styles: Record<TStyle, string> ={
    error: "border-red-700 bg-red-400",
    warning: "border-yellow-700 bg-yellow-400",
    info: "border-blue-700 bg-blue-400",
}

export default function ValidationItemsDisplay({items, style}: Props){
    const mappedItems = items.map((item, idx) => <div key={idx} className={`p-2 border border-solid ${styles[style]}`}>
        {item}
    </div>)
return <div className="flex flex-col gap-1">
    {mappedItems}
</div>
}