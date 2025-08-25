export interface ICard {
    id: string;
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