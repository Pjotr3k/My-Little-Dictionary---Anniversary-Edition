import { PropsWithChildren } from "react";

type Props = {
  name: string;
}

export default function FieldWrapper({name, children} : PropsWithChildren<Props>){
  return (
  <div className="flex flex-col gap-2">
    <label>{name}</label>
    {children}
  </div>)

}