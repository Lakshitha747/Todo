import type { AxiosInstance } from "axios";
import axios from "axios";
import { getBaseURL } from "../helpers/ApiFunctions";

export class ApiService {
    private readonly api: AxiosInstance;

    constructor() {
        this.api = axios.create({
            baseURL: getBaseURL(),
            headers: {
                "Content-Type": "application/json",
            },
        });
    }

    async getTasks(deviceId: string) {
        return await this.api.get("/api/Task", { params: { deviceId } });
    }

    async createTask(title: string, description: string, deviceId: string) {
        return await this.api.post("/api/Task",
            {
                deviceId,
                title,
                description,
            }
        );
    }

    async completeTask(taskId: string) {
        await this.api.post("/api/Task/complete", { taskId });
    }
}
