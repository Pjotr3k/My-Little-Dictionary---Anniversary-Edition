export type CollectionItem<T> = {
  orderNo: number;
  element: T;
}

export type CollectionActions<T> = {
  addItem: (elem: T) => void;
  modifyItem: (item: CollectionItem<T>) => void;
  removeItem: (orderNo: number) => void;
}

export type Collection<T> = CollectionItem<T>[]

export function addItem<T>(elem: T, setItems: React.Dispatch<React.SetStateAction<Collection<T>>>){
  setItems(prev => {
    const orderNo = prev.length
      ? prev.reduce((highest, current) => 
        current.orderNo > highest.orderNo ? current : highest).orderNo + 1
      : 0;

    return [...prev, {orderNo, element: elem}]
  })
}

export function modifyItem<T>(item: CollectionItem<T>, setItems: React.Dispatch<React.SetStateAction<Collection<T>>>){
  setItems(prev => prev.map(elem => elem.orderNo === item.orderNo
    ? item
    : elem
  ))
}

export function removeItem<T>(orderNo: number, setItems: React.Dispatch<React.SetStateAction<Collection<T>>>){
  setItems(prev => 
    prev.filter(elem => elem.orderNo !== orderNo))
}

export default function getCollectionActions<T>(setItems: React.Dispatch<React.SetStateAction<Collection<T>>>){
  return {
    addItem: (elem: T) => addItem(elem, setItems),
    modifyItem: (item: CollectionItem<T>) => modifyItem(item, setItems),
    removeItem: (orderNo: number) => removeItem(orderNo, setItems),
  }
}

export function getData<T>( collection:Collection<T>){
  return collection.map(item => item.element)
}