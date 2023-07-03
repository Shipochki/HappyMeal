export const Candidate = ({
    id,
    fullName,
    phoneNumber,
    email,
    isActive
}) => {
    return(
        <div className="card">
            <h2>{fullName}</h2>
            <p>{phoneNumber}</p>
            <p>{email}</p>
            {!isActive && (
                <p>False</p>
            )}
        </div>
    )
}