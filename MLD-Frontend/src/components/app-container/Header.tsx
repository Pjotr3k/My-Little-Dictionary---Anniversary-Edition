import HeaderMenu from "./HeaderMenu"

export default function Header(){
    return <div className="h-28 sticky flex">
        <div className="p-6 w-full">
            <h2 className="font-semibold text-2xl capitalize">My Little Dictionary</h2>
            <h4>Anniversary Edition</h4>
        </div>
        {/* <ProjectData /> */}
        <HeaderMenu />
        </div>    
}