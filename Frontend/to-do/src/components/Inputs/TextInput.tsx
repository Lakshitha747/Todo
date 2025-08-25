import { Input } from "antd";

type TextInputComponentProps = {
    placeHolder: string;
    onChange: (value: string) => void;
    maxLength: number;
}

export default function TextInputComponent(props: Readonly<TextInputComponentProps>) {
    return (<Input placeholder={props.placeHolder} maxLength={props.maxLength} onChange={(value) => { props.onChange(value.target.value) }} />)
}