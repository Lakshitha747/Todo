import { useEffect, useState } from "react";
import type { ICard } from "../../helpers/Interfaces";
import { getDeviceId } from "../../helpers/IdentifierFunctions";
import { ApiService } from "../../services/ApiService";

type formValueTypes = "title" | "description";

export function useCards() {
    const [cards, setCards] = useState<ICard[]>([
        { id: 1, title: "Hi", description: "Short desc" },
        { id: 2, title: "Sample title", description: "A medium length description here" },
        { id: 3, title: "Longer Title Example", description: "This description is a bit longer but still fits" },
        { id: 4, title: "Tiny", description: "Min" },
        { id: 5, title: "ExactlyTwentyChars!!", description: "This description uses forty characters max!!" }
    ]);
    const [form, setForm] = useState({ title: "", description: "" });
    const [loading, setLoading] = useState(false);

    const apiService = new ApiService();

    useEffect(() => {
        authenticate(getCards);
    }, [])

    const handleForms = (valueType: formValueTypes, value: string) => {
        setForm((prev) => ({ ...prev, [valueType]: value }))
    }

    const authenticate = (callback: CallableFunction) => {
        let uuid = getDeviceId();

        console.log("authenticate", uuid)
        callback();
    }

    const getCards = async () => {
        
        setLoading(true);

     await apiService.getTasks("d520c7a8-421b-4563-b955-f5abc56b97ec").then((response)=>{
let data=response.data;

console.log("data ",data)
     }).catch(err){
        handleApiErrors(err);
     }.finally(()=>{
        setLoading(false);
     })
    }

    const add = () => {
        console.log("form", form)
        console.log("add")
    }

    const complete = () => {
        console.log("complete")
    }

    return { loading,cards, handleForms, add, complete };
}
