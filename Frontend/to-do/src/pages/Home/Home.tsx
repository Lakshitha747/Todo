import TextInputComponent from "../../components/Inputs/TextInput";
import TextAreaInputComponent from "../../components/Inputs/TextAreaInput";
import PrimaryButtonComponent from "../../components/Buttons/PrimaryButton";
import Card from "../../components/Card/Card";
import { useCards } from "./useHome";
import { Spin } from "antd";

import "./Home.scss";

export default function Home() {

    const { loading, cards, form, handleForms, add, complete } = useCards();

    return (<main className="home-container">
        <section className="left">
            <div className="form-wrappper">
                <form className="form">
                    <h1 className="heading">Add a Task</h1>
                    <TextInputComponent value={form.title} placeHolder="Title" maxLength={20} onChange={(value: string) => { handleForms("title", value); }} />
                    <TextAreaInputComponent value={form.description} placeHolder="Description" maxLength={40} onChange={(value: string) => { handleForms("description", value); }} />
                    <div className="button-wrapper">
                        <PrimaryButtonComponent text="Add" onClick={() => { add(); }} disabled={loading} />
                    </div>
                </form>
            </div>
        </section>
        <div className="divider" />
        <section className="right">
            <div className="card-wrapper">
                {loading
                    ? (<Spin />)
                    : (cards.map((card) => {
                        return (<Card key={card.id} title={card.title} description={card.description} complete={() => { complete(card.id); }} />)
                    }))
                }
            </div>
        </section>
    </main>)
}