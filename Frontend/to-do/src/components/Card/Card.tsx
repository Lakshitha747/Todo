import DefaultButtonComponent from "../Buttons/DefaultButton";

import "./Card.scss";

type CardProps = {
    title: string;
    description: string;
    complete: () => void;
}

export default function Card(props: Readonly<CardProps>) {
    return (<div className="card-container">
        <div className="text-wrapper">
            <h1 className="title">{props.title}</h1>
            <h3 className="description">{props.description}</h3>
        </div>
        <div className="button-wrapper">
            <DefaultButtonComponent text="Done" onClick={props.complete} />
        </div>
    </div>)
}