import React, {useEffect, useState} from 'react';


function DisplayUsers(){
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [users, setUsers] = useState([]);

    useEffect(()=>{
        fetch("https://localhost:5001/api/users")
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setUsers(result);
                },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    },[])

    if(error) {
        return <div>Ошибка: {error.message}</div>
    } else if(!isLoaded) {
        return <div>Загрузка...</div>
    } else{
        return (
            <ul>
                {users.map(item => (
                    <li key={item.id}>
                        Name: {item.name}, Surname: {item.surname === "" ? item.surname : "und"}
                    </li>
                ))}
            </ul>
        )
    }
}

export default DisplayUsers;