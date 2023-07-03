import { useContext } from "react";

import { useForm } from "../../hooks/useForm";
import { AuthContext } from "../../contexts/AuthContext";

const CreateFormKeys = {
    name: 'name',
    description: 'description',
    imgurllink: 'imgurllink',
    deliverytime: "deliverytime",
    minmoneyfororder: "minmoneyfororder",
    ownerId:"ownerId",
    cityname: 'cityname',
}

export const AddRestaurant = () => {
    const { onCreateRestaurant, userId } = useContext(AuthContext);
    const { values, changeHandler, onSubmit } = useForm({
        [CreateFormKeys.name]: '',
        [CreateFormKeys.description]: '',
        [CreateFormKeys.imgurllink]: '',
        [CreateFormKeys.deliverytime]: 0,
        [CreateFormKeys.minmoneyfororder]: 0,
        [CreateFormKeys.ownerId]: userId,
        [CreateFormKeys.cityname]:'',
    }, onCreateRestaurant);

    return (
        <section id="create-page" className="content auth">
            <form id="create" method="post" onSubmit={onSubmit}>
                <div className="container">
                    <div className="brand-logo"></div>
                    <h1>Create</h1>

                    <label htmlFor="text">Name:</label>
                    <input
                        type="text"
                        id="name"
                        name={CreateFormKeys.name}
                        placeholder="MacDonalds"
                        value={values[CreateFormKeys.name]}
                        onChange={changeHandler}
                    />

                    <label htmlFor="text">Description:</label>
                    <textarea
                        type="text"
                        id="description"
                        name={CreateFormKeys.description}
                        placeholder="Description here...."
                        value={values[CreateFormKeys.description]}
                        onChange={changeHandler}
                    />

                    <label htmlFor="text">ImgUrlLink:</label>
                    <input
                        type="text"
                        id="imgurllink"
                        name={CreateFormKeys.imgurllink}
                        placeholder="Link here..."
                        value={values[CreateFormKeys.imgurllink]}
                        onChange={changeHandler}
                    />

                    <label htmlFor="number">DeliveryTime:</label>
                    <input
                        type="number"
                        id="deliverytime"
                        name={CreateFormKeys.deliverytime}
                        placeholder="15min..,"
                        value={values[CreateFormKeys.deliverytime]}
                        onChange={changeHandler}
                    />

                    <label htmlFor="number">MinMoneyForOrder:</label>
                    <input
                        type="number"
                        name={CreateFormKeys.minmoneyfororder}
                        id="minmoneyfororder"
                        value={values[CreateFormKeys.minmoneyfororder]}
                        onChange={changeHandler}
                    />

                    <label htmlFor="text">CityName</label>
                    <input
                        type="text"
                        name={CreateFormKeys.cityname}
                        id="cityname"
                        value={values[CreateFormKeys.cityname]}
                        onChange={changeHandler}
                    />

                    <input className="btn submit" type="submit" value="Create" />
                </div>
            </form>
        </section>

    );
};