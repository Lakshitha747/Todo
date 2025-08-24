import { Button } from "antd";

type PrimaryButtonProps = {
    text: string;
    onClick: () => void;
}

export default function PrimaryButtonComponent(props: Readonly<PrimaryButtonProps>) {
    return (<Button type="primary" onClick={() => { props.onClick() }}>{props.text}</Button>)
}