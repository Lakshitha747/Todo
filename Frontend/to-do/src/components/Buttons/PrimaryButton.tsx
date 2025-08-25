import { Button } from "antd";

type PrimaryButtonProps = {
    text: string;
    onClick: () => void;
    disabled: boolean;
}

export default function PrimaryButtonComponent(props: Readonly<PrimaryButtonProps>) {
    return (<Button type="primary" onClick={() => { props.onClick() }} disabled={props.disabled}>{props.text}</Button>)
}