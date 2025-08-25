import { useEffect, useState } from "react";
import type { ICard } from "../../helpers/Interfaces";
import { getDeviceId } from "../../helpers/IdentifierFunctions";
import { ApiService } from "../../services/ApiService";
import { handleApiErrors } from "../../helpers/ApiFunctions";
import { showToast } from "../../helpers/ToastFunctions";

type formValueTypes = "title" | "description";

export function useCards() {
    const [uuid, setUUID] = useState<string>("");
    const [cards, setCards] = useState<ICard[]>([]);
    const [form, setForm] = useState({ title: "", description: "" });
    const [loading, setLoading] = useState(false);

    const apiService = new ApiService();

    useEffect(() => {
        authenticate();
    }, [])

    useEffect(() => {
        if (uuid) {
            getCards();
        }
    }, [uuid])

    const handleForms = (valueType: formValueTypes, value: string) => {
        setForm((prev) => ({ ...prev, [valueType]: value }))
    }

    const clearFormFields = () => {
        setForm({ title: "", description: "" });
    }

    const authenticate = () => {
        let uuid = getDeviceId();
        setUUID(uuid);
    }

    const getCards = async () => {
        setLoading(true);

        await apiService.getTasks(uuid).then((response) => {
            let data = response.data;
            setCards(data?.tasks);
        }).catch((err) => {
            handleApiErrors(err);
        }).finally(() => {
            setLoading(false);
        })
    }

    const add = async () => {
        setLoading(true);

        await apiService.createTask(form.title, form.description, uuid).then((_) => {
            showToast("success", "Task Created");
            clearFormFields();
        }).catch((err) => {
            handleApiErrors(err);
        }).finally(async () => {
            await getCards();
            setLoading(false);
        })
    }

    const complete = async (selectedTaskId: string) => {
        setLoading(true);

        await apiService.completeTask(selectedTaskId).then((_) => {
            showToast("success", "Task Completed");
        }).catch((err) => {
            handleApiErrors(err);
        }).finally(async () => {
            await getCards();
            setLoading(false);
        })
    }

    return { loading, cards, form, handleForms, add, complete };
}
