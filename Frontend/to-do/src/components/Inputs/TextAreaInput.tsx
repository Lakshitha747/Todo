import { Input } from "antd";

type TextAreaInputComponentProps = {
    placeHolder: string;
    onChange: (value: string) => void;
    maxLength: number;
}

export default function TextAreaInputComponent(props: Readonly<TextAreaInputComponentProps>) {
    return (<Input.TextArea placeholder={props.placeHolder} maxLength={props.maxLength} onChange={(value) => { props.onChange(value.target.value) }} />)
}