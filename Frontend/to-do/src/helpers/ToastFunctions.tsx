import { toast } from "react-toastify";

export function showToast(type: "success" | "warning" | "error", message: string) {
    toast[type](message);
}