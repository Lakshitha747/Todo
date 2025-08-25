import type { AxiosError } from "axios";
import type { IError } from "./Interfaces";
import { showToast } from "./ToastFunctions";

export function getBaseURL() {
    return "http://localhost:8080";
}

export function handleApiErrors(error: AxiosError) {
    if (error.response) {

        let errorData = error.response.data as IError;

        if (errorData.detail) {
            return showToast("error", errorData.detail)
        } else {
            return showToast("error", errorData.title)
        }
    } else {
        return showToast("error", error.message)
    }
}