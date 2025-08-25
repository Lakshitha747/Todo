import { DeviceUUID } from "device-uuid";

function generateDeviceId() {
    let uuid = new DeviceUUID().get();
    localStorage.setItem("id", uuid)
    return uuid;
}

export function getDeviceId() {
    let uuid = localStorage.getItem("id");

    if (uuid === null) {
        return generateDeviceId();
    }

    return uuid;
}