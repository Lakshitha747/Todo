export interface ICard {
    id: number;
    title: string;
    description: string;
}

export interface IError {
    detail: string;
    status: number;
    title: string;
    traceId: string;
    type: string;
}