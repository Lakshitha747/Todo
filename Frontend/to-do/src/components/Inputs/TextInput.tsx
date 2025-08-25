import { Input } from "antd";

type TextInputComponentProps = {
    value: string;
    placeHolder: string;
    onChange: (value: string) => void;
    maxLength: number;
}

export default function TextInputComponent(props: Readonly<TextInputComponentProps>) {
    return (<Input value={props.value} placeholder={props.placeHolder} maxLength={props.maxLength} onChange={(value) => { props.onChange(value.target.value) }} />)
}