export function setParams(key: string, ...values: Array<string>){
    const elems = values.map(val => `${key}=${encodeURIComponent(val)}`)
    return elems.join("&", )
}