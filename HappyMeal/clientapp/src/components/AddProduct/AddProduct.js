import { useContext } from "react";

import { useForm } from "../../hooks/useForm";
import { AuthContext } from "../../contexts/AuthContext";


const CreateFormKeys = {
    name: 'name',
    description: 'description',
    typeProduct: 'typeProduct',
    price: "price",
    minmoneyfororder: "minmoneyfororder",
    restaurantId: "restaurantId",
    weight: 'weight',
}

export const AddProduct = ({restaurant}) => {
    const { onCreateProduct } = useContext(AuthContext);
    const { values, changeHandler, onSubmit } = useForm({
        [CreateFormKeys.name]: '',
        [CreateFormKeys.description]: '',
        [CreateFormKeys.typeProduct]: 0,
        [CreateFormKeys.price]: 0,
        [CreateFormKeys.restaurantId]: restaurant.id,
        [CreateFormKeys.weight]:'',
    }, onCreateProduct);

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

                    <label htmlFor="text">Type Product:</label>
                    <select onChange={changeHandler} value={values[CreateFormKeys.imgurllink]} name={CreateFormKeys.typeProduct} id="typeProduct">
                        <option value="0">Food</option>
                        <option value="1">Drink</option>
                    </select>

                    <label htmlFor="number">Price:</label>
                    <input
                        type="number"
                        id="price"
                        name={CreateFormKeys.price}
                        placeholder="15min..,"
                        value={values[CreateFormKeys.price]}
                        onChange={changeHandler}
                    />

                    <label htmlFor="text">Weight:</label>
                    <input
                        type="text"
                        name={CreateFormKeys.weight}
                        id="weight"
                        value={values[CreateFormKeys.weight]}
                        onChange={changeHandler}
                    />

                    <input className="btn submit" type="submit" value="Create" />
                </div>
            </form>
        </section>

    );
};