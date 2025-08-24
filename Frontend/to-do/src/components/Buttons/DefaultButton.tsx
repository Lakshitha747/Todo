import { Button } from "antd";

import "./Buttons.scss";

type DefaultButtonProps = {
    text: string;
    onClick: () => void;
}

export default function DefaultButtonComponent(props: Readonly<DefaultButtonProps>) {
    return (<Button className="default-button" onClick={() => { props.onClick() }}>{props.text}</Button>)
}