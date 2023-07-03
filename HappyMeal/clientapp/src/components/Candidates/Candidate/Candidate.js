import { useContext } from "react";
import { AuthContext } from "../../../contexts/AuthContext";
import { useForm } from "../../../hooks/useForm";

export const Candidate = ({ id, fullName, phoneNumber, email, isActive }) => {
  const { approveCandidate } = useContext(AuthContext);
  const { values, changeHandler, onSubmit } = useForm(
    {
      ["id"]: id,
    },
    approveCandidate
  );

  return (
    <div className="card">
      <h2>{fullName}</h2>
      <p>{phoneNumber}</p>
      <p>{email}</p>
      {!isActive && <p>False</p>}
      <form method="POST" onSubmit={onSubmit}>
        <input value={values["id"]} onChange={changeHandler}></input>
        <input type="submit"></input>
      </form>
    </div>
  );
};
