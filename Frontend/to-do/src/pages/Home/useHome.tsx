import { useEffect, useState } from "react";
import type { ICard } from "../../helpers/Interfaces";

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

    useEffect(() => {
        authenticate(getCards);
    }, [])

    const handleForms = (valueType: formValueTypes, value: string) => {
        setForm((prev) => ({ ...prev, [valueType]: value }))
    }

    const authenticate = (callback: CallableFunction) => {
        console.log("authenticate")
        callback();
    }

    const getCards = () => {
        console.log("get cards")
    }

    const add = () => {
        console.log("form", form)
        console.log("add")
    }

    const complete = () => {
        console.log("complete")
    }

    return { cards, handleForms, add, complete };
}
